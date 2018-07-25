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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 10000000;
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSiteStartEndDate, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID, mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSiteStartEndDate.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "MWQMSite"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSiteStartEndDate.StartDate   (DateTime)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.StartDate = new DateTime();
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateStartDate), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.StartDate = new DateTime(1979, 1, 1);
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateStartDate, "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateEndDate, "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb   (MWQMSiteStartEndDateWeb)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb = null;
                    Assert.IsNull(mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb = new MWQMSiteStartEndDateWeb();
                    Assert.IsNotNull(mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.MWQMSiteStartEndDateReport   (MWQMSiteStartEndDateReport)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateReport = null;
                    Assert.IsNull(mwqmSiteStartEndDate.MWQMSiteStartEndDateReport);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateReport = new MWQMSiteStartEndDateReport();
                    Assert.IsNotNull(mwqmSiteStartEndDate.MWQMSiteStartEndDateReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSiteStartEndDate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime();
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC, "1980"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSiteStartEndDate.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateContactTVItemID = 0;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateContactTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "Contact"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteStartEndDateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                            Assert.IsNull(mwqmSiteStartEndDateRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(new List<MWQMSiteStartEndDate>() { mwqmSiteStartEndDateRet }, entityQueryDetailType);
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

                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteStartEndDateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(1, mwqmSiteStartEndDateList.Count);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSiteStartEndDateID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(1, mwqmSiteStartEndDateList.Count);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSiteStartEndDateID,MWQMSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(1, mwqmSiteStartEndDateList.Count);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteStartEndDateID", "MWQMSiteStartEndDateID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(1, mwqmSiteStartEndDateList.Count);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteStartEndDateID", "MWQMSiteStartEndDateID,GT,2|MWQMSiteStartEndDateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID > 2 && c.MWQMSiteStartEndDateID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSiteStartEndDateID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(1, mwqmSiteStartEndDateList.Count);
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
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateDirectQueryList = new List<MWQMSiteStartEndDate>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteStartEndDateService.Query = mwqmSiteStartEndDateService.FillQuery(typeof(MWQMSiteStartEndDate), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSiteStartEndDateID,GT,2|MWQMSiteStartEndDateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteStartEndDateDirectQueryList = mwqmSiteStartEndDateService.GetRead().Where(c => c.MWQMSiteStartEndDateID > 2 && c.MWQMSiteStartEndDateID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                            Assert.AreEqual(0, mwqmSiteStartEndDateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteStartEndDateList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteStartEndDateFields(mwqmSiteStartEndDateList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteStartEndDateDirectQueryList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
                        Assert.AreEqual(2, mwqmSiteStartEndDateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteStartEndDateList() 2Where

        #region Functions private
        private void CheckMWQMSiteStartEndDateFields(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // MWQMSiteStartEndDate fields
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].StartDate);
            if (mwqmSiteStartEndDateList[0].EndDate != null)
            {
                Assert.IsNotNull(mwqmSiteStartEndDateList[0].EndDate);
            }
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteStartEndDateList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMSiteStartEndDateWeb and MWQMSiteStartEndDateReport fields should be null here
                Assert.IsNull(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb);
                Assert.IsNull(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMSiteStartEndDateWeb fields should not be null and MWQMSiteStartEndDateReport fields should be null here
                if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.MWQMSiteTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.MWQMSiteTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMSiteStartEndDateWeb and MWQMSiteStartEndDateReport fields should NOT be null here
                if (mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.MWQMSiteTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.MWQMSiteTVText));
                }
                if (mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateWeb.LastUpdateContactTVText));
                }
                if (mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateReport.MWQMSiteStartEndDateReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateReport.MWQMSiteStartEndDateReportTest));
                }
            }
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
