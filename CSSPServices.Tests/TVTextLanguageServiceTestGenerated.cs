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
    public partial class TVTextLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTextLanguageService tvTextLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageServiceTest() : base()
        {
            //tvTextLanguageService = new TVTextLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVTextLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTextLanguageService tvTextLanguageService = new TVTextLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVTextLanguage tvTextLanguage = GetFilledRandomTVTextLanguage("");

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

        #region Tests Generated for GetTVTextLanguageWithTVTextLanguageID(tvTextLanguage.TVTextLanguageID)
        #endregion Tests Generated for GetTVTextLanguageWithTVTextLanguageID(tvTextLanguage.TVTextLanguageID)

        #region Tests Generated for GetTVTextLanguageList()
        #endregion Tests Generated for GetTVTextLanguageList()

        #region Tests Generated for GetTVTextLanguageList() Skip Take
        #endregion Tests Generated for GetTVTextLanguageList() Skip Take

        #region Tests Generated for GetTVTextLanguageList() Skip Take Order
        #endregion Tests Generated for GetTVTextLanguageList() Skip Take Order

        #region Tests Generated for GetTVTextLanguageList() Skip Take 2Order
        #endregion Tests Generated for GetTVTextLanguageList() Skip Take 2Order

        #region Tests Generated for GetTVTextLanguageList() Skip Take Order Where
        #endregion Tests Generated for GetTVTextLanguageList() Skip Take Order Where

        #region Tests Generated for GetTVTextLanguageList() Skip Take Order 2Where
        #endregion Tests Generated for GetTVTextLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetTVTextLanguageList() 2Where
        #endregion Tests Generated for GetTVTextLanguageList() 2Where

        #region Functions private
        private TVTextLanguage GetFilledRandomTVTextLanguage(string OmitPropName)
        {
            TVTextLanguage tvTextLanguage = new TVTextLanguage();

            if (OmitPropName != "TVText") tvTextLanguage.TVText = GetRandomString("", 20);
            if (OmitPropName != "Language") tvTextLanguage.Language = LanguageRequest;
            if (OmitPropName != "LanguageText") tvTextLanguage.LanguageText = GetRandomString("", 5);

            return tvTextLanguage;
        }
        #endregion Functions private
    }
}
