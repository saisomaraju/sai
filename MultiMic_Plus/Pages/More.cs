using Demo1.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Pages
{
    public class More : ControlHelper
    {
        static By pair_new_accesories = By.XPath("//android.widget.TextView[@text = 'Pair new wireless accessory']");
        public static void Press_pair_new_accessory()
        {
            PressElement(pair_new_accesories);
        }
    }
}
