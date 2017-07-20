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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class TVItemTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItemID += 1;

            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVItemID") tvItem.TVItemID = TVItemID;
            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = GetRandomInt(1, 11);
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItem_Testing()
        {
            SetupTestHelper(culture);
            TVItemService tvItemService = new TVItemService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            TVItem tvItem = GetFilledRandomTVItem("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
            tvItem.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvItemService.Update(tvItem));
            Assert.AreEqual(1, tvItemService.GetRead().Count());
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVLevel will automatically be initialized at 0 --> not null

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVPath");
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.AreEqual(1, tvItem.ValidationResults.Count());
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath)).Any());
            Assert.AreEqual(null, tvItem.TVPath);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //Error: Type not implemented [TVType]

            // ParentID will automatically be initialized at 0 --> not null

            // IsActive will automatically be initialized at 0 --> not null

            tvItem = null;
            tvItem = GetFilledRandomTVItem("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.AreEqual(1, tvItem.ValidationResults.Count());
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItem.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [AddressesAddressTVItem]

            //Error: Type not implemented [AddressesCountryTVItem]

            //Error: Type not implemented [AddressesMunicipalityTVItem]

            //Error: Type not implemented [AddressesProvinceTVItem]

            //Error: Type not implemented [AppTasksTVItem]

            //Error: Type not implemented [AppTasksTVItemID2Navigation]

            //Error: Type not implemented [BoxModels]

            //Error: Type not implemented [ClimateSites]

            //Error: Type not implemented [Contacts]

            //Error: Type not implemented [DocTemplates]

            //Error: Type not implemented [Emails]

            //Error: Type not implemented [EmailDistributionLists]

            //Error: Type not implemented [HydrometricSites]

            //Error: Type not implemented [Infrastructures]

            //Error: Type not implemented [LabSheetDetails]

            //Error: Type not implemented [LabSheetsAcceptedOrRejectedByContactTVItem]

            //Error: Type not implemented [LabSheetsMWQMRunTVItem]

            //Error: Type not implemented [LabSheetsSubsectorTVItem]

            //Error: Type not implemented [LabSheetTubeMPNDetails]

            //Error: Type not implemented [MapInfos]

            //Error: Type not implemented [MikeBoundaryConditions]

            //Error: Type not implemented [MikeScenarios]

            //Error: Type not implemented [MikeSources]

            //Error: Type not implemented [MWQMRunsLabSampleApprovalContactTVItem]

            //Error: Type not implemented [MWQMRunsMWQMRunTVItem]

            //Error: Type not implemented [MWQMRunsSubsectorTVItem]

            //Error: Type not implemented [MWQMSampleMWQMRunTVItem]

            //Error: Type not implemented [MWQMSampleMWQMSiteTVItem]

            //Error: Type not implemented [MWQMSites]

            //Error: Type not implemented [MWQMSiteStartEndDates]

            //Error: Type not implemented [MWQMSubsectors]

            //Error: Type not implemented [PolSourceObservationsContactTVItem]

            //Error: Type not implemented [PolSourceObservationsPolSourceSiteTVItem]

            //Error: Type not implemented [PolSourceSites]

            //Error: Type not implemented [SamplingPlansCreatorTVItem]

            //Error: Type not implemented [SamplingPlansProvinceTVItem]

            //Error: Type not implemented [SamplingPlansSamplingPlanFileTVItem]

            //Error: Type not implemented [SamplingPlanSubsectors]

            //Error: Type not implemented [SamplingPlanSubsectorSites]

            //Error: Type not implemented [SpillsInfrastructureTVItem]

            //Error: Type not implemented [SpillsMunicipalityTVItem]

            //Error: Type not implemented [Tels]

            //Error: Type not implemented [TideDataValues]

            //Error: Type not implemented [TideSites]

            //Error: Type not implemented [TVFiles]

            //Error: Type not implemented [TVItemLanguages]

            //Error: Type not implemented [TVItemLinksFromTVItem]

            //Error: Type not implemented [TVItemLinksToTVItem]

            //Error: Type not implemented [TVItemStats]

            //Error: Type not implemented [TVItemUserAuthorizationsContactTVItem]

            //Error: Type not implemented [TVItemUserAuthorizationsTVItemID1Navigation]

            //Error: Type not implemented [TVTypeUserAuthorizations]

            //Error: Type not implemented [UseOfSitesSiteTVItem]

            //Error: Type not implemented [UseOfSitesSubsectorTVItem]

            //Error: Type not implemented [VPScenarios]

            //Error: Type not implemented [Parent]

            //Error: Type not implemented [InverseParent]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVLevel] of type [Int32]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // TVLevel has Min [0] and Max [100]. At Min should return true and no errors
            tvItem.TVLevel = 0;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(0, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItem.TVLevel = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItem.TVLevel = -1;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100")).Any());
            Assert.AreEqual(-1, tvItem.TVLevel);
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max should return true and no errors
            tvItem.TVLevel = 100;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(100, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItem.TVLevel = 99;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(99, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItem.TVLevel = 101;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100")).Any());
            Assert.AreEqual(101, tvItem.TVLevel);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [TVPath] of type [String]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ParentID] of type [Int32]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // ParentID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.ParentID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.ParentID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.ParentID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemParentID, "1")).Any());
            Assert.AreEqual(0, tvItem.ParentID);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [IsActive] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [AddressesAddressTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AddressesCountryTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AddressesMunicipalityTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AddressesProvinceTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AppTasksTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AppTasksTVItemID2Navigation] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [BoxModels] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [Contacts] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [DocTemplates] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [Emails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailDistributionLists] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [Infrastructures] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetDetails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetsAcceptedOrRejectedByContactTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetsMWQMRunTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetsSubsectorTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetTubeMPNDetails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MapInfos] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeBoundaryConditions] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarios] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeSources] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunsLabSampleApprovalContactTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunsMWQMRunTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunsSubsectorTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSampleMWQMRunTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSampleMWQMSiteTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteStartEndDates] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSubsectors] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceObservationsContactTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceObservationsPolSourceSiteTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlansCreatorTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlansProvinceTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlansSamplingPlanFileTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanSubsectors] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanSubsectorSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpillsInfrastructureTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpillsMunicipalityTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tels] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideDataValues] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFiles] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemLinksFromTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemLinksToTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemStats] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemUserAuthorizationsContactTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemUserAuthorizationsTVItemID1Navigation] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVTypeUserAuthorizations] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [UseOfSitesSiteTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [UseOfSitesSubsectorTVItem] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarios] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [Parent] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [InverseParent] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
