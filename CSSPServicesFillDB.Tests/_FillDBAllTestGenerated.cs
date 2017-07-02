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
            // should also run this test with CultureInfo("fr-CA")
            SetupTestHelper(new CultureInfo("en-CA"));

            // -------------------------------
            // Adding First TVItem Object
            // -------------------------------

            TVItem tvItemRoot = new TVItem();
            tvItemService.AddRoot(tvItemRoot);
            Assert.AreEqual(1, tvItemService.GetRead().Count());
            Assert.AreEqual(2, tvItemLanguageService.GetRead().Count());
            Assert.AreEqual("p1", tvItemRoot.TVPath);
            Assert.AreEqual(0, tvItemRoot.TVLevel);
            Assert.AreEqual(TVTypeEnum.Root, tvItemRoot.TVType);
            Assert.AreEqual(1, tvItemRoot.ParentID);
            Assert.AreEqual(1, tvItemRoot.TVItemID);
            Assert.AreEqual(LanguageEnum.en, tvItemRoot.TVItemLanguages.First().Language);
            Assert.AreEqual(ServicesRes.Root, tvItemRoot.TVItemLanguages.First().TVText);
            Assert.AreEqual(tvItemRoot.TVItemID, tvItemRoot.TVItemLanguages.First().TVItemID);

            // -------------------------------
            // Adding First Contact Object
            // -------------------------------

            byte[] PasswordHash;
            byte[] PasswordSalt;

            Register register = new Register();
            register.LoginEmail = "Charles.LeBlanc2@canada.ca";
            register.FirstName = "Charles";
            register.Initial = "G";
            register.LastName = "LeBlanc";
            register.WebName = GetRandomString("", 20);
            register.Password = "aaaaaaaaaa2!";
            register.ConfirmPassword = register.Password;

            contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);

            Contact contact = new Contact();
            contact.FirstName = "Charles";
            contact.Initial = "G";
            contact.LastName = "LeBlanc";
            contact.WebName = GetRandomString("", 20);
            contact.LoginEmail = "Charles.LeBlanc2@canada.ca";
            contact.LastUpdateDate_UTC = DateTime.UtcNow;
            contact.LastUpdateContactTVItemID = 1;

            contactService.AddContact(contact, ContactService.AddContactType.First);
            Assert.AreEqual(1, contactService.GetRead().Count());
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contact.FirstName, contactService.GetRead().FirstOrDefault().FirstName);
            Assert.AreEqual(contact.Initial, contactService.GetRead().FirstOrDefault().Initial);
            Assert.AreEqual(contact.LastName, contactService.GetRead().FirstOrDefault().LastName);

            TVItem tvItemTestContact = tvItemService.GetRead().Where(c => c.TVItemID == contact.ContactTVItemID).FirstOrDefault();
            Assert.AreEqual("p1p" + contact.ContactTVItemID, tvItemTestContact.TVPath);
            Assert.AreEqual(1, tvItemTestContact.TVLevel);
            Assert.AreEqual(TVTypeEnum.Contact, tvItemTestContact.TVType);
            Assert.AreEqual(1, tvItemTestContact.ParentID);
            Assert.AreEqual(2, tvItemTestContact.TVItemID);

            ContactLogin contactLogin = new ContactLogin();
            contactLogin.ContactID = contact.ContactID;
            contactLogin.LoginEmail = contact.LoginEmail;
            contactLogin.Password = register.Password;
            contactLogin.ConfirmPassword = contactLogin.Password;
            contactLogin.PasswordHash = PasswordHash;
            contactLogin.PasswordSalt = PasswordSalt;
            contactLogin.LastUpdateDate_UTC = DateTime.UtcNow;
            contactLogin.LastUpdateContactTVItemID = contact.ContactTVItemID;

            Assert.IsTrue(contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contact.ContactID, contactLogin.ContactID);
        }
        #endregion Tests Generated
    }
}
