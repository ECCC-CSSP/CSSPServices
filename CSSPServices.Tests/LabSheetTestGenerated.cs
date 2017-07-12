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
        private int LabSheetID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheetID += 1;

            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "LabSheetID") labSheet.LabSheetID = LabSheetID;
            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheet.SamplingPlanID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 5);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            if (OmitPropName != "SubsectorTVItemID") labSheet.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MWQMRunTVItemID") labSheet.MWQMRunTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanType") labSheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "LabSheetStatus") labSheet.LabSheetStatus = (LabSheetStatusEnum)GetRandomEnumType(typeof(LabSheetStatusEnum));
            if (OmitPropName != "FileName") labSheet.FileName = GetRandomString("", 5);
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = GetRandomDateTime();
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = GetRandomDateTime();
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return labSheet;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheet_Testing()
        {
            SetupTestHelper(culture);
            LabSheetService labSheetService = new LabSheetService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            LabSheet labSheet = GetFilledRandomLabSheet("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(true, labSheetService.GetRead().Where(c => c == labSheet).Any());
            labSheet.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, labSheetService.Update(labSheet));
            Assert.AreEqual(1, labSheetService.GetRead().Count());
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // OtherServerLabSheetID will automatically be initialized at 0 --> not null

            // SamplingPlanID will automatically be initialized at 0 --> not null

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("SamplingPlanName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName)).Any());
            Assert.AreEqual(null, labSheet.SamplingPlanName);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            // Year will automatically be initialized at 0 --> not null

            // Month will automatically be initialized at 0 --> not null

            // Day will automatically be initialized at 0 --> not null

            // RunNumber will automatically be initialized at 0 --> not null

            // SubsectorTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SamplingPlanType]

            //Error: Type not implemented [SampleType]

            //Error: Type not implemented [LabSheetType]

            //Error: Type not implemented [LabSheetStatus]

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileName");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileName)).Any());
            Assert.AreEqual(null, labSheet.FileName);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileLastModifiedDate_Local");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileLastModifiedDate_Local)).Any());
            Assert.IsTrue(labSheet.FileLastModifiedDate_Local.Year < 1900);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("FileContent");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent)).Any());
            Assert.AreEqual(null, labSheet.FileContent);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("RejectReason");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetRejectReason)).Any());
            Assert.AreEqual(null, labSheet.RejectReason);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("LastUpdateDate_UTC");
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.AreEqual(1, labSheet.ValidationResults.Count());
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLastUpdateDate_UTC)).Any());
            Assert.IsTrue(labSheet.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [LabSheetDetails]

            //Error: Type not implemented [AcceptedOrRejectedByContactTVItem]

            //Error: Type not implemented [MWQMRunTVItem]

            //Error: Type not implemented [SamplingPlan]

            //Error: Type not implemented [SubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LabSheetID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [OtherServerLabSheetID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.OtherServerLabSheetID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.OtherServerLabSheetID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // OtherServerLabSheetID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.OtherServerLabSheetID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1")).Any());
            Assert.AreEqual(0, labSheet.OtherServerLabSheetID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [SamplingPlanID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.SamplingPlanID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.SamplingPlanID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.SamplingPlanID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.SamplingPlanID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.SamplingPlanID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, labSheet.SamplingPlanID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [SamplingPlanName] of type [String]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            //-----------------------------------
            // doing property [Year] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Year has Min [1980] and Max [empty]. At Min should return true and no errors
            labSheet.Year = 1980;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1980, labSheet.Year);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Year has Min [1980] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.Year = 1981;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1981, labSheet.Year);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Year has Min [1980] and Max [empty]. At Min - 1 should return false with one error
            labSheet.Year = 1979;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetYear, "1980")).Any());
            Assert.AreEqual(1979, labSheet.Year);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [Month] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Month has Min [1] and Max [12]. At Min should return true and no errors
            labSheet.Month = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Min + 1 should return true and no errors
            labSheet.Month = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Min - 1 should return false with one error
            labSheet.Month = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12")).Any());
            Assert.AreEqual(0, labSheet.Month);
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max should return true and no errors
            labSheet.Month = 12;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(12, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max - 1 should return true and no errors
            labSheet.Month = 11;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(11, labSheet.Month);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Month has Min [1] and Max [12]. At Max + 1 should return false with one error
            labSheet.Month = 13;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12")).Any());
            Assert.AreEqual(13, labSheet.Month);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [Day] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // Day has Min [1] and Max [31]. At Min should return true and no errors
            labSheet.Day = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Min + 1 should return true and no errors
            labSheet.Day = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Min - 1 should return false with one error
            labSheet.Day = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31")).Any());
            Assert.AreEqual(0, labSheet.Day);
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max should return true and no errors
            labSheet.Day = 31;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(31, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max - 1 should return true and no errors
            labSheet.Day = 30;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(30, labSheet.Day);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // Day has Min [1] and Max [31]. At Max + 1 should return false with one error
            labSheet.Day = 32;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31")).Any());
            Assert.AreEqual(32, labSheet.Day);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [RunNumber] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // RunNumber has Min [1] and Max [100]. At Min should return true and no errors
            labSheet.RunNumber = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Min + 1 should return true and no errors
            labSheet.RunNumber = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Min - 1 should return false with one error
            labSheet.RunNumber = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100")).Any());
            Assert.AreEqual(0, labSheet.RunNumber);
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max should return true and no errors
            labSheet.RunNumber = 100;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(100, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max - 1 should return true and no errors
            labSheet.RunNumber = 99;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(99, labSheet.RunNumber);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // RunNumber has Min [1] and Max [100]. At Max + 1 should return false with one error
            labSheet.RunNumber = 101;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100")).Any());
            Assert.AreEqual(101, labSheet.RunNumber);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [SubsectorTVItemID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.SubsectorTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.SubsectorTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.SubsectorTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.SubsectorTVItemID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMRunTVItemID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.MWQMRunTVItemID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [SamplingPlanType] of type [SamplingPlanTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SampleType] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetType] of type [LabSheetTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetStatus] of type [LabSheetStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FileName] of type [String]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            //-----------------------------------
            // doing property [FileLastModifiedDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [FileContent] of type [String]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            //-----------------------------------
            // doing property [AcceptedOrRejectedByContactTVItemID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.AcceptedOrRejectedByContactTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // AcceptedOrRejectedByContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.AcceptedOrRejectedByContactTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.AcceptedOrRejectedByContactTVItemID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [AcceptedOrRejectedDateTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [RejectReason] of type [String]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            labSheet = null;
            labSheet = GetFilledRandomLabSheet("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheet.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(1, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheet.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetService.Add(labSheet));
            Assert.AreEqual(0, labSheet.ValidationResults.Count());
            Assert.AreEqual(2, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetService.Delete(labSheet));
            Assert.AreEqual(0, labSheetService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheet.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetService.Add(labSheet));
            Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheet.LastUpdateContactTVItemID);
            Assert.AreEqual(0, labSheetService.GetRead().Count());

            //-----------------------------------
            // doing property [LabSheetDetails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [AcceptedOrRejectedByContactTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlan] of type [SamplingPlan]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
