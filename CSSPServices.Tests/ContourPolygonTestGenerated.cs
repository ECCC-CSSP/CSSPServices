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
        private ContourPolygonService contourPolygonService { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonTest() : base()
        {
            contourPolygonService = new ContourPolygonService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth") contourPolygon.Depth = GetRandomDouble(1.0D, 1000.0D);

            return contourPolygon;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContourPolygon_Testing()
        {

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
