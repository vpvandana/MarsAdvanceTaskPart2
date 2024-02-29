using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using MarsAdvanceTaskPart2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsAdvanceTaskPart2.Hooks
{
    [Binding]
    public sealed class HooksHelper
    {
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        private static ExtentSparkReporter htmlReporter;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentSparkReporter("C:\\internship notes\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\MarsAdvanceTaskPart2\\Hooks\\Report.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
            }
            else
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.Message);
            }
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }


    }

}


