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
    public partial class MWQMSubsectorTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSubsectorID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsectorID += 1;

            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorID") mwqmSubsector.MWQMSubsectorID = MWQMSubsectorID;
            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "RainDay0Limit") mwqmSubsector.RainDay0Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay1Limit") mwqmSubsector.RainDay1Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay2Limit") mwqmSubsector.RainDay2Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay3Limit") mwqmSubsector.RainDay3Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay4Limit") mwqmSubsector.RainDay4Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay5Limit") mwqmSubsector.RainDay5Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay6Limit") mwqmSubsector.RainDay6Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay7Limit") mwqmSubsector.RainDay7Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay8Limit") mwqmSubsector.RainDay8Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay9Limit") mwqmSubsector.RainDay9Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay10Limit") mwqmSubsector.RainDay10Limit = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IncludeRainStartDate") mwqmSubsector.IncludeRainStartDate = GetRandomDateTime();
            if (OmitPropName != "IncludeRainEndDate") mwqmSubsector.IncludeRainEndDate = GetRandomDateTime();
            if (OmitPropName != "IncludeRainRunCount") mwqmSubsector.IncludeRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "IncludeRainSelectFullYear") mwqmSubsector.IncludeRainSelectFullYear = true;
            if (OmitPropName != "NoRainStartDate") mwqmSubsector.NoRainStartDate = GetRandomDateTime();
            if (OmitPropName != "NoRainEndDate") mwqmSubsector.NoRainEndDate = GetRandomDateTime();
            if (OmitPropName != "NoRainRunCount") mwqmSubsector.NoRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "NoRainSelectFullYear") mwqmSubsector.NoRainSelectFullYear = true;
            if (OmitPropName != "OnlyRainStartDate") mwqmSubsector.OnlyRainStartDate = GetRandomDateTime();
            if (OmitPropName != "OnlyRainEndDate") mwqmSubsector.OnlyRainEndDate = GetRandomDateTime();
            if (OmitPropName != "OnlyRainRunCount") mwqmSubsector.OnlyRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "OnlyRainSelectFullYear") mwqmSubsector.OnlyRainSelectFullYear = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmSubsector;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSubsector_Testing()
        {
            SetupTestHelper(culture);
            MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(true, mwqmSubsectorService.GetRead().Where(c => c == mwqmSubsector).Any());
            mwqmSubsector.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmSubsectorService.Update(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsectorService.GetRead().Count());
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSubsectorTVItemID will automatically be initialized at 0 --> not null

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorSubsectorHistoricKey)).Any());
            Assert.AreEqual(null, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("TideLocationSIDText");
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorTideLocationSIDText)).Any());
            Assert.AreEqual(null, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //Error: Type not implemented [RainDay0Limit]

            //Error: Type not implemented [RainDay1Limit]

            //Error: Type not implemented [RainDay2Limit]

            //Error: Type not implemented [RainDay3Limit]

            //Error: Type not implemented [RainDay4Limit]

            //Error: Type not implemented [RainDay5Limit]

            //Error: Type not implemented [RainDay6Limit]

            //Error: Type not implemented [RainDay7Limit]

            //Error: Type not implemented [RainDay8Limit]

            //Error: Type not implemented [RainDay9Limit]

            //Error: Type not implemented [RainDay10Limit]

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSubsector.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MWQMSubsectorLanguages]

            //Error: Type not implemented [MWQMSubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSubsectorID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSubsectorTVItemID] of type [Int32]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.MWQMSubsectorTVItemID = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.MWQMSubsectorTVItemID = 2;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.MWQMSubsectorTVItemID = 0;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [SubsectorHistoricKey] of type [String]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            //-----------------------------------
            // doing property [TideLocationSIDText] of type [String]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            //-----------------------------------
            // doing property [RainDay0Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay1Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay2Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay3Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay4Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay5Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay6Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay7Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay8Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay9Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay10Limit] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeRainRunCount] of type [Int32]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // IncludeRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.IncludeRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.IncludeRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [IncludeRainSelectFullYear] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainRunCount] of type [Int32]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // NoRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.NoRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.NoRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.NoRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.NoRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.NoRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.NoRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [NoRainSelectFullYear] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainRunCount] of type [Int32]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // OnlyRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.OnlyRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.OnlyRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [OnlyRainSelectFullYear] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSubsectorLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSubsectorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
