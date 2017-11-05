namespace MvcHTPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmodels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContentModels", newName: "contents");
            RenameTable(name: "dbo.FolderModels", newName: "folders");
            RenameTable(name: "dbo.ForumModels", newName: "forums");
            RenameTable(name: "dbo.GroupModels", newName: "groups");
            RenameTable(name: "dbo.UserModels", newName: "users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.users", newName: "UserModels");
            RenameTable(name: "dbo.groups", newName: "GroupModels");
            RenameTable(name: "dbo.forums", newName: "ForumModels");
            RenameTable(name: "dbo.folders", newName: "FolderModels");
            RenameTable(name: "dbo.contents", newName: "ContentModels");
        }
    }
}
