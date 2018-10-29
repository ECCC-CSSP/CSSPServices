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
    public partial class MWQMSitePolSourceSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSitePolSourceSiteServiceTest() : base()
        {
            //mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSitePolSourceSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSitePolSourceSite mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.MWQMSitePolSourceSites select c).Count());

                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    if (mwqmSitePolSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Where(c => c == mwqmSitePolSourceSite).Any());
                    mwqmSitePolSourceSiteService.Update(mwqmSitePolSourceSite);
                    if (mwqmSitePolSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Count());
                    mwqmSitePolSourceSiteService.Delete(mwqmSitePolSourceSite);
                    if (mwqmSitePolSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSitePolSourceSite.MWQMSitePolSourceSiteID   (Int32)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.MWQMSitePolSourceSiteID = 0;
                    mwqmSitePolSourceSiteService.Update(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteMWQMSitePolSourceSiteID"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.MWQMSitePolSourceSiteID = 10000000;
                    mwqmSitePolSourceSiteService.Update(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSitePolSourceSite", "MWQMSitePolSourceSiteMWQMSitePolSourceSiteID", mwqmSitePolSourceSite.MWQMSitePolSourceSiteID.ToString()), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSitePolSourceSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.MWQMSiteTVItemID = 0;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSiteMWQMSiteTVItemID", mwqmSitePolSourceSite.MWQMSiteTVItemID.ToString()), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.MWQMSiteTVItemID = 1;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSiteMWQMSiteTVItemID", "MWQMSite"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = PolSourceSite)]
                    // mwqmSitePolSourceSite.PolSourceSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.PolSourceSiteTVItemID = 0;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSitePolSourceSiteTVItemID", mwqmSitePolSourceSite.PolSourceSiteTVItemID.ToString()), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.PolSourceSiteTVItemID = 1;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSitePolSourceSiteTVItemID", "PolSourceSite"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSitePolSourceSite.TVType   (TVTypeEnum)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.TVType = (TVTypeEnum)1000000;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteTVType"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(4000))]
                    // mwqmSitePolSourceSite.LinkReasons   (String)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("LinkReasons");
                    Assert.AreEqual(false, mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite));
                    Assert.AreEqual(1, mwqmSitePolSourceSite.ValidationResults.Count());
                    Assert.IsTrue(mwqmSitePolSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteLinkReasons")).Any());
                    Assert.AreEqual(null, mwqmSitePolSourceSite.LinkReasons);
                    Assert.AreEqual(count, mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Count());

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.LinkReasons = GetRandomString("", 4001);
                    Assert.AreEqual(false, mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSitePolSourceSiteLinkReasons", "4000"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSitePolSourceSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.LastUpdateDate_UTC = new DateTime();
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteLastUpdateDate_UTC"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSitePolSourceSiteLastUpdateDate_UTC", "1980"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSitePolSourceSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.LastUpdateContactTVItemID = 0;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSiteLastUpdateContactTVItemID", mwqmSitePolSourceSite.LastUpdateContactTVItemID.ToString()), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSitePolSourceSite = null;
                    mwqmSitePolSourceSite = GetFilledRandomMWQMSitePolSourceSite("");
                    mwqmSitePolSourceSite.LastUpdateContactTVItemID = 1;
                    mwqmSitePolSourceSiteService.Add(mwqmSitePolSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSiteLastUpdateContactTVItemID", "Contact"), mwqmSitePolSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSitePolSourceSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSitePolSourceSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID)
        [TestMethod]
        public void GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID__mwqmSitePolSourceSite_MWQMSitePolSourceSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSitePolSourceSite mwqmSitePolSourceSite = (from c in dbTestDB.MWQMSitePolSourceSites select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSitePolSourceSite);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmSitePolSourceSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            MWQMSitePolSourceSite mwqmSitePolSourceSiteRet = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID);
                            CheckMWQMSitePolSourceSiteFields(new List<MWQMSitePolSourceSite>() { mwqmSitePolSourceSiteRet });
                            Assert.AreEqual(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteRet.MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            MWQMSitePolSourceSiteExtraA mwqmSitePolSourceSiteExtraARet = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAWithMWQMSitePolSourceSiteID(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID);
                            CheckMWQMSitePolSourceSiteExtraAFields(new List<MWQMSitePolSourceSiteExtraA>() { mwqmSitePolSourceSiteExtraARet });
                            Assert.AreEqual(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraARet.MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraB")
                        {
                            MWQMSitePolSourceSiteExtraB mwqmSitePolSourceSiteExtraBRet = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBWithMWQMSitePolSourceSiteID(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID);
                            CheckMWQMSitePolSourceSiteExtraBFields(new List<MWQMSitePolSourceSiteExtraB>() { mwqmSitePolSourceSiteExtraBRet });
                            Assert.AreEqual(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBRet.MWQMSitePolSourceSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID(mwqmSitePolSourceSite.MWQMSitePolSourceSiteID)

        #region Tests Generated for GetMWQMSitePolSourceSiteList()
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSitePolSourceSite mwqmSitePolSourceSite = (from c in dbTestDB.MWQMSitePolSourceSites select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSitePolSourceSite);

                    List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                    mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmSitePolSourceSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList()

        #region Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take

        #region Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSitePolSourceSiteID", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Skip(1).Take(1).OrderBy(c => c.MWQMSitePolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order

        #region Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSitePolSourceSiteID,MWQMSiteTVItemID", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Skip(1).Take(1).OrderBy(c => c.MWQMSitePolSourceSiteID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take 2Order

        #region Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSitePolSourceSiteID", "MWQMSitePolSourceSiteID,EQ,4", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Where(c => c.MWQMSitePolSourceSiteID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSitePolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order Where

        #region Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSitePolSourceSiteID", "MWQMSitePolSourceSiteID,GT,2|MWQMSitePolSourceSiteID,LT,5", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Where(c => c.MWQMSitePolSourceSiteID > 2 && c.MWQMSitePolSourceSiteID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSitePolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSitePolSourceSiteList() 2Where
        [TestMethod]
        public void GetMWQMSitePolSourceSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMSitePolSourceSiteService mwqmSitePolSourceSiteService = new MWQMSitePolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSitePolSourceSiteService.Query = mwqmSitePolSourceSiteService.FillQuery(typeof(MWQMSitePolSourceSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSitePolSourceSiteID,GT,2|MWQMSitePolSourceSiteID,LT,5", "");

                        List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteDirectQueryList = new List<MWQMSitePolSourceSite>();
                        mwqmSitePolSourceSiteDirectQueryList = (from c in dbTestDB.MWQMSitePolSourceSites select c).Where(c => c.MWQMSitePolSourceSiteID > 2 && c.MWQMSitePolSourceSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList = new List<MWQMSitePolSourceSite>();
                            mwqmSitePolSourceSiteList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteList().ToList();
                            CheckMWQMSitePolSourceSiteFields(mwqmSitePolSourceSiteList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList = new List<MWQMSitePolSourceSiteExtraA>();
                            mwqmSitePolSourceSiteExtraAList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraAList().ToList();
                            CheckMWQMSitePolSourceSiteExtraAFields(mwqmSitePolSourceSiteExtraAList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList = new List<MWQMSitePolSourceSiteExtraB>();
                            mwqmSitePolSourceSiteExtraBList = mwqmSitePolSourceSiteService.GetMWQMSitePolSourceSiteExtraBList().ToList();
                            CheckMWQMSitePolSourceSiteExtraBFields(mwqmSitePolSourceSiteExtraBList);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList[0].MWQMSitePolSourceSiteID, mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
                            Assert.AreEqual(mwqmSitePolSourceSiteDirectQueryList.Count, mwqmSitePolSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSitePolSourceSiteList() 2Where

        #region Functions private
        private void CheckMWQMSitePolSourceSiteFields(List<MWQMSitePolSourceSite> mwqmSitePolSourceSiteList)
        {
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].MWQMSitePolSourceSiteID);
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].PolSourceSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].TVType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteList[0].LinkReasons));
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteList[0].HasErrors);
        }
        private void CheckMWQMSitePolSourceSiteExtraAFields(List<MWQMSitePolSourceSiteExtraA> mwqmSitePolSourceSiteExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraAList[0].MWQMSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraAList[0].PolSourceSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraAList[0].LastUpdateContactText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraAList[0].TVTypeText));
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].MWQMSitePolSourceSiteID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].PolSourceSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].TVType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraAList[0].LinkReasons));
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraAList[0].HasErrors);
        }
        private void CheckMWQMSitePolSourceSiteExtraBFields(List<MWQMSitePolSourceSiteExtraB> mwqmSitePolSourceSiteExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].MWQMSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].PolSourceSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].LastUpdateContactText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].TVTypeText));
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].MWQMSitePolSourceSiteID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].PolSourceSiteTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].TVType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSitePolSourceSiteExtraBList[0].LinkReasons));
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSitePolSourceSiteExtraBList[0].HasErrors);
        }
        private MWQMSitePolSourceSite GetFilledRandomMWQMSitePolSourceSite(string OmitPropName)
        {
            MWQMSitePolSourceSite mwqmSitePolSourceSite = new MWQMSitePolSourceSite();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSitePolSourceSite.MWQMSiteTVItemID = 43;
            if (OmitPropName != "PolSourceSiteTVItemID") mwqmSitePolSourceSite.PolSourceSiteTVItemID = 46;
            if (OmitPropName != "TVType") mwqmSitePolSourceSite.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LinkReasons") mwqmSitePolSourceSite.LinkReasons = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSitePolSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSitePolSourceSite.LastUpdateContactTVItemID = 2;

            return mwqmSitePolSourceSite;
        }
        #endregion Functions private
    }
}
