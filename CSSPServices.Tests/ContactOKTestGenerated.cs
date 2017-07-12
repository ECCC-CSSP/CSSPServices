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
        private int ContactOKID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactOK GetFilledRandomContactOK(string OmitPropName)
        {
            ContactOKID += 1;

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
            SetupTestHelper(culture);
            ContactOKService contactOKService = new ContactOKService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            ContactOK contactOK = GetFilledRandomContactOK("");

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
