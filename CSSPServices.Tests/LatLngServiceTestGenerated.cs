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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LatLng GetFilledRandomLatLng(string OmitPropName)
        {
            LatLng latLng = new LatLng();

            if (OmitPropName != "Lat") latLng.Lat = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "Lng") latLng.Lng = GetRandomDouble(-90.0D, 90.0D);

            return latLng;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LatLng_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LatLngService latLngService = new LatLngService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LatLng latLng = GetFilledRandomLatLng("");

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
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetLatLngWithLatLngID(latLng.LatLngID)
        #endregion Tests Generated for GetLatLngWithLatLngID(latLng.LatLngID)

        #region Tests Generated for GetLatLngList()
        #endregion Tests Generated for GetLatLngList()

        #region Tests Generated for GetLatLngList() Skip Take
        #endregion Tests Generated for GetLatLngList() Skip Take

    }
}
