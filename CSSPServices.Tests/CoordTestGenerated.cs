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
        private CoordService coordService { get; set; }
        #endregion Properties

        #region Constructors
        public CoordTest() : base()
        {
            coordService = new CoordService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Coord GetFilledRandomCoord(string OmitPropName)
        {
            Coord coord = new Coord();

            if (OmitPropName != "Lat") coord.Lat = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "Lng") coord.Lng = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Ordinal") coord.Ordinal = GetRandomInt(0, 10000);

            return coord;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Coord_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Coord coord = GetFilledRandomCoord("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

        }
        #endregion Tests Generated
    }
}
