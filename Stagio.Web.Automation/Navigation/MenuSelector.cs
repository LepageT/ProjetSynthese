using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Stagio.Web.Automation
{
    public class MenuSelector
    {
        public static void SelectTopLevel(string topLevelMenuId)
        {
            var menuElement = Driver.Instance.FindElement(By.Id(topLevelMenuId));
            menuElement.Click();
        }
        public static void Select(string topLevelMenuId, string subLevelMenuId)
        {
            SelectTopLevel(topLevelMenuId);

            var editRestaurantMenuItem = Driver.Instance.FindElement(By.Id(subLevelMenuId));
            editRestaurantMenuItem.Click();
        }
    }
}