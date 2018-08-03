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
    public partial class MWQMSiteStartEndDateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateServiceTest() : base()
        {
            //mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSiteStartEndDate_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSiteStartEndDate mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSiteStartEndDateService.GetRead().Count();

                    Assert.AreEqual(mwqmSiteStartEndDateService.GetRead().Count(), mwqmSiteStartEndDateService.GetEdit().Count());

                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSiteStartEndDateService.GetRead().Where(c => c == mwqmSiteStartEndDate).Any());
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSiteStartEndDateService.GetRead().Count());
                    mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSiteStartEndDateService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSiteStartEndDate.MWQMSiteStartEndDateID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 0;
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateMWQMSiteStartEndDateID"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 10000000;
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateMWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSiteStartEndDate.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteStartEndDateMWQMSiteTVItemID", mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteStartEndDateMWQMSiteTVItemID", "MWQMSite"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSiteStartEndDate.StartDate   (DateTime)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.StartDate = new DateTime();
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateStartDate"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.StartDate = new DateTime(1979, 1, 1);
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateStartDate", "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDate)]
                    // mwqmSiteStartEndDate.EndDate   (DateTime)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.EndDate = new DateTime(1979, 1, 1);
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateEndDate", "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSiteStartEndDate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime();
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateLastUpdateDate_UTC"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateLastUpdateDate_UTC", "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSiteStartEndDate.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateContactTVItemID = 0;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteStartEndDateLastUpdateContactTVItemID", mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateContactTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteStartEndDateLastUpdateContactTVItemID", "Contact"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID)
        [TestMethod]
        public void GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID__mwqmSiteStartEndDate_MWQMSiteStartEndDateID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in mwqmSiteStartEndDateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSiteStartEndDate);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteStartEndDateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MWQMSiteStartEndDate mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                            CheckMWQMSiteStartEndDateFields(new List<MWQMSiteStartEndDate>() { mwqmSiteStartEndDateRet });
                            Assert.AreEqual(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MWQMSiteStartEndDateWeb mwqmSiteStartEndDateWebRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                            CheckMWQMSiteStartEndDateWebFields(new List<MWQMSiteStartEndDateWeb>() { mwqmSiteStartEndDateWebRet });
                            Assert.AreEqual(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebRet.MWQMSiteStartEndDateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MWQMSiteStartEndDateReport mwqmSiteStartEndDateReportRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                            CheckMWQMSiteStartEndDateReportFields(new List<MWQMSiteStartEndDateReport>() { mwqmSiteStartEndDateReportRet });
                            Assert.AreEqual(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportRet.MWQMSiteStartEndDateID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID)

        #region Tests Generated for GetMWQMSiteStartEndDateList()
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in mwqmSiteStartEndDateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSiteStartEndDate);

                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteStartEndDateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList()

        #region Tests Generated for GetMWQMSiteStartEndDateList() Skip Take
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() Skip Take

        #region Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSiteStartEndDateID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order

        #region Tests Generated for GetMWQMSiteStartEndDateList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSiteStartEndDateID,MWQMSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() Skip Take 2Order

        #region Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteStartEndDateID", "MWQMSiteStartEndDateID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order Where

        #region Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteStartEndDateID", "MWQMSiteStartEndDateID,GT,2|MWQMSiteStartEndDateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID > 2 && c.MWQMSiteStartEndDateID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSiteStartEndDateList() 2Where
        [TestMethod]
        public void GetMWQMSiteStartEndDateList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSiteStartEndDateID,GT,2|MWQMSiteStartEndDateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID > 2 && c.MWQMSiteStartEndDateID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList = new List<MWQMSiteStartEndDateWeb>();
                            mwqmSiteStartEndDateWebList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWebList().ToList();
                            CheckMWQMSiteStartEndDateWebFields(mwqmSiteStartEndDateWebList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList = new List<MWQMSiteStartEndDateReport>();
                            mwqmSiteStartEndDateReportList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateReportList().ToList();
                            CheckMWQMSiteStartEndDateReportFields(mwqmSiteStartEndDateReportList);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
                            Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList.Count, mwqmSiteStartEndDateReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() 2Where

        #region Functions private
        private void CheckMWQMSiteStartEndDateFields(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList)
        {
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].StartDate);
            if (mwqmSiteStartEndDateList[0].EndDate != null)
            {
                Assert.IsNotNull(mwqmSiteStartEndDateList[0].EndDate);
            }
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].HasErrors);
        }
        private void CheckMWQMSiteStartEndDateWebFields(List<MWQMSiteStartEndDateWeb> mwqmSiteStartEndDateWebList)
        {
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].MWQMSiteStartEndDateID);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].StartDate);
            if (mwqmSiteStartEndDateWebList[0].EndDate != null)
            {
                Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].EndDate);
            }
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateWebList[0].HasErrors);
        }
        private void CheckMWQMSiteStartEndDateReportFields(List<MWQMSiteStartEndDateReport> mwqmSiteStartEndDateReportList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateReportTest));
            }
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].MWQMSiteStartEndDateID);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].StartDate);
            if (mwqmSiteStartEndDateReportList[0].EndDate != null)
            {
                Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].EndDate);
            }
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateReportList[0].HasErrors);
        }
        private MWQMSiteStartEndDate GetFilledRandomMWQMSiteStartEndDate(string OmitPropName)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSiteStartEndDate.MWQMSiteTVItemID = 40;
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private
    }
}
