using System;
using NUnit.Framework;
using SkillTracker_DataLayer.Entities;

using System.Web.Http;
using System.Web.Http.Results;
using SkillTracker.Controllers;
using System.Collections.Generic;

namespace SkillTrackerTest
{
     [TestFixture]
    public class SkillsControllerTest
    {
        [Test, Order(1)]
        public void AddSkillTest()
        {
             SkillSet skill = new SkillSet { Skillname = "UnitTest Skill" };
            SkillsController skillcontroller = new SkillsController();
            IHttpActionResult response = skillcontroller.AddSkills(skill);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }
        [Test, Order(2)]
        public void GetAllSkillsTest()
        {
            SkillsController skillcontroller = new SkillsController();
            IList<SkillSet> skills = skillcontroller.GetAllSkills();
            Assert.IsNotNull(skills);
        }

        [Test, Order(3)]
        public void UpdateSkillTest()
        {
            SkillsController skillcontroller = new SkillsController();
            SkillSet skill = GetLastSkill();
            skill.Skillname = "Test Skill Updated";
            IHttpActionResult response = skillcontroller.UpdateSkills(skill);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        [Test, Order(4)]
        public void DeleteSkillTest()
        {
            SkillsController skillcontroller = new SkillsController();
            SkillSet skill = GetLastSkill();
            IHttpActionResult response = skillcontroller.DeleteSkills(skill.Skillid);
            var contentResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.ToString(), "Success");
        }

        public SkillSet GetLastSkill()
        {
            SkillsController skillController = new SkillsController();
            IList<SkillSet> skills = skillController.GetAllSkills();
            return skills != null ? skills[skills.Count - 1] : null;
        }
    }
}
