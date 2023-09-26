using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SeleniumCsharp

{

    public class Tests

    {
        String testUrl = "https://proton.me/";
        IWebDriver driver;


        [OneTimeSetUp]

        public void Setup()

        {
            driver = new ChromeDriver(@"D:\Studing\SELF-EDUCATION\AQA EPAM\C#\Test Automation\webdrive-task\WebriverTask\TestProject1\driver\chromedriver-win64\chromedriver-win64");
            
            driver.Url = "https://proton.me/";
        }

        //[Test]

        //public void verifyEmailWithValidCredentials()

        //{

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        //    driver.Url = testUrl;
        //    IWebElement signInElement = driver.FindElement(By.XPath("//*[@id=\"__next\"]/main/div[1]/div/div/a[4]/span"));

        //    signInElement.Click();

        //    IWebElement emailElement =
        //        driver.FindElement(By.CssSelector("#root > div > div > div > div:nth-child(2) > form > div > div.sc-hBUSln.PBLfe > div > input"));
        //    emailElement.SendKeys("testEmailWebDriver@skiff.com");
        //    IWebElement password = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div[2]/form/div/div[2]/div/div/input"));
        //    password.SendKeys("1111Qwer");
        //    IWebElement loginBtn =
        //        driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div[2]/form/span/div"));
        //    loginBtn.Click();

        //    String loggedUrl = "https://app.skiff.com/mail/inbox";
        //    string currentUrl = driver.Url;

        //    Assert.AreEqual(loggedUrl, currentUrl);

        //}

        [Test]
        public void VerifyEmailWIthValidCredentials()

        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Url = testUrl;
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

            IWebElement logo = driver.FindElement(By.CssSelector(
                "body > div.app-root > div.flex.flex-row.flex-nowrap.h100 > div > div.content.ui-prominent.flex-item-fluid-auto.flex.flex-column.flex-nowrap.reset4print > div > div.sidebar.flex.flex-nowrap.flex-column.no-print.outline-none > div.logo-container.flex.flex-justify-space-between.flex-align-items-center.flex-nowrap.no-mobile > a > svg"));

            Assert.IsTrue(logo.Displayed);

        }

        [Test]
        public void VerifyEmailWIthInvalidCredentials()

        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

            IWebElement signInElement = driver.FindElement(By.CssSelector("#gatsby-focus-wrapper > div.fixed.top-0.z-30.w-full.duration-75.ease-linear.bg-purple-25 > div > div > header > div > div.ml-auto.hidden.items-center.xl\\:shrink-0.md\\:flex.md\\:gap-4 > a.flex.flex-row.items-center.text-center.font-bold.rounded-full.group.transition-all.duration-300.no-underline.justify-center.items-center.transition-all.px-3.py-1\\.5.text-sm.text-purple-500.hover\\:\\!bg-purple-500.hover\\:\\!text-white.button-hover-shadow.focus\\:bg-purple-500.focus\\:text-white.w-fit > span > span"));

            signInElement.Click();

            IWebElement emailElement =
                driver.FindElement(By.CssSelector("#username"));
            emailElement.SendKeys("");
            IWebElement password = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            password.SendKeys("");
            IWebElement loginBtn =
                driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[1]/main/div[1]/div[2]/form/button"));
            loginBtn.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"id-3\"]/span"));


            Assert.IsTrue(errorMessage.Displayed);

        }





        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}