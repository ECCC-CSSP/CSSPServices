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
        private int HydrometricDataValueID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            HydrometricDataValueID += 1;

            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricDataValueID") hydrometricDataValue.HydrometricDataValueID = HydrometricDataValueID;
            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = GetRandomInt(1, 11);
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Flow_m3_s") hydrometricDataValue.Flow_m3_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return hydrometricDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void HydrometricDataValue_Testing()
        {
            SetupTestHelper(culture);
            HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            HydrometricDataValue hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(true, hydrometricDataValueService.GetRead().Where(c => c == hydrometricDataValue).Any());
            hydrometricDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, hydrometricDataValueService.Update(hydrometricDataValue));
            Assert.AreEqual(1, hydrometricDataValueService.GetRead().Count());
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // HydrometricSiteID will automatically be initialized at 0 --> not null

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("DateTime_Local");
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(1, hydrometricDataValue.ValidationResults.Count());
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueDateTime_Local)).Any());
            Assert.IsTrue(hydrometricDataValue.DateTime_Local.Year < 1900);
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            // Keep will automatically be initialized at 0 --> not null

            //Error: Type not implemented [StorageDataType]

            //Error: Type not implemented [Flow_m3_s]

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("HourlyValues");
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(1, hydrometricDataValue.ValidationResults.Count());
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHourlyValues)).Any());
            Assert.AreEqual(null, hydrometricDataValue.HourlyValues);
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(1, hydrometricDataValue.ValidationResults.Count());
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(hydrometricDataValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [HydrometricSite]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [HydrometricDataValueID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSiteID] of type [Int32]
            //-----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            // HydrometricSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricDataValue.HydrometricSiteID = 1;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricDataValue.HydrometricSiteID = 2;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricDataValue.HydrometricSiteID = 0;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueHydrometricSiteID, "1")).Any());
            Assert.AreEqual(0, hydrometricDataValue.HydrometricSiteID);
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Keep] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [StorageDataType] of type [StorageDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Flow_m3_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyValues] of type [String]
            //-----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            hydrometricDataValue = null;
            hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValue.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricDataValueService.Delete(hydrometricDataValue));
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
            Assert.IsTrue(hydrometricDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, hydrometricDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [HydrometricSite] of type [HydrometricSite]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
