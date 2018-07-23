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
    public partial class GetParamServiceTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Functions Test 
        [TestMethod]
        public void GetParamService_Constructor_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                    Assert.AreEqual(null, getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);
                }
            }
        }
        [TestMethod]
        public void GetParamService_FillProp_Good_Test()
        {
            string lang;
            int skip;
            int take;
            string orderByName;
            string where;
            EntityQueryDetailTypeEnum entityQueryDetailType;
            EntityQueryTypeEnum entityQueryType;

            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                    // FillProp empty
                    GetParam getParam = new GetParam();
                    getParamService.GetParam = getParamService.FillProp(typeof(Address));

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp lang = "fr"
                    getParam = new GetParam();
                    lang = "fr";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), lang: lang);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.fr, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp skip = 1
                    getParam = new GetParam();
                    skip = 1;
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), skip: skip);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(1, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp take = 2
                    getParam = new GetParam();
                    take = 2;
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), take: take);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(2, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp Order = "Bonjour,Testing,Allo"
                    getParam = new GetParam();
                    orderByName = "AddressID,StreetType,StreetNumber,StreetName";
                    getParamService.GetParam = getParamService.FillProp(modelType: typeof(Address), Order: orderByName);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual(orderByName, getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(4, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.OrderList[0]);
                    Assert.AreEqual("StreetType", getParamService.GetParam.OrderList[1]);
                    Assert.AreEqual("StreetNumber", getParamService.GetParam.OrderList[2]);
                    Assert.AreEqual("StreetName", getParamService.GetParam.OrderList[3]);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp Order = "Bonjour,Testing,Allo" with spaces
                    getParam = new GetParam();
                    orderByName = "AddressID, StreetType, StreetNumber ,StreetName";
                    getParamService.GetParam = getParamService.FillProp(modelType: typeof(Address), Order: orderByName);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual(orderByName, getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(4, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.OrderList[0]);
                    Assert.AreEqual("StreetType", getParamService.GetParam.OrderList[1]);
                    Assert.AreEqual("StreetNumber", getParamService.GetParam.OrderList[2]);
                    Assert.AreEqual("StreetName", getParamService.GetParam.OrderList[3]);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp where = "Bonjour,EQ,4|Testing,LT,Allo"
                    getParam = new GetParam();
                    where = "AddressID,LT,400|StreetType,EQ,Rouge";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(2, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetType", getParamService.GetParam.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", getParamService.GetParam.WhereInfoList[1].Value);

                    // FillProp where = "Bonjour,EQ,4|Testing,LT,Allo" with spaces
                    getParam = new GetParam();
                    where = "AddressID, LT, 400 | StreetName, EQ, Rouge";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(2, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.LessThan, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("400", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetName", getParamService.GetParam.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Rouge", getParamService.GetParam.WhereInfoList[1].Value);

                    // FillProp where = "AddressID,EQ,4" - System.Int32
                    getParam = new GetParam();
                    where = "AddressID,EQ,4";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("4", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(4, getParamService.GetParam.WhereInfoList[0].ValueInt);

                    // FillProp where = "FixLength,EQ,true" - System.Boolean
                    getParam = new GetParam();
                    where = "FixLength,EQ,true";
                    getParamService.GetParam = getParamService.FillProp(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("FixLength", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("true", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(true, getParamService.GetParam.WhereInfoList[0].ValueBool);

                    // FillProp where = "LastUpdateDate_UTC,EQ,2018-04-05" - System.DateTime
                    getParam = new GetParam();
                    where = "LastUpdateDate_UTC,EQ,2018-04-05";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5), getParamService.GetParam.WhereInfoList[0].ValueDateTime);

                    // FillProp where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z" - System.DateTime
                    getParam = new GetParam();
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34Z"; // the Z designate the GMT time zone
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34Z", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34).ToLocalTime(), getParamService.GetParam.WhereInfoList[0].ValueDateTime);

                    // FillProp where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34" - System.DateTime
                    getParam = new GetParam();
                    where = "LastUpdateDate_UTC,EQ,2018-04-05 06:45:34"; // without the Z designate the local time zone
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("LastUpdateDate_UTC", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2018-04-05 06:45:34", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(new DateTime(2018, 4, 5, 6, 45, 34), getParamService.GetParam.WhereInfoList[0].ValueDateTime);

                    // FillProp where = "Radius_m,EQ,23.34" - System.Double
                    getParam = new GetParam();
                    where = "Radius_m,EQ,23.3";
                    getParamService.GetParam = getParamService.FillProp(typeof(BoxModelResult), where: where);

                    Assert.AreEqual(typeof(BoxModelResult), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("Radius_m", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("23.3", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual(23.3D, getParamService.GetParam.WhereInfoList[0].ValueDouble);

                    // FillProp where = "StreetType,EQ,Road" - Enumeration with text
                    getParam = new GetParam();
                    where = "StreetType,EQ,Road";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("Road", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, getParamService.GetParam.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), getParamService.GetParam.WhereInfoList[0].ValueEnumText);

                    // FillProp where = "StreetType,EQ,Road" - Enumeration with number
                    getParam = new GetParam();
                    where = "StreetType,EQ,2";
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(1, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("StreetType", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("2", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual((int)StreetTypeEnum.Road, getParamService.GetParam.WhereInfoList[0].ValueInt);
                    Assert.AreEqual(StreetTypeEnum.Road.ToString(), getParamService.GetParam.WhereInfoList[0].ValueEnumText);

                    // FillProp entityQueryDetailType = EntityQueryDetailTypeEnum.EntityReport
                    getParam = new GetParam();
                    entityQueryDetailType = EntityQueryDetailTypeEnum.EntityReport;
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), EntityQueryDetailType: entityQueryDetailType);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityReport, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.AsNoTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp entityQueryType = EntityQueryTypeEnum.WithTracking
                    getParam = new GetParam();
                    entityQueryType = EntityQueryTypeEnum.WithTracking;
                    getParamService.GetParam = getParamService.FillProp(typeof(Address), EntityQueryType: entityQueryType);

                    Assert.AreEqual(typeof(Address), getParamService.GetParam.ModelType);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);
                    Assert.AreEqual(0, getParamService.GetParam.Skip);
                    Assert.AreEqual(100, getParamService.GetParam.Take);
                    Assert.AreEqual("", getParamService.GetParam.Order);
                    Assert.AreEqual("", getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityOnly, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.WithTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(0, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual(0, getParamService.GetParam.WhereInfoList.Count);

                    // FillProp all
                    getParam = new GetParam();
                    lang = "fr";
                    skip = 2;
                    take = 4;
                    orderByName = "AddressID,StreetName,StreetNumber";
                    where = "AddressID,GT,4|StreetName,EQ,Allo";
                    entityQueryDetailType = EntityQueryDetailTypeEnum.EntityReport;
                    entityQueryType = EntityQueryTypeEnum.WithTracking;

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), lang, skip, take, orderByName, where, entityQueryDetailType, entityQueryType);

                    Assert.AreEqual(LanguageEnum.fr, getParamService.GetParam.Language);
                    Assert.AreEqual(2, getParamService.GetParam.Skip);
                    Assert.AreEqual(4, getParamService.GetParam.Take);
                    Assert.AreEqual(orderByName, getParamService.GetParam.Order);
                    Assert.AreEqual(where, getParamService.GetParam.Where);
                    Assert.AreEqual(EntityQueryDetailTypeEnum.EntityReport, getParamService.GetParam.EntityQueryDetailType);
                    Assert.AreEqual(EntityQueryTypeEnum.WithTracking, getParamService.GetParam.EntityQueryType);
                    Assert.AreEqual(3, getParamService.GetParam.OrderList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.OrderList[0]);
                    Assert.AreEqual("StreetName", getParamService.GetParam.OrderList[1]);
                    Assert.AreEqual("StreetNumber", getParamService.GetParam.OrderList[2]);
                    Assert.AreEqual(2, getParamService.GetParam.WhereInfoList.Count);
                    Assert.AreEqual("AddressID", getParamService.GetParam.WhereInfoList[0].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.GreaterThan, getParamService.GetParam.WhereInfoList[0].WhereOperator);
                    Assert.AreEqual("4", getParamService.GetParam.WhereInfoList[0].Value);
                    Assert.AreEqual("StreetName", getParamService.GetParam.WhereInfoList[1].PropertyName);
                    Assert.AreEqual(WhereOperatorEnum.Equal, getParamService.GetParam.WhereInfoList[1].WhereOperator);
                    Assert.AreEqual("Allo", getParamService.GetParam.WhereInfoList[1].Value);
                }
            }
        }
        [TestMethod]
        public void GetParamService_FillProp_Bad_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                    // Testing ErrorMessage for ModelType == null
                    getParamService.GetParam = getParamService.FillProp(null);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldNotBeNullOrEmpty, "ModelType"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Lang == es
                    string lang = "es";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), lang: lang);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(CSSPServicesRes.AllowableLanguagesAreFRAndEN, getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(LanguageEnum.en, getParamService.GetParam.Language);

                    // Testing ErrorMessage for Skip < 0
                    int skip = -1;

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), skip: skip);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeAbove_, "Skip", "0"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Take > 1000000
                    int take = 1000001;

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), take: take);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._ShouldBeBelow_, "Take", "1000000"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order 
                    string Order = "AddressID_Not";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), Order: Order);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames
                    Order = "AddressID,StreetName,AddressID_Not";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), Order: Order);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for Order with multiple PropertyNames with space
                     Order = "AddressID, StreetName, AddressID_Not";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), Order: Order);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._DoesNotExistForModelType_, "AddressID_Not", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                     string where = "aAddressID,GT,4,eifj";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where 
                     where = "aAddressID,GT,";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  with spaces
                    where = "aAddressID, GT,4,eifj";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedToHaveValidStringFormatEx_, "Where", "TVItemID,GT,5|TVItemID,LT,20"), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where _NeedsToBeANumberFor_ForModel
                    where = "AddressID,GT,aStringButShouldBeANumber";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "aStringButShouldBeANumber", "AddressID", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeTrueOrFalseFor_OfModel_
                    where = "FixLength,EQ,falseNot";

                    getParamService.GetParam = getParamService.FillProp(typeof(BoxModelResult), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeTrueOrFalseFor_OfModel_, "falseNot", "FixLength", typeof(BoxModelResult).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeADateFor_OfModel_
                    where = "LastUpdateDate_UTC,EQ,2018-04-05Not";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeADateFor_OfModel_, "2018-04-05Not", "LastUpdateDate_UTC", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeANumberFor_OfModel_
                    where = "StreetType,EQ,2NotANumber";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeANumberFor_OfModel_, "2NotANumber", "StreetType", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                    where = "StreetType,EQ,2222";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumNumberFor_OfModel_, "2222", "StreetType", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);

                    // Testing ErrorMessage for where  _NeedsToBeAValidEnumNumberFor_OfModel_
                     where = "StreetType,EQ,NotAnOption";

                    getParamService.GetParam = getParamService.FillProp(typeof(Address), where: where);

                    Assert.IsTrue(getParamService.GetParam.HasErrors);
                    Assert.AreEqual(string.Format(CSSPServicesRes._NeedsToBeAValidEnumTextFor_OfModel_, "NotAnOption", "StreetType", typeof(Address).Name), getParamService.GetParam.ValidationResults.FirstOrDefault().ErrorMessage);
                }
            }
        }
        #endregion Functions Test
    }
}
