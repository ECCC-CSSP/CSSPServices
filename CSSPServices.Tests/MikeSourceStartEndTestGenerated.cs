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
        private MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndTest() : base()
        {
            mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;

            return mikeSourceStartEnd;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeSourceStartEnd_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mikeSourceStartEndService.GetRead().Count();

            mikeSourceStartEndService.Add(mikeSourceStartEnd);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mikeSourceStartEndService.GetRead().Where(c => c == mikeSourceStartEnd).Any());
            mikeSourceStartEndService.Update(mikeSourceStartEnd);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mikeSourceStartEndService.GetRead().Count());
            mikeSourceStartEndService.Delete(mikeSourceStartEnd);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mikeSourceStartEnd.MikeSourceStartEndID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceStartEndID = 0;
            mikeSourceStartEndService.Update(mikeSourceStartEnd);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndMikeSourceStartEndID), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "MikeSource", Plurial = "s", FieldID = "MikeSourceID", TVType = TVTypeEnum.Error)]
            // mikeSourceStartEnd.MikeSourceID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceID = 0;
            mikeSourceStartEndService.Add(mikeSourceStartEnd);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MikeSource, ModelsRes.MikeSourceStartEndMikeSourceID, mikeSourceStartEnd.MikeSourceID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

            // MikeSourceID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
            // -----------------------------------

            // StartDateAndTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateAndTime_Local)]
            // mikeSourceStartEnd.EndDateAndTime_Local   (DateTime)
            // -----------------------------------

            // EndDateAndTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000000)]
            // mikeSourceStartEnd.SourceFlowStart_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceFlowStart_m3_day]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceFlowStart_m3_day = 0.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceFlowStart_m3_day = 1.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceFlowStart_m3_day = -1.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceFlowStart_m3_day = 1000000.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceFlowStart_m3_day = 999999.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(999999.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowStart_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, mikeSourceStartEnd.SourceFlowStart_m3_day);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000000)]
            // mikeSourceStartEnd.SourceFlowEnd_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceFlowEnd_m3_day]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 0.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 1.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceFlowEnd_m3_day = -1.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000000.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 999999.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(999999.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceFlowEnd_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, mikeSourceStartEnd.SourceFlowEnd_m3_day);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
            // -----------------------------------

            // SourcePollutionStart_MPN_100ml will automatically be initialized at 0 --> not null

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 0;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000000;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(10000000, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 9999999;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(9999999, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionStart_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
            // -----------------------------------

            // SourcePollutionEnd_MPN_100ml will automatically be initialized at 0 --> not null

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 0;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 1;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000000;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(10000000, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 9999999;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(9999999, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourcePollutionEnd_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-10, 40)]
            // mikeSourceStartEnd.SourceTemperatureStart_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceTemperatureStart_C]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceTemperatureStart_C = -10.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceTemperatureStart_C = -9.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceTemperatureStart_C = -11.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceTemperatureStart_C = 40.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceTemperatureStart_C = 39.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureStart_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mikeSourceStartEnd.SourceTemperatureStart_C);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-10, 40)]
            // mikeSourceStartEnd.SourceTemperatureEnd_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceTemperatureEnd_C]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceTemperatureEnd_C = -10.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceTemperatureEnd_C = -9.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceTemperatureEnd_C = -11.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceTemperatureEnd_C = 40.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceTemperatureEnd_C = 39.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceTemperatureEnd_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mikeSourceStartEnd.SourceTemperatureEnd_C);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 40)]
            // mikeSourceStartEnd.SourceSalinityStart_PSU   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceSalinityStart_PSU]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceSalinityStart_PSU = 0.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceSalinityStart_PSU = 1.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceSalinityStart_PSU = -1.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceSalinityStart_PSU = 40.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceSalinityStart_PSU = 39.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityStart_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, mikeSourceStartEnd.SourceSalinityStart_PSU);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 40)]
            // mikeSourceStartEnd.SourceSalinityEnd_PSU   (Double)
            // -----------------------------------

            //Error: Type not implemented [SourceSalinityEnd_PSU]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 0.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 1.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeSourceStartEnd.SourceSalinityEnd_PSU = -1.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 40.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 39.0D;
            Assert.AreEqual(true, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.AreEqual(0, mikeSourceStartEnd.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(true, mikeSourceStartEndService.Delete(mikeSourceStartEnd));
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
            // SourceSalinityEnd_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
            Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
            Assert.IsTrue(mikeSourceStartEnd.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, mikeSourceStartEnd.SourceSalinityEnd_PSU);
            Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
            mikeSourceStartEndService.Add(mikeSourceStartEnd);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mikeSourceStartEnd.MikeSource   (MikeSource)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mikeSourceStartEnd.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
