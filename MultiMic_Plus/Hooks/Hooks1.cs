using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using Demo1.Utility;
using System;

namespace Smart3dTest.Hooks
{
    [Binding]
    public sealed class Smart3dHook : ControlHelper
    {
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {


            ExtentReportInit();

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            InitilizeAppium();
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {

            ControlHelper._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            AddStep(scenarioContext);
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            TerminateAppium();
            ExtentReportTeardown();
            RenameReport();
        }
    }
}