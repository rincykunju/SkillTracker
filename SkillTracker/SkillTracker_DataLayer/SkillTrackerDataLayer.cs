using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkillTracker_DataLayer.Entities;

namespace SkillTracker
{
    public class SkillTrackerDataLayer
    {
        public IList<SkillSet> GetAllSkills()
        {
            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {

                return contextObj.SkillSet.ToList();
            }
        }
        public int AddSkills(SkillSet skill)
        {
            int returnValue = 0;

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                contextObj.SkillSet.Add(skill);
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;

        }
        public int UpdateSkills(SkillSet skill)
        {
            int returnValue = 0;

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {

                SkillSet skillToUpdate = contextObj.SkillSet.SingleOrDefault(x => x.Skillid == skill.Skillid);
                skillToUpdate.Skillname = skill.Skillname;
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;

        }
        public int DeleteSkills(int skillId)
        {
            int returnValue = 0;

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {

                SkillSet skillToDelete = contextObj.SkillSet.SingleOrDefault(x => x.Skillid == skillId);
                contextObj.SkillSet.Remove(skillToDelete);
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;

        }
        public int AddAssociate(AssociateDetails associateDetails)
        {
            int returnValue = 0;

            Associate associate = associateDetails.Associate;
            List<AssociateSkills> associateskills = associateDetails.AssociateSkills;

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                contextObj.Associate.Add(associate);
                if (associateskills != null)
                {
                    foreach (AssociateSkills associateskill in associateskills)
                    {
                        contextObj.AssociateSkills.Add(associateskill);
                    }
                }
                returnValue = contextObj.SaveChanges();
            }
            return returnValue;

        }
        public int UpdateAssociate(AssociateDetails associateDetails)
        {
            int returnValue = 0;

            Associate associate = associateDetails.Associate;
            List<AssociateSkills> associateskills = associateDetails.AssociateSkills;


            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                Associate empDetails = contextObj.Associate.SingleOrDefault(e => e.AssociateId == associate.AssociateId);
                empDetails.Name = associate.Name;
                empDetails.Email = associate.Email;
                empDetails.MobileNo = associate.MobileNo;
                empDetails.Image = associate.Image;
                empDetails.StatusGreen = associate.StatusGreen;
                empDetails.StatusBlue = associate.StatusBlue;
                empDetails.StatusRed = associate.StatusRed;
                empDetails.Level1 = associate.Level1;
                empDetails.Level2 = associate.Level2;
                empDetails.Level3 = associate.Level3;
                empDetails.Remarks = associate.Remarks;
                empDetails.Strength = associate.Strength;
                empDetails.Weakness = associate.Weakness;
                if (associateskills != null)
                {
                    foreach (AssociateSkills associateskill in associateskills)
                    {
                        AssociateSkills empSkill = contextObj.AssociateSkills.SingleOrDefault(x => x.associateId == associateskill.associateId && x.skillid == associateskill.skillid);

                        if (empSkill != null)
                            empSkill.rating = associateskill.rating;
                        else

                            contextObj.AssociateSkills.Add(associateskill);
                    }
                }

                returnValue = contextObj.SaveChanges();

            }
            return returnValue;
        }


        public AssociateDetails GetAssociateDetails(int associateId)
        {

            AssociateDetails associateDetails = new AssociateDetails();

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {

                associateDetails.Associate = contextObj.Associate.SingleOrDefault(x => x.AssociateId == associateId);
                associateDetails.AssociateSkills = contextObj.AssociateSkills.Where(x => x.associateId == associateId).ToList();
            }
            return associateDetails;

        }
        public int DeleteAssociateDetails(int associateId)
        {
            int returnValue = 0;

            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                Associate associate = contextObj.Associate.SingleOrDefault(s => s.AssociateId == associateId);
                contextObj.Associate.Remove(associate);
                List<AssociateSkills> associateSkill = contextObj.AssociateSkills.Where(s => s.associateId == associateId).ToList();
                if (associateSkill != null)
                {
                    contextObj.AssociateSkills.RemoveRange(associateSkill);
                }

                returnValue = contextObj.SaveChanges();
            }

            return returnValue;
        }
        public List<AssociateDetails> GetAllAssociateDetails()
        {
            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                List<AssociateDetails> associateDetailsList = new List<AssociateDetails>();
                IList<Associate> associates = contextObj.Associate.ToList();
                foreach(Associate associate in associates)
                {
                    AssociateDetails associateDetails = new AssociateDetails();
                    associateDetails.Associate = contextObj.Associate.SingleOrDefault(x => x.AssociateId == associate.AssociateId);
                    associateDetails.AssociateSkills = contextObj.AssociateSkills.Where(x => x.associateId == associate.AssociateId).ToList();
                    associateDetailsList.Add(associateDetails);
                }
                return associateDetailsList;
            }

        }
        public List<Dashboard> GetDashboardStatistics()
        {
            using (SkillTrackerDBFunctions contextObj = new SkillTrackerDBFunctions())
            {
                List<AssociateSkills> associateSkill = contextObj.AssociateSkills.ToList();
                List<SkillSet> skillmaster = contextObj.SkillSet.ToList();
                List<Dashboard> dashboard = (from ask in associateSkill
                                                       join sm in skillmaster
                                                       on ask.skillid equals sm.Skillid
                                                       group sm by sm.Skillname into db
                                                       select new Dashboard
                                                       {
                                                           skillname = db.Key,
                                                           skillcount = db.Count()
                                                       }).ToList();

                return dashboard;

            }

        }
    }

    }