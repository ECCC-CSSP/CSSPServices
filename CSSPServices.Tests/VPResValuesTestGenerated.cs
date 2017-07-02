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
    public partial class VPResValuesTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int VPResValuesID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPResValuesTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResValues GetFilledRandomVPResValues(string OmitPropName)
        {
            VPResValuesID += 1;

            VPResValues vpResValues = new VPResValues();

            if (OmitPropName != "Conc") vpResValues.Conc = GetRandomInt(0, 10);
            if (OmitPropName != "Dilu") vpResValues.Dilu = GetRandomDouble(1.0f, 5.0f);
            if (OmitPropName != "FarfieldWidth") vpResValues.FarfieldWidth = GetRandomDouble(1.0f, 5.0f);
            if (OmitPropName != "Distance") vpResValues.Distance = GetRandomDouble(1.0f, 5.0f);
            if (OmitPropName != "TheTime") vpResValues.TheTime = GetRandomDouble(1.0f, 5.0f);
            if (OmitPropName != "Decay") vpResValues.Decay = GetRandomDouble(1.0f, 5.0f);

            return vpResValues;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPResValues_Testing()
        {
            SetupTestHelper(culture);
            VPResValuesService vpResValuesService = new VPResValuesService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
