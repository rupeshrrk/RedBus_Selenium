using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;


namespace RedBus_Selenium
{
    public class RedbusOperators
    {
        // Create a new ChromeDriver instance
        IWebDriver driver = new ChromeDriver();

        // Declare path to the output file
        // Get the current project path
        string filePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent + @"\Output\Operators.txt";

        [Test]
        public void Test()
        {
            // Navigate to the RedBus homepage and maximize the window
            driver.Navigate().GoToUrl("https://www.redbus.in/");
            driver.Manage().Window.Maximize();

            // Scroll to the bottom of the page using JavaScriptExecutor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            // Get the handle of the current window
            string mainWindowHandle = driver.CurrentWindowHandle;

            // Click the "All Operators" link to open a new window
            IWebElement AllOperators = driver.FindElement(By.LinkText("All Operators >"));
            AllOperators.Click();

            string newWindowHandle = string.Empty;

            // loop through all the window handles and find the new window handle
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    newWindowHandle = handle;
                    break;
                }
            }

            // switch to the new window
            driver.SwitchTo().Window(newWindowHandle);

            // Click the links for the letters "I", "R", and "A" 
            IWebElement Aplphabet_I = driver.FindElement(By.LinkText("I"));
            Aplphabet_I.Click();

            IWebElement Alphabet_R = driver.FindElement(By.LinkText("R"));
            Alphabet_R.Click();

            IWebElement Alphabet_A = driver.FindElement(By.LinkText("A"));
            Alphabet_A.Click();

            // Declare a list to store the operator names
            List<string> Operators_A = new List<string>();

            // Wait for the page to load before continuing
            var wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.StalenessOf(Alphabet_A));

            // If the file already exists, clear its contents and write headers
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
                using StreamWriter writer = File.AppendText(filePath);
                writer.WriteLine("###############################################################");
                writer.WriteLine("BELOW ARE THE LIST OF OPERATOR NAMES THAT STARTS WITH LETTER A");
                writer.WriteLine("###############################################################");
            }


            // Find all the operator links on the page1 and add them to the list
            IList<IWebElement> Operatorlist1 = driver.FindElements(By.XPath("//a[@class='D113_link']"));
            foreach (IWebElement Item in Operatorlist1)
            {

                string name = Item.Text;
                Operators_A.Add(name);

                if (File.Exists(filePath))
                {
                    using StreamWriter writer = File.AppendText(filePath);
                    writer.WriteLine("--------- Page 1 of 5 ---------");
                    writer.WriteLine(name);

                }
            }

            // Find all the operator links on the page2 and add them to the list
            IWebElement Page_2 = driver.FindElement(By.LinkText("2"));
            Page_2.Click();
            wait1.Until(ExpectedConditions.StalenessOf(Page_2));

            IList<IWebElement> Operatorlist2 = driver.FindElements(By.XPath("//a[@class='D113_link']"));
            foreach (IWebElement Item in Operatorlist2)
            {
                string name = Item.Text;
                Operators_A.Add(name);

                if (File.Exists(filePath))
                {
                    using StreamWriter writer = File.AppendText(filePath);
                    writer.WriteLine("--------- Page 2 of 5 ---------");
                    writer.WriteLine(name);

                }
            }

            // Find all the operator links on the page3 and add them to the list
            IWebElement Page_3 = driver.FindElement(By.LinkText("3"));
            Page_3.Click();
            wait1.Until(ExpectedConditions.StalenessOf(Page_3));

            IList<IWebElement> Operatorlist3 = driver.FindElements(By.XPath("//a[@class='D113_link']"));
            foreach (IWebElement Item in Operatorlist3)
            {
                string name = Item.Text;
                Operators_A.Add(name);

                if (File.Exists(filePath))
                {
                    using StreamWriter writer = File.AppendText(filePath);
                    writer.WriteLine("--------- Page 3 of 5 ---------");
                    writer.WriteLine(name);
                }
            }

            // Find all the operator links on the page4 and add them to the list
            IWebElement Page_4 = driver.FindElement(By.LinkText("4"));
            Page_4.Click();
            wait1.Until(ExpectedConditions.StalenessOf(Page_4));

            IList<IWebElement> Operatorlist4 = driver.FindElements(By.XPath("//a[@class='D113_link']"));
            foreach (IWebElement Item in Operatorlist4)
            {
                string name = Item.Text;
                Operators_A.Add(name);

                if (File.Exists(filePath))
                {
                    using StreamWriter writer = File.AppendText(filePath);
                    writer.WriteLine("--------- Page 4 of 5 ---------");
                    writer.WriteLine(name);
                }
            }

            // Find all the operator links on the page5 and add them to the list
            IWebElement Page_5 = driver.FindElement(By.LinkText("5"));
            Page_5.Click();
            wait1.Until(ExpectedConditions.StalenessOf(Page_5));



            IList<IWebElement> Operatorlist5 = driver.FindElements(By.XPath("//a[@class='D113_link']"));
            foreach (IWebElement Item in Operatorlist5)
            {
                string name = Item.Text;
                Operators_A.Add(name);

                if (File.Exists(filePath))
                {
                    using StreamWriter writer = File.AppendText(filePath);
                    writer.WriteLine("--------- Page 5 of 5 ---------");
                    writer.WriteLine(name);
                }
            }

            //Adding Total count of operators to the file
            using StreamWriter writertotal = File.AppendText(filePath);
            writertotal.WriteLine("################################################");
            writertotal.WriteLine("Total Number of Operatos: " + Operators_A.Count);
            writertotal.WriteLine("################################################");

            //Close all Browser windows
            driver.Quit();

        }
    }

}



