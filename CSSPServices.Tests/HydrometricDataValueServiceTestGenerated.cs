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

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 1;
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Flow_m3_s") hydrometricDataValue.Flow_m3_s = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") hydrometricDataValue.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "StorageDataTypeText") hydrometricDataValue.StorageDataTypeText = GetRandomString("", 5);
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHydrometricDataValueID), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.HydrometricDataValueID = 10000000;
                hydrometricDataValueService.Update(hydrometricDataValue);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricDataValue, ModelsRes.HydrometricDataValueHydrometricDataValueID, hydrometricDataValue.HydrometricDataValueID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = Error)]
                // hydrometricDataValue.HydrometricSiteID   (Int32)
                // -----------------------------------

                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.HydrometricSiteID = 0;
                hydrometricDataValueService.Add(hydrometricDataValue);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.HydrometricDataValueHydrometricSiteID, hydrometricDataValue.HydrometricSiteID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueStorageDataType), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.Flow_m3_s = 10001.0D;
                Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // hydrometricDataValue.HourlyValues   (String)
                // -----------------------------------


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
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.LastUpdateContactTVItemID = 1;
                hydrometricDataValueService.Add(hydrometricDataValue);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "Contact"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // hydrometricDataValue.LastUpdateContactTVText   (String)
                // -----------------------------------

                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVText, "200"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // hydrometricDataValue.StorageDataTypeText   (String)
                // -----------------------------------

                hydrometricDataValue = null;
                hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                hydrometricDataValue.StorageDataTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricDataValueStorageDataTypeText, "100"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

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
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void HydrometricDataValue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);
                HydrometricDataValue hydrometricDataValue = (from c in hydrometricDataValueService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(hydrometricDataValue);

                HydrometricDataValue hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                Assert.IsNotNull(hydrometricDataValueRet.HydrometricDataValueID);
                Assert.IsNotNull(hydrometricDataValueRet.HydrometricSiteID);
                Assert.IsNotNull(hydrometricDataValueRet.DateTime_Local);
                Assert.IsNotNull(hydrometricDataValueRet.Keep);
                Assert.IsNotNull(hydrometricDataValueRet.StorageDataType);
                Assert.IsNotNull(hydrometricDataValueRet.Flow_m3_s);
                if (hydrometricDataValueRet.HourlyValues != null)
                {
                   Assert.IsNotNull(hydrometricDataValueRet.HourlyValues);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.HourlyValues));
                }
                Assert.IsNotNull(hydrometricDataValueRet.LastUpdateDate_UTC);
                Assert.IsNotNull(hydrometricDataValueRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(hydrometricDataValueRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.LastUpdateContactTVText));
                Assert.IsNotNull(hydrometricDataValueRet.StorageDataTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueRet.StorageDataTypeText));
                Assert.IsNotNull(hydrometricDataValueRet.HasErrors);
            }
        }
        #endregion Tests Get With Key

    }
}
