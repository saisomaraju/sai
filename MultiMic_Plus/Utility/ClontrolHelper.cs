using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Demo1.Utility
{
    public class ControlHelper : ExtentReporting
    {
        public static AppiumDriver<AndroidElement> _driver { get; set; }

        static AppiumLocalService service = null;
        public static void PressElement(By Locator)
        {
            try
            {
                //TouchAction touch = new(_driver);
                //IWebElement Element = _driver.FindElement(Locator);
                //touch.Press(Element).Release().Perform();
                _driver.FindElement(Locator).Click();
            }
            catch (Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                ExtentReporting.log("FAIL", "The button cannot  be clicked as " + e.Message, screenshot_loc);
                throw;
            }

        }
        public static List<Dictionary<string, object>> ReadJson()
        {
            string jsonFilePath = @"C:\\Users\\iray3\\source\\repos\\MultiMic_Plus\\Capabilites.json";

            try
            {
                // Read the entire JSON file as a string
                string jsonString = File.ReadAllText(jsonFilePath);
                // Deserialize the JSON data into a list of dictionaries
                List<Dictionary<string, object>> data = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);
                return data;

            }
            catch (Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                ExtentReporting.log("Fail", e.Message, screenshot_loc);
                return null;
            }

        }
        public static void InitilizeAppium()
        {
            service = new AppiumServiceBuilder()
            .WithAppiumJS(new FileInfo(@"C:\Users\iray3\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"))
            .UsingPort(4723)
            .Build();
            service.Start();
            var Capabilities = ReadJson();
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("platformName", Capabilities[0]["platformName"].ToString());
            appiumOptions.AddAdditionalCapability("automationName", Capabilities[0]["automationName"].ToString());
            appiumOptions.AddAdditionalCapability("deviceName", Capabilities[0]["deviceName"].ToString());
            appiumOptions.AddAdditionalCapability("udid", Capabilities[0]["udid"].ToString());
            appiumOptions.AddAdditionalCapability("platformVersion", Capabilities[0]["platformVersion"].ToString());
            appiumOptions.AddAdditionalCapability(CapabilityType.Timeouts, TimeSpan.FromSeconds(20));
            appiumOptions.AddAdditionalCapability("app", "C:\\Users\\iray3\\XamarinApps\\Xamarin-SDK-Sample-App-Android-5.15.833.apk");
            appiumOptions.AddAdditionalCapability("appPackage", "Xamarin-SDK-Sample-App-Android-5.15.833.apk");
            // appiumOptions.AddAdditionalCapability("appWaitActivity", "crc646f76f13f64c213ab.WelcomeScreenActivity");
            var httpClient = new HttpClient();
            {
                httpClient.Timeout = TimeSpan.FromSeconds(120);
            }
            var commandExecutor = new HttpCommandExecutor(new Uri("http://localhost:4723/wd/hub"), TimeSpan.FromSeconds(120));
            _driver = new AndroidDriver<AndroidElement>(commandExecutor, appiumOptions);
        }
        public static void TerminateAppium()
        {
            service.Dispose();
        }
        public static void ValidateProgramCard(string mode, By CardTitle)
        {

            string mode_title = string.Empty;
            try
            {
                mode_title = _driver.FindElement(CardTitle).Text;
                Assert.AreEqual(mode, mode_title);
            }
            catch (Exception e)
            {
                if (e is AssertionException)
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", $"The Mode is {mode_title} but expected to be {mode} " + e.Message, screenshot_loc);
                }
                else
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", e.Message, screenshot_loc);
                    throw;
                }
            }
        }
        public static void CheckEnabled(By locator)
        {
            try
            {
                bool status = _driver.FindElement(locator).Enabled;
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                if (e is AssertionException)
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", $"The quick button is expected to be selected but it is not selected as " + e.Message, screenshot_loc);
                }
                else
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", e.Message, screenshot_loc);
                    throw;
                }
            }
        }
        public static void CheckSelected(By locator)
        {
            try
            {
                bool status = _driver.FindElement(locator).Selected;
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                if (e is AssertionException)
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", $"The quick button is expected to be selected but it is not selected as " + e.Message, screenshot_loc);
                }
                else
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", e.Message, screenshot_loc);
                    throw;
                }
            }
        }

        public static void CheckHtmlViewDisplayed(By locator)
        {
            try
            {
                bool status = _driver.FindElement(locator).Displayed;
                Assert.IsTrue(status);
            }
            catch (Exception ex)
            {
                if (ex is AssertionException)
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", $"The quick button is expected to be selected but it is not selected as " + ex.Message, screenshot_loc);
                }
                else
                {
                    string screenshot_loc = ExtentReporting.addscreenshot(_driver);
                    ExtentReporting.log("FAIL", ex.Message, screenshot_loc);
                    throw;
                }
            }
        }

    }

}