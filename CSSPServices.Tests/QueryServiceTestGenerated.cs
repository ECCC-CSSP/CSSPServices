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
            if (OmitPropName != "Detail") query.Detail = GetRandomString("", 1);
            if (OmitPropName != "OrderList") query.OrderList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            //Error: property [WhereInfoList] and type [Query] is  not implemented

            return query;
        }
        #endregion Functions private
    }
}
