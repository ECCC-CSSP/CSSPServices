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
    public partial class LatLngTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LatLngID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LatLngTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LatLng GetFilledRandomLatLng(string OmitPropName)
        {
            LatLngID += 1;

            LatLng latLng = new LatLng();

            if (OmitPropName != "Lat") latLng.Lat = GetRandomFloat(-180, 180);
            if (OmitPropName != "Lng") latLng.Lng = GetRandomFloat(-90, 90);

            return latLng;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LatLng_Testing()
        {
            SetupTestHelper(culture);
            LatLngService latLngService = new LatLngService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            LatLng latLng = GetFilledRandomLatLng("");

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
