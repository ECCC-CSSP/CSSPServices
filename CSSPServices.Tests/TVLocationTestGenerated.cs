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
    public partial class TVLocationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVLocationID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVLocationTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVLocation GetFilledRandomTVLocation(string OmitPropName)
        {
            TVLocationID += 1;

            TVLocation tvLocation = new TVLocation();

            if (OmitPropName != "Error") tvLocation.Error = GetRandomString("", 20);
            if (OmitPropName != "TVItemID") tvLocation.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvLocation.TVText = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvLocation.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "SubTVType") tvLocation.SubTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));

            return tvLocation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVLocation_Testing()
        {
            SetupTestHelper(culture);
            TVLocationService tvLocationService = new TVLocationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TVLocation tvLocation = GetFilledRandomTVLocation("");

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
