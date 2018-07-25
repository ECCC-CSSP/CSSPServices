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
    public partial class TVItemLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLanguageService tvItemLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageServiceTest() : base()
        {
            //tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemLanguageService.GetRead().Count();

                    Assert.AreEqual(tvItemLanguageService.GetRead().Count(), tvItemLanguageService.GetEdit().Count());

                    tvItemLanguageService.Add(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemLanguageService.GetRead().Where(c => c == tvItemLanguage).Any());
                    tvItemLanguageService.Update(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemLanguageService.GetRead().Count());
                    tvItemLanguageService.Delete(tvItemLanguage);
                    if (tvItemLanguage.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemLanguage.TVItemLanguageID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageID = 0;
                    tvItemLanguageService.Update(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTVItemLanguageID), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageID = 10000000;
                    tvItemLanguageService.Update(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLanguage, CSSPModelsRes.TVItemLanguageTVItemLanguageID, tvItemLanguage.TVItemLanguageID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification)]
                    // tvItemLanguage.TVItemID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemID = 0;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemID = 34;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLanguageTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.Language = (LanguageEnum)1000000;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageLanguage), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // tvItemLanguage.TVText   (String)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
                    Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                    Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
                    Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTVText)).Any());
                    Assert.AreEqual(null, tvItemLanguage.TVText);
                    Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLanguageTVText, "200"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTranslationStatus), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLanguage.TVItemLanguageWeb   (TVItemLanguageWeb)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageWeb = null;
                    Assert.IsNull(tvItemLanguage.TVItemLanguageWeb);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageWeb = new TVItemLanguageWeb();
                    Assert.IsNotNull(tvItemLanguage.TVItemLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLanguage.TVItemLanguageReport   (TVItemLanguageReport)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageReport = null;
                    Assert.IsNull(tvItemLanguage.TVItemLanguageReport);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.TVItemLanguageReport = new TVItemLanguageReport();
                    Assert.IsNotNull(tvItemLanguage.TVItemLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateDate_UTC = new DateTime();
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageLastUpdateDate_UTC), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLanguageLastUpdateDate_UTC, "1980"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateContactTVItemID = 0;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLanguage = null;
                    tvItemLanguage = GetFilledRandomTVItemLanguage("");
                    tvItemLanguage.LastUpdateContactTVItemID = 1;
                    tvItemLanguageService.Add(tvItemLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLanguageLastUpdateContactTVItemID, "Contact"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID)
        [TestMethod]
        public void GetTVItemLanguageWithTVItemLanguageID__tvItemLanguage_TVItemLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLanguage tvItemLanguage = (from c in tvItemLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLanguage);

                    TVItemLanguage tvItemLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                            Assert.IsNull(tvItemLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(new List<TVItemLanguage>() { tvItemLanguageRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID)

        #region Tests Generated for GetTVItemLanguageList()
        [TestMethod]
        public void GetTVItemLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLanguage tvItemLanguage = (from c in tvItemLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLanguage);

                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList()

        #region Tests Generated for GetTVItemLanguageList() Skip Take
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(1, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(1, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order

        #region Tests Generated for GetTVItemLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 1, 1, "TVItemLanguageID,TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemLanguageID).ThenBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(1, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take 2Order

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLanguageID", "TVItemLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Where(c => c.TVItemLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(1, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order Where

        #region Tests Generated for GetTVItemLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLanguageID", "TVItemLanguageID,GT,2|TVItemLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Where(c => c.TVItemLanguageID > 2 && c.TVItemLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(1, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemLanguageList() 2Where
        [TestMethod]
        public void GetTVItemLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    List<TVItemLanguage> tvItemLanguageDirectQueryList = new List<TVItemLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLanguageService.Query = tvItemLanguageService.FillQuery(typeof(TVItemLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemLanguageID,GT,2|TVItemLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLanguageDirectQueryList = tvItemLanguageService.GetRead().Where(c => c.TVItemLanguageID > 2 && c.TVItemLanguageID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                            Assert.AreEqual(0, tvItemLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLanguageList = tvItemLanguageService.GetTVItemLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLanguageFields(tvItemLanguageList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLanguageDirectQueryList[0].TVItemLanguageID, tvItemLanguageList[0].TVItemLanguageID);
                        Assert.AreEqual(2, tvItemLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLanguageList() 2Where

        #region Functions private
        private void CheckTVItemLanguageFields(List<TVItemLanguage> tvItemLanguageList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // TVItemLanguage fields
            Assert.IsNotNull(tvItemLanguageList[0].TVItemLanguageID);
            Assert.IsNotNull(tvItemLanguageList[0].TVItemID);
            Assert.IsNotNull(tvItemLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVText));
            Assert.IsNotNull(tvItemLanguageList[0].TranslationStatus);
            Assert.IsNotNull(tvItemLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVItemLanguageWeb and TVItemLanguageReport fields should be null here
                Assert.IsNull(tvItemLanguageList[0].TVItemLanguageWeb);
                Assert.IsNull(tvItemLanguageList[0].TVItemLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVItemLanguageWeb fields should not be null and TVItemLanguageReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.TranslationStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.TranslationStatusText));
                }
                Assert.IsNull(tvItemLanguageList[0].TVItemLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVItemLanguageWeb and TVItemLanguageReport fields should NOT be null here
                if (tvItemLanguageList[0].TVItemLanguageWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LastUpdateContactTVText));
                }
                if (tvItemLanguageList[0].TVItemLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.LanguageText));
                }
                if (tvItemLanguageList[0].TVItemLanguageWeb.TranslationStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageWeb.TranslationStatusText));
                }
                if (tvItemLanguageList[0].TVItemLanguageReport.TVItemLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageList[0].TVItemLanguageReport.TVItemLanguageReportTest));
                }
            }
        }
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = LanguageRequest;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;

            return tvItemLanguage;
        }
        #endregion Functions private
    }
}
