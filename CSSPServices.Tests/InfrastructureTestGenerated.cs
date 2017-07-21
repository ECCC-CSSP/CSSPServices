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
    public partial class InfrastructureTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int InfrastructureID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Infrastructure GetFilledRandomInfrastructure(string OmitPropName)
        {
            InfrastructureID += 1;

            Infrastructure infrastructure = new Infrastructure();

            if (OmitPropName != "InfrastructureID") infrastructure.InfrastructureID = InfrastructureID;
            if (OmitPropName != "InfrastructureTVItemID") infrastructure.InfrastructureTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "PrismID") infrastructure.PrismID = GetRandomInt(0, 100000);
            if (OmitPropName != "TPID") infrastructure.TPID = GetRandomInt(0, 100000);
            if (OmitPropName != "LSID") infrastructure.LSID = GetRandomInt(0, 100000);
            if (OmitPropName != "SiteID") infrastructure.SiteID = GetRandomInt(0, 100000);
            if (OmitPropName != "Site") infrastructure.Site = GetRandomInt(0, 100000);
            if (OmitPropName != "InfrastructureCategory") infrastructure.InfrastructureCategory = GetRandomString("", 1);
            if (OmitPropName != "InfrastructureType") infrastructure.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            if (OmitPropName != "FacilityType") infrastructure.FacilityType = (FacilityTypeEnum)GetRandomEnumType(typeof(FacilityTypeEnum));
            if (OmitPropName != "IsMechanicallyAerated") infrastructure.IsMechanicallyAerated = true;
            if (OmitPropName != "NumberOfCells") infrastructure.NumberOfCells = GetRandomInt(0, 10);
            if (OmitPropName != "NumberOfAeratedCells") infrastructure.NumberOfAeratedCells = GetRandomInt(0, 10);
            if (OmitPropName != "AerationType") infrastructure.AerationType = (AerationTypeEnum)GetRandomEnumType(typeof(AerationTypeEnum));
            if (OmitPropName != "PreliminaryTreatmentType") infrastructure.PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)GetRandomEnumType(typeof(PreliminaryTreatmentTypeEnum));
            if (OmitPropName != "PrimaryTreatmentType") infrastructure.PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)GetRandomEnumType(typeof(PrimaryTreatmentTypeEnum));
            if (OmitPropName != "SecondaryTreatmentType") infrastructure.SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)GetRandomEnumType(typeof(SecondaryTreatmentTypeEnum));
            if (OmitPropName != "TertiaryTreatmentType") infrastructure.TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)GetRandomEnumType(typeof(TertiaryTreatmentTypeEnum));
            if (OmitPropName != "TreatmentType") infrastructure.TreatmentType = (TreatmentTypeEnum)GetRandomEnumType(typeof(TreatmentTypeEnum));
            if (OmitPropName != "DisinfectionType") infrastructure.DisinfectionType = (DisinfectionTypeEnum)GetRandomEnumType(typeof(DisinfectionTypeEnum));
            if (OmitPropName != "CollectionSystemType") infrastructure.CollectionSystemType = (CollectionSystemTypeEnum)GetRandomEnumType(typeof(CollectionSystemTypeEnum));
            if (OmitPropName != "AlarmSystemType") infrastructure.AlarmSystemType = (AlarmSystemTypeEnum)GetRandomEnumType(typeof(AlarmSystemTypeEnum));
            if (OmitPropName != "DesignFlow_m3_day") infrastructure.DesignFlow_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "AverageFlow_m3_day") infrastructure.AverageFlow_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PeakFlow_m3_day") infrastructure.PeakFlow_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PopServed") infrastructure.PopServed = GetRandomInt(0, 1000000);
            if (OmitPropName != "CanOverflow") infrastructure.CanOverflow = true;
            if (OmitPropName != "PercFlowOfTotal") infrastructure.PercFlowOfTotal = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TimeOffset_hour") infrastructure.TimeOffset_hour = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TempCatchAllRemoveLater") infrastructure.TempCatchAllRemoveLater = GetRandomString("", 20);
            if (OmitPropName != "AverageDepth_m") infrastructure.AverageDepth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "NumberOfPorts") infrastructure.NumberOfPorts = GetRandomInt(1, 1000);
            if (OmitPropName != "PortDiameter_m") infrastructure.PortDiameter_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PortSpacing_m") infrastructure.PortSpacing_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PortElevation_m") infrastructure.PortElevation_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") infrastructure.VerticalAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "HorizontalAngle_deg") infrastructure.HorizontalAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DecayRate_per_day") infrastructure.DecayRate_per_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "NearFieldVelocity_m_s") infrastructure.NearFieldVelocity_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FarFieldVelocity_m_s") infrastructure.FarFieldVelocity_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ReceivingWaterSalinity_PSU") infrastructure.ReceivingWaterSalinity_PSU = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ReceivingWaterTemperature_C") infrastructure.ReceivingWaterTemperature_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ReceivingWater_MPN_per_100ml") infrastructure.ReceivingWater_MPN_per_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "DistanceFromShore_m") infrastructure.DistanceFromShore_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SeeOtherTVItemID") infrastructure.SeeOtherTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "CivicAddressTVItemID") infrastructure.CivicAddressTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LastUpdateDate_UTC") infrastructure.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructure.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return infrastructure;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Infrastructure_Testing()
        {
            SetupTestHelper(culture);
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            Infrastructure infrastructure = GetFilledRandomInfrastructure("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(true, infrastructureService.GetRead().Where(c => c == infrastructure).Any());
            infrastructure.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, infrastructureService.Update(infrastructure));
            Assert.AreEqual(1, infrastructureService.GetRead().Count());
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [InfrastructureType]

            //Error: Type not implemented [FacilityType]

            //Error: Type not implemented [AerationType]

            //Error: Type not implemented [PreliminaryTreatmentType]

            //Error: Type not implemented [PrimaryTreatmentType]

            //Error: Type not implemented [SecondaryTreatmentType]

            //Error: Type not implemented [TertiaryTreatmentType]

            //Error: Type not implemented [TreatmentType]

            //Error: Type not implemented [DisinfectionType]

            //Error: Type not implemented [CollectionSystemType]

            //Error: Type not implemented [AlarmSystemType]

            //Error: Type not implemented [DesignFlow_m3_day]

            //Error: Type not implemented [AverageFlow_m3_day]

            //Error: Type not implemented [PeakFlow_m3_day]

            //Error: Type not implemented [PercFlowOfTotal]

            //Error: Type not implemented [TimeOffset_hour]

            //Error: Type not implemented [AverageDepth_m]

            //Error: Type not implemented [PortDiameter_m]

            //Error: Type not implemented [PortSpacing_m]

            //Error: Type not implemented [PortElevation_m]

            //Error: Type not implemented [VerticalAngle_deg]

            //Error: Type not implemented [HorizontalAngle_deg]

            //Error: Type not implemented [DecayRate_per_day]

            //Error: Type not implemented [NearFieldVelocity_m_s]

            //Error: Type not implemented [FarFieldVelocity_m_s]

            //Error: Type not implemented [ReceivingWaterSalinity_PSU]

            //Error: Type not implemented [ReceivingWaterTemperature_C]

            //Error: Type not implemented [DistanceFromShore_m]

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("LastUpdateDate_UTC");
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.AreEqual(1, infrastructure.ValidationResults.Count());
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLastUpdateDate_UTC)).Any());
            Assert.IsTrue(infrastructure.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [InfrastructureLanguages]

            //Error: Type not implemented [InfrastructureTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [InfrastructureID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PrismID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PrismID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.PrismID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.PrismID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.PrismID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.PrismID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.PrismID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.PrismID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.PrismID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.PrismID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [TPID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // TPID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.TPID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.TPID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.TPID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.TPID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.TPID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.TPID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.TPID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.TPID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [LSID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // LSID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.LSID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.LSID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.LSID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.LSID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.LSID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.LSID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.LSID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.LSID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [SiteID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // SiteID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.SiteID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.SiteID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.SiteID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.SiteID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.SiteID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.SiteID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.SiteID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.SiteID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [Site] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // Site has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.Site = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.Site = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.Site = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.Site);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.Site = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.Site = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.Site = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.Site);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [InfrastructureCategory] of type [String]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            //-----------------------------------
            // doing property [InfrastructureType] of type [InfrastructureTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FacilityType] of type [FacilityTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsMechanicallyAerated] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfCells] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfCells has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.NumberOfCells = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.NumberOfCells = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.NumberOfCells = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10")).Any());
            Assert.AreEqual(-1, infrastructure.NumberOfCells);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.NumberOfCells = 10;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.NumberOfCells = 9;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.NumberOfCells = 11;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10")).Any());
            Assert.AreEqual(11, infrastructure.NumberOfCells);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfAeratedCells] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.NumberOfAeratedCells = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.NumberOfAeratedCells = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.NumberOfAeratedCells = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10")).Any());
            Assert.AreEqual(-1, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.NumberOfAeratedCells = 10;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.NumberOfAeratedCells = 9;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.NumberOfAeratedCells = 11;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10")).Any());
            Assert.AreEqual(11, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [AerationType] of type [AerationTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [PreliminaryTreatmentType] of type [PreliminaryTreatmentTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [PrimaryTreatmentType] of type [PrimaryTreatmentTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SecondaryTreatmentType] of type [SecondaryTreatmentTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TertiaryTreatmentType] of type [TertiaryTreatmentTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TreatmentType] of type [TreatmentTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [DisinfectionType] of type [DisinfectionTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [CollectionSystemType] of type [CollectionSystemTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [AlarmSystemType] of type [AlarmSystemTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [DesignFlow_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [AverageFlow_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PeakFlow_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PopServed] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PopServed has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.PopServed = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.PopServed = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.PopServed = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000")).Any());
            Assert.AreEqual(-1, infrastructure.PopServed);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.PopServed = 1000000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.PopServed = 999999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.PopServed = 1000001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000")).Any());
            Assert.AreEqual(1000001, infrastructure.PopServed);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [CanOverflow] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [PercFlowOfTotal] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TempCatchAllRemoveLater] of type [String]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            //-----------------------------------
            // doing property [AverageDepth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfPorts] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfPorts has Min [1] and Max [1000]. At Min should return true and no errors
            infrastructure.NumberOfPorts = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.NumberOfPorts = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.NumberOfPorts = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000")).Any());
            Assert.AreEqual(0, infrastructure.NumberOfPorts);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max should return true and no errors
            infrastructure.NumberOfPorts = 1000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.NumberOfPorts = 999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.NumberOfPorts = 1001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000")).Any());
            Assert.AreEqual(1001, infrastructure.NumberOfPorts);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PortDiameter_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PortSpacing_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PortElevation_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [VerticalAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HorizontalAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DecayRate_per_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [NearFieldVelocity_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FarFieldVelocity_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ReceivingWaterSalinity_PSU] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ReceivingWaterTemperature_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ReceivingWater_MPN_per_100ml] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 10000000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10000000, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 9999999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9999999, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = 10000001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [DistanceFromShore_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SeeOtherTVItemID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.SeeOtherTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.SeeOtherTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.SeeOtherTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureSeeOtherTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [CivicAddressTVItemID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.CivicAddressTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.CivicAddressTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.CivicAddressTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureCivicAddressTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [InfrastructureLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
