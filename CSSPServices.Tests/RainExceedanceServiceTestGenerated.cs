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
    public partial class RainExceedanceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RainExceedanceService rainExceedanceService { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceServiceTest() : base()
        {
            //rainExceedanceService = new RainExceedanceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RainExceedance GetFilledRandomRainExceedance(string OmitPropName)
        {
            RainExceedance rainExceedance = new RainExceedance();

            if (OmitPropName != "YearRound") rainExceedance.YearRound = true;
            if (OmitPropName != "StartDate_Local") rainExceedance.StartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate_Local") rainExceedance.EndDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "RainMaximum_mm") rainExceedance.RainMaximum_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainExtreme_mm") rainExceedance.RainExtreme_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "DaysPriorToStart") rainExceedance.DaysPriorToStart = GetRandomInt(0, 30);
            if (OmitPropName != "RepeatEveryYear") rainExceedance.RepeatEveryYear = true;
            if (OmitPropName != "ProvinceTVItemIDs") rainExceedance.ProvinceTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "SubsectorTVItemIDs") rainExceedance.SubsectorTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "ClimateSiteTVItemIDs") rainExceedance.ClimateSiteTVItemIDs = GetRandomString("", 5);
            if (OmitPropName != "EmailDistributionListIDs") rainExceedance.EmailDistributionListIDs = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedance.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedance.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") rainExceedance.LastUpdateContactTVText = GetRandomString("", 5);

            return rainExceedance;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RainExceedance_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                RainExceedanceService rainExceedanceService = new RainExceedanceService(LanguageRequest, dbTestDB, ContactID);

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

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.RainExceedanceID = 0;
                rainExceedanceService.Update(rainExceedance);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceRainExceedanceID), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // rainExceedance.YearRound   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // rainExceedance.StartDate_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // [CSSPBigger(OtherField = StartDate_Local)]
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
                rainExceedance.RainMaximum_mm = -1.0D;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.RainMaximum_mm = 301.0D;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // rainExceedance.RainExtreme_mm   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainExtreme_mm]

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.RainExtreme_mm = -1.0D;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.RainExtreme_mm = 301.0D;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 30)]
                // rainExceedance.DaysPriorToStart   (Int32)
                // -----------------------------------

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.DaysPriorToStart = -1;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.DaysPriorToStart = 31;
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // rainExceedance.RepeatEveryYear   (Boolean)
                // -----------------------------------


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
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.ProvinceTVItemIDs = GetRandomString("", 251);
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceProvinceTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.SubsectorTVItemIDs = GetRandomString("", 251);
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceSubsectorTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.ClimateSiteTVItemIDs = GetRandomString("", 251);
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceClimateSiteTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.EmailDistributionListIDs = GetRandomString("", 251);
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceEmailDistributionListIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // rainExceedance.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // rainExceedance.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.LastUpdateContactTVItemID = 0;
                rainExceedanceService.Add(rainExceedance);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RainExceedanceLastUpdateContactTVItemID, rainExceedance.LastUpdateContactTVItemID.ToString()), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.LastUpdateContactTVItemID = 1;
                rainExceedanceService.Add(rainExceedance);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RainExceedanceLastUpdateContactTVItemID, "Contact"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // rainExceedance.LastUpdateContactTVText   (String)
                // -----------------------------------

                rainExceedance = null;
                rainExceedance = GetFilledRandomRainExceedance("");
                rainExceedance.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceLastUpdateContactTVText, "200"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // rainExceedance.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void RainExceedance_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                RainExceedanceService rainExceedanceService = new RainExceedanceService(LanguageRequest, dbTestDB, ContactID);
                RainExceedance rainExceedance = (from c in rainExceedanceService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(rainExceedance);

                RainExceedance rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                Assert.AreEqual(rainExceedance.RainExceedanceID, rainExceedanceRet.RainExceedanceID);
                Assert.AreEqual(rainExceedance.YearRound, rainExceedanceRet.YearRound);
                Assert.AreEqual(rainExceedance.StartDate_Local, rainExceedanceRet.StartDate_Local);
                Assert.AreEqual(rainExceedance.EndDate_Local, rainExceedanceRet.EndDate_Local);
                Assert.AreEqual(rainExceedance.RainMaximum_mm, rainExceedanceRet.RainMaximum_mm);
                Assert.AreEqual(rainExceedance.RainExtreme_mm, rainExceedanceRet.RainExtreme_mm);
                Assert.AreEqual(rainExceedance.DaysPriorToStart, rainExceedanceRet.DaysPriorToStart);
                Assert.AreEqual(rainExceedance.RepeatEveryYear, rainExceedanceRet.RepeatEveryYear);
                Assert.AreEqual(rainExceedance.ProvinceTVItemIDs, rainExceedanceRet.ProvinceTVItemIDs);
                Assert.AreEqual(rainExceedance.SubsectorTVItemIDs, rainExceedanceRet.SubsectorTVItemIDs);
                Assert.AreEqual(rainExceedance.ClimateSiteTVItemIDs, rainExceedanceRet.ClimateSiteTVItemIDs);
                Assert.AreEqual(rainExceedance.EmailDistributionListIDs, rainExceedanceRet.EmailDistributionListIDs);
                Assert.AreEqual(rainExceedance.LastUpdateDate_UTC, rainExceedanceRet.LastUpdateDate_UTC);
                Assert.AreEqual(rainExceedance.LastUpdateContactTVItemID, rainExceedanceRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(rainExceedanceRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
