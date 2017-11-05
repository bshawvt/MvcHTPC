using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcHTPC.Services
{
    public class AuthService
    {
        private MvcHTPCContext db = new MvcHTPCContext();

        public AuthService(string potatoes)
        {
            string hash = _sha256Hash(potatoes); // incoming from client side
            string salt = _createSalt(); // db.user.salt
            string cook = _cook(hash, salt); // db.user.password
            //Debug.WriteLine("* hash = {0}\n* salt = {1}\n* hash+salt:{2}", hash, salt, cook);

        }

        public bool CreateNewUser(string username, string password, string email)
        {
            string salt = _createSalt();
            Debug.WriteLine("username = {0}\naccessLevel = {1}\ndateOfCreation = {2}\nemail = {3}\npassword = {4}\nsalt = {5}", username,
            Models.DbModels.DbStaticEnums.AccessLevel.UNVERIFIED,
            DateTime.Today,
            email,
            _cook(_sha256Hash(password), salt),
            salt);

            db.tblUsers.Add(new users
            {
                username = username,
                accessLevel = Models.DbModels.DbStaticEnums.AccessLevel.UNVERIFIED,
                dateOfCreation = DateTime.Today,
                email = email,
                password = _cook(_sha256Hash(password), salt),
                salt = salt

            });
            db.SaveChanges();
            return false;
        }

        public bool IsUsernameTaken(string username)
        {
            if (db.tblUsers.FirstOrDefault(x => x.username.ToLower() == username.ToLower()) != null)
            {
                return true;
            }
            return false;
        }
        public bool IsEmailTaken(string email)
        {
            if (db.tblUsers.FirstOrDefault(x => x.email.ToLower() == email.ToLower()) != null)
            {
                return true;
            }
            return false;
        }
        public string GetHash(string potatoes)
        {
            return _sha256Hash(potatoes);
        }
        public users Authenticate(string username, string password)
        {

            //MvcHTPCContext db = new MvcHTPCContext();
            users user = db.tblUsers.Where(x => x.username.ToLower().Equals(username.ToLower())).FirstOrDefault();
            if (user != null)
            {
                
                Debug.WriteLine("authenticateUser: user exists.. getting salt and password..");
                string hash = user.password;
                string salt = user.salt;
                Debug.WriteLine("username = {0}\npasword = {1}\ndbSalt = {2}\ndbPassword = {3}\nMy Mix = {4}", username, password, salt, hash, _cook(_sha256Hash(password), salt));
                if (hash.Equals(_cook(_sha256Hash(password), salt)))
                {
                    Debug.WriteLine("password match");
                    return user;
                }
                else
                {
                    Debug.WriteLine("Passwords don't match!");
                    return null;
                }
              
            }
            Debug.WriteLine("This user does not exist..");
            return null;
        }


        private string _createSalt()
        {// returns a random sequence of bytes. added to db.users column
            byte[] rbytes = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(rbytes);
            return Convert.ToBase64String(rbytes);
        }

        private string _sha256Hash(string str)
        {// hash a string.
            // passwords should come in as sha256
            SHA256 sh = SHA256Managed.Create();
            byte[] msg = new byte[str.Length];

            byte[] byteString = Encoding.ASCII.GetBytes(str);

            Array.Copy(byteString, msg, str.Length);
            byte[] hash = sh.ComputeHash(msg);
            string t_hash = "";
            foreach(var i in hash)
               t_hash += String.Format("{0:X2}", i);
            return t_hash;
        }

        private string _cook(string hash, string salt)
        {// add salt to hash and razzle dazzle
            // _cook().compare(db.user.password)
            const int ITERATIONS = 10000;

            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            byte[] hashSalad = new Rfc2898DeriveBytes(hash, saltBytes, ITERATIONS).GetBytes(32);

            string hashString = Convert.ToBase64String(hashSalad);

            //Debug.WriteLine("hash = {0}\nsalt = {1}\nmix = {2}", hash, salt, hashString);

            return hashString;
        }
    }

}