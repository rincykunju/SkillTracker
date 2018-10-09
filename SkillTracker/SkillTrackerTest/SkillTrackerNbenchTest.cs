using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using SkillTrackerTest;

namespace SkillTrackerTest
{
    public class SkillTrackerNbenchTest
    {
        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Iterations,
           TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void BenchMarkPerformanceSkill()
        {
            SkillsControllerTest skillTest = new SkillsControllerTest();
            skillTest.AddSkillTest();
            skillTest.GetAllSkillsTest();
            skillTest.UpdateSkillTest();
            skillTest.DeleteSkillTest();
        }
    }
}
