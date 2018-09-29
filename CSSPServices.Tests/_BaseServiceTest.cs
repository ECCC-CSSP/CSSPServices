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
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    // Variables
                    Assert.AreEqual(@"E:\inetpub\wwwroot\cssp\App_Data\", baseService.BasePath);
                    Assert.AreEqual(6378137.0D, baseService.R);
                    Assert.AreEqual(Math.PI / 180.0D, baseService.d2r);
                    Assert.AreEqual(180.0D / Math.PI, baseService.r2d);

                    // Properties
                    Assert.AreEqual(dbTestDB, baseService.db);
                    Assert.AreEqual(true, baseService.CanSendEmail);
                    Assert.AreEqual(ContactID, baseService.ContactID);
                    Assert.AreEqual("ec.pccsm-cssp.ec@canada.ca", baseService.FromEmail);
                    Assert.AreEqual(LanguageEnum.en, baseService.LanguageRequest);
                    Assert.AreEqual(new CultureInfo("en-CA"), Thread.CurrentThread.CurrentCulture);
                    Assert.AreEqual(new CultureInfo("en-CA"), Thread.CurrentThread.CurrentUICulture);
                }
            }
        }
        [TestMethod]
        public void BaseService_FillQuery_Good_Test()
        {
            string lang;
            int skip;
            int take;
            string orderByName;
            string where;
            string detail;

            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // FillQuery empty
                    baseService.Query = baseService.FillQuery(typeof(Address));

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery lang = "fr"
                    lang = "fr";
                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.fr, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery skip = 1
                    skip = 1;
                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(1, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery take = 2
                    take = 2;
                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(2, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Order = "Bonjour,Testing,Allo"
                    orderByName = "AddressID,StreetType,StreetNumber,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), order: orderByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(orderByName, baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(4, baseService.Query.OrderList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.OrderList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.OrderList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.OrderList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.OrderList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery Order = "Bonjour,Testing,Allo" with spaces
                    orderByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    baseService.Query = baseService.FillQuery(modelType: typeof(Address), order: orderByName);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual(orderByName, baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(4, baseService.Query.OrderList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.OrderList[0]);
                    Assert.AreEqual("StreetType", baseService.Query.OrderList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.OrderList[2]);
                    Assert.AreEqual("StreetName", baseService.Query.OrderList[3]);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery where = "Bonjour,EQ,4|Testing,LT,Allo"
                    where = "AddressID,LT,400|StreetType,EQ,Rouge";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(2, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "Bonjour,EQ,4|Testing,LT,Allo" with spaces
                    where = "AddressID, LT, 400 | StreetName, EQ, Rouge";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(2, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetName", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", baseService.Query.WhereInfoList[1].Value);

                    // FillQuery where = "AddressID,EQ,4" - System.Int32
                    where = "AddressID,EQ,4";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("4", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(4, baseService.Query.WhereInfoList[0].ValueInt);

                    // FillQuery where = "FixLength,EQ,true" - System.Boolean
                    where = "FixLength,EQ,true";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("FixLength", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("true", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(true, baseService.Query.WhereInfoList[0].ValueBool);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z"; // the Z designate the GMT time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34Z", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34).ToLocalTime(), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34" - System.DateTime
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34"; // without the Z designate the local time zone
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34), baseService.Query.WhereInfoList[0].ValueDateTime);

                    // FillQuery where = "Radius_m,EQ,23.34" - System.Double
                    where = "Radius_m,EQ,23.3";
                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("Radius_m", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("23.3", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual(23.3D, baseService.Query.WhereInfoList[0].ValueDouble);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with text
                    where = "StreetType,EQ,Road";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("Road", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);

                    // FillQuery where = "StreetType,EQ,Road" - Enumeration with number
                    where = "StreetType,EQ,2";
                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(1, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, baseService.Query.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), baseService.Query.WhereInfoList[0].ValueEnumText);

                    // FillQuery entityQueryDetailType = EntityQueryDetailTypeEnum.EntityReport
                    detail = "A";
                    baseService.Query = baseService.FillQuery(typeof(Address), detail: detail);

                    Assert.AreEqual(typeof(Address), baseService.Query.ModelType);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);
                    Assert.AreEqual(0, baseService.Query.Skip);
                    Assert.AreEqual(200, baseService.Query.Take);
                    Assert.AreEqual("", baseService.Query.Order);
                    Assert.AreEqual("", baseService.Query.Where);
                    Assert.AreEqual("A", baseService.Query.Detail);
                    Assert.AreEqual(0, baseService.Query.OrderList.Count);
                    Assert.AreEqual(0, baseService.Query.WhereInfoList.Count);

                    // FillQuery all
                    lang = "fr";
                    skip = 2;
                    take = 4;
                    orderByName = "AddressID,StreetName,StreetNumber";
                    where = "AddressID,GT,4|StreetName,EQ,Allo";
                    detail = "B";

                    baseService.Query = baseService.FillQuery(typeof(Address), lang, skip, take, orderByName, where, detail);

                    Assert.AreEqual(LanguageEnum.fr, baseService.Query.Language);
                    Assert.AreEqual(2, baseService.Query.Skip);
                    Assert.AreEqual(4, baseService.Query.Take);
                    Assert.AreEqual(orderByName, baseService.Query.Order);
                    Assert.AreEqual(where, baseService.Query.Where);
                    Assert.AreEqual("B", baseService.Query.Detail);
                    Assert.AreEqual(3, baseService.Query.OrderList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.OrderList[0]);
                    Assert.AreEqual("StreetName", baseService.Query.OrderList[1]);
                    Assert.AreEqual("StreetNumber", baseService.Query.OrderList[2]);
                    Assert.AreEqual(2, baseService.Query.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", baseService.Query.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.GreaterThan, baseService.Query.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("4", baseService.Query.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetName", baseService.Query.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, baseService.Query.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Allo", baseService.Query.WhereInfoList[1].Value);
                }
            }
        }
        [TestMethod]
        public void BaseService_FillQuery_Bad_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BaseService baseService = new BaseService(new Query(), dbTestDB, ContactID);

                    // Testing ErrorMessage for ModelType == null
                    baseService.Query = baseService.FillQuery(null);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldNotBeNullOrEmpty, "ModelType"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Lang == es
                    string lang = "es";

                    baseService.Query = baseService.FillQuery(typeof(Address), lang: lang);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(CSSPServicesRes.AllowableLanguagesAreFRAndEN, baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(LanguageEnum.en, baseService.Query.Language);

                    // Testing ErrorMessage for Skip < 0
                    int skip = -1;

                    baseService.Query = baseService.FillQuery(typeof(Address), skip: skip);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeAbove_, "Skip", "0"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take > 1000000
                    int take = 1000001;

                    baseService.Query = baseService.FillQuery(typeof(Address), take: take);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeBelow_, "Take", "1000000"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order 
                    string Order = "AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), order: Order);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Order = "AddressID,StreetName,AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), order: Order);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                    Order = "AddressID, StreetName, AddressID_Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), order: Order);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    string where = "aAddressID,GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                    where = "aAddressID,GT,";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  with spaces
                    where = "aAddressID, GT,4,eifj";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel
                    where = "AddressID,GT,aStringButShouldBeANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "AddressID", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeTrueOrFalseFor_OfModel_
                    where = "FixLength,EQ,falseNot";

                    baseService.Query = baseService.FillQuery(typeof(BoxModelResult), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeTrueOrFalseFor_OfModel_, "falseNot", "FixLength", typeof(BoxModelResult).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeADateFor_OfModel_
                    where = "LastUpdateDate_UTC,EQ,2018-04-05Not";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeADateFor_OfModel_, "2018-04-05Not", "LastUpdateDate_UTC", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeANumberFor_OfModel_
                    where = "StreetType,EQ,2NotANumber";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "2NotANumber", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,2222";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumNumberFor_OfModel_, "2222", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,NotAnOption";

                    baseService.Query = baseService.FillQuery(typeof(Address), where: where);

                    Assert.IsTrue(baseService.Query.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumTextFor_OfModel_, "NotAnOption", "StreetType", typeof(Address).Name), baseService.Query.ValidationResults.FirstOrDefault().ErrorMessage);
                }
            }
        }
        #endregion Tests Functions public
    }
}
