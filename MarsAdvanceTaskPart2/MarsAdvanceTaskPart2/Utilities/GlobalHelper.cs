using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using System.Drawing.Imaging;


namespace MarsAdvanceTaskPart2.Utilities
{

    public class GlobalHelper
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest testreport;
        [SetUp]
        public void SetupAction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
        }
        public void LogScreenshot(string ScreenshotName)
        {
            string screenshotPath = CaptureScreenshot(ScreenshotName);
            if (testreport != null)
            {
                testreport.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }

        public static string CaptureScreenshot(string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine(@"C:\internship notes\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\MarsAdvanceTaskPart2\ScreenshotReport\", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;

        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }
    }
}
