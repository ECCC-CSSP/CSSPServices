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
    public partial class MWQMSampleLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageServiceTest() : base()
        {
            //mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSampleLanguage GetFilledRandomMWQMSampleLanguage(string OmitPropName)
        {
            MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();

            if (OmitPropName != "MWQMSampleID") mwqmSampleLanguage.MWQMSampleID = 1;
            if (OmitPropName != "Language") mwqmSampleLanguage.Language = LanguageRequest;
            if (OmitPropName != "MWQMSampleNote") mwqmSampleLanguage.MWQMSampleNote = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSampleLanguage.LastUpdateContactTVItemID = 2;

            return mwqmSampleLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSampleLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSampleLanguage mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSampleLanguageService.GetRead().Count();

                    Assert.AreEqual(mwqmSampleLanguageService.GetRead().Count(), mwqmSampleLanguageService.GetEdit().Count());

                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSampleLanguageService.GetRead().Where(c => c == mwqmSampleLanguage).Any());
                    mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSampleLanguageService.GetRead().Count());
                    mwqmSampleLanguageService.Delete(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSampleLanguage.MWQMSampleLanguageID   (Int32)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageID = 0;
                    mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageMWQMSampleLanguageID), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageID = 10000000;
                    mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSampleLanguage, CSSPModelsRes.MWQMSampleLanguageMWQMSampleLanguageID, mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMSample", ExistPlurial = "s", ExistFieldID = "MWQMSampleID", AllowableTVtypeList = Error)]
                    // mwqmSampleLanguage.MWQMSampleID   (Int32)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleID = 0;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSample, CSSPModelsRes.MWQMSampleLanguageMWQMSampleID, mwqmSampleLanguage.MWQMSampleID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSampleLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.Language = (LanguageEnum)1000000;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageLanguage), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmSampleLanguage.MWQMSampleNote   (String)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("MWQMSampleNote");
                    Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                    Assert.AreEqual(1, mwqmSampleLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageMWQMSampleNote)).Any());
                    Assert.AreEqual(null, mwqmSampleLanguage.MWQMSampleNote);
                    Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSampleLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageTranslationStatus), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSampleLanguage.MWQMSampleLanguageWeb   (MWQMSampleLanguageWeb)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageWeb = null;
                    Assert.IsNull(mwqmSampleLanguage.MWQMSampleLanguageWeb);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageWeb = new MWQMSampleLanguageWeb();
                    Assert.IsNotNull(mwqmSampleLanguage.MWQMSampleLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSampleLanguage.MWQMSampleLanguageReport   (MWQMSampleLanguageReport)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageReport = null;
                    Assert.IsNull(mwqmSampleLanguage.MWQMSampleLanguageReport);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageReport = new MWQMSampleLanguageReport();
                    Assert.IsNotNull(mwqmSampleLanguage.MWQMSampleLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSampleLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageLastUpdateDate_UTC), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleLanguageLastUpdateDate_UTC, "1980"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSampleLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateContactTVItemID = 0;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateContactTVItemID = 1;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, "Contact"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSampleLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSampleLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID)
        [TestMethod]
        public void GetMWQMSampleLanguageWithMWQMSampleLanguageID__mwqmSampleLanguage_MWQMSampleLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new GetParam(), dbTestDB, ContactID);
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in mwqmSampleLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    MWQMSampleLanguage mwqmSampleLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                            Assert.IsNull(mwqmSampleLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMSampleLanguage fields
                        Assert.IsNotNull(mwqmSampleLanguageRet.MWQMSampleLanguageID);
                        Assert.IsNotNull(mwqmSampleLanguageRet.MWQMSampleID);
                        Assert.IsNotNull(mwqmSampleLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleNote));
                        Assert.IsNotNull(mwqmSampleLanguageRet.TranslationStatus);
                        Assert.IsNotNull(mwqmSampleLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmSampleLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMSampleLanguageWeb and MWQMSampleLanguageReport fields should be null here
                            Assert.IsNull(mwqmSampleLanguageRet.MWQMSampleLanguageWeb);
                            Assert.IsNull(mwqmSampleLanguageRet.MWQMSampleLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMSampleLanguageWeb fields should not be null and MWQMSampleLanguageReport fields should be null here
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LanguageText));
                            }
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(mwqmSampleLanguageRet.MWQMSampleLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMSampleLanguageWeb and MWQMSampleLanguageReport fields should NOT be null here
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.LanguageText));
                            }
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageWeb.TranslationStatusText));
                            }
                            if (mwqmSampleLanguageRet.MWQMSampleLanguageReport.MWQMSampleLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageRet.MWQMSampleLanguageReport.MWQMSampleLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID)

        #region Tests Generated for GetMWQMSampleLanguageList()
        [TestMethod]
        public void GetMWQMSampleLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new GetParam(), dbTestDB, ContactID);
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in mwqmSampleLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            Assert.AreEqual(0, mwqmSampleLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMSampleLanguage fields
                        Assert.IsNotNull(mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.IsNotNull(mwqmSampleLanguageList[0].MWQMSampleID);
                        Assert.IsNotNull(mwqmSampleLanguageList[0].Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleNote));
                        Assert.IsNotNull(mwqmSampleLanguageList[0].TranslationStatus);
                        Assert.IsNotNull(mwqmSampleLanguageList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmSampleLanguageList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMSampleLanguageWeb and MWQMSampleLanguageReport fields should be null here
                            Assert.IsNull(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb);
                            Assert.IsNull(mwqmSampleLanguageList[0].MWQMSampleLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMSampleLanguageWeb fields should not be null and MWQMSampleLanguageReport fields should be null here
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText));
                            }
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(mwqmSampleLanguageList[0].MWQMSampleLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMSampleLanguageWeb and MWQMSampleLanguageReport fields should NOT be null here
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText));
                            }
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.TranslationStatusText));
                            }
                            if (mwqmSampleLanguageList[0].MWQMSampleLanguageReport.MWQMSampleLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageReport.MWQMSampleLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList()

        #region Tests Generated for GetMWQMSampleLanguageList() Skip Take
        [TestMethod]
        public void GetMWQMSampleLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(MWQMSampleLanguage), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            Assert.AreEqual(0, mwqmSampleLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take

    }
}
