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
    public partial class NewContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private NewContactService newContactService { get; set; }
        #endregion Properties

        #region Constructors
        public NewContactServiceTest() : base()
        {
            //newContactService = new NewContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void NewContact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    NewContactService newContactService = new NewContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetNewContactWithNewContactID(newContact.NewContactID)
        #endregion Tests Generated for GetNewContactWithNewContactID(newContact.NewContactID)

        #region Tests Generated for GetNewContactList()
        #endregion Tests Generated for GetNewContactList()

        #region Tests Generated for GetNewContactList() Skip Take
        #endregion Tests Generated for GetNewContactList() Skip Take

        #region Tests Generated for GetNewContactList() Skip Take Order
        #endregion Tests Generated for GetNewContactList() Skip Take Order

        #region Tests Generated for GetNewContactList() Skip Take 2Order
        #endregion Tests Generated for GetNewContactList() Skip Take 2Order

        #region Tests Generated for GetNewContactList() Skip Take Order Where
        #endregion Tests Generated for GetNewContactList() Skip Take Order Where

        #region Tests Generated for GetNewContactList() Skip Take Order 2Where
        #endregion Tests Generated for GetNewContactList() Skip Take Order 2Where

        #region Tests Generated for GetNewContactList() 2Where
        #endregion Tests Generated for GetNewContactList() 2Where

        #region Functions private
        private NewContact GetFilledRandomNewContact(string OmitPropName)
        {
            NewContact newContact = new NewContact();

            if (OmitPropName != "LoginEmail") newContact.LoginEmail = GetRandomString("", 6);
            if (OmitPropName != "FirstName") newContact.FirstName = GetRandomString("", 6);
            if (OmitPropName != "LastName") newContact.LastName = GetRandomString("", 6);
            if (OmitPropName != "Initial") newContact.Initial = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") newContact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));
            if (OmitPropName != "ContactTitleText") newContact.ContactTitleText = GetRandomString("", 5);

            return newContact;
        }
        #endregion Functions private
    }
}
