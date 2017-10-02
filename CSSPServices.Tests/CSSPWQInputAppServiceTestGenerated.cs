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
    public partial class CSSPWQInputAppServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private CSSPWQInputAppService cSSPWQInputAppService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputAppServiceTest() : base()
        {
            //cSSPWQInputAppService = new CSSPWQInputAppService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPWQInputApp GetFilledRandomCSSPWQInputApp(string OmitPropName)
        {
            CSSPWQInputApp cSSPWQInputApp = new CSSPWQInputApp();

            if (OmitPropName != "AccessCode") cSSPWQInputApp.AccessCode = GetRandomString("", 6);
            if (OmitPropName != "ActiveYear") cSSPWQInputApp.ActiveYear = GetRandomString("", 4);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") cSSPWQInputApp.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") cSSPWQInputApp.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") cSSPWQInputApp.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") cSSPWQInputApp.ApprovalCode = GetRandomString("", 6);
            if (OmitPropName != "ApprovalDate") cSSPWQInputApp.ApprovalDate = new DateTime(2005, 3, 6);

            return cSSPWQInputApp;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void CSSPWQInputApp_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    CSSPWQInputAppService cSSPWQInputAppService = new CSSPWQInputAppService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    CSSPWQInputApp cSSPWQInputApp = GetFilledRandomCSSPWQInputApp("");

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

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

        #region Tests Generated Get List of CSSPWQInputApp
        #endregion Tests Get List of CSSPWQInputApp

    }
}
