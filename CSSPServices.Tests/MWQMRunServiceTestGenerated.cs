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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMRun GetFilledRandomMWQMRun(string OmitPropName)
        {
            MWQMRun mwqmRun = new MWQMRun();

            // Need to implement (no items found, would need to add at least one in the TestDB) [MWQMRun SubsectorTVItemID TVItem TVItemID]
            // Need to implement (no items found, would need to add at least one in the TestDB) [MWQMRun MWQMRunTVItemID TVItem TVItemID]
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
            if (OmitPropName != "RemoveFromStat") mwqmRun.RemoveFromStat = true;
            //Error: property [MWQMRunWeb] and type [MWQMRun] is  not implemented
            //Error: property [MWQMRunReport] and type [MWQMRun] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") mwqmRun.HasErrors = true;

            return mwqmRun;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMRun_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, dbTestDB, ContactID);

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

                    count = mwqmRunService.GetRead().Count();

                    Assert.AreEqual(mwqmRunService.GetRead().Count(), mwqmRunService.GetEdit().Count());

                    mwqmRunService.Add(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmRunService.GetRead().Where(c => c == mwqmRun).Any());
                    mwqmRunService.Update(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmRunService.GetRead().Count());
                    mwqmRunService.Delete(mwqmRun);
                    if (mwqmRun.HasErrors)
                    {
                        Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunMWQMRunID), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunID = 10000000;
                    mwqmRunService.Update(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRun, CSSPModelsRes.MWQMRunMWQMRunID, mwqmRun.MWQMRunID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // mwqmRun.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SubsectorTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunSubsectorTVItemID, mwqmRun.SubsectorTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SubsectorTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunSubsectorTVItemID, "Subsector"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // mwqmRun.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunMWQMRunTVItemID, mwqmRun.MWQMRunTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.MWQMRunTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunMWQMRunTVItemID, "MWQMRun"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmRun.RunSampleType   (SampleTypeEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunSampleType = (SampleTypeEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunRunSampleType), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.DateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // mwqmRun.RunNumber   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunNumber = 0;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRunNumber, "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RunNumber = 1001;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRunNumber, "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.StartDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // mwqmRun.EndDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabReceivedDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // mwqmRun.TemperatureControl1_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TemperatureControl1_C]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl1_C = -11.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl1_C = 41.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // mwqmRun.TemperatureControl2_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TemperatureControl2_C]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl2_C = -11.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.TemperatureControl2_C = 41.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SeaStateAtStart_BeaufortScale   (BeaufortScaleEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSeaStateAtStart_BeaufortScale), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SeaStateAtEnd_BeaufortScale   (BeaufortScaleEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaterLevelAtBrook_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaterLevelAtBrook_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaterLevelAtBrook_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaterLevelAtBrook_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaveHightAtStart_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaveHightAtStart_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtStart_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtStart_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mwqmRun.WaveHightAtEnd_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaveHightAtEnd_m]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtEnd_m = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.WaveHightAtEnd_m = 101.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // mwqmRun.SampleCrewInitials   (String)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleCrewInitials = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSampleCrewInitials, "20"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.AnalyzeMethod   (AnalyzeMethodEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunAnalyzeMethod), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SampleMatrix   (SampleMatrixEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleMatrix = (SampleMatrixEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSampleMatrix), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Laboratory   (LaboratoryEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Laboratory = (LaboratoryEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLaboratory), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.SampleStatus   (SampleStatusEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.SampleStatus = (SampleStatusEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSampleStatus), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRun.LabSampleApprovalContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabSampleApprovalContactTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLabSampleApprovalContactTVItemID, mwqmRun.LabSampleApprovalContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LabSampleApprovalContactTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LabRunSampleApprovalDateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Tide_Start   (TideTextEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Tide_Start = (TideTextEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunTide_Start), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmRun.Tide_End   (TideTextEnum)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.Tide_End = (TideTextEnum)1000000;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunTide_End), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay0_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay0_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay0_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay0_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay0_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay0_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay1_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay1_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay1_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay1_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay1_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay1_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay2_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay2_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay2_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay2_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay2_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay2_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay3_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay3_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay3_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay3_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay3_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay3_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay4_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay4_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay4_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay4_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay4_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay4_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay5_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay5_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay5_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay5_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay5_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay5_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay6_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay6_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay6_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay6_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay6_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay6_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay7_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay7_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay7_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay7_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay7_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay7_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay8_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay8_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay8_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay8_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay8_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay8_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay9_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay9_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay9_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay9_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay9_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay9_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // mwqmRun.RainDay10_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainDay10_mm]

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay10_mm = -1.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay10_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.RainDay10_mm = 301.0D;
                    Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay10_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // mwqmRun.RemoveFromStat   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmRun.MWQMRunWeb   (MWQMRunWeb)
                    // -----------------------------------

                    //Error: Type not implemented [MWQMRunWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmRun.MWQMRunReport   (MWQMRunReport)
                    // -----------------------------------

                    //Error: Type not implemented [MWQMRunReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmRun.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmRun.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateContactTVItemID = 0;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLastUpdateContactTVItemID, mwqmRun.LastUpdateContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmRun = null;
                    mwqmRun = GetFilledRandomMWQMRun("");
                    mwqmRun.LastUpdateContactTVItemID = 1;
                    mwqmRunService.Add(mwqmRun);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLastUpdateContactTVItemID, "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRun.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmRun.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMRun_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, dbTestDB, ContactID);
                    MWQMRun mwqmRun = (from c in mwqmRunService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmRun);

                    MWQMRun mwqmRunRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(mwqmRunRet.MWQMRunID);
                        Assert.IsNotNull(mwqmRunRet.SubsectorTVItemID);
                        Assert.IsNotNull(mwqmRunRet.MWQMRunTVItemID);
                        Assert.IsNotNull(mwqmRunRet.RunSampleType);
                        Assert.IsNotNull(mwqmRunRet.DateTime_Local);
                        Assert.IsNotNull(mwqmRunRet.RunNumber);
                        if (mwqmRunRet.StartDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.StartDateTime_Local);
                        }
                        if (mwqmRunRet.EndDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.EndDateTime_Local);
                        }
                        if (mwqmRunRet.LabReceivedDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabReceivedDateTime_Local);
                        }
                        if (mwqmRunRet.TemperatureControl1_C != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.TemperatureControl1_C);
                        }
                        if (mwqmRunRet.TemperatureControl2_C != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.TemperatureControl2_C);
                        }
                        if (mwqmRunRet.SeaStateAtStart_BeaufortScale != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.SeaStateAtStart_BeaufortScale);
                        }
                        if (mwqmRunRet.SeaStateAtEnd_BeaufortScale != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.SeaStateAtEnd_BeaufortScale);
                        }
                        if (mwqmRunRet.WaterLevelAtBrook_m != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.WaterLevelAtBrook_m);
                        }
                        if (mwqmRunRet.WaveHightAtStart_m != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.WaveHightAtStart_m);
                        }
                        if (mwqmRunRet.WaveHightAtEnd_m != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.WaveHightAtEnd_m);
                        }
                        if (mwqmRunRet.SampleCrewInitials != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmRunRet.SampleCrewInitials));
                        }
                        if (mwqmRunRet.AnalyzeMethod != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.AnalyzeMethod);
                        }
                        if (mwqmRunRet.SampleMatrix != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.SampleMatrix);
                        }
                        if (mwqmRunRet.Laboratory != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.Laboratory);
                        }
                        if (mwqmRunRet.SampleStatus != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.SampleStatus);
                        }
                        if (mwqmRunRet.LabSampleApprovalContactTVItemID != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabSampleApprovalContactTVItemID);
                        }
                        if (mwqmRunRet.LabAnalyzeBath1IncubationStartDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabAnalyzeBath1IncubationStartDateTime_Local);
                        }
                        if (mwqmRunRet.LabAnalyzeBath2IncubationStartDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabAnalyzeBath2IncubationStartDateTime_Local);
                        }
                        if (mwqmRunRet.LabAnalyzeBath3IncubationStartDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabAnalyzeBath3IncubationStartDateTime_Local);
                        }
                        if (mwqmRunRet.LabRunSampleApprovalDateTime_Local != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.LabRunSampleApprovalDateTime_Local);
                        }
                        if (mwqmRunRet.Tide_Start != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.Tide_Start);
                        }
                        if (mwqmRunRet.Tide_End != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.Tide_End);
                        }
                        if (mwqmRunRet.RainDay0_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay0_mm);
                        }
                        if (mwqmRunRet.RainDay1_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay1_mm);
                        }
                        if (mwqmRunRet.RainDay2_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay2_mm);
                        }
                        if (mwqmRunRet.RainDay3_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay3_mm);
                        }
                        if (mwqmRunRet.RainDay4_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay4_mm);
                        }
                        if (mwqmRunRet.RainDay5_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay5_mm);
                        }
                        if (mwqmRunRet.RainDay6_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay6_mm);
                        }
                        if (mwqmRunRet.RainDay7_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay7_mm);
                        }
                        if (mwqmRunRet.RainDay8_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay8_mm);
                        }
                        if (mwqmRunRet.RainDay9_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay9_mm);
                        }
                        if (mwqmRunRet.RainDay10_mm != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RainDay10_mm);
                        }
                        if (mwqmRunRet.RemoveFromStat != null)
                        {
                            Assert.IsNotNull(mwqmRunRet.RemoveFromStat);
                        }
                        Assert.IsNotNull(mwqmRunRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmRunRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (mwqmRunRet.MWQMRunWeb != null)
                            {
                                Assert.IsNull(mwqmRunRet.MWQMRunWeb);
                            }
                            if (mwqmRunRet.MWQMRunReport != null)
                            {
                                Assert.IsNull(mwqmRunRet.MWQMRunReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (mwqmRunRet.MWQMRunWeb != null)
                            {
                                Assert.IsNotNull(mwqmRunRet.MWQMRunWeb);
                            }
                            if (mwqmRunRet.MWQMRunReport != null)
                            {
                                Assert.IsNotNull(mwqmRunRet.MWQMRunReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MWQMRun
        #endregion Tests Get List of MWQMRun

    }
}
