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
    public partial class LabSheetTubeMPNDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailServiceTest() : base()
        {
            //labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "SampleDateTime") labSheetTubeMPNDetail.SampleDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "MPN") labSheetTubeMPNDetail.MPN = GetRandomInt(1, 10000000);
            if (OmitPropName != "Tube10") labSheetTubeMPNDetail.Tube10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube1_0") labSheetTubeMPNDetail.Tube1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube0_1") labSheetTubeMPNDetail.Tube0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "Salinity") labSheetTubeMPNDetail.Salinity = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "Temperature") labSheetTubeMPNDetail.Temperature = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ProcessedBy") labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "SampleType") labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetTubeMPNDetail.SiteComment = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "MWQMSiteTVText") labSheetTubeMPNDetail.MWQMSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") labSheetTubeMPNDetail.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "SampleTypeText") labSheetTubeMPNDetail.SampleTypeText = GetRandomString("", 5);

            return labSheetTubeMPNDetail;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheetTubeMPNDetail_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, dbTestDB, ContactID);

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


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // labSheetTubeMPNDetail.LabSheetTubeMPNDetailID   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
                labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = Error)]
                // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.LabSheetDetailID = 0;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheetDetail, ModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, labSheetTubeMPNDetail.LabSheetDetailID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // labSheetTubeMPNDetail.Ordinal   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Ordinal = -1;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Ordinal = 1001;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                // labSheetTubeMPNDetail.MWQMSiteTVItemID   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "MWQMSite"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(1, 10000000)]
                // labSheetTubeMPNDetail.MPN   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.MPN = 0;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.MPN = 10000001;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 5)]
                // labSheetTubeMPNDetail.Tube10   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube10 = -1;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube10 = 6;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 5)]
                // labSheetTubeMPNDetail.Tube1_0   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube1_0 = -1;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube1_0 = 6;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 5)]
                // labSheetTubeMPNDetail.Tube0_1   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube0_1 = -1;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Tube0_1 = 6;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 40)]
                // labSheetTubeMPNDetail.Salinity   (Double)
                // -----------------------------------

                //Error: Type not implemented [Salinity]

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Salinity = -1.0D;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Salinity = 41.0D;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-10, 40)]
                // labSheetTubeMPNDetail.Temperature   (Double)
                // -----------------------------------

                //Error: Type not implemented [Temperature]

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Temperature = -11.0D;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.Temperature = 41.0D;
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(10))]
                // labSheetTubeMPNDetail.ProcessedBy   (String)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 11);
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailProcessedBy, "10"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // labSheetTubeMPNDetail.SampleType   (SampleTypeEnum)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)1000000;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailSampleType), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [StringLength(250))]
                // labSheetTubeMPNDetail.SiteComment   (String)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.SiteComment = GetRandomString("", 251);
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailSiteComment, "250"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
                labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "Contact"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // labSheetTubeMPNDetail.MWQMSiteTVText   (String)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.MWQMSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVText, "200"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // labSheetTubeMPNDetail.LastUpdateContactTVText   (String)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVText, "200"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // labSheetTubeMPNDetail.SampleTypeText   (String)
                // -----------------------------------

                labSheetTubeMPNDetail = null;
                labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                labSheetTubeMPNDetail.SampleTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailSampleTypeText, "100"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // labSheetTubeMPNDetail.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void LabSheetTubeMPNDetail_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(LanguageRequest, dbTestDB, ContactID);
                LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in labSheetTubeMPNDetailService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(labSheetTubeMPNDetail);

                LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                Assert.IsNotNull(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);
                Assert.IsNotNull(labSheetTubeMPNDetailRet.LabSheetDetailID);
                Assert.IsNotNull(labSheetTubeMPNDetailRet.Ordinal);
                Assert.IsNotNull(labSheetTubeMPNDetailRet.MWQMSiteTVItemID);
                if (labSheetTubeMPNDetailRet.SampleDateTime != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.SampleDateTime);
                }
                if (labSheetTubeMPNDetailRet.MPN != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.MPN);
                }
                if (labSheetTubeMPNDetailRet.Tube10 != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.Tube10);
                }
                if (labSheetTubeMPNDetailRet.Tube1_0 != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.Tube1_0);
                }
                if (labSheetTubeMPNDetailRet.Tube0_1 != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.Tube0_1);
                }
                if (labSheetTubeMPNDetailRet.Salinity != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.Salinity);
                }
                if (labSheetTubeMPNDetailRet.Temperature != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.Temperature);
                }
                if (labSheetTubeMPNDetailRet.ProcessedBy != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.ProcessedBy);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.ProcessedBy));
                }
                Assert.IsNotNull(labSheetTubeMPNDetailRet.SampleType);
                if (labSheetTubeMPNDetailRet.SiteComment != null)
                {
                   Assert.IsNotNull(labSheetTubeMPNDetailRet.SiteComment);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.SiteComment));
                }
                Assert.IsNotNull(labSheetTubeMPNDetailRet.LastUpdateDate_UTC);
                Assert.IsNotNull(labSheetTubeMPNDetailRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(labSheetTubeMPNDetailRet.MWQMSiteTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.MWQMSiteTVText));
                Assert.IsNotNull(labSheetTubeMPNDetailRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LastUpdateContactTVText));
                Assert.IsNotNull(labSheetTubeMPNDetailRet.SampleTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.SampleTypeText));
            }
        }
        #endregion Tests Get With Key

    }
}
