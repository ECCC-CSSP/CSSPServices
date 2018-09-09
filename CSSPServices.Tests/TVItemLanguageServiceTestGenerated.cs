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
    public partial class TVItemLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLanguageService tvItemLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageServiceTest() : base()
        {
            //tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemLanguageService.GetTVItemLanguageList().Count();

                    Assert.AreEqual(tvItemLanguageService.GetTVItemLanguageList().Count(), (from c in dbTestDB.TVItemLanguages select c).Take(200).Count());

                    tvItemLanguageService.Add(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemLanguageService.GetTVItemLanguageList().Where(c => c == tvItemLanguage).Any());
                    tvItemLanguageService.Update(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemLanguageService.GetTVItemLanguageList().Count());
                    tvItemLanguageService.Delete(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemLanguageService.GetTVItemLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemLanguage.TVItemLanguageID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageID = 0;
                    tvItemLanguageService.Update(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLanguageTVItemLanguageID"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageID = 10000000;
                    tvItemLanguageService.Update(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageTVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
                    // tvItemLanguage.TVItemID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemID = 0;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLanguageTVItemID", tvItemLanguage.TVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemID = 37;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLanguageTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.Language = (LanguageEnum)1000000;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLanguageLanguage"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // tvItemLanguage.TVText   (String)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
                    Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                    Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
                    Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TVItemLanguageTVText")).Any());
                    Assert.AreEqual(null, tvItemLanguage.TVText);
                    Assert.AreEqual(count, tvItemLanguageService.GetTVItemLanguageList().Count());

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemLanguageTVText", "200"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLanguageService.GetTVItemLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLanguageTranslationStatus"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateDate_UTC = new DateTime();
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLanguageLastUpdateDate_UTC"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLanguageLastUpdateDate_UTC", "1980"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateContactTVItemID = 0;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLanguageLastUpdateContactTVItemID", tvItemLanguage.LastUpdateContactTVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateContactTVItemID = 1;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLanguageLastUpdateContactTVItemID", "Contact"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID)
        [TestMethod]
        public void GetTVItemLanguageWithTVItemLanguageID__tvItemLanguage_TVItemLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLanguage tvItemLanguage = (from c in dbTestDB.TVItemLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLanguage);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TVItemLanguage tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                            CheckTVItemLanguageFields(new List<TVItemLanguage>() { tvItemLanguageRet });
                            Assert.AreEqual(tvItemLanguage.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            TVItemLanguage_A tvItemLanguage_ARet = tvItemLanguageService.GetTVItemLanguage_AWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                            CheckTVItemLanguage_AFields(new List<TVItemLanguage_A>() { tvItemLanguage_ARet });
                            Assert.AreEqual(tvItemLanguage.TVItemLanguageID, tvItemLanguage_ARet.TVItemLanguageID);
                        }
                        else if (detail == "B")
                        {
                            TVItemLanguage_B tvItemLanguage_BRet = tvItemLanguageService.GetTVItemLanguage_BWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                            CheckTVItemLanguage_BFields(new List<TVItemLanguage_B>() { tvItemLanguage_BRet });
                            Assert.AreEqual(tvItemLanguage.TVItemLanguageID, tvItemLanguage_BRet.TVItemLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID)

        #region Tests Generated for GetTVItemLanguageList()
        [TestMethod]
        public void GetTVItemLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLanguage tvItemLanguage = (from c in dbTestDB.TVItemLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLanguage);

                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvItemLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList()

        #region Tests Generated for GetTVItemLanguageList() Skip Take
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemLanguageID", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Skip(1).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order

        #region Tests Generated for GetTVItemLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1, "TVItemLanguageID,TVItemID", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Skip(1).Take(1).OrderBy(c => c.TVItemLanguageID).ThenBy(c => c.TVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take 2Order

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLanguageID", "TVItemLanguageID,EQ,4", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Where(c => c.TVItemLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order Where

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLanguageID", "TVItemLanguageID,GT,2|TVItemLanguageID,LT,5", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Where(c => c.TVItemLanguageID > 2 && c.TVItemLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemLanguageList() 2Where
        [TestMethod]
        public void GetTVItemLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemLanguageID,GT,2|TVItemLanguageID,LT,5", "");

                        List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                        tvItemLanguageDirectQueryList = (from c in dbTestDB.TVItemLanguages select c).Where(c => c.TVItemLanguageID > 2 && c.TVItemLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            CheckTVItemLanguageFields(tvItemLanguageList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVItemLanguage_A> tvItemLanguage_AList = new List<TVItemLanguage_A>();
                            tvItemLanguage_AList = tvItemLanguageService.GetTVItemLanguage_AList().ToList();
                            CheckTVItemLanguage_AFields(tvItemLanguage_AList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_AList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVItemLanguage_B> tvItemLanguage_BList = new List<TVItemLanguage_B>();
                            tvItemLanguage_BList = tvItemLanguageService.GetTVItemLanguage_BList().ToList();
                            CheckTVItemLanguage_BFields(tvItemLanguage_BList);
                            Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguage_BList[0].TVItemLanguageID);
                            Assert.AreEqual(tvItemLanguageDirectQueryList.Count, tvItemLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() 2Where

        #region Functions private
        private void CheckTVItemLanguageFields(List<TVItemLanguage> tvItemLanguageList)
        {
            Assert.IsNotNull(tvItemLanguageList[0].TVItemLanguageID);
            Assert.IsNotNull(tvItemLanguageList[0].TVItemID);
            Assert.IsNotNull(tvItemLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVText));
            Assert.IsNotNull(tvItemLanguageList[0].TranslationStatus);
            Assert.IsNotNull(tvItemLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLanguageList[0].HasErrors);
        }
        private void CheckTVItemLanguage_AFields(List<TVItemLanguage_A> tvItemLanguage_AList)
        {
            Assert.IsNotNull(tvItemLanguage_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemLanguage_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvItemLanguage_AList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_AList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvItemLanguage_AList[0].TVItemLanguageID);
            Assert.IsNotNull(tvItemLanguage_AList[0].TVItemID);
            Assert.IsNotNull(tvItemLanguage_AList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_AList[0].TVText));
            Assert.IsNotNull(tvItemLanguage_AList[0].TranslationStatus);
            Assert.IsNotNull(tvItemLanguage_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLanguage_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLanguage_AList[0].HasErrors);
        }
        private void CheckTVItemLanguage_BFields(List<TVItemLanguage_B> tvItemLanguage_BList)
        {
            if (!string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].TVItemLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].TVItemLanguageReportTest));
            }
            Assert.IsNotNull(tvItemLanguage_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvItemLanguage_BList[0].TVItemLanguageID);
            Assert.IsNotNull(tvItemLanguage_BList[0].TVItemID);
            Assert.IsNotNull(tvItemLanguage_BList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguage_BList[0].TVText));
            Assert.IsNotNull(tvItemLanguage_BList[0].TranslationStatus);
            Assert.IsNotNull(tvItemLanguage_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLanguage_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemLanguage_BList[0].HasErrors);
        }
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = LanguageRequest;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;

            return tvItemLanguage;
        }
        #endregion Functions private
    }
}
