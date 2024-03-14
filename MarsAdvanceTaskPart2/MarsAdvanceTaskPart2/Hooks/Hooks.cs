using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MarsAdvanceTaskPart2.Utilities;

namespace MarsAdvanceTaskPart2.Hooks
{
    [Binding]
    public sealed class Hooks : GlobalHelper
    {
#pragma warning disable
        private static ExtentReports extent;
        private static ExtentTest testreport;
        private static ExtentSparkReporter htmlReporter;

        [BeforeScenario]

        public void BeforeScenarioWithTag()
        {
            SetupAction();

        }
        [AfterScenario]
        public void AfterSCenario()
        {
            TearDownAction();
        }


    }

}
