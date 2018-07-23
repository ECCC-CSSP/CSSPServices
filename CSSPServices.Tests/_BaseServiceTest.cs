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
using System.Threading;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class _BaseServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public _BaseServiceTest() : base()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Tests Functions public
        [TestMethod]
        public void _BaseService_Constructor_Test()
        {
            using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                GetParam getParam = new GetParam();
                BaseService baseService = new BaseService(getParam, dbTestDB, ContactID);

                // Variables
                Assert.AreEqual(@"E:\inetpub\wwwroot\csspwebtools\App_Data\", baseService.BasePath);
                Assert.AreEqual(6378137.0D, baseService.R);
                Assert.AreEqual(Math.PI / 180.0D, baseService.d2r);
                Assert.AreEqual(180.0D / Math.PI, baseService.r2d);

                // Properties
                Assert.AreEqual(dbTestDB, baseService.db);
                Assert.AreEqual(true, baseService.CanSendEmail);
                Assert.AreEqual(ContactID, baseService.ContactID);
                Assert.AreEqual("ec.pccsm-cssp.ec@canada.ca", baseService.FromEmail);
                Assert.AreEqual(LanguageEnum.en, baseService.LanguageRequest);
                Assert.AreEqual(getParam, baseService.GetParam);
                Assert.AreEqual(LanguageEnum.en, baseService.GetParam.Language);
                Assert.AreEqual(0, baseService.GetParam.Skip);
                Assert.AreEqual(100, baseService.GetParam.Take);
                Assert.AreEqual("", baseService.GetParam.Order);
                Assert.AreEqual("", baseService.GetParam.Where);
                Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, baseService.GetParam.EntityQueryDetailType);
                Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, baseService.GetParam.EntityQueryType);
                Assert.AreEqual(new CultureInfo("en-CA"), Thread.CurrentThread.CurrentCulture);
                Assert.AreEqual(new CultureInfo("en-CA"), Thread.CurrentThread.CurrentUICulture);
            }
        }
        #endregion Tests Functions public
    }
}
