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
    public partial class CSSPMPNTableServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private CSSPMPNTableService cSSPMPNTableService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPMPNTableServiceTest() : base()
        {
            //cSSPMPNTableService = new CSSPMPNTableService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void CSSPMPNTable_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    CSSPMPNTableService cSSPMPNTableService = new CSSPMPNTableService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    CSSPMPNTable cSSPMPNTable = GetFilledRandomCSSPMPNTable("");

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

        #region Tests Generated for GetCSSPMPNTableWithCSSPMPNTableID(cSSPMPNTable.CSSPMPNTableID)
        #endregion Tests Generated for GetCSSPMPNTableWithCSSPMPNTableID(cSSPMPNTable.CSSPMPNTableID)

        #region Tests Generated for GetCSSPMPNTableList()
        #endregion Tests Generated for GetCSSPMPNTableList()

        #region Tests Generated for GetCSSPMPNTableList() Skip Take
        #endregion Tests Generated for GetCSSPMPNTableList() Skip Take

        #region Tests Generated for GetCSSPMPNTableList() Skip Take Order
        #endregion Tests Generated for GetCSSPMPNTableList() Skip Take Order

        #region Tests Generated for GetCSSPMPNTableList() Skip Take 2Order
        #endregion Tests Generated for GetCSSPMPNTableList() Skip Take 2Order

        #region Tests Generated for GetCSSPMPNTableList() Skip Take Order Where
        #endregion Tests Generated for GetCSSPMPNTableList() Skip Take Order Where

        #region Tests Generated for GetCSSPMPNTableList() Skip Take Order 2Where
        #endregion Tests Generated for GetCSSPMPNTableList() Skip Take Order 2Where

        #region Tests Generated for GetCSSPMPNTableList() 2Where
        #endregion Tests Generated for GetCSSPMPNTableList() 2Where

        #region Functions private
        private CSSPMPNTable GetFilledRandomCSSPMPNTable(string OmitPropName)
        {
            CSSPMPNTable cSSPMPNTable = new CSSPMPNTable();

            if (OmitPropName != "Tube10") cSSPMPNTable.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") cSSPMPNTable.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") cSSPMPNTable.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "MPN") cSSPMPNTable.MPN = GetRandomInt(0, 100000000);

            return cSSPMPNTable;
        }
        #endregion Functions private
    }
}
