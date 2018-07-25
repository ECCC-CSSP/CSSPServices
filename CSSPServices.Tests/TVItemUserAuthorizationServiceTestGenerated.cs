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
    public partial class TVItemUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationServiceTest() : base()
        {
            //tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemUserAuthorization_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvItemUserAuthorizationService.GetRead().Count();

                    Assert.AreEqual(tvItemUserAuthorizationService.GetRead().Count(), tvItemUserAuthorizationService.GetEdit().Count());

                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetRead().Count());
                    tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemUserAuthorization.TVItemUserAuthorizationID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationID = 0;
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemUserAuthorization, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID, tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID1   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID2   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID3   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID4   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVAuth), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.TVItemUserAuthorizationWeb   (TVItemUserAuthorizationWeb)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationWeb = null;
                    Assert.IsNull(tvItemUserAuthorization.TVItemUserAuthorizationWeb);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationWeb = new TVItemUserAuthorizationWeb();
                    Assert.IsNotNull(tvItemUserAuthorization.TVItemUserAuthorizationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.TVItemUserAuthorizationReport   (TVItemUserAuthorizationReport)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationReport = null;
                    Assert.IsNull(tvItemUserAuthorization.TVItemUserAuthorizationReport);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationReport = new TVItemUserAuthorizationReport();
                    Assert.IsNotNull(tvItemUserAuthorization.TVItemUserAuthorizationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime();
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC, "1980"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID)
        [TestMethod]
        public void GetTVItemUserAuthorizationWithTVItemUserAuthorizationID__tvItemUserAuthorization_TVItemUserAuthorizationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemUserAuthorization tvItemUserAuthorization = (from c in tvItemUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemUserAuthorization);

                    TVItemUserAuthorization tvItemUserAuthorizationRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                            Assert.IsNull(tvItemUserAuthorizationRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(new List<TVItemUserAuthorization>() { tvItemUserAuthorizationRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID)

        #region Tests Generated for GetTVItemUserAuthorizationList()
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVItemUserAuthorization tvItemUserAuthorization = (from c in tvItemUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemUserAuthorization);

                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList()

        #region Tests Generated for GetTVItemUserAuthorizationList() Skip Take
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(1, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() Skip Take

        #region Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemUserAuthorizationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(1, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order

        #region Tests Generated for GetTVItemUserAuthorizationList() Skip Take 2Order
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "TVItemUserAuthorizationID,ContactTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ThenBy(c => c.ContactTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(1, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() Skip Take 2Order

        #region Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order Where
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVItemUserAuthorizationID", "TVItemUserAuthorizationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Where(c => c.TVItemUserAuthorizationID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(1, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order Where

        #region Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVItemUserAuthorizationList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVItemUserAuthorizationID", "TVItemUserAuthorizationID,GT,2|TVItemUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Where(c => c.TVItemUserAuthorizationID > 2 && c.TVItemUserAuthorizationID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(1, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() Skip Take Order 2Where

        #region Tests Generated for GetTVItemUserAuthorizationList() 2Where
        [TestMethod]
        public void GetTVItemUserAuthorizationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemUserAuthorizationID,GT,2|TVItemUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvItemUserAuthorizationDirectQueryList = tvItemUserAuthorizationService.GetRead().Where(c => c.TVItemUserAuthorizationID > 2 && c.TVItemUserAuthorizationID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvItemUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                        Assert.AreEqual(2, tvItemUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() 2Where

        #region Functions private
        private void CheckTVItemUserAuthorizationFields(List<TVItemUserAuthorization> tvItemUserAuthorizationList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // TVItemUserAuthorization fields
            Assert.IsNotNull(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
            Assert.IsNotNull(tvItemUserAuthorizationList[0].ContactTVItemID);
            Assert.IsNotNull(tvItemUserAuthorizationList[0].TVItemID1);
            if (tvItemUserAuthorizationList[0].TVItemID2 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationList[0].TVItemID2);
            }
            if (tvItemUserAuthorizationList[0].TVItemID3 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationList[0].TVItemID3);
            }
            if (tvItemUserAuthorizationList[0].TVItemID4 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationList[0].TVItemID4);
            }
            Assert.IsNotNull(tvItemUserAuthorizationList[0].TVAuth);
            Assert.IsNotNull(tvItemUserAuthorizationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemUserAuthorizationList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVItemUserAuthorizationWeb and TVItemUserAuthorizationReport fields should be null here
                Assert.IsNull(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb);
                Assert.IsNull(tvItemUserAuthorizationList[0].TVItemUserAuthorizationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVItemUserAuthorizationWeb fields should not be null and TVItemUserAuthorizationReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.ContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.ContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText1))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText1));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText2))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText2));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText3))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText3));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText4))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText4));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVAuthText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVAuthText));
                }
                Assert.IsNull(tvItemUserAuthorizationList[0].TVItemUserAuthorizationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVItemUserAuthorizationWeb and TVItemUserAuthorizationReport fields should NOT be null here
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.ContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.ContactTVText));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText1 != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText1));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText2 != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText2));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText3 != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText3));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText4 != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVText4));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.LastUpdateContactTVText));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVAuthText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationWeb.TVAuthText));
                }
                if (tvItemUserAuthorizationList[0].TVItemUserAuthorizationReport.TVItemUserAuthorizationReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationList[0].TVItemUserAuthorizationReport.TVItemUserAuthorizationReportTest));
                }
            }
        }
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 1;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 1;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 1;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 1;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvItemUserAuthorization;
        }
        #endregion Functions private
    }
}
