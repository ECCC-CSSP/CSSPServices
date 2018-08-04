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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RainExceedance_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = rainExceedanceService.GetRainExceedanceList().Count();

                    Assert.AreEqual(rainExceedanceService.GetRainExceedanceList().Count(), (from c in dbTestDB.RainExceedances select c).Take(200).Count());

                    rainExceedanceService.Add(rainExceedance);
                    if (rainExceedance.HasErrors)
                    {
                        Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, rainExceedanceService.GetRainExceedanceList().Where(c => c == rainExceedance).Any());
                    rainExceedanceService.Update(rainExceedance);
                    if (rainExceedance.HasErrors)
                    {
                        Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, rainExceedanceService.GetRainExceedanceList().Count());
                    rainExceedanceService.Delete(rainExceedance);
                    if (rainExceedance.HasErrors)
                    {
                        Assert.AreEqual("", rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceRainExceedanceID"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceID = 10000000;
                    rainExceedanceService.Update(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceRainExceedanceID", rainExceedance.RainExceedanceID.ToString()), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // rainExceedance.YearRound   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // rainExceedance.StartDate_Local   (DateTime)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.StartDate_Local = new DateTime(1979, 1, 1);
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceStartDate_Local", "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDate_Local)]
                    // rainExceedance.EndDate_Local   (DateTime)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.EndDate_Local = new DateTime(1979, 1, 1);
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceEndDate_Local", "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // rainExceedance.RainMaximum_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainMaximum_mm]

                    //Error: Type not implemented [RainMaximum_mm]

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainMaximum_mm = -1.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainMaximum_mm", "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainMaximum_mm = 301.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainMaximum_mm", "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // rainExceedance.RainExtreme_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainExtreme_mm]

                    //Error: Type not implemented [RainExtreme_mm]

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExtreme_mm = -1.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainExtreme_mm", "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExtreme_mm = 301.0D;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainExtreme_mm", "0", "300"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 30)]
                    // rainExceedance.DaysPriorToStart   (Int32)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.DaysPriorToStart = -1;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceDaysPriorToStart", "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.DaysPriorToStart = 31;
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceDaysPriorToStart", "0", "30"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

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
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RainExceedanceProvinceTVItemIDs")).Any());
                    Assert.AreEqual(null, rainExceedance.ProvinceTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.ProvinceTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceProvinceTVItemIDs", "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // rainExceedance.SubsectorTVItemIDs   (String)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("SubsectorTVItemIDs");
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RainExceedanceSubsectorTVItemIDs")).Any());
                    Assert.AreEqual(null, rainExceedance.SubsectorTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.SubsectorTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceSubsectorTVItemIDs", "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // rainExceedance.ClimateSiteTVItemIDs   (String)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("ClimateSiteTVItemIDs");
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RainExceedanceClimateSiteTVItemIDs")).Any());
                    Assert.AreEqual(null, rainExceedance.ClimateSiteTVItemIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.ClimateSiteTVItemIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceClimateSiteTVItemIDs", "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // rainExceedance.EmailDistributionListIDs   (String)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("EmailDistributionListIDs");
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(1, rainExceedance.ValidationResults.Count());
                    Assert.IsTrue(rainExceedance.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RainExceedanceEmailDistributionListIDs")).Any());
                    Assert.AreEqual(null, rainExceedance.EmailDistributionListIDs);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.EmailDistributionListIDs = GetRandomString("", 251);
                    Assert.AreEqual(false, rainExceedanceService.Add(rainExceedance));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceEmailDistributionListIDs", "250"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, rainExceedanceService.GetRainExceedanceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // rainExceedance.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateDate_UTC = new DateTime();
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceLastUpdateDate_UTC"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceLastUpdateDate_UTC", "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // rainExceedance.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateContactTVItemID = 0;
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RainExceedanceLastUpdateContactTVItemID", rainExceedance.LastUpdateContactTVItemID.ToString()), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateContactTVItemID = 1;
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "RainExceedanceLastUpdateContactTVItemID", "Contact"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // rainExceedance.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // rainExceedance.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID)
        [TestMethod]
        public void GetRainExceedanceWithRainExceedanceID__rainExceedance_RainExceedanceID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RainExceedance rainExceedance = (from c in dbTestDB.RainExceedances select c).FirstOrDefault();
                    Assert.IsNotNull(rainExceedance);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        rainExceedanceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            RainExceedance rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                            CheckRainExceedanceFields(new List<RainExceedance>() { rainExceedanceRet });
                            Assert.AreEqual(rainExceedance.RainExceedanceID, rainExceedanceRet.RainExceedanceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            RainExceedanceWeb rainExceedanceWebRet = rainExceedanceService.GetRainExceedanceWebWithRainExceedanceID(rainExceedance.RainExceedanceID);
                            CheckRainExceedanceWebFields(new List<RainExceedanceWeb>() { rainExceedanceWebRet });
                            Assert.AreEqual(rainExceedance.RainExceedanceID, rainExceedanceWebRet.RainExceedanceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            RainExceedanceReport rainExceedanceReportRet = rainExceedanceService.GetRainExceedanceReportWithRainExceedanceID(rainExceedance.RainExceedanceID);
                            CheckRainExceedanceReportFields(new List<RainExceedanceReport>() { rainExceedanceReportRet });
                            Assert.AreEqual(rainExceedance.RainExceedanceID, rainExceedanceReportRet.RainExceedanceID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID)

        #region Tests Generated for GetRainExceedanceList()
        [TestMethod]
        public void GetRainExceedanceList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RainExceedance rainExceedance = (from c in dbTestDB.RainExceedances select c).FirstOrDefault();
                    Assert.IsNotNull(rainExceedance);

                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        rainExceedanceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList()

        #region Tests Generated for GetRainExceedanceList() Skip Take
        [TestMethod]
        public void GetRainExceedanceList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() Skip Take

        #region Tests Generated for GetRainExceedanceList() Skip Take Order
        [TestMethod]
        public void GetRainExceedanceList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1,  "RainExceedanceID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Skip(1).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() Skip Take Order

        #region Tests Generated for GetRainExceedanceList() Skip Take 2Order
        [TestMethod]
        public void GetRainExceedanceList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1, "RainExceedanceID,YearRound", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Skip(1).Take(1).OrderBy(c => c.RainExceedanceID).ThenBy(c => c.YearRound).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() Skip Take 2Order

        #region Tests Generated for GetRainExceedanceList() Skip Take Order Where
        [TestMethod]
        public void GetRainExceedanceList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 1, "RainExceedanceID", "RainExceedanceID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Where(c => c.RainExceedanceID == 4).Skip(0).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() Skip Take Order Where

        #region Tests Generated for GetRainExceedanceList() Skip Take Order 2Where
        [TestMethod]
        public void GetRainExceedanceList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 1, "RainExceedanceID", "RainExceedanceID,GT,2|RainExceedanceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Where(c => c.RainExceedanceID > 2 && c.RainExceedanceID < 5).Skip(0).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() Skip Take Order 2Where

        #region Tests Generated for GetRainExceedanceList() 2Where
        [TestMethod]
        public void GetRainExceedanceList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 10000, "", "RainExceedanceID,GT,2|RainExceedanceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                        rainExceedanceDirectQueryList = (from c in dbTestDB.RainExceedances select c).Where(c => c.RainExceedanceID > 2 && c.RainExceedanceID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            CheckRainExceedanceFields(rainExceedanceList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<RainExceedanceWeb> rainExceedanceWebList = new List<RainExceedanceWeb>();
                            rainExceedanceWebList = rainExceedanceService.GetRainExceedanceWebList().ToList();
                            CheckRainExceedanceWebFields(rainExceedanceWebList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceWebList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<RainExceedanceReport> rainExceedanceReportList = new List<RainExceedanceReport>();
                            rainExceedanceReportList = rainExceedanceService.GetRainExceedanceReportList().ToList();
                            CheckRainExceedanceReportFields(rainExceedanceReportList);
                            Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceReportList[0].RainExceedanceID);
                            Assert.AreEqual(rainExceedanceDirectQueryList.Count, rainExceedanceReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() 2Where

        #region Functions private
        private void CheckRainExceedanceFields(List<RainExceedance> rainExceedanceList)
        {
            Assert.IsNotNull(rainExceedanceList[0].RainExceedanceID);
            Assert.IsNotNull(rainExceedanceList[0].YearRound);
            if (rainExceedanceList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceList[0].StartDate_Local);
            }
            if (rainExceedanceList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceList[0].EndDate_Local);
            }
            if (rainExceedanceList[0].RainMaximum_mm != null)
            {
                Assert.IsNotNull(rainExceedanceList[0].RainMaximum_mm);
            }
            if (rainExceedanceList[0].RainExtreme_mm != null)
            {
                Assert.IsNotNull(rainExceedanceList[0].RainExtreme_mm);
            }
            Assert.IsNotNull(rainExceedanceList[0].DaysPriorToStart);
            Assert.IsNotNull(rainExceedanceList[0].RepeatEveryYear);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].ProvinceTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].SubsectorTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].ClimateSiteTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].EmailDistributionListIDs));
            Assert.IsNotNull(rainExceedanceList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(rainExceedanceList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(rainExceedanceList[0].HasErrors);
        }
        private void CheckRainExceedanceWebFields(List<RainExceedanceWeb> rainExceedanceWebList)
        {
            Assert.IsNotNull(rainExceedanceWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(rainExceedanceWebList[0].RainExceedanceID);
            Assert.IsNotNull(rainExceedanceWebList[0].YearRound);
            if (rainExceedanceWebList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceWebList[0].StartDate_Local);
            }
            if (rainExceedanceWebList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceWebList[0].EndDate_Local);
            }
            if (rainExceedanceWebList[0].RainMaximum_mm != null)
            {
                Assert.IsNotNull(rainExceedanceWebList[0].RainMaximum_mm);
            }
            if (rainExceedanceWebList[0].RainExtreme_mm != null)
            {
                Assert.IsNotNull(rainExceedanceWebList[0].RainExtreme_mm);
            }
            Assert.IsNotNull(rainExceedanceWebList[0].DaysPriorToStart);
            Assert.IsNotNull(rainExceedanceWebList[0].RepeatEveryYear);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceWebList[0].ProvinceTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceWebList[0].SubsectorTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceWebList[0].ClimateSiteTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceWebList[0].EmailDistributionListIDs));
            Assert.IsNotNull(rainExceedanceWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(rainExceedanceWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(rainExceedanceWebList[0].HasErrors);
        }
        private void CheckRainExceedanceReportFields(List<RainExceedanceReport> rainExceedanceReportList)
        {
            if (!string.IsNullOrWhiteSpace(rainExceedanceReportList[0].RainExceedanceReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceReportList[0].RainExceedanceReportTest));
            }
            Assert.IsNotNull(rainExceedanceReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(rainExceedanceReportList[0].RainExceedanceID);
            Assert.IsNotNull(rainExceedanceReportList[0].YearRound);
            if (rainExceedanceReportList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceReportList[0].StartDate_Local);
            }
            if (rainExceedanceReportList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(rainExceedanceReportList[0].EndDate_Local);
            }
            if (rainExceedanceReportList[0].RainMaximum_mm != null)
            {
                Assert.IsNotNull(rainExceedanceReportList[0].RainMaximum_mm);
            }
            if (rainExceedanceReportList[0].RainExtreme_mm != null)
            {
                Assert.IsNotNull(rainExceedanceReportList[0].RainExtreme_mm);
            }
            Assert.IsNotNull(rainExceedanceReportList[0].DaysPriorToStart);
            Assert.IsNotNull(rainExceedanceReportList[0].RepeatEveryYear);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceReportList[0].ProvinceTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceReportList[0].SubsectorTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceReportList[0].ClimateSiteTVItemIDs));
            Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceReportList[0].EmailDistributionListIDs));
            Assert.IsNotNull(rainExceedanceReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(rainExceedanceReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(rainExceedanceReportList[0].HasErrors);
        }
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

            return rainExceedance;
        }
        #endregion Functions private
    }
}
