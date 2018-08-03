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
    public partial class ContactOKServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactOKService contactOKService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKServiceTest() : base()
        {
            //contactOKService = new ContactOKService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

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
    }
}
