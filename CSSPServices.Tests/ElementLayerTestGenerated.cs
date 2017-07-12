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
    public partial class ElementLayerTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ElementLayerID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ElementLayerTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ElementLayer GetFilledRandomElementLayer(string OmitPropName)
        {
            ElementLayerID += 1;

            ElementLayer elementLayer = new ElementLayer();

            if (OmitPropName != "Layer") elementLayer.Layer = GetRandomInt(1, 1000);
            if (OmitPropName != "ZMin") elementLayer.ZMin = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "ZMax") elementLayer.ZMax = GetRandomFloat(1.0f, 1000.0f);

            return elementLayer;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ElementLayer_Testing()
        {
            SetupTestHelper(culture);
            ElementLayerService elementLayerService = new ElementLayerService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            ElementLayer elementLayer = GetFilledRandomElementLayer("");

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
