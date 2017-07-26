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
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = GetRandomDateTime();
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = GetRandomDateTime();
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = GetRandomDateTime();
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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // labSheet.LabSheetID   (Int32)
            //-----------------------------------
            labSheet = GetFilledRandomLabSheet("");
            labSheet.LabSheetID = 0;
            labSheetService.Update(labSheet);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetID), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, -1)]
            // labSheet.OtherServerLabSheetID   (Int32)
            //-----------------------------------
            // OtherServerLabSheetID will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.OtherServerLabSheetID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.OtherServerLabSheetID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.OtherServerLabSheetID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1")).Any());
            Assert.AreEqual(0, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "SamplingPlan", Plurial = "s", FieldID = "SamplingPlanID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // labSheet.SamplingPlanID   (Int32)
            //-----------------------------------
            // SamplingPlanID will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.SamplingPlanID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.SamplingPlanID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.SamplingPlanID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.SamplingPlanID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.SamplingPlanID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, labSheet.SamplingPlanID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(250, MinimumLength = 1)]
            // labSheet.SamplingPlanName   (String)
            //-----------------------------------
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("SamplingPlanName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName)).Any());
            Assert.AreEqual(null, labSheet.SamplingPlanName);
            Assert.AreEqual(0, labSheetService.GetRead().Count());


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            // SamplingPlanName has MinLength [1] and MaxLength [250]. At Min should return true and no errors
            string labSheetSamplingPlanNameMin = GetRandomString("", 1);
            labSheet.SamplingPlanName = labSheetSamplingPlanNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetSamplingPlanNameMin, labSheet.SamplingPlanName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // SamplingPlanName has MinLength [1] and MaxLength [250]. At Min + 1 should return true and no errors
            labSheetSamplingPlanNameMin = GetRandomString("", 2);
            labSheet.SamplingPlanName = labSheetSamplingPlanNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetSamplingPlanNameMin, labSheet.SamplingPlanName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // SamplingPlanName has MinLength [1] and MaxLength [250]. At Max should return true and no errors
            labSheetSamplingPlanNameMin = GetRandomString("", 250);
            labSheet.SamplingPlanName = labSheetSamplingPlanNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetSamplingPlanNameMin, labSheet.SamplingPlanName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // SamplingPlanName has MinLength [1] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetSamplingPlanNameMin = GetRandomString("", 249);
            labSheet.SamplingPlanName = labSheetSamplingPlanNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetSamplingPlanNameMin, labSheet.SamplingPlanName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // SamplingPlanName has MinLength [1] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetSamplingPlanNameMin = GetRandomString("", 251);
            labSheet.SamplingPlanName = labSheetSamplingPlanNameMin;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetSamplingPlanName, "1", "250")).Any());
            Assert.AreEqual(labSheetSamplingPlanNameMin, labSheet.SamplingPlanName);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1980, -1)]
            // labSheet.Year   (Int32)
            //-----------------------------------
            // Year will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Year has Min [1980] and Max [empty]. At Min should return true and no errors
            labSheet.Year = 1980;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1980, labSheet.Year);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Year has Min [1980] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.Year = 1981;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1981, labSheet.Year);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Year has Min [1980] and Max [empty]. At Min - 1 should return false with one error
            labSheet.Year = 1979;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetYear, "1980")).Any());
            Assert.AreEqual(1979, labSheet.Year);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 12)]
            // labSheet.Month   (Int32)
            //-----------------------------------
            // Month will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Month has Min [1] and Max [12]. At Min should return true and no errors
            labSheet.Month = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Min + 1 should return true and no errors
            labSheet.Month = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Min - 1 should return false with one error
            labSheet.Month = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12")).Any());
            Assert.AreEqual(0, labSheet.Month);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max should return true and no errors
            labSheet.Month = 12;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(12, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max - 1 should return true and no errors
            labSheet.Month = 11;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(11, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max + 1 should return false with one error
            labSheet.Month = 13;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12")).Any());
            Assert.AreEqual(13, labSheet.Month);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 31)]
            // labSheet.Day   (Int32)
            //-----------------------------------
            // Day will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Day has Min [1] and Max [31]. At Min should return true and no errors
            labSheet.Day = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Min + 1 should return true and no errors
            labSheet.Day = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Min - 1 should return false with one error
            labSheet.Day = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31")).Any());
            Assert.AreEqual(0, labSheet.Day);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max should return true and no errors
            labSheet.Day = 31;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(31, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max - 1 should return true and no errors
            labSheet.Day = 30;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(30, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max + 1 should return false with one error
            labSheet.Day = 32;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31")).Any());
            Assert.AreEqual(32, labSheet.Day);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 100)]
            // labSheet.RunNumber   (Int32)
            //-----------------------------------
            // RunNumber will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // RunNumber has Min [1] and Max [100]. At Min should return true and no errors
            labSheet.RunNumber = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Min + 1 should return true and no errors
            labSheet.RunNumber = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Min - 1 should return false with one error
            labSheet.RunNumber = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100")).Any());
            Assert.AreEqual(0, labSheet.RunNumber);
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max should return true and no errors
            labSheet.RunNumber = 100;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(100, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max - 1 should return true and no errors
            labSheet.RunNumber = 99;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(99, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max + 1 should return false with one error
            labSheet.RunNumber = 101;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100")).Any());
            Assert.AreEqual(101, labSheet.RunNumber);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            //[Range(1, -1)]
            // labSheet.SubsectorTVItemID   (Int32)
            //-----------------------------------
            // SubsectorTVItemID will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.SubsectorTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.SubsectorTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.SubsectorTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.SubsectorTVItemID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMRun)]
            //[Range(1, -1)]
            // labSheet.MWQMRunTVItemID   (Int32)
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
            //-----------------------------------
            // SamplingPlanType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // labSheet.SampleType   (SampleTypeEnum)
            //-----------------------------------
            // SampleType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // labSheet.LabSheetType   (LabSheetTypeEnum)
            //-----------------------------------
            // LabSheetType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // labSheet.LabSheetStatus   (LabSheetStatusEnum)
            //-----------------------------------
            // LabSheetStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(250, MinimumLength = 1)]
            // labSheet.FileName   (String)
            //-----------------------------------
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileName)).Any());
            Assert.AreEqual(null, labSheet.FileName);
            Assert.AreEqual(0, labSheetService.GetRead().Count());


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            // FileName has MinLength [1] and MaxLength [250]. At Min should return true and no errors
            string labSheetFileNameMin = GetRandomString("", 1);
            labSheet.FileName = labSheetFileNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetFileNameMin, labSheet.FileName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // FileName has MinLength [1] and MaxLength [250]. At Min + 1 should return true and no errors
            labSheetFileNameMin = GetRandomString("", 2);
            labSheet.FileName = labSheetFileNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetFileNameMin, labSheet.FileName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // FileName has MinLength [1] and MaxLength [250]. At Max should return true and no errors
            labSheetFileNameMin = GetRandomString("", 250);
            labSheet.FileName = labSheetFileNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetFileNameMin, labSheet.FileName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // FileName has MinLength [1] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetFileNameMin = GetRandomString("", 249);
            labSheet.FileName = labSheetFileNameMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetFileNameMin, labSheet.FileName);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // FileName has MinLength [1] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetFileNameMin = GetRandomString("", 251);
            labSheet.FileName = labSheetFileNameMin;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetFileName, "1", "250")).Any());
            Assert.AreEqual(labSheetFileNameMin, labSheet.FileName);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheet.FileLastModifiedDate_Local   (DateTime)
            //-----------------------------------
            // FileLastModifiedDate_Local will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            // labSheet.FileContent   (String)
            //-----------------------------------
            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileContent");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent)).Any());
            Assert.AreEqual(null, labSheet.FileContent);
            Assert.AreEqual(0, labSheetService.GetRead().Count());


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            //-----------------------------------
            //Is Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.AcceptedOrRejectedByContactTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.AcceptedOrRejectedByContactTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheet.AcceptedOrRejectedDateTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // labSheet.RejectReason   (String)
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            // RejectReason has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string labSheetRejectReasonMin = GetRandomString("", 250);
            labSheet.RejectReason = labSheetRejectReasonMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetRejectReasonMin, labSheet.RejectReason);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // RejectReason has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetRejectReasonMin = GetRandomString("", 249);
            labSheet.RejectReason = labSheetRejectReasonMin;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(labSheetRejectReasonMin, labSheet.RejectReason);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            // RejectReason has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetRejectReasonMin = GetRandomString("", 251);
            labSheet.RejectReason = labSheetRejectReasonMin;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetRejectReason, "250")).Any());
            Assert.AreEqual(labSheetRejectReasonMin, labSheet.RejectReason);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheet.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // labSheet.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(count, labSheetService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(count, labSheetService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheet.LabSheetDetails   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheet.AcceptedOrRejectedByContactTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheet.MWQMRunTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheet.SamplingPlan   (SamplingPlan)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheet.SubsectorTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // labSheet.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
