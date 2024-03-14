using MarsAdvanceTaskPart2.Pages.Components.ProfileOverview;
using MarsAdvanceTaskPart2.Pages.Components;
using MarsAdvanceTaskPart2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskPart2.Pages.Components.NavigationMenu;

namespace MarsAdvanceTaskPart2.Steps
{
    public class HomePageSteps : GlobalHelper
    {
        private HomePage homePage;
        private ProfileMenuTabComponents profileMenuTabComponents;
        private NavigationMenuTabComponents navigationMenuTabComponents;

        public HomePageSteps()
        {
            homePage = new HomePage();
            profileMenuTabComponents = new ProfileMenuTabComponents();
            navigationMenuTabComponents = new NavigationMenuTabComponents();
        }

        public void ClickOnDescriptionIcon()
        {
            profileMenuTabComponents.ClickDescriptionIcon();
        }
        public void ClickOnProfileIcon()
        {

            profileMenuTabComponents.ClickUserNameIcon();
        }

        public void ClickOnAvailabilityEditIcon()
        {
            profileMenuTabComponents.ClickAvailabilityEditIcon();
        }

        public void ClickOnHoursEditIcon()
        {
            profileMenuTabComponents.ClickHoursEditIcon();
        }

        public void ClickOnEarnTargetEditIcon()
        {
            profileMenuTabComponents.ClickEarnTargetEditIcon();
        }

        public void ClickOnShareSkill()
        {
            navigationMenuTabComponents.ClickShareSkillTab();
        }

        public void ClickOnManageListingTab()
        {
            navigationMenuTabComponents.ClickManageListingTab();
        }

        public void ClickOnEducationTab()
        {
            profileMenuTabComponents.ClickEducationTab();
        }
        public void ValidateIsLoggedIn()
        {
            homePage.getFirstName();

        }

    }
}
