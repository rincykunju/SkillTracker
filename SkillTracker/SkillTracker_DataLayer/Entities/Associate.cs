using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkillTracker_DataLayer.Entities
{
    public class Associate
    {
        [Key]
        public int AssociateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Image { get; set; }
        public int StatusGreen { get; set; }
        public int StatusBlue { get; set; }
        public int StatusRed { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public string Remarks { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
        
    }
}
