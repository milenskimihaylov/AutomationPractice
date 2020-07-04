using DemoQA.Pages.DemoQA;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Drawing;

namespace DemoQA.Tests.Interactions
{
    [TestFixture]
    public class Accordian : BaseTest
    {
        private AccordianPage _accordianPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _accordianPage = new AccordianPage(Driver);
            Driver.GoToUrl(_accordianPage.URL);
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
        [TestCase("What is Lorem Ipsum?", 2, 3)]
        [TestCase("Where does it come from?", 1, 3)]
        [TestCase("Why do we use it?", 1, 2)]
        public void SelectAccordianSections(string section, int notSelectedSectionOne, int notSelectedSectionTwo)
        {
            _accordianPage.AccordionSection(section).Click();
            Driver.WaitForElementToBecomeInvisible(By.XPath($"//div[@id = 'section{notSelectedSectionOne}Heading']/following-sibling::div//p"));
            Driver.WaitForElementToBecomeInvisible(By.XPath($"//div[@id = 'section{notSelectedSectionTwo}Heading']/following-sibling::div//p"));

            Assert.AreEqual("collapse", _accordianPage.DivContainingText(notSelectedSectionOne).GetAttribute("class"));
            Assert.AreEqual("collapse", _accordianPage.DivContainingText(notSelectedSectionTwo).GetAttribute("class"));

        }

        [Test]
        public void SelectAccordianSection_And_CheckTextParagraphs()
        {
            string firstParagraphText = _accordianPage.TextParagraph(1).Text;

            Assert.AreEqual("collapse show", _accordianPage.DivContainingText(1).GetAttribute("class"));
            Assert.IsTrue(firstParagraphText.Contains("Lorem Ipsum is simply dummy text of the printing and typesetting industry."));

            _accordianPage.AccordionSection("Where does it come from?").Click();
            string secondParagraphText = _accordianPage.TextParagraph(2).Text;

            Assert.AreEqual("collapse show", _accordianPage.DivContainingText(2).GetAttribute("class"));
            Assert.IsTrue(secondParagraphText.Contains("Contrary to popular belief, Lorem Ipsum is not simply random text."));

            Driver.ScrollToElement(_accordianPage.AccordionSection("Why do we use it?")).Click();
            string thirdParagraphText = _accordianPage.TextParagraph(3).Text;

            Assert.AreEqual("collapse show", _accordianPage.DivContainingText(3).GetAttribute("class"));
            Assert.IsTrue(thirdParagraphText.Contains("It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout."));
        }
    }
}