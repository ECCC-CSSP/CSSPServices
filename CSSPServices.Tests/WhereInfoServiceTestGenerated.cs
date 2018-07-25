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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void WhereInfo_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    WhereInfoService whereInfoService = new WhereInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    WhereInfo whereInfo = GetFilledRandomWhereInfo("");

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

        #region Tests Generated for GetWhereInfoWithWhereInfoID(whereInfo.WhereInfoID)
        #endregion Tests Generated for GetWhereInfoWithWhereInfoID(whereInfo.WhereInfoID)

        #region Tests Generated for GetWhereInfoList()
        #endregion Tests Generated for GetWhereInfoList()

        #region Tests Generated for GetWhereInfoList() Skip Take
        #endregion Tests Generated for GetWhereInfoList() Skip Take

        #region Tests Generated for GetWhereInfoList() Skip Take Order
        #endregion Tests Generated for GetWhereInfoList() Skip Take Order

        #region Tests Generated for GetWhereInfoList() Skip Take 2Order
        #endregion Tests Generated for GetWhereInfoList() Skip Take 2Order

        #region Tests Generated for GetWhereInfoList() Skip Take Order Where
        #endregion Tests Generated for GetWhereInfoList() Skip Take Order Where

        #region Tests Generated for GetWhereInfoList() Skip Take Order 2Where
        #endregion Tests Generated for GetWhereInfoList() Skip Take Order 2Where

        #region Tests Generated for GetWhereInfoList() 2Where
        #endregion Tests Generated for GetWhereInfoList() 2Where

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
