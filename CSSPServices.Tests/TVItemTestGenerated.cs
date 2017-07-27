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
        private TVItemService tvItemService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTest() : base()
        {
            tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 2;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;

            return tvItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItem_Testing()
        {

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

            tvItemService.Add(tvItem);
            if (tvItem.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
            tvItemService.Update(tvItem);
            if (tvItem.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemService.GetRead().Count());
            tvItemService.Delete(tvItem);
            if (tvItem.ValidationResults.Count() > 0)
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

            tvItem = GetFilledRandomTVItem("");
            tvItem.TVItemID = 0;
            tvItemService.Update(tvItem);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVItemID), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // tvItem.TVLevel   (Int32)
            // -----------------------------------

            // TVLevel will automatically be initialized at 0 --> not null


            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // TVLevel has Min [0] and Max [100]. At Min should return true and no errors
            tvItem.TVLevel = 0;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(0, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItem.TVLevel = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItem.TVLevel = -1;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100")).Any());
            Assert.AreEqual(-1, tvItem.TVLevel);
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max should return true and no errors
            tvItem.TVLevel = 100;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(100, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItem.TVLevel = 99;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(99, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItem.TVLevel = 101;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100")).Any());
            Assert.AreEqual(101, tvItem.TVLevel);
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
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath)).Any());
            Assert.AreEqual(null, tvItem.TVPath);
            Assert.AreEqual(0, tvItemService.GetRead().Count());


            tvItem = null;
            tvItem = GetFilledRandomTVItem("");

            // TVPath has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string tvItemTVPathMin = GetRandomString("", 250);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());

            // TVPath has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            tvItemTVPathMin = GetRandomString("", 249);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());

            // TVPath has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            tvItemTVPathMin = GetRandomString("", 251);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemTVPath, "250")).Any());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(count, tvItemService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItem.TVType   (TVTypeEnum)
            // -----------------------------------

            // TVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // tvItem.ParentID   (Int32)
            // -----------------------------------

            // ParentID will automatically be initialized at 0 --> not null


            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // ParentID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.ParentID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.ParentID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.ParentID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemParentID, "1")).Any());
            Assert.AreEqual(0, tvItem.ParentID);
            Assert.AreEqual(count, tvItemService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // tvItem.IsActive   (Boolean)
            // -----------------------------------

            // IsActive will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItem.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tvItem.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(count, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvItemService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.AddressesAddressTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.AddressesCountryTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.AddressesMunicipalityTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.AddressesProvinceTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.AppTasks   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.BoxModels   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.ClimateSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.Contacts   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.DocTemplates   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.Emails   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.EmailDistributionLists   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.HydrometricSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.Infrastructures   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.LabSheetDetails   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.LabSheetsAcceptedOrRejectedByContactTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.LabSheetsMWQMRunTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.LabSheetsSubsectorTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.LabSheetTubeMPNDetails   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MapInfos   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MikeBoundaryConditions   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MikeScenarios   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MikeSources   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMRunsLabSampleApprovalContactTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMRunsMWQMRunTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMRunsSubsectorTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMSampleMWQMRunTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMSampleMWQMSiteTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMSiteStartEndDates   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.MWQMSubsectors   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.PolSourceObservationsContactTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.PolSourceSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SamplingPlansCreatorTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SamplingPlansProvinceTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SamplingPlansSamplingPlanFileTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SamplingPlanSubsectors   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SamplingPlanSubsectorSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SpillsInfrastructureTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.SpillsMunicipalityTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.Tels   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TideDataValues   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TideSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVFiles   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVItemLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVItemLinksFromTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVItemLinksToTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVItemStats   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVItemUserAuthorizationsContactTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.TVTypeUserAuthorizations   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.UseOfSitesSiteTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.UseOfSitesSubsectorTVItem   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.VPScenarios   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.Parent   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItem.InverseParent   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItem.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
