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
    public partial class RainExceedanceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RainExceedanceService rainExceedanceService { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceTest() : base()
        {
            rainExceedanceService = new RainExceedanceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RainExceedance GetFilledRandomRainExceedance(string OmitPropName)
        {
            RainExceedance rainExceedance = new RainExceedance();

            if (OmitPropName != "YearRound") rainExceedance.YearRound = true;
            if (OmitPropName != "StartDate_Local") rainExceedance.StartDate_Local = GetRandomDateTime();
            if (OmitPropName != "EndDate_Local") rainExceedance.EndDate_Local = GetRandomDateTime();
            if (OmitPropName != "RainMaximum_mm") rainExceedance.RainMaximum_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainExtreme_mm") rainExceedance.RainExtreme_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "DaysPriorToStart") rainExceedance.DaysPriorToStart = GetRandomInt(0, 30);
            if (OmitPropName != "RepeatEveryYear") rainExceedance.RepeatEveryYear = true;
            if (OmitPropName != "ProvinceTVItemIDs") rainExceedance.ProvinceTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "SubsectorTVItemIDs") rainExceedance.SubsectorTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "ClimateSiteTVItemIDs") rainExceedance.ClimateSiteTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "EmailDistributionListIDs") rainExceedance.EmailDistributionListIDs = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedance.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedance.LastUpdateContactTVItemID = 2;

            return rainExceedance;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void RainExceedance_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            RainExceedance rainExceedance = GetFilledRandomRainExceedance("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = rainExceedanceService.GetRead().Count();

            rainExceedanceService.Add(rainExceedance);
            if (rainExceedance.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, rainExceedanceService.GetRead().Where(c => c == rainExceedance).Any());
            rainExceedanceService.Update(rainExceedance);
            if (rainExceedance.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, rainExceedanceService.GetRead().Count());
            rainExceedanceService.Delete(rainExceedance);
            if (rainExceedance.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // rainExceedance.RainExceedanceID   (Int32)
            // -----------------------------------

            rainExceedance = GetFilledRandomRainExceedance("");
            rainExceedance.RainExceedanceID = 0;
            rainExceedanceService.Update(rainExceedance);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceRainExceedanceID), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // rainExceedance.YearRound   (Boolean)
            // -----------------------------------

            // YearRound will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // rainExceedance.StartDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDate)]
            // rainExceedance.EndDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // rainExceedance.RainMaximum_mm   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainMaximum_mm]


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            rainExceedance.RainMaximum_mm = 0.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(0.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            rainExceedance.RainMaximum_mm = 1.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            rainExceedance.RainMaximum_mm = -1.0D;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            rainExceedance.RainMaximum_mm = 300.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(300.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            rainExceedance.RainMaximum_mm = 299.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(299.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainMaximum_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            rainExceedance.RainMaximum_mm = 301.0D;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, rainExceedance.RainMaximum_mm);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // rainExceedance.RainExtreme_mm   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainExtreme_mm]


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            rainExceedance.RainExtreme_mm = 0.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(0.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            rainExceedance.RainExtreme_mm = 1.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            rainExceedance.RainExtreme_mm = -1.0D;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            rainExceedance.RainExtreme_mm = 300.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(300.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            rainExceedance.RainExtreme_mm = 299.0D;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(299.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // RainExtreme_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            rainExceedance.RainExtreme_mm = 301.0D;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, rainExceedance.RainExtreme_mm);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 30)]
            // rainExceedance.DaysPriorToStart   (Int32)
            // -----------------------------------

            // DaysPriorToStart will automatically be initialized at 0 --> not null


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // DaysPriorToStart has Min [0] and Max [30]. At Min should return true and no errors
            rainExceedance.DaysPriorToStart = 0;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(0, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Min + 1 should return true and no errors
            rainExceedance.DaysPriorToStart = 1;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Min - 1 should return false with one error
            rainExceedance.DaysPriorToStart = -1;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30")).Any());
            Assert.AreEqual(-1, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max should return true and no errors
            rainExceedance.DaysPriorToStart = 30;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(30, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max - 1 should return true and no errors
            rainExceedance.DaysPriorToStart = 29;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(29, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max + 1 should return false with one error
            rainExceedance.DaysPriorToStart = 31;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30")).Any());
            Assert.AreEqual(31, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // rainExceedance.RepeatEveryYear   (Boolean)
            // -----------------------------------

            // RepeatEveryYear will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // rainExceedance.ProvinceTVItemIDs   (String)
            // -----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("ProvinceTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceProvinceTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.ProvinceTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            // ProvinceTVItemIDs has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string rainExceedanceProvinceTVItemIDsMin = GetRandomString("", 250);
            rainExceedance.ProvinceTVItemIDs = rainExceedanceProvinceTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceProvinceTVItemIDsMin, rainExceedance.ProvinceTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // ProvinceTVItemIDs has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            rainExceedanceProvinceTVItemIDsMin = GetRandomString("", 249);
            rainExceedance.ProvinceTVItemIDs = rainExceedanceProvinceTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceProvinceTVItemIDsMin, rainExceedance.ProvinceTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // ProvinceTVItemIDs has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            rainExceedanceProvinceTVItemIDsMin = GetRandomString("", 251);
            rainExceedance.ProvinceTVItemIDs = rainExceedanceProvinceTVItemIDsMin;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceProvinceTVItemIDs, "250")).Any());
            Assert.AreEqual(rainExceedanceProvinceTVItemIDsMin, rainExceedance.ProvinceTVItemIDs);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // rainExceedance.SubsectorTVItemIDs   (String)
            // -----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("SubsectorTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceSubsectorTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.SubsectorTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            // SubsectorTVItemIDs has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string rainExceedanceSubsectorTVItemIDsMin = GetRandomString("", 250);
            rainExceedance.SubsectorTVItemIDs = rainExceedanceSubsectorTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceSubsectorTVItemIDsMin, rainExceedance.SubsectorTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // SubsectorTVItemIDs has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            rainExceedanceSubsectorTVItemIDsMin = GetRandomString("", 249);
            rainExceedance.SubsectorTVItemIDs = rainExceedanceSubsectorTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceSubsectorTVItemIDsMin, rainExceedance.SubsectorTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // SubsectorTVItemIDs has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            rainExceedanceSubsectorTVItemIDsMin = GetRandomString("", 251);
            rainExceedance.SubsectorTVItemIDs = rainExceedanceSubsectorTVItemIDsMin;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceSubsectorTVItemIDs, "250")).Any());
            Assert.AreEqual(rainExceedanceSubsectorTVItemIDsMin, rainExceedance.SubsectorTVItemIDs);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // rainExceedance.ClimateSiteTVItemIDs   (String)
            // -----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("ClimateSiteTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceClimateSiteTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.ClimateSiteTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            // ClimateSiteTVItemIDs has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string rainExceedanceClimateSiteTVItemIDsMin = GetRandomString("", 250);
            rainExceedance.ClimateSiteTVItemIDs = rainExceedanceClimateSiteTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceClimateSiteTVItemIDsMin, rainExceedance.ClimateSiteTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // ClimateSiteTVItemIDs has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            rainExceedanceClimateSiteTVItemIDsMin = GetRandomString("", 249);
            rainExceedance.ClimateSiteTVItemIDs = rainExceedanceClimateSiteTVItemIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceClimateSiteTVItemIDsMin, rainExceedance.ClimateSiteTVItemIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // ClimateSiteTVItemIDs has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            rainExceedanceClimateSiteTVItemIDsMin = GetRandomString("", 251);
            rainExceedance.ClimateSiteTVItemIDs = rainExceedanceClimateSiteTVItemIDsMin;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceClimateSiteTVItemIDs, "250")).Any());
            Assert.AreEqual(rainExceedanceClimateSiteTVItemIDsMin, rainExceedance.ClimateSiteTVItemIDs);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // rainExceedance.EmailDistributionListIDs   (String)
            // -----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("EmailDistributionListIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceEmailDistributionListIDs)).Any());
            Assert.AreEqual(null, rainExceedance.EmailDistributionListIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            // EmailDistributionListIDs has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string rainExceedanceEmailDistributionListIDsMin = GetRandomEmail();
            rainExceedance.EmailDistributionListIDs = rainExceedanceEmailDistributionListIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceEmailDistributionListIDsMin, rainExceedance.EmailDistributionListIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // EmailDistributionListIDs has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            rainExceedanceEmailDistributionListIDsMin = GetRandomEmail();
            rainExceedance.EmailDistributionListIDs = rainExceedanceEmailDistributionListIDsMin;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(rainExceedanceEmailDistributionListIDsMin, rainExceedance.EmailDistributionListIDs);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // rainExceedance.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // rainExceedance.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            rainExceedance.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            rainExceedance.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(2, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            rainExceedance.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RainExceedanceLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // rainExceedance.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
