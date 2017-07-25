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
        private DBTableService dBTableService { get; set; }
        #endregion Properties

        #region Constructors
        public DBTableTest() : base()
        {
            dBTableService = new DBTableService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DBTable GetFilledRandomDBTable(string OmitPropName)
        {
            DBTable dBTable = new DBTable();

            if (OmitPropName != "TableName") dBTable.TableName = GetRandomString("", 6);
            if (OmitPropName != "Plurial") dBTable.Plurial = GetRandomString("", 3);

            return dBTable;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void DBTable_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            DBTable dBTable = GetFilledRandomDBTable("");

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
