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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteID), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteID = 10000000;
                    mwqmSiteService.Update(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSite, CSSPModelsRes.MWQMSiteMWQMSiteID, mwqmSite.MWQMSiteID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteMWQMSiteTVItemID, mwqmSite.MWQMSiteTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteMWQMSiteTVItemID, "MWQMSite"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(8))]
                    // mwqmSite.MWQMSiteNumber   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteNumber)).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteNumber);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteNumber = GetRandomString("", 9);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteNumber, "8"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteDescription)).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteDescription);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteDescription = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteDescription, "200"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteLatestClassification), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // mwqmSite.Ordinal   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = -1;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSiteOrdinal, "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = 1001;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSiteOrdinal, "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSite.MWQMSiteWeb   (MWQMSiteWeb)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteWeb = null;
                    Assert.IsNull(mwqmSite.MWQMSiteWeb);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteWeb = new MWQMSiteWeb();
                    Assert.IsNotNull(mwqmSite.MWQMSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSite.MWQMSiteReport   (MWQMSiteReport)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteReport = null;
                    Assert.IsNull(mwqmSite.MWQMSiteReport);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteReport = new MWQMSiteReport();
                    Assert.IsNotNull(mwqmSite.MWQMSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateDate_UTC = new DateTime();
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteLastUpdateDate_UTC), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteLastUpdateDate_UTC, "1980"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteLastUpdateContactTVItemID, mwqmSite.LastUpdateContactTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteLastUpdateContactTVItemID, "Contact"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    MWQMSite mwqmSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                            Assert.IsNull(mwqmSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(new List<MWQMSite>() { mwqmSiteRet }, entityQueryDetailType);
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

                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(1, mwqmSiteList.Count);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(1, mwqmSiteList.Count);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSiteID,MWQMSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSiteID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(1, mwqmSiteList.Count);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteID", "MWQMSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(1, mwqmSiteList.Count);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSiteID", "MWQMSiteID,GT,2|MWQMSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID > 2 && c.MWQMSiteID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(1, mwqmSiteList.Count);
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
                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    List<MWQMSite> mwqmSiteDirectQueryList = new List<MWQMSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSiteService.Query = mwqmSiteService.FillQuery(typeof(MWQMSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSiteID,GT,2|MWQMSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSiteDirectQueryList = mwqmSiteService.GetRead().Where(c => c.MWQMSiteID > 2 && c.MWQMSiteID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                            Assert.AreEqual(0, mwqmSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSiteList = mwqmSiteService.GetMWQMSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSiteFields(mwqmSiteList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSiteDirectQueryList[0].MWQMSiteID, mwqmSiteList[0].MWQMSiteID);
                        Assert.AreEqual(2, mwqmSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSiteList() 2Where

        #region Functions private
        private void CheckMWQMSiteFields(List<MWQMSite> mwqmSiteList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // MWQMSite fields
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteID);
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteDescription));
            Assert.IsNotNull(mwqmSiteList[0].MWQMSiteLatestClassification);
            Assert.IsNotNull(mwqmSiteList[0].Ordinal);
            Assert.IsNotNull(mwqmSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSiteList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMSiteWeb and MWQMSiteReport fields should be null here
                Assert.IsNull(mwqmSiteList[0].MWQMSiteWeb);
                Assert.IsNull(mwqmSiteList[0].MWQMSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMSiteWeb fields should not be null and MWQMSiteReport fields should be null here
                Assert.IsNotNull(mwqmSiteList[0].MWQMSiteWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(mwqmSiteList[0].MWQMSiteWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteWeb.MWQMSiteLatestClassificationText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteWeb.MWQMSiteLatestClassificationText));
                }
                Assert.IsNull(mwqmSiteList[0].MWQMSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMSiteWeb and MWQMSiteReport fields should NOT be null here
                Assert.IsNotNull(mwqmSiteList[0].MWQMSiteWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(mwqmSiteList[0].MWQMSiteWeb.LastUpdateContactTVItemLanguage);
                if (mwqmSiteList[0].MWQMSiteWeb.MWQMSiteLatestClassificationText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteWeb.MWQMSiteLatestClassificationText));
                }
                if (mwqmSiteList[0].MWQMSiteReport.MWQMSiteReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteReport.MWQMSiteReportTest));
                }
            }
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
