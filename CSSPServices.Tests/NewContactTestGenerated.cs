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
    public partial class NewContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int NewContactID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public NewContactTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private NewContact GetFilledRandomNewContact(string OmitPropName)
        {
            NewContactID += 1;

            NewContact newContact = new NewContact();

            if (OmitPropName != "LoginEmail") newContact.LoginEmail = GetRandomEmail();
            if (OmitPropName != "FirstName") newContact.FirstName = GetRandomString("", 5);
            if (OmitPropName != "LastName") newContact.LastName = GetRandomString("", 5);
            if (OmitPropName != "Initial") newContact.Initial = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") newContact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));

            return newContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void NewContact_Testing()
        {
            SetupTestHelper(culture);
            NewContactService newContactService = new NewContactService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            NewContact newContact = GetFilledRandomNewContact("");

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
