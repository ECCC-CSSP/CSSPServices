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
        private NewContactService newContactService { get; set; }
        #endregion Properties

        #region Constructors
        public NewContactTest() : base()
        {
            newContactService = new NewContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private NewContact GetFilledRandomNewContact(string OmitPropName)
        {
            NewContact newContact = new NewContact();

            if (OmitPropName != "LoginEmail") newContact.LoginEmail = GetRandomString("", 6);
            if (OmitPropName != "FirstName") newContact.FirstName = GetRandomString("", 6);
            if (OmitPropName != "LastName") newContact.LastName = GetRandomString("", 6);
            if (OmitPropName != "Initial") newContact.Initial = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") newContact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));

            return newContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void NewContact_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

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
