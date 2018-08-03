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
    public partial class MWQMSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSiteService mwqmSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteServiceTest() : base()
        {
            //mwqmSiteService = new MWQMSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSite mwqmSite = GetFilledRandomMWQMSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSiteService.GetRead().Count();

                    Assert.AreEqual(mwqmSiteService.GetRead().Count(), mwqmSiteService.GetEdit().Count());

                    mwqmSiteService.Add(mwqmSite);
                    if (mwqmSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSiteService.GetRead().Where(c => c == mwqmSite).Any());
                    mwqmSiteService.Update(mwqmSite);
                    if (mwqmSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSiteService.GetRead().Count());
                    mwqmSiteService.Delete(mwqmSite);
                    if (mwqmSite.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSite.MWQMSiteID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteID = 0;
                    mwqmSiteService.Update(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteID"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteID = 10000000;
                    mwqmSiteService.Update(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteMWQMSiteID", mwqmSite.MWQMSiteID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteMWQMSiteTVItemID", mwqmSite.MWQMSiteTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteMWQMSiteTVItemID", "MWQMSite"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(8))]
                    // mwqmSite.MWQMSiteNumber   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteNumber")).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteNumber);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteNumber = GetRandomString("", 9);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSiteMWQMSiteNumber", "8"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // mwqmSite.MWQMSiteDescription   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("MWQMSiteDescription");
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteDescription")).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteDescription);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteDescription = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSiteMWQMSiteDescription", "200"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSite.MWQMSiteLatestClassification   (MWQMSiteLatestClassificationEnum)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)1000000;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteLatestClassification"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // mwqmSite.Ordinal   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = -1;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSiteOrdinal", "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = 1001;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSiteOrdinal", "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateDate_UTC = new DateTime();
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteLastUpdateDate_UTC"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteLastUpdateDate_UTC", "1980"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteLastUpdateContactTVItemID", mwqmSite.LastUpdateContactTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteLastUpdateContactTVItemID", "Contact"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID)
        [TestMethod]
        public void GetMWQMSiteWithMWQMSiteID__mwqmSite_MWQMSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSite mwqmSite = (from c in mwqmSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSite);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MWQMSite mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                            CheckMWQMSiteFields(new List<MWQMSite>() { mwqmSiteRet });
                            Assert.AreEqual(mwqmSite.MWQMSiteID, mwqmSiteRet.MWQMSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MWQMSiteWeb mwqmSiteWebRet = mwqmSiteService.GetMWQMSiteWebWithMWQMSiteID(mwqmSite.MWQMSiteID);
                            CheckMWQMSiteWebFields(new List<MWQMSiteWeb>() { mwqmSiteWebRet });
                            Assert.AreEqual(mwqmSite.MWQMSiteID, mwqmSiteWebRet.MWQMSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MWQMSiteReport mwqmSiteReportRet = mwqmSiteService.GetMWQMSiteReportWithMWQMSiteID(mwqmSite.MWQMSiteID);
                            CheckMWQMSiteReportFields(new List<MWQMSiteReport>() { mwqmSiteReportRet });
                            Assert.AreEqual(mwqmSite.MWQMSiteID, mwqmSiteReportRet.MWQMSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID)

        #region Tests Generated for GetMWQMSiteList()
        [TestMethod]
        public void GetMWQMSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSite mwqmSite = (from c in mwqmSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSite);

                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList()

        #region Tests Generated for GetMWQMSiteList() Skip Take
        [TestMethod]
        public void GetMWQMSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() Skip Take

        #region Tests Generated for GetMWQMSiteList() Skip Take Order
        [TestMethod]
        public void GetMWQMSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() Skip Take Order

        #region Tests Generated for GetMWQMSiteList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSiteID,MWQMSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() Skip Take 2Order

        #region Tests Generated for GetMWQMSiteList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteID", "MWQMSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() Skip Take Order Where

        #region Tests Generated for GetMWQMSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteID", "MWQMSiteID,GT,2|MWQMSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID > 2 && c.MWQMSiteID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSiteList() 2Where
        [TestMethod]
        public void GetMWQMSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSiteID,GT,2|MWQMSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID > 2 && c.MWQMSiteID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            CheckMWQMSiteFields(mwqmSiteList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteWeb> mwqmSiteWebList = new List<MWQMSiteWeb>();
                            mwqmSiteWebList = mwqmSiteService.GetMWQMSiteWebList().ToList();
                            CheckMWQMSiteWebFields(mwqmSiteWebList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteWebList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteReport> mwqmSiteReportList = new List<MWQMSiteReport>();
                            mwqmSiteReportList = mwqmSiteService.GetMWQMSiteReportList().ToList();
                            CheckMWQMSiteReportFields(mwqmSiteReportList);
                            Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteReportList[0].MWQMSiteID);
                            Assert.AreEqual(mwqmSiteDirectQueryList.Count, mwqmSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() 2Where

        #region Functions private
        private void CheckMWQMSiteFields(List<MWQMSite> mwqmSiteList)
        {
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteID);
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteDescription));
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteLatestClassification);
            Assert.IsNotNull(mwqmSiteList[0].Ordinal);
            Assert.IsNotNull(mwqmSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteList[0].HasErrors);
        }
        private void CheckMWQMSiteWebFields(List<MWQMSiteWeb> mwqmSiteWebList)
        {
            Assert.IsNotNull(mwqmSiteWebList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSiteWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSiteWebList[0].MWQMSiteLatestClassificationText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteWebList[0].MWQMSiteLatestClassificationText));
            }
            Assert.IsNotNull(mwqmSiteWebList[0].MWQMSiteID);
            Assert.IsNotNull(mwqmSiteWebList[0].MWQMSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteWebList[0].MWQMSiteNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteWebList[0].MWQMSiteDescription));
            Assert.IsNotNull(mwqmSiteWebList[0].MWQMSiteLatestClassification);
            Assert.IsNotNull(mwqmSiteWebList[0].Ordinal);
            Assert.IsNotNull(mwqmSiteWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteWebList[0].HasErrors);
        }
        private void CheckMWQMSiteReportFields(List<MWQMSiteReport> mwqmSiteReportList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteReportTest));
            }
            Assert.IsNotNull(mwqmSiteReportList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSiteReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteLatestClassificationText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteLatestClassificationText));
            }
            Assert.IsNotNull(mwqmSiteReportList[0].MWQMSiteID);
            Assert.IsNotNull(mwqmSiteReportList[0].MWQMSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteReportList[0].MWQMSiteDescription));
            Assert.IsNotNull(mwqmSiteReportList[0].MWQMSiteLatestClassification);
            Assert.IsNotNull(mwqmSiteReportList[0].Ordinal);
            Assert.IsNotNull(mwqmSiteReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteReportList[0].HasErrors);
        }
        private MWQMSite GetFilledRandomMWQMSite(string OmitPropName)
        {
            MWQMSite mwqmSite = new MWQMSite();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSite.MWQMSiteTVItemID = 40;
            if (OmitPropName != "MWQMSiteNumber") mwqmSite.MWQMSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteDescription") mwqmSite.MWQMSiteDescription = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteLatestClassification") mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)GetRandomEnumType(typeof(MWQMSiteLatestClassificationEnum));
            if (OmitPropName != "Ordinal") mwqmSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSite.LastUpdateContactTVItemID = 2;

            return mwqmSite;
        }
        #endregion Functions private
    }
}
