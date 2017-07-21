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
    public partial class MikeSourceStartEndTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MikeSourceStartEndID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            MikeSourceStartEndID += 1;

            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceStartEndID") mikeSourceStartEnd.MikeSourceStartEndID = MikeSourceStartEndID;
            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = GetRandomInt(1, 11);
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = GetRandomDateTime();
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mikeSourceStartEnd;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeSourceStartEnd_Testing()
        {
            SetupTestHelper(culture);
            MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(true, mikeSourceStartEndService.GetRead().Where(c => c == mikeSourceStartEnd).Any());
            mikeSourceStartEnd.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mikeSourceStartEndService.Update(mikeSourceStartEnd));
            Assert.AreEqual(1, mikeSourceStartEndService.GetRead().Count());
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MikeSourceID will automatically be initialized at 0 --> not null

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("StartDateAndTime_Local");
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(1, mikeSourceStartEnd.ValidationResults.Count());
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndStartDateAndTime_Local)).Any());
            Assert.IsTrue(mikeSourceStartEnd.StartDateAndTime_Local.Year < 1900);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("EndDateAndTime_Local");
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(1, mikeSourceStartEnd.ValidationResults.Count());
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndEndDateAndTime_Local)).Any());
            Assert.IsTrue(mikeSourceStartEnd.EndDateAndTime_Local.Year < 1900);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            //Error: Type not implemented [SourceFlowStart_m3_day]

            //Error: Type not implemented [SourceFlowEnd_m3_day]

            // SourcePollutionStart_MPN_100ml will automatically be initialized at 0 --> not null

            // SourcePollutionEnd_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SourceTemperatureStart_C]

            //Error: Type not implemented [SourceTemperatureEnd_C]

            //Error: Type not implemented [SourceSalinityStart_PSU]

            //Error: Type not implemented [SourceSalinityEnd_PSU]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("LastUpdateDate_UTC");
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(1, mikeSourceStartEnd.ValidationResults.Count());
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MikeSource]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MikeSourceStartEndID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeSourceID] of type [Int32]
            //-----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // MikeSourceID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSourceStartEnd.MikeSourceID = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.MikeSourceID);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // MikeSourceID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.MikeSourceID = 2;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(2, mikeSourceStartEnd.MikeSourceID);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // MikeSourceID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSourceStartEnd.MikeSourceID = 0;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceStartEndMikeSourceID, "1")).Any());
            Assert.AreEqual(0, mikeSourceStartEnd.MikeSourceID);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            //-----------------------------------
            // doing property [StartDateAndTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDateAndTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceFlowStart_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceFlowEnd_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourcePollutionStart_MPN_100ml] of type [Int32]
            //-----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 0;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000000;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(10000000, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 9999999;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(9999999, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            //-----------------------------------
            // doing property [SourcePollutionEnd_MPN_100ml] of type [Int32]
            //-----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 0;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000000;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(10000000, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 9999999;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(9999999, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            //-----------------------------------
            // doing property [SourceTemperatureStart_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceTemperatureEnd_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceSalinityStart_PSU] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceSalinityEnd_PSU] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSourceStartEnd.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(2, mikeSourceStartEnd.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeSourceStartEnd.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mikeSourceStartEndService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeSource] of type [MikeSource]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
