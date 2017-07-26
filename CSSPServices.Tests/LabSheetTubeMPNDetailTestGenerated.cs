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
        private LabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailTest() : base()
        {
            labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = 1;
            if (OmitPropName != "Ordinal") labSheetTubeMPNDetail.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "MWQMSiteTVItemID") labSheetTubeMPNDetail.MWQMSiteTVItemID = 19;
            if (OmitPropName != "SampleDateTime") labSheetTubeMPNDetail.SampleDateTime = GetRandomDateTime();
            if (OmitPropName != "MPN") labSheetTubeMPNDetail.MPN = GetRandomInt(1, 10000000);
            if (OmitPropName != "Tube10") labSheetTubeMPNDetail.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") labSheetTubeMPNDetail.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") labSheetTubeMPNDetail.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "Salinity") labSheetTubeMPNDetail.Salinity = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "Temperature") labSheetTubeMPNDetail.Temperature = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ProcessedBy") labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "SampleType") labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetTubeMPNDetail.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheetTubeMPNDetail.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;

            return labSheetTubeMPNDetail;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetTubeMPNDetail_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = labSheetTubeMPNDetailService.GetRead().Count();

            labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, labSheetTubeMPNDetailService.GetRead().Where(c => c == labSheetTubeMPNDetail).Any());
            labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, labSheetTubeMPNDetailService.GetRead().Count());
            labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // labSheetTubeMPNDetail.LabSheetTubeMPNDetailID   (Int32)
            //-----------------------------------
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
            labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "LabSheetDetail", Plurial = "s", FieldID = "LabSheetDetailID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
            //-----------------------------------
            // LabSheetDetailID will automatically be initialized at 0 --> not null


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // LabSheetDetailID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.LabSheetDetailID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // LabSheetDetailID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.LabSheetDetailID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // LabSheetDetailID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.LabSheetDetailID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.LabSheetDetailID);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // labSheetTubeMPNDetail.Ordinal   (Int32)
            //-----------------------------------
            // Ordinal will automatically be initialized at 0 --> not null


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Ordinal = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 1000;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1000, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Ordinal = 999;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(999, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Ordinal = 1001;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, labSheetTubeMPNDetail.Ordinal);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            //[Range(1, -1)]
            // labSheetTubeMPNDetail.MWQMSiteTVItemID   (Int32)
            //-----------------------------------
            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.MWQMSiteTVItemID);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(1, 10000000)]
            // labSheetTubeMPNDetail.MPN   (Int32)
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // MPN has Min [1] and Max [10000000]. At Min should return true and no errors
            labSheetTubeMPNDetail.MPN = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [10000000]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.MPN = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [10000000]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.MPN = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [10000000]. At Max should return true and no errors
            labSheetTubeMPNDetail.MPN = 10000000;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(10000000, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [10000000]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.MPN = 9999999;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(9999999, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // MPN has Min [1] and Max [10000000]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.MPN = 10000001;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000")).Any());
            Assert.AreEqual(10000001, labSheetTubeMPNDetail.MPN);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // labSheetTubeMPNDetail.Tube10   (Int32)
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube10 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube10 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube10 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube10 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube10);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // labSheetTubeMPNDetail.Tube1_0   (Int32)
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube1_0 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube1_0 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube1_0 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube1_0 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube1_0 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube1_0);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // labSheetTubeMPNDetail.Tube0_1   (Int32)
            //-----------------------------------

            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Tube0_1 has Min [0] and Max [5]. At Min should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 0;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Tube0_1 = -1;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5")).Any());
            Assert.AreEqual(-1, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 5;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Tube0_1 = 4;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Tube0_1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Tube0_1 = 6;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5")).Any());
            Assert.AreEqual(6, labSheetTubeMPNDetail.Tube0_1);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 40)]
            // labSheetTubeMPNDetail.Salinity   (Double)
            //-----------------------------------
            //Error: Type not implemented [Salinity]


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Salinity has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetTubeMPNDetail.Salinity = 0.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(0.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Salinity = 1.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Salinity = -1.0D;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40")).Any());
            Assert.AreEqual(-1.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetTubeMPNDetail.Salinity = 40.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Salinity = 39.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Salinity has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Salinity = 41.0D;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40")).Any());
            Assert.AreEqual(41.0D, labSheetTubeMPNDetail.Salinity);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetTubeMPNDetail.Temperature   (Double)
            //-----------------------------------
            //Error: Type not implemented [Temperature]


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // Temperature has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetTubeMPNDetail.Temperature = -10.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.Temperature = -9.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.Temperature = -11.0D;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetTubeMPNDetail.Temperature = 40.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetail.Temperature = 39.0D;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // Temperature has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetTubeMPNDetail.Temperature = 41.0D;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetTubeMPNDetail.Temperature);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(10))]
            // labSheetTubeMPNDetail.ProcessedBy   (String)
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
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetailProcessedByMin = GetRandomString("", 9);
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailProcessedByMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailProcessedByMin, labSheetTubeMPNDetail.ProcessedBy);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetTubeMPNDetailProcessedByMin = GetRandomString("", 11);
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailProcessedByMin;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailProcessedBy, "10")).Any());
            Assert.AreEqual(labSheetTubeMPNDetailProcessedByMin, labSheetTubeMPNDetail.ProcessedBy);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // labSheetTubeMPNDetail.SampleType   (SampleTypeEnum)
            //-----------------------------------
            // SampleType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // labSheetTubeMPNDetail.SiteComment   (String)
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
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            // SiteComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetTubeMPNDetailSiteCommentMin = GetRandomString("", 249);
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailSiteCommentMin;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetTubeMPNDetailSiteCommentMin, labSheetTubeMPNDetail.SiteComment);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            // SiteComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetTubeMPNDetailSiteCommentMin = GetRandomString("", 251);
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailSiteCommentMin;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailSiteComment, "250")).Any());
            Assert.AreEqual(labSheetTubeMPNDetailSiteCommentMin, labSheetTubeMPNDetail.SiteComment);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            labSheetTubeMPNDetail = null;
            labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.AreEqual(0, labSheetTubeMPNDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail));
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
            Assert.IsTrue(labSheetTubeMPNDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetTubeMPNDetail.LabSheetDetail   (LabSheetDetail)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetTubeMPNDetail.MWQMSiteTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // labSheetTubeMPNDetail.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
