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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFileLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new GetParam(), dbTestDB, ContactID);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageTVFileLanguageID), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageID = 10000000;
                    tvFileLanguageService.Update(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFileLanguage, CSSPModelsRes.TVFileLanguageTVFileLanguageID, tvFileLanguage.TVFileLanguageID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID", AllowableTVtypeList = Error)]
                    // tvFileLanguage.TVFileID   (Int32)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileID = 0;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFile, CSSPModelsRes.TVFileLanguageTVFileID, tvFileLanguage.TVFileID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFileLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.Language = (LanguageEnum)1000000;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageLanguage), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageTranslationStatus), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvFileLanguage.TVFileLanguageWeb   (TVFileLanguageWeb)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageWeb = null;
                    Assert.IsNull(tvFileLanguage.TVFileLanguageWeb);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageWeb = new TVFileLanguageWeb();
                    Assert.IsNotNull(tvFileLanguage.TVFileLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvFileLanguage.TVFileLanguageReport   (TVFileLanguageReport)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageReport = null;
                    Assert.IsNull(tvFileLanguage.TVFileLanguageReport);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.TVFileLanguageReport = new TVFileLanguageReport();
                    Assert.IsNotNull(tvFileLanguage.TVFileLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFileLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateDate_UTC = new DateTime();
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageLastUpdateDate_UTC), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileLanguageLastUpdateDate_UTC, "1980"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvFileLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateContactTVItemID = 0;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileLanguageLastUpdateContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFileLanguage = null;
                    tvFileLanguage = GetFilledRandomTVFileLanguage("");
                    tvFileLanguage.LastUpdateContactTVItemID = 1;
                    tvFileLanguageService.Add(tvFileLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileLanguageLastUpdateContactTVItemID, "Contact"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new GetParam(), dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in tvFileLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    TVFileLanguage tvFileLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                            Assert.IsNull(tvFileLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TVFileLanguage fields
                        Assert.IsNotNull(tvFileLanguageRet.TVFileLanguageID);
                        Assert.IsNotNull(tvFileLanguageRet.TVFileID);
                        Assert.IsNotNull(tvFileLanguageRet.Language);
                        if (tvFileLanguageRet.FileDescription != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.FileDescription));
                        }
                        Assert.IsNotNull(tvFileLanguageRet.TranslationStatus);
                        Assert.IsNotNull(tvFileLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvFileLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TVFileLanguageWeb and TVFileLanguageReport fields should be null here
                            Assert.IsNull(tvFileLanguageRet.TVFileLanguageWeb);
                            Assert.IsNull(tvFileLanguageRet.TVFileLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TVFileLanguageWeb fields should not be null and TVFileLanguageReport fields should be null here
                            if (tvFileLanguageRet.TVFileLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.LastUpdateContactTVText));
                            }
                            if (tvFileLanguageRet.TVFileLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.LanguageText));
                            }
                            if (tvFileLanguageRet.TVFileLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(tvFileLanguageRet.TVFileLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TVFileLanguageWeb and TVFileLanguageReport fields should NOT be null here
                            if (tvFileLanguageRet.TVFileLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.LastUpdateContactTVText));
                            }
                            if (tvFileLanguageRet.TVFileLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.LanguageText));
                            }
                            if (tvFileLanguageRet.TVFileLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageWeb.TranslationStatusText));
                            }
                            if (tvFileLanguageRet.TVFileLanguageReport.TVFileLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TVFileLanguageReport.TVFileLanguageReportTest));
                            }
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
                    TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new GetParam(), dbTestDB, ContactID);
                    TVFileLanguage tvFileLanguage = (from c in tvFileLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFileLanguage);

                    List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            Assert.AreEqual(0, tvFileLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TVFileLanguage fields
                        Assert.IsNotNull(tvFileLanguageList[0].TVFileLanguageID);
                        Assert.IsNotNull(tvFileLanguageList[0].TVFileID);
                        Assert.IsNotNull(tvFileLanguageList[0].Language);
                        if (tvFileLanguageList[0].FileDescription != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].FileDescription));
                        }
                        Assert.IsNotNull(tvFileLanguageList[0].TranslationStatus);
                        Assert.IsNotNull(tvFileLanguageList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(tvFileLanguageList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TVFileLanguageWeb and TVFileLanguageReport fields should be null here
                            Assert.IsNull(tvFileLanguageList[0].TVFileLanguageWeb);
                            Assert.IsNull(tvFileLanguageList[0].TVFileLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TVFileLanguageWeb fields should not be null and TVFileLanguageReport fields should be null here
                            if (tvFileLanguageList[0].TVFileLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.LastUpdateContactTVText));
                            }
                            if (tvFileLanguageList[0].TVFileLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.LanguageText));
                            }
                            if (tvFileLanguageList[0].TVFileLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(tvFileLanguageList[0].TVFileLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TVFileLanguageWeb and TVFileLanguageReport fields should NOT be null here
                            if (tvFileLanguageList[0].TVFileLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.LastUpdateContactTVText));
                            }
                            if (tvFileLanguageList[0].TVFileLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.LanguageText));
                            }
                            if (tvFileLanguageList[0].TVFileLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageWeb.TranslationStatusText));
                            }
                            if (tvFileLanguageList[0].TVFileLanguageReport.TVFileLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageList[0].TVFileLanguageReport.TVFileLanguageReportTest));
                            }
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
                    List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(TVFileLanguage), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                            Assert.AreEqual(0, tvFileLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileLanguageList = tvFileLanguageService.GetTVFileLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, tvFileLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileLanguageList() Skip Take

    }
}
