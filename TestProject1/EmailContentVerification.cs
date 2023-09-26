using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using WebDriverTask;

namespace SeleniumCsharp

{

    public class EmailContent

    {
        String testUrl = "https://proton.me/";
        IWebDriver driver;


        [OneTimeSetUp]

        public void Setup()

        {
            driver = new ChromeDriver(@"D:\Studing\SELF-EDUCATION\AQA EPAM\C#\Test Automation\webdrive-task\WebriverTask\TestProject1\driver\chromedriver-win64\chromedriver-win64");

            driver.Url = "https://proton.me/";
        }


        [Test]
        public void SendLetter()

        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = testUrl;

            string randomContent = LetterContentGenerator.GeneratorRandomEmailContent(300);

            IWebElement signInElement = driver.FindElement(By.CssSelector("#gatsby-focus-wrapper > div.fixed.top-0.z-30.w-full.duration-75.ease-linear.bg-purple-25 > div > div > header > div > div.ml-auto.hidden.items-center.xl\\:shrink-0.md\\:flex.md\\:gap-4 > a.flex.flex-row.items-center.text-center.font-bold.rounded-full.group.transition-all.duration-300.no-underline.justify-center.items-center.transition-all.px-3.py-1\\.5.text-sm.text-purple-500.hover\\:\\!bg-purple-500.hover\\:\\!text-white.button-hover-shadow.focus\\:bg-purple-500.focus\\:text-white.w-fit > span > span"));

            signInElement.Click();

            IWebElement emailElement =
                driver.FindElement(By.CssSelector("#username"));
            emailElement.SendKeys("testEmailWebDriver@proton.me");
            IWebElement password = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            password.SendKeys("J3kCetx!6gvrdB:");
            IWebElement loginBtn =
                driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[1]/main/div[1]/div[2]/form/button"));
            loginBtn.Click();

            IWebElement newMail = driver.FindElement(By.CssSelector(
                "body > div.app-root > div.flex.flex-row.flex-nowrap.h100 > div > div.content.ui-prominent.flex-item-fluid-auto.flex.flex-column.flex-nowrap.reset4print > div > div.sidebar.flex.flex-nowrap.flex-column.no-print.outline-none > div.px-3.pb-2.flex-item-noshrink.no-mobile > button"));

            newMail.Click();
            IWebElement emailAddress = driver.FindElement(By.XPath("//*[@id=\"to-composer-5447\"]"));
            emailAddress.SendKeys("testEmailWebDriverproton1.me@proton.me");
            IWebElement subject = driver.FindElement(By.XPath("//*[@id=\"subject-composer-918\"]"));
            subject.SendKeys("Random");
            IWebElement emailBody = driver.FindElement(By.XPath("//*[@id=\"rooster-editor\"]/div[1]"));
            emailBody.SendKeys(randomContent);
            IWebElement sendBtn = driver.FindElement(By.CssSelector(
                "body > div.app-root > div:nth-child(5) > div > div > div > footer > div > div.button-group.button-group-solid-norm.button-group-medium > button.button.button-group-item.button-solid-norm.composer-send-button"));
            sendBtn.Click();
            IWebElement emailSend =
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div/div[1]/div[1]/div[1]/button/svg"));
            Assert.IsTrue(emailSend.Displayed);

        }



        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}