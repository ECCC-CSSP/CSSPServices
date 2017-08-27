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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class DBTableServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private DBTableService dBTableService { get; set; }
        #endregion Properties

        #region Constructors
        public DBTableServiceTest() : base()
        {
            //dBTableService = new DBTableService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "HasErrors") dBTable.HasErrors = true;

            return dBTable;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void DBTable_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DBTableService dBTableService = new DBTableService(LanguageRequest, dbTestDB, ContactID);

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
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
