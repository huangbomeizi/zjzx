using zjzx.dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using com.timjcshop.www.Model;
using System.Data;
using zjzx.entity;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for BZDaoTest and is intended
    ///to contain all BZDaoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BZDaoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getList
        ///</summary>
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%PathToWebRoot%\\zjzx\\zjzx", "/")]
        [UrlToTest("http://localhost:1269/")]
        public void getListTest()
        {
            BZDao target = new BZDao(); // TODO: Initialize to an appropriate value
            string fieldList = "Id,bzh,bzmc,fbsj"; // TODO: Initialize to an appropriate value
            string orderField = "Id"; // TODO: Initialize to an appropriate value
            bool orderBy = false; // TODO: Initialize to an appropriate value
            int pageIndex = 1; // TODO: Initialize to an appropriate value
            int pageSize = 2; // TODO: Initialize to an appropriate value
            string where = string.Empty; // TODO: Initialize to an appropriate value
            DataRecordTable actual;
            actual = target.getList(fieldList, orderField, orderBy, pageIndex, pageSize, @where);
            System.Console.WriteLine(actual.RecordCount+";"+actual.PageCount);
            foreach (DataRow row in actual.Table.Rows)
            {
                System.Console.WriteLine(row["bzh"].ToString() + ";" + row["bzmc"].ToString() + ";" + row["fbsj"].ToString());
            }
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for batchDelete
        ///</summary>
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%PathToWebRoot%\\zjzx\\zjzx", "/")]
        [UrlToTest("http://localhost:1269/")]
        public void batchDeleteTest()
        {
            BZDao target = new BZDao(); // TODO: Initialize to an appropriate value
            string ids = "1,2"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.batchDelete(ids);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getEntity
        ///</summary>
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%PathToWebRoot%\\zjzx\\zjzx", "/")]
        [UrlToTest("http://localhost:1269/")]
        public void getEntityTest()
        {
            BZDao target = new BZDao(); // TODO: Initialize to an appropriate value
            int id = 3; // TODO: Initialize to an appropriate value
            BZ actual;
            actual = target.getEntity(id);
            System.Console.WriteLine(actual.Id);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
