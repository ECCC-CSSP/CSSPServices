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
    public partial class AppTaskParameterServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskParameterService appTaskParameterService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskParameterServiceTest() : base()
        {
            //appTaskParameterService = new AppTaskParameterService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskParameter GetFilledRandomAppTaskParameter(string OmitPropName)
        {
            AppTaskParameter appTaskParameter = new AppTaskParameter();

            if (OmitPropName != "Name") appTaskParameter.Name = GetRandomString("", 5);
            if (OmitPropName != "Value") appTaskParameter.Value = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") appTaskParameter.HasErrors = true;

            return appTaskParameter;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTaskParameter_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskParameterService appTaskParameterService = new AppTaskParameterService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppTaskParameter appTaskParameter = GetFilledRandomAppTaskParameter("");

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

        #region Tests Generated Get List of AppTaskParameter
        #endregion Tests Get List of AppTaskParameter

    }
}
