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
            if (OmitPropName != "RainDay0Limit") mwqmSubsector.RainDay0Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay1Limit") mwqmSubsector.RainDay1Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay2Limit") mwqmSubsector.RainDay2Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay3Limit") mwqmSubsector.RainDay3Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay4Limit") mwqmSubsector.RainDay4Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay5Limit") mwqmSubsector.RainDay5Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay6Limit") mwqmSubsector.RainDay6Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay7Limit") mwqmSubsector.RainDay7Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay8Limit") mwqmSubsector.RainDay8Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay9Limit") mwqmSubsector.RainDay9Limit = GetRandomFloat(0, 1000);
            if (OmitPropName != "RainDay10Limit") mwqmSubsector.RainDay10Limit = GetRandomFloat(0, 1000);
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
            SetupTestHelper(LoginEmail, culture);
            MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");
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
            mwqmSubsector = GetFilledRandomMWQMSubsector("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSubsector.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSubsectorID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSubsectorTVItemID] of type [int]
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
            // doing property [SubsectorHistoricKey] of type [string]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 20);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 19);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 21);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorHistoricKey, "20")).Any());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [TideLocationSIDText] of type [string]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // TideLocationSIDText has MinLength [empty] and MaxLength [30]. At Max should return true and no errors
            string mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 30);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // TideLocationSIDText has MinLength [empty] and MaxLength [30]. At Max - 1 should return true and no errors
            mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 29);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            // TideLocationSIDText has MinLength [empty] and MaxLength [30]. At Max + 1 should return false with one error
            mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 31);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorTideLocationSIDText, "30")).Any());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay0Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay0Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay0Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay0Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay0Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay0Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay0Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay0Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay1Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay1Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay1Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay1Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay1Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay1Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay1Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay1Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay2Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay2Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay2Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay2Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay2Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay2Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay2Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay2Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay3Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay3Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay3Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay3Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay3Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay3Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay3Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay3Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay4Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay4Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay4Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay4Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay4Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay4Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay4Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay4Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay5Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay5Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay5Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay5Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay5Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay5Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay5Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay5Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay6Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay6Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay6Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay6Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay6Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay6Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay6Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay6Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay7Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay7Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay7Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay7Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay7Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay7Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay7Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay7Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay8Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay8Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay8Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay8Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay8Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay8Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay8Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay8Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay9Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay9Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay9Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay9Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay9Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay9Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay9Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay9Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [RainDay10Limit] of type [float]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay10Limit has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSubsector.RainDay10Limit = 0.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay10Limit = 1.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay10Limit = -1.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSubsector.RainDay10Limit = 1000.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay10Limit = 999.0f;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay10Limit = 1001.0f;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [IncludeRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeRainRunCount] of type [int]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // IncludeRainRunCount has Min [0] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.IncludeRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0")).Any());
            Assert.AreEqual(-1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [IncludeRainSelectFullYear] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [NoRainRunCount] of type [int]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // NoRainRunCount has Min [0] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.NoRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.NoRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.NoRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorNoRainRunCount, "0")).Any());
            Assert.AreEqual(-1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [NoRainSelectFullYear] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainStartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainEndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [OnlyRainRunCount] of type [int]
            //-----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // OnlyRainRunCount has Min [0] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.OnlyRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0")).Any());
            Assert.AreEqual(-1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [OnlyRainSelectFullYear] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
