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

        #region Functions public
        #endregion Functions public

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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolyPoint_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                PolyPointService polyPointService = new PolyPointService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                PolyPoint polyPoint = GetFilledRandomPolyPoint("");

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
