using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gauge.Automation.Testing.Logic
{
    public class Contact
    {
        public void Add(IWebDriver driver)
        {
            //Arrange
            Random rnd = new Random();
            string TesterNo = rnd.Next(1000).ToString();
            string PhoneNo = rnd.Next(100000).ToString();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > a")));
            }
            catch
            {
                // Wait for the page to load
            }

            //Action 
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("body > nav > div > ul > li.contacts > a")).Click(); // Click on Contact Tab
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(5) > img")).Click(); // Click on Add New Contact button

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#contactFirstName"))); //Wait for element visible
            driver.FindElement(By.CssSelector("#contactFirstName")).Click();
            driver.FindElement(By.CssSelector("#contactFirstName")).SendKeys("Tester " + TesterNo);
            driver.FindElement(By.CssSelector("#contactLastName")).Click();
            driver.FindElement(By.CssSelector("#contactLastName")).SendKeys("Automation Testing");
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(7) > div:nth-child(1) > div > div.divider > div > div.number > input")).Click();
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(7) > div:nth-child(1) > div > div.divider > div > div.number > input")).SendKeys(PhoneNo);
            //Click on Follow Up
            IWebElement fUp = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(11) > aside > div.section-header > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fUp);
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(11) > aside > div.section-header > span > span > span > i")).Click(); //Click on Follow Up
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#contact-profile-followup-calendar")).Click(); //Click on Today
            IWebElement fTIme = driver.FindElement(By.CssSelector("#followUpFields > div.capitalize > strong > small")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fTIme);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#followUpFields > div.time"));
            IList<IWebElement> select = driver.FindElements(By.CssSelector("#followUpFields > div.time > div > select")); // Selects
            select[0].Click(); //Click on Time 
            Thread.Sleep(2000);
            IList<IWebElement> hours = select[0].FindElements(By.TagName("Option"));
            hours[10].Click(); //click on 11
            driver.FindElement(By.CssSelector("#followUpFields > div.time > div > div")).Click(); //Click on AM
            IWebElement notes = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(12) > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", notes);
            driver.FindElement(By.CssSelector("#followUpFields > div.capitalize > select")).Click();
            System.Threading.Thread.Sleep(2000);
            IList<IWebElement> priority = driver.FindElements(By.CssSelector("#followUpFields > div.capitalize > select > option"));
            priority[2].Click(); // Click on Medium
            driver.FindElement(By.CssSelector("#contactNote")).SendKeys("Automation Testing"); //Enter Notes
            IWebElement custStatus = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(13) > aside > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", custStatus);
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(13) > aside > span > span > span > i")).Click(); //Click on Customer Status
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#statusChoices > div > div:nth-child(10) > label")).Click(); //Click on Prefered Custoemr
            IWebElement interested = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(16) > aside > div.section-header > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", interested);
            driver.FindElement(By.CssSelector("#contactInviteMethod")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#contactInviteMethod > option:nth-child(3)")).Click(); //Click on Other
            IWebElement otherInterest = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(17) > aside > div.section-header > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", otherInterest);
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(16) > aside > div.section-header > span > span > span > i")).Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement lWeight = driver.FindElement(By.CssSelector("#interestedInOptions > label:nth-child(2)")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", lWeight);
            driver.FindElement(By.CssSelector("#interestedInOptions > label:nth-child(2)")).Click(); //Click on Lose Weight
            IWebElement OInterest = driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(17) > aside > div.section-header > label")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", OInterest);
            driver.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(17) > aside > div.section-header > span > span > span > i")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#InterestedIn")).SendKeys("Automation"); //Enter Other Interest
            driver.FindElement(By.CssSelector("#InterestedIn")).SendKeys(Keys.Space); //Enter Other Interest
            Thread.Sleep(2000);
            IWebElement doneButton = driver.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary")); //Scrool to the element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
            driver.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary")).Click(); //Click on Done
            Thread.Sleep(5000);

            //Check if hit goals dialog pop-up
            try
            {
                IWebElement okButton = driver.FindElement(By.ClassName("button-set"));
                okButton.FindElement(By.TagName("input")).Click();
                Thread.Sleep(2000);
                //Click on contact tab
                driver.FindElement(By.CssSelector("body > nav > div > ul > li:nth-child(3) > a")).Click();
                Thread.Sleep(5000);
            }
            catch
            {

            }

            //Assert
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#customerSearchBox")));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#customerSearchBox")).Click();
            driver.FindElement(By.CssSelector("#customerSearchBox")).SendKeys("Tester " + TesterNo + " Automation Testing");
            driver.FindElement(By.CssSelector("#customerSearchBox")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            string newContact = "Tester "+ TesterNo + " Automation Testing";
            string searchResult = driver.FindElement(By.CssSelector("#contacts-list > div > span > a > span:nth-child(2)")).Text + " " + driver.FindElement(By.CssSelector("#contacts-list > div > span > a > span:nth-child(3)")).Text;
            Assert.AreEqual(newContact, searchResult);
        }
    }
}
