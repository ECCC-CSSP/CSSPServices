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
    public partial class CSSPWQInputParamTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWQInputParamService cSSPWQInputParamService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamTest() : base()
        {
            cSSPWQInputParamService = new CSSPWQInputParamService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPWQInputParam GetFilledRandomCSSPWQInputParam(string OmitPropName)
        {
            CSSPWQInputParam cSSPWQInputParam = new CSSPWQInputParam();

            if (OmitPropName != "CSSPWQInputType") cSSPWQInputParam.CSSPWQInputType = (CSSPWQInputTypeEnum)GetRandomEnumType(typeof(CSSPWQInputTypeEnum));
            if (OmitPropName != "Name") cSSPWQInputParam.Name = GetRandomString("", 6);
            if (OmitPropName != "TVItemID") cSSPWQInputParam.TVItemID = GetRandomInt(1, 11);

            return cSSPWQInputParam;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPWQInputParam_Testing()
        {

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
        #endregion Tests Generated
    }
}
