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
    public partial class PolSourceObsInfoEnumTextAndIDTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDTest() : base()
        {
            polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObsInfoEnumTextAndID GetFilledRandomPolSourceObsInfoEnumTextAndID(string OmitPropName)
        {
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = new PolSourceObsInfoEnumTextAndID();

            if (OmitPropName != "Text") polSourceObsInfoEnumTextAndID.Text = GetRandomString("", 20);
            if (OmitPropName != "ID") polSourceObsInfoEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceObsInfoEnumTextAndID;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObsInfoEnumTextAndID_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = GetFilledRandomPolSourceObsInfoEnumTextAndID("");

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
