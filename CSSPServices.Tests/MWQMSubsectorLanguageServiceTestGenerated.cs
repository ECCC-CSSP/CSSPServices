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
    public partial class MWQMSubsectorLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageServiceTest() : base()
        {
            //mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsectorLanguage GetFilledRandomMWQMSubsectorLanguage(string OmitPropName)
        {
            MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();

            if (OmitPropName != "MWQMSubsectorID") mwqmSubsectorLanguage.MWQMSubsectorID = 1;
            if (OmitPropName != "Language") mwqmSubsectorLanguage.Language = LanguageRequest;
            if (OmitPropName != "SubsectorDesc") mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusSubsectorDesc") mwqmSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LogBook") mwqmSubsectorLanguage.LogBook = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusLogBook") mwqmSubsectorLanguage.TranslationStatusLogBook = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsectorLanguage.LastUpdateContactTVItemID = 2;

            return mwqmSubsectorLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSubsectorLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSubsectorLanguage mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSubsectorLanguageService.GetRead().Count();

                    Assert.AreEqual(mwqmSubsectorLanguageService.GetRead().Count(), mwqmSubsectorLanguageService.GetEdit().Count());

                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSubsectorLanguageService.GetRead().Where(c => c == mwqmSubsectorLanguage).Any());
                    mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSubsectorLanguageService.GetRead().Count());
                    mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSubsectorLanguage.MWQMSubsectorLanguageID   (Int32)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageID = 0;
                    mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageID = 10000000;
                    mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsectorLanguage, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID, mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMSubsector", ExistPlurial = "s", ExistFieldID = "MWQMSubsectorID", AllowableTVtypeList = Error)]
                    // mwqmSubsectorLanguage.MWQMSubsectorID   (Int32)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorID = 0;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsector, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSubsectorLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.Language = (LanguageEnum)1000000;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageLanguage), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // mwqmSubsectorLanguage.SubsectorDesc   (String)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("SubsectorDesc");
                    Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
                    Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageSubsectorDesc)).Any());
                    Assert.AreEqual(null, mwqmSubsectorLanguage.SubsectorDesc);
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 251);
                    Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSubsectorLanguage.TranslationStatusSubsectorDesc   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)1000000;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusSubsectorDesc), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // mwqmSubsectorLanguage.LogBook   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmSubsectorLanguage.TranslationStatusLogBook   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.TranslationStatusLogBook = (TranslationStatusEnum)1000000;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusLogBook), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSubsectorLanguage.MWQMSubsectorLanguageWeb   (MWQMSubsectorLanguageWeb)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageWeb = null;
                    Assert.IsNull(mwqmSubsectorLanguage.MWQMSubsectorLanguageWeb);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageWeb = new MWQMSubsectorLanguageWeb();
                    Assert.IsNotNull(mwqmSubsectorLanguage.MWQMSubsectorLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSubsectorLanguage.MWQMSubsectorLanguageReport   (MWQMSubsectorLanguageReport)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageReport = null;
                    Assert.IsNull(mwqmSubsectorLanguage.MWQMSubsectorLanguageReport);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageReport = new MWQMSubsectorLanguageReport();
                    Assert.IsNotNull(mwqmSubsectorLanguage.MWQMSubsectorLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSubsectorLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC, "1980"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSubsectorLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateContactTVItemID = 0;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateContactTVItemID = 1;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "Contact"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsectorLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsectorLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSubsectorLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new GetParam(), dbTestDB, ContactID);
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in mwqmSubsectorLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsectorLanguage);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSubsectorLanguageRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, getParam);
                            Assert.IsNull(mwqmSubsectorLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorLanguageRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorLanguageRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorLanguageRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMSubsectorLanguage fields
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.MWQMSubsectorID);
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.SubsectorDesc));
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.TranslationStatusSubsectorDesc);
                        if (mwqmSubsectorLanguageRet.LogBook != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.LogBook));
                        }
                        if (mwqmSubsectorLanguageRet.TranslationStatusLogBook != null)
                        {
                            Assert.IsNotNull(mwqmSubsectorLanguageRet.TranslationStatusLogBook);
                        }
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmSubsectorLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMSubsectorLanguageWeb and MWQMSubsectorLanguageReport fields should be null here
                            Assert.IsNull(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb);
                            Assert.IsNull(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMSubsectorLanguageWeb fields should not be null and MWQMSubsectorLanguageReport fields should be null here
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LanguageText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusSubsectorDescText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusSubsectorDescText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusLogBookText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusLogBookText));
                            }
                            Assert.IsNull(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMSubsectorLanguageWeb and MWQMSubsectorLanguageReport fields should NOT be null here
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.LanguageText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusSubsectorDescText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusSubsectorDescText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusLogBookText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageWeb.TranslationStatusLogBookText));
                            }
                            if (mwqmSubsectorLanguageRet.MWQMSubsectorLanguageReport.MWQMSubsectorLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageRet.MWQMSubsectorLanguageReport.MWQMSubsectorLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MWQMSubsectorLanguage
        #endregion Tests Get List of MWQMSubsectorLanguage

    }
}
