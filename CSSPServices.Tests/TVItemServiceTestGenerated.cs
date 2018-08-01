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
    public partial class TVItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemService tvItemService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemServiceTest() : base()
        {
            //tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItem_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItem tvItem = GetFilledRandomTVItem("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemService.GetRead().Count();

                    Assert.AreEqual(tvItemService.GetRead().Count(), tvItemService.GetEdit().Count());

                    tvItemService.Add(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
                    tvItemService.Update(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemService.GetRead().Count());
                    tvItemService.Delete(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItem.TVItemID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemID = 0;
                    tvItemService.Update(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVItemID), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemID = 10000000;
                    tvItemService.Update(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemTVItemID, tvItem.TVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItem.TVLevel   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = -1;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());
                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = 101;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvItem.TVPath   (String)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("TVPath");
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(1, tvItem.ValidationResults.Count());
                    Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVPath)).Any());
                    Assert.AreEqual(null, tvItem.TVPath);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemTVPath, "250"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItem.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVType = (TVTypeEnum)1000000;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVType), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
                    // tvItem.ParentID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 0;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemParentID, tvItem.ParentID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 34;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemParentID, "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // tvItem.IsActive   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItem.TVItemWeb   (TVItemWeb)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemWeb = null;
                    Assert.IsNull(tvItem.TVItemWeb);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemWeb = new TVItemWeb();
                    Assert.IsNotNull(tvItem.TVItemWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItem.TVItemReport   (TVItemReport)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemReport = null;
                    Assert.IsNull(tvItem.TVItemReport);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemReport = new TVItemReport();
                    Assert.IsNotNull(tvItem.TVItemReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItem.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateDate_UTC = new DateTime();
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLastUpdateDate_UTC), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLastUpdateDate_UTC, "1980"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItem.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateContactTVItemID = 0;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLastUpdateContactTVItemID, tvItem.LastUpdateContactTVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateContactTVItemID = 1;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLastUpdateContactTVItemID, "Contact"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItem.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItem.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemWithTVItemID(tvItem.TVItemID)
        [TestMethod]
        public void GetTVItemWithTVItemID__tvItem_TVItemID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItem tvItem = (from c in tvItemService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItem);

                    TVItem tvItemRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                            Assert.IsNull(tvItemRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(new List<TVItem>() { tvItemRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemWithTVItemID(tvItem.TVItemID)

        #region Tests Generated for GetTVItemList()
        [TestMethod]
        public void GetTVItemList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItem tvItem = (from c in tvItemService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItem);

                    List<TVItem> tvItemList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList()

        #region Tests Generated for GetTVItemList() Skip Take
        [TestMethod]
        public void GetTVItemList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(1, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() Skip Take

        #region Tests Generated for GetTVItemList() Skip Take Order
        [TestMethod]
        public void GetTVItemList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(1, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() Skip Take Order

        #region Tests Generated for GetTVItemList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1, "TVItemID,TVLevel", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemID).ThenBy(c => c.TVLevel).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(1, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() Skip Take 2Order

        #region Tests Generated for GetTVItemList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 1, "TVItemID", "TVItemID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Where(c => c.TVItemID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(1, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() Skip Take Order Where

        #region Tests Generated for GetTVItemList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 1, "TVItemID", "TVItemID,GT,2|TVItemID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Where(c => c.TVItemID > 2 && c.TVItemID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(1, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemList() 2Where
        [TestMethod]
        public void GetTVItemList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItem> tvItemList = new List<TVItem>();
                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemID,GT,2|TVItemID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemDirectQueryList = tvItemService.GetRead().Where(c => c.TVItemID > 2 && c.TVItemID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            Assert.AreEqual(0, tvItemList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemList = tvItemService.GetTVItemList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemFields(tvItemList, entityQueryDetailType);
                        Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                        Assert.AreEqual(2, tvItemList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() 2Where

        #region Functions private
        private void CheckTVItemFields(List<TVItem> tvItemList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // TVItem fields
            Assert.IsNotNull(tvItemList[0].TVItemID);
            Assert.IsNotNull(tvItemList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVPath));
            Assert.IsNotNull(tvItemList[0].TVType);
            Assert.IsNotNull(tvItemList[0].ParentID);
            Assert.IsNotNull(tvItemList[0].IsActive);
            Assert.IsNotNull(tvItemList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVItemWeb and TVItemReport fields should be null here
                Assert.IsNull(tvItemList[0].TVItemWeb);
                Assert.IsNull(tvItemList[0].TVItemReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVItemWeb fields should not be null and TVItemReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVTypeText));
                }
                Assert.IsNull(tvItemList[0].TVItemReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVItemWeb and TVItemReport fields should NOT be null here
                if (tvItemList[0].TVItemWeb.TVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVText));
                }
                if (tvItemList[0].TVItemWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.LastUpdateContactTVText));
                }
                if (tvItemList[0].TVItemWeb.TVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemWeb.TVTypeText));
                }
                if (tvItemList[0].TVItemReport.TVItemReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVItemReport.TVItemReportTest));
                }
            }
        }
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 1;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;

            return tvItem;
        }
        #endregion Functions private
    }
}
