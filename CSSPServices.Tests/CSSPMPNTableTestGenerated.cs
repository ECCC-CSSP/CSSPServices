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
    public partial class CSSPMPNTableTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPMPNTableService cSSPMPNTableService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPMPNTableTest() : base()
        {
            cSSPMPNTableService = new CSSPMPNTableService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

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

        #region Tests Generated
        [TestMethod]
        public void CSSPMPNTable_Testing()
        {

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
        #endregion Tests Generated
    }
}
