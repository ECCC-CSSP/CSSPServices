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
    public partial class HydrometricDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private HydrometricDataValueService hydrometricDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueServiceTest() : base()
        {
            //hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void HydrometricDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    HydrometricDataValue hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = hydrometricDataValueService.GetHydrometricDataValueList().Count();

                    Assert.AreEqual(hydrometricDataValueService.GetHydrometricDataValueList().Count(), (from c in dbTestDB.HydrometricDataValues select c).Take(200).Count());

                    hydrometricDataValueService.Add(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, hydrometricDataValueService.GetHydrometricDataValueList().Where(c => c == hydrometricDataValue).Any());
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValueService.Delete(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // hydrometricDataValue.HydrometricDataValueID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueID = 0;
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueHydrometricDataValueID"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueID = 10000000;
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueHydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
                    // hydrometricDataValue.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricSiteID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricDataValueHydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueDateTime_Local"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueDateTime_Local", "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // hydrometricDataValue.Keep   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // hydrometricDataValue.StorageDataType   (StorageDataTypeEnum)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueStorageDataType"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // hydrometricDataValue.Flow_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Flow_m3_s]

                    //Error: Type not implemented [Flow_m3_s]

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Flow_m3_s = -1.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueFlow_m3_s", "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Flow_m3_s = 10001.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueFlow_m3_s", "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // hydrometricDataValue.HourlyValues   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueLastUpdateDate_UTC"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueLastUpdateDate_UTC", "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // hydrometricDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricDataValueLastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 1;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricDataValueLastUpdateContactTVItemID", "Contact"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricDataValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID)
        [TestMethod]
        public void GetHydrometricDataValueWithHydrometricDataValueID__hydrometricDataValue_HydrometricDataValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in dbTestDB.HydrometricDataValues select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        hydrometricDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            HydrometricDataValue hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueFields(new List<HydrometricDataValue>() { hydrometricDataValueRet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            HydrometricDataValueWeb hydrometricDataValueWebRet = hydrometricDataValueService.GetHydrometricDataValueWebWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueWebFields(new List<HydrometricDataValueWeb>() { hydrometricDataValueWebRet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueWebRet.HydrometricDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            HydrometricDataValueReport hydrometricDataValueReportRet = hydrometricDataValueService.GetHydrometricDataValueReportWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueReportFields(new List<HydrometricDataValueReport>() { hydrometricDataValueReportRet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueReportRet.HydrometricDataValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID)

        #region Tests Generated for GetHydrometricDataValueList()
        [TestMethod]
        public void GetHydrometricDataValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in dbTestDB.HydrometricDataValues select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                    hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        hydrometricDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList()

        #region Tests Generated for GetHydrometricDataValueList() Skip Take
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1,  "HydrometricDataValueID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order

        #region Tests Generated for GetHydrometricDataValueList() Skip Take 2Order
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1, "HydrometricDataValueID,HydrometricSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).OrderBy(c => c.HydrometricDataValueID).ThenBy(c => c.HydrometricSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take 2Order

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order Where
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricDataValueID", "HydrometricDataValueID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == 4).Skip(0).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order Where

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricDataValueID", "HydrometricDataValueID,GT,2|HydrometricDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID > 2 && c.HydrometricDataValueID < 5).Skip(0).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order 2Where

        #region Tests Generated for GetHydrometricDataValueList() 2Where
        [TestMethod]
        public void GetHydrometricDataValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "HydrometricDataValueID,GT,2|HydrometricDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID > 2 && c.HydrometricDataValueID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<HydrometricDataValueWeb> hydrometricDataValueWebList = new List<HydrometricDataValueWeb>();
                            hydrometricDataValueWebList = hydrometricDataValueService.GetHydrometricDataValueWebList().ToList();
                            CheckHydrometricDataValueWebFields(hydrometricDataValueWebList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueWebList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<HydrometricDataValueReport> hydrometricDataValueReportList = new List<HydrometricDataValueReport>();
                            hydrometricDataValueReportList = hydrometricDataValueService.GetHydrometricDataValueReportList().ToList();
                            CheckHydrometricDataValueReportFields(hydrometricDataValueReportList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueReportList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() 2Where

        #region Functions private
        private void CheckHydrometricDataValueFields(List<HydrometricDataValue> hydrometricDataValueList)
        {
            Assert.IsNotNull(hydrometricDataValueList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueList[0].Flow_m3_s);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueList[0].HasErrors);
        }
        private void CheckHydrometricDataValueWebFields(List<HydrometricDataValueWeb> hydrometricDataValueWebList)
        {
            Assert.IsNotNull(hydrometricDataValueWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueWebList[0].StorageDataTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueWebList[0].StorageDataTypeText));
            }
            Assert.IsNotNull(hydrometricDataValueWebList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueWebList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueWebList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueWebList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueWebList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueWebList[0].Flow_m3_s);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueWebList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueWebList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueWebList[0].HasErrors);
        }
        private void CheckHydrometricDataValueReportFields(List<HydrometricDataValueReport> hydrometricDataValueReportList)
        {
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].HydrometricDataValueReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].HydrometricDataValueReportTest));
            }
            Assert.IsNotNull(hydrometricDataValueReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].StorageDataTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].StorageDataTypeText));
            }
            Assert.IsNotNull(hydrometricDataValueReportList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueReportList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueReportList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueReportList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueReportList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueReportList[0].Flow_m3_s);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueReportList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueReportList[0].HasErrors);
        }
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 1;
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Flow_m3_s") hydrometricDataValue.Flow_m3_s = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;

            return hydrometricDataValue;
        }
        #endregion Functions private
    }
}
