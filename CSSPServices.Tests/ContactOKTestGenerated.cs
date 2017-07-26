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
    public partial class ContactOKTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactOKService contactOKService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKTest() : base()
        {
            contactOKService = new ContactOKService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactOK GetFilledRandomContactOK(string OmitPropName)
        {
            ContactOK contactOK = new ContactOK();

            if (OmitPropName != "Error") contactOK.Error = GetRandomString("", 5);
            if (OmitPropName != "ContactID") contactOK.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ContactTVItemID") contactOK.ContactTVItemID = GetRandomInt(1, 11);

            return contactOK;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactOK_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ContactOK contactOK = GetFilledRandomContactOK("");

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
