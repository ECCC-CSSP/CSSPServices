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
    public partial class LastUpdateAndTVTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LastUpdateAndTVTextService lastUpdateAndTVTextService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextServiceTest() : base()
        {
            //lastUpdateAndTVTextService = new LastUpdateAndTVTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LastUpdateAndTVText_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LastUpdateAndTVTextService lastUpdateAndTVTextService = new LastUpdateAndTVTextService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LastUpdateAndTVText lastUpdateAndTVText = GetFilledRandomLastUpdateAndTVText("");

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

        #region Tests Generated for GetLastUpdateAndTVTextWithLastUpdateAndTVTextID(lastUpdateAndTVText.LastUpdateAndTVTextID)
        #endregion Tests Generated for GetLastUpdateAndTVTextWithLastUpdateAndTVTextID(lastUpdateAndTVText.LastUpdateAndTVTextID)

        #region Tests Generated for GetLastUpdateAndTVTextList()
        #endregion Tests Generated for GetLastUpdateAndTVTextList()

        #region Tests Generated for GetLastUpdateAndTVTextList() Skip Take
        #endregion Tests Generated for GetLastUpdateAndTVTextList() Skip Take

        #region Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order
        #endregion Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order

        #region Tests Generated for GetLastUpdateAndTVTextList() Skip Take 2Order
        #endregion Tests Generated for GetLastUpdateAndTVTextList() Skip Take 2Order

        #region Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order Where
        #endregion Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order Where

        #region Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order 2Where
        #endregion Tests Generated for GetLastUpdateAndTVTextList() Skip Take Order 2Where

        #region Tests Generated for GetLastUpdateAndTVTextList() 2Where
        #endregion Tests Generated for GetLastUpdateAndTVTextList() 2Where

        #region Functions private
        private LastUpdateAndTVText GetFilledRandomLastUpdateAndTVText(string OmitPropName)
        {
            LastUpdateAndTVText lastUpdateAndTVText = new LastUpdateAndTVText();

            if (OmitPropName != "Error") lastUpdateAndTVText.Error = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateAndTVTextDate_UTC") lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_Local") lastUpdateAndTVText.LastUpdateDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TVText") lastUpdateAndTVText.TVText = GetRandomString("", 6);

            return lastUpdateAndTVText;
        }
        #endregion Functions private
    }
}
