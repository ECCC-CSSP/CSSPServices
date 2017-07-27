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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class HydrometricDataValueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private HydrometricDataValueService hydrometricDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueTest() : base()
        {
            hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 1;
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Flow_m3_s") hydrometricDataValue.Flow_m3_s = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;

            return hydrometricDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void HydrometricDataValue_Testing()
        {

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

            hydrometricDataValueService.Add(hydrometricDataValue);
            if (hydrometricDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, hydrometricDataValueService.GetRead().Where(c => c == hydrometricDataValue).Any());
            hydrometricDataValueService.Update(hydrometricDataValue);
            if (hydrometricDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, hydrometricDataValueService.GetRead().Count());
            hydrometricDataValueService.Delete(hydrometricDataValue);
            if (hydrometricDataValue.ValidationResults.Count() > 0)
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

            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            hydrometricDataValue.HydrometricDataValueID = 0;
            hydrometricDataValueService.Update(hydrometricDataValue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHydrometricDataValueID), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "HydrometricSite", Plurial = "s", FieldID = "HydrometricSiteID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // hydrometricDataValue.HydrometricSiteID   (Int32)
            // -----------------------------------

            // HydrometricSiteID will automatically be initialized at 0 --> not null


            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            // HydrometricSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricDataValue.HydrometricSiteID = 1;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricDataValue.HydrometricSiteID = 2;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricDataValue.HydrometricSiteID = 0;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueHydrometricSiteID, "1")).Any());
            Assert.AreEqual(0, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricDataValue.DateTime_Local   (DateTime)
            // -----------------------------------

            // DateTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // hydrometricDataValue.Keep   (Boolean)
            // -----------------------------------

            // Keep will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // hydrometricDataValue.StorageDataType   (StorageDataTypeEnum)
            // -----------------------------------

            // StorageDataType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000)]
            // hydrometricDataValue.Flow_m3_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [Flow_m3_s]


            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            hydrometricDataValue.Flow_m3_s = 0.0D;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            hydrometricDataValue.Flow_m3_s = 1.0D;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            hydrometricDataValue.Flow_m3_s = -1.0D;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            hydrometricDataValue.Flow_m3_s = 10000.0D;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            hydrometricDataValue.Flow_m3_s = 9999.0D;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // Flow_m3_s has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            hydrometricDataValue.Flow_m3_s = 10001.0D;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, hydrometricDataValue.Flow_m3_s);
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // hydrometricDataValue.HourlyValues   (String)
            // -----------------------------------


            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // hydrometricDataValue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(count, hydrometricDataValueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // hydrometricDataValue.HydrometricSite   (HydrometricSite)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // hydrometricDataValue.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
