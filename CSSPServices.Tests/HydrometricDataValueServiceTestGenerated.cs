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

            // Need to implement (no items found, would need to add at least one in the TestDB) [HydrometricDataValue HydrometricSiteID HydrometricSite HydrometricSiteID]
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Flow_m3_s") hydrometricDataValue.Flow_m3_s = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            //Error: property [HydrometricDataValueWeb] and type [HydrometricDataValue] is  not implemented
            //Error: property [HydrometricDataValueReport] and type [HydrometricDataValue] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") hydrometricDataValue.HasErrors = true;

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
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);

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

                    //Error: Type not implemented [HydrometricDataValueWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // hydrometricDataValue.HydrometricDataValueReport   (HydrometricDataValueReport)
                    // -----------------------------------

                    //Error: Type not implemented [HydrometricDataValueReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

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
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in hydrometricDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    HydrometricDataValue hydrometricDataValueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
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

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (hydrometricDataValueRet.HydrometricDataValueWeb != null)
                            {
                                Assert.IsNull(hydrometricDataValueRet.HydrometricDataValueWeb);
                            }
                            if (hydrometricDataValueRet.HydrometricDataValueReport != null)
                            {
                                Assert.IsNull(hydrometricDataValueRet.HydrometricDataValueReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (hydrometricDataValueRet.HydrometricDataValueWeb != null)
                            {
                                Assert.IsNotNull(hydrometricDataValueRet.HydrometricDataValueWeb);
                            }
                            if (hydrometricDataValueRet.HydrometricDataValueReport != null)
                            {
                                Assert.IsNotNull(hydrometricDataValueRet.HydrometricDataValueReport);
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
