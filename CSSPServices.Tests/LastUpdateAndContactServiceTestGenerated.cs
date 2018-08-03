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
    }
}
