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
    public partial class TVFileLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVFileLanguageService tvFileLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageServiceTest() : base()
        {
            //tvFileLanguageService = new TVFileLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFileLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVFileLanguage tvFileLanguage = GetFilledRandomTVFileLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvFileLanguageService.GetTVFileLanguageList().Count();

                    Assert.AreEqual(tvFileLanguageService.GetTVFileLanguageList().Count(), (from c in dbTestDB.TVFileLanguages select c).Take(200).Count());

                    tvFileLanguageService.Add(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvFileLanguageService.GetTVFileLanguageList().Where(c => c == tvFileLanguage).Any());
                    tvFileLanguageService.Update(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvFileLanguageService.GetTVFileLanguageList().Count());
                    tvFileLanguageService.Delete(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvFileLanguageService.GetTVFileLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvFileLanguage.TVFileLanguageID   (Int32)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageID = 0;
                    tvFileLanguageService.Update(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageTVFileLanguageID"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageID = 10000000;
                    tvFileLanguageService.Update(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageTVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID", AllowableTVtypeList = )]
                    // tvFileLanguage.TVFileID   (Int32)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileID = 0;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileLanguageTVFileID", tvFileLanguage.TVFileID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFileLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.Language = (LanguageEnum)1000000;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageLanguage"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // tvFileLanguage.FileDescription   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFileLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageTranslationStatus"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFileLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateDate_UTC = new DateTime();
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageLastUpdateDate_UTC"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileLanguageLastUpdateDate_UTC", "1980"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvFileLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateContactTVItemID = 0;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileLanguageLastUpdateContactTVItemID", tvFileLanguage.LastUpdateContactTVItemID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateContactTVItemID = 1;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileLanguageLastUpdateContactTVItemID", "Contact"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvFileLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvFileLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID)
        [TestMethod]
        public void GetTVFileLanguageWithTVFileLanguageID__tvFileLanguage_TVFileLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in dbTestDB.TVFileLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvFileLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TVFileLanguage tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguageFields(new List<TVFileLanguage>() { tvFileLanguageRet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            TVFileLanguage_A tvFileLanguage_ARet = tvFileLanguageService.GetTVFileLanguage_AWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguage_AFields(new List<TVFileLanguage_A>() { tvFileLanguage_ARet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguage_ARet.TVFileLanguageID);
                        }
                        else if (detail == "B")
                        {
                            TVFileLanguage_B tvFileLanguage_BRet = tvFileLanguageService.GetTVFileLanguage_BWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguage_BFields(new List<TVFileLanguage_B>() { tvFileLanguage_BRet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguage_BRet.TVFileLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID)

        #region Tests Generated for GetTVFileLanguageList()
        [TestMethod]
        public void GetTVFileLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in dbTestDB.TVFileLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                    tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvFileLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList()

        #region Tests Generated for GetTVFileLanguageList() Skip Take
        [TestMethod]
        public void GetTVFileLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take

        #region Tests Generated for GetTVFileLanguageList() Skip Take Order
        [TestMethod]
        public void GetTVFileLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "TVFileLanguageID", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Skip(1).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take Order

        #region Tests Generated for GetTVFileLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetTVFileLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1, "TVFileLanguageID,TVFileID", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Skip(1).Take(1).OrderBy(c => c.TVFileLanguageID).ThenBy(c => c.TVFileID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take 2Order

        #region Tests Generated for GetTVFileLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetTVFileLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVFileLanguageID", "TVFileLanguageID,EQ,4", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Where(c => c.TVFileLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take Order Where

        #region Tests Generated for GetTVFileLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVFileLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVFileLanguageID", "TVFileLanguageID,GT,2|TVFileLanguageID,LT,5", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Where(c => c.TVFileLanguageID > 2 && c.TVFileLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetTVFileLanguageList() 2Where
        [TestMethod]
        public void GetTVFileLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVFileLanguageID,GT,2|TVFileLanguageID,LT,5", "");

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = (from c in dbTestDB.TVFileLanguages select c).Where(c => c.TVFileLanguageID > 2 && c.TVFileLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFileLanguage_A> tvFileLanguage_AList = new List<TVFileLanguage_A>();
                            tvFileLanguage_AList = tvFileLanguageService.GetTVFileLanguage_AList().ToList();
                            CheckTVFileLanguage_AFields(tvFileLanguage_AList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_AList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFileLanguage_B> tvFileLanguage_BList = new List<TVFileLanguage_B>();
                            tvFileLanguage_BList = tvFileLanguageService.GetTVFileLanguage_BList().ToList();
                            CheckTVFileLanguage_BFields(tvFileLanguage_BList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguage_BList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() 2Where

        #region Functions private
        private void CheckTVFileLanguageFields(List<TVFileLanguage> tvFileLanguageList)
        {
            Assert.IsNotNull(tvFileLanguageList[0].TVFileLanguageID);
            Assert.IsNotNull(tvFileLanguageList[0].TVFileID);
            Assert.IsNotNull(tvFileLanguageList[0].Language);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageList[0].FileDescription))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].FileDescription));
            }
            Assert.IsNotNull(tvFileLanguageList[0].TranslationStatus);
            Assert.IsNotNull(tvFileLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileLanguageList[0].HasErrors);
        }
        private void CheckTVFileLanguage_AFields(List<TVFileLanguage_A> tvFileLanguage_AList)
        {
            Assert.IsNotNull(tvFileLanguage_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvFileLanguage_AList[0].TVFileLanguageID);
            Assert.IsNotNull(tvFileLanguage_AList[0].TVFileID);
            Assert.IsNotNull(tvFileLanguage_AList[0].Language);
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].FileDescription))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_AList[0].FileDescription));
            }
            Assert.IsNotNull(tvFileLanguage_AList[0].TranslationStatus);
            Assert.IsNotNull(tvFileLanguage_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileLanguage_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileLanguage_AList[0].HasErrors);
        }
        private void CheckTVFileLanguage_BFields(List<TVFileLanguage_B> tvFileLanguage_BList)
        {
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].TVFileLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].TVFileLanguageReportTest));
            }
            Assert.IsNotNull(tvFileLanguage_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvFileLanguage_BList[0].TVFileLanguageID);
            Assert.IsNotNull(tvFileLanguage_BList[0].TVFileID);
            Assert.IsNotNull(tvFileLanguage_BList[0].Language);
            if (!string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].FileDescription))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguage_BList[0].FileDescription));
            }
            Assert.IsNotNull(tvFileLanguage_BList[0].TranslationStatus);
            Assert.IsNotNull(tvFileLanguage_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileLanguage_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileLanguage_BList[0].HasErrors);
        }
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = LanguageRequest;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;

            return tvFileLanguage;
        }
        #endregion Functions private
    }
}
