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
    public partial class MWQMRunLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageServiceTest() : base()
        {
            //mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMRunLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmRunLanguageService.GetRead().Count();

                    Assert.AreEqual(mwqmRunLanguageService.GetRead().Count(), mwqmRunLanguageService.GetEdit().Count());

                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmRunLanguageService.GetRead().Where(c => c == mwqmRunLanguage).Any());
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmRunLanguageService.GetRead().Count());
                    mwqmRunLanguageService.Delete(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmRunLanguage.MWQMRunLanguageID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageID = 0;
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageMWQMRunLanguageID"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageID = 10000000;
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageMWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID", AllowableTVtypeList = )]
                    // mwqmRunLanguage.MWQMRunID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunLanguageMWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.Language = (LanguageEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageLanguage"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
                    Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageRunComment")).Any());
                    Assert.AreEqual(null, mwqmRunLanguage.RunComment);
                    Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageTranslationStatusRunComment"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunWeatherComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
                    Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageRunWeatherComment")).Any());
                    Assert.AreEqual(null, mwqmRunLanguage.RunWeatherComment);
                    Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageTranslationStatusRunWeatherComment"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageLastUpdateDate_UTC"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLanguageLastUpdateDate_UTC", "1980"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLanguageLastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 1;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLanguageLastUpdateContactTVItemID", "Contact"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID)
        [TestMethod]
        public void GetMWQMRunLanguageWithMWQMRunLanguageID__mwqmRunLanguage_MWQMRunLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in mwqmRunLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRunLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmRunLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MWQMRunLanguage mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageFields(new List<MWQMRunLanguage>() { mwqmRunLanguageRet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MWQMRunLanguageWeb mwqmRunLanguageWebRet = mwqmRunLanguageService.GetMWQMRunLanguageWebWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageWebFields(new List<MWQMRunLanguageWeb>() { mwqmRunLanguageWebRet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageWebRet.MWQMRunLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MWQMRunLanguageReport mwqmRunLanguageReportRet = mwqmRunLanguageService.GetMWQMRunLanguageReportWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageReportFields(new List<MWQMRunLanguageReport>() { mwqmRunLanguageReportRet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageReportRet.MWQMRunLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID)

        #region Tests Generated for GetMWQMRunLanguageList()
        [TestMethod]
        public void GetMWQMRunLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in mwqmRunLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRunLanguage);

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmRunLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList()

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take
        [TestMethod]
        public void GetMWQMRunLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Order
        [TestMethod]
        public void GetMWQMRunLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMRunLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Order

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMRunLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMRunLanguageID,MWQMRunID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ThenBy(c => c.MWQMRunID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take 2Order

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMRunLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Order Where

        #region Tests Generated for GetMWQMRunLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMRunLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMRunLanguageList() 2Where
        [TestMethod]
        public void GetMWQMRunLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMRunLanguageWeb> mwqmRunLanguageWebList = new List<MWQMRunLanguageWeb>();
                            mwqmRunLanguageWebList = mwqmRunLanguageService.GetMWQMRunLanguageWebList().ToList();
                            CheckMWQMRunLanguageWebFields(mwqmRunLanguageWebList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageWebList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMRunLanguageReport> mwqmRunLanguageReportList = new List<MWQMRunLanguageReport>();
                            mwqmRunLanguageReportList = mwqmRunLanguageService.GetMWQMRunLanguageReportList().ToList();
                            CheckMWQMRunLanguageReportFields(mwqmRunLanguageReportList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageReportList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() 2Where

        #region Functions private
        private void CheckMWQMRunLanguageFields(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunLanguageList[0].HasErrors);
        }
        private void CheckMWQMRunLanguageWebFields(List<MWQMRunLanguageWeb> mwqmRunLanguageWebList)
        {
            Assert.IsNotNull(mwqmRunLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].TranslationStatusRunCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].TranslationStatusRunCommentText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].TranslationStatusRunWeatherCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].TranslationStatusRunWeatherCommentText));
            }
            Assert.IsNotNull(mwqmRunLanguageWebList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageWebList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageWebList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageWebList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageWebList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunLanguageWebList[0].HasErrors);
        }
        private void CheckMWQMRunLanguageReportFields(List<MWQMRunLanguageReport> mwqmRunLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].MWQMRunLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].MWQMRunLanguageReportTest));
            }
            Assert.IsNotNull(mwqmRunLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].TranslationStatusRunCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].TranslationStatusRunCommentText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].TranslationStatusRunWeatherCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].TranslationStatusRunWeatherCommentText));
            }
            Assert.IsNotNull(mwqmRunLanguageReportList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageReportList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageReportList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageReportList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageReportList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunLanguageReportList[0].HasErrors);
        }
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = 1;
            if (OmitPropName != "Language") mwqmRunLanguage.Language = LanguageRequest;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = 2;

            return mwqmRunLanguage;
        }
        #endregion Functions private
    }
}
