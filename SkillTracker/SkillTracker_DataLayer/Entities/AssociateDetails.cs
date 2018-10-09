using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker_DataLayer.Entities
{
    public class AssociateDetails
    {
        public Associate Associate { get; set; }

        public List<AssociateSkills> AssociateSkills { get; set; }
    }
}
