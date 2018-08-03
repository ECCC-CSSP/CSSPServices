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
    public partial class WhereInfoServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private WhereInfoService whereInfoService { get; set; }
        #endregion Properties

        #region Constructors
        public WhereInfoServiceTest() : base()
        {
            //whereInfoService = new WhereInfoService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private WhereInfo GetFilledRandomWhereInfo(string OmitPropName)
        {
            WhereInfo whereInfo = new WhereInfo();

            if (OmitPropName != "PropertyName") whereInfo.PropertyName = GetRandomString("", 5);
            if (OmitPropName != "PropertyType") whereInfo.PropertyType = (PropertyTypeEnum)GetRandomEnumType(typeof(PropertyTypeEnum));
            if (OmitPropName != "WhereOperator") whereInfo.WhereOperator = (WhereOperatorEnum)GetRandomEnumType(typeof(WhereOperatorEnum));
            if (OmitPropName != "Value") whereInfo.Value = GetRandomString("", 5);
            if (OmitPropName != "ValueInt") whereInfo.ValueInt = GetRandomInt(-1, -1);
            if (OmitPropName != "ValueDouble") whereInfo.ValueDouble = GetRandomDouble(-1.0D, -1.0D);
            if (OmitPropName != "ValueBool") whereInfo.ValueBool = true;
            if (OmitPropName != "ValueDateTime") whereInfo.ValueDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "ValueEnumText") whereInfo.ValueEnumText = GetRandomString("", 5);

            return whereInfo;
        }
        #endregion Functions private
    }
}
