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
    public partial class ContourPolygonTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ContourPolygonID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygonID += 1;

            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomFloat(0.0f, 10.0f);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth") contourPolygon.Depth = GetRandomFloat(1.0f, 10000.0f);

            return contourPolygon;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContourPolygon_Testing()
        {
            SetupTestHelper(culture);
            ContourPolygonService contourPolygonService = new ContourPolygonService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            ContourPolygon contourPolygon = GetFilledRandomContourPolygon("");

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
