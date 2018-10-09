using SkillTracker_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SkillTracker.Controllers
{
   //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SkillsController :  ApiController
    {
        SkillTrackerDBFunctions dbFunctions = new SkillTrackerDBFunctions();
        SkillTrackerDataLayer dataLayer = new SkillTrackerDataLayer();
        // GET: Skills
        [HttpGet]
        [Route("api/skills/GetAllSkills")]
        public IList<SkillSet> GetAllSkills()
        {
            return dataLayer.GetAllSkills();        }
        //add new skills to master table
        [HttpPost]
        [Route("api/skills/AddSkills")]
        public IHttpActionResult AddSkills(SkillSet skill)
        {
            int rowAffected = dataLayer.AddSkills(skill);

            if (rowAffected > 0)
                return Ok("Add Success");
            else
                return NotFound();
        }

        //update  skills in master table
        [HttpPut]
        [Route("api/skills/UpdateSkills")]
        public IHttpActionResult UpdateSkills(SkillSet skill)
        {
            int rowAffected = dataLayer.UpdateSkills(skill);

            if (rowAffected > 0)
                return Ok("Update Success");
            else
                return NotFound();
        }

        //delete  skills from master table
        [HttpDelete]
        [Route("api/skills/DeleteSkills")]
        public IHttpActionResult DeleteSkills(int skillId)
        {
            int rowAffected = dataLayer.DeleteSkills(skillId);

            if (rowAffected > 0)
                return Ok("Update Success");
            else
                return NotFound();
        }
    }
   
}