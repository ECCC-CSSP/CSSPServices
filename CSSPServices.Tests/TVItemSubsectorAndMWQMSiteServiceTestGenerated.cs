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
    public partial class TVItemSubsectorAndMWQMSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemSubsectorAndMWQMSiteService tvItemSubsectorAndMWQMSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteServiceTest() : base()
        {
            //tvItemSubsectorAndMWQMSiteService = new TVItemSubsectorAndMWQMSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVItemSubsectorAndMWQMSite GetFilledRandomTVItemSubsectorAndMWQMSite(string OmitPropName)
        {
            TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = new TVItemSubsectorAndMWQMSite();

            //CSSPError: property [TVItemSubsector] and type [TVItemSubsectorAndMWQMSite] is  not implemented
            //CSSPError: property [TVItemMWQMSiteList] and type [TVItemSubsectorAndMWQMSite] is  not implemented
            //CSSPError: property [TVItemMWQMSiteDuplicate] and type [TVItemSubsectorAndMWQMSite] is  not implemented

            return tvItemSubsectorAndMWQMSite;
        }
        #endregion Functions private
    }
}
