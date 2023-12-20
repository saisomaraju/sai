using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;
using System;
using System.IO;

namespace Demo1.Utility
{
    public class ExtentReporting
    {
        public static ExtentReports _extentReports = null;
        public static ExtentTest _feature = null;
        public static ExtentTest _scenario = null;
        public static ExtentTest step = null;
        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        static string subfolder = DateTime.Now.ToString("ddMMyyyy_HHmmss");
        //string fullPath = Path.Combine(dir.Replace("bin\\Debug\\netcoreapp2.1", dynamicFolder), subfolder);
        public static string testResultPath = dir.Replace("bin\\Debug\\netcoreapp2.1", $"TestReport\\{subfolder}");
       

    public static void ExtentReportInit() //creates extent report
        {
            if (!Directory.Exists(testResultPath))
            {
                Directory.CreateDirectory(testResultPath);
            }
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "smart3d_Report";
            htmlReporter.Config.DocumentTitle = "Final_Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Smart3d");
            _extentReports.AddSystemInfo("OS", "Android");
        }
        public static void ExtentReportTeardown()
        {
            _extentReports.Flush();
        }

        public static string addscreenshot(AppiumDriver<AndroidElement> driver) //takes screenshots on failure
        {
            ITakesScreenshot takescreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takescreenshot.GetScreenshot();
            string screenshotlocation = $"C:\\Users\\iray3\\source\\repos\\MultiMic_Plus\\MultiMic_Plus\\TestReport\\{subfolder}\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".png";

            screenshot.SaveAsFile(screenshotlocation, ScreenshotImageFormat.Png);
            return screenshotlocation;
        }
        public static void AddStep(ScenarioContext scenarioContext) //adds steps to extent report
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    step = _scenario.CreateNode<Given>(stepName);

                }
                else if (stepType == "When")
                {
                    step = _scenario.CreateNode<When>(stepName);

                }
                else if (stepType == "Then")
                {
                    step = _scenario.CreateNode<Then>(stepName);

                }
            }
        }
        public static void log(string Result, string desc, string location) //used for logging to extent report
        {

            switch (Result.ToUpper().Trim())
            {
                case "PASS":
                    step.Log(Status.Pass, desc);
                    break;
                case "FAIL":
                    step.Log(Status.Fail, desc);
                    step.AddScreenCaptureFromPath(location);
                    break;
                case "INFO":
                    step.Log(Status.Info, desc);
                    break;
                default:
                    throw new ArgumentException("Unknown Result type: " + Result + " in Log.");
            }
        }
        public static void RenameReport()
        {
            System.IO.File.Move($"C:\\Users\\iray3\\source\\repos\\MultiMic_Plus\\MultiMic_Plus\\TestReport\\{subfolder}\\index.html", $"C:\\Users\\iray3\\source\\repos\\MultiMic_Plus\\MultiMic_Plus\\TestReport\\{subfolder}\\MultiMicPlusReport.html");
        }

    }
}