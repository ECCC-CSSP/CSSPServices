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
    public partial class PolSourceInactiveReasonEnumTextAndIDTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int PolSourceInactiveReasonEnumTextAndIDID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceInactiveReasonEnumTextAndID GetFilledRandomPolSourceInactiveReasonEnumTextAndID(string OmitPropName)
        {
            PolSourceInactiveReasonEnumTextAndIDID += 1;

            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = new PolSourceInactiveReasonEnumTextAndID();

            if (OmitPropName != "Text") polSourceInactiveReasonEnumTextAndID.Text = GetRandomString("", 5);
            if (OmitPropName != "ID") polSourceInactiveReasonEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceInactiveReasonEnumTextAndID;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceInactiveReasonEnumTextAndID_Testing()
        {
            SetupTestHelper(culture);
            PolSourceInactiveReasonEnumTextAndIDService polSourceInactiveReasonEnumTextAndIDService = new PolSourceInactiveReasonEnumTextAndIDService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
