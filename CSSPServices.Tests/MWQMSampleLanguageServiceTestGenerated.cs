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

                    count = mwqmSampleLanguageService.GetMWQMSampleLanguageList().Count();

                    Assert.AreEqual(mwqmSampleLanguageService.GetMWQMSampleLanguageList().Count(), (from c in dbTestDB.MWQMSampleLanguages select c).Take(200).Count());

                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSampleLanguageService.GetMWQMSampleLanguageList().Where(c => c == mwqmSampleLanguage).Any());
                    mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSampleLanguageService.GetMWQMSampleLanguageList().Count());
                    mwqmSampleLanguageService.Delete(mwqmSampleLanguage);
                    if (mwqmSampleLanguage.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSampleLanguageService.GetMWQMSampleLanguageList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageMWQMSampleLanguageID"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleLanguageID = 10000000;
                    mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageMWQMSampleLanguageID", mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MWQMSample", ExistPlurial = "s", ExistFieldID = "MWQMSampleID", AllowableTVtypeList = )]
                    // mwqmSampleLanguage.MWQMSampleID   (Int32)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.MWQMSampleID = 0;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleLanguageMWQMSampleID", mwqmSampleLanguage.MWQMSampleID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSampleLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.Language = (LanguageEnum)1000000;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageLanguage"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmSampleLanguage.MWQMSampleNote   (String)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("MWQMSampleNote");
                    Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                    Assert.AreEqual(1, mwqmSampleLanguage.ValidationResults.Count());
                    Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageMWQMSampleNote")).Any());
                    Assert.AreEqual(null, mwqmSampleLanguage.MWQMSampleNote);
                    Assert.AreEqual(count, mwqmSampleLanguageService.GetMWQMSampleLanguageList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSampleLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageTranslationStatus"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSampleLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime();
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageLastUpdateDate_UTC"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSampleLanguageLastUpdateDate_UTC", "1980"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSampleLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateContactTVItemID = 0;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSampleLanguageLastUpdateContactTVItemID", mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSampleLanguage = null;
                    mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                    mwqmSampleLanguage.LastUpdateContactTVItemID = 1;
                    mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSampleLanguageLastUpdateContactTVItemID", "Contact"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in dbTestDB.MWQMSampleLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmSampleLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MWQMSampleLanguage mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                            CheckMWQMSampleLanguageFields(new List<MWQMSampleLanguage>() { mwqmSampleLanguageRet });
                            Assert.AreEqual(mwqmSampleLanguage.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            MWQMSampleLanguage_A mwqmSampleLanguage_ARet = mwqmSampleLanguageService.GetMWQMSampleLanguage_AWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                            CheckMWQMSampleLanguage_AFields(new List<MWQMSampleLanguage_A>() { mwqmSampleLanguage_ARet });
                            Assert.AreEqual(mwqmSampleLanguage.MWQMSampleLanguageID, mwqmSampleLanguage_ARet.MWQMSampleLanguageID);
                        }
                        else if (detail == "B")
                        {
                            MWQMSampleLanguage_B mwqmSampleLanguage_BRet = mwqmSampleLanguageService.GetMWQMSampleLanguage_BWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                            CheckMWQMSampleLanguage_BFields(new List<MWQMSampleLanguage_B>() { mwqmSampleLanguage_BRet });
                            Assert.AreEqual(mwqmSampleLanguage.MWQMSampleLanguageID, mwqmSampleLanguage_BRet.MWQMSampleLanguageID);
                        }
                        else
                        {
                            // nothing for now
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
                    MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSampleLanguage mwqmSampleLanguage = (from c in dbTestDB.MWQMSampleLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSampleLanguage);

                    List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                    mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmSampleLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSampleLanguageID", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSampleLanguageID,MWQMSampleID", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Skip(1).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ThenBy(c => c.MWQMSampleID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleLanguageID", "MWQMSampleLanguageID,EQ,4", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Where(c => c.MWQMSampleLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleLanguageID", "MWQMSampleLanguageID,GT,2|MWQMSampleLanguageID,LT,5", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Where(c => c.MWQMSampleLanguageID > 2 && c.MWQMSampleLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSampleLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleLanguageService.Query = mwqmSampleLanguageService.FillQuery(typeof(MWQMSampleLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSampleLanguageID,GT,2|MWQMSampleLanguageID,LT,5", "");

                        List<MWQMSampleLanguage> mwqmSampleLanguageDirectQueryList = new List<MWQMSampleLanguage>();
                        mwqmSampleLanguageDirectQueryList = (from c in dbTestDB.MWQMSampleLanguages select c).Where(c => c.MWQMSampleLanguageID > 2 && c.MWQMSampleLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                            mwqmSampleLanguageList = mwqmSampleLanguageService.GetMWQMSampleLanguageList().ToList();
                            CheckMWQMSampleLanguageFields(mwqmSampleLanguageList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguageList[0].MWQMSampleLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList = new List<MWQMSampleLanguage_A>();
                            mwqmSampleLanguage_AList = mwqmSampleLanguageService.GetMWQMSampleLanguage_AList().ToList();
                            CheckMWQMSampleLanguage_AFields(mwqmSampleLanguage_AList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList = new List<MWQMSampleLanguage_B>();
                            mwqmSampleLanguage_BList = mwqmSampleLanguageService.GetMWQMSampleLanguage_BList().ToList();
                            CheckMWQMSampleLanguage_BFields(mwqmSampleLanguage_BList);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList[0].MWQMSampleLanguageID, mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
                            Assert.AreEqual(mwqmSampleLanguageDirectQueryList.Count, mwqmSampleLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleLanguageList() 2Where

        #region Functions private
        private void CheckMWQMSampleLanguageFields(List<MWQMSampleLanguage> mwqmSampleLanguageList)
        {
            Assert.IsNotNull(mwqmSampleLanguageList[0].MWQMSampleLanguageID);
            Assert.IsNotNull(mwqmSampleLanguageList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSampleLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguageList[0].MWQMSampleNote));
            Assert.IsNotNull(mwqmSampleLanguageList[0].TranslationStatus);
            Assert.IsNotNull(mwqmSampleLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSampleLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSampleLanguageList[0].HasErrors);
        }
        private void CheckMWQMSampleLanguage_AFields(List<MWQMSampleLanguage_A> mwqmSampleLanguage_AList)
        {
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguage_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguage_AList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_AList[0].TranslationStatusText));
            }
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].MWQMSampleLanguageID);
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_AList[0].MWQMSampleNote));
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].TranslationStatus);
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSampleLanguage_AList[0].HasErrors);
        }
        private void CheckMWQMSampleLanguage_BFields(List<MWQMSampleLanguage_B> mwqmSampleLanguage_BList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].MWQMSampleLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].MWQMSampleLanguageReportTest));
            }
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].TranslationStatusText));
            }
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].MWQMSampleLanguageID);
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleLanguage_BList[0].MWQMSampleNote));
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].TranslationStatus);
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSampleLanguage_BList[0].HasErrors);
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
