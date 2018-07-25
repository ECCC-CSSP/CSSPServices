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
    public partial class LabSheetDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetDetailService labSheetDetailService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailServiceTest() : base()
        {
            //labSheetDetailService = new LabSheetDetailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheetDetail_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LabSheetDetail labSheetDetail = GetFilledRandomLabSheetDetail("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = labSheetDetailService.GetRead().Count();

                    Assert.AreEqual(labSheetDetailService.GetRead().Count(), labSheetDetailService.GetEdit().Count());

                    labSheetDetailService.Add(labSheetDetail);
                    if (labSheetDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, labSheetDetailService.GetRead().Where(c => c == labSheetDetail).Any());
                    labSheetDetailService.Update(labSheetDetail);
                    if (labSheetDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, labSheetDetailService.GetRead().Count());
                    labSheetDetailService.Delete(labSheetDetail);
                    if (labSheetDetail.HasErrors)
                    {
                        Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // labSheetDetail.LabSheetDetailID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailID = 0;
                    labSheetDetailService.Update(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailLabSheetDetailID), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailID = 10000000;
                    labSheetDetailService.Update(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetDetail, CSSPModelsRes.LabSheetDetailLabSheetDetailID, labSheetDetail.LabSheetDetailID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "LabSheet", ExistPlurial = "s", ExistFieldID = "LabSheetID", AllowableTVtypeList = Error)]
                    // labSheetDetail.LabSheetID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheet, CSSPModelsRes.LabSheetDetailLabSheetID, labSheetDetail.LabSheetID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                    // labSheetDetail.SamplingPlanID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SamplingPlanID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.LabSheetDetailSamplingPlanID, labSheetDetail.SamplingPlanID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // labSheetDetail.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SubsectorTVItemID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetDetailSubsectorTVItemID, labSheetDetail.SubsectorTVItemID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SubsectorTVItemID = 1;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetDetailSubsectorTVItemID, "Subsector"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 5)]
                    // labSheetDetail.Version   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Version = 0;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailVersion, "1", "5"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Version = 6;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailVersion, "1", "5"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.RunDate   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunDate = new DateTime();
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailRunDate), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunDate = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailRunDate, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(7, MinimumLength = 1)]
                    // labSheetDetail.Tides   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("Tides");
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
                    Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailTides)).Any());
                    Assert.AreEqual(null, labSheetDetail.Tides);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Tides = GetRandomString("", 8);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTides, "1", "7"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SampleCrewInitials   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SampleCrewInitials = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSampleCrewInitials, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 3)]
                    // labSheetDetail.WaterBathCount   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBathCount = 0;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailWaterBathCount, "1", "3"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBathCount = 4;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailWaterBathCount, "1", "3"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath1StartTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1StartTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath1StartTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath2StartTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2StartTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath2StartTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath3StartTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3StartTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath3StartTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath1EndTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1EndTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath1EndTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath2EndTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2EndTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath2EndTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath3EndTime   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3EndTime = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath3EndTime, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath1TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath2TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath3TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath1   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath1 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath1, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath2   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath2 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath2, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath3   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath3 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath3, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCField1   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCField1]

                    //Error: Type not implemented [TCField1]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField1 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField1 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCLab1   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCLab1]

                    //Error: Type not implemented [TCLab1]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab1 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab1 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCField2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCField2]

                    //Error: Type not implemented [TCField2]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField2 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField2 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCLab2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCLab2]

                    //Error: Type not implemented [TCLab2]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab2 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab2 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCFirst   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCFirst]

                    //Error: Type not implemented [TCFirst]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCFirst = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCFirst, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCFirst = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCFirst, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCAverage   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCAverage]

                    //Error: Type not implemented [TCAverage]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCAverage = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCAverage, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCAverage = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCAverage, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(100))]
                    // labSheetDetail.ControlLot   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ControlLot = GetRandomString("", 101);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailControlLot, "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Positive35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Positive35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailPositive35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.NonTarget35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.NonTarget35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailNonTarget35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Negative35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Negative35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailNegative35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Blank35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Blank35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBlank35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.Lot35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Lot35 = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailLot35, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.Lot44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Lot44_5 = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailLot44_5, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.Weather   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Weather = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWeather, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.RunComment   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailRunComment, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.RunWeatherComment   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunWeatherComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailRunWeatherComment, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SampleBottleLotNumber   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SampleBottleLotNumber = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSampleBottleLotNumber, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SalinitiesReadBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SalinitiesReadBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSalinitiesReadBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.SalinitiesReadDate   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SalinitiesReadDate = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailSalinitiesReadDate, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.ResultsReadBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsReadBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailResultsReadBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.ResultsReadDate   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsReadDate = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailResultsReadDate, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.ResultsRecordedBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsRecordedBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailResultsRecordedBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.ResultsRecordedDate   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsRecordedDate = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailResultsRecordedDate, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.DailyDuplicateRLog   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DailyDuplicateRLog]

                    //Error: Type not implemented [DailyDuplicateRLog]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicateRLog = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicateRLog = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.DailyDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                    //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.DailyDuplicateAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.IntertechDuplicateRLog   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [IntertechDuplicateRLog]

                    //Error: Type not implemented [IntertechDuplicateRLog]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicateRLog = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicateRLog = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.IntertechDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                    //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.IntertechDuplicateAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.IntertechReadAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheetDetail.LabSheetDetailWeb   (LabSheetDetailWeb)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailWeb = null;
                    Assert.IsNull(labSheetDetail.LabSheetDetailWeb);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailWeb = new LabSheetDetailWeb();
                    Assert.IsNotNull(labSheetDetail.LabSheetDetailWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // labSheetDetail.LabSheetDetailReport   (LabSheetDetailReport)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailReport = null;
                    Assert.IsNull(labSheetDetail.LabSheetDetailReport);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailReport = new LabSheetDetailReport();
                    Assert.IsNotNull(labSheetDetail.LabSheetDetailReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateDate_UTC = new DateTime();
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailLastUpdateDate_UTC), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailLastUpdateDate_UTC, "1980"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheetDetail.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateContactTVItemID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetDetailLastUpdateContactTVItemID, labSheetDetail.LastUpdateContactTVItemID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateContactTVItemID = 1;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetDetailLastUpdateContactTVItemID, "Contact"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetDetail.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetDetail.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID)
        [TestMethod]
        public void GetLabSheetDetailWithLabSheetDetailID__labSheetDetail_LabSheetDetailID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheetDetail labSheetDetail = (from c in labSheetDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetDetail);

                    LabSheetDetail labSheetDetailRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID);
                            Assert.IsNull(labSheetDetailRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(new List<LabSheetDetail>() { labSheetDetailRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID)

        #region Tests Generated for GetLabSheetDetailList()
        [TestMethod]
        public void GetLabSheetDetailList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheetDetail labSheetDetail = (from c in labSheetDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetDetail);

                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetDetailService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList()

        #region Tests Generated for GetLabSheetDetailList() Skip Take
        [TestMethod]
        public void GetLabSheetDetailList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(1, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() Skip Take

        #region Tests Generated for GetLabSheetDetailList() Skip Take Order
        [TestMethod]
        public void GetLabSheetDetailList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 1, 1,  "LabSheetDetailID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetDetailID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(1, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() Skip Take Order

        #region Tests Generated for GetLabSheetDetailList() Skip Take 2Order
        [TestMethod]
        public void GetLabSheetDetailList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 1, 1, "LabSheetDetailID,LabSheetID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetDetailID).ThenBy(c => c.LabSheetID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(1, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() Skip Take 2Order

        #region Tests Generated for GetLabSheetDetailList() Skip Take Order Where
        [TestMethod]
        public void GetLabSheetDetailList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetDetailID", "LabSheetDetailID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Where(c => c.LabSheetDetailID == 4).Skip(0).Take(1).OrderBy(c => c.LabSheetDetailID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(1, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() Skip Take Order Where

        #region Tests Generated for GetLabSheetDetailList() Skip Take Order 2Where
        [TestMethod]
        public void GetLabSheetDetailList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetDetailID", "LabSheetDetailID,GT,2|LabSheetDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Where(c => c.LabSheetDetailID > 2 && c.LabSheetDetailID < 5).Skip(0).Take(1).OrderBy(c => c.LabSheetDetailID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(1, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() Skip Take Order 2Where

        #region Tests Generated for GetLabSheetDetailList() 2Where
        [TestMethod]
        public void GetLabSheetDetailList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    List<LabSheetDetail> labSheetDetailDirectQueryList = new List<LabSheetDetail>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetDetailService.Query = labSheetDetailService.FillQuery(typeof(LabSheetDetail), culture.TwoLetterISOLanguageName, 0, 10000, "", "LabSheetDetailID,GT,2|LabSheetDetailID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        labSheetDetailDirectQueryList = labSheetDetailService.GetRead().Where(c => c.LabSheetDetailID > 2 && c.LabSheetDetailID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                            Assert.AreEqual(0, labSheetDetailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            labSheetDetailList = labSheetDetailService.GetLabSheetDetailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckLabSheetDetailFields(labSheetDetailList, entityQueryDetailType);
                        Assert.AreEqual(labSheetDetailDirectQueryList[0].LabSheetDetailID, labSheetDetailList[0].LabSheetDetailID);
                        Assert.AreEqual(2, labSheetDetailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetDetailList() 2Where

        #region Functions private
        private void CheckLabSheetDetailFields(List<LabSheetDetail> labSheetDetailList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // LabSheetDetail fields
            Assert.IsNotNull(labSheetDetailList[0].LabSheetDetailID);
            Assert.IsNotNull(labSheetDetailList[0].LabSheetID);
            Assert.IsNotNull(labSheetDetailList[0].SamplingPlanID);
            Assert.IsNotNull(labSheetDetailList[0].SubsectorTVItemID);
            Assert.IsNotNull(labSheetDetailList[0].Version);
            Assert.IsNotNull(labSheetDetailList[0].RunDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Tides));
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].SampleCrewInitials))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].SampleCrewInitials));
            }
            if (labSheetDetailList[0].WaterBathCount != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].WaterBathCount);
            }
            if (labSheetDetailList[0].IncubationBath1StartTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath1StartTime);
            }
            if (labSheetDetailList[0].IncubationBath2StartTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath2StartTime);
            }
            if (labSheetDetailList[0].IncubationBath3StartTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath3StartTime);
            }
            if (labSheetDetailList[0].IncubationBath1EndTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath1EndTime);
            }
            if (labSheetDetailList[0].IncubationBath2EndTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath2EndTime);
            }
            if (labSheetDetailList[0].IncubationBath3EndTime != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath3EndTime);
            }
            if (labSheetDetailList[0].IncubationBath1TimeCalculated_minutes != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath1TimeCalculated_minutes);
            }
            if (labSheetDetailList[0].IncubationBath2TimeCalculated_minutes != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath2TimeCalculated_minutes);
            }
            if (labSheetDetailList[0].IncubationBath3TimeCalculated_minutes != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IncubationBath3TimeCalculated_minutes);
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath1))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath1));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath2))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath2));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath3))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].WaterBath3));
            }
            if (labSheetDetailList[0].TCField1 != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCField1);
            }
            if (labSheetDetailList[0].TCLab1 != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCLab1);
            }
            if (labSheetDetailList[0].TCField2 != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCField2);
            }
            if (labSheetDetailList[0].TCLab2 != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCLab2);
            }
            if (labSheetDetailList[0].TCFirst != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCFirst);
            }
            if (labSheetDetailList[0].TCAverage != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].TCAverage);
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].ControlLot))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].ControlLot));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Positive35))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Positive35));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].NonTarget35))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].NonTarget35));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Negative35))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Negative35));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Positive44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Positive44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Positive44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Positive44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Positive44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Positive44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1NonTarget44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1NonTarget44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2NonTarget44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2NonTarget44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3NonTarget44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3NonTarget44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Negative44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Negative44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Negative44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Negative44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Negative44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Negative44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Blank35))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Blank35));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Blank44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath1Blank44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Blank44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath2Blank44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Blank44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Bath3Blank44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Lot35))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Lot35));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Lot44_5))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Lot44_5));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].Weather))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].Weather));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].RunComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].RunComment));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].RunWeatherComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].RunWeatherComment));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].SampleBottleLotNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].SampleBottleLotNumber));
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].SalinitiesReadBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].SalinitiesReadBy));
            }
            if (labSheetDetailList[0].SalinitiesReadDate != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].SalinitiesReadDate);
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].ResultsReadBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].ResultsReadBy));
            }
            if (labSheetDetailList[0].ResultsReadDate != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].ResultsReadDate);
            }
            if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].ResultsRecordedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].ResultsRecordedBy));
            }
            if (labSheetDetailList[0].ResultsRecordedDate != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].ResultsRecordedDate);
            }
            if (labSheetDetailList[0].DailyDuplicateRLog != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].DailyDuplicateRLog);
            }
            if (labSheetDetailList[0].DailyDuplicatePrecisionCriteria != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].DailyDuplicatePrecisionCriteria);
            }
            if (labSheetDetailList[0].DailyDuplicateAcceptable != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].DailyDuplicateAcceptable);
            }
            if (labSheetDetailList[0].IntertechDuplicateRLog != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IntertechDuplicateRLog);
            }
            if (labSheetDetailList[0].IntertechDuplicatePrecisionCriteria != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IntertechDuplicatePrecisionCriteria);
            }
            if (labSheetDetailList[0].IntertechDuplicateAcceptable != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IntertechDuplicateAcceptable);
            }
            if (labSheetDetailList[0].IntertechReadAcceptable != null)
            {
                Assert.IsNotNull(labSheetDetailList[0].IntertechReadAcceptable);
            }
            Assert.IsNotNull(labSheetDetailList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetDetailList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // LabSheetDetailWeb and LabSheetDetailReport fields should be null here
                Assert.IsNull(labSheetDetailList[0].LabSheetDetailWeb);
                Assert.IsNull(labSheetDetailList[0].LabSheetDetailReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // LabSheetDetailWeb fields should not be null and LabSheetDetailReport fields should be null here
                if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.SubsectorTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.SubsectorTVText));
                }
                if (!string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(labSheetDetailList[0].LabSheetDetailReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // LabSheetDetailWeb and LabSheetDetailReport fields should NOT be null here
                if (labSheetDetailList[0].LabSheetDetailWeb.SubsectorTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.SubsectorTVText));
                }
                if (labSheetDetailList[0].LabSheetDetailWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailWeb.LastUpdateContactTVText));
                }
                if (labSheetDetailList[0].LabSheetDetailReport.LabSheetDetailReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailList[0].LabSheetDetailReport.LabSheetDetailReportTest));
                }
            }
        }
        private LabSheetDetail GetFilledRandomLabSheetDetail(string OmitPropName)
        {
            LabSheetDetail labSheetDetail = new LabSheetDetail();

            if (OmitPropName != "LabSheetID") labSheetDetail.LabSheetID = 1;
            if (OmitPropName != "SamplingPlanID") labSheetDetail.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") labSheetDetail.SubsectorTVItemID = 11;
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 5);
            if (OmitPropName != "RunDate") labSheetDetail.RunDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "Tides") labSheetDetail.Tides = GetRandomString("", 6);
            if (OmitPropName != "SampleCrewInitials") labSheetDetail.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "WaterBathCount") labSheetDetail.WaterBathCount = GetRandomInt(1, 3);
            if (OmitPropName != "IncubationBath1StartTime") labSheetDetail.IncubationBath1StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2StartTime") labSheetDetail.IncubationBath2StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3StartTime") labSheetDetail.IncubationBath3StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath1EndTime") labSheetDetail.IncubationBath1EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2EndTime") labSheetDetail.IncubationBath2EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3EndTime") labSheetDetail.IncubationBath3EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath1TimeCalculated_minutes") labSheetDetail.IncubationBath1TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath2TimeCalculated_minutes") labSheetDetail.IncubationBath2TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath3TimeCalculated_minutes") labSheetDetail.IncubationBath3TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "WaterBath1") labSheetDetail.WaterBath1 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath2") labSheetDetail.WaterBath2 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath3") labSheetDetail.WaterBath3 = GetRandomString("", 5);
            if (OmitPropName != "TCField1") labSheetDetail.TCField1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab1") labSheetDetail.TCLab1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCField2") labSheetDetail.TCField2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab2") labSheetDetail.TCLab2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCFirst") labSheetDetail.TCFirst = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCAverage") labSheetDetail.TCAverage = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ControlLot") labSheetDetail.ControlLot = GetRandomString("", 5);
            if (OmitPropName != "Positive35") labSheetDetail.Positive35 = GetRandomString("", 1);
            if (OmitPropName != "NonTarget35") labSheetDetail.NonTarget35 = GetRandomString("", 1);
            if (OmitPropName != "Negative35") labSheetDetail.Negative35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Positive44_5") labSheetDetail.Bath1Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Positive44_5") labSheetDetail.Bath2Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Positive44_5") labSheetDetail.Bath3Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1NonTarget44_5") labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2NonTarget44_5") labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3NonTarget44_5") labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Negative44_5") labSheetDetail.Bath1Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Negative44_5") labSheetDetail.Bath2Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Negative44_5") labSheetDetail.Bath3Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Blank35") labSheetDetail.Blank35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Blank44_5") labSheetDetail.Bath1Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Blank44_5") labSheetDetail.Bath2Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Blank44_5") labSheetDetail.Bath3Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Lot35") labSheetDetail.Lot35 = GetRandomString("", 5);
            if (OmitPropName != "Lot44_5") labSheetDetail.Lot44_5 = GetRandomString("", 5);
            if (OmitPropName != "Weather") labSheetDetail.Weather = GetRandomString("", 5);
            if (OmitPropName != "RunComment") labSheetDetail.RunComment = GetRandomString("", 5);
            if (OmitPropName != "RunWeatherComment") labSheetDetail.RunWeatherComment = GetRandomString("", 5);
            if (OmitPropName != "SampleBottleLotNumber") labSheetDetail.SampleBottleLotNumber = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadBy") labSheetDetail.SalinitiesReadBy = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadDate") labSheetDetail.SalinitiesReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsReadBy") labSheetDetail.ResultsReadBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsReadDate") labSheetDetail.ResultsReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsRecordedBy") labSheetDetail.ResultsRecordedBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsRecordedDate") labSheetDetail.ResultsRecordedDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyDuplicateRLog") labSheetDetail.DailyDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRLog") labSheetDetail.IntertechDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicateAcceptable") labSheetDetail.IntertechDuplicateAcceptable = true;
            if (OmitPropName != "IntertechReadAcceptable") labSheetDetail.IntertechReadAcceptable = true;
            if (OmitPropName != "LastUpdateDate_UTC") labSheetDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetDetail.LastUpdateContactTVItemID = 2;

            return labSheetDetail;
        }
        #endregion Functions private
    }
}
