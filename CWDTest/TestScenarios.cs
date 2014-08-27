


using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Tools;
using HKEx.Clear.CDWGUI.Data;
using HKEx.Clear.CDWGUI.Param;
using System.Collections;
using System.Windows;
using System.Windows.Threading;
using HKEx.Clear.CDWGUI.Param.CollateralHaircutsTableAdapters;
using NinjaCross.Classes.Nunit.TestPerformance;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using FluentAssertions;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace CWDTest
{


    [TestFixture, RequiresSTA]
    class TestScenarios
    {

        private Dictionary<int, int> _addListConcentrationStatus;
        private IWebDriver driver;


       
        [TestCase]
        public void UITest()
        {


         try{
            Console.WriteLine("\nBegin WPF UIAutomation test run\n"); // launch CryptoCalc application 
            // get reference to main Window control // get references to user controls 
            // manipulate application
            // check resulting state and determine pass/fail 

             Console.WriteLine("Launching LME GUI application"); 
             Process p = null; 
             p = Process.Start("C:\\CDW\\CDW_GUI_Deployment_LMEFT\\LMEClear_CDW_GUI.exe");

             int ct = 0; 
             do
             {
                 Console.WriteLine("Looking for LMEClear_CDW_GUI process. . . ");
                 ++ct;
                 Thread.Sleep(100);
             } while (p == null && ct < 50);
             if (p == null)
                 throw new Exception("Failed to find LMEClear_CDW_GUI process"); 
             else
                 Console.WriteLine("Found LMEClear_CDW_GUI process"); // Next I fetch a reference to the host machine's Desktop as an 
             // AutomationElement object:
             Console.WriteLine("\nGetting Desktop"); 
             AutomationElement aeDesktop = null; 
             aeDesktop = AutomationElement.RootElement; 

             if (aeDesktop == null) 
                 throw new Exception("Unable to get Desktop"); 
             else 
                 Console.WriteLine("Found Desktop\n");

             AutomationElement aeCryptoCalc = null; 
             int numWaits = 0; 
             do
             {
                 Console.WriteLine("Looking for LMEClear_CDW_GUI main window. . . "); 
                 aeCryptoCalc = aeDesktop.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "LMEClear")); 
                 ++numWaits; 
                 Thread.Sleep(200);
             } while (aeCryptoCalc == null && numWaits < 50);

             if (aeCryptoCalc == null)
                 throw new Exception("Failed to find LMEClear_CDW_GUI main window"); 
             else
                 Console.WriteLine("Found LMEClear_CDW_GUI main window");

             Console.WriteLine("\nGetting all user controls");


             AutomationElementCollection aeAllTextBoxes = null;
             aeAllTextBoxes = aeCryptoCalc.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "MenuBar"));


             if (aeAllTextBoxes == null)
             {
                 throw new Exception("No textboxes collection");
             }
             else
             {
                 Console.WriteLine("Got textboxes collection total of {0}", aeAllTextBoxes.Count);
             
                 foreach (AutomationElement txtBoxes in aeAllTextBoxes)
                 {
                     Console.WriteLine(txtBoxes);
                 }
             }

             AutomationElement aeMenuBar = null;
             aeMenuBar = aeCryptoCalc.FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.ItemTypeProperty, "MenuBar"));
             if (aeMenuBar == null) 
                 throw new Exception("Could not find File menu"); 
             else 
                 Console.WriteLine("Got File menu");

             Console.WriteLine(aeMenuBar);


             AutomationElement aeButton = null;
             aeButton = aeCryptoCalc.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Limit Management")); 

             if (aeButton == null) 
                 throw new Exception("No compute button"); 
             else 
                 Console.WriteLine("Got Compute button");

            Console.WriteLine("\nEnd automation\n"); 
        } 
        catch (Exception ex) { 
            Console.WriteLine("Fatal: " + ex.Message); 
        } 
        
    
    // class } // ns
      

           // List<AutomationPeer> children = windowPeer.GetName();
            //TabItemAutomationPeer tabs = (TabItemAutomationPeer)
            //TextBoxAutomationPeer textBoxPeer = (TextBoxAutomationPeer)children[children.Count] ;
            //ButtonAutomationPeer buttonPeer = (ButtonAutomationPeer)children[1];
           // Assert.AreEqual("0", ((IValueProvider)textBoxPeer).Value);

             

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


            var isElementPresent =IsElementPresent(driver, By.TagName("a"));
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
            bool valb=false;
            int count = 0;
            foreach (var ss in s)
            {
                try
                {
                    if(ss.Text.Equals("Next"))valb=true;
                    Console.WriteLine("new Txt {0}",ss.Text);

                 /*   while(true){
                            driver.FindElement(By.LinkText("Next")).Click();
                            count++;
                            s = driver.FindElements(By.XPath(".//*[@id='rso']")); 
                            foreach (var ss2 in s)
                            {
                                Console.WriteLine("new Txt {0}", ss2.Text);
                            }
                            if (count == 10)
                            {
                                valb = false;
                                TearDown();

                            }
                        }*/
                

                
                    }
                
                catch (Exception e) { }
            }




        }

        [TearDown]
        public void TearDown()
        {
            if (driver!= null)
            {
                driver.Close();
                driver.Quit();
            }
        }



        // private ParameterValue GetParamValue(string parameterName

        

        //  [TestCase]
        public void DisplayBondHaircutsTable()
        {
            /*clsDataAccess dataAccess = new clsDataAccess();
            var test = dataAccess.GetConnection();            

             var service = test.PacketSize;
             Console.WriteLine("Packet Size is {0}", service);

             var ver = test.ServerVersion;
             Console.WriteLine("Server Version {0}", ver);
          */
            BondHaircutsTableAdapter bondsHairCut = new BondHaircutsTableAdapter();

            var allData = bondsHairCut.GetData();

            foreach (DataColumn cols in allData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }


            foreach (var cols in allData)
            {

                Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}", cols.BondID, cols.ISIN, cols.ShortName, cols.CollateralID, cols.HaircutPercent, cols.IsPending);
            }

            //  test.Close();



        }



        //     [TestCase]
        [STAThread]
        public void StressScenarioBondDataTable()
        {

            HKEx.Clear.CDWGUI.Param.StressScenariosTableAdapters.GetStressScenarioBondTableAdapter bondStressScenarios = new HKEx.Clear.CDWGUI.Param.StressScenariosTableAdapters.GetStressScenarioBondTableAdapter();
            var alldata = bondStressScenarios.GetData();
            foreach (DataColumn cols in alldata.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }


            foreach (var cols in alldata)
            {

                Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", cols.StressScenarioDescription, cols.CollateralGroupName, cols.MaturityBucketValue, cols.BondTypeCode, cols.CollateralStressPriceChangePercent, cols.CollateralStressYieldChangePercent, cols.isEnabled);
            }

        }

        [TestCase]
        public void ViewEnrichedBond()
        {

            BondEnrichmentView bondEnrichmentView = new BondEnrichmentView();
            bondEnrichmentView.LoadData();

            var getParticularBond = bondEnrichmentView.BondLookupDT.FindByBondID(802);


            for (int i = 0; i < getParticularBond.ItemArray.Length; i++)
            {
                Console.WriteLine(getParticularBond.ItemArray[i]);
            }


        }

        [TestCase]
        public void Load_BoondSummaryScreen()
        {

            HKEx.Clear.CDWGUI.Param.BondsTableAdapters.GetBondsTableAdapter _bonds = new HKEx.Clear.CDWGUI.Param.BondsTableAdapters.GetBondsTableAdapter();
            var _alldata = _bonds.GetData();

            foreach (DataColumn cols in _alldata.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }
            Console.WriteLine("\n");

            foreach (DataRow rows in _alldata.Rows)
            {
                for (int i = 0; i < _alldata.Columns.Count; i++)
                {
                    Console.Write(rows.ItemArray[i] + "\t");
                }

                Console.WriteLine("\n");
            }

        }

        [TestCase]
        public void ConcentrationMarginView()
        {

            HKEx.Clear.CDWGUI.Param.ConcentrationMarginView _concetrationMargerns = new ConcentrationMarginView();

            _concetrationMargerns.LoadData();

            var _concentrationData = _concetrationMargerns.ConcentrationMarginsDT;

            foreach (DataColumn cols in _concentrationData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }
            Console.WriteLine("\n");

            foreach (DataRow rows in _concentrationData.Rows)
            {

                for (int i = 0; i < _concentrationData.Columns.Count; i++)
                {
                    Console.Write(rows.ItemArray[i] + "\t");
                }
                Console.WriteLine("\n");
            }

        }

        [TestCase]
        public void CollatorialStressView()
        {

            CollateralStressView _collateralStressView = new CollateralStressView();
            _collateralStressView.LoadData();
            foreach (DataRow row in _collateralStressView.StressScenarioBondDT.Rows)
            {

                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.Write(row.ItemArray[i] + "\t");
                }

                Console.WriteLine("\n");


            }

        }


        public void LoadList()
        {
            HKEx.Clear.CDWGUI.Param.ConcentrationMarginView _concetrationMargerns = new ConcentrationMarginView();
            _concetrationMargerns.LoadData();
            _addListConcentrationStatus = new Dictionary<int, int>();

            var _concentrationData = _concetrationMargerns.ConcentrationMarginsDT;

            foreach (DataColumn cols in _concentrationData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }
            Console.WriteLine("\n");



            for (int allRows = 0; allRows < _concentrationData.Rows.Count; allRows++)
            {

                DataRow row = _concetrationMargerns.ConcentrationMarginsDT.Rows[allRows];

                /*
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.Write(row.ItemArray[i] + "\t");


                }*/
                if (_addListConcentrationStatus.ContainsKey((int)row.ItemArray[0]))
                {
                    _addListConcentrationStatus.Remove((int)row.ItemArray[0]);
                }
                _addListConcentrationStatus.Add((int)row.ItemArray[0], (int)row.ItemArray[9]);
                

                // Console.WriteLine("\n");
            }

        }

        [TestCase]
        public void UpdateConcentrationMargin()
        {
            bool _approve = false;
            bool _editData = true;

            int[] _thresholdIdList = { 1, 82, 10, 19, 28 };
            int[] _underlinindIdList = { 3, 3, 3, 3, 3 };
            int[] _chargeNameIdList = { 1, 10, 2, 3, 4 };
            int[] _thresholdNameIdList = { 1, 10, 2, 3, 4 };
            int[] _thresholdList = { 20000, 118435, 43198, 55438, 64437 };

            string[] increaseAmount = { "29.000004", "188.00020", "55.000000", "86.000000", "90.000000" };


            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            #region ListPendingApprovalConcentrationMargin

            
            if (_editData)
            {
                LoadList();
                for (int i = 0; i < _thresholdIdList.Length; i++)
                {
                    decimal value = Convert.ToDecimal(increaseAmount[i]);

                    var res = clsLimits.EditConcentrationMargin(_thresholdIdList[i], _underlinindIdList[i], _chargeNameIdList[i], _thresholdNameIdList[i], _thresholdList[i], value);
                }
            }
            HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter approvalTable = new HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter();
            var approvals = approvalTable.GetData();

            Console.WriteLine("\nListing Approvals For Concentration Margins\n");
            int positionOfPendingColumn = 0, count = 0;
         
            foreach (DataColumn cols in approvals.Columns)
            {
                count++;
                Console.Write(cols.ColumnName + " \t");
                if (cols.ColumnName == "PendingConcentrationMarginID")
                {

                    positionOfPendingColumn = count - 1;
                }
            }
            Console.WriteLine("\n");

            int pendingCMID = 0;

            foreach (DataRow app in approvals.Rows)
            {

                for (int i = 0; i < app.ItemArray.Length; i++)
                {
                    Console.Write(app.ItemArray[i] + "\t");


                }

                Console.WriteLine("\n");

                if (_approve)
                {

                    Console.WriteLine("Approving CMID  {0}", app.ItemArray[positionOfPendingColumn]);
                    pendingCMID = (int)app.ItemArray[positionOfPendingColumn];
                    int concetrationThresholdId = (int)app.ItemArray[0];
                    var _retVal = clsApprovals.ApprovePendingConcentrationMargin(pendingCMID, concetrationThresholdId, true, true, 27);
                }



            }
            #endregion

            #region ListConcentrationMarginView


            HKEx.Clear.CDWGUI.Param.ConcentrationMarginView _concetrationMargerns = new ConcentrationMarginView();
            _concetrationMargerns.LoadData();


            var _concentrationData = _concetrationMargerns.ConcentrationMarginsDT;

            foreach (DataColumn cols in _concentrationData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }
            Console.WriteLine("\n");
          

            for (int allRows = 0; allRows < _concentrationData.Rows.Count; allRows++)
            {

                DataRow row = _concetrationMargerns.ConcentrationMarginsDT.Rows[allRows];


                //var dict = _addListConcentrationStatus.Cast<DictionaryEntry>().ToDictionary(d => d.Key, d => d.Value);

                //dict.Add(_addListConcentrationStatus);

//                var my = _addListConcentrationStatus.FirstOrDefault(x => (int)x.Value == 1).Key;
                
                var getValues= _addListConcentrationStatus.FirstOrDefault(x => x.Value == (int)row.ItemArray[9]).Value;
                var getKeys = _addListConcentrationStatus.FirstOrDefault(x => x.Key == (int)row.ItemArray[0]).Key;


                var myValue = _addListConcentrationStatus.FirstOrDefault(x => x.Key == getValues).Value;

                if (getKeys.Equals(row.ItemArray[0]))
                {

                    Console.WriteLine("Keys==>>{0} has values==>{1}", row.ItemArray[0],myValue);
                    myValue.Should().Equals(myValue);
                    Assert.That(myValue, Is.InRange(0,1));

                    
                }
                

                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.Write(row.ItemArray[i] + "\t");
                    

                }
                Console.WriteLine("\n");


            }

            #endregion

            timer.Stop();

            int elapsedSeconds = timer.Elapsed.Seconds;
            Console.WriteLine("Total Elapse Time {0}", elapsedSeconds);


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
