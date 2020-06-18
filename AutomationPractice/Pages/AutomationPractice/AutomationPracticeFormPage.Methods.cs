using AutomationPractice.Models;
using DemoQA.Pages;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public partial class AutomationPracticeFormPage : BasePage
    {
        public AutomationPracticeFormPage(IWebDriver driver)
            :base(driver)
        {
        }
        
        public void FillFormWithEmail(AutomationPracticeFormModel user)
        {
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            EmailField.SendKeys(user.Email);
            PasswordField.SendKeys(user.Password);
            AddressField.SendKeys(user.Address);
            CityField.SendKeys(user.City);
            PostalCode.SendKeys(user.PostalCode);
            MobilePhone.SendKeys(user.MobilePhone);
        }
        public void FillFormWithoutEmail(AutomationPracticeFormModel user)
        {
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);            
            PasswordField.SendKeys(user.Password);
            AddressField.SendKeys(user.Address);
            CityField.SendKeys(user.City);
            PostalCode.SendKeys(user.PostalCode);
            MobilePhone.SendKeys(user.MobilePhone);
        }
        public void FillForm(string firstName, string lastName, string pass, string email, string address, string city, string postcode, string phone)
        {
            if (firstName != "")
            {
                Driver.ScrollToElement(FirstNameField);
                FirstNameField.SendKeys(firstName);
            }
            if (lastName != "")
            {
                Driver.ScrollToElement(LastNameField);
                LastNameField.SendKeys(lastName);
            }
            if (pass != "")
            {
                Driver.ScrollToElement(PasswordField);
                PasswordField.SendKeys(pass);
            }
            if (email != "")
            {
                if (email == "none")
                {
                    Driver.ScrollToElement(EmailField);
                    EmailField.Clear();
                } else
                {
                    Driver.ScrollToElement(EmailField);
                    EmailField.Clear();
                    EmailField.SendKeys(email);
                } 
            }
            if (address != "")
            {
                Driver.ScrollToElement(AddressField);
                AddressField.SendKeys(address);
            }
            if (city != "")
            {
                Driver.ScrollToElement(CityField);
                CityField.SendKeys(city);
            }
            if (postcode != "")
            {
                Driver.ScrollToElement(PostalCode);
                PostalCode.SendKeys(postcode);
            }
            if (phone != "")
            {               
                MobilePhone.SendKeys(phone);
            }
        }

    }
}
