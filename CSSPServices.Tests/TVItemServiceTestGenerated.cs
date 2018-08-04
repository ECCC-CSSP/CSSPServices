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

                    count = tvItemService.GetTVItemList().Count();

                    Assert.AreEqual(tvItemService.GetTVItemList().Count(), (from c in dbTestDB.TVItems select c).Take(200).Count());

                    tvItemService.Add(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemService.GetTVItemList().Where(c => c == tvItem).Any());
                    tvItemService.Update(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemService.GetTVItemList().Count());
                    tvItemService.Delete(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemTVItemID"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemID = 10000000;
                    tvItemService.Update(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemTVItemID", tvItem.TVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItem.TVLevel   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = -1;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemTVLevel", "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetTVItemList().Count());
                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = 101;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemTVLevel", "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvItem.TVPath   (String)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("TVPath");
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(1, tvItem.ValidationResults.Count());
                    Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TVItemTVPath")).Any());
                    Assert.AreEqual(null, tvItem.TVPath);
                    Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemTVPath", "250"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItem.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVType = (TVTypeEnum)1000000;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemTVType"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
                    // tvItem.ParentID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 0;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemParentID", tvItem.ParentID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 34;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemParentID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // tvItem.IsActive   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItem.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateDate_UTC = new DateTime();
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemLastUpdateDate_UTC"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLastUpdateDate_UTC", "1980"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItem.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateContactTVItemID = 0;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLastUpdateContactTVItemID", tvItem.LastUpdateContactTVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateContactTVItemID = 1;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLastUpdateContactTVItemID", "Contact"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TVItem tvItem = (from c in dbTestDB.TVItems select c).FirstOrDefault();
                    Assert.IsNotNull(tvItem);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            TVItem tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                            CheckTVItemFields(new List<TVItem>() { tvItemRet });
                            Assert.AreEqual(tvItem.TVItemID, tvItemRet.TVItemID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            TVItemWeb tvItemWebRet = tvItemService.GetTVItemWebWithTVItemID(tvItem.TVItemID);
                            CheckTVItemWebFields(new List<TVItemWeb>() { tvItemWebRet });
                            Assert.AreEqual(tvItem.TVItemID, tvItemWebRet.TVItemID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            TVItemReport tvItemReportRet = tvItemService.GetTVItemReportWithTVItemID(tvItem.TVItemID);
                            CheckTVItemReportFields(new List<TVItemReport>() { tvItemReportRet });
                            Assert.AreEqual(tvItem.TVItemID, tvItemReportRet.TVItemID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    TVItem tvItem = (from c in dbTestDB.TVItems select c).FirstOrDefault();
                    Assert.IsNotNull(tvItem);

                    List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                    tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Skip(1).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 1, 1, "TVItemID,TVLevel", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Skip(1).Take(1).OrderBy(c => c.TVItemID).ThenBy(c => c.TVLevel).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 1, "TVItemID", "TVItemID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Where(c => c.TVItemID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 1, "TVItemID", "TVItemID,GT,2|TVItemID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Where(c => c.TVItemID > 2 && c.TVItemID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemService tvItemService = new TVItemService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemService.Query = tvItemService.FillQuery(typeof(TVItem), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemID,GT,2|TVItemID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItem> tvItemDirectQueryList = new List<TVItem>();
                        tvItemDirectQueryList = (from c in dbTestDB.TVItems select c).Where(c => c.TVItemID > 2 && c.TVItemID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItem> tvItemList = new List<TVItem>();
                            tvItemList = tvItemService.GetTVItemList().ToList();
                            CheckTVItemFields(tvItemList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemWeb> tvItemWebList = new List<TVItemWeb>();
                            tvItemWebList = tvItemService.GetTVItemWebList().ToList();
                            CheckTVItemWebFields(tvItemWebList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemWebList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemReport> tvItemReportList = new List<TVItemReport>();
                            tvItemReportList = tvItemService.GetTVItemReportList().ToList();
                            CheckTVItemReportFields(tvItemReportList);
                            Assert.AreEqual(tvItemDirectQueryList[0].TVItemID, tvItemReportList[0].TVItemID);
                            Assert.AreEqual(tvItemDirectQueryList.Count, tvItemReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemList() 2Where

        #region Functions private
        private void CheckTVItemFields(List<TVItem> tvItemList)
        {
            Assert.IsNotNull(tvItemList[0].TVItemID);
            Assert.IsNotNull(tvItemList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemList[0].TVPath));
            Assert.IsNotNull(tvItemList[0].TVType);
            Assert.IsNotNull(tvItemList[0].ParentID);
            Assert.IsNotNull(tvItemList[0].IsActive);
            Assert.IsNotNull(tvItemList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemList[0].HasErrors);
        }
        private void CheckTVItemWebFields(List<TVItemWeb> tvItemWebList)
        {
            Assert.IsNotNull(tvItemWebList[0].TVItemLanguage);
            Assert.IsNotNull(tvItemWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemWebList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemWebList[0].TVTypeText));
            }
            Assert.IsNotNull(tvItemWebList[0].TVItemID);
            Assert.IsNotNull(tvItemWebList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemWebList[0].TVPath));
            Assert.IsNotNull(tvItemWebList[0].TVType);
            Assert.IsNotNull(tvItemWebList[0].ParentID);
            Assert.IsNotNull(tvItemWebList[0].IsActive);
            Assert.IsNotNull(tvItemWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemWebList[0].HasErrors);
        }
        private void CheckTVItemReportFields(List<TVItemReport> tvItemReportList)
        {
            if (!string.IsNullOrWhiteSpace(tvItemReportList[0].TVItemReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemReportList[0].TVItemReportTest));
            }
            Assert.IsNotNull(tvItemReportList[0].TVItemLanguage);
            Assert.IsNotNull(tvItemReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemReportList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemReportList[0].TVTypeText));
            }
            Assert.IsNotNull(tvItemReportList[0].TVItemID);
            Assert.IsNotNull(tvItemReportList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemReportList[0].TVPath));
            Assert.IsNotNull(tvItemReportList[0].TVType);
            Assert.IsNotNull(tvItemReportList[0].ParentID);
            Assert.IsNotNull(tvItemReportList[0].IsActive);
            Assert.IsNotNull(tvItemReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemReportList[0].HasErrors);
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
