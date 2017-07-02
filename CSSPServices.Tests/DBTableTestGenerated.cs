using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class DBTableTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int DBTableID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public DBTableTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DBTable GetFilledRandomDBTable(string OmitPropName)
        {
            DBTableID += 1;

            DBTable dBTable = new DBTable();

            if (OmitPropName != "TableName") dBTable.TableName = GetRandomString("", 1);
            if (OmitPropName != "Plurial") dBTable.Plurial = GetRandomString("", 1);

            return dBTable;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void DBTable_Testing()
        {
            SetupTestHelper(culture);
            DBTableService dBTableService = new DBTableService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
