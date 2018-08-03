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
    public partial class LatLngServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LatLngService latLngService { get; set; }
        #endregion Properties

        #region Constructors
        public LatLngServiceTest() : base()
        {
            //latLngService = new LatLngService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private LatLng GetFilledRandomLatLng(string OmitPropName)
        {
            LatLng latLng = new LatLng();

            if (OmitPropName != "Lat") latLng.Lat = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "Lng") latLng.Lng = GetRandomDouble(-90.0D, 90.0D);

            return latLng;
        }
        #endregion Functions private
    }
}
