using Demo1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Demo1.StepDefinitions
{
    [Binding]
    public class Defnitions
    {
        [Given(@"I am on welcome page and i press take me to demo mode")]
        public void GivenIAmOnWelcomePageAndIPressTakeMeToDemoMode()
        {
            WelcomePage.press_take_me_to_demo_mode();
        }

        [When(@"I press ok on Demo mode popup")]
        public void WhenIPressOkOnDemoModePopup()
        {
            AllAroundPage.press_pricepoint_ok();
        }

        [When(@"I press no thanks on welcome popup")]
        public void WhenIPressNoThanksOnWelcomePopup()
        {
            AllAroundPage.press_nothanks();
        }

        [When(@"I press on More tab on bottom ribbon bar")]
        public void WhenIPressOnMoreTabOnBottomRibbonBar()
        {
            AllAroundPage.press_more();
        }

        [When(@"I press Pair new wireless accessory")]
        public void WhenIPressPairNewWirelessAccessory()
        {
            More.Press_pair_new_accessory();
        }

        [When(@"I select Multi_Mic\+")]
        public void WhenISelectMulti_Mic()
        {
            PairNewAccessoryPage.Press_MultiMicPlus();
        }

        [Then(@"I valiadte ""([^""]*)"" displayed on top of the page")]
        public void ThenIValiadteDisplayedOnTopOfThePage(string p0)
        {
            PairNewAccessoryPage.ValidateMultiMicPlusDisplayed(p0);
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            PairNewAccessoryPage.PressSearch();
        }

        [When(@"I press ok")]
        public void WhenIPressOk()
        {
            PairNewAccessoryPage.PressOk();
        }

    }
}
