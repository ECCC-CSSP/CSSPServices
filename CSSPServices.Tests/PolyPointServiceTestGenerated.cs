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
    public partial class PolyPointServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolyPointService polyPointService { get; set; }
        #endregion Properties

        #region Constructors
        public PolyPointServiceTest() : base()
        {
            //polyPointService = new PolyPointService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private PolyPoint GetFilledRandomPolyPoint(string OmitPropName)
        {
            PolyPoint polyPoint = new PolyPoint();

            if (OmitPropName != "XCoord") polyPoint.XCoord = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "YCoord") polyPoint.YCoord = GetRandomDouble(-90.0D, 90.0D);
            // should implement a Range for the property Z and type PolyPoint

            return polyPoint;
        }
        #endregion Functions private
    }
}
