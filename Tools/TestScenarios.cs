
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKEx.Clear.CDWGUI.Param;
using System.Data;
using System.Data.SqlClient;
using HKEx.Clear.CDWGUI;
using Tools;
using HKEx.Clear.CDWGUI.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace CWDTest
{
    
   
    [TestFixture]
    class TestScenarios
    {

        Approvals approvals;
        private IWebDriver driver;


       // private ParameterValue GetParamValue(string parameterName
      
       //[TestCase]
        public void CDQWReport_DashBoard()
        {
           

            /*Console.WriteLine("Starting Service Calls ");

            System.Net.NetworkCredential _logonCredentials = new System.Net.NetworkCredential();

            _logonCredentials.UserName=@"LMEFT\caleb.carvalho";
            _logonCredentials.Password="Monday1";
            
            ReportExecutionService rs = new ReportExecutionService();
                        
            rs.Credentials = _logonCredentials;
            rs.PreAuthenticate = true;
            
            rs.Url = "http://10.83.60.101/ReportServer_INST02/ReportExecution2005.asmx";
            string[] methods = rs.ListSecureMethods();
            Console.WriteLine("Getting Methods" , methods.Count());
            
            if (methods != null)
            {
                foreach (string method in methods)
                {
                    Console.WriteLine("Getting Methods " + method);
                }
            }

            rs.LoadReport2("/CDW Reporting/Market Risk/Margin Dashboard","");                     

            */
        }


        [TestCase]
        public void SeleniumTest()
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

            List<IWebElement> rest = new List<IWebElement>();
            var s = driver.FindElements(By.TagName("a"));
            bool valb = false;
            int count = 0;
            foreach (var ss in s)
            {
                try
                {
                    if (ss.Text.Equals("Next")) valb = true;                    

                    while (valb)
                    {
                        driver.FindElement(By.LinkText("Next")).Click();
                        count++;
                        s = driver.FindElements(By.XPath(".//*[@id='rso']"));
                        

                        foreach (var ss2 in s)
                        {

                            var att = ss2.GetAttribute("em");
                            Console.WriteLine("att is {0}", att);

                            Console.WriteLine("Clicked Next on Page: [ {0} ] \n{1}",count,ss2.Text);
                           
                        }

                        if (count == 2)
                        {
                            valb = false;
                            s = null;
                            break;

                        }
                    }                         



                }

                catch (Exception e) { }

                
            }





        }



        [TestCase]
        public void Approvals()
        {

            
            //clsDataAccess dataAccess = new clsDataAccess();
            //var con1 =dataAccess.GetConnection();

            
                string connectString = "Data Source=10.83.60.101,57381;Initial Catalog=EDWCLEAR_CORE;Integrated Security=True";
                var connection = new SqlConnection(connectString);

                var cmdSQL = new SqlCommand("SELECT TOP 1 ISIN FROM param.tblBond",connection);                            
                connection.Open();
                SqlDataReader reader = cmdSQL.ExecuteReader();
            
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}",   reader.GetString(0));
                    }

                    reader.NextResult();
                }
                //else
                //{
                    //Console.WriteLine("No rows found.");
                //}

                
               //clsDataAccess ss = new clsDataAccess();
                //var test = ss.GetConnection();



                reader.Close();                               
            
        }
        [TearDown]
        public void TearDown()
        {

            driver.Close();
            driver.Quit();
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
