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
    public partial class TVItemInfrastructureTypeTVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemInfrastructureTypeTVItemLinkService tvItemInfrastructureTypeTVItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkServiceTest() : base()
        {
            //tvItemInfrastructureTypeTVItemLinkService = new TVItemInfrastructureTypeTVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVItemInfrastructureTypeTVItemLink GetFilledRandomTVItemInfrastructureTypeTVItemLink(string OmitPropName)
        {
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();

            if (OmitPropName != "InfrastructureType") tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            // should implement a Range for the property SeeOtherTVItemID and type TVItemInfrastructureTypeTVItemLink
            if (OmitPropName != "InfrastructureTypeText") tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText = GetRandomString("", 5);
            //Error: property [TVItem] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented
            //Error: property [TVItemLinkList] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented
            //Error: property [FlowTo] and type [TVItemInfrastructureTypeTVItemLink] is  not implemented

            return tvItemInfrastructureTypeTVItemLink;
        }
        #endregion Functions private
    }
}
