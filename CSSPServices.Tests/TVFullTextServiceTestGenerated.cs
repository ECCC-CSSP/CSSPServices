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
    public partial class TVFullTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVFullTextService tvFullTextService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextServiceTest() : base()
        {
            //tvFullTextService = new TVFullTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFullText_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFullTextService tvFullTextService = new TVFullTextService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVFullText tvFullText = GetFilledRandomTVFullText("");

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

        #region Tests Generated for GetTVFullTextWithTVFullTextID(tvFullText.TVFullTextID)
        #endregion Tests Generated for GetTVFullTextWithTVFullTextID(tvFullText.TVFullTextID)

        #region Tests Generated for GetTVFullTextList()
        #endregion Tests Generated for GetTVFullTextList()

        #region Tests Generated for GetTVFullTextList() Skip Take
        #endregion Tests Generated for GetTVFullTextList() Skip Take

        #region Tests Generated for GetTVFullTextList() Skip Take Order
        #endregion Tests Generated for GetTVFullTextList() Skip Take Order

        #region Tests Generated for GetTVFullTextList() Skip Take 2Order
        #endregion Tests Generated for GetTVFullTextList() Skip Take 2Order

        #region Tests Generated for GetTVFullTextList() Skip Take Order Where
        #endregion Tests Generated for GetTVFullTextList() Skip Take Order Where

        #region Tests Generated for GetTVFullTextList() Skip Take Order 2Where
        #endregion Tests Generated for GetTVFullTextList() Skip Take Order 2Where

        #region Tests Generated for GetTVFullTextList() 2Where
        #endregion Tests Generated for GetTVFullTextList() 2Where

        #region Functions private
        private TVFullText GetFilledRandomTVFullText(string OmitPropName)
        {
            TVFullText tvFullText = new TVFullText();

            if (OmitPropName != "TVPath") tvFullText.TVPath = GetRandomString("", 6);
            if (OmitPropName != "FullText") tvFullText.FullText = GetRandomString("", 6);

            return tvFullText;
        }
        #endregion Functions private
    }
}
