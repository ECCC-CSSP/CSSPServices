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

                    count = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count();

                    Assert.AreEqual(labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count(), (from c in dbTestDB.LabSheetTubeMPNDetails select c).Take(200).Count());

                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Where(c => c == labSheetTubeMPNDetail).Any());
                    labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetailService.Delete(labSheetTubeMPNDetail);
                    if (labSheetTubeMPNDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailLabSheetTubeMPNDetailID"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 10000000;
                    labSheetTubeMPNDetailService.Update(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailLabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "LabSheetDetail", ExistPlurial = "s", ExistFieldID = "LabSheetDetailID", AllowableTVtypeList = )]
                    // labSheetTubeMPNDetail.LabSheetDetailID   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LabSheetDetailID = 0;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetTubeMPNDetailLabSheetDetailID", labSheetTubeMPNDetail.LabSheetDetailID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // labSheetTubeMPNDetail.Ordinal   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Ordinal = -1;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailOrdinal", "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Ordinal = 1001;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailOrdinal", "0", "1000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // labSheetTubeMPNDetail.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MWQMSiteTVItemID = 0;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetTubeMPNDetailMWQMSiteTVItemID", labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MWQMSiteTVItemID = 1;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetTubeMPNDetailMWQMSiteTVItemID", "MWQMSite"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetTubeMPNDetail.SampleDateTime   (DateTime)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.SampleDateTime = new DateTime(1979, 1, 1);
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetTubeMPNDetailSampleDateTime", "1980"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 10000000)]
                    // labSheetTubeMPNDetail.MPN   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MPN = 0;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailMPN", "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.MPN = 10000001;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailMPN", "1", "10000000"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // labSheetTubeMPNDetail.Tube10   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube10 = -1;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube10", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube10 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube10", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // labSheetTubeMPNDetail.Tube1_0   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube1_0 = -1;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube1_0", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube1_0 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube1_0", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // labSheetTubeMPNDetail.Tube0_1   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube0_1 = -1;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube0_1", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Tube0_1 = 6;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube0_1", "0", "5"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailSalinity", "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Salinity = 41.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailSalinity", "0", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTemperature", "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.Temperature = 41.0D;
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTemperature", "-10", "40"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetTubeMPNDetail.ProcessedBy   (String)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.ProcessedBy = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetTubeMPNDetailProcessedBy", "10"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheetTubeMPNDetail.SampleType   (SampleTypeEnum)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.SampleType = (SampleTypeEnum)1000000;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailSampleType"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetTubeMPNDetail.SiteComment   (String)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.SiteComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetTubeMPNDetailSiteComment", "250"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetTubeMPNDetail.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime();
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailLastUpdateDate_UTC"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetTubeMPNDetailLastUpdateDate_UTC", "1980"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheetTubeMPNDetail.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateContactTVItemID = 0;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetTubeMPNDetailLastUpdateContactTVItemID", labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetTubeMPNDetail = null;
                    labSheetTubeMPNDetail = GetFilledRandomLabSheetTubeMPNDetail("");
                    labSheetTubeMPNDetail.LastUpdateContactTVItemID = 1;
                    labSheetTubeMPNDetailService.Add(labSheetTubeMPNDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetTubeMPNDetailLastUpdateContactTVItemID", "Contact"), labSheetTubeMPNDetail.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbTestDB.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetTubeMPNDetail);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetTubeMPNDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                            CheckLabSheetTubeMPNDetailFields(new List<LabSheetTubeMPNDetail>() { labSheetTubeMPNDetailRet });
                            Assert.AreEqual(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            LabSheetTubeMPNDetailWeb labSheetTubeMPNDetailWebRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                            CheckLabSheetTubeMPNDetailWebFields(new List<LabSheetTubeMPNDetailWeb>() { labSheetTubeMPNDetailWebRet });
                            Assert.AreEqual(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebRet.LabSheetTubeMPNDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            LabSheetTubeMPNDetailReport labSheetTubeMPNDetailReportRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportWithLabSheetTubeMPNDetailID(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID);
                            CheckLabSheetTubeMPNDetailReportFields(new List<LabSheetTubeMPNDetailReport>() { labSheetTubeMPNDetailReportRet });
                            Assert.AreEqual(labSheetTubeMPNDetail.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportRet.LabSheetTubeMPNDetailID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in dbTestDB.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetTubeMPNDetail);

                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                    labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetTubeMPNDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1,  "LabSheetTubeMPNDetailID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Skip(1).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 1, 1, "LabSheetTubeMPNDetailID,LabSheetDetailID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Skip(1).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ThenBy(c => c.LabSheetDetailID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetTubeMPNDetailID", "LabSheetTubeMPNDetailID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID == 4).Skip(0).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetTubeMPNDetailID", "LabSheetTubeMPNDetailID,GT,2|LabSheetTubeMPNDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID > 2 && c.LabSheetTubeMPNDetailID < 5).Skip(0).Take(1).OrderBy(c => c.LabSheetTubeMPNDetailID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetTubeMPNDetailService.Query = labSheetTubeMPNDetailService.FillQuery(typeof(LabSheetTubeMPNDetail), culture.TwoLetterISOLanguageName, 0, 10000, "", "LabSheetTubeMPNDetailID,GT,2|LabSheetTubeMPNDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailDirectQueryList = new List<LabSheetTubeMPNDetail>();
                        labSheetTubeMPNDetailDirectQueryList = (from c in dbTestDB.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID > 2 && c.LabSheetTubeMPNDetailID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                            labSheetTubeMPNDetailList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList().ToList();
                            CheckLabSheetTubeMPNDetailFields(labSheetTubeMPNDetailList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList = new List<LabSheetTubeMPNDetailWeb>();
                            labSheetTubeMPNDetailWebList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWebList().ToList();
                            CheckLabSheetTubeMPNDetailWebFields(labSheetTubeMPNDetailWebList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList = new List<LabSheetTubeMPNDetailReport>();
                            labSheetTubeMPNDetailReportList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailReportList().ToList();
                            CheckLabSheetTubeMPNDetailReportFields(labSheetTubeMPNDetailReportList);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList[0].LabSheetTubeMPNDetailID, labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
                            Assert.AreEqual(labSheetTubeMPNDetailDirectQueryList.Count, labSheetTubeMPNDetailReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetTubeMPNDetailList() 2Where

        #region Functions private
        private void CheckLabSheetTubeMPNDetailFields(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
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
            Assert.IsNotNull(labSheetTubeMPNDetailList[0].HasErrors);
        }
        private void CheckLabSheetTubeMPNDetailWebFields(List<LabSheetTubeMPNDetailWeb> labSheetTubeMPNDetailWebList)
        {
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].SampleTypeText));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].LabSheetTubeMPNDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].LabSheetDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Ordinal);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].MWQMSiteTVItemID);
            if (labSheetTubeMPNDetailWebList[0].SampleDateTime != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].SampleDateTime);
            }
            if (labSheetTubeMPNDetailWebList[0].MPN != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].MPN);
            }
            if (labSheetTubeMPNDetailWebList[0].Tube10 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Tube10);
            }
            if (labSheetTubeMPNDetailWebList[0].Tube1_0 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Tube1_0);
            }
            if (labSheetTubeMPNDetailWebList[0].Tube0_1 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Tube0_1);
            }
            if (labSheetTubeMPNDetailWebList[0].Salinity != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Salinity);
            }
            if (labSheetTubeMPNDetailWebList[0].Temperature != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].Temperature);
            }
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].ProcessedBy));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].SampleType);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].SiteComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailWebList[0].SiteComment));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(labSheetTubeMPNDetailWebList[0].HasErrors);
        }
        private void CheckLabSheetTubeMPNDetailReportFields(List<LabSheetTubeMPNDetailReport> labSheetTubeMPNDetailReportList)
        {
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailReportTest));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].SampleTypeText));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].LabSheetTubeMPNDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].LabSheetDetailID);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Ordinal);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].MWQMSiteTVItemID);
            if (labSheetTubeMPNDetailReportList[0].SampleDateTime != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].SampleDateTime);
            }
            if (labSheetTubeMPNDetailReportList[0].MPN != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].MPN);
            }
            if (labSheetTubeMPNDetailReportList[0].Tube10 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Tube10);
            }
            if (labSheetTubeMPNDetailReportList[0].Tube1_0 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Tube1_0);
            }
            if (labSheetTubeMPNDetailReportList[0].Tube0_1 != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Tube0_1);
            }
            if (labSheetTubeMPNDetailReportList[0].Salinity != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Salinity);
            }
            if (labSheetTubeMPNDetailReportList[0].Temperature != null)
            {
                Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].Temperature);
            }
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].ProcessedBy));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].SampleType);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].SiteComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetTubeMPNDetailReportList[0].SiteComment));
            }
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(labSheetTubeMPNDetailReportList[0].HasErrors);
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
