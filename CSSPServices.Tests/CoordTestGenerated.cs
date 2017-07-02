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
    public partial class CoordTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CoordID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CoordTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Coord GetFilledRandomCoord(string OmitPropName)
        {
            CoordID += 1;

            Coord coord = new Coord();

            if (OmitPropName != "Lat") coord.Lat = GetRandomFloat(-180, 180);
            if (OmitPropName != "Lng") coord.Lng = GetRandomFloat(-90, 90);
            if (OmitPropName != "Ordinal") coord.Ordinal = GetRandomInt(0, 10000);

            return coord;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Coord_Testing()
        {
            SetupTestHelper(culture);
            CoordService coordService = new CoordService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
