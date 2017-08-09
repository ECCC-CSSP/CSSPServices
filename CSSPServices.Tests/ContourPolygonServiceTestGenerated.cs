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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class ContourPolygonServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContourPolygonService contourPolygonService { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonServiceTest() : base()
        {
            //contourPolygonService = new ContourPolygonService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth") contourPolygon.Depth = GetRandomDouble(1.0D, 10000.0D);

            return contourPolygon;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContourPolygon_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContourPolygonService contourPolygonService = new ContourPolygonService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                ContourPolygon contourPolygon = GetFilledRandomContourPolygon("");

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
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}