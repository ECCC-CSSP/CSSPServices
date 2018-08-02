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
    public partial class QueryServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private QueryService queryService { get; set; }
        #endregion Properties

        #region Constructors
        public QueryServiceTest() : base()
        {
            //queryService = new QueryService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Query_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    QueryService queryService = new QueryService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Query query = GetFilledRandomQuery("");

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

        #region Tests Generated for GetQueryWithQueryID(query.QueryID)
        #endregion Tests Generated for GetQueryWithQueryID(query.QueryID)

        #region Tests Generated for GetQueryList()
        #endregion Tests Generated for GetQueryList()

        #region Tests Generated for GetQueryList() Skip Take
        #endregion Tests Generated for GetQueryList() Skip Take

        #region Tests Generated for GetQueryList() Skip Take Order
        #endregion Tests Generated for GetQueryList() Skip Take Order

        #region Tests Generated for GetQueryList() Skip Take 2Order
        #endregion Tests Generated for GetQueryList() Skip Take 2Order

        #region Tests Generated for GetQueryList() Skip Take Order Where
        #endregion Tests Generated for GetQueryList() Skip Take Order Where

        #region Tests Generated for GetQueryList() Skip Take Order 2Where
        #endregion Tests Generated for GetQueryList() Skip Take Order 2Where

        #region Tests Generated for GetQueryList() 2Where
        #endregion Tests Generated for GetQueryList() 2Where

        #region Functions private
        private Query GetFilledRandomQuery(string OmitPropName)
        {
            Query query = new Query();

            //Error: property [ModelType] and type [Query] is  not implemented
            if (OmitPropName != "Language") query.Language = LanguageRequest;
            if (OmitPropName != "Lang") query.Lang = GetRandomString("", 2);
            if (OmitPropName != "Skip") query.Skip = GetRandomInt(0, 1000000);
            if (OmitPropName != "Take") query.Take = GetRandomInt(1, 1000000);
            if (OmitPropName != "Order") query.Order = GetRandomString("", 5);
            if (OmitPropName != "Where") query.Where = GetRandomString("", 5);
            if (OmitPropName != "EntityQueryDetailType") query.EntityQueryDetailType = (EntityQueryDetailTypeEnum)GetRandomEnumType(typeof(EntityQueryDetailTypeEnum));
            if (OmitPropName != "EntityQueryType") query.EntityQueryType = (EntityQueryTypeEnum)GetRandomEnumType(typeof(EntityQueryTypeEnum));
            if (OmitPropName != "OrderList") query.OrderList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            //Error: property [WhereInfoList] and type [Query] is  not implemented

            return query;
        }
        #endregion Functions private
    }
}
