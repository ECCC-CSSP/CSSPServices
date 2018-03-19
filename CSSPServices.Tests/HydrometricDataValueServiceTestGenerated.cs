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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 0;
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void HydrometricDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new GetParam(), dbTestDB, ContactID);

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

                    count = hydrometricDataValueService.GetRead().Count();

                    Assert.AreEqual(hydrometricDataValueService.GetRead().Count(), hydrometricDataValueService.GetEdit().Count());

                    hydrometricDataValueService.Add(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, hydrometricDataValueService.GetRead().Where(c => c == hydrometricDataValue).Any());
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, hydrometricDataValueService.GetRead().Count());
                    hydrometricDataValueService.Delete(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueHydrometricDataValueID), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueID = 10000000;
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricDataValue, CSSPModelsRes.HydrometricDataValueHydrometricDataValueID, hydrometricDataValue.HydrometricDataValueID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = Error)]
                    // hydrometricDataValue.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricSiteID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricSite, CSSPModelsRes.HydrometricDataValueHydrometricSiteID, hydrometricDataValue.HydrometricSiteID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueDateTime_Local), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricDataValueDateTime_Local, "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueStorageDataType), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Flow_m3_s = 10001.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // hydrometricDataValue.HourlyValues   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // hydrometricDataValue.HydrometricDataValueWeb   (HydrometricDataValueWeb)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueWeb = null;
                    Assert.IsNull(hydrometricDataValue.HydrometricDataValueWeb);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueWeb = new HydrometricDataValueWeb();
                    Assert.IsNotNull(hydrometricDataValue.HydrometricDataValueWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // hydrometricDataValue.HydrometricDataValueReport   (HydrometricDataValueReport)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueReport = null;
                    Assert.IsNull(hydrometricDataValue.HydrometricDataValueReport);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueReport = new HydrometricDataValueReport();
                    Assert.IsNotNull(hydrometricDataValue.HydrometricDataValueReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueLastUpdateDate_UTC), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricDataValueLastUpdateDate_UTC, "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // hydrometricDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.HydrometricDataValueLastUpdateContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 1;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "Contact"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void HydrometricDataValue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new GetParam(), dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in hydrometricDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    HydrometricDataValue hydrometricDataValueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, getParam);
                            Assert.IsNull(hydrometricDataValueRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // HydrometricDataValue fields
                        Assert.IsNotNull(hydrometricDataValueRet.HydrometricDataValueID);
                        Assert.IsNotNull(hydrometricDataValueRet.HydrometricSiteID);
                        Assert.IsNotNull(hydrometricDataValueRet.DateTime_Local);
                        Assert.IsNotNull(hydrometricDataValueRet.Keep);
                        Assert.IsNotNull(hydrometricDataValueRet.StorageDataType);
                        Assert.IsNotNull(hydrometricDataValueRet.Flow_m3_s);
                        if (hydrometricDataValueRet.HourlyValues != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HourlyValues));
                        }
                        Assert.IsNotNull(hydrometricDataValueRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(hydrometricDataValueRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // HydrometricDataValueWeb and HydrometricDataValueReport fields should be null here
                            Assert.IsNull(hydrometricDataValueRet.HydrometricDataValueWeb);
                            Assert.IsNull(hydrometricDataValueRet.HydrometricDataValueReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // HydrometricDataValueWeb fields should not be null and HydrometricDataValueReport fields should be null here
                            if (hydrometricDataValueRet.HydrometricDataValueWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HydrometricDataValueWeb.LastUpdateContactTVText));
                            }
                            if (hydrometricDataValueRet.HydrometricDataValueWeb.StorageDataTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HydrometricDataValueWeb.StorageDataTypeText));
                            }
                            Assert.IsNull(hydrometricDataValueRet.HydrometricDataValueReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // HydrometricDataValueWeb and HydrometricDataValueReport fields should NOT be null here
                            if (hydrometricDataValueRet.HydrometricDataValueWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HydrometricDataValueWeb.LastUpdateContactTVText));
                            }
                            if (hydrometricDataValueRet.HydrometricDataValueWeb.StorageDataTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HydrometricDataValueWeb.StorageDataTypeText));
                            }
                            if (hydrometricDataValueRet.HydrometricDataValueReport.HydrometricDataValueReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HydrometricDataValueReport.HydrometricDataValueReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of HydrometricDataValue
        #endregion Tests Get List of HydrometricDataValue

    }
}
