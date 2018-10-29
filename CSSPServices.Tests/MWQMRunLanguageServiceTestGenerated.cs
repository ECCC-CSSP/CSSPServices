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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = mwqmRunLanguageService.GetMWQMRunLanguageList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.MWQMRunLanguages select c).Count());

                    mwqmRunLanguageService.Add(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmRunLanguageService.GetMWQMRunLanguageList().Where(c => c == mwqmRunLanguage).Any());
                    mwqmRunLanguageService.Update(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());
                    mwqmRunLanguageService.Delete(mwqmRunLanguage);
                    if (mwqmRunLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());

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
                    Assert.AreEqual(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());


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
                    Assert.AreEqual(count, mwqmRunLanguageService.GetMWQMRunLanguageList().Count());


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in dbTestDB.MWQMRunLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRunLanguage);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmRunLanguageService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            MWQMRunLanguage mwqmRunLanguageRet = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageFields(new List<MWQMRunLanguage>() { mwqmRunLanguageRet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            MWQMRunLanguageExtraA mwqmRunLanguageExtraARet = mwqmRunLanguageService.GetMWQMRunLanguageExtraAWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageExtraAFields(new List<MWQMRunLanguageExtraA>() { mwqmRunLanguageExtraARet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageExtraARet.MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraB")
                        {
                            MWQMRunLanguageExtraB mwqmRunLanguageExtraBRet = mwqmRunLanguageService.GetMWQMRunLanguageExtraBWithMWQMRunLanguageID(mwqmRunLanguage.MWQMRunLanguageID);
                            CheckMWQMRunLanguageExtraBFields(new List<MWQMRunLanguageExtraB>() { mwqmRunLanguageExtraBRet });
                            Assert.AreEqual(mwqmRunLanguage.MWQMRunLanguageID, mwqmRunLanguageExtraBRet.MWQMRunLanguageID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRunLanguage mwqmRunLanguage = (from c in dbTestDB.MWQMRunLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRunLanguage);

                    List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                    mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmRunLanguageService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMRunLanguageID", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMRunLanguageID,MWQMRunID", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMRunLanguageID).ThenBy(c => c.MWQMRunID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,EQ,4", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunLanguageID", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMRunLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunLanguageService.Query = mwqmRunLanguageService.FillQuery(typeof(MWQMRunLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMRunLanguageID,GT,2|MWQMRunLanguageID,LT,5", "");

                        List<MWQMRunLanguage> mwqmRunLanguageDirectQueryList = new List<MWQMRunLanguage>();
                        mwqmRunLanguageDirectQueryList = (from c in dbTestDB.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID > 2 && c.MWQMRunLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                            mwqmRunLanguageList = mwqmRunLanguageService.GetMWQMRunLanguageList().ToList();
                            CheckMWQMRunLanguageFields(mwqmRunLanguageList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageList[0].MWQMRunLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList = new List<MWQMRunLanguageExtraA>();
                            mwqmRunLanguageExtraAList = mwqmRunLanguageService.GetMWQMRunLanguageExtraAList().ToList();
                            CheckMWQMRunLanguageExtraAFields(mwqmRunLanguageExtraAList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList = new List<MWQMRunLanguageExtraB>();
                            mwqmRunLanguageExtraBList = mwqmRunLanguageService.GetMWQMRunLanguageExtraBList().ToList();
                            CheckMWQMRunLanguageExtraBFields(mwqmRunLanguageExtraBList);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList[0].MWQMRunLanguageID, mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
                            Assert.AreEqual(mwqmRunLanguageDirectQueryList.Count, mwqmRunLanguageExtraBList.Count);
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
        private void CheckMWQMRunLanguageExtraAFields(List<MWQMRunLanguageExtraA> mwqmRunLanguageExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].TranslationStatusRunCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].TranslationStatusRunCommentText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].TranslationStatusRunWeatherCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].TranslationStatusRunWeatherCommentText));
            }
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraAList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunLanguageExtraAList[0].HasErrors);
        }
        private void CheckMWQMRunLanguageExtraBFields(List<MWQMRunLanguageExtraB> mwqmRunLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].MWQMRunLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].MWQMRunLanguageReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].TranslationStatusRunCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].TranslationStatusRunCommentText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].TranslationStatusRunWeatherCommentText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].TranslationStatusRunWeatherCommentText));
            }
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].MWQMRunLanguageID);
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].RunComment));
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].TranslationStatusRunComment);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunLanguageExtraBList[0].RunWeatherComment));
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].TranslationStatusRunWeatherComment);
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunLanguageExtraBList[0].HasErrors);
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
