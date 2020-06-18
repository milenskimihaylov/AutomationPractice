using DemoQA.Pages;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public partial class AutomationPracticeFormPage : BasePage
    {
        public IWebElement FirstNameField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("customer_firstname")));

        public IWebElement LastNameField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("customer_lastname")));

        public IWebElement EmailField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("email")));

        public IWebElement PasswordField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("passwd")));

        public IWebElement AddressField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("address1")));

        public IWebElement CityField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("city")));

        public IWebElement StateField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("id_state")));

        public IWebElement PostalCode => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("postcode")));

        public IWebElement MobilePhone => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("phone_mobile")));

        public IWebElement SubmitAccountButton => Wait.Until(d => d.FindElement(By.Id("submitAccount")));

    }
}
