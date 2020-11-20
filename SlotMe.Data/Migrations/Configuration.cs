namespace SlotMe.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SlotMe.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SlotMe.Data.ApplicationDbContext";
        }

        protected override void Seed(SlotMe.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // ** we'll want to make a User first so that that user can be used in the following seed items

            /*
            var talentEntity = new Talent()
            {
                TalentTitle = "guitar",
                TalentDescription = "I will play you some sweet classical string plucking goodness"
            };
            context.Talents.Add(talentEntity);
            */
        }
    }
}
