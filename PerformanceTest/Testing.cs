using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest
{
    [TestFixture]
  public class Testing
    {
        private IWebDriver driver;

        [TestCase]
        public void HelloCsharp()
        {
            Console.WriteLine("hello World From C#");

        }

        [TestCase]
        public void RunSelenium()
        {
            FirefoxProfile prof = new FirefoxProfile(@"C:\\Users\\Caleb.Carvalho\\AppData\\Local\\Mozilla Firefox\\firefox.exe\\");
            driver = new FirefoxDriver(prof);

            driver.Navigate().GoToUrl("https://www.google.co.uk");
            Console.WriteLine(driver.Title);

            IWebElement elem = driver.FindElement(By.Name("q"));
            elem.SendKeys("hello caleb");
            elem.Submit();
            var isElementPresent = IsElementPresent(driver, By.TagName("a"));
            Console.WriteLine("retval {0}", isElementPresent);
            


            if (true)
            {

                IList<IWebElement> results = driver.FindElements(By.XPath(".//*[@id='rso']"));

                foreach (IWebElement ele in results)
                {

                    Console.WriteLine(ele.Text);


                }
            }

           
        }
        public bool IsElementPresent(IWebDriver driver, By locator)
        {
            //Set the timeout to something low
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(100));

            try
            {
                driver.FindElement(locator);
                //If element is found set the timeout back and return true
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
                return true;
            }
            catch (NoSuchElementException)
            {
                //If element isn't found, set the timeout and return false
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(200));
                return false;
            }
        }
    }
}
