using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI; //From Selenium Support Nuget, use for Wait Element
using System.Collections.Generic;
using System.Threading;
using Gauge.Automation.Testing.Logic;

namespace UNITTestGaugeWebPROD
{
    [TestFixture]
    public class SmokeTest
    {
        static IWebDriver driverUse;
       
        [SetUp]
        public void BeforeEachTest()
        {
            //Set browser to use
            string browser = "Chrome";

            switch (browser)
            {
                case "Chrome":
                    driverUse = new ChromeDriver(@"E:\TFS\Dev\MyHerbalife3.Crm.Web.AcceptanceTest");
                    break;
                case "Firefox":
                    driverUse = new FirefoxDriver();
                    break;
                case "IE":
                    driverUse = new InternetExplorerDriver();
                    break;
            }

            driverUse.Manage().Window.Maximize();
            //driverUse.Navigate().GoToUrl(ProdConfig.LoginUrl);
            driverUse.Navigate().GoToUrl("https://crm.myherbalife.com/Crm/Home/Login?ReturnUrl=%2FCrm%2Fspa");
        }

        public void Login()
        {
            //Arrange
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(30));

            //Action
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("localeDropDownList")));
            driverUse.FindElement(By.Id("localeDropDownList")).Click();

            IList<IWebElement> localeList = driverUse.FindElement(By.Id("localeDropDownList")).FindElements(By.TagName("option"));
            localeList[5].Click(); //Select India-English

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("username")));
            driverUse.FindElement(By.Id("username")).SendKeys("company2");
            driverUse.FindElement(By.Id("pin")).SendKeys("9885");
            driverUse.FindElement(By.Id("btnLogin")).Click();
        }

        [Test]
        public void DailyGoals()
        {
            //Arrange
            Boolean setGoals = false;
            string TempTarget;
            string NCCurrentTarget = "";
            IWebElement E_NewCustTarget;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(30));

            //Action
            try
            {
                Thread.Sleep(7000);
                driverUse.FindElement(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > a")).Click(); //Click on Set Goals button

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")));

                //Enter Target for New Contact
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).SendKeys("2");

                //Enter Target for Daily Visitor
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(4) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(4) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(4) > span > input[type=\"number\"]")).SendKeys("4");

                //Enter Target for Event Participants
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(6) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(6) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(6) > span > input[type=\"number\"]")).SendKeys("6");

                //Enter Target for New Preferred Customers
                IWebElement pCustomer = driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(8) > span > input[type=\"number\"]")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", pCustomer);
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(8) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(8) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(8) > span > input[type=\"number\"]")).SendKeys("7");

                //Enter Target for New Charter Preferred Customers
                IWebElement cpCustomer = driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(9) > span > input[type=\"number\"]")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", cpCustomer);
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(9) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(9) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(9) > span > input[type=\"number\"]")).SendKeys("8");

                //Enter Target for New Long Term Customers
                IWebElement ltCustomer = driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(10) > span > input[type=\"number\"]")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", ltCustomer);
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(10) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(10) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(3) > div:nth-child(10) > span > input[type=\"number\"]")).SendKeys("9");

                //Enter Target for Customers Consumptions
                IWebElement consumptions = driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(2) > span > input[type=\"number\"]")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", consumptions);
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(2) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(2) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(2) > span > input[type=\"number\"]")).SendKeys("5");

                //Enter Target for Volume Point
                IWebElement vp = driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(3) > span > input[type=\"number\"]")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", vp);
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(3) > span > input[type=\"number\"]")).Click();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(3) > span > input[type=\"number\"]")).Clear();
                driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div.set-goals.no-border > div:nth-child(3) > span > input[type=\"number\"]")).SendKeys("15");

                //Click on Done
                IWebElement done = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", done);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")).Click();
                Thread.Sleep(5000);
                setGoals = true;

                //Assert
                try
                {
                    E_NewCustTarget = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div > div > div.k-target")); //Without Progress
                }
                catch
                {
                    E_NewCustTarget = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div > div.k-target")); //With Progress
                }

                string NewCustTarget = E_NewCustTarget.Text;

                // Check Current Target
                for (int a = 0; a < NewCustTarget.Length; a++)
                {
                    TempTarget = NewCustTarget.Substring(a, 1);

                    if (TempTarget == "/")
                    {
                        int remainL = NewCustTarget.Length - (a + 1);
                        NCCurrentTarget = NewCustTarget.Substring(a + 1, remainL);
                    }
                }
                Assert.AreEqual("2", NCCurrentTarget); // Assert New Customer Target
                Assert.IsTrue(setGoals);
            }
            catch
            {
                // Goals already set
                setGoals = true;
            }
        }

        [Test]
        public void EditGoals()
        {
            // Arrange
            string TempTarget;
            string NCCurrentTarget = "";
            IWebElement E_NewCustTarget;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(30));
            Thread.Sleep(8000);

            // Action
            IWebElement button = driverUse.FindElement(By.Id("editIcon"));
            button.Click(); // Click on Edit Button
            Thread.Sleep(3000);

            //Enter Target for New Contact
            driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).Click();
            driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).Clear();
            driverUse.FindElement(By.CssSelector("#set-goal-container > form > div > div:nth-child(2) > div:nth-child(2) > span > input[type=\"number\"]")).SendKeys("5");

            //Click on Done
            IWebElement done = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", done);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")).Click();
            Thread.Sleep(7000);

            // Assert
            try
            {
                E_NewCustTarget = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div > div > div.k-target")); //Without Progress
            }
            catch
            {
                E_NewCustTarget = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div > div.k-target")); //With Progress
            }
            string NewCustTarget = E_NewCustTarget.Text;

            // Check Current Target
            for (int a = 0; a < NewCustTarget.Length; a++)
            {
                TempTarget = NewCustTarget.Substring(a, 1);

                if (TempTarget == "/")
                {
                    int remainL = NewCustTarget.Length - (a + 1);
                    NCCurrentTarget = NewCustTarget.Substring(a + 1, remainL);
                }
            }

            Assert.AreEqual("5", NCCurrentTarget);
        }

        [Test]
        public void NewContact()
        {
            //Arrange
            Login();

            //Action
            Contact NewContact = new Contact();
            NewContact.Add(driverUse);
        }

        [Test]
        public void DeleteContact()
        {
            //Arrange
            bool check = false;
            string msg ="";
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

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
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.contacts > a")).Click(); // Click on Contact Tab
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#contacts-list > div:nth-child(1) > span > a")));
            Thread.Sleep(3000);
            string lname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a > span:nth-child(2)")).Text;
            string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a > span:nth-child(3)")).Text;
            string contact = lname + " " + fname;
            driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > header > a:nth-child(3)")));
            Thread.Sleep(2000);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(3)")).Click(); //Click on Edit button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > header > a.pull-right.btn-primary.btn-trash > img"))); 
            Thread.Sleep(2000);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.pull-right.btn-primary.btn-trash > img")).Click(); // Click on Delete button

            //Assert
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#customerSearchBox")));
            driverUse.FindElement(By.CssSelector("#customerSearchBox")).SendKeys(contact);
            driverUse.FindElement(By.CssSelector("#customerSearchBox")).SendKeys(Keys.Enter);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#searchResults > div:nth-child(2) > div > strong")));
                Thread.Sleep(2000);
                msg = driverUse.FindElement(By.CssSelector("#searchResults > div:nth-child(2) > div > strong")).Text;
            }
            catch
            {

            }
            if (msg=="" || msg== "Customer Not Found")
            {
                check = true;
            }
            Assert.IsTrue(check);
        }

        [Test]
        public void EditContact_PhoneNumber()
        {
            //Arrange
            Login();
            Random rnd = new Random();
            string PhoneNo = rnd.Next(100000).ToString();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

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
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.contacts > a")).Click(); // Click on Contact Tab
            Thread.Sleep(3000);
            IWebElement fContact = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", fContact);
            string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a > span:nth-child(3)")).Text;
            driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > span > a")).Click(); // Click on contact
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > header > a:nth-child(3)")));
            Thread.Sleep(2000);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(3)")).Click(); //Click on Edit button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > header > a.pull-right.btn-primary.btn-trash > img")));
            Thread.Sleep(2000);
            driverUse.FindElement(By.CssSelector("#contactLastName")).Clear();
            driverUse.FindElement(By.CssSelector("#contactLastName")).SendKeys("Automation - Edit Phone Number");
            driverUse.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(7) > div:nth-child(1) > div > div.divider > div > div.number > input")).Clear();
            driverUse.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(7) > div:nth-child(1) > div > div.divider > div > div.number > input")).SendKeys(PhoneNo);
            IWebElement doneButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary > img")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary > img")).Click(); //Click on Done button

            //Assert
            string contact = fname + " Automation - Edit Phone Number";
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > header > a:nth-child(3) > img")));
            string afterPno = driverUse.FindElement(By.CssSelector("#contactInfoForm > div.profile-container > div:nth-child(6) > div > div.divider > div > span > strong:nth-child(3)")).Text;
            Assert.AreEqual(PhoneNo, afterPno);
        }

        [Test]
        public void TrackClubVisit()
        {
            //Arrange
            bool check = false;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

            //Action
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > a")));
            }
            catch
            {
                // After Goals Set then only can track activity
                Thread.Sleep(3000);
                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.activities > a")).Click(); //Click on Activity tab
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(2)")));
                Thread.Sleep(2000);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(2)")).Click();
                Thread.Sleep(3000);
                IWebElement fContact = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", fContact);
                string lname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(1)")).Text;
                string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(2)")).Text;
                string cvContact = lname + " " + fname;
                driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")).Click(); //Click on contact
                IWebElement doneButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")).Click(); //Click on Done button
                Thread.Sleep(2000);
                //Check if hit goals dialog pop-up
                try
                {
                    IWebElement okButton = driverUse.FindElement(By.ClassName("button-set"));
                    okButton.FindElement(By.TagName("input")).Click();
                    Thread.Sleep(2000);
                }
                catch
                {

                }

                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.goals > a")).Click();
                Thread.Sleep(5000);
                driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(3) > div > div.progressbar.k-widget.k-progressbar.k-progressbar-horizontal > div > span")).Click();
                Thread.Sleep(5000);
                IList<IWebElement> contacts = driverUse.FindElements(By.CssSelector("#contacts-list > div")); // Contacts
                int contactCount = contacts.Count;

                for (int a = 0; a < contactCount; a++)
                {
                    IList<IWebElement> name = contacts[a].FindElements(By.TagName("span"));
                    var lName = name[1].Text;
                    var fName = name[2].Text;
                    string contactDetail = fName + " "+ lName;
                    if (contactDetail == cvContact)
                    {
                        a = contactCount;
                        check = true;
                    }
                }
            }

            //Assert
            Assert.IsTrue(check);
        }

        [Test]
        public void TrackConsumption()
        {
            //Arrange
            bool check = false;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

            //Action
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > a"))); //Check to see if goals set
            }
            catch
            {
                // After Goals Set then only can track activity
                Thread.Sleep(3000);
                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.activities > a")).Click(); //Click on Activity tab
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(7) > span"))); //Wait for Consumption link show
                Thread.Sleep(2000);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(7) > span")).Click(); //Click on Consumption
                Thread.Sleep(3000);
                IWebElement fContact = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", fContact);
                string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(1)")).Text;
                string lname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(2)")).Text;
                string cvContact = lname + " " + fname;
                driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")).Click(); //Click on contact
                Thread.Sleep(2000);
                IWebElement doneButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(6) > img")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(6) > img")).Click(); //Click on Next button
                Thread.Sleep(2000);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div.set-goals.volume-points > div.k-widget.k-listview > div > span > input")).SendKeys("1"); //Enter value for consumption
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")).Click(); //Click on Done button
                Thread.Sleep(2000);
                //Check if hit goals dialog pop-up
                try
                {
                    IWebElement okButton = driverUse.FindElement(By.ClassName("button-set"));
                    okButton.FindElement(By.TagName("input")).Click();
                    Thread.Sleep(2000);
                }
                catch
                {

                }

                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.goals > a")).Click(); //Click on Dashboad tab
                Thread.Sleep(5000);
                IWebElement consumptionGoals = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(17) > div > div")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", consumptionGoals);
                driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(17) > div > div")).Click();
                Thread.Sleep(5000);

                IList<IWebElement> contacts = driverUse.FindElements(By.CssSelector("#contacts-list > div")); // Contacts
                int contactCount = contacts.Count;

                for (int a = 0; a < contactCount; a++)
                {
                    IList<IWebElement> name = contacts[a].FindElements(By.TagName("span"));
                    var lName = name[1].Text;
                    var fName = name[2].Text;
                    string contactDetail = lName + " " + fName;
                    if (contactDetail == cvContact)
                    {
                        a = contactCount;
                        check = true;
                    }
                }
            }

            //Assert
            Assert.IsTrue(check);
        }

        [Test]
        public void TrackVolumePoint()
        {
            //Arrange
            bool check = false;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

            //Action
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > a"))); //Check to see if goals set
            }
            catch
            {
                // After Goals Set then only can track activity
                Thread.Sleep(3000);
                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.activities > a")).Click(); //Click on Activity tab
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(7) > span"))); //Wait for Consumption link show
                Thread.Sleep(2000);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(6) > span")).Click(); //Click on Volume Point
                Thread.Sleep(3000);
                IWebElement fContact = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", fContact);
                string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(1)")).Text;
                string lname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(2)")).Text;
                string cvContact = lname + " " + fname;
                driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")).Click(); //Click on contact
                Thread.Sleep(2000);
                IWebElement nextButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(6) > img")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", nextButton);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a:nth-child(6) > img")).Click(); //Click on Next button
                Thread.Sleep(2000);
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div.set-goals.volume-points > div.k-widget.k-listview > div > span > input")).SendKeys("15.5"); //Enter value for consumption
                driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")).Click(); //Click on Done button
                Thread.Sleep(3000);
                //Check if hit goals dialog pop-up
                try
                {
                    IWebElement okButton = driverUse.FindElement(By.ClassName("button-set"));
                    okButton.FindElement(By.TagName("input")).Click();
                    Thread.Sleep(2000);
                }
                catch
                {

                }

                driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.goals > a")).Click(); //Click on Dashboad tab
                Thread.Sleep(5000);
                IWebElement volumePointGoals = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(18) > div > div")); //Scrool to the element
                ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", volumePointGoals);
                driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(18) > div > div")).Click();
                Thread.Sleep(5000);

                IList<IWebElement> contacts = driverUse.FindElements(By.CssSelector("#contacts-list > div")); // Contacts
                int contactCount = contacts.Count;

                for (int a = 0; a < contactCount; a++)
                {
                    IList<IWebElement> name = contacts[a].FindElements(By.TagName("span"));
                    var lName = name[1].Text;
                    var fName = name[2].Text;
                    string contactDetail = lName + " " + fName;
                    if (contactDetail == cvContact)
                    {
                        a = contactCount;
                        check = true;
                    }
                }
            }

            //Assert
            Assert.IsTrue(check);
        }

        [Test]
        public void AddTodayEvent()
        {
            //Arrange
            bool check = false;
            Random rnd = new Random();
            string EventNo = rnd.Next(100000).ToString();
            string eventName = "Automation Testing Event " + EventNo;
            Login();
            WebDriverWait wait = new WebDriverWait(driverUse, TimeSpan.FromSeconds(20));

            //Action
            Thread.Sleep(8000);
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.more > a")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Manage Events")));
            driverUse.FindElement(By.LinkText("Manage Events")).Click();
            Thread.Sleep(5000);
            driverUse.FindElement(By.LinkText("Add Event")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#addEvent > div > form > div > div:nth-child(1) > select")));
            //Thread.Sleep(3000);
            driverUse.FindElement(By.CssSelector("#addEvent > div > form > div > div:nth-child(1) > select")).Click(); //Click on Category
            Thread.Sleep(2000);
            IList<IWebElement> category = driverUse.FindElements(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(1) > select > option"));
            category[2].Click(); // Click On Holiday
            driverUse.FindElement(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(2) > input[type=\"text\"]")).SendKeys("Automation Testing Event "+ EventNo); // Enter Event Name
            driverUse.FindElement(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(3) > textarea")).SendKeys("Automation Testing"); // Enter Event Description
            driverUse.FindElement(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(5) > div > div > select:nth-child(1)")).Click(); //Click on Hours
            IList<IWebElement> hours = driverUse.FindElements(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(5) > div > div > select:nth-child(1) > option"));
            hours[2].Click();
            driverUse.FindElement(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(5) > div > div > select:nth-child(2)")).Click(); //Click on Minutres
            IList<IWebElement> minutes = driverUse.FindElements(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(5) > div > div > select:nth-child(2) > option"));
            minutes[2].Click();
            driverUse.FindElement(By.CssSelector("#addEvent > div:nth-child(1) > form > div > div:nth-child(5) > div > div > div > span:nth-child(2)")).Click(); // Click on "PM"
            IWebElement doneButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.pull-right.btn-primary.save-goal > img")).Click();
            Thread.Sleep(4000);
            IList<IWebElement> events = driverUse.FindElements(By.CssSelector("#manageEvents > ul > li"));

            for (int a = 0; a < events.Count; a++)
            {
                string todayEvent = events[a].Text;
                if (todayEvent==eventName)
                {
                    a = events.Count;
                    check = true;
                }
            }

            //Assert
            Assert.IsTrue(check);
        }

        [Test]
        public void NewCustomer_GoalsProgress()
        {
            //Arrange
            string before = "0";
            string after = "0";
            Login();

            //Action
            Thread.Sleep(7000); //Wait for Goals page to load
            string progress = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div")).Text;
            int count = progress.Length;

            for (int a=0;a<count;a++)
            {
                string current = progress.Substring(a, 1);
                if (current == "/")
                {
                    before = progress.Substring(0,a); //Capture New Customer Progress (before)
                }
            }

            Contact NewContact = new Contact();
            NewContact.Add(driverUse);

            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.goals > a")).Click();
            Thread.Sleep(5000); //Wait for Goals page to load

            string afterProgress = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(1) > div")).Text;
            int afterCount = progress.Length;

            for (int a = 0; a < afterCount; a++)
            {
                string current = afterProgress.Substring(a, 1);
                if (current == "/")
                {
                    after = afterProgress.Substring(0, a); //Capture New Customer Progress (before)
                }
            }

            int expected = Convert.ToInt32(before) + 1;
            int actual = Convert.ToInt32(after);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClubVisit_GoalsProgress()
        {
            //Arrange
            string before = "0";
            string after = "0";
            Login();

            //Action
            Thread.Sleep(7000); //Wait for Goals page to load
            string progress = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(3) > div")).Text;
            int count = progress.Length;

            for (int a = 0; a < count; a++)
            {
                string current = progress.Substring(a, 1);
                if (current == "/")
                {
                    before = progress.Substring(0, a); //Capture New Customer Progress (before)
                }
            }

            Thread.Sleep(3000);
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.activities > a")).Click(); //Click on Activity tab
            Thread.Sleep(3000);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div:nth-child(3) > div > div > a:nth-child(2)")).Click();
            Thread.Sleep(3000);
            IWebElement fContact = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", fContact);
            string lname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(1)")).Text;
            string fname = driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1) > div > div > label > span:nth-child(3) > span:nth-child(2)")).Text;
            string cvContact = lname + " " + fname;
            driverUse.FindElement(By.CssSelector("#contacts-list > div:nth-child(1)")).Click(); //Click on contact
            IWebElement doneButton = driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")); //Scrool to the element
            ((IJavaScriptExecutor)driverUse).ExecuteScript("arguments[0].scrollIntoView(true);", doneButton);
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > header > a.right.btn-primary.pull-right")).Click(); //Click on Done button
            Thread.Sleep(2000);
            //Check if hit goals dialog pop-up
            try
            {
                IWebElement okButton = driverUse.FindElement(By.ClassName("button-set"));
                okButton.FindElement(By.TagName("input")).Click();
                Thread.Sleep(2000);
            }
            catch
            {

            }
            //Click on Dashboards Tab
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li.goals > a")).Click();
            Thread.Sleep(3000);
            string afterProgress = driverUse.FindElement(By.CssSelector("#goals-report-container > div:nth-child(3) > div")).Text;
            int afterCount = progress.Length;

            for (int a = 0; a < afterCount; a++)
            {
                string current = afterProgress.Substring(a, 1);
                if (current == "/")
                {
                    after = afterProgress.Substring(0, a); //Capture New Customer Progress (before)
                }
            }

            int expected = Convert.ToInt32(before) + 1;
            int actual = Convert.ToInt32(after);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClubPartner_NoGoalsSetForToday()
        {
            //Arrange
            string msg;
            Login();

            //Action
            Thread.Sleep(7000);
            driverUse.FindElement(By.Id("slick")).Click(); //Click on the Club Operator drop down
            Thread.Sleep(3000);
            IList<IWebElement> operators = driverUse.FindElements(By.CssSelector("#slick > option"));
            operators[1].Click();
            Thread.Sleep(3000);
            msg = driverUse.FindElement(By.CssSelector("#goalsProgressGrid > div:nth-child(4) > div > h2")).Text;

            //Assert
            Assert.AreEqual("No Goals set for today.", msg);
        }

        [TearDown]
        public void Cleanup()
        {
            //Click More Page Tab
            Thread.Sleep(5000);
            driverUse.FindElement(By.CssSelector("body > nav > div > ul > li:nth-child(5) > a")).Click();
            Thread.Sleep(2000);

            //Click Sign Out
            driverUse.FindElement(By.CssSelector("#nc-crm-content > div > div > ul > li:nth-child(8) > a > div > div > strong")).Click();
            Thread.Sleep(2000);
            driverUse.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);

            //Quit driver
            driverUse.Quit();
        }
    }
}
