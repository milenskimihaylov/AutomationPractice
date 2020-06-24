using AutomationPractice.Factories;
using AutomationPractice.Models;
using AutomationPractice.Pages;
using DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using POM_Exercises;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class AutomationPracticeFormTests : BaseTest
    {
        private AutomationPracticeLoginPage _automationPracticeLoginPage;
        private AutomationPracticeFormPage _automationPracticeFormPage;
        private AutomationPracticeFormModel _user;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _automationPracticeLoginPage = new AutomationPracticeLoginPage(Driver);
            _automationPracticeFormPage = new AutomationPracticeFormPage(Driver);
            _user = AutomationPracticeFormFactory.CreateUser();
            _automationPracticeLoginPage.GoToCreateAnAccountForm(_user.Email);
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenshot(@"..\..\..\");
            }

            Driver.Quit();
        }

        [Test]
        public void RegistrationEmailCheck()
        {              
            Driver.ScrollToPixels(200);

            _automationPracticeFormPage.LastNameField.Click();
            _automationPracticeFormPage.EmailField.Click();                       
            
            _automationPracticeFormPage.AssertCorrectEmail(_automationPracticeFormPage.EmailField, _user.Email);           
        }

        [Test]
        public void TryToRegister_without_FirstNameFilled()
        {
            _user.FirstName = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>firstname</b> is required.");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>firstname</b> is required.");

        }
        [Test]
        public void TryToRegister_without_LastNameFilled()
        {
            _user.LastName = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>lastname</b> is required.");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>lastname</b> is required.");
        }
        [Test]
        public void TryToRegister_without_PasswordFilled()
        {
            _user.Password = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>passwd</b> is required.");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>passwd</b> is required.");
        }
        [Test]
        public void TryToRegister_without_AddressFilled()
        {
            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>address1</b> is required.");

            _automationPracticeFormPage.FillForm("Pesho", "Gosho", "wsafaf124sdf","", "", "Montana", "12345", "123142543531");
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>address1</b> is required.");
        }
        [Test]
        public void TryToRegister_without_CityFilled()
        {
            _user.City = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>city</b> is required.");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>city</b> is required.");
        }
        [Test]
        public void TryToRegister_without_PhoneNumberFilled()
        {
            _user.MobilePhone = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<li>You must register at least one phone number.</li>");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<li>You must register at least one phone number.</li>");
        }
        [Test]
        public void TryToRegister_without_PostalCodeFilled()
        {
            _user.PostalCode = string.Empty;

            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<li>The Zip/Postal code you&#039;ve entered is invalid. It must follow this format: 00000</li>");

            _automationPracticeFormPage.FillFormWithoutEmail(_user);
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<li>The Zip/Postal code you&#039;ve entered is invalid. It must follow this format: 00000</li>");
        }
        [Test]
        public void TryToRegister_without_EmailFilled()
        {
            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<b>email</b> is required.");

            _automationPracticeFormPage.FillForm("Pesho", "Gosho", "wsafaf124sdf", "none", "OK, Montana", "Montana", "12345", "123142543531");
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<b>email</b> is required.");
        }
        [Test]
        public void TryToRegister_with_EmailThatIsAlreadyUsed()
        {
            _automationPracticeFormPage.AssertPageSourceDoesNotContain(Driver.PageSource, "<li>An account using this email address has already been registered.</li>");

            _automationPracticeFormPage.FillForm("Pesho", "Gosho", "wsafaf124sdf", "pesho1@gmail.com", "OK, Montana", "Montana", "12345", "123142543531");
            SelectElementFromList(_automationPracticeFormPage.StateField, _user.State);
            Driver.ScrollToElement(_automationPracticeFormPage.SubmitAccountButton).Click();

            _automationPracticeFormPage.AssertPageSourceContains(Driver.PageSource, "<li>An account using this email address has already been registered.</li>");
        }
    }
    
}
