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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = tvFileLanguageService.GetRead().Count();

                    Assert.AreEqual(tvFileLanguageService.GetRead().Count(), tvFileLanguageService.GetEdit().Count());

                    tvFileLanguageService.Add(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvFileLanguageService.GetRead().Where(c => c == tvFileLanguage).Any());
                    tvFileLanguageService.Update(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvFileLanguageService.GetRead().Count());
                    tvFileLanguageService.Delete(tvFileLanguage);
                    if (tvFileLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvFileLanguageService.GetRead().Count());

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in tvFileLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            TVFileLanguage tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguageFields(new List<TVFileLanguage>() { tvFileLanguageRet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            TVFileLanguageWeb tvFileLanguageWebRet = tvFileLanguageService.GetTVFileLanguageWebWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguageWebFields(new List<TVFileLanguageWeb>() { tvFileLanguageWebRet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguageWebRet.TVFileLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            TVFileLanguageReport tvFileLanguageReportRet = tvFileLanguageService.GetTVFileLanguageReportWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            CheckTVFileLanguageReportFields(new List<TVFileLanguageReport>() { tvFileLanguageReportRet });
                            Assert.AreEqual(tvFileLanguage.TVFileLanguageID, tvFileLanguageReportRet.TVFileLanguageID);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in tvFileLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                    tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "TVFileLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 1, 1, "TVFileLanguageID,TVFileID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVFileLanguageID).ThenBy(c => c.TVFileID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVFileLanguageID", "TVFileLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Where(c => c.TVFileLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVFileLanguageID", "TVFileLanguageID,GT,2|TVFileLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Where(c => c.TVFileLanguageID > 2 && c.TVFileLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.TVFileLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileLanguageService.Query = tvFileLanguageService.FillQuery(typeof(TVFileLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVFileLanguageID,GT,2|TVFileLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVFileLanguage> tvFileLanguageDirectQueryList = new List<TVFileLanguage>();
                        tvFileLanguageDirectQueryList = tvFileLanguageService.GetRead().Where(c => c.TVFileLanguageID > 2 && c.TVFileLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            CheckTVFileLanguageFields(tvFileLanguageList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVFileLanguageWeb> tvFileLanguageWebList = new List<TVFileLanguageWeb>();
                            tvFileLanguageWebList = tvFileLanguageService.GetTVFileLanguageWebList().ToList();
                            CheckTVFileLanguageWebFields(tvFileLanguageWebList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageWebList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVFileLanguageReport> tvFileLanguageReportList = new List<TVFileLanguageReport>();
                            tvFileLanguageReportList = tvFileLanguageService.GetTVFileLanguageReportList().ToList();
                            CheckTVFileLanguageReportFields(tvFileLanguageReportList);
                            Assert.AreEqual(tvFileLanguageDirectQueryList[0].TVFileLanguageID, tvFileLanguageReportList[0].TVFileLanguageID);
                            Assert.AreEqual(tvFileLanguageDirectQueryList.Count, tvFileLanguageReportList.Count);
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
        private void CheckTVFileLanguageWebFields(List<TVFileLanguageWeb> tvFileLanguageWebList)
        {
            Assert.IsNotNull(tvFileLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvFileLanguageWebList[0].TVFileLanguageID);
            Assert.IsNotNull(tvFileLanguageWebList[0].TVFileID);
            Assert.IsNotNull(tvFileLanguageWebList[0].Language);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].FileDescription))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageWebList[0].FileDescription));
            }
            Assert.IsNotNull(tvFileLanguageWebList[0].TranslationStatus);
            Assert.IsNotNull(tvFileLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileLanguageWebList[0].HasErrors);
        }
        private void CheckTVFileLanguageReportFields(List<TVFileLanguageReport> tvFileLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].TVFileLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].TVFileLanguageReportTest));
            }
            Assert.IsNotNull(tvFileLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].TranslationStatusText));
            }
            Assert.IsNotNull(tvFileLanguageReportList[0].TVFileLanguageID);
            Assert.IsNotNull(tvFileLanguageReportList[0].TVFileID);
            Assert.IsNotNull(tvFileLanguageReportList[0].Language);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].FileDescription))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageReportList[0].FileDescription));
            }
            Assert.IsNotNull(tvFileLanguageReportList[0].TranslationStatus);
            Assert.IsNotNull(tvFileLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileLanguageReportList[0].HasErrors);
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
