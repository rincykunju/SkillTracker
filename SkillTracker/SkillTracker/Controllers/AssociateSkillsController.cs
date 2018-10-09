using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkillTracker_DataLayer.Entities;
using System.Web.Http.Cors;

namespace SkillTracker.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssociateSkillsController : ApiController
    {
        SkillTrackerDBFunctions dbFunctions = new SkillTrackerDBFunctions();
        SkillTrackerDataLayer dataLayer = new SkillTrackerDataLayer();

        //Add associate details
        [HttpPost]
        [Route("api/skills/AddAssociate")]
        public IHttpActionResult AddAssociate(AssociateDetails associateDetails)
        {
            
            int rowAffected = dataLayer.AddAssociate(associateDetails);
            
            if (rowAffected > 0)
                return Ok("Add Success");
            else
                return NotFound();
        }

        //Add associate details
        [HttpGet]
        [Route("api/skills/GetAssociateDetails")]
        public AssociateDetails GetAssociateDetails(int associateId)
        {
            return (dataLayer.GetAssociateDetails(associateId));
        }
        //Add associate details
        [HttpPut]
        [Route("api/skills/UpdateAssociate")]
        public IHttpActionResult UpdateAssociate([FromBody]AssociateDetails associateDetails)
        {

            int rowAffected = dataLayer.UpdateAssociate(associateDetails);

            if (rowAffected > 0)
                return Ok("Add Success");
            else
                return NotFound();
        }
        [HttpGet]
        [Route("api/skills/GetAllAssociates")]
        public List<AssociateDetails> GetAllAssociates()
        {

            return dataLayer.GetAllAssociateDetails();
        }
        [HttpDelete]
        [Route("api/skills/DeleteAssociateDetails")]
        public IHttpActionResult DeleteAssociateDetails(int associateId)
        {
            int rowAffected = dataLayer.DeleteAssociateDetails(associateId);

            if (rowAffected > 0)
                return Ok("Success");
            else
                return NotFound();
        }
        [HttpGet]
        [Route("api/skills/GetDashboardStatistics")]
        public List<Dashboard> GetDashboardStatistics()
        {
            return dataLayer.GetDashboardStatistics();
        }
    }
}