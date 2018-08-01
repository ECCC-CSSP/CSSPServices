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

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.StartDate_Local = new DateTime(1979, 1, 1);
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceStartDate_Local, "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceEndDate_Local, "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

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

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceWeb = null;
                    Assert.IsNull(rainExceedance.RainExceedanceWeb);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceWeb = new RainExceedanceWeb();
                    Assert.IsNotNull(rainExceedance.RainExceedanceWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // rainExceedance.RainExceedanceReport   (RainExceedanceReport)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceReport = null;
                    Assert.IsNull(rainExceedance.RainExceedanceReport);

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.RainExceedanceReport = new RainExceedanceReport();
                    Assert.IsNotNull(rainExceedance.RainExceedanceReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // rainExceedance.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateDate_UTC = new DateTime();
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceLastUpdateDate_UTC), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);
                    rainExceedance = null;
                    rainExceedance = GetFilledRandomRainExceedance("");
                    rainExceedance.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    rainExceedanceService.Add(rainExceedance);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceLastUpdateDate_UTC, "1980"), rainExceedance.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    RainExceedance rainExceedance = (from c in rainExceedanceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(rainExceedance);

                    RainExceedance rainExceedanceRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        rainExceedanceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                            Assert.IsNull(rainExceedanceRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceRet = rainExceedanceService.GetRainExceedanceWithRainExceedanceID(rainExceedance.RainExceedanceID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(new List<RainExceedance>() { rainExceedanceRet }, entityQueryDetailType);
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
                    RainExceedance rainExceedance = (from c in rainExceedanceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(rainExceedance);

                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        rainExceedanceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(1, rainExceedanceList.Count);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1,  "RainExceedanceID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Skip(1).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(1, rainExceedanceList.Count);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 1, 1, "RainExceedanceID,YearRound", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Skip(1).Take(1).OrderBy(c => c.RainExceedanceID).ThenBy(c => c.YearRound).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(1, rainExceedanceList.Count);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 1, "RainExceedanceID", "RainExceedanceID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Where(c => c.RainExceedanceID == 4).Skip(0).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(1, rainExceedanceList.Count);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 1, "RainExceedanceID", "RainExceedanceID,GT,2|RainExceedanceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Where(c => c.RainExceedanceID > 2 && c.RainExceedanceID < 5).Skip(0).Take(1).OrderBy(c => c.RainExceedanceID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(1, rainExceedanceList.Count);
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
                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    List<RainExceedance> rainExceedanceDirectQueryList = new List<RainExceedance>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        rainExceedanceService.Query = rainExceedanceService.FillQuery(typeof(RainExceedance), culture.TwoLetterISOLanguageName, 0, 10000, "", "RainExceedanceID,GT,2|RainExceedanceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        rainExceedanceDirectQueryList = rainExceedanceService.GetRead().Where(c => c.RainExceedanceID > 2 && c.RainExceedanceID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                            Assert.AreEqual(0, rainExceedanceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            rainExceedanceList = rainExceedanceService.GetRainExceedanceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRainExceedanceFields(rainExceedanceList, entityQueryDetailType);
                        Assert.AreEqual(rainExceedanceDirectQueryList[0].RainExceedanceID, rainExceedanceList[0].RainExceedanceID);
                        Assert.AreEqual(2, rainExceedanceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRainExceedanceList() 2Where

        #region Functions private
        private void CheckRainExceedanceFields(List<RainExceedance> rainExceedanceList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // RainExceedance fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // RainExceedanceWeb and RainExceedanceReport fields should be null here
                Assert.IsNull(rainExceedanceList[0].RainExceedanceWeb);
                Assert.IsNull(rainExceedanceList[0].RainExceedanceReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // RainExceedanceWeb fields should not be null and RainExceedanceReport fields should be null here
                if (!string.IsNullOrWhiteSpace(rainExceedanceList[0].RainExceedanceWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].RainExceedanceWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(rainExceedanceList[0].RainExceedanceReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // RainExceedanceWeb and RainExceedanceReport fields should NOT be null here
                if (rainExceedanceList[0].RainExceedanceWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].RainExceedanceWeb.LastUpdateContactTVText));
                }
                if (rainExceedanceList[0].RainExceedanceReport.RainExceedanceReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(rainExceedanceList[0].RainExceedanceReport.RainExceedanceReportTest));
                }
            }
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
