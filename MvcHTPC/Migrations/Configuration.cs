namespace MvcHTPC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<MvcHTPC.Models.MvcHTPCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcHTPC.Models.MvcHTPCContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.tblForums.AddOrUpdate(x => x.id,
                new Models.forums()
                {
                    id = 1,
                    groupIds = null,
                    title = "",
                    description = "",
                    hidden = Models.DbModels.DbStaticEnums.HiddenState.HIDDEN,
                    locked = true,
                    dateOfCreation = DateTime.Today

                }
            );

            context.tblUsers.AddOrUpdate(x => x.id,
                new Models.users()
                {
                    id = 1,
                    groupIds = null,
                    accessLevel = Models.DbModels.DbStaticEnums.AccessLevel.DEACTIVATED,
                    username = "root",
                    password = "",
                    email = "",
                    dateOfCreation = DateTime.Today
                }
            );

            context.tblGroups.AddOrUpdate(x => x.id,
                new Models.groups()
                {
                    id = 1,
                    ownersId = 1,
                    name = "",
                    description = "",
                    dateOfCreation = DateTime.Today
                }
            );

            context.tblFolders.AddOrUpdate(x => x.id,
                new Models.folders()
                {
                    id = 1,
                    forumId = 1,
                    ownersId = 1,
                    groupIds = null,
                    location = "",
                    title = "",
                    description = "",
                    hidden = Models.DbModels.DbStaticEnums.HiddenState.HIDDEN,
                    locked = true,
                    dateOfCreation = DateTime.Today,
                    lastModified = null
                    
                }
            );

            context.tblContents.AddOrUpdate(x => x.id,
                new Models.contents()
                {
                    id = 1,
                    folderId = 1,
                    ownerId = 1,
                    title = "",
                    bodyText = "",
                    dateOfCreation = DateTime.Today,
                    lastModification = null
                }
            );
            
        }
    }
}
