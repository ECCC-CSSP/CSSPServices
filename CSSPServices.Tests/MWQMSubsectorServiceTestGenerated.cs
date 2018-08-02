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
    public partial class MWQMSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSubsectorService mwqmSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorServiceTest() : base()
        {
            //mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSubsectorService.GetRead().Count();

                    Assert.AreEqual(mwqmSubsectorService.GetRead().Count(), mwqmSubsectorService.GetEdit().Count());

                    mwqmSubsectorService.Add(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSubsectorService.GetRead().Where(c => c == mwqmSubsector).Any());
                    mwqmSubsectorService.Update(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSubsectorService.GetRead().Count());
                    mwqmSubsectorService.Delete(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSubsector.MWQMSubsectorID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorID = 0;
                    mwqmSubsectorService.Update(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorMWQMSubsectorID), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorID = 10000000;
                    mwqmSubsectorService.Update(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsector, CSSPModelsRes.MWQMSubsectorMWQMSubsectorID, mwqmSubsector.MWQMSubsectorID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorTVItemID = 0;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, mwqmSubsector.MWQMSubsectorTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorTVItemID = 1;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "Subsector"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(20))]
                    // mwqmSubsector.SubsectorHistoricKey   (String)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
                    Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorSubsectorHistoricKey)).Any());
                    Assert.AreEqual(null, mwqmSubsector.SubsectorHistoricKey);
                    Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorSubsectorHistoricKey, "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // mwqmSubsector.TideLocationSIDText   (String)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.TideLocationSIDText = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorTideLocationSIDText, "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSubsector.MWQMSubsectorWeb   (MWQMSubsectorWeb)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorWeb = null;
                    Assert.IsNull(mwqmSubsector.MWQMSubsectorWeb);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorWeb = new MWQMSubsectorWeb();
                    Assert.IsNotNull(mwqmSubsector.MWQMSubsectorWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSubsector.MWQMSubsectorReport   (MWQMSubsectorReport)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorReport = null;
                    Assert.IsNull(mwqmSubsector.MWQMSubsectorReport);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorReport = new MWQMSubsectorReport();
                    Assert.IsNotNull(mwqmSubsector.MWQMSubsectorReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateDate_UTC = new DateTime();
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLastUpdateDate_UTC), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSubsectorLastUpdateDate_UTC, "1980"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateContactTVItemID = 0;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorLastUpdateContactTVItemID, mwqmSubsector.LastUpdateContactTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateContactTVItemID = 1;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "Contact"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsector.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsector.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID)
        [TestMethod]
        public void GetMWQMSubsectorWithMWQMSubsectorID__mwqmSubsector_MWQMSubsectorID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsector mwqmSubsector = (from c in mwqmSubsectorService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsector);

                    MWQMSubsector mwqmSubsectorRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                            Assert.IsNull(mwqmSubsectorRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(new List<MWQMSubsector>() { mwqmSubsectorRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID)

        #region Tests Generated for GetMWQMSubsectorList()
        [TestMethod]
        public void GetMWQMSubsectorList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsector mwqmSubsector = (from c in mwqmSubsectorService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsector);

                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList()

        #region Tests Generated for GetMWQMSubsectorList() Skip Take
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(1, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(1, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order

        #region Tests Generated for GetMWQMSubsectorList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSubsectorID,MWQMSubsectorTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorID).ThenBy(c => c.MWQMSubsectorTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(1, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take 2Order

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorID", "MWQMSubsectorID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Where(c => c.MWQMSubsectorID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(1, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order Where

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorID", "MWQMSubsectorID,GT,2|MWQMSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Where(c => c.MWQMSubsectorID > 2 && c.MWQMSubsectorID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(1, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSubsectorList() 2Where
        [TestMethod]
        public void GetMWQMSubsectorList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSubsectorID,GT,2|MWQMSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSubsectorDirectQueryList = mwqmSubsectorService.GetRead().Where(c => c.MWQMSubsectorID > 2 && c.MWQMSubsectorID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            Assert.AreEqual(0, mwqmSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSubsectorFields(mwqmSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                        Assert.AreEqual(2, mwqmSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() 2Where

        #region Functions private
        private void CheckMWQMSubsectorFields(List<MWQMSubsector> mwqmSubsectorList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // MWQMSubsector fields
            Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText));
            }
            Assert.IsNotNull(mwqmSubsectorList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMSubsectorWeb and MWQMSubsectorReport fields should be null here
                Assert.IsNull(mwqmSubsectorList[0].MWQMSubsectorWeb);
                Assert.IsNull(mwqmSubsectorList[0].MWQMSubsectorReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMSubsectorWeb fields should not be null and MWQMSubsectorReport fields should be null here
                Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorWeb.SubsectorTVItemLanguage);
                Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(mwqmSubsectorList[0].MWQMSubsectorReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMSubsectorWeb and MWQMSubsectorReport fields should NOT be null here
                Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorWeb.SubsectorTVItemLanguage);
                Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorWeb.LastUpdateContactTVItemLanguage);
                if (mwqmSubsectorList[0].MWQMSubsectorReport.MWQMSubsectorReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].MWQMSubsectorReport.MWQMSubsectorReportTest));
                }
            }
        }
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;

            return mwqmSubsector;
        }
        #endregion Functions private
    }
}
