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
    public partial class GetParamServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private GetParamService getParamService { get; set; }
        #endregion Properties

        #region Constructors
        public GetParamServiceTest() : base()
        {
            //getParamService = new GetParamService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private GetParam GetFilledRandomGetParam(string OmitPropName)
        {
            GetParam getParam = new GetParam();

            //Error: property [ModelType] and type [GetParam] is  not implemented
            if (OmitPropName != "Language") getParam.Language = LanguageRequest;
            if (OmitPropName != "Lang") getParam.Lang = GetRandomString("", 2);
            if (OmitPropName != "Skip") getParam.Skip = GetRandomInt(0, 10);
            if (OmitPropName != "Take") getParam.Take = GetRandomInt(0, 10);
            if (OmitPropName != "OrderByNames") getParam.OrderByNames = GetRandomString("", 5);
            if (OmitPropName != "Where") getParam.Where = GetRandomString("", 5);
            if (OmitPropName != "EntityQueryDetailType") getParam.EntityQueryDetailType = (EntityQueryDetailTypeEnum)GetRandomEnumType(typeof(EntityQueryDetailTypeEnum));
            if (OmitPropName != "EntityQueryType") getParam.EntityQueryType = (EntityQueryTypeEnum)GetRandomEnumType(typeof(EntityQueryTypeEnum));

            return getParam;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void GetParam_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    GetParam getParam = GetFilledRandomGetParam("");

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

        #region Tests Generated for GetGetParamWithGetParamID(getParam.GetParamID)
        #endregion Tests Generated for GetGetParamWithGetParamID(getParam.GetParamID)

        #region Tests Generated for GetGetParamList()
        #endregion Tests Generated for GetGetParamList()

        #region Tests Generated for GetGetParamList() Skip Take
        #endregion Tests Generated for GetGetParamList() Skip Take

    }
}
