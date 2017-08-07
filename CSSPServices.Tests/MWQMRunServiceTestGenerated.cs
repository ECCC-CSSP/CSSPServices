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

            if (OmitPropName != "SubsectorTVItemID") mwqmRun.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") mwqmRun.MWQMRunTVItemID = 24;
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
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "RunSampleTypeText") mwqmRun.RunSampleTypeText = GetRandomString("", 5);
            if (OmitPropName != "SeaStateAtStart_BeaufortScaleText") mwqmRun.SeaStateAtStart_BeaufortScaleText = GetRandomString("", 5);
            if (OmitPropName != "SeaStateAtEnd_BeaufortScaleText") mwqmRun.SeaStateAtEnd_BeaufortScaleText = GetRandomString("", 5);
            if (OmitPropName != "AnalyzeMethodText") mwqmRun.AnalyzeMethodText = GetRandomString("", 5);
            if (OmitPropName != "SampleMatrixText") mwqmRun.SampleMatrixText = GetRandomString("", 5);
            if (OmitPropName != "LaboratoryText") mwqmRun.LaboratoryText = GetRandomString("", 5);
            if (OmitPropName != "SampleStatusText") mwqmRun.SampleStatusText = GetRandomString("", 5);
            if (OmitPropName != "Tide_StartText") mwqmRun.Tide_StartText = GetRandomString("", 5);
            if (OmitPropName != "Tide_EndText") mwqmRun.Tide_EndText = GetRandomString("", 5);

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

                mwqmRunService.Add(mwqmRun);
                if (mwqmRun.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmRunService.GetRead().Where(c => c == mwqmRun).Any());
                mwqmRunService.Update(mwqmRun);
                if (mwqmRun.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmRunService.GetRead().Count());
                mwqmRunService.Delete(mwqmRun);
                if (mwqmRun.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunMWQMRunID), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                // mwqmRun.SubsectorTVItemID   (Int32)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SubsectorTVItemID = 0;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunSubsectorTVItemID, mwqmRun.SubsectorTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SubsectorTVItemID = 1;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunSubsectorTVItemID, "Subsector"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                // mwqmRun.MWQMRunTVItemID   (Int32)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.MWQMRunTVItemID = 0;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunMWQMRunTVItemID, mwqmRun.MWQMRunTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.MWQMRunTVItemID = 1;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunMWQMRunTVItemID, "MWQMRun"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // mwqmRun.RunSampleType   (SampleTypeEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RunSampleType = (SampleTypeEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunRunSampleType), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RunNumber = 1001;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.TemperatureControl1_C = 41.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.TemperatureControl2_C = 41.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSeaStateAtStart_BeaufortScale), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // mwqmRun.SeaStateAtEnd_BeaufortScale   (BeaufortScaleEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.WaterLevelAtBrook_m = 101.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.WaveHightAtStart_m = 101.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.WaveHightAtEnd_m = 101.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleCrewInitials, "20"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunAnalyzeMethod), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // mwqmRun.SampleMatrix   (SampleMatrixEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SampleMatrix = (SampleMatrixEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSampleMatrix), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // mwqmRun.Laboratory   (LaboratoryEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.Laboratory = (LaboratoryEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLaboratory), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // mwqmRun.SampleStatus   (SampleStatusEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SampleStatus = (SampleStatusEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSampleStatus), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmRun.LabSampleApprovalContactTVItemID   (Int32)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.LabSampleApprovalContactTVItemID = 0;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, mwqmRun.LabSampleApprovalContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.LabSampleApprovalContactTVItemID = 1;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunTide_Start), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // mwqmRun.Tide_End   (TideTextEnum)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.Tide_End = (TideTextEnum)1000000;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunTide_End), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay0_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay1_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay2_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay3_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay4_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay5_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay6_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay7_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay8_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay9_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());
                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RainDay10_mm = 301.0D;
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // mwqmRun.RemoveFromStat   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmRun.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmRun.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.LastUpdateContactTVItemID = 0;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLastUpdateContactTVItemID, mwqmRun.LastUpdateContactTVItemID.ToString()), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.LastUpdateContactTVItemID = 1;
                mwqmRunService.Add(mwqmRun);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "Contact"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.RunSampleTypeText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.RunSampleTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunRunSampleTypeText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.SeaStateAtStart_BeaufortScaleText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SeaStateAtStart_BeaufortScaleText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSeaStateAtStart_BeaufortScaleText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.SeaStateAtEnd_BeaufortScaleText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SeaStateAtEnd_BeaufortScaleText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSeaStateAtEnd_BeaufortScaleText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.AnalyzeMethodText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.AnalyzeMethodText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunAnalyzeMethodText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.SampleMatrixText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SampleMatrixText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleMatrixText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.LaboratoryText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.LaboratoryText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunLaboratoryText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.SampleStatusText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.SampleStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleStatusText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.Tide_StartText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.Tide_StartText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunTide_StartText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmRun.Tide_EndText   (String)
                // -----------------------------------

                mwqmRun = null;
                mwqmRun = GetFilledRandomMWQMRun("");
                mwqmRun.Tide_EndText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunTide_EndText, "100"), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmRunService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mwqmRun.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, dbTestDB, ContactID);

                MWQMRun mwqmRun = (from c in mwqmRunService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(mwqmRun);

                MWQMRun mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunID(mwqmRun.MWQMRunID);
                Assert.AreEqual(mwqmRun.MWQMRunID, mwqmRunRet.MWQMRunID);
            }
        }
        #endregion Tests Get With Key

    }
}
