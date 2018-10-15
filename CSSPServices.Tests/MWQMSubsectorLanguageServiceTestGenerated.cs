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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSubsectorLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count();

                    Assert.AreEqual(mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count(), (from c in dbTestDB.MWQMSubsectorLanguages select c).Take(200).Count());

                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Where(c => c == mwqmSubsectorLanguage).Any());
                    mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count());
                    mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage);
                    if (mwqmSubsectorLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageMWQMSubsectorLanguageID"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorLanguageID = 10000000;
                    mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageMWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMSubsector", ExistPlurial = "s", ExistFieldID = "MWQMSubsectorID", AllowableTVtypeList = )]
                    // mwqmSubsectorLanguage.MWQMSubsectorID   (Int32)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.MWQMSubsectorID = 0;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorLanguageMWQMSubsectorID", mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSubsectorLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.Language = (LanguageEnum)1000000;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageLanguage"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // mwqmSubsectorLanguage.SubsectorDesc   (String)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("SubsectorDesc");
                    Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
                    Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageSubsectorDesc")).Any());
                    Assert.AreEqual(null, mwqmSubsectorLanguage.SubsectorDesc);
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count());

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 251);
                    Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorLanguageSubsectorDesc", "250"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSubsectorLanguage.TranslationStatusSubsectorDesc   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)1000000;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageTranslationStatusSubsectorDesc"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageTranslationStatusLogBook"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSubsectorLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageLastUpdateDate_UTC"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSubsectorLanguageLastUpdateDate_UTC", "1980"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSubsectorLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateContactTVItemID = 0;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorLanguageLastUpdateContactTVItemID", mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsectorLanguage = null;
                    mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
                    mwqmSubsectorLanguage.LastUpdateContactTVItemID = 1;
                    mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorLanguageLastUpdateContactTVItemID", "Contact"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated for GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID)
        [TestMethod]
        public void GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID__mwqmSubsectorLanguage_MWQMSubsectorLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbTestDB.MWQMSubsectorLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsectorLanguage);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmSubsectorLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MWQMSubsectorLanguage mwqmSubsectorLanguageRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID);
                            CheckMWQMSubsectorLanguageFields(new List<MWQMSubsectorLanguage>() { mwqmSubsectorLanguageRet });
                            Assert.AreEqual(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            MWQMSubsectorLanguageExtraA mwqmSubsectorLanguageExtraARet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID);
                            CheckMWQMSubsectorLanguageExtraAFields(new List<MWQMSubsectorLanguageExtraA>() { mwqmSubsectorLanguageExtraARet });
                            Assert.AreEqual(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraARet.MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraB")
                        {
                            MWQMSubsectorLanguageExtraB mwqmSubsectorLanguageExtraBRet = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID);
                            CheckMWQMSubsectorLanguageExtraBFields(new List<MWQMSubsectorLanguageExtraB>() { mwqmSubsectorLanguageExtraBRet });
                            Assert.AreEqual(mwqmSubsectorLanguage.MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBRet.MWQMSubsectorLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(mwqmSubsectorLanguage.MWQMSubsectorLanguageID)

        #region Tests Generated for GetMWQMSubsectorLanguageList()
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in dbTestDB.MWQMSubsectorLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsectorLanguage);

                    List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                    mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmSubsectorLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList()

        #region Tests Generated for GetMWQMSubsectorLanguageList() Skip Take
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() Skip Take

        #region Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSubsectorLanguageID", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order

        #region Tests Generated for GetMWQMSubsectorLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSubsectorLanguageID,MWQMSubsectorID", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorLanguageID).ThenBy(c => c.MWQMSubsectorID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() Skip Take 2Order

        #region Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorLanguageID", "MWQMSubsectorLanguageID,EQ,4", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order Where

        #region Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorLanguageID", "MWQMSubsectorLanguageID,GT,2|MWQMSubsectorLanguageID,LT,5", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID > 2 && c.MWQMSubsectorLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSubsectorLanguageList() 2Where
        [TestMethod]
        public void GetMWQMSubsectorLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorLanguageService.Query = mwqmSubsectorLanguageService.FillQuery(typeof(MWQMSubsectorLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSubsectorLanguageID,GT,2|MWQMSubsectorLanguageID,LT,5", "");

                        List<MWQMSubsectorLanguage> mwqmSubsectorLanguageDirectQueryList = new List<MWQMSubsectorLanguage>();
                        mwqmSubsectorLanguageDirectQueryList = (from c in dbTestDB.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID > 2 && c.MWQMSubsectorLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                            mwqmSubsectorLanguageList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList().ToList();
                            CheckMWQMSubsectorLanguageFields(mwqmSubsectorLanguageList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList = new List<MWQMSubsectorLanguageExtraA>();
                            mwqmSubsectorLanguageExtraAList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraAList().ToList();
                            CheckMWQMSubsectorLanguageExtraAFields(mwqmSubsectorLanguageExtraAList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList = new List<MWQMSubsectorLanguageExtraB>();
                            mwqmSubsectorLanguageExtraBList = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageExtraBList().ToList();
                            CheckMWQMSubsectorLanguageExtraBFields(mwqmSubsectorLanguageExtraBList);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
                            Assert.AreEqual(mwqmSubsectorLanguageDirectQueryList.Count, mwqmSubsectorLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorLanguageList() 2Where

        #region Functions private
        private void CheckMWQMSubsectorLanguageFields(List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList)
        {
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageList[0].SubsectorDesc));
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].TranslationStatusSubsectorDesc);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageList[0].LogBook))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageList[0].LogBook));
            }
            if (mwqmSubsectorLanguageList[0].TranslationStatusLogBook != null)
            {
                Assert.IsNotNull(mwqmSubsectorLanguageList[0].TranslationStatusLogBook);
            }
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorLanguageList[0].HasErrors);
        }
        private void CheckMWQMSubsectorLanguageExtraAFields(List<MWQMSubsectorLanguageExtraA> mwqmSubsectorLanguageExtraAList)
        {
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].TranslationStatusSubsectorDescText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].TranslationStatusSubsectorDescText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].TranslationStatusLogBookText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].TranslationStatusLogBookText));
            }
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorLanguageID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].SubsectorDesc));
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].TranslationStatusSubsectorDesc);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].LogBook))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraAList[0].LogBook));
            }
            if (mwqmSubsectorLanguageExtraAList[0].TranslationStatusLogBook != null)
            {
                Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].TranslationStatusLogBook);
            }
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraAList[0].HasErrors);
        }
        private void CheckMWQMSubsectorLanguageExtraBFields(List<MWQMSubsectorLanguageExtraB> mwqmSubsectorLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageReportTest));
            }
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].TranslationStatusSubsectorDescText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].TranslationStatusSubsectorDescText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].TranslationStatusLogBookText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].TranslationStatusLogBookText));
            }
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorLanguageID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].SubsectorDesc));
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].TranslationStatusSubsectorDesc);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].LogBook))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorLanguageExtraBList[0].LogBook));
            }
            if (mwqmSubsectorLanguageExtraBList[0].TranslationStatusLogBook != null)
            {
                Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].TranslationStatusLogBook);
            }
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorLanguageExtraBList[0].HasErrors);
        }
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
    }
}
