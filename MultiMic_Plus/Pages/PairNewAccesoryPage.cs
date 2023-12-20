using Demo1.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Pages
{
    public class PairNewAccessoryPage : ControlHelper
    {
        static By Multimic = By.XPath("//android.widget.TextView[@text = 'Multi-Mic+']");
        static By search = By.XPath("//android.widget.TextView[@text = 'Search']");
        static By ok = By.XPath("//android.widget.TextView[@text = 'OK']");
        public static void Press_MultiMicPlus()
        {
            PressElement(Multimic);
        }
        public static void ValidateMultiMicPlusDisplayed(string expected)
        {
            ValidateProgramCard(expected, Multimic);
        }
        public static void PressSearch()
        {
            PressElement(search);
        }
        public static void PressOk()
        {
            PressElement(ok);
        }
    }
}
