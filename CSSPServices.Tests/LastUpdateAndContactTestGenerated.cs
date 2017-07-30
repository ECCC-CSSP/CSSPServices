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
    public partial class LastUpdateAndContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LastUpdateAndContactService lastUpdateAndContactService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactTest() : base()
        {
            lastUpdateAndContactService = new LastUpdateAndContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LastUpdateAndContact GetFilledRandomLastUpdateAndContact(string OmitPropName)
        {
            LastUpdateAndContact lastUpdateAndContact = new LastUpdateAndContact();

            if (OmitPropName != "Error") lastUpdateAndContact.Error = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") lastUpdateAndContact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") lastUpdateAndContact.LastUpdateContactTVItemID = 2;

            return lastUpdateAndContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LastUpdateAndContact_Testing()
        {

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
        #endregion Tests Generated
    }
}
