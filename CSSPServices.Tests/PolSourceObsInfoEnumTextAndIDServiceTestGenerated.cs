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
    public partial class PolSourceObsInfoEnumTextAndIDServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDServiceTest() : base()
        {
            //polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObsInfoEnumTextAndID_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = GetFilledRandomPolSourceObsInfoEnumTextAndID("");

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

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDWithPolSourceObsInfoEnumTextAndIDID(polSourceObsInfoEnumTextAndID.PolSourceObsInfoEnumTextAndIDID)
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDWithPolSourceObsInfoEnumTextAndIDID(polSourceObsInfoEnumTextAndID.PolSourceObsInfoEnumTextAndIDID)

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList()
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList()

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take 2Order
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take 2Order

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order Where
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order Where

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order 2Where
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() Skip Take Order 2Where

        #region Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() 2Where
        #endregion Tests Generated for GetPolSourceObsInfoEnumTextAndIDList() 2Where

        #region Functions private
        private PolSourceObsInfoEnumTextAndID GetFilledRandomPolSourceObsInfoEnumTextAndID(string OmitPropName)
        {
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = new PolSourceObsInfoEnumTextAndID();

            if (OmitPropName != "Text") polSourceObsInfoEnumTextAndID.Text = GetRandomString("", 20);
            if (OmitPropName != "ID") polSourceObsInfoEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceObsInfoEnumTextAndID;
        }
        #endregion Functions private
    }
}
