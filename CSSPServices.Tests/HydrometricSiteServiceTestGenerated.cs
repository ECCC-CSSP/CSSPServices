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
    public partial class HydrometricSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private HydrometricSiteService hydrometricSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteServiceTest() : base()
        {
            //hydrometricSiteService = new HydrometricSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void HydrometricSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = hydrometricSiteService.GetRead().Count();

                    Assert.AreEqual(hydrometricSiteService.GetRead().Count(), hydrometricSiteService.GetEdit().Count());

                    hydrometricSiteService.Add(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, hydrometricSiteService.GetRead().Where(c => c == hydrometricSite).Any());
                    hydrometricSiteService.Update(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, hydrometricSiteService.GetRead().Count());
                    hydrometricSiteService.Delete(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // hydrometricSite.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteID = 0;
                    hydrometricSiteService.Update(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricSiteHydrometricSiteID), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteID = 10000000;
                    hydrometricSiteService.Update(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricSite, CSSPModelsRes.HydrometricSiteHydrometricSiteID, hydrometricSite.HydrometricSiteID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
                    // hydrometricSite.HydrometricSiteTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteTVItemID = 0;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.HydrometricSiteHydrometricSiteTVItemID, hydrometricSite.HydrometricSiteTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteTVItemID = 1;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.HydrometricSiteHydrometricSiteTVItemID, "HydrometricSite"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(7))]
                    // hydrometricSite.FedSiteNumber   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.FedSiteNumber = GetRandomString("", 8);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricSiteFedSiteNumber, "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(7))]
                    // hydrometricSite.QuebecSiteNumber   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.QuebecSiteNumber = GetRandomString("", 8);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricSiteQuebecSiteNumber, "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // hydrometricSite.HydrometricSiteName   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
                    Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricSiteHydrometricSiteName)).Any());
                    Assert.AreEqual(null, hydrometricSite.HydrometricSiteName);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteName = GetRandomString("", 201);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricSiteHydrometricSiteName, "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200))]
                    // hydrometricSite.Description   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Description = GetRandomString("", 201);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricSiteDescription, "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(4))]
                    // hydrometricSite.Province   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("Province");
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
                    Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricSiteProvince)).Any());
                    Assert.AreEqual(null, hydrometricSite.Province);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Province = GetRandomString("", 5);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricSiteProvince, "4"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // hydrometricSite.Elevation_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Elevation_m]

                    //Error: Type not implemented [Elevation_m]

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Elevation_m = -1.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteElevation_m, "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Elevation_m = 10001.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteElevation_m, "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1849)]
                    // hydrometricSite.StartDate_Local   (DateTime)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.StartDate_Local = new DateTime(1848, 1, 1);
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricSiteStartDate_Local, "1849"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1849)]
                    // [CSSPBigger(OtherField = StartDate_Local)]
                    // hydrometricSite.EndDate_Local   (DateTime)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.EndDate_Local = new DateTime(1848, 1, 1);
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricSiteEndDate_Local, "1849"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 0)]
                    // hydrometricSite.TimeOffset_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TimeOffset_hour]

                    //Error: Type not implemented [TimeOffset_hour]

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.TimeOffset_hour = -11.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.TimeOffset_hour = 1.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // hydrometricSite.DrainageArea_km2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DrainageArea_km2]

                    //Error: Type not implemented [DrainageArea_km2]

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.DrainageArea_km2 = -1.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.DrainageArea_km2 = 1000001.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.IsNatural   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.IsActive   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.Sediment   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.RHBN   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.RealTime   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.HasRatingCurve   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // hydrometricSite.HydrometricSiteWeb   (HydrometricSiteWeb)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteWeb = null;
                    Assert.IsNull(hydrometricSite.HydrometricSiteWeb);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteWeb = new HydrometricSiteWeb();
                    Assert.IsNotNull(hydrometricSite.HydrometricSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // hydrometricSite.HydrometricSiteReport   (HydrometricSiteReport)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteReport = null;
                    Assert.IsNull(hydrometricSite.HydrometricSiteReport);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteReport = new HydrometricSiteReport();
                    Assert.IsNotNull(hydrometricSite.HydrometricSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateDate_UTC = new DateTime();
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricSiteLastUpdateDate_UTC), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricSiteLastUpdateDate_UTC, "1980"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // hydrometricSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateContactTVItemID = 0;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.HydrometricSiteLastUpdateContactTVItemID, hydrometricSite.LastUpdateContactTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateContactTVItemID = 1;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.HydrometricSiteLastUpdateContactTVItemID, "Contact"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID)
        [TestMethod]
        public void GetHydrometricSiteWithHydrometricSiteID__hydrometricSite_HydrometricSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricSite hydrometricSite = (from c in hydrometricSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    HydrometricSite hydrometricSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        hydrometricSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                            Assert.IsNull(hydrometricSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(new List<HydrometricSite>() { hydrometricSiteRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID)

        #region Tests Generated for GetHydrometricSiteList()
        [TestMethod]
        public void GetHydrometricSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricSite hydrometricSite = (from c in hydrometricSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        hydrometricSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList()

        #region Tests Generated for GetHydrometricSiteList() Skip Take
        [TestMethod]
        public void GetHydrometricSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(1, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() Skip Take

        #region Tests Generated for GetHydrometricSiteList() Skip Take Order
        [TestMethod]
        public void GetHydrometricSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1,  "HydrometricSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(1, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() Skip Take Order

        #region Tests Generated for GetHydrometricSiteList() Skip Take 2Order
        [TestMethod]
        public void GetHydrometricSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1, "HydrometricSiteID,HydrometricSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.HydrometricSiteID).ThenBy(c => c.HydrometricSiteTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(1, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() Skip Take 2Order

        #region Tests Generated for GetHydrometricSiteList() Skip Take Order Where
        [TestMethod]
        public void GetHydrometricSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricSiteID", "HydrometricSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Where(c => c.HydrometricSiteID == 4).Skip(0).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(1, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() Skip Take Order Where

        #region Tests Generated for GetHydrometricSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetHydrometricSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricSiteID", "HydrometricSiteID,GT,2|HydrometricSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Where(c => c.HydrometricSiteID > 2 && c.HydrometricSiteID < 5).Skip(0).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(1, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() Skip Take Order 2Where

        #region Tests Generated for GetHydrometricSiteList() 2Where
        [TestMethod]
        public void GetHydrometricSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "HydrometricSiteID,GT,2|HydrometricSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        hydrometricSiteDirectQueryList = hydrometricSiteService.GetRead().Where(c => c.HydrometricSiteID > 2 && c.HydrometricSiteID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            Assert.AreEqual(0, hydrometricSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckHydrometricSiteFields(hydrometricSiteList, entityQueryDetailType);
                        Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        Assert.AreEqual(2, hydrometricSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() 2Where

        #region Functions private
        private void CheckHydrometricSiteFields(List<HydrometricSite> hydrometricSiteList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // HydrometricSite fields
            Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].FedSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].FedSiteNumber));
            }
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].QuebecSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].QuebecSiteNumber));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].HydrometricSiteName));
            if (!string.IsNullOrWhiteSpace(hydrometricSiteList[0].Description))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].Description));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].Province));
            if (hydrometricSiteList[0].Elevation_m != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].Elevation_m);
            }
            if (hydrometricSiteList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].StartDate_Local);
            }
            if (hydrometricSiteList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].EndDate_Local);
            }
            if (hydrometricSiteList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].TimeOffset_hour);
            }
            if (hydrometricSiteList[0].DrainageArea_km2 != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].DrainageArea_km2);
            }
            if (hydrometricSiteList[0].IsNatural != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].IsNatural);
            }
            if (hydrometricSiteList[0].IsActive != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].IsActive);
            }
            if (hydrometricSiteList[0].Sediment != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].Sediment);
            }
            if (hydrometricSiteList[0].RHBN != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].RHBN);
            }
            if (hydrometricSiteList[0].RealTime != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].RealTime);
            }
            if (hydrometricSiteList[0].HasRatingCurve != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].HasRatingCurve);
            }
            Assert.IsNotNull(hydrometricSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricSiteList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // HydrometricSiteWeb and HydrometricSiteReport fields should be null here
                Assert.IsNull(hydrometricSiteList[0].HydrometricSiteWeb);
                Assert.IsNull(hydrometricSiteList[0].HydrometricSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // HydrometricSiteWeb fields should not be null and HydrometricSiteReport fields should be null here
                Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteWeb.HydrometricTVItemLanguage);
                Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(hydrometricSiteList[0].HydrometricSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // HydrometricSiteWeb and HydrometricSiteReport fields should NOT be null here
                Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteWeb.HydrometricTVItemLanguage);
                Assert.IsNotNull(hydrometricSiteList[0].HydrometricSiteWeb.LastUpdateContactTVItemLanguage);
                if (hydrometricSiteList[0].HydrometricSiteReport.HydrometricSiteReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSiteList[0].HydrometricSiteReport.HydrometricSiteReportTest));
                }
            }
        }
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
            HydrometricSite hydrometricSite = new HydrometricSite();

            if (OmitPropName != "HydrometricSiteTVItemID") hydrometricSite.HydrometricSiteTVItemID = 8;
            if (OmitPropName != "FedSiteNumber") hydrometricSite.FedSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "QuebecSiteNumber") hydrometricSite.QuebecSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "HydrometricSiteName") hydrometricSite.HydrometricSiteName = GetRandomString("", 5);
            if (OmitPropName != "Description") hydrometricSite.Description = GetRandomString("", 5);
            if (OmitPropName != "Province") hydrometricSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            return hydrometricSite;
        }
        #endregion Functions private
    }
}
