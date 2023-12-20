using Demo1.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Pages
{
    public class WelcomePage : ControlHelper
    {
        static By Take_me_to_demo_mode = By.XPath("//android.widget.Button[@text = 'No, take me to demo mode']");
        public static void press_take_me_to_demo_mode()
        {
            PressElement(Take_me_to_demo_mode);
        }
    }
}
