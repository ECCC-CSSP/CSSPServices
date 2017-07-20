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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class LastUpdateAndContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LastUpdateAndContactID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LastUpdateAndContact GetFilledRandomLastUpdateAndContact(string OmitPropName)
        {
            LastUpdateAndContactID += 1;

            LastUpdateAndContact lastUpdateAndContact = new LastUpdateAndContact();

            if (OmitPropName != "Error") lastUpdateAndContact.Error = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") lastUpdateAndContact.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") lastUpdateAndContact.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return lastUpdateAndContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LastUpdateAndContact_Testing()
        {
            SetupTestHelper(culture);
            LastUpdateAndContactService lastUpdateAndContactService = new LastUpdateAndContactService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            LastUpdateAndContact lastUpdateAndContact = GetFilledRandomLastUpdateAndContact("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
