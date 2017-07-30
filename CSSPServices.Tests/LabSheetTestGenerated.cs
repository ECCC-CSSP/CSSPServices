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
    public partial class LabSheetTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LabSheetService labSheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTest() : base()
        {
            labSheetService = new LabSheetService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheet.SamplingPlanID = 1;
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 6);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            if (OmitPropName != "SubsectorTVItemID") labSheet.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") labSheet.MWQMRunTVItemID = 24;
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
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = 2;

            return labSheet;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheet_Testing()
        {

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

            labSheetService.Add(labSheet);
            if (labSheet.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, labSheetService.GetRead().Where(c => c == labSheet).Any());
            labSheetService.Update(labSheet);
            if (labSheet.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, labSheetService.GetRead().Count());
            labSheetService.Delete(labSheet);
            if (labSheet.ValidationResults.Count() > 0)
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetID), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, -1)]
            // labSheet.OtherServerLabSheetID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.OtherServerLabSheetID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "SamplingPlan", Plurial = "s", FieldID = "SamplingPlanID", TVType = TVTypeEnum.Error)]
            // labSheet.SamplingPlanID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanID = 0;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.LabSheetSamplingPlanID, labSheet.SamplingPlanID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250, MinimumLength = 1)]
            // labSheet.SamplingPlanName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("SamplingPlanName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName)).Any());
            Assert.AreEqual(null, labSheet.SamplingPlanName);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanName = GetRandomString("", 251);
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetSamplingPlanName, "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetYear, "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Month = 13;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.Day = 32;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.RunNumber = 101;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            // labSheet.SubsectorTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 0;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetSubsectorTVItemID, labSheet.SubsectorTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SubsectorTVItemID = 1;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetSubsectorTVItemID, "Subsector"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMRun)]
            // labSheet.MWQMRunTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 0;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetMWQMRunTVItemID, labSheet.MWQMRunTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.MWQMRunTVItemID = 1;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetMWQMRunTVItemID, "MWQMRun"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.SampleType   (SampleTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.SampleType = (SampleTypeEnum)1000000;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSampleType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetType   (LabSheetTypeEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetType = (LabSheetTypeEnum)1000000;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetType), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // labSheet.LabSheetStatus   (LabSheetStatusEnum)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetStatus = (LabSheetStatusEnum)1000000;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetStatus), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250, MinimumLength = 1)]
            // labSheet.FileName   (String)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileName)).Any());
            Assert.AreEqual(null, labSheet.FileName);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.FileName = GetRandomString("", 251);
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetFileName, "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent)).Any());
            Assert.AreEqual(null, labSheet.FileContent);
            Assert.AreEqual(count, labSheetService.GetRead().Count());


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 0;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, labSheet.AcceptedOrRejectedByContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.AcceptedOrRejectedByContactTVItemID = 1;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetRejectReason, "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // labSheet.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // labSheet.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 0;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetLastUpdateContactTVItemID, labSheet.LastUpdateContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LastUpdateContactTVItemID = 1;
            labSheetService.Add(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetLastUpdateContactTVItemID, "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // labSheet.LabSheetDetails   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // labSheet.AcceptedOrRejectedByContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // labSheet.MWQMRunTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // labSheet.SamplingPlan   (SamplingPlan)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // labSheet.SubsectorTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // labSheet.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
