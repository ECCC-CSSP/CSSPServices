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
        AppTaskLanguageService appTaskLanguageService { get; set; }
        AspNetRoleService aspNetRoleService { get; set; }
        AspNetUserService aspNetUserService { get; set; }
        AspNetUserClaimService aspNetUserClaimService { get; set; }
        AspNetUserLoginService aspNetUserLoginService { get; set; }
        AspNetUserRoleService aspNetUserRoleService { get; set; }
        BoxModelService boxModelService { get; set; }
        BoxModelLanguageService boxModelLanguageService { get; set; }
        BoxModelResultService boxModelResultService { get; set; }
        ClimateDataValueService climateDataValueService { get; set; }
        ClimateSiteService climateSiteService { get; set; }
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
            addressService = new AddressService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            appErrLogService = new AppErrLogService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            appTaskService = new AppTaskService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            aspNetRoleService = new AspNetRoleService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            aspNetUserService = new AspNetUserService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            aspNetUserClaimService = new AspNetUserClaimService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            aspNetUserLoginService = new AspNetUserLoginService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            aspNetUserRoleService = new AspNetUserRoleService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelService = new BoxModelService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            boxModelResultService = new BoxModelResultService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            climateDataValueService = new ClimateDataValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            climateSiteService = new ClimateSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            contactService = new ContactService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            contactPreferenceService = new ContactPreferenceService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            contactShortcutService = new ContactShortcutService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            docTemplateService = new DocTemplateService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            emailService = new EmailService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            hydrometricSiteService = new HydrometricSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            infrastructureService = new InfrastructureService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetService = new LabSheetService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetDetailService = new LabSheetDetailService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            logService = new LogService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mapInfoService = new MapInfoService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mapInfoPointService = new MapInfoPointService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mikeScenarioService = new MikeScenarioService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mikeSourceService = new MikeSourceService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmRunService = new MWQMRunService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSampleService = new MWQMSampleService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSiteService = new MWQMSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObservationService = new PolSourceObservationService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            polSourceSiteService = new PolSourceSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            ratingCurveService = new RatingCurveService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            ratingCurveValueService = new RatingCurveValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            resetPasswordService = new ResetPasswordService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanService = new SamplingPlanService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            spillService = new SpillService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            spillLanguageService = new SpillLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            telService = new TelService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tideDataValueService = new TideDataValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tideLocationService = new TideLocationService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tideSiteService = new TideSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvFileService = new TVFileService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvFileLanguageService = new TVFileLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemService = new TVItemService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemLanguageService = new TVItemLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemLinkService = new TVItemLinkService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemStatService = new TVItemStatService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            useOfSiteService = new UseOfSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            vpAmbientService = new VPAmbientService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            vpResultService = new VPResultService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            vpScenarioService = new VPScenarioService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
            vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);
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
            SetupTestHelper(LoginEmail, new CultureInfo("en-CA"));

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
            // Adding First AspNetUser Object
            // -------------------------------

            AspNetUser aspNetUser = new AspNetUser();
            aspNetUser.UserName = "Charles.LeBlanc2@canada.ca";
            aspNetUser.Email = "Charles.LeBlanc2@canada.ca";
            aspNetUser.Password = GetRandomPassword();
            aspNetUser.Id = GetRandomString("", 30);

            aspNetUserService.Add(aspNetUser);
            Assert.AreEqual(1, aspNetUserService.GetRead().Count());
            Assert.AreEqual(0, aspNetUser.ValidationResults.Count());
            Assert.AreEqual(aspNetUser.UserName, aspNetUserService.GetRead().First().UserName);
            Assert.AreEqual(aspNetUser.Email, aspNetUserService.GetRead().First().Email);
            Assert.AreEqual(aspNetUser.Id, aspNetUserService.GetRead().First().Id);

            // -------------------------------
            // Adding First Contact Object
            // -------------------------------

            Contact contact = new Contact();
            contact.FirstName = "Charles";
            contact.Initial = "G";
            contact.LastName = "LeBlanc";
            contact.Id = aspNetUser.Id;
            contact.WebName = GetRandomString("", 20);
            contact.LoginEmail = aspNetUser.Email;
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
        }
        #endregion Tests Generated
    }
}
