using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTracker_DataLayer.Entities
{
    public class AssociateSkills
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Associate")]
        public int associateId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("SkillSet")]
        public int skillid { get; set; }

        public int rating { get; set; }

        public Associate Associate { get; set; }
        public SkillSet SkillSet { get; set; }


    }
}
