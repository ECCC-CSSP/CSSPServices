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

                    count = hydrometricSiteService.GetHydrometricSiteList().Count();

                    Assert.AreEqual(hydrometricSiteService.GetHydrometricSiteList().Count(), (from c in dbTestDB.HydrometricSites select c).Take(200).Count());

                    hydrometricSiteService.Add(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, hydrometricSiteService.GetHydrometricSiteList().Where(c => c == hydrometricSite).Any());
                    hydrometricSiteService.Update(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, hydrometricSiteService.GetHydrometricSiteList().Count());
                    hydrometricSiteService.Delete(hydrometricSite);
                    if (hydrometricSite.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteHydrometricSiteID"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteID = 10000000;
                    hydrometricSiteService.Update(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteHydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
                    // hydrometricSite.HydrometricSiteTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteTVItemID = 0;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteHydrometricSiteTVItemID", hydrometricSite.HydrometricSiteTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteTVItemID = 1;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricSiteHydrometricSiteTVItemID", "HydrometricSite"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(7))]
                    // hydrometricSite.FedSiteNumber   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.FedSiteNumber = GetRandomString("", 8);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteFedSiteNumber", "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(7))]
                    // hydrometricSite.QuebecSiteNumber   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.QuebecSiteNumber = GetRandomString("", 8);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteQuebecSiteNumber", "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // hydrometricSite.HydrometricSiteName   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
                    Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteHydrometricSiteName")).Any());
                    Assert.AreEqual(null, hydrometricSite.HydrometricSiteName);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.HydrometricSiteName = GetRandomString("", 201);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteHydrometricSiteName", "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200))]
                    // hydrometricSite.Description   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Description = GetRandomString("", 201);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteDescription", "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(4))]
                    // hydrometricSite.Province   (String)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("Province");
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
                    Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteProvince")).Any());
                    Assert.AreEqual(null, hydrometricSite.Province);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Province = GetRandomString("", 5);
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteProvince", "4"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteElevation_m", "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.Elevation_m = 10001.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteElevation_m", "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1849)]
                    // hydrometricSite.StartDate_Local   (DateTime)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.StartDate_Local = new DateTime(1848, 1, 1);
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteStartDate_Local", "1849"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteEndDate_Local", "1849"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteTimeOffset_hour", "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.TimeOffset_hour = 1.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteTimeOffset_hour", "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteDrainageArea_km2", "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.DrainageArea_km2 = 1000001.0D;
                    Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteDrainageArea_km2", "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricSiteService.GetHydrometricSiteList().Count());

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
                    // hydrometricSite.HasDischarge   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.HasLevel   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // hydrometricSite.HasRatingCurve   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateDate_UTC = new DateTime();
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteLastUpdateDate_UTC"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteLastUpdateDate_UTC", "1980"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // hydrometricSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateContactTVItemID = 0;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteLastUpdateContactTVItemID", hydrometricSite.LastUpdateContactTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricSite = null;
                    hydrometricSite = GetFilledRandomHydrometricSite("");
                    hydrometricSite.LastUpdateContactTVItemID = 1;
                    hydrometricSiteService.Add(hydrometricSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricSiteLastUpdateContactTVItemID", "Contact"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    HydrometricSite hydrometricSite = (from c in dbTestDB.HydrometricSites select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        hydrometricSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            HydrometricSite hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                            CheckHydrometricSiteFields(new List<HydrometricSite>() { hydrometricSiteRet });
                            Assert.AreEqual(hydrometricSite.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            HydrometricSite_A hydrometricSite_ARet = hydrometricSiteService.GetHydrometricSite_AWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                            CheckHydrometricSite_AFields(new List<HydrometricSite_A>() { hydrometricSite_ARet });
                            Assert.AreEqual(hydrometricSite.HydrometricSiteID, hydrometricSite_ARet.HydrometricSiteID);
                        }
                        else if (detail == "B")
                        {
                            HydrometricSite_B hydrometricSite_BRet = hydrometricSiteService.GetHydrometricSite_BWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                            CheckHydrometricSite_BFields(new List<HydrometricSite_B>() { hydrometricSite_BRet });
                            Assert.AreEqual(hydrometricSite.HydrometricSiteID, hydrometricSite_BRet.HydrometricSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    HydrometricSite hydrometricSite = (from c in dbTestDB.HydrometricSites select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                    hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        hydrometricSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1,  "HydrometricSiteID", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Skip(1).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 1, 1, "HydrometricSiteID,HydrometricSiteTVItemID", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Skip(1).Take(1).OrderBy(c => c.HydrometricSiteID).ThenBy(c => c.HydrometricSiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricSiteID", "HydrometricSiteID,EQ,4", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Where(c => c.HydrometricSiteID == 4).Skip(0).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricSiteID", "HydrometricSiteID,GT,2|HydrometricSiteID,LT,5", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Where(c => c.HydrometricSiteID > 2 && c.HydrometricSiteID < 5).Skip(0).Take(1).OrderBy(c => c.HydrometricSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricSiteService.Query = hydrometricSiteService.FillQuery(typeof(HydrometricSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "HydrometricSiteID,GT,2|HydrometricSiteID,LT,5", "");

                        List<HydrometricSite> hydrometricSiteDirectQueryList = new List<HydrometricSite>();
                        hydrometricSiteDirectQueryList = (from c in dbTestDB.HydrometricSites select c).Where(c => c.HydrometricSiteID > 2 && c.HydrometricSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<HydrometricSite> hydrometricSiteList = new List<HydrometricSite>();
                            hydrometricSiteList = hydrometricSiteService.GetHydrometricSiteList().ToList();
                            CheckHydrometricSiteFields(hydrometricSiteList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSiteList[0].HydrometricSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<HydrometricSite_A> hydrometricSite_AList = new List<HydrometricSite_A>();
                            hydrometricSite_AList = hydrometricSiteService.GetHydrometricSite_AList().ToList();
                            CheckHydrometricSite_AFields(hydrometricSite_AList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_AList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<HydrometricSite_B> hydrometricSite_BList = new List<HydrometricSite_B>();
                            hydrometricSite_BList = hydrometricSiteService.GetHydrometricSite_BList().ToList();
                            CheckHydrometricSite_BFields(hydrometricSite_BList);
                            Assert.AreEqual(hydrometricSiteDirectQueryList[0].HydrometricSiteID, hydrometricSite_BList[0].HydrometricSiteID);
                            Assert.AreEqual(hydrometricSiteDirectQueryList.Count, hydrometricSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricSiteList() 2Where

        #region Functions private
        private void CheckHydrometricSiteFields(List<HydrometricSite> hydrometricSiteList)
        {
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
            if (hydrometricSiteList[0].HasDischarge != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].HasDischarge);
            }
            if (hydrometricSiteList[0].HasLevel != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].HasLevel);
            }
            if (hydrometricSiteList[0].HasRatingCurve != null)
            {
                Assert.IsNotNull(hydrometricSiteList[0].HasRatingCurve);
            }
            Assert.IsNotNull(hydrometricSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricSiteList[0].HasErrors);
        }
        private void CheckHydrometricSite_AFields(List<HydrometricSite_A> hydrometricSite_AList)
        {
            Assert.IsNotNull(hydrometricSite_AList[0].HydrometricTVItemLanguage);
            Assert.IsNotNull(hydrometricSite_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(hydrometricSite_AList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricSite_AList[0].HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(hydrometricSite_AList[0].FedSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_AList[0].FedSiteNumber));
            }
            if (!string.IsNullOrWhiteSpace(hydrometricSite_AList[0].QuebecSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_AList[0].QuebecSiteNumber));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_AList[0].HydrometricSiteName));
            if (!string.IsNullOrWhiteSpace(hydrometricSite_AList[0].Description))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_AList[0].Description));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_AList[0].Province));
            if (hydrometricSite_AList[0].Elevation_m != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].Elevation_m);
            }
            if (hydrometricSite_AList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].StartDate_Local);
            }
            if (hydrometricSite_AList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].EndDate_Local);
            }
            if (hydrometricSite_AList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].TimeOffset_hour);
            }
            if (hydrometricSite_AList[0].DrainageArea_km2 != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].DrainageArea_km2);
            }
            if (hydrometricSite_AList[0].IsNatural != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].IsNatural);
            }
            if (hydrometricSite_AList[0].IsActive != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].IsActive);
            }
            if (hydrometricSite_AList[0].Sediment != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].Sediment);
            }
            if (hydrometricSite_AList[0].RHBN != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].RHBN);
            }
            if (hydrometricSite_AList[0].RealTime != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].RealTime);
            }
            if (hydrometricSite_AList[0].HasDischarge != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].HasDischarge);
            }
            if (hydrometricSite_AList[0].HasLevel != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].HasLevel);
            }
            if (hydrometricSite_AList[0].HasRatingCurve != null)
            {
                Assert.IsNotNull(hydrometricSite_AList[0].HasRatingCurve);
            }
            Assert.IsNotNull(hydrometricSite_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricSite_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricSite_AList[0].HasErrors);
        }
        private void CheckHydrometricSite_BFields(List<HydrometricSite_B> hydrometricSite_BList)
        {
            if (!string.IsNullOrWhiteSpace(hydrometricSite_BList[0].HydrometricSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].HydrometricSiteReportTest));
            }
            Assert.IsNotNull(hydrometricSite_BList[0].HydrometricTVItemLanguage);
            Assert.IsNotNull(hydrometricSite_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(hydrometricSite_BList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricSite_BList[0].HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(hydrometricSite_BList[0].FedSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].FedSiteNumber));
            }
            if (!string.IsNullOrWhiteSpace(hydrometricSite_BList[0].QuebecSiteNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].QuebecSiteNumber));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].HydrometricSiteName));
            if (!string.IsNullOrWhiteSpace(hydrometricSite_BList[0].Description))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].Description));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricSite_BList[0].Province));
            if (hydrometricSite_BList[0].Elevation_m != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].Elevation_m);
            }
            if (hydrometricSite_BList[0].StartDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].StartDate_Local);
            }
            if (hydrometricSite_BList[0].EndDate_Local != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].EndDate_Local);
            }
            if (hydrometricSite_BList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].TimeOffset_hour);
            }
            if (hydrometricSite_BList[0].DrainageArea_km2 != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].DrainageArea_km2);
            }
            if (hydrometricSite_BList[0].IsNatural != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].IsNatural);
            }
            if (hydrometricSite_BList[0].IsActive != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].IsActive);
            }
            if (hydrometricSite_BList[0].Sediment != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].Sediment);
            }
            if (hydrometricSite_BList[0].RHBN != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].RHBN);
            }
            if (hydrometricSite_BList[0].RealTime != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].RealTime);
            }
            if (hydrometricSite_BList[0].HasDischarge != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].HasDischarge);
            }
            if (hydrometricSite_BList[0].HasLevel != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].HasLevel);
            }
            if (hydrometricSite_BList[0].HasRatingCurve != null)
            {
                Assert.IsNotNull(hydrometricSite_BList[0].HasRatingCurve);
            }
            Assert.IsNotNull(hydrometricSite_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricSite_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricSite_BList[0].HasErrors);
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
            if (OmitPropName != "HasDischarge") hydrometricSite.HasDischarge = true;
            if (OmitPropName != "HasLevel") hydrometricSite.HasLevel = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            return hydrometricSite;
        }
        #endregion Functions private
    }
}
