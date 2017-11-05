using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcHTPC.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MvcHTPCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MvcHTPCContext() : base("name=MvcHTPCContext")
        {
        }
        // groups
        public System.Data.Entity.DbSet<MvcHTPC.Models.groups> tblGroups { get; set; }
        // user accounts & statistics
        public System.Data.Entity.DbSet<MvcHTPC.Models.users> tblUsers { get; set; }
        // Forum folders and sub folders
        public System.Data.Entity.DbSet<MvcHTPC.Models.forums> tblForums { get; set; }
        // folders are basically threads
        public System.Data.Entity.DbSet<MvcHTPC.Models.folders> tblFolders { get; set; }
        // content can be posts or 
        public System.Data.Entity.DbSet<MvcHTPC.Models.contents> tblContents { get; set; }
        // logs
        public System.Data.Entity.DbSet<MvcHTPC.Models.logs> tblLogs { get; set; }
        // notifications
        public System.Data.Entity.DbSet<MvcHTPC.Models.notifications> tblNotifications { get; set; }


    }
}
