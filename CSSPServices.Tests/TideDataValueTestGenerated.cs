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
    public partial class TideDataValueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TideDataValueID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideDataValue GetFilledRandomTideDataValue(string OmitPropName)
        {
            TideDataValueID += 1;

            TideDataValue tideDataValue = new TideDataValue();

            if (OmitPropName != "TideDataValueID") tideDataValue.TideDataValueID = TideDataValueID;
            if (OmitPropName != "TideSiteTVItemID") tideDataValue.TideSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "DateTime_Local") tideDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") tideDataValue.Keep = true;
            if (OmitPropName != "TideDataType") tideDataValue.TideDataType = (TideDataTypeEnum)GetRandomEnumType(typeof(TideDataTypeEnum));
            if (OmitPropName != "StorageDataType") tideDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Depth_m") tideDataValue.Depth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "UVelocity_m_s") tideDataValue.UVelocity_m_s = GetRandomFloat(-10, 10);
            if (OmitPropName != "VVelocity_m_s") tideDataValue.VVelocity_m_s = GetRandomFloat(-10, 10);
            if (OmitPropName != "TideStart") tideDataValue.TideStart = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "TideEnd") tideDataValue.TideEnd = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tideDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tideDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tideDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideDataValue_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            TideDataValueService tideDataValueService = new TideDataValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TideDataValue tideDataValue = GetFilledRandomTideDataValue("");
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(true, tideDataValueService.GetRead().Where(c => c == tideDataValue).Any());
            tideDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tideDataValueService.Update(tideDataValue));
            Assert.AreEqual(1, tideDataValueService.GetRead().Count());
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TideSiteTVItemID will automatically be initialized at 0 --> not null

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("DateTime_Local");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueDateTime_Local)).Any());
            Assert.IsTrue(tideDataValue.DateTime_Local.Year < 1900);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // Keep will automatically be initialized at false --> not null

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("TideDataType");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataType)).Any());
            Assert.AreEqual(TideDataTypeEnum.Error, tideDataValue.TideDataType);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("StorageDataType");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueStorageDataType)).Any());
            Assert.AreEqual(StorageDataTypeEnum.Error, tideDataValue.StorageDataType);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // Depth_m will automatically be initialized at 0.0f --> not null

            // UVelocity_m_s will automatically be initialized at 0.0f --> not null

            // VVelocity_m_s will automatically be initialized at 0.0f --> not null

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tideDataValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TideDataValueID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideSiteTVItemID] of type [int]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideDataValue.TideSiteTVItemID = 1;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideDataValue.TideSiteTVItemID = 2;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(2, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideDataValue.TideSiteTVItemID = 0;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueTideSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Keep] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideDataType] of type [TideDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [StorageDataType] of type [StorageDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Depth_m] of type [float]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // Depth_m has Min [0] and Max [1000]. At Min should return true and no errors
            tideDataValue.Depth_m = 0.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            tideDataValue.Depth_m = 1.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            tideDataValue.Depth_m = -1.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, tideDataValue.Depth_m);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max should return true and no errors
            tideDataValue.Depth_m = 1000.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1000.0f, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            tideDataValue.Depth_m = 999.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(999.0f, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            tideDataValue.Depth_m = 1001.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, tideDataValue.Depth_m);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [UVelocity_m_s] of type [float]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // UVelocity_m_s has Min [-10] and Max [10]. At Min should return true and no errors
            tideDataValue.UVelocity_m_s = -10.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(-10.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [-10] and Max [10]. At Min + 1 should return true and no errors
            tideDataValue.UVelocity_m_s = -9.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(-9.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [-10] and Max [10]. At Min - 1 should return false with one error
            tideDataValue.UVelocity_m_s = -11.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "-10", "10")).Any());
            Assert.AreEqual(-11.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [-10] and Max [10]. At Max should return true and no errors
            tideDataValue.UVelocity_m_s = 10.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(10.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [-10] and Max [10]. At Max - 1 should return true and no errors
            tideDataValue.UVelocity_m_s = 9.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(9.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [-10] and Max [10]. At Max + 1 should return false with one error
            tideDataValue.UVelocity_m_s = 11.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "-10", "10")).Any());
            Assert.AreEqual(11.0f, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [VVelocity_m_s] of type [float]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // VVelocity_m_s has Min [-10] and Max [10]. At Min should return true and no errors
            tideDataValue.VVelocity_m_s = -10.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(-10.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [-10] and Max [10]. At Min + 1 should return true and no errors
            tideDataValue.VVelocity_m_s = -9.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(-9.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [-10] and Max [10]. At Min - 1 should return false with one error
            tideDataValue.VVelocity_m_s = -11.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "-10", "10")).Any());
            Assert.AreEqual(-11.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [-10] and Max [10]. At Max should return true and no errors
            tideDataValue.VVelocity_m_s = 10.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(10.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [-10] and Max [10]. At Max - 1 should return true and no errors
            tideDataValue.VVelocity_m_s = 9.0f;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(9.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [-10] and Max [10]. At Max + 1 should return false with one error
            tideDataValue.VVelocity_m_s = 11.0f;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "-10", "10")).Any());
            Assert.AreEqual(11.0f, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [TideStart] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideEnd] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(2, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
