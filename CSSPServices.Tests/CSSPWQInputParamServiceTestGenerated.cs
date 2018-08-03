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

        #region Functions private
        private CSSPWQInputParam GetFilledRandomCSSPWQInputParam(string OmitPropName)
        {
            CSSPWQInputParam cSSPWQInputParam = new CSSPWQInputParam();

            if (OmitPropName != "CSSPWQInputType") cSSPWQInputParam.CSSPWQInputType = (CSSPWQInputTypeEnum)GetRandomEnumType(typeof(CSSPWQInputTypeEnum));
            if (OmitPropName != "Name") cSSPWQInputParam.Name = GetRandomString("", 6);
            if (OmitPropName != "TVItemID") cSSPWQInputParam.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "CSSPWQInputTypeText") cSSPWQInputParam.CSSPWQInputTypeText = GetRandomString("", 5);
            if (OmitPropName != "sidList") cSSPWQInputParam.sidList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            if (OmitPropName != "MWQMSiteList") cSSPWQInputParam.MWQMSiteList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            // should implement a Range for the property MWQMSiteTVItemIDList and type CSSPWQInputParam
            if (OmitPropName != "DailyDuplicateMWQMSiteList") cSSPWQInputParam.DailyDuplicateMWQMSiteList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            // should implement a Range for the property DailyDuplicateMWQMSiteTVItemIDList and type CSSPWQInputParam
            if (OmitPropName != "InfrastructureList") cSSPWQInputParam.InfrastructureList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };
            // should implement a Range for the property InfrastructureTVItemIDList and type CSSPWQInputParam

            return cSSPWQInputParam;
        }
        #endregion Functions private
    }
}
