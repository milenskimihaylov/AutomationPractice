using DemoQA.Core;
using DemoQA.Pages;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public partial class AutomationPracticeFormPage : BasePage
    {
        public WebElement FirstNameField => Driver.FindClickableElement(By.Id("customer_firstname"));

        public WebElement LastNameField => Driver.FindClickableElement(By.Id("customer_lastname"));

        public WebElement EmailField => Driver.FindClickableElement(By.Id("email"));

        public WebElement PasswordField => Driver.FindClickableElement(By.Id("passwd"));

        public WebElement AddressField => Driver.FindClickableElement(By.Id("address1"));

        public WebElement CityField => Driver.FindClickableElement(By.Id("city"));

        public WebElement StateField => Driver.FindExistingElement(By.Id("id_state"));

        public WebElement PostalCode => Driver.FindClickableElement(By.Id("postcode"));

        public WebElement MobilePhone => Driver.FindClickableElement(By.Id("phone_mobile"));

        public WebElement SubmitAccountButton => Driver.FindElement(By.Id("submitAccount"));

    }
}
