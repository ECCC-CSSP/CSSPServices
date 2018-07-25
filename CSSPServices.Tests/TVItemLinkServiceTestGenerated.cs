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
    public partial class TVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLinkService tvItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkServiceTest() : base()
        {
            //tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLink_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemLink tvItemLink = GetFilledRandomTVItemLink("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemLinkService.GetRead().Count();

                    Assert.AreEqual(tvItemLinkService.GetRead().Count(), tvItemLinkService.GetEdit().Count());

                    tvItemLinkService.Add(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemLinkService.GetRead().Where(c => c == tvItemLink).Any());
                    tvItemLinkService.Update(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemLinkService.GetRead().Count());
                    tvItemLinkService.Delete(tvItemLink);
                    if (tvItemLink.HasErrors)
                    {
                        Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemLink.TVItemLinkID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkID = 0;
                    tvItemLinkService.Update(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVItemLinkID), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkID = 10000000;
                    tvItemLinkService.Update(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkTVItemLinkID, tvItemLink.TVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.FromTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVItemID = 13;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkFromTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemLink.ToTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVItemID = 13;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkToTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.FromTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.FromTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkFromTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemLink.ToTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ToTVType = (TVTypeEnum)1000000;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkToTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.StartDateTime_Local = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkStartDateTime_Local, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // tvItemLink.EndDateTime_Local   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.EndDateTime_Local = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkEndDateTime_Local, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.Ordinal   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.Ordinal = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItemLink.TVLevel   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = -1;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVLevel = 101;
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvItemLink.TVPath   (String)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("TVPath");
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
                    Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVPath)).Any());
                    Assert.AreEqual(null, tvItemLink.TVPath);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLinkTVPath, "250"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID", AllowableTVtypeList = Error)]
                    // tvItemLink.ParentTVItemLinkID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.ParentTVItemLinkID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLink.TVItemLinkWeb   (TVItemLinkWeb)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkWeb = null;
                    Assert.IsNull(tvItemLink.TVItemLinkWeb);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkWeb = new TVItemLinkWeb();
                    Assert.IsNotNull(tvItemLink.TVItemLinkWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemLink.TVItemLinkReport   (TVItemLinkReport)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkReport = null;
                    Assert.IsNull(tvItemLink.TVItemLinkReport);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.TVItemLinkReport = new TVItemLinkReport();
                    Assert.IsNotNull(tvItemLink.TVItemLinkReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemLink.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime();
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC, "1980"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemLink.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 0;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemLink = null;
                    tvItemLink = GetFilledRandomTVItemLink("");
                    tvItemLink.LastUpdateContactTVItemID = 1;
                    tvItemLinkService.Add(tvItemLink);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLink.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemLink.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID)
        [TestMethod]
        public void GetTVItemLinkWithTVItemLinkID__tvItemLink_TVItemLinkID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLink tvItemLink = (from c in tvItemLinkService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLink);

                    TVItemLink tvItemLinkRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemLinkService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                            Assert.IsNull(tvItemLinkRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(new List<TVItemLink>() { tvItemLinkRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID)

        #region Tests Generated for GetTVItemLinkList()
        [TestMethod]
        public void GetTVItemLinkList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemLink tvItemLink = (from c in tvItemLinkService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemLink);

                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemLinkService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList()

        #region Tests Generated for GetTVItemLinkList() Skip Take
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(1, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take

        #region Tests Generated for GetTVItemLinkList() Skip Take Order
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemLinkID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(1, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order

        #region Tests Generated for GetTVItemLinkList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 1, 1, "TVItemLinkID,FromTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemLinkID).ThenBy(c => c.FromTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(1, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take 2Order

        #region Tests Generated for GetTVItemLinkList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLinkID", "TVItemLinkID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Where(c => c.TVItemLinkID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(1, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order Where

        #region Tests Generated for GetTVItemLinkList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemLinkList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 1, "TVItemLinkID", "TVItemLinkID,GT,2|TVItemLinkID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Where(c => c.TVItemLinkID > 2 && c.TVItemLinkID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemLinkID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(1, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemLinkList() 2Where
        [TestMethod]
        public void GetTVItemLinkList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    List<TVItemLink> tvItemLinkDirectQueryList = new List<TVItemLink>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemLinkService.Query = tvItemLinkService.FillQuery(typeof(TVItemLink), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemLinkID,GT,2|TVItemLinkID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemLinkDirectQueryList = tvItemLinkService.GetRead().Where(c => c.TVItemLinkID > 2 && c.TVItemLinkID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                            Assert.AreEqual(0, tvItemLinkList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemLinkList = tvItemLinkService.GetTVItemLinkList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemLinkFields(tvItemLinkList, entityQueryDetailType);
                        Assert.AreEqual(tvItemLinkDirectQueryList[0].TVItemLinkID, tvItemLinkList[0].TVItemLinkID);
                        Assert.AreEqual(2, tvItemLinkList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemLinkList() 2Where

        #region Functions private
        private void CheckTVItemLinkFields(List<TVItemLink> tvItemLinkList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // TVItemLink fields
            Assert.IsNotNull(tvItemLinkList[0].TVItemLinkID);
            Assert.IsNotNull(tvItemLinkList[0].FromTVItemID);
            Assert.IsNotNull(tvItemLinkList[0].ToTVItemID);
            Assert.IsNotNull(tvItemLinkList[0].FromTVType);
            Assert.IsNotNull(tvItemLinkList[0].ToTVType);
            if (tvItemLinkList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].StartDateTime_Local);
            }
            if (tvItemLinkList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(tvItemLinkList[0].Ordinal);
            Assert.IsNotNull(tvItemLinkList[0].TVLevel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVPath));
            if (tvItemLinkList[0].ParentTVItemLinkID != null)
            {
                Assert.IsNotNull(tvItemLinkList[0].ParentTVItemLinkID);
            }
            Assert.IsNotNull(tvItemLinkList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemLinkList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVItemLinkWeb and TVItemLinkReport fields should be null here
                Assert.IsNull(tvItemLinkList[0].TVItemLinkWeb);
                Assert.IsNull(tvItemLinkList[0].TVItemLinkReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVItemLinkWeb fields should not be null and TVItemLinkReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVTypeText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVTypeText));
                }
                Assert.IsNull(tvItemLinkList[0].TVItemLinkReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVItemLinkWeb and TVItemLinkReport fields should NOT be null here
                if (tvItemLinkList[0].TVItemLinkWeb.FromTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVText));
                }
                if (tvItemLinkList[0].TVItemLinkWeb.ToTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVText));
                }
                if (tvItemLinkList[0].TVItemLinkWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.LastUpdateContactTVText));
                }
                if (tvItemLinkList[0].TVItemLinkWeb.FromTVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.FromTVTypeText));
                }
                if (tvItemLinkList[0].TVItemLinkWeb.ToTVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkWeb.ToTVTypeText));
                }
                if (tvItemLinkList[0].TVItemLinkReport.TVItemLinkReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkList[0].TVItemLinkReport.TVItemLinkReportTest));
                }
            }
        }
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = 1;
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = 1;
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            // Need to implement [TVItemLink ParentTVItemLinkID TVItemLink TVItemLinkID]
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = 2;

            return tvItemLink;
        }
        #endregion Functions private
    }
}
