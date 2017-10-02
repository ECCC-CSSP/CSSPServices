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
    public partial class TVLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVLocationService tvLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVLocationServiceTest() : base()
        {
            //tvLocationService = new TVLocationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVLocation GetFilledRandomTVLocation(string OmitPropName)
        {
            TVLocation tvLocation = new TVLocation();

            if (OmitPropName != "Error") tvLocation.Error = GetRandomString("", 20);
            if (OmitPropName != "TVItemID") tvLocation.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvLocation.TVText = GetRandomString("", 6);
            if (OmitPropName != "TVType") tvLocation.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "SubTVType") tvLocation.SubTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVTypeText") tvLocation.TVTypeText = GetRandomString("", 5);
            if (OmitPropName != "SubTVTypeText") tvLocation.SubTVTypeText = GetRandomString("", 5);

            return tvLocation;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVLocation_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVLocationService tvLocationService = new TVLocationService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVLocation tvLocation = GetFilledRandomTVLocation("");

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

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVLocation
        #endregion Tests Get List of TVLocation

    }
}
