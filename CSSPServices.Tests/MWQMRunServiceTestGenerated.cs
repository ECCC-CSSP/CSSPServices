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
    public partial class MWQMRunServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMRunService mwqmRunService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunServiceTest() : base()
        {
            //mwqmRunService = new MWQMRunService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMRun_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMRun mwqmRun = GetFilledRandomMWQMRun("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmRunService.GetMWQMRunList().Count();

                    Assert.AreEqual(mwqmRunService.GetMWQMRunList().Count(), (from c in dbTestDB.MWQMRuns select c).Take(200).Count());

                    mwqmRunService.Add(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmRunService.GetMWQMRunList().Where(c => c == mwqmRun).Any());
                    mwqmRunService.Update(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRunService.Delete(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmRun.MWQMRunID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunID = 0;
                    mwqmRunService.Update(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunMWQMRunID"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunID = 10000000;
                    mwqmRunService.Update(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunMWQMRunID", mwqmRun.MWQMRunID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // mwqmRun.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SubsectorTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunSubsectorTVItemID", mwqmRun.SubsectorTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SubsectorTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunSubsectorTVItemID", "Subsector"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // mwqmRun.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunMWQMRunTVItemID", mwqmRun.MWQMRunTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunMWQMRunTVItemID", "MWQMRun"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRun.RunSampleType   (SampleTypeEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunSampleType = (SampleTypeEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunRunSampleType"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.DateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DateTime_Local = new DateTime();
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunDateTime_Local"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // mwqmRun.RunNumber   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunNumber = 0;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRunNumber", "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunNumber = 1001;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRunNumber", "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.StartDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunStartDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // mwqmRun.EndDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.EndDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunEndDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabReceivedDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabReceivedDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabReceivedDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // mwqmRun.TemperatureControl1_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TemperatureControl1_C]

                    //Error: Type not implemented [TemperatureControl1_C]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl1_C = -11.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl1_C", "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl1_C = 41.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl1_C", "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // mwqmRun.TemperatureControl2_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TemperatureControl2_C]

                    //Error: Type not implemented [TemperatureControl2_C]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl2_C = -11.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl2_C", "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl2_C = 41.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl2_C", "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SeaStateAtStart_BeaufortScale   (BeaufortScaleEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSeaStateAtStart_BeaufortScale"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SeaStateAtEnd_BeaufortScale   (BeaufortScaleEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSeaStateAtEnd_BeaufortScale"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaterLevelAtBrook_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaterLevelAtBrook_m]

                    //Error: Type not implemented [WaterLevelAtBrook_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaterLevelAtBrook_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaterLevelAtBrook_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaterLevelAtBrook_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaterLevelAtBrook_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaveHightAtStart_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaveHightAtStart_m]

                    //Error: Type not implemented [WaveHightAtStart_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtStart_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtStart_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtStart_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtStart_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaveHightAtEnd_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaveHightAtEnd_m]

                    //Error: Type not implemented [WaveHightAtEnd_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtEnd_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtEnd_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtEnd_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtEnd_m", "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // mwqmRun.SampleCrewInitials   (String)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleCrewInitials = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMRunSampleCrewInitials", "20"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.AnalyzeMethod   (AnalyzeMethodEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunAnalyzeMethod"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SampleMatrix   (SampleMatrixEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleMatrix = (SampleMatrixEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSampleMatrix"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Laboratory   (LaboratoryEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Laboratory = (LaboratoryEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLaboratory"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SampleStatus   (SampleStatusEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleStatus = (SampleStatusEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSampleStatus"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRun.LabSampleApprovalContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabSampleApprovalContactTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLabSampleApprovalContactTVItemID", mwqmRun.LabSampleApprovalContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabSampleApprovalContactTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLabSampleApprovalContactTVItemID", "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabRunSampleApprovalDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabRunSampleApprovalDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabRunSampleApprovalDateTime_Local", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Tide_Start   (TideTextEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Tide_Start = (TideTextEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunTide_Start"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Tide_End   (TideTextEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Tide_End = (TideTextEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunTide_End"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay0_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay0_mm]

                    //Error: Type not implemented [RainDay0_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay0_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay0_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay0_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay0_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay1_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay1_mm]

                    //Error: Type not implemented [RainDay1_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay1_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay1_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay1_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay1_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay2_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay2_mm]

                    //Error: Type not implemented [RainDay2_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay2_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay2_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay2_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay2_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay3_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay3_mm]

                    //Error: Type not implemented [RainDay3_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay3_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay3_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay3_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay3_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay4_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay4_mm]

                    //Error: Type not implemented [RainDay4_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay4_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay4_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay4_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay4_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay5_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay5_mm]

                    //Error: Type not implemented [RainDay5_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay5_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay5_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay5_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay5_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay6_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay6_mm]

                    //Error: Type not implemented [RainDay6_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay6_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay6_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay6_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay6_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay7_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay7_mm]

                    //Error: Type not implemented [RainDay7_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay7_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay7_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay7_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay7_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay8_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay8_mm]

                    //Error: Type not implemented [RainDay8_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay8_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay8_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay8_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay8_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay9_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay9_mm]

                    //Error: Type not implemented [RainDay9_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay9_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay9_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay9_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay9_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay10_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay10_mm]

                    //Error: Type not implemented [RainDay10_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay10_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay10_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay10_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay10_mm", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.DischargeDay0_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay0_m3_s]

                    //Error: Type not implemented [DischargeDay0_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay0_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay0_m3_s", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay0_m3_s = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay0_m3_s", "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay1_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay1_m3_s]

                    //Error: Type not implemented [DischargeDay1_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay1_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay1_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay1_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay1_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay2_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay2_m3_s]

                    //Error: Type not implemented [DischargeDay2_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay2_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay2_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay2_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay2_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay3_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay3_m3_s]

                    //Error: Type not implemented [DischargeDay3_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay3_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay3_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay3_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay3_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay4_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay4_m3_s]

                    //Error: Type not implemented [DischargeDay4_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay4_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay4_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay4_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay4_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay5_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay5_m3_s]

                    //Error: Type not implemented [DischargeDay5_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay5_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay5_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay5_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay5_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay6_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay6_m3_s]

                    //Error: Type not implemented [DischargeDay6_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay6_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay6_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay6_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay6_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay7_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay7_m3_s]

                    //Error: Type not implemented [DischargeDay7_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay7_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay7_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay7_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay7_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay8_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay8_m3_s]

                    //Error: Type not implemented [DischargeDay8_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay8_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay8_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay8_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay8_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay9_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay9_m3_s]

                    //Error: Type not implemented [DischargeDay9_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay9_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay9_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay9_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay9_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // mwqmRun.DischargeDay10_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeDay10_m3_s]

                    //Error: Type not implemented [DischargeDay10_m3_s]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay10_m3_s = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay10_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.DischargeDay10_m3_s = 100001.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunDischargeDay10_m3_s", "0", "100000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetMWQMRunList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // mwqmRun.RemoveFromStat   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateDate_UTC = new DateTime();
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLastUpdateDate_UTC"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLastUpdateDate_UTC", "1980"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRun.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateContactTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLastUpdateContactTVItemID", mwqmRun.LastUpdateContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateContactTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLastUpdateContactTVItemID", "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRun.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRun.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID)
        [TestMethod]
        public void GetMWQMRunWithMWQMRunID__mwqmRun_MWQMRunID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRun mwqmRun = (from c in dbTestDB.MWQMRuns select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRun);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmRunService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MWQMRun mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID);
                            CheckMWQMRunFields(new List<MWQMRun>() { mwqmRunRet });
                            Assert.AreEqual(mwqmRun.MWQMRunID, mwqmRunRet.MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            MWQMRun_A mwqmRun_ARet = mwqmRunService.GetMWQMRun_AWithMWQMRunID(mwqmRun.MWQMRunID);
                            CheckMWQMRun_AFields(new List<MWQMRun_A>() { mwqmRun_ARet });
                            Assert.AreEqual(mwqmRun.MWQMRunID, mwqmRun_ARet.MWQMRunID);
                        }
                        else if (detail == "B")
                        {
                            MWQMRun_B mwqmRun_BRet = mwqmRunService.GetMWQMRun_BWithMWQMRunID(mwqmRun.MWQMRunID);
                            CheckMWQMRun_BFields(new List<MWQMRun_B>() { mwqmRun_BRet });
                            Assert.AreEqual(mwqmRun.MWQMRunID, mwqmRun_BRet.MWQMRunID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID)

        #region Tests Generated for GetMWQMRunList()
        [TestMethod]
        public void GetMWQMRunList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMRun mwqmRun = (from c in dbTestDB.MWQMRuns select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRun);

                    List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                    mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmRunService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList()

        #region Tests Generated for GetMWQMRunList() Skip Take
        [TestMethod]
        public void GetMWQMRunList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() Skip Take

        #region Tests Generated for GetMWQMRunList() Skip Take Order
        [TestMethod]
        public void GetMWQMRunList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMRunID", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Skip(1).Take(1).OrderBy(c => c.MWQMRunID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() Skip Take Order

        #region Tests Generated for GetMWQMRunList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMRunList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 1, 1, "MWQMRunID,SubsectorTVItemID", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Skip(1).Take(1).OrderBy(c => c.MWQMRunID).ThenBy(c => c.SubsectorTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() Skip Take 2Order

        #region Tests Generated for GetMWQMRunList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMRunList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunID", "MWQMRunID,EQ,4", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Where(c => c.MWQMRunID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMRunID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() Skip Take Order Where

        #region Tests Generated for GetMWQMRunList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMRunList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 0, 1, "MWQMRunID", "MWQMRunID,GT,2|MWQMRunID,LT,5", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Where(c => c.MWQMRunID > 2 && c.MWQMRunID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMRunID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMRunList() 2Where
        [TestMethod]
        public void GetMWQMRunList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMRunService mwqmRunService = new MWQMRunService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmRunService.Query = mwqmRunService.FillQuery(typeof(MWQMRun), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMRunID,GT,2|MWQMRunID,LT,5", "");

                        List<MWQMRun> mwqmRunDirectQueryList = new List<MWQMRun>();
                        mwqmRunDirectQueryList = (from c in dbTestDB.MWQMRuns select c).Where(c => c.MWQMRunID > 2 && c.MWQMRunID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMRun> mwqmRunList = new List<MWQMRun>();
                            mwqmRunList = mwqmRunService.GetMWQMRunList().ToList();
                            CheckMWQMRunFields(mwqmRunList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRunList[0].MWQMRunID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMRun_A> mwqmRun_AList = new List<MWQMRun_A>();
                            mwqmRun_AList = mwqmRunService.GetMWQMRun_AList().ToList();
                            CheckMWQMRun_AFields(mwqmRun_AList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_AList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMRun_B> mwqmRun_BList = new List<MWQMRun_B>();
                            mwqmRun_BList = mwqmRunService.GetMWQMRun_BList().ToList();
                            CheckMWQMRun_BFields(mwqmRun_BList);
                            Assert.AreEqual(mwqmRunDirectQueryList[0].MWQMRunID, mwqmRun_BList[0].MWQMRunID);
                            Assert.AreEqual(mwqmRunDirectQueryList.Count, mwqmRun_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMRunList() 2Where

        #region Functions private
        private void CheckMWQMRunFields(List<MWQMRun> mwqmRunList)
        {
            Assert.IsNotNull(mwqmRunList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRunList[0].SubsectorTVItemID);
            Assert.IsNotNull(mwqmRunList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmRunList[0].RunSampleType);
            Assert.IsNotNull(mwqmRunList[0].DateTime_Local);
            Assert.IsNotNull(mwqmRunList[0].RunNumber);
            if (mwqmRunList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].StartDateTime_Local);
            }
            if (mwqmRunList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].EndDateTime_Local);
            }
            if (mwqmRunList[0].LabReceivedDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabReceivedDateTime_Local);
            }
            if (mwqmRunList[0].TemperatureControl1_C != null)
            {
                Assert.IsNotNull(mwqmRunList[0].TemperatureControl1_C);
            }
            if (mwqmRunList[0].TemperatureControl2_C != null)
            {
                Assert.IsNotNull(mwqmRunList[0].TemperatureControl2_C);
            }
            if (mwqmRunList[0].SeaStateAtStart_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRunList[0].SeaStateAtStart_BeaufortScale);
            }
            if (mwqmRunList[0].SeaStateAtEnd_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRunList[0].SeaStateAtEnd_BeaufortScale);
            }
            if (mwqmRunList[0].WaterLevelAtBrook_m != null)
            {
                Assert.IsNotNull(mwqmRunList[0].WaterLevelAtBrook_m);
            }
            if (mwqmRunList[0].WaveHightAtStart_m != null)
            {
                Assert.IsNotNull(mwqmRunList[0].WaveHightAtStart_m);
            }
            if (mwqmRunList[0].WaveHightAtEnd_m != null)
            {
                Assert.IsNotNull(mwqmRunList[0].WaveHightAtEnd_m);
            }
            if (!string.IsNullOrWhiteSpace(mwqmRunList[0].SampleCrewInitials))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunList[0].SampleCrewInitials));
            }
            if (mwqmRunList[0].AnalyzeMethod != null)
            {
                Assert.IsNotNull(mwqmRunList[0].AnalyzeMethod);
            }
            if (mwqmRunList[0].SampleMatrix != null)
            {
                Assert.IsNotNull(mwqmRunList[0].SampleMatrix);
            }
            if (mwqmRunList[0].Laboratory != null)
            {
                Assert.IsNotNull(mwqmRunList[0].Laboratory);
            }
            if (mwqmRunList[0].SampleStatus != null)
            {
                Assert.IsNotNull(mwqmRunList[0].SampleStatus);
            }
            if (mwqmRunList[0].LabSampleApprovalContactTVItemID != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabSampleApprovalContactTVItemID);
            }
            if (mwqmRunList[0].LabAnalyzeBath1IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabAnalyzeBath1IncubationStartDateTime_Local);
            }
            if (mwqmRunList[0].LabAnalyzeBath2IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabAnalyzeBath2IncubationStartDateTime_Local);
            }
            if (mwqmRunList[0].LabAnalyzeBath3IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabAnalyzeBath3IncubationStartDateTime_Local);
            }
            if (mwqmRunList[0].LabRunSampleApprovalDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRunList[0].LabRunSampleApprovalDateTime_Local);
            }
            if (mwqmRunList[0].Tide_Start != null)
            {
                Assert.IsNotNull(mwqmRunList[0].Tide_Start);
            }
            if (mwqmRunList[0].Tide_End != null)
            {
                Assert.IsNotNull(mwqmRunList[0].Tide_End);
            }
            if (mwqmRunList[0].RainDay0_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay0_mm);
            }
            if (mwqmRunList[0].RainDay1_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay1_mm);
            }
            if (mwqmRunList[0].RainDay2_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay2_mm);
            }
            if (mwqmRunList[0].RainDay3_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay3_mm);
            }
            if (mwqmRunList[0].RainDay4_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay4_mm);
            }
            if (mwqmRunList[0].RainDay5_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay5_mm);
            }
            if (mwqmRunList[0].RainDay6_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay6_mm);
            }
            if (mwqmRunList[0].RainDay7_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay7_mm);
            }
            if (mwqmRunList[0].RainDay8_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay8_mm);
            }
            if (mwqmRunList[0].RainDay9_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay9_mm);
            }
            if (mwqmRunList[0].RainDay10_mm != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RainDay10_mm);
            }
            if (mwqmRunList[0].DischargeDay0_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay0_m3_s);
            }
            if (mwqmRunList[0].DischargeDay1_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay1_m3_s);
            }
            if (mwqmRunList[0].DischargeDay2_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay2_m3_s);
            }
            if (mwqmRunList[0].DischargeDay3_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay3_m3_s);
            }
            if (mwqmRunList[0].DischargeDay4_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay4_m3_s);
            }
            if (mwqmRunList[0].DischargeDay5_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay5_m3_s);
            }
            if (mwqmRunList[0].DischargeDay6_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay6_m3_s);
            }
            if (mwqmRunList[0].DischargeDay7_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay7_m3_s);
            }
            if (mwqmRunList[0].DischargeDay8_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay8_m3_s);
            }
            if (mwqmRunList[0].DischargeDay9_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay9_m3_s);
            }
            if (mwqmRunList[0].DischargeDay10_m3_s != null)
            {
                Assert.IsNotNull(mwqmRunList[0].DischargeDay10_m3_s);
            }
            if (mwqmRunList[0].RemoveFromStat != null)
            {
                Assert.IsNotNull(mwqmRunList[0].RemoveFromStat);
            }
            Assert.IsNotNull(mwqmRunList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRunList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRunList[0].HasErrors);
        }
        private void CheckMWQMRun_AFields(List<MWQMRun_A> mwqmRun_AList)
        {
            Assert.IsNotNull(mwqmRun_AList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(mwqmRun_AList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(mwqmRun_AList[0].LabSampleApprovalContactTVItemLanguage);
            Assert.IsNotNull(mwqmRun_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].RunSampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].RunSampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].SeaStateAtStart_BeaufortScaleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].SeaStateAtStart_BeaufortScaleText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].SeaStateAtEnd_BeaufortScaleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].SeaStateAtEnd_BeaufortScaleText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].AnalyzeMethodText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].AnalyzeMethodText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleMatrixText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleMatrixText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].LaboratoryText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].LaboratoryText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleStatusText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].Tide_StartText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].Tide_StartText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].Tide_EndText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].Tide_EndText));
            }
            Assert.IsNotNull(mwqmRun_AList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRun_AList[0].SubsectorTVItemID);
            Assert.IsNotNull(mwqmRun_AList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmRun_AList[0].RunSampleType);
            Assert.IsNotNull(mwqmRun_AList[0].DateTime_Local);
            Assert.IsNotNull(mwqmRun_AList[0].RunNumber);
            if (mwqmRun_AList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].StartDateTime_Local);
            }
            if (mwqmRun_AList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].EndDateTime_Local);
            }
            if (mwqmRun_AList[0].LabReceivedDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabReceivedDateTime_Local);
            }
            if (mwqmRun_AList[0].TemperatureControl1_C != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].TemperatureControl1_C);
            }
            if (mwqmRun_AList[0].TemperatureControl2_C != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].TemperatureControl2_C);
            }
            if (mwqmRun_AList[0].SeaStateAtStart_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].SeaStateAtStart_BeaufortScale);
            }
            if (mwqmRun_AList[0].SeaStateAtEnd_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].SeaStateAtEnd_BeaufortScale);
            }
            if (mwqmRun_AList[0].WaterLevelAtBrook_m != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].WaterLevelAtBrook_m);
            }
            if (mwqmRun_AList[0].WaveHightAtStart_m != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].WaveHightAtStart_m);
            }
            if (mwqmRun_AList[0].WaveHightAtEnd_m != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].WaveHightAtEnd_m);
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleCrewInitials))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_AList[0].SampleCrewInitials));
            }
            if (mwqmRun_AList[0].AnalyzeMethod != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].AnalyzeMethod);
            }
            if (mwqmRun_AList[0].SampleMatrix != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].SampleMatrix);
            }
            if (mwqmRun_AList[0].Laboratory != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].Laboratory);
            }
            if (mwqmRun_AList[0].SampleStatus != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].SampleStatus);
            }
            if (mwqmRun_AList[0].LabSampleApprovalContactTVItemID != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabSampleApprovalContactTVItemID);
            }
            if (mwqmRun_AList[0].LabAnalyzeBath1IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabAnalyzeBath1IncubationStartDateTime_Local);
            }
            if (mwqmRun_AList[0].LabAnalyzeBath2IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabAnalyzeBath2IncubationStartDateTime_Local);
            }
            if (mwqmRun_AList[0].LabAnalyzeBath3IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabAnalyzeBath3IncubationStartDateTime_Local);
            }
            if (mwqmRun_AList[0].LabRunSampleApprovalDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].LabRunSampleApprovalDateTime_Local);
            }
            if (mwqmRun_AList[0].Tide_Start != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].Tide_Start);
            }
            if (mwqmRun_AList[0].Tide_End != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].Tide_End);
            }
            if (mwqmRun_AList[0].RainDay0_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay0_mm);
            }
            if (mwqmRun_AList[0].RainDay1_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay1_mm);
            }
            if (mwqmRun_AList[0].RainDay2_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay2_mm);
            }
            if (mwqmRun_AList[0].RainDay3_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay3_mm);
            }
            if (mwqmRun_AList[0].RainDay4_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay4_mm);
            }
            if (mwqmRun_AList[0].RainDay5_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay5_mm);
            }
            if (mwqmRun_AList[0].RainDay6_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay6_mm);
            }
            if (mwqmRun_AList[0].RainDay7_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay7_mm);
            }
            if (mwqmRun_AList[0].RainDay8_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay8_mm);
            }
            if (mwqmRun_AList[0].RainDay9_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay9_mm);
            }
            if (mwqmRun_AList[0].RainDay10_mm != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RainDay10_mm);
            }
            if (mwqmRun_AList[0].DischargeDay0_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay0_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay1_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay1_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay2_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay2_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay3_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay3_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay4_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay4_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay5_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay5_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay6_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay6_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay7_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay7_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay8_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay8_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay9_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay9_m3_s);
            }
            if (mwqmRun_AList[0].DischargeDay10_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].DischargeDay10_m3_s);
            }
            if (mwqmRun_AList[0].RemoveFromStat != null)
            {
                Assert.IsNotNull(mwqmRun_AList[0].RemoveFromStat);
            }
            Assert.IsNotNull(mwqmRun_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRun_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRun_AList[0].HasErrors);
        }
        private void CheckMWQMRun_BFields(List<MWQMRun_B> mwqmRun_BList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].MWQMRunReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].MWQMRunReportTest));
            }
            Assert.IsNotNull(mwqmRun_BList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(mwqmRun_BList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(mwqmRun_BList[0].LabSampleApprovalContactTVItemLanguage);
            Assert.IsNotNull(mwqmRun_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].RunSampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].RunSampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].SeaStateAtStart_BeaufortScaleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].SeaStateAtStart_BeaufortScaleText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].SeaStateAtEnd_BeaufortScaleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].SeaStateAtEnd_BeaufortScaleText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].AnalyzeMethodText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].AnalyzeMethodText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleMatrixText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleMatrixText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].LaboratoryText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].LaboratoryText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleStatusText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].Tide_StartText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].Tide_StartText));
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].Tide_EndText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].Tide_EndText));
            }
            Assert.IsNotNull(mwqmRun_BList[0].MWQMRunID);
            Assert.IsNotNull(mwqmRun_BList[0].SubsectorTVItemID);
            Assert.IsNotNull(mwqmRun_BList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmRun_BList[0].RunSampleType);
            Assert.IsNotNull(mwqmRun_BList[0].DateTime_Local);
            Assert.IsNotNull(mwqmRun_BList[0].RunNumber);
            if (mwqmRun_BList[0].StartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].StartDateTime_Local);
            }
            if (mwqmRun_BList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].EndDateTime_Local);
            }
            if (mwqmRun_BList[0].LabReceivedDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabReceivedDateTime_Local);
            }
            if (mwqmRun_BList[0].TemperatureControl1_C != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].TemperatureControl1_C);
            }
            if (mwqmRun_BList[0].TemperatureControl2_C != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].TemperatureControl2_C);
            }
            if (mwqmRun_BList[0].SeaStateAtStart_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].SeaStateAtStart_BeaufortScale);
            }
            if (mwqmRun_BList[0].SeaStateAtEnd_BeaufortScale != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].SeaStateAtEnd_BeaufortScale);
            }
            if (mwqmRun_BList[0].WaterLevelAtBrook_m != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].WaterLevelAtBrook_m);
            }
            if (mwqmRun_BList[0].WaveHightAtStart_m != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].WaveHightAtStart_m);
            }
            if (mwqmRun_BList[0].WaveHightAtEnd_m != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].WaveHightAtEnd_m);
            }
            if (!string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleCrewInitials))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRun_BList[0].SampleCrewInitials));
            }
            if (mwqmRun_BList[0].AnalyzeMethod != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].AnalyzeMethod);
            }
            if (mwqmRun_BList[0].SampleMatrix != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].SampleMatrix);
            }
            if (mwqmRun_BList[0].Laboratory != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].Laboratory);
            }
            if (mwqmRun_BList[0].SampleStatus != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].SampleStatus);
            }
            if (mwqmRun_BList[0].LabSampleApprovalContactTVItemID != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabSampleApprovalContactTVItemID);
            }
            if (mwqmRun_BList[0].LabAnalyzeBath1IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabAnalyzeBath1IncubationStartDateTime_Local);
            }
            if (mwqmRun_BList[0].LabAnalyzeBath2IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabAnalyzeBath2IncubationStartDateTime_Local);
            }
            if (mwqmRun_BList[0].LabAnalyzeBath3IncubationStartDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabAnalyzeBath3IncubationStartDateTime_Local);
            }
            if (mwqmRun_BList[0].LabRunSampleApprovalDateTime_Local != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].LabRunSampleApprovalDateTime_Local);
            }
            if (mwqmRun_BList[0].Tide_Start != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].Tide_Start);
            }
            if (mwqmRun_BList[0].Tide_End != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].Tide_End);
            }
            if (mwqmRun_BList[0].RainDay0_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay0_mm);
            }
            if (mwqmRun_BList[0].RainDay1_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay1_mm);
            }
            if (mwqmRun_BList[0].RainDay2_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay2_mm);
            }
            if (mwqmRun_BList[0].RainDay3_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay3_mm);
            }
            if (mwqmRun_BList[0].RainDay4_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay4_mm);
            }
            if (mwqmRun_BList[0].RainDay5_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay5_mm);
            }
            if (mwqmRun_BList[0].RainDay6_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay6_mm);
            }
            if (mwqmRun_BList[0].RainDay7_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay7_mm);
            }
            if (mwqmRun_BList[0].RainDay8_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay8_mm);
            }
            if (mwqmRun_BList[0].RainDay9_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay9_mm);
            }
            if (mwqmRun_BList[0].RainDay10_mm != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RainDay10_mm);
            }
            if (mwqmRun_BList[0].DischargeDay0_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay0_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay1_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay1_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay2_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay2_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay3_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay3_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay4_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay4_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay5_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay5_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay6_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay6_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay7_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay7_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay8_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay8_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay9_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay9_m3_s);
            }
            if (mwqmRun_BList[0].DischargeDay10_m3_s != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].DischargeDay10_m3_s);
            }
            if (mwqmRun_BList[0].RemoveFromStat != null)
            {
                Assert.IsNotNull(mwqmRun_BList[0].RemoveFromStat);
            }
            Assert.IsNotNull(mwqmRun_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmRun_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmRun_BList[0].HasErrors);
        }
        private MWQMRun GetFilledRandomMWQMRun(string OmitPropName)
        {
            MWQMRun mwqmRun = new MWQMRun();

            if (OmitPropName != "SubsectorTVItemID") mwqmRun.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") mwqmRun.MWQMRunTVItemID = 49;
            if (OmitPropName != "RunSampleType") mwqmRun.RunSampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "DateTime_Local") mwqmRun.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "RunNumber") mwqmRun.RunNumber = GetRandomInt(1, 1000);
            if (OmitPropName != "StartDateTime_Local") mwqmRun.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") mwqmRun.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "LabReceivedDateTime_Local") mwqmRun.LabReceivedDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TemperatureControl1_C") mwqmRun.TemperatureControl1_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TemperatureControl2_C") mwqmRun.TemperatureControl2_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SeaStateAtStart_BeaufortScale") mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "SeaStateAtEnd_BeaufortScale") mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "WaterLevelAtBrook_m") mwqmRun.WaterLevelAtBrook_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtStart_m") mwqmRun.WaveHightAtStart_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtEnd_m") mwqmRun.WaveHightAtEnd_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "SampleCrewInitials") mwqmRun.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "AnalyzeMethod") mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrix") mwqmRun.SampleMatrix = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "Laboratory") mwqmRun.Laboratory = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "SampleStatus") mwqmRun.SampleStatus = (SampleStatusEnum)GetRandomEnumType(typeof(SampleStatusEnum));
            if (OmitPropName != "LabSampleApprovalContactTVItemID") mwqmRun.LabSampleApprovalContactTVItemID = 2;
            if (OmitPropName != "LabAnalyzeBath1IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabAnalyzeBath2IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabAnalyzeBath3IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "LabRunSampleApprovalDateTime_Local") mwqmRun.LabRunSampleApprovalDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Tide_Start") mwqmRun.Tide_Start = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "Tide_End") mwqmRun.Tide_End = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "RainDay0_mm") mwqmRun.RainDay0_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay1_mm") mwqmRun.RainDay1_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay2_mm") mwqmRun.RainDay2_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay3_mm") mwqmRun.RainDay3_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay4_mm") mwqmRun.RainDay4_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay5_mm") mwqmRun.RainDay5_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay6_mm") mwqmRun.RainDay6_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay7_mm") mwqmRun.RainDay7_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay8_mm") mwqmRun.RainDay8_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay9_mm") mwqmRun.RainDay9_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay10_mm") mwqmRun.RainDay10_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "DischargeDay0_m3_s") mwqmRun.DischargeDay0_m3_s = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "DischargeDay1_m3_s") mwqmRun.DischargeDay1_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay2_m3_s") mwqmRun.DischargeDay2_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay3_m3_s") mwqmRun.DischargeDay3_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay4_m3_s") mwqmRun.DischargeDay4_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay5_m3_s") mwqmRun.DischargeDay5_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay6_m3_s") mwqmRun.DischargeDay6_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay7_m3_s") mwqmRun.DischargeDay7_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay8_m3_s") mwqmRun.DischargeDay8_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay9_m3_s") mwqmRun.DischargeDay9_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeDay10_m3_s") mwqmRun.DischargeDay10_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RemoveFromStat") mwqmRun.RemoveFromStat = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = 2;

            return mwqmRun;
        }
        #endregion Functions private
    }
}
