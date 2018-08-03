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

        #region Functions private
        private AppTaskParameter GetFilledRandomAppTaskParameter(string OmitPropName)
        {
            AppTaskParameter appTaskParameter = new AppTaskParameter();

            if (OmitPropName != "Name") appTaskParameter.Name = GetRandomString("", 5);
            if (OmitPropName != "Value") appTaskParameter.Value = GetRandomString("", 5);

            return appTaskParameter;
        }
        #endregion Functions private
    }
}
