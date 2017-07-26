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
    public partial class TVItemInfrastructureTypeTVItemLinkTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemInfrastructureTypeTVItemLinkService tvItemInfrastructureTypeTVItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkTest() : base()
        {
            tvItemInfrastructureTypeTVItemLinkService = new TVItemInfrastructureTypeTVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemInfrastructureTypeTVItemLink GetFilledRandomTVItemInfrastructureTypeTVItemLink(string OmitPropName)
        {
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();

            if (OmitPropName != "InfrastructureType") tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            // should implement a Range for the property SeeOtherTVItemID and type TVItemInfrastructureTypeTVItemLink

            return tvItemInfrastructureTypeTVItemLink;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemInfrastructureTypeTVItemLink_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = GetFilledRandomTVItemInfrastructureTypeTVItemLink("");

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
