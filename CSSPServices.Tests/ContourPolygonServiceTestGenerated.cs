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

        #region Functions private
        private ContourPolygon GetFilledRandomContourPolygon(string OmitPropName)
        {
            ContourPolygon contourPolygon = new ContourPolygon();

            if (OmitPropName != "ContourValue") contourPolygon.ContourValue = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Layer") contourPolygon.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Depth_m") contourPolygon.Depth_m = GetRandomDouble(1.0D, 10000.0D);
            //Error: property [ContourNodeList] and type [ContourPolygon] is  not implemented

            return contourPolygon;
        }
        #endregion Functions private
    }
}
