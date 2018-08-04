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

                    count = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().Count();

                    Assert.AreEqual(tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().Count(), (from c in dbTestDB.TVItemUserAuthorizations select c).Take(200).Count());

                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().Where(c => c == tvItemUserAuthorization).Any());
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().Count());
                    tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationTVItemUserAuthorizationID"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationTVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationContactTVItemID", tvItemUserAuthorization.ContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationContactTVItemID", "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID1   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID1", tvItemUserAuthorization.TVItemID1.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID1", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID2   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID2", tvItemUserAuthorization.TVItemID2.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID2", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID3   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID3", tvItemUserAuthorization.TVItemID3.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID3", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint)]
                    // tvItemUserAuthorization.TVItemID4   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID4", tvItemUserAuthorization.TVItemID4.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 13;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID4", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationTVAuth"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime();
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationLastUpdateDate_UTC"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemUserAuthorizationLastUpdateDate_UTC", "1980"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationLastUpdateContactTVItemID", tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationLastUpdateContactTVItemID", "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TVItemUserAuthorization tvItemUserAuthorization = (from c in dbTestDB.TVItemUserAuthorizations select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemUserAuthorization);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            TVItemUserAuthorization tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                            CheckTVItemUserAuthorizationFields(new List<TVItemUserAuthorization>() { tvItemUserAuthorizationRet });
                            Assert.AreEqual(tvItemUserAuthorization.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            TVItemUserAuthorizationWeb tvItemUserAuthorizationWebRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                            CheckTVItemUserAuthorizationWebFields(new List<TVItemUserAuthorizationWeb>() { tvItemUserAuthorizationWebRet });
                            Assert.AreEqual(tvItemUserAuthorization.TVItemUserAuthorizationID, tvItemUserAuthorizationWebRet.TVItemUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            TVItemUserAuthorizationReport tvItemUserAuthorizationReportRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                            CheckTVItemUserAuthorizationReportFields(new List<TVItemUserAuthorizationReport>() { tvItemUserAuthorizationReportRet });
                            Assert.AreEqual(tvItemUserAuthorization.TVItemUserAuthorizationID, tvItemUserAuthorizationReportRet.TVItemUserAuthorizationID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    TVItemUserAuthorization tvItemUserAuthorization = (from c in dbTestDB.TVItemUserAuthorizations select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemUserAuthorization);

                    List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                    tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvItemUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1,  "TVItemUserAuthorizationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Skip(1).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "TVItemUserAuthorizationID,ContactTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Skip(1).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ThenBy(c => c.ContactTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVItemUserAuthorizationID", "TVItemUserAuthorizationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID == 4).Skip(0).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVItemUserAuthorizationID", "TVItemUserAuthorizationID,GT,2|TVItemUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID > 2 && c.TVItemUserAuthorizationID < 5).Skip(0).Take(1).OrderBy(c => c.TVItemUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvItemUserAuthorizationService.Query = tvItemUserAuthorizationService.FillQuery(typeof(TVItemUserAuthorization), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVItemUserAuthorizationID,GT,2|TVItemUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVItemUserAuthorization> tvItemUserAuthorizationDirectQueryList = new List<TVItemUserAuthorization>();
                        tvItemUserAuthorizationDirectQueryList = (from c in dbTestDB.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID > 2 && c.TVItemUserAuthorizationID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                            tvItemUserAuthorizationList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationList().ToList();
                            CheckTVItemUserAuthorizationFields(tvItemUserAuthorizationList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList = new List<TVItemUserAuthorizationWeb>();
                            tvItemUserAuthorizationWebList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWebList().ToList();
                            CheckTVItemUserAuthorizationWebFields(tvItemUserAuthorizationWebList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList = new List<TVItemUserAuthorizationReport>();
                            tvItemUserAuthorizationReportList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationReportList().ToList();
                            CheckTVItemUserAuthorizationReportFields(tvItemUserAuthorizationReportList);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList[0].TVItemUserAuthorizationID, tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
                            Assert.AreEqual(tvItemUserAuthorizationDirectQueryList.Count, tvItemUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVItemUserAuthorizationList() 2Where

        #region Functions private
        private void CheckTVItemUserAuthorizationFields(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
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
            Assert.IsNotNull(tvItemUserAuthorizationList[0].HasErrors);
        }
        private void CheckTVItemUserAuthorizationWebFields(List<TVItemUserAuthorizationWeb> tvItemUserAuthorizationWebList)
        {
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].ContactTVItemLanguage);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemLanguage1);
            if (tvItemUserAuthorizationWebList[0].TVItemLanguage2 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemLanguage2);
            }
            if (tvItemUserAuthorizationWebList[0].TVItemLanguage3 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemLanguage3);
            }
            if (tvItemUserAuthorizationWebList[0].TVItemLanguage4 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemLanguage4);
            }
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationWebList[0].TVAuthText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationWebList[0].TVAuthText));
            }
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemUserAuthorizationID);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].ContactTVItemID);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemID1);
            if (tvItemUserAuthorizationWebList[0].TVItemID2 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemID2);
            }
            if (tvItemUserAuthorizationWebList[0].TVItemID3 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemID3);
            }
            if (tvItemUserAuthorizationWebList[0].TVItemID4 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVItemID4);
            }
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].TVAuth);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemUserAuthorizationWebList[0].HasErrors);
        }
        private void CheckTVItemUserAuthorizationReportFields(List<TVItemUserAuthorizationReport> tvItemUserAuthorizationReportList)
        {
            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationReportTest));
            }
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].ContactTVItemLanguage);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemLanguage1);
            if (tvItemUserAuthorizationReportList[0].TVItemLanguage2 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemLanguage2);
            }
            if (tvItemUserAuthorizationReportList[0].TVItemLanguage3 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemLanguage3);
            }
            if (tvItemUserAuthorizationReportList[0].TVItemLanguage4 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemLanguage4);
            }
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationReportList[0].TVAuthText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationReportList[0].TVAuthText));
            }
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemUserAuthorizationID);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].ContactTVItemID);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemID1);
            if (tvItemUserAuthorizationReportList[0].TVItemID2 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemID2);
            }
            if (tvItemUserAuthorizationReportList[0].TVItemID3 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemID3);
            }
            if (tvItemUserAuthorizationReportList[0].TVItemID4 != null)
            {
                Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVItemID4);
            }
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].TVAuth);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvItemUserAuthorizationReportList[0].HasErrors);
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
