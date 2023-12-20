using Demo1.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Pages
{
    public class AllAroundPage : ControlHelper
    {
        static By Pricepointok = By.XPath("//android.widget.TextView[@text = 'OK']");
        static By Nothanks = By.XPath("//android.widget.TextView[@text = 'No thanks']");
        static By more = By.XPath("//android.widget.TextView[@text = 'More']");
        public static void press_pricepoint_ok()
        {
            PressElement(Pricepointok);
        }
        public static void press_nothanks()
        {
            PressElement(Nothanks);
        }
        public static void press_more()
        {
            PressElement(more);
        }
    }
}
