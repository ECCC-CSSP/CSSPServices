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
    public partial class LastUpdateAndContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LastUpdateAndContactService lastUpdateAndContactService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactServiceTest() : base()
        {
            //lastUpdateAndContactService = new LastUpdateAndContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LastUpdateAndContact GetFilledRandomLastUpdateAndContact(string OmitPropName)
        {
            LastUpdateAndContact lastUpdateAndContact = new LastUpdateAndContact();

            if (OmitPropName != "Err") lastUpdateAndContact.Err = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateAndContactDate_UTC") lastUpdateAndContact.LastUpdateAndContactDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateAndContactTVItemID") lastUpdateAndContact.LastUpdateAndContactTVItemID = GetRandomInt(1, 11);

            return lastUpdateAndContact;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LastUpdateAndContact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LastUpdateAndContactService lastUpdateAndContactService = new LastUpdateAndContactService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LastUpdateAndContact lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");

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

        #region Tests Generated for GetLastUpdateAndContactWithLastUpdateAndContactID(lastUpdateAndContact.LastUpdateAndContactID)
        #endregion Tests Generated for GetLastUpdateAndContactWithLastUpdateAndContactID(lastUpdateAndContact.LastUpdateAndContactID)

        #region Tests Generated for GetLastUpdateAndContactList()
        #endregion Tests Generated for GetLastUpdateAndContactList()

        #region Tests Generated for GetLastUpdateAndContactList() Skip Take
        #endregion Tests Generated for GetLastUpdateAndContactList() Skip Take

    }
}
