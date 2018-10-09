using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker_DataLayer.Entities
{
    public class SkillTrackerDBFunctions : DbContext
    {
        static SkillTrackerDBFunctions()
        {
            Database.SetInitializer<SkillTrackerDBFunctions>(new CreateDatabaseIfNotExists<SkillTrackerDBFunctions>());
        }
        public SkillTrackerDBFunctions() : base("name=skilltrackerconnection") { }
       
        public DbSet<SkillSet> SkillSet { get; set; }
        public DbSet<Associate> Associate { get; set; }
        public DbSet<AssociateSkills> AssociateSkills { get; set; }
    }
}
