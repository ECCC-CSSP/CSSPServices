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

namespace CSSPServicesFillDB.Tests
{
    [TestClass]
    public partial class FillDBTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<LanguageEnum> AllowableLanguageList { get; set; }
        AddressService addressService { get; set; }
        AppErrLogService appErrLogService { get; set; }
        AppTaskService appTaskService { get; set; }
        EmailDistributionListContactService emailDistributionListContactService { get; set; }
        EmailDistributionListService emailDistributionListService { get; set; }
        MWQMSampleDuplicateItemService mwqmSampleDuplicateItemService { get; set; }
        MWQMSiteSampleFCService mwqmSiteSampleFCService { get; set; }
        NewContactService newContactService { get; set; }
        URLNumberOfSamplesService uRLNumberOfSamplesService { get; set; }
        VPScenarioIDAndRawResultsService vpScenarioIDAndRawResultsService { get; set; }
        VPResValuesService vpResValuesService { get; set; }
        VPFullService vpFullService { get; set; }
        VectorService vectorService { get; set; }
        TVTypeNamesAndPathService tvTypeNamesAndPathService { get; set; }
        TVTextLanguageService tvTextLanguageService { get; set; }
        TVLocationService tvLocationService { get; set; }
        TVItemTVAuthService tvItemTVAuthService { get; set; }
        TVItemInfrastructureTypeTVItemLinkService tvItemInfrastructureTypeTVItemLinkService { get; set; }
        TVItemSubsectorAndMWQMSiteService tvItemSubsectorAndMWQMSiteService { get; set; }
        TVFullTextService tvFullTextService { get; set; }
        SubsectorMWQMSampleYearService subsectorMWQMSampleYearService { get; set; }
        SearchTagAndTermsService searchTagAndTermsService { get; set; }
        SearchService searchService { get; set; }
        RTBStringPosService rTBStringPosService { get; set; }
        PolSourceObsInfoChildService polSourceObsInfoChildService { get; set; }
        PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService { get; set; }
        PolSourceInactiveReasonEnumTextAndIDService polSourceInactiveReasonEnumTextAndIDService { get; set; }
        PolyPointService polyPointService { get; set; }
        OtherFilesToUploadService otherFilesToUploadService { get; set; }
        NodeLayerService nodeLayerService { get; set; }
        NodeService nodeService { get; set; }
        SamplingPlanAndFilesLabSheetCountService samplingPlanAndFilesLabSheetCountService { get; set; }
        MapObjService mapObjService { get; set; }
        LatLngService latLngService { get; set; }
        LastUpdateAndTVTextService lastUpdateAndTVTextService { get; set; }
        LastUpdateAndContactService lastUpdateAndContactService { get; set; }
        LabSheetAndA1SheetService labSheetAndA1SheetService { get; set; }
        LabSheetA1MeasurementService labSheetA1MeasurementService { get; set; }
        LabSheetA1SheetService labSheetA1SheetService { get; set; }
        InputSummaryService inputSummaryService { get; set; }
        FilePurposeAndTextService filePurposeAndTextService { get; set; }
        FileItemListService fileItemListService { get; set; }
        FileItemService fileItemService { get; set; }
        ElementLayerService elementLayerService { get; set; }
        ElementService elementService { get; set; }
        DataPathOfTideService dataPathOfTideService { get; set; }
        CSSPWQInputParamService cSSPWQInputParamService { get; set; }
        CSSPWQInputAppService cSSPWQInputAppService { get; set; }
        CSSPMPNTableService cSSPMPNTableService { get; set; }
        CoordService coordService { get; set; }
        ContourPolygonService contourPolygonService { get; set; }
        ContactSearchService contactSearchService { get; set; }
        ContactOKService contactOKService { get; set; }
        CalDecayService calDecayService { get; set; }
        DBTableService dBTableService { get; set; }
        BoxModelCalNumbService boxModelCalNumbService { get; set; }
        AppTaskParameterService appTaskParameterService { get; set; }
        AppTaskLanguageService appTaskLanguageService { get; set; }
        BoxModelService boxModelService { get; set; }
        BoxModelLanguageService boxModelLanguageService { get; set; }
        BoxModelResultService boxModelResultService { get; set; }
        ClimateDataValueService climateDataValueService { get; set; }
        ClimateSiteService climateSiteService { get; set; }
        ContactLoginService contactLoginService { get; set; }
        RegisterService registerService { get; set; }
        LoginService loginService { get; set; }
        ContactService contactService { get; set; }
        ContactPreferenceService contactPreferenceService { get; set; }
        ContactShortcutService contactShortcutService { get; set; }
        DocTemplateService docTemplateService { get; set; }
        EmailService emailService { get; set; }
        HydrometricDataValueService hydrometricDataValueService { get; set; }
        HydrometricSiteService hydrometricSiteService { get; set; }
        InfrastructureService infrastructureService { get; set; }
        InfrastructureLanguageService infrastructureLanguageService { get; set; }
        LabSheetService labSheetService { get; set; }
        LabSheetDetailService labSheetDetailService { get; set; }
        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        LogService logService { get; set; }
        MapInfoService mapInfoService { get; set; }
        MapInfoPointService mapInfoPointService { get; set; }
        MikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        MikeScenarioService mikeScenarioService { get; set; }
        MikeSourceService mikeSourceService { get; set; }
        MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        MWQMLookupMPNService mwqmLookupMPNService { get; set; }
        MWQMRunService mwqmRunService { get; set; }
        MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        MWQMSampleService mwqmSampleService { get; set; }
        MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        MWQMSiteService mwqmSiteService { get; set; }
        MWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        MWQMSubsectorService mwqmSubsectorService { get; set; }
        MWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        PolSourceObservationService polSourceObservationService { get; set; }
        PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        PolSourceSiteService polSourceSiteService { get; set; }
        RatingCurveService ratingCurveService { get; set; }
        RatingCurveValueService ratingCurveValueService { get; set; }
        ResetPasswordService resetPasswordService { get; set; }
        SamplingPlanService samplingPlanService { get; set; }
        SamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        SpillService spillService { get; set; }
        SpillLanguageService spillLanguageService { get; set; }
        TelService telService { get; set; }
        TideDataValueService tideDataValueService { get; set; }
        TideLocationService tideLocationService { get; set; }
        TideSiteService tideSiteService { get; set; }
        TVFileService tvFileService { get; set; }
        TVFileLanguageService tvFileLanguageService { get; set; }
        TVItemService tvItemService { get; set; }
        TVItemLanguageService tvItemLanguageService { get; set; }
        TVItemLinkService tvItemLinkService { get; set; }
        TVItemStatService tvItemStatService { get; set; }
        TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        UseOfSiteService useOfSiteService { get; set; }
        VPAmbientService vpAmbientService { get; set; }
        VPResultService vpResultService { get; set; }
        VPScenarioService vpScenarioService { get; set; }
        VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public FillDBTest() : base()
        {
            AllowableLanguageList = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
            addressService = new AddressService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            appErrLogService = new AppErrLogService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            appTaskService = new AppTaskService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            emailDistributionListService = new EmailDistributionListService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSampleDuplicateItemService = new MWQMSampleDuplicateItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSiteSampleFCService = new MWQMSiteSampleFCService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            newContactService = new NewContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpScenarioIDAndRawResultsService = new VPScenarioIDAndRawResultsService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpResValuesService = new VPResValuesService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpFullService = new VPFullService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vectorService = new VectorService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvTypeNamesAndPathService = new TVTypeNamesAndPathService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvTextLanguageService = new TVTextLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvLocationService = new TVLocationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemTVAuthService = new TVItemTVAuthService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemInfrastructureTypeTVItemLinkService = new TVItemInfrastructureTypeTVItemLinkService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemSubsectorAndMWQMSiteService = new TVItemSubsectorAndMWQMSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvFullTextService = new TVFullTextService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            searchService = new SearchService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            rTBStringPosService = new RTBStringPosService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObsInfoChildService = new PolSourceObsInfoChildService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceInactiveReasonEnumTextAndIDService = new PolSourceInactiveReasonEnumTextAndIDService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polyPointService = new PolyPointService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            otherFilesToUploadService = new OtherFilesToUploadService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            nodeLayerService = new NodeLayerService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            nodeService = new NodeService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanAndFilesLabSheetCountService = new SamplingPlanAndFilesLabSheetCountService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mapObjService = new MapObjService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            latLngService = new LatLngService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            lastUpdateAndTVTextService = new LastUpdateAndTVTextService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            lastUpdateAndContactService = new LastUpdateAndContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetAndA1SheetService = new LabSheetAndA1SheetService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetA1MeasurementService = new LabSheetA1MeasurementService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetA1SheetService = new LabSheetA1SheetService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            inputSummaryService = new InputSummaryService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            filePurposeAndTextService = new FilePurposeAndTextService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            fileItemListService = new FileItemListService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            fileItemService = new FileItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            elementLayerService = new ElementLayerService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            elementService = new ElementService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            dataPathOfTideService = new DataPathOfTideService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            cSSPWQInputParamService = new CSSPWQInputParamService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            cSSPWQInputAppService = new CSSPWQInputAppService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            cSSPMPNTableService = new CSSPMPNTableService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            coordService = new CoordService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contourPolygonService = new ContourPolygonService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactSearchService = new ContactSearchService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactOKService = new ContactOKService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            calDecayService = new CalDecayService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            dBTableService = new DBTableService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelCalNumbService = new BoxModelCalNumbService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            appTaskParameterService = new AppTaskParameterService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelService = new BoxModelService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelResultService = new BoxModelResultService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            climateDataValueService = new ClimateDataValueService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            climateSiteService = new ClimateSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactLoginService = new ContactLoginService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            registerService = new RegisterService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            loginService = new LoginService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactPreferenceService = new ContactPreferenceService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            contactShortcutService = new ContactShortcutService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            docTemplateService = new DocTemplateService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            emailService = new EmailService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            hydrometricSiteService = new HydrometricSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            infrastructureService = new InfrastructureService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetService = new LabSheetService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetDetailService = new LabSheetDetailService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            logService = new LogService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mapInfoService = new MapInfoService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mapInfoPointService = new MapInfoPointService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mikeScenarioService = new MikeScenarioService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mikeSourceService = new MikeSourceService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmRunService = new MWQMRunService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSampleService = new MWQMSampleService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSiteService = new MWQMSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObservationService = new PolSourceObservationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceSiteService = new PolSourceSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            ratingCurveService = new RatingCurveService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            ratingCurveValueService = new RatingCurveValueService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            resetPasswordService = new ResetPasswordService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanService = new SamplingPlanService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            spillService = new SpillService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            spillLanguageService = new SpillLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            telService = new TelService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tideDataValueService = new TideDataValueService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tideLocationService = new TideLocationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tideSiteService = new TideSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvFileService = new TVFileService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvFileLanguageService = new TVFileLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemService = new TVItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemLanguageService = new TVItemLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemLinkService = new TVItemLinkService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemStatService = new TVItemStatService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            useOfSiteService = new UseOfSiteService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpAmbientService = new VPAmbientService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpResultService = new VPResultService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpScenarioService = new VPScenarioService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
            vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryWithDBShape);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void FillDBTestAll()
        {
            int DoItemCount = 2;
            bool retBool = false;
            int CurrentTVItemID = 0;
            int CurrentContactID = 0;
            int CurrentContactLoginID = 0;
            int CurrentBoxModelID = 0;
            int CurrentBoxModelResultID = 0;
            int CurrentPolSourceSiteID = 0;

            // should also run this test with CultureInfo("fr-CA")
            SetupTestHelper(new CultureInfo("en-CA"));

            #region Adding Root TVItem

            TVItem tvItemRoot = new TVItem();
            tvItemRoot.TVItemID = 1;
            tvItemRoot.TVLevel = 0;
            tvItemRoot.TVPath = "p1";
            tvItemRoot.TVType = TVTypeEnum.Root;
            tvItemRoot.ParentID = 1;
            tvItemRoot.IsActive = true;
            tvItemRoot.LastUpdateDate_UTC = DateTime.UtcNow;
            tvItemRoot.LastUpdateContactTVItemID = 1;

            foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                tvItemRoot.TVItemLanguages.Add(new TVItemLanguage()
                {
                    Language = Lang,
                    TVText = ServicesRes.Root,
                    TVItemID = tvItemRoot.TVItemID,
                    TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                });
            }
            retBool = tvItemService.Add(tvItemRoot);
            if (!retBool)
            {
                Assert.AreEqual("", tvItemRoot.ValidationResults.First().ErrorMessage);
            }

            CurrentTVItemID += 1;
            
            #endregion  Adding First TVItem Object

            #region Adding Contact Object

            for (int i = 0; i < DoItemCount; i++)
            {
                TVItem tvItem = new TVItem();
                tvItem.TVItemID = i + 2;
                tvItem.TVLevel = 1;
                tvItem.TVPath = "p1p" + (i + 2).ToString();
                tvItem.TVType = TVTypeEnum.Contact;
                tvItem.ParentID = tvItemRoot.TVItemID;
                tvItem.IsActive = true;
                tvItem.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItem.LastUpdateContactTVItemID = i + 1;

                foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    tvItem.TVItemLanguages.Add(new TVItemLanguage()
                    {
                        Language = Lang,
                        TVText = (i == 0 ? "LeBlanc" : "User" + i.ToString()) + " " + (i == 0 ? "G" : GetRandomString("A", 2)) + ", " + (i == 0 ? "Charles" : "User" + i.ToString()),
                        TVItemID = tvItem.TVItemID,
                        TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                    });
                }
                retBool = tvItemService.Add(tvItem);
                Assert.IsTrue(retBool);
                if (!retBool)
                {
                    Assert.AreEqual("", tvItem.ValidationResults.First().ErrorMessage);
                }

                tvItem.LastUpdateContactTVItemID = i + 2;

                retBool = tvItemService.Update(tvItem);
                if (!retBool)
                {
                    Assert.AreEqual("", tvItem.ValidationResults.First().ErrorMessage);
                }

                CurrentTVItemID += 1;

                byte[] PasswordHash;
                byte[] PasswordSalt;

                Register register = new Register();
                register.LoginEmail = (i == 0 ? "Charles.LeBlanc2@canada.ca" : "user.name" + i.ToString() + "@abc.ca");
                register.FirstName = (i == 0 ? "Charles" : "User" + i.ToString());
                register.Initial = (i == 0 ? "G" : GetRandomString("A", 2));
                register.LastName = (i == 0 ? "LeBlanc" : "User" + i.ToString());
                register.WebName = GetRandomString("", 20);
                register.Password = "aaaaaaaaaa2!";
                register.ConfirmPassword = register.Password;

                contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);

                Contact contact = new Contact();
                contact.ContactID = i + 1;
                contact.ContactTVItemID = i + 2;
                contact.Id = "NotUsed";
                contact.ParentTVItemID = tvItemRoot.TVItemID;
                contact.FirstName = register.FirstName;
                contact.Initial = register.Initial;
                contact.LastName = register.LastName;
                contact.WebName = GetRandomString("", 20);
                contact.LoginEmail = register.LoginEmail;
                contact.LastUpdateDate_UTC = DateTime.UtcNow;
                contact.LastUpdateContactTVItemID = 1;
                contact.ContactTitle = ((ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum)));
                contact.Disabled = false;
                contact.EmailValidated = true;
                contact.IsAdmin = (i == 0 ? true : false);
                contact.IsNew = false;
                contact.SamplingPlanner_ProvincesTVItemID = "";

                retBool = contactService.Add(contact, (i == 0 ? ContactService.AddContactType.First : ContactService.AddContactType.Register));
                if (!retBool)
                {
                    Assert.AreEqual("", contact.ValidationResults.First().ErrorMessage);
                }

                CurrentContactID += 1;

                ContactLogin contactLogin = new ContactLogin();
                contactLogin.ContactLoginID = i + 1;
                contactLogin.ContactID = contact.ContactID;
                contactLogin.LoginEmail = contact.LoginEmail;
                contactLogin.PasswordHash = PasswordHash;
                contactLogin.PasswordSalt = PasswordSalt;
                contactLogin.LastUpdateDate_UTC = DateTime.UtcNow;
                contactLogin.LastUpdateContactTVItemID = contact.ContactTVItemID;
                contactLogin.Password = register.Password;
                contactLogin.ConfirmPassword = register.ConfirmPassword;

                retBool = contactLoginService.Add(contactLogin);
                if (!retBool)
                {
                    Assert.AreEqual("", contact.ValidationResults.First().ErrorMessage);
                }

                CurrentContactLoginID += 1;
            }
            #endregion Adding Contact Object

            #region Adding x Country TVItem
            for (int country = 0; country < DoItemCount; country++)
            {
                TVItem tvItemCountry = new TVItem();
                tvItemCountry.TVItemID = CurrentTVItemID + 1;
                tvItemCountry.TVLevel = 2;
                tvItemCountry.TVPath = "p" + tvItemRoot.TVItemID.ToString() + "p" + (CurrentTVItemID + 1).ToString();
                tvItemCountry.TVType = TVTypeEnum.Country;
                tvItemCountry.ParentID = tvItemRoot.TVItemID;
                tvItemCountry.IsActive = true;
                tvItemCountry.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItemCountry.LastUpdateContactTVItemID = 2;

                foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    tvItemCountry.TVItemLanguages.Add(new TVItemLanguage()
                    {
                        Language = Lang,
                        TVText = "Country" + country.ToString(),
                        TVItemID = CurrentTVItemID + 1,
                        TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                    });
                }
                retBool = tvItemService.Add(tvItemCountry);
                if (!retBool)
                {
                    Assert.AreEqual("", tvItemCountry.ValidationResults.First().ErrorMessage);
                }

                CurrentTVItemID += 1;
            }
            #endregion Adding x Country TVItem

            #region Adding x Provinces/country TVItem
            foreach (TVItem tvItemCountry in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Country))
            {
                for (int province = 0; province < DoItemCount; province++)
                {
                    TVItem tvItemProvince = new TVItem();
                    tvItemProvince.TVItemID = CurrentTVItemID + 1;
                    tvItemProvince.TVLevel = 3;
                    tvItemProvince.TVPath = tvItemCountry.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemProvince.TVType = TVTypeEnum.Province;
                    tvItemProvince.ParentID = tvItemCountry.TVItemID;
                    tvItemProvince.IsActive = true;
                    tvItemProvince.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemProvince.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemProvince.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "Province" + province.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemProvince);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemProvince.ValidationResults.First().ErrorMessage);
                    }

                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Provinces/country TVItem

            #region Adding x Areas/Province TVItem
            foreach (TVItem tvItemProvince in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Province))
            {
                for (int area = 0; area < DoItemCount; area++)
                {
                    TVItem tvItemArea = new TVItem();
                    tvItemArea.TVItemID = CurrentTVItemID + 1;
                    tvItemArea.TVLevel = 4;
                    tvItemArea.TVPath = tvItemProvince.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemArea.TVType = TVTypeEnum.Area;
                    tvItemArea.ParentID = tvItemProvince.TVItemID;
                    tvItemArea.IsActive = true;
                    tvItemArea.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemArea.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemArea.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "Area" + area.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemArea);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemArea.ValidationResults.First().ErrorMessage);
                    }

                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Areas/Province TVItem

            #region Adding x Subsector/Area TVItem
            foreach (TVItem tvItemArea in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Area))
            {
                for (int subsector = 0; subsector < DoItemCount; subsector++)
                {
                    TVItem tvItemSubsector = new TVItem();
                    tvItemSubsector.TVItemID = CurrentTVItemID + 1;
                    tvItemSubsector.TVLevel = 5;
                    tvItemSubsector.TVPath = tvItemArea.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemSubsector.TVType = TVTypeEnum.Subsector;
                    tvItemSubsector.ParentID = tvItemArea.TVItemID;
                    tvItemSubsector.IsActive = true;
                    tvItemSubsector.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemSubsector.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemSubsector.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "Subsector" + subsector.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemSubsector);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemSubsector.ValidationResults.First().ErrorMessage);
                    }

                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Subsector/Area TVItem

            #region Adding x Municipality/Subsector TVItem
            foreach (TVItem tvItemSubsector in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Subsector))
            {
                for (int municipality = 0; municipality < DoItemCount; municipality++)
                {
                    TVItem tvItemMunicipality = new TVItem();
                    tvItemMunicipality.TVItemID = CurrentTVItemID + 1;
                    tvItemMunicipality.TVLevel = 6;
                    tvItemMunicipality.TVPath = tvItemSubsector.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemMunicipality.TVType = TVTypeEnum.Municipality;
                    tvItemMunicipality.ParentID = tvItemSubsector.TVItemID;
                    tvItemMunicipality.IsActive = true;
                    tvItemMunicipality.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemMunicipality.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemMunicipality.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "Municipality" + municipality.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemMunicipality);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemMunicipality.ValidationResults.First().ErrorMessage);
                    }

                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Municipality/Subsector TVItem

            #region Adding x Infrastructure/Subsector TVItem
            foreach (TVItem tvItemSubsector in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Subsector))
            {
                for (int infrastructure = 0; infrastructure < DoItemCount; infrastructure++)
                {
                    TVItem tvItemInfrastructure = new TVItem();
                    tvItemInfrastructure.TVItemID = CurrentTVItemID + 1;
                    tvItemInfrastructure.TVLevel = 6;
                    tvItemInfrastructure.TVPath = tvItemSubsector.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemInfrastructure.TVType = TVTypeEnum.Infrastructure;
                    tvItemInfrastructure.ParentID = tvItemSubsector.TVItemID;
                    tvItemInfrastructure.IsActive = true;
                    tvItemInfrastructure.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemInfrastructure.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemInfrastructure.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "Infrastructure" + infrastructure.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemInfrastructure);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemInfrastructure.ValidationResults.First().ErrorMessage);
                    }

                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Municipality/Subsector TVItem

            #region Adding x BoxModel/Infrastructure
            foreach (TVItem tvItemInfrastructure in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Infrastructure))
            {
                for (int boxmodel = 0; boxmodel < DoItemCount; boxmodel++)
                {
                    BoxModel boxModel = new BoxModel();
                    boxModel.BoxModelID = CurrentBoxModelID + 1;
                    boxModel.InfrastructureTVItemID = tvItemInfrastructure.TVItemID;
                    boxModel.Flow_m3_day = GetRandomFloat(1000, 10000);
                    boxModel.Concentration_MPN_100ml = GetRandomInt(3200000, 5500000);
                    boxModel.Depth_m = GetRandomFloat(0.5f, 3.0f);
                    boxModel.Temperature_C = GetRandomFloat(5.0f, 20.0f);
                    boxModel.Dilution = GetRandomInt(5, 1000);
                    boxModel.DecayRate_per_day = GetRandomFloat(4.6f, 4.9f);
                    boxModel.FCUntreated_MPN_100ml = GetRandomInt(3200000, 5500000);
                    boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(3000, 20000);
                    boxModel.Concentration_MPN_100ml = GetRandomInt(20000, 40000);
                    boxModel.T90_hour = GetRandomFloat(5.0f, 500.0f);
                    boxModel.FlowDuration_hour = GetRandomFloat(5.0f, 23.0f);
                    boxModel.LastUpdateDate_UTC = DateTime.UtcNow;
                    boxModel.LastUpdateContactTVItemID = 2;

                    retBool = boxModelService.Add(boxModel);
                    if (!retBool)
                    {
                        Assert.AreEqual("", boxModel.ValidationResults.First().ErrorMessage);
                    }

                    #region Adding BoxModelLanguage

                    BoxModelLanguage boxModelLanguageEN = new BoxModelLanguage();
                    boxModelLanguageEN.BoxModelLanguageID = CurrentBoxModelID * 2 + 1;
                    boxModelLanguageEN.BoxModelID = boxModel.BoxModelID;
                    boxModelLanguageEN.Language = LanguageEnum.en;
                    boxModelLanguageEN.ScenarioName = "BoxModelScenarioEN" + boxModel.BoxModelID;
                    boxModelLanguageEN.TranslationStatus = TranslationStatusEnum.NotTranslated;
                    boxModelLanguageEN.LastUpdateDate_UTC = DateTime.UtcNow;
                    boxModelLanguageEN.LastUpdateContactTVItemID = 2;

                    retBool = boxModelLanguageService.Add(boxModelLanguageEN);
                    if (!retBool)
                    {
                        Assert.AreEqual("", boxModelLanguageEN.ValidationResults.First().ErrorMessage);
                    }

                    BoxModelLanguage boxModelLanguageFR = new BoxModelLanguage();
                    boxModelLanguageFR.BoxModelLanguageID = CurrentBoxModelID * 2 + 2;
                    boxModelLanguageFR.BoxModelID = boxModel.BoxModelID;
                    boxModelLanguageFR.Language = LanguageEnum.fr;
                    boxModelLanguageFR.ScenarioName = "BoxModelScenarioFR" + boxModel.BoxModelID;
                    boxModelLanguageFR.TranslationStatus = TranslationStatusEnum.Translated;
                    boxModelLanguageFR.LastUpdateDate_UTC = DateTime.UtcNow;
                    boxModelLanguageFR.LastUpdateContactTVItemID = 2;

                    retBool = boxModelLanguageService.Add(boxModelLanguageFR);
                    if (!retBool)
                    {
                        Assert.AreEqual("", boxModelLanguageFR.ValidationResults.First().ErrorMessage);
                    }
                    #endregion Adding BoxModelLanguage

                    #region Adding BoxModelResult

                    for (int boxmodelresulttype = 1; boxmodelresulttype < 6; boxmodelresulttype++)
                    {
                        BoxModelResult boxModelResult = new BoxModelResult();
                        boxModelResult.BoxModelResultID = CurrentBoxModelResultID + 1;
                        boxModelResult.BoxModelID = boxModel.BoxModelID;
                        boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)boxmodelresulttype;
                        boxModelResult.Volume_m3 = GetRandomFloat(10000.0f, 1000000.0f);
                        boxModelResult.Surface_m2 = GetRandomFloat(10000.0f, 1000000.0f);
                        boxModelResult.Radius_m = GetRandomFloat(100.0f, 10000.0f);
                        boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomFloat(0.0f, 360.0f);
                        boxModelResult.CircleCenterLatitude = GetRandomFloat(-90.0f, 90.0f);
                        boxModelResult.CircleCenterLongitude = GetRandomFloat(-180.0f, 180.0f);
                        boxModelResult.FixLength = false;
                        boxModelResult.FixWidth = false;
                        boxModelResult.RectLength_m = GetRandomFloat(0.0f, 10000.0f);
                        boxModelResult.RectWidth_m = GetRandomFloat(0.0f, 10000.0f);
                        boxModelResult.LeftSideLineAngle_deg = GetRandomFloat(0.0f, 360.0f);
                        boxModelResult.LeftSideLineStartLatitude = GetRandomFloat(-90.0f, 90.0f);
                        boxModelResult.LeftSideLineStartLongitude = GetRandomFloat(-180.0f, 180.0f);
                        boxModelResult.LastUpdateDate_UTC = DateTime.UtcNow;
                        boxModelResult.LastUpdateContactTVItemID = 2;

                        retBool = boxModelResultService.Add(boxModelResult);
                        if (!retBool)
                        {
                            Assert.AreEqual("", boxModelResult.ValidationResults.First().ErrorMessage);
                        }

                        CurrentBoxModelResultID += 1;
                    }
                    #endregion Adding BoxModelResult

                    CurrentBoxModelID += 1;
                }
            }
            #endregion Adding x BoxModel/Infrastructure

            #region Adding x PolSourceSite/Subsector TVItem
            foreach (TVItem tvItemSubsector in tvItemService.GetRead().Where(c => c.TVType == TVTypeEnum.Subsector))
            {
                for (int polsourcesite = 0; polsourcesite < DoItemCount; polsourcesite++)
                {
                    TVItem tvItemPolSourceSite = new TVItem();
                    tvItemPolSourceSite.TVItemID = CurrentTVItemID + 1;
                    tvItemPolSourceSite.TVLevel = 7;
                    tvItemPolSourceSite.TVPath = tvItemSubsector.TVPath + "p" + (CurrentTVItemID + 1).ToString();
                    tvItemPolSourceSite.TVType = TVTypeEnum.PolSourceSite;
                    tvItemPolSourceSite.ParentID = tvItemSubsector.TVItemID;
                    tvItemPolSourceSite.IsActive = true;
                    tvItemPolSourceSite.LastUpdateDate_UTC = DateTime.UtcNow;
                    tvItemPolSourceSite.LastUpdateContactTVItemID = 2;

                    foreach (LanguageEnum Lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        tvItemPolSourceSite.TVItemLanguages.Add(new TVItemLanguage()
                        {
                            Language = Lang,
                            TVText = "PolSourceSite" + polsourcesite.ToString(),
                            TVItemID = CurrentTVItemID + 1,
                            TranslationStatus = (Lang == LanguageEnum.fr ? TranslationStatusEnum.NotTranslated : TranslationStatusEnum.Translated),
                        });
                    }
                    retBool = tvItemService.Add(tvItemPolSourceSite);
                    if (!retBool)
                    {
                        Assert.AreEqual("", tvItemPolSourceSite.ValidationResults.First().ErrorMessage);
                    }

                    #region Adding x PolSourceSite table
                    for (int polsourcesiteobservation = 0; polsourcesiteobservation < DoItemCount; polsourcesiteobservation++)
                    {
                        PolSourceSite polSourceSite = new PolSourceSite();
                        polSourceSite.PolSourceSiteID = CurrentPolSourceSiteID + 1;
                        polSourceSite.PolSourceSiteTVItemID = tvItemPolSourceSite.TVItemID;
                        polSourceSite.Temp_Locator_CanDelete = "NotUsed";
                        polSourceSite.Oldsiteid = null;
                        polSourceSite.Site = null;
                        polSourceSite.SiteID = null;
                        polSourceSite.IsPointSource = true;
                        polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
                        polSourceSite.CivicAddressTVItemID = null;
                        polSourceSite.LastUpdateDate_UTC = DateTime.UtcNow;
                        polSourceSite.LastUpdateContactTVItemID = 2;

                        retBool = polSourceSiteService.Add(polSourceSite);
                        if (!retBool)
                        {
                            Assert.AreEqual("", polSourceSite.ValidationResults.First().ErrorMessage);
                        }

                        CurrentPolSourceSiteID += 1;
                    }
                    #endregion Adding x PolSourceSiteObservation/PolSourceSite

                    CurrentPolSourceSiteID += 1;
                    CurrentTVItemID += 1;
                }
            }
            #endregion Adding x Municipality/Subsector TVItem

        }

        private void AddFirstContact()
        {
            throw new NotImplementedException();
        }
        #endregion Tests Generated
    }
}
