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
    public partial class LabSheetTubeMPNDetailTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LabSheetTubeMPNDetailID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            LabSheetTubeMPNDetailID += 1;

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "LabSheetTubeMPNDetailID") labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = LabSheetTubeMPNDetailID;
            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = GetRandomInt(1, 11);
            if (OmitPropName != "Ordinal") labSheetTubeMPNDetail.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "MWQMSiteTVItemID") labSheetTubeMPNDetail.MWQMSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SampleDateTime") labSheetTubeMPNDetail.SampleDateTime = GetRandomDateTime();
            if (OmitPropName != "MPN") labSheetTubeMPNDetail.MPN = GetRandomInt(1, 20000000);
            if (OmitPropName != "Tube10") labSheetTubeMPNDetail.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") labSheetTubeMPNDetail.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") labSheetTubeMPNDetail.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "Salinity") labSheetTubeMPNDetail.Salinity = GetRandomFloat(0, 40);
            if (OmitPropName != "Temperature") labSheetTubeMPNDetail.Temperature = GetRandomFloat(0, 40);
            if (OmitPropName != "ProcessedBy") labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "SampleType") labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetTubeMPNDetail.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheetTubeMPNDetail.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetTubeMPNDetail.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return labSheetTubeMPNDetail;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetTubeMPNDetail_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(true, labSheetTubeMPNDetailService.GetRead().Where(c => c == labSheetTubeMPNDetail).Any());
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail));
            Assert.AreEqual(1, labSheetTubeMPNDetailService.GetRead().Count());
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // LabSheetDetailID will automatically be initialized at 0 --> not null

            // Ordinal will automatically be initialized at 0 --> not null

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("SampleType");
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(1, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailSampleType)).Any());
            Assert.AreEqual(SampleTypeEnum.Error, labSheetTubeMPNDetail.SampleType);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("LastUpdateDate_UTC");
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(1, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC)).Any());
            Assert.IsTrue(labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LabSheetTubeMPNDetailID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetDetailID] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // LabSheetDetailID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.LabSheetDetailID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // LabSheetDetailID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.LabSheetDetailID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // LabSheetDetailID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.LabSheetDetailID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Ordinal] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Ordinal = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 1000;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1000, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 999;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(999, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Ordinal = 1001;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleDateTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MPN] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // MPN has Min [1] and Max [20000000]. At Min should return true and no errors
            labSheetTubeMPNDetail.MPN = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [20000000]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.MPN = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [20000000]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.MPN = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "20000000")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [20000000]. At Max should return true and no errors
            labSheetTubeMPNDetail.MPN = 20000000;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(20000000, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [20000000]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.MPN = 19999999;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(19999999, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [20000000]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.MPN = 20000001;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "20000000")).Any());
            Assert.AreEqual(20000001, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Tube10] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube10 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube10 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube10 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Tube1_0] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube1_0 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube1_0 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube1_0 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Tube0_1] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube0_1 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube0_1 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube0_1 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Salinity] of type [float]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Salinity has Min [0] and Max [40]. At Min should return true and no errors
            labSheetTubeMPNDetail.Salinity = 0.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Salinity = 1.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Salinity = -1.0f;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0] and Max [40]. At Max should return true and no errors
            labSheetTubeMPNDetail.Salinity = 40.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Salinity = 39.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Salinity = 41.0f;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Temperature] of type [float]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Temperature has Min [0] and Max [40]. At Min should return true and no errors
            labSheetTubeMPNDetail.Temperature = 0.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Temperature = 1.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Temperature = -1.0f;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [0] and Max [40]. At Max should return true and no errors
            labSheetTubeMPNDetail.Temperature = 40.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Temperature = 39.0f;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Temperature = 41.0f;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [ProcessedBy] of type [string]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string labSheetTubeMPNDetailProcessedByMin = GetRandomString("", 10);
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailProcessedByMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailProcessedByMin, labSheetTubeMPNDetail.ProcessedBy);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetailProcessedByMin = GetRandomString("", 9);
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailProcessedByMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailProcessedByMin, labSheetTubeMPNDetail.ProcessedBy);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetTubeMPNDetailProcessedByMin = GetRandomString("", 11);
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailProcessedByMin;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailProcessedBy, "10")).Any());
            Assert.AreEqual(labSheetTubeMPNDetailProcessedByMin, labSheetTubeMPNDetail.ProcessedBy);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleType] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SiteComment] of type [string]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");

            // SiteComment has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string labSheetTubeMPNDetailSiteCommentMin = GetRandomString("", 250);
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailSiteCommentMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailSiteCommentMin, labSheetTubeMPNDetail.SiteComment);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // SiteComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetailSiteCommentMin = GetRandomString("", 249);
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailSiteCommentMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailSiteCommentMin, labSheetTubeMPNDetail.SiteComment);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            // SiteComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetTubeMPNDetailSiteCommentMin = GetRandomString("", 251);
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailSiteCommentMin;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailSiteComment, "250")).Any());
            Assert.AreEqual(labSheetTubeMPNDetailSiteCommentMin, labSheetTubeMPNDetail.SiteComment);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(0, labSheetTubeMPNDetailService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
