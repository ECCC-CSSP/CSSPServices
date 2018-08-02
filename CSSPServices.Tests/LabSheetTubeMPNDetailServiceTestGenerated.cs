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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheetTubeMPNDetail_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = )]
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

        #region Tests Generated for GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID)
        [TestMethod]
        public void GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID__labSheetTubeMPNDetail_LabSheetTubeMPNDetailID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in labSheetTubeMPNDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetTubeMPNDetail);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetTubeMPNDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                            Assert.IsNull(labSheetTubeMPNDetailRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(new List<LabSheetTubeMPNDetail>() { labSheetTubeMPNDetailRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID)

        #region Tests Generated for GetLabSheetTubeMPNDetailList()
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in labSheetTubeMPNDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetTubeMPNDetail);

                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetTubeMPNDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList()

        #region Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(1, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take

        #region Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1,  "LabSheetTubeMPNDetailID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(1, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order

        #region Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take 2Order
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1, "LabSheetTubeMPNDetailID,LabSheetDetailID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ThenBy(c => c.LabSheetDetailID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(1, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take 2Order

        #region Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order Where
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetTubeMPNDetailID", "LabSheetTubeMPNDetailID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Where(c => c.LabSheetTubeMPNDetailID == 4).Skip(0).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(1, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order Where

        #region Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order 2Where
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetTubeMPNDetailID", "LabSheetTubeMPNDetailID,GT,2|LabSheetTubeMPNDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Where(c => c.LabSheetTubeMPNDetailID > 2 && c.LabSheetTubeMPNDetailID < 5).Skip(0).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(1, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() Skip Take Order 2Where

        #region Tests Generated for GetLabSheetTubeMPNDetailList() 2Where
        [TestMethod]
        public void GetLabSheetTubeMPNDetailList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 10000, "", "LabSheetTubeMPNDetailID,GT,2|LabSheetTubeMPNDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetTubeMPNDetailDirectQueryList = labSheetTubeMPNDetailService.GetRead().Where(c => c.LabSheetTubeMPNDetailID > 2 && c.LabSheetTubeMPNDetailID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            Assert.AreEqual(0, labSheetTubeMPNDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                        Assert.AreEqual(2, labSheetTubeMPNDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() 2Where

        #region Functions private
        private void CheckLabSheetTubeMPNDetailFields(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // LabSheetTubeMPNDetail fields
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].Ordinal);
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].MWQMSiteTVItemID);
            if (labSheetTubeMPNDetailList[0].SampleDateTime != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].SampleDateTime);
            }
            if (labSheetTubeMPNDetailList[0].MPN != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].MPN);
            }
            if (labSheetTubeMPNDetailList[0].Tube10 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].Tube10);
            }
            if (labSheetTubeMPNDetailList[0].Tube1_0 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].Tube1_0);
            }
            if (labSheetTubeMPNDetailList[0].Tube0_1 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].Tube0_1);
            }
            if (labSheetTubeMPNDetailList[0].Salinity != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].Salinity);
            }
            if (labSheetTubeMPNDetailList[0].Temperature != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].Temperature);
            }
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].ProcessedBy));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].SampleType);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].SiteComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].SiteComment));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // LabSheetTubeMPNDetailWeb and LabSheetTubeMPNDetailReport fields should be null here
                Assert.IsNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb);
                Assert.IsNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // LabSheetTubeMPNDetailWeb fields should not be null and LabSheetTubeMPNDetailReport fields should be null here
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.SampleTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.SampleTypeText));
                }
                Assert.IsNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // LabSheetTubeMPNDetailWeb and LabSheetTubeMPNDetailReport fields should NOT be null here
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.LastUpdateContactTVItemLanguage);
                if (labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.SampleTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailWeb.SampleTypeText));
                }
                if (labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailReport.LabSheetTubeMPNDetailReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailReport.LabSheetTubeMPNDetailReportTest));
                }
            }
        }
        private LabSheetTubeMPNDetail GetFilledRandomLabSheetTubeMPNDetail(string OmitPropName)
        {
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();

            if (OmitPropName != "LabSheetDetailID") labSheetTubeMPNDetail.LabSheetDetailID = 1;
            if (OmitPropName != "Ordinal") labSheetTubeMPNDetail.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "MWQMSiteTVItemID") labSheetTubeMPNDetail.MWQMSiteTVItemID = 40;
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
    }
}
