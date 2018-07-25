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
    public partial class CSSPWQInputParamServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private CSSPWQInputParamService cSSPWQInputParamService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamServiceTest() : base()
        {
            //cSSPWQInputParamService = new CSSPWQInputParamService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void CSSPWQInputParam_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    CSSPWQInputParamService cSSPWQInputParamService = new CSSPWQInputParamService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    CSSPWQInputParam cSSPWQInputParam = GetFilledRandomCSSPWQInputParam("");

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

        #region Tests Generated for GetCSSPWQInputParamWithCSSPWQInputParamID(cSSPWQInputParam.CSSPWQInputParamID)
        #endregion Tests Generated for GetCSSPWQInputParamWithCSSPWQInputParamID(cSSPWQInputParam.CSSPWQInputParamID)

        #region Tests Generated for GetCSSPWQInputParamList()
        #endregion Tests Generated for GetCSSPWQInputParamList()

        #region Tests Generated for GetCSSPWQInputParamList() Skip Take
        #endregion Tests Generated for GetCSSPWQInputParamList() Skip Take

        #region Tests Generated for GetCSSPWQInputParamList() Skip Take Order
        #endregion Tests Generated for GetCSSPWQInputParamList() Skip Take Order

        #region Tests Generated for GetCSSPWQInputParamList() Skip Take 2Order
        #endregion Tests Generated for GetCSSPWQInputParamList() Skip Take 2Order

        #region Tests Generated for GetCSSPWQInputParamList() Skip Take Order Where
        #endregion Tests Generated for GetCSSPWQInputParamList() Skip Take Order Where

        #region Tests Generated for GetCSSPWQInputParamList() Skip Take Order 2Where
        #endregion Tests Generated for GetCSSPWQInputParamList() Skip Take Order 2Where

        #region Tests Generated for GetCSSPWQInputParamList() 2Where
        #endregion Tests Generated for GetCSSPWQInputParamList() 2Where

        #region Functions private
        private CSSPWQInputParam GetFilledRandomCSSPWQInputParam(string OmitPropName)
        {
            CSSPWQInputParam cSSPWQInputParam = new CSSPWQInputParam();

            if (OmitPropName != "CSSPWQInputType") cSSPWQInputParam.CSSPWQInputType = (CSSPWQInputTypeEnum)GetRandomEnumType(typeof(CSSPWQInputTypeEnum));
            if (OmitPropName != "Name") cSSPWQInputParam.Name = GetRandomString("", 6);
            if (OmitPropName != "TVItemID") cSSPWQInputParam.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "CSSPWQInputTypeText") cSSPWQInputParam.CSSPWQInputTypeText = GetRandomString("", 5);

            return cSSPWQInputParam;
        }
        #endregion Functions private
    }
}
