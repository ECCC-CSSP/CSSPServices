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
    public partial class ClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ClimateSiteService climateSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteServiceTest() : base()
        {
            //climateSiteService = new ClimateSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ClimateSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ClimateSite climateSite = GetFilledRandomClimateSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = climateSiteService.GetRead().Count();

                    Assert.AreEqual(climateSiteService.GetRead().Count(), climateSiteService.GetEdit().Count());

                    climateSiteService.Add(climateSite);
                    if (climateSite.HasErrors)
                    {
                        Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, climateSiteService.GetRead().Where(c => c == climateSite).Any());
                    climateSiteService.Update(climateSite);
                    if (climateSite.HasErrors)
                    {
                        Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, climateSiteService.GetRead().Count());
                    climateSiteService.Delete(climateSite);
                    if (climateSite.HasErrors)
                    {
                        Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // climateSite.ClimateSiteID   (Int32)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteID = 0;
                    climateSiteService.Update(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteClimateSiteID), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteID = 10000000;
                    climateSiteService.Update(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateSite, CSSPModelsRes.ClimateSiteClimateSiteID, climateSite.ClimateSiteID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite)]
                    // climateSite.ClimateSiteTVItemID   (Int32)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteTVItemID = 0;
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateSiteClimateSiteTVItemID, climateSite.ClimateSiteTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteTVItemID = 1;
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateSiteClimateSiteTVItemID, "ClimateSite"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100000)]
                    // climateSite.ECDBID   (Int32)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ECDBID = 0;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteECDBID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());
                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ECDBID = 100001;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteECDBID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // climateSite.ClimateSiteName   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("ClimateSiteName");
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(1, climateSite.ValidationResults.Count());
                    Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteClimateSiteName)).Any());
                    Assert.AreEqual(null, climateSite.ClimateSiteName);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteName = GetRandomString("", 101);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteClimateSiteName, "100"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(4))]
                    // climateSite.Province   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("Province");
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(1, climateSite.ValidationResults.Count());
                    Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteProvince)).Any());
                    Assert.AreEqual(null, climateSite.Province);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.Province = GetRandomString("", 5);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteProvince, "4"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateSite.Elevation_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Elevation_m]

                    //Error: Type not implemented [Elevation_m]

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.Elevation_m = -1.0D;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteElevation_m, "0", "10000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());
                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.Elevation_m = 10001.0D;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteElevation_m, "0", "10000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // climateSite.ClimateID   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateID = GetRandomString("", 11);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteClimateID, "10"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 100000)]
                    // climateSite.WMOID   (Int32)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.WMOID = 0;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteWMOID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());
                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.WMOID = 100001;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteWMOID, "1", "100000"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(3))]
                    // climateSite.TCID   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.TCID = GetRandomString("", 4);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteTCID, "3"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // climateSite.IsProvincial   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // climateSite.ProvSiteID   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ProvSiteID = GetRandomString("", 51);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteProvSiteID, "50"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 0)]
                    // climateSite.TimeOffset_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TimeOffset_hour]

                    //Error: Type not implemented [TimeOffset_hour]

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.TimeOffset_hour = -11.0D;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());
                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.TimeOffset_hour = 1.0D;
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // climateSite.File_desc   (String)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.File_desc = GetRandomString("", 51);
                    Assert.AreEqual(false, climateSiteService.Add(climateSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteFile_desc, "50"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.HourlyStartDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.HourlyStartDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteHourlyStartDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.HourlyEndDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.HourlyEndDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteHourlyEndDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // climateSite.HourlyNow   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.DailyStartDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.DailyStartDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteDailyStartDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.DailyEndDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.DailyEndDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteDailyEndDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // climateSite.DailyNow   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.MonthlyStartDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.MonthlyStartDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteMonthlyStartDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.MonthlyEndDate_Local   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.MonthlyEndDate_Local = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteMonthlyEndDate_Local, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // climateSite.MonthlyNow   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // climateSite.ClimateSiteWeb   (ClimateSiteWeb)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteWeb = null;
                    Assert.IsNull(climateSite.ClimateSiteWeb);

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteWeb = new ClimateSiteWeb();
                    Assert.IsNotNull(climateSite.ClimateSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // climateSite.ClimateSiteReport   (ClimateSiteReport)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteReport = null;
                    Assert.IsNull(climateSite.ClimateSiteReport);

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.ClimateSiteReport = new ClimateSiteReport();
                    Assert.IsNotNull(climateSite.ClimateSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.LastUpdateDate_UTC = new DateTime();
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteLastUpdateDate_UTC), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteLastUpdateDate_UTC, "1980"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // climateSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.LastUpdateContactTVItemID = 0;
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateSiteLastUpdateContactTVItemID, climateSite.LastUpdateContactTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    climateSite = null;
                    climateSite = GetFilledRandomClimateSite("");
                    climateSite.LastUpdateContactTVItemID = 1;
                    climateSiteService.Add(climateSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateSiteLastUpdateContactTVItemID, "Contact"), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID)
        [TestMethod]
        public void GetClimateSiteWithClimateSiteID__climateSite_ClimateSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ClimateSite climateSite = (from c in climateSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(climateSite);

                    ClimateSite climateSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        climateSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteRet = climateSiteService.GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID);
                            Assert.IsNull(climateSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteRet = climateSiteService.GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteRet = climateSiteService.GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteRet = climateSiteService.GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(new List<ClimateSite>() { climateSiteRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteWithClimateSiteID(climateSite.ClimateSiteID)

        #region Tests Generated for GetClimateSiteList()
        [TestMethod]
        public void GetClimateSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ClimateSite climateSite = (from c in climateSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(climateSite);

                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        climateSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList()

        #region Tests Generated for GetClimateSiteList() Skip Take
        [TestMethod]
        public void GetClimateSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(1, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() Skip Take

        #region Tests Generated for GetClimateSiteList() Skip Take Order
        [TestMethod]
        public void GetClimateSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 1, 1,  "ClimateSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.ClimateSiteID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(1, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() Skip Take Order

        #region Tests Generated for GetClimateSiteList() Skip Take 2Order
        [TestMethod]
        public void GetClimateSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 1, 1, "ClimateSiteID,ClimateSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.ClimateSiteID).ThenBy(c => c.ClimateSiteTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(1, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() Skip Take 2Order

        #region Tests Generated for GetClimateSiteList() Skip Take Order Where
        [TestMethod]
        public void GetClimateSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 0, 1, "ClimateSiteID", "ClimateSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Where(c => c.ClimateSiteID == 4).Skip(0).Take(1).OrderBy(c => c.ClimateSiteID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(1, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() Skip Take Order Where

        #region Tests Generated for GetClimateSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetClimateSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 0, 1, "ClimateSiteID", "ClimateSiteID,GT,2|ClimateSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Where(c => c.ClimateSiteID > 2 && c.ClimateSiteID < 5).Skip(0).Take(1).OrderBy(c => c.ClimateSiteID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(1, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() Skip Take Order 2Where

        #region Tests Generated for GetClimateSiteList() 2Where
        [TestMethod]
        public void GetClimateSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    List<ClimateSite> climateSiteDirectQueryList = new List<ClimateSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateSiteService.Query = climateSiteService.FillQuery(typeof(ClimateSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "ClimateSiteID,GT,2|ClimateSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateSiteDirectQueryList = climateSiteService.GetRead().Where(c => c.ClimateSiteID > 2 && c.ClimateSiteID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                            Assert.AreEqual(0, climateSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateSiteList = climateSiteService.GetClimateSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateSiteFields(climateSiteList, entityQueryDetailType);
                        Assert.AreEqual(climateSiteDirectQueryList[0].ClimateSiteID, climateSiteList[0].ClimateSiteID);
                        Assert.AreEqual(2, climateSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateSiteList() 2Where

        #region Functions private
        private void CheckClimateSiteFields(List<ClimateSite> climateSiteList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // ClimateSite fields
            Assert.IsNotNull(climateSiteList[0].ClimateSiteID);
            Assert.IsNotNull(climateSiteList[0].ClimateSiteTVItemID);
            Assert.IsNotNull(climateSiteList[0].ECDBID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].Province));
            if (climateSiteList[0].Elevation_m != null)
            {
                Assert.IsNotNull(climateSiteList[0].Elevation_m);
            }
            if (!string.IsNullOrWhiteSpace(climateSiteList[0].ClimateID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateID));
            }
            if (climateSiteList[0].WMOID != null)
            {
                Assert.IsNotNull(climateSiteList[0].WMOID);
            }
            if (!string.IsNullOrWhiteSpace(climateSiteList[0].TCID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].TCID));
            }
            if (climateSiteList[0].IsProvincial != null)
            {
                Assert.IsNotNull(climateSiteList[0].IsProvincial);
            }
            if (!string.IsNullOrWhiteSpace(climateSiteList[0].ProvSiteID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ProvSiteID));
            }
            if (climateSiteList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(climateSiteList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(climateSiteList[0].File_desc))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].File_desc));
            }
            if (climateSiteList[0].HourlyStartDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].HourlyStartDate_Local);
            }
            if (climateSiteList[0].HourlyEndDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].HourlyEndDate_Local);
            }
            if (climateSiteList[0].HourlyNow != null)
            {
                Assert.IsNotNull(climateSiteList[0].HourlyNow);
            }
            if (climateSiteList[0].DailyStartDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].DailyStartDate_Local);
            }
            if (climateSiteList[0].DailyEndDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].DailyEndDate_Local);
            }
            if (climateSiteList[0].DailyNow != null)
            {
                Assert.IsNotNull(climateSiteList[0].DailyNow);
            }
            if (climateSiteList[0].MonthlyStartDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].MonthlyStartDate_Local);
            }
            if (climateSiteList[0].MonthlyEndDate_Local != null)
            {
                Assert.IsNotNull(climateSiteList[0].MonthlyEndDate_Local);
            }
            if (climateSiteList[0].MonthlyNow != null)
            {
                Assert.IsNotNull(climateSiteList[0].MonthlyNow);
            }
            Assert.IsNotNull(climateSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(climateSiteList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // ClimateSiteWeb and ClimateSiteReport fields should be null here
                Assert.IsNull(climateSiteList[0].ClimateSiteWeb);
                Assert.IsNull(climateSiteList[0].ClimateSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // ClimateSiteWeb fields should not be null and ClimateSiteReport fields should be null here
                if (!string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.ClimateSiteTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.ClimateSiteTVText));
                }
                if (!string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(climateSiteList[0].ClimateSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // ClimateSiteWeb and ClimateSiteReport fields should NOT be null here
                if (climateSiteList[0].ClimateSiteWeb.ClimateSiteTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.ClimateSiteTVText));
                }
                if (climateSiteList[0].ClimateSiteWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteWeb.LastUpdateContactTVText));
                }
                if (climateSiteList[0].ClimateSiteReport.ClimateSiteReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateSiteList[0].ClimateSiteReport.ClimateSiteReportTest));
                }
            }
        }
        private ClimateSite GetFilledRandomClimateSite(string OmitPropName)
        {
            ClimateSite climateSite = new ClimateSite();

            if (OmitPropName != "ClimateSiteTVItemID") climateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 100000);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 100000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsProvincial") climateSite.IsProvincial = true;
            if (OmitPropName != "ProvSiteID") climateSite.ProvSiteID = GetRandomString("", 5);
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "File_desc") climateSite.File_desc = GetRandomString("", 5);
            if (OmitPropName != "HourlyStartDate_Local") climateSite.HourlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "HourlyEndDate_Local") climateSite.HourlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "HourlyNow") climateSite.HourlyNow = true;
            if (OmitPropName != "DailyStartDate_Local") climateSite.DailyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyEndDate_Local") climateSite.DailyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "DailyNow") climateSite.DailyNow = true;
            if (OmitPropName != "MonthlyStartDate_Local") climateSite.MonthlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MonthlyEndDate_Local") climateSite.MonthlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "MonthlyNow") climateSite.MonthlyNow = true;
            if (OmitPropName != "LastUpdateDate_UTC") climateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateSite.LastUpdateContactTVItemID = 2;

            return climateSite;
        }
        #endregion Functions private
    }
}
