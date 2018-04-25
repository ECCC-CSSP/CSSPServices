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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new GetParam(), dbTestDB, ContactID);

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

                    Assert.AreEqual(labSheetTubeMPNDetailService.GetRead().Count(), labSheetTubeMPNDetailService.GetEdit().Count());

                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, labSheetTubeMPNDetailService.GetRead().Where(c => c == labSheetTubeMPNDetail).Any());
                    labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 10000000;
                    labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetTubeMPNDetail, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID, labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = Error)]
                    // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetDetailID = 0;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetDetail, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, labSheetTubeMPNDetail.LabSheetDetailID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // labSheetTubeMPNDetail.Ordinal   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Ordinal = -1;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Ordinal = 1001;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "MWQMSite"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.SampleDateTime = new DateTime(1979, 1, 1);
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetTubeMPNDetailSampleDateTime, "1980"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 10000000)]
                    // labSheetTubeMPNDetail.MPN   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MPN = 0;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MPN = 10000001;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube10 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube1_0 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube0_1 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40)]
                    // labSheetTubeMPNDetail.Salinity   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Salinity]

                    //Error: Type not implemented [Salinity]

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Salinity = -1.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Salinity = 41.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetTubeMPNDetail.Temperature   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Temperature]

                    //Error: Type not implemented [Temperature]

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Temperature = -11.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Temperature = 41.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetTubeMPNDetailProcessedBy, "10"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailSampleType), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetTubeMPNDetail.SiteComment   (String)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.SiteComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetTubeMPNDetailSiteComment, "250"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheetTubeMPNDetail.LabSheetTubeMPNDetailWeb   (LabSheetTubeMPNDetailWeb)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailWeb = null;
                    Assert.IsNull(labSheetTubeMPNDetail.LabSheetTubeMPNDetailWeb);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailWeb = new LabSheetTubeMPNDetailWeb();
                    Assert.IsNotNull(labSheetTubeMPNDetail.LabSheetTubeMPNDetailWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheetTubeMPNDetail.LabSheetTubeMPNDetailReport   (LabSheetTubeMPNDetailReport)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailReport = null;
                    Assert.IsNull(labSheetTubeMPNDetail.LabSheetTubeMPNDetailReport);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailReport = new LabSheetTubeMPNDetailReport();
                    Assert.IsNotNull(labSheetTubeMPNDetail.LabSheetTubeMPNDetailReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime();
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC, "1980"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "Contact"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetTubeMPNDetail.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetTubeMPNDetail.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new GetParam(), dbTestDB, ContactID);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in labSheetTubeMPNDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetTubeMPNDetail);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, getParam);
                            Assert.IsNull(labSheetTubeMPNDetailRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // LabSheetTubeMPNDetail fields
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
                            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.ProcessedBy));
                        }
                        Assert.IsNotNull(labSheetTubeMPNDetailRet.SampleType);
                        if (labSheetTubeMPNDetailRet.SiteComment != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.SiteComment));
                        }
                        Assert.IsNotNull(labSheetTubeMPNDetailRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(labSheetTubeMPNDetailRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // LabSheetTubeMPNDetailWeb and LabSheetTubeMPNDetailReport fields should be null here
                            Assert.IsNull(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb);
                            Assert.IsNull(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // LabSheetTubeMPNDetailWeb fields should not be null and LabSheetTubeMPNDetailReport fields should be null here
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.MWQMSiteTVText));
                            }
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.LastUpdateContactTVText));
                            }
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.SampleTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.SampleTypeText));
                            }
                            Assert.IsNull(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // LabSheetTubeMPNDetailWeb and LabSheetTubeMPNDetailReport fields should NOT be null here
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.MWQMSiteTVText));
                            }
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.LastUpdateContactTVText));
                            }
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.SampleTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailWeb.SampleTypeText));
                            }
                            if (labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailReport.LabSheetTubeMPNDetailReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailReport.LabSheetTubeMPNDetailReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of LabSheetTubeMPNDetail
        #endregion Tests Get List of LabSheetTubeMPNDetail

    }
}
