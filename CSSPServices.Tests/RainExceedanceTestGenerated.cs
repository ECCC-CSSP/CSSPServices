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
            if (OmitPropName != "RainMaximum_mm") rainExceedance.RainMaximum_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainExtreme_mm") rainExceedance.RainExtreme_mm = GetRandomDouble(1.0D, 1000.0D);
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // YearRound will automatically be initialized at 0 --> not null

            //Error: Type not implemented [RainMaximum_mm]

            //Error: Type not implemented [RainExtreme_mm]

            // DaysPriorToStart will automatically be initialized at 0 --> not null

            // RepeatEveryYear will automatically be initialized at 0 --> not null

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("ProvinceTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceProvinceTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.ProvinceTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("SubsectorTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceSubsectorTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.SubsectorTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("ClimateSiteTVItemIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceClimateSiteTVItemIDs)).Any());
            Assert.AreEqual(null, rainExceedance.ClimateSiteTVItemIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("EmailDistributionListIDs");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceEmailDistributionListIDs)).Any());
            Assert.AreEqual(null, rainExceedance.EmailDistributionListIDs);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("LastUpdateDate_UTC");
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceLastUpdateDate_UTC)).Any());
            Assert.IsTrue(rainExceedance.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [RainExceedanceID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [YearRound] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [StartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainMaximum_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainExtreme_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DaysPriorToStart] of type [Int32]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // DaysPriorToStart has Min [0] and Max [30]. At Min should return true and no errors
            rainExceedance.DaysPriorToStart = 0;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(0, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Min + 1 should return true and no errors
            rainExceedance.DaysPriorToStart = 1;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Min - 1 should return false with one error
            rainExceedance.DaysPriorToStart = -1;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30")).Any());
            Assert.AreEqual(-1, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max should return true and no errors
            rainExceedance.DaysPriorToStart = 30;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(30, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max - 1 should return true and no errors
            rainExceedance.DaysPriorToStart = 29;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(29, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // DaysPriorToStart has Min [0] and Max [30]. At Max + 1 should return false with one error
            rainExceedance.DaysPriorToStart = 31;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30")).Any());
            Assert.AreEqual(31, rainExceedance.DaysPriorToStart);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            //-----------------------------------
            // doing property [RepeatEveryYear] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvinceTVItemIDs] of type [String]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            //-----------------------------------
            // doing property [SubsectorTVItemIDs] of type [String]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            //-----------------------------------
            // doing property [ClimateSiteTVItemIDs] of type [String]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            //-----------------------------------
            // doing property [EmailDistributionListIDs] of type [String]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            rainExceedance = null;
            rainExceedance = GetFilledRandomRainExceedance("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            rainExceedance.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(1, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            rainExceedance.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, rainExceedanceService.Add(rainExceedance));
            Assert.AreEqual(0, rainExceedance.ValidationResults.Count());
            Assert.AreEqual(2, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(true, rainExceedanceService.Delete(rainExceedance));
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            rainExceedance.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
            Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RainExceedanceLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, rainExceedance.LastUpdateContactTVItemID);
            Assert.AreEqual(0, rainExceedanceService.GetRead().Count());

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
