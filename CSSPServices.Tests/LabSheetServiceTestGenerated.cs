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
    public partial class LabSheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetService labSheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetServiceTest() : base()
        {
            //labSheetService = new LabSheetService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            // Need to implement (no items found, would need to add at least one in the TestDB) [LabSheet SamplingPlanID SamplingPlan SamplingPlanID]
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 6);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            // Need to implement (no items found, would need to add at least one in the TestDB) [LabSheet SubsectorTVItemID TVItem TVItemID]
            // Need to implement (no items found, would need to add at least one in the TestDB) [LabSheet MWQMRunTVItemID TVItem TVItemID]
            if (OmitPropName != "SamplingPlanType") labSheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "LabSheetStatus") labSheet.LabSheetStatus = (LabSheetStatusEnum)GetRandomEnumType(typeof(LabSheetStatusEnum));
            if (OmitPropName != "FileName") labSheet.FileName = GetRandomString("", 6);
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 5);
            //Error: property [LabSheetWeb] and type [LabSheet] is  not implemented
            //Error: property [LabSheetReport] and type [LabSheet] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") labSheet.HasErrors = true;

            return labSheet;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheet_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetService labSheetService = new LabSheetService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LabSheet labSheet = GetFilledRandomLabSheet("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = labSheetService.GetRead().Count();

                    Assert.AreEqual(labSheetService.GetRead().Count(), labSheetService.GetEdit().Count());

                    labSheetService.Add(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, labSheetService.GetRead().Where(c => c == labSheet).Any());
                    labSheetService.Update(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, labSheetService.GetRead().Count());
                    labSheetService.Delete(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // labSheet.LabSheetID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetID = 0;
                    labSheetService.Update(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetLabSheetID), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetID = 10000000;
                    labSheetService.Update(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheet, CSSPModelsRes.LabSheetLabSheetID, labSheet.LabSheetID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // labSheet.OtherServerLabSheetID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.OtherServerLabSheetID = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LabSheetOtherServerLabSheetID, "1"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                    // labSheet.SamplingPlanID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.LabSheetSamplingPlanID, labSheet.SamplingPlanID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250, MinimumLength = 1)]
                    // labSheet.SamplingPlanName   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("SamplingPlanName");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetSamplingPlanName)).Any());
                    Assert.AreEqual(null, labSheet.SamplingPlanName);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanName = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetSamplingPlanName, "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1980, -1)]
                    // labSheet.Year   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Year = 1979;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LabSheetYear, "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 12)]
                    // labSheet.Month   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Month = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetMonth, "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Month = 13;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetMonth, "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 31)]
                    // labSheet.Day   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Day = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDay, "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Day = 32;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDay, "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // labSheet.RunNumber   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RunNumber = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetRunNumber, "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RunNumber = 101;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetRunNumber, "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // labSheet.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SubsectorTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetSubsectorTVItemID, labSheet.SubsectorTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SubsectorTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetSubsectorTVItemID, "Subsector"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // labSheet.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.MWQMRunTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetMWQMRunTVItemID, labSheet.MWQMRunTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.MWQMRunTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetMWQMRunTVItemID, "MWQMRun"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetSamplingPlanType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.SampleType   (SampleTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SampleType = (SampleTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetSampleType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.LabSheetType   (LabSheetTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetType = (LabSheetTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetLabSheetType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.LabSheetStatus   (LabSheetStatusEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetStatus = (LabSheetStatusEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetLabSheetStatus), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250, MinimumLength = 1)]
                    // labSheet.FileName   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("FileName");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetFileName)).Any());
                    Assert.AreEqual(null, labSheet.FileName);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.FileName = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetFileName, "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.FileLastModifiedDate_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // labSheet.FileContent   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("FileContent");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetFileContent)).Any());
                    Assert.AreEqual(null, labSheet.FileContent);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.AcceptedOrRejectedByContactTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, labSheet.AcceptedOrRejectedByContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.AcceptedOrRejectedByContactTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.AcceptedOrRejectedDateTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheet.RejectReason   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RejectReason = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetRejectReason, "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheet.LabSheetWeb   (LabSheetWeb)
                    // -----------------------------------

                    //Error: Type not implemented [LabSheetWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheet.LabSheetReport   (LabSheetReport)
                    // -----------------------------------

                    //Error: Type not implemented [LabSheetReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheet.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateContactTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetLastUpdateContactTVItemID, labSheet.LastUpdateContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateContactTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetLastUpdateContactTVItemID, "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheet.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheet.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void LabSheet_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetService labSheetService = new LabSheetService(LanguageRequest, dbTestDB, ContactID);
                    LabSheet labSheet = (from c in labSheetService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    LabSheet labSheetRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetRet = labSheetService.GetLabSheetWithLabSheetID(labSheet.LabSheetID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetRet = labSheetService.GetLabSheetWithLabSheetID(labSheet.LabSheetID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetRet = labSheetService.GetLabSheetWithLabSheetID(labSheet.LabSheetID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(labSheetRet.LabSheetID);
                        Assert.IsNotNull(labSheetRet.OtherServerLabSheetID);
                        Assert.IsNotNull(labSheetRet.SamplingPlanID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetRet.SamplingPlanName));
                        Assert.IsNotNull(labSheetRet.Year);
                        Assert.IsNotNull(labSheetRet.Month);
                        Assert.IsNotNull(labSheetRet.Day);
                        Assert.IsNotNull(labSheetRet.RunNumber);
                        Assert.IsNotNull(labSheetRet.SubsectorTVItemID);
                        if (labSheetRet.MWQMRunTVItemID != null)
                        {
                            Assert.IsNotNull(labSheetRet.MWQMRunTVItemID);
                        }
                        Assert.IsNotNull(labSheetRet.SamplingPlanType);
                        Assert.IsNotNull(labSheetRet.SampleType);
                        Assert.IsNotNull(labSheetRet.LabSheetType);
                        Assert.IsNotNull(labSheetRet.LabSheetStatus);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetRet.FileName));
                        Assert.IsNotNull(labSheetRet.FileLastModifiedDate_Local);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetRet.FileContent));
                        if (labSheetRet.AcceptedOrRejectedByContactTVItemID != null)
                        {
                            Assert.IsNotNull(labSheetRet.AcceptedOrRejectedByContactTVItemID);
                        }
                        if (labSheetRet.AcceptedOrRejectedDateTime != null)
                        {
                            Assert.IsNotNull(labSheetRet.AcceptedOrRejectedDateTime);
                        }
                        if (labSheetRet.RejectReason != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetRet.RejectReason));
                        }
                        Assert.IsNotNull(labSheetRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(labSheetRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (labSheetRet.LabSheetWeb != null)
                            {
                                Assert.IsNull(labSheetRet.LabSheetWeb);
                            }
                            if (labSheetRet.LabSheetReport != null)
                            {
                                Assert.IsNull(labSheetRet.LabSheetReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (labSheetRet.LabSheetWeb != null)
                            {
                                Assert.IsNotNull(labSheetRet.LabSheetWeb);
                            }
                            if (labSheetRet.LabSheetReport != null)
                            {
                                Assert.IsNotNull(labSheetRet.LabSheetReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of LabSheet
        #endregion Tests Get List of LabSheet

    }
}
