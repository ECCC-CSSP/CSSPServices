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
    public partial class DataPathOfTideTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int DataPathOfTideID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DataPathOfTide GetFilledRandomDataPathOfTide(string OmitPropName)
        {
            DataPathOfTideID += 1;

            DataPathOfTide dataPathOfTide = new DataPathOfTide();

            if (OmitPropName != "Text") dataPathOfTide.Text = GetRandomString("", 5);
            if (OmitPropName != "WebTideDataSet") dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));

            return dataPathOfTide;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void DataPathOfTide_Testing()
        {
            SetupTestHelper(culture);
            DataPathOfTideService dataPathOfTideService = new DataPathOfTideService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            DataPathOfTide dataPathOfTide = GetFilledRandomDataPathOfTide("");

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
