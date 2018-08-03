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
