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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSampleLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in mwqmSampleLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    MWQMSampleLanguage mwqmSampleLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

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
                        CheckMWQMSampleLanguageFields(new List<MWQMSampleLanguage>() { mwqmSampleLanguageRet }, entityQueryDetailType);
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
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in mwqmSampleLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
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
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Skip(1).Take(1).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(1, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take

        #region Tests Generated for GetMWQMSampleLanguageList() Skip Take Order
        [TestMethod]
        public void GetMWQMSampleLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSampleLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(1, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take Order

        #region Tests Generated for GetMWQMSampleLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSampleLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSampleLanguageID,MWQMSampleID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ThenBy(c => c.MWQMSampleID).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(1, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take 2Order

        #region Tests Generated for GetMWQMSampleLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSampleLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleLanguageID", "MWQMSampleLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Where(c => c.MWQMSampleLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(1, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take Order Where

        #region Tests Generated for GetMWQMSampleLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSampleLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleLanguageID", "MWQMSampleLanguageID,GT,2|MWQMSampleLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Where(c => c.MWQMSampleLanguageID > 2 && c.MWQMSampleLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(1, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSampleLanguageList() 2Where
        [TestMethod]
        public void GetMWQMSampleLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSampleLanguageID,GT,2|MWQMSampleLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleLanguageDirectQueryList = mwqmSampleLanguageService.GetRead().Where(c => c.MWQMSampleLanguageID > 2 && c.MWQMSampleLanguageID < 5).ToList();

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
                        CheckMWQMSampleLanguageFields(mwqmSampleLanguageList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        Assert.AreEqual(2, mwqmSampleLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() 2Where

        #region Functions private
        private void CheckMWQMSampleLanguageFields(List<MWQMSampleLanguage> mwqmSampleLanguageList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
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
                if (!string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleLanguageWeb.TranslationStatusText))
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
    }
}
