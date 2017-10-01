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
            //Error: property [RainExceedanceWeb] and type [RainExceedance] is  not implemented
            //Error: property [RainExceedanceReport] and type [RainExceedance] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedance.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedance.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") rainExceedance.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(rainExceedanceService.GetRead().Count(), rainExceedanceService.GetEdit().Count());

                    rainExceedanceService.Add(rainExceedance);
                    if (rainExceedance.HasErrors)
                    {
                        Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, rainExceedanceService.GetRead().Where(c => c == rainExceedance).Any());
                    rainExceedanceService.Update(rainExceedance);
                    if (rainExceedance.HasErrors)
                    {
                        Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, rainExceedanceService.GetRead().Count());
                    rainExceedanceService.Delete(rainExceedance);
                    if (rainExceedance.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceRainExceedanceID), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceID = 10000000;
                    rainExceedanceService.Update(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RainExceedance, CSSPModelsRes.RainExceedanceRainExceedanceID, rainExceedance.RainExceedanceID.ToString()), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainMaximum_mm = 301.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExtreme_mm = 301.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.DaysPriorToStart = 31;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceProvinceTVItemIDs)).Any());
                    Assert.AreEqual(null, rainExceedance.ProvinceTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.ProvinceTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceProvinceTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceSubsectorTVItemIDs)).Any());
                    Assert.AreEqual(null, rainExceedance.SubsectorTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.SubsectorTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceSubsectorTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceClimateSiteTVItemIDs)).Any());
                    Assert.AreEqual(null, rainExceedance.ClimateSiteTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.ClimateSiteTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceClimateSiteTVItemIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceEmailDistributionListIDs)).Any());
                    Assert.AreEqual(null, rainExceedance.EmailDistributionListIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.EmailDistributionListIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceEmailDistributionListIDs, "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // rainExceedance.RainExceedanceWeb   (RainExceedanceWeb)
                    // -----------------------------------

                    //Error: Type not implemented [RainExceedanceWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // rainExceedance.RainExceedanceReport   (RainExceedanceReport)
                    // -----------------------------------

                    //Error: Type not implemented [RainExceedanceReport]


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
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RainExceedanceLastUpdateContactTVItemID, rainExceedance.LastUpdateContactTVItemID.ToString()), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateContactTVItemID = 1;
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RainExceedanceLastUpdateContactTVItemID, "Contact"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // rainExceedance.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // rainExceedance.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RainExceedanceService rainExceedanceService = new RainExceedanceService(LanguageRequest, dbTestDB, ContactID);
                    RainExceedance rainExceedance = (from c in rainExceedanceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(rainExceedance);

                    RainExceedance rainExceedanceRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(rainExceedanceRet.RainExceedanceID);
                        Assert.IsNotNull(rainExceedanceRet.YearRound);
                        if (rainExceedanceRet.StartDate_Local != null)
                        {
                            Assert.IsNotNull(rainExceedanceRet.StartDate_Local);
                        }
                        if (rainExceedanceRet.EndDate_Local != null)
                        {
                            Assert.IsNotNull(rainExceedanceRet.EndDate_Local);
                        }
                        if (rainExceedanceRet.RainMaximum_mm != null)
                        {
                            Assert.IsNotNull(rainExceedanceRet.RainMaximum_mm);
                        }
                        if (rainExceedanceRet.RainExtreme_mm != null)
                        {
                            Assert.IsNotNull(rainExceedanceRet.RainExtreme_mm);
                        }
                        Assert.IsNotNull(rainExceedanceRet.DaysPriorToStart);
                        Assert.IsNotNull(rainExceedanceRet.RepeatEveryYear);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceRet.ProvinceTVItemIDs));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceRet.SubsectorTVItemIDs));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceRet.ClimateSiteTVItemIDs));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceRet.EmailDistributionListIDs));
                        Assert.IsNotNull(rainExceedanceRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(rainExceedanceRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (rainExceedanceRet.RainExceedanceWeb != null)
                            {
                                Assert.IsNull(rainExceedanceRet.RainExceedanceWeb);
                            }
                            if (rainExceedanceRet.RainExceedanceReport != null)
                            {
                                Assert.IsNull(rainExceedanceRet.RainExceedanceReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (rainExceedanceRet.RainExceedanceWeb != null)
                            {
                                Assert.IsNotNull(rainExceedanceRet.RainExceedanceWeb);
                            }
                            if (rainExceedanceRet.RainExceedanceReport != null)
                            {
                                Assert.IsNotNull(rainExceedanceRet.RainExceedanceReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of RainExceedance
        #endregion Tests Get List of RainExceedance

    }
}
