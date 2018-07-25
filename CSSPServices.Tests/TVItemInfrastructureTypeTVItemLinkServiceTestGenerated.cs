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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemInfrastructureTypeTVItemLink_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemInfrastructureTypeTVItemLinkService tvItemInfrastructureTypeTVItemLinkService = new TVItemInfrastructureTypeTVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkWithTVItemInfrastructureTypeTVItemLinkID(tvItemInfrastructureTypeTVItemLink.TVItemInfrastructureTypeTVItemLinkID)
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkWithTVItemInfrastructureTypeTVItemLinkID(tvItemInfrastructureTypeTVItemLink.TVItemInfrastructureTypeTVItemLinkID)

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList()
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList()

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take 2Order
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take 2Order

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order Where
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order Where

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order 2Where
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() 2Where
        #endregion Tests Generated for GetTVItemInfrastructureTypeTVItemLinkList() 2Where

        #region Functions private
        private TVItemInfrastructureTypeTVItemLink GetFilledRandomTVItemInfrastructureTypeTVItemLink(string OmitPropName)
        {
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();

            if (OmitPropName != "InfrastructureType") tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            // should implement a Range for the property SeeOtherTVItemID and type TVItemInfrastructureTypeTVItemLink
            if (OmitPropName != "InfrastructureTypeText") tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText = GetRandomString("", 5);

            return tvItemInfrastructureTypeTVItemLink;
        }
        #endregion Functions private
    }
}
