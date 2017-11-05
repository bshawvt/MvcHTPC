using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Models.DbModels
{
    public static class DbStaticEnums
    {
        public enum HiddenState
        {
            VISIBLE,            // appears in searches?
            PRIVATE,              // only shown to members of group 
            HIDDEN,               // does not appear in searchs

        };

        public enum AccessLevel
        {
            DEACTIVATED, // all accounts should be created as deactivated
            UNVERIFIED, // email authentication never completed
            MODERATOR, // todo: 
            ADMINISTRATOR, // todo:
            ROOT, // todo:
            // do not modified the above order!

            BANNED,
            USER
        };
    }
}