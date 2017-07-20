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
    public partial class PolyPointTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int PolyPointID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolyPointTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolyPoint GetFilledRandomPolyPoint(string OmitPropName)
        {
            PolyPointID += 1;

            PolyPoint polyPoint = new PolyPoint();

            if (OmitPropName != "XCoord") polyPoint.XCoord = GetRandomFloat(-180.0f, 180.0f);
            if (OmitPropName != "YCoord") polyPoint.YCoord = GetRandomFloat(-90.0f, 90.0f);
            if (OmitPropName != "Z") polyPoint.Z = GetRandomFloat(1.0f, 1000.0f);

            return polyPoint;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolyPoint_Testing()
        {
            SetupTestHelper(culture);
            PolyPointService polyPointService = new PolyPointService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            PolyPoint polyPoint = GetFilledRandomPolyPoint("");

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
