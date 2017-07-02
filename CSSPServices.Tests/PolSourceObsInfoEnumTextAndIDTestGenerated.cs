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
        private int PolSourceObsInfoEnumTextAndIDID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObsInfoEnumTextAndID GetFilledRandomPolSourceObsInfoEnumTextAndID(string OmitPropName)
        {
            PolSourceObsInfoEnumTextAndIDID += 1;

            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = new PolSourceObsInfoEnumTextAndID();

            if (OmitPropName != "Text") polSourceObsInfoEnumTextAndID.Text = GetRandomString("", 5);
            if (OmitPropName != "ID") polSourceObsInfoEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceObsInfoEnumTextAndID;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObsInfoEnumTextAndID_Testing()
        {
            SetupTestHelper(culture);
            PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
