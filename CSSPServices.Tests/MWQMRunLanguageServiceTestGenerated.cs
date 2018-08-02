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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageMWQMRunLanguageID), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageID = 10000000;
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRunLanguage, CSSPModelsRes.MWQMRunLanguageMWQMRunLanguageID, mwqmRunLanguage.MWQMRunLanguageID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID", AllowableTVtypeList = )]
                    // mwqmRunLanguage.MWQMRunID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRun, CSSPModelsRes.MWQMRunLanguageMWQMRunID, mwqmRunLanguage.MWQMRunID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRunLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.Language = (LanguageEnum)1000000;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageLanguage), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
                    Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageRunComment)).Any());
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunComment), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmRunLanguage.RunWeatherComment   (String)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
                    Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
                    Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageRunWeatherComment)).Any());
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.MWQMRunLanguageWeb   (MWQMRunLanguageWeb)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageWeb = null;
                    Assert.IsNull(mwqmRunLanguage.MWQMRunLanguageWeb);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageWeb = new MWQMRunLanguageWeb();
                    Assert.IsNotNull(mwqmRunLanguage.MWQMRunLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmRunLanguage.MWQMRunLanguageReport   (MWQMRunLanguageReport)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageReport = null;
                    Assert.IsNull(mwqmRunLanguage.MWQMRunLanguageReport);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.MWQMRunLanguageReport = new MWQMRunLanguageReport();
                    Assert.IsNotNull(mwqmRunLanguage.MWQMRunLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageLastUpdateDate_UTC), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLanguageLastUpdateDate_UTC, "1980"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 0;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRunLanguage = null;
                    mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
                    mwqmRunLanguage.LastUpdateContactTVItemID = 1;
                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "Contact"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    MWQMRunLanguage mwqmRunLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmRunLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            Assert.IsNull(mwqmRunLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(new List<MWQMRunLanguage>() { mwqmRunLanguageRet }, entityQueryDetailType);
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

                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmRunLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(1, mwqmRunLanguageList.Count);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMRunLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(1, mwqmRunLanguageList.Count);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMRunLanguageID,MWQMRunID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ThenBy(c => c.MWQMRunID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(1, mwqmRunLanguageList.Count);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(1, mwqmRunLanguageList.Count);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(1, mwqmRunLanguageList.Count);
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
                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmRunLanguageDirectQueryList = mwqmRunLanguageService.GetRead().Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            Assert.AreEqual(0, mwqmRunLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMRunLanguageFields(mwqmRunLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        Assert.AreEqual(2, mwqmRunLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunLanguageList() 2Where

        #region Functions private
        private void CheckMWQMRunLanguageFields(List<MWQMRunLanguage> mwqmRunLanguageList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // MWQMRunLanguage fields
            Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMRunLanguageWeb and MWQMRunLanguageReport fields should be null here
                Assert.IsNull(mwqmRunLanguageList[0].MWQMRunLanguageWeb);
                Assert.IsNull(mwqmRunLanguageList[0].MWQMRunLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMRunLanguageWeb fields should not be null and MWQMRunLanguageReport fields should be null here
                Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunLanguageWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunCommentText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunCommentText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunWeatherCommentText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunWeatherCommentText));
                }
                Assert.IsNull(mwqmRunLanguageList[0].MWQMRunLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMRunLanguageWeb and MWQMRunLanguageReport fields should NOT be null here
                Assert.IsNotNull(mwqmRunLanguageList[0].MWQMRunLanguageWeb.LastUpdateContactTVItemLanguage);
                if (mwqmRunLanguageList[0].MWQMRunLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.LanguageText));
                }
                if (mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunCommentText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunCommentText));
                }
                if (mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunWeatherCommentText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageWeb.TranslationStatusRunWeatherCommentText));
                }
                if (mwqmRunLanguageList[0].MWQMRunLanguageReport.MWQMRunLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageList[0].MWQMRunLanguageReport.MWQMRunLanguageReportTest));
                }
            }
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
