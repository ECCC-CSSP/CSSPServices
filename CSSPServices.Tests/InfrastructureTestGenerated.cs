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
            if (OmitPropName != "PrismID") infrastructure.PrismID = GetRandomInt(1, 11);
            if (OmitPropName != "TPID") infrastructure.TPID = GetRandomInt(1, 11);
            if (OmitPropName != "LSID") infrastructure.LSID = GetRandomInt(1, 11);
            if (OmitPropName != "SiteID") infrastructure.SiteID = GetRandomInt(1, 11);
            if (OmitPropName != "Site") infrastructure.Site = GetRandomInt(1, 11);
            if (OmitPropName != "InfrastructureCategory") infrastructure.InfrastructureCategory = GetRandomString("", 6);
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
            if (OmitPropName != "DesignFlow_m3_day") infrastructure.DesignFlow_m3_day = GetRandomFloat(0, 1000000);
            if (OmitPropName != "AverageFlow_m3_day") infrastructure.AverageFlow_m3_day = GetRandomFloat(0, 1000000);
            if (OmitPropName != "PeakFlow_m3_day") infrastructure.PeakFlow_m3_day = GetRandomFloat(0, 1000000);
            if (OmitPropName != "PopServed") infrastructure.PopServed = GetRandomInt(0, 1000000);
            if (OmitPropName != "CanOverflow") infrastructure.CanOverflow = true;
            if (OmitPropName != "PercFlowOfTotal") infrastructure.PercFlowOfTotal = GetRandomFloat(0, 1000000);
            if (OmitPropName != "TimeOffset_hour") infrastructure.TimeOffset_hour = GetRandomFloat(-12, 12);
            if (OmitPropName != "TempCatchAllRemoveLater") infrastructure.TempCatchAllRemoveLater = GetRandomString("", 20);
            if (OmitPropName != "AverageDepth_m") infrastructure.AverageDepth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "NumberOfPorts") infrastructure.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortDiameter_m") infrastructure.PortDiameter_m = GetRandomFloat(0, 100);
            if (OmitPropName != "PortSpacing_m") infrastructure.PortSpacing_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "PortElevation_m") infrastructure.PortElevation_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "VerticalAngle_deg") infrastructure.VerticalAngle_deg = GetRandomFloat(-90, 90);
            if (OmitPropName != "HorizontalAngle_deg") infrastructure.HorizontalAngle_deg = GetRandomFloat(-180, 180);
            if (OmitPropName != "DecayRate_per_day") infrastructure.DecayRate_per_day = GetRandomFloat(0, 1000);
            if (OmitPropName != "NearFieldVelocity_m_s") infrastructure.NearFieldVelocity_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "FarFieldVelocity_m_s") infrastructure.FarFieldVelocity_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "ReceivingWaterSalinity_PSU") infrastructure.ReceivingWaterSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "ReceivingWaterTemperature_C") infrastructure.ReceivingWaterTemperature_C = GetRandomFloat(0, 40);
            if (OmitPropName != "ReceivingWater_MPN_per_100ml") infrastructure.ReceivingWater_MPN_per_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "DistanceFromShore_m") infrastructure.DistanceFromShore_m = GetRandomFloat(0, 10000);
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
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Infrastructure infrastructure = GetFilledRandomInfrastructure("");
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

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("LastUpdateDate_UTC");
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.AreEqual(1, infrastructure.ValidationResults.Count());
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLastUpdateDate_UTC)).Any());
            Assert.IsTrue(infrastructure.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [InfrastructureID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [int]
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
            // doing property [PrismID] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PrismID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.PrismID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.PrismID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PrismID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.PrismID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructurePrismID, "1")).Any());
            Assert.AreEqual(0, infrastructure.PrismID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [TPID] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // TPID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.TPID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.TPID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TPID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.TPID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureTPID, "1")).Any());
            Assert.AreEqual(0, infrastructure.TPID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [LSID] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // LSID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.LSID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.LSID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // LSID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.LSID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLSID, "1")).Any());
            Assert.AreEqual(0, infrastructure.LSID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [SiteID] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // SiteID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.SiteID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.SiteID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // SiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.SiteID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureSiteID, "1")).Any());
            Assert.AreEqual(0, infrastructure.SiteID);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [Site] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // Site has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.Site = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.Site = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // Site has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.Site = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureSite, "1")).Any());
            Assert.AreEqual(0, infrastructure.Site);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [InfrastructureCategory] of type [string]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            // InfrastructureCategory has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string infrastructureInfrastructureCategoryMin = GetRandomString("", 1);
            infrastructure.InfrastructureCategory = infrastructureInfrastructureCategoryMin;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(infrastructureInfrastructureCategoryMin, infrastructure.InfrastructureCategory);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            // InfrastructureCategory has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            infrastructureInfrastructureCategoryMin = GetRandomString("", 2);
            infrastructure.InfrastructureCategory = infrastructureInfrastructureCategoryMin;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(infrastructureInfrastructureCategoryMin, infrastructure.InfrastructureCategory);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [InfrastructureType] of type [InfrastructureTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FacilityType] of type [FacilityTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsMechanicallyAerated] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfCells] of type [int]
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
            // doing property [NumberOfAeratedCells] of type [int]
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
            // doing property [DesignFlow_m3_day] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.DesignFlow_m3_day = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.DesignFlow_m3_day = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.DesignFlow_m3_day = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.DesignFlow_m3_day = 1000000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.DesignFlow_m3_day = 999999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.DesignFlow_m3_day = 1000001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [AverageFlow_m3_day] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.AverageFlow_m3_day = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.AverageFlow_m3_day = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.AverageFlow_m3_day = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.AverageFlow_m3_day = 1000000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.AverageFlow_m3_day = 999999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.AverageFlow_m3_day = 1000001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PeakFlow_m3_day] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.PeakFlow_m3_day = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.PeakFlow_m3_day = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.PeakFlow_m3_day = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.PeakFlow_m3_day = 1000000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.PeakFlow_m3_day = 999999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.PeakFlow_m3_day = 1000001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PopServed] of type [int]
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
            // doing property [CanOverflow] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [PercFlowOfTotal] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.PercFlowOfTotal = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.PercFlowOfTotal = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.PercFlowOfTotal = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.PercFlowOfTotal = 1000000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.PercFlowOfTotal = 999999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.PercFlowOfTotal = 1000001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // TimeOffset_hour has Min [-12] and Max [12]. At Min should return true and no errors
            infrastructure.TimeOffset_hour = -12.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-12.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Min + 1 should return true and no errors
            infrastructure.TimeOffset_hour = -11.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-11.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Min - 1 should return false with one error
            infrastructure.TimeOffset_hour = -13.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-12", "12")).Any());
            Assert.AreEqual(-13.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max should return true and no errors
            infrastructure.TimeOffset_hour = 12.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(12.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max - 1 should return true and no errors
            infrastructure.TimeOffset_hour = 11.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(11.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max + 1 should return false with one error
            infrastructure.TimeOffset_hour = 13.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-12", "12")).Any());
            Assert.AreEqual(13.0f, infrastructure.TimeOffset_hour);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [TempCatchAllRemoveLater] of type [string]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            //-----------------------------------
            // doing property [AverageDepth_m] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // AverageDepth_m has Min [0] and Max [1000]. At Min should return true and no errors
            infrastructure.AverageDepth_m = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.AverageDepth_m = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.AverageDepth_m = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0] and Max [1000]. At Max should return true and no errors
            infrastructure.AverageDepth_m = 1000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.AverageDepth_m = 999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.AverageDepth_m = 1001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, infrastructure.AverageDepth_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfPorts] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfPorts has Min [1] and Max [100]. At Min should return true and no errors
            infrastructure.NumberOfPorts = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min + 1 should return true and no errors
            infrastructure.NumberOfPorts = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min - 1 should return false with one error
            infrastructure.NumberOfPorts = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(0, infrastructure.NumberOfPorts);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max should return true and no errors
            infrastructure.NumberOfPorts = 100;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max - 1 should return true and no errors
            infrastructure.NumberOfPorts = 99;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max + 1 should return false with one error
            infrastructure.NumberOfPorts = 101;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(101, infrastructure.NumberOfPorts);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PortDiameter_m] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortDiameter_m has Min [0] and Max [100]. At Min should return true and no errors
            infrastructure.PortDiameter_m = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Min + 1 should return true and no errors
            infrastructure.PortDiameter_m = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Min - 1 should return false with one error
            infrastructure.PortDiameter_m = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "100")).Any());
            Assert.AreEqual(-1.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max should return true and no errors
            infrastructure.PortDiameter_m = 100.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max - 1 should return true and no errors
            infrastructure.PortDiameter_m = 99.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max + 1 should return false with one error
            infrastructure.PortDiameter_m = 101.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "100")).Any());
            Assert.AreEqual(101.0f, infrastructure.PortDiameter_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PortSpacing_m] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortSpacing_m has Min [0] and Max [1000]. At Min should return true and no errors
            infrastructure.PortSpacing_m = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.PortSpacing_m = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.PortSpacing_m = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max should return true and no errors
            infrastructure.PortSpacing_m = 1000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.PortSpacing_m = 999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.PortSpacing_m = 1001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, infrastructure.PortSpacing_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [PortElevation_m] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortElevation_m has Min [0] and Max [1000]. At Min should return true and no errors
            infrastructure.PortElevation_m = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.PortElevation_m = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.PortElevation_m = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max should return true and no errors
            infrastructure.PortElevation_m = 1000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.PortElevation_m = 999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.PortElevation_m = 1001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, infrastructure.PortElevation_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [VerticalAngle_deg] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // VerticalAngle_deg has Min [-90] and Max [90]. At Min should return true and no errors
            infrastructure.VerticalAngle_deg = -90.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-90.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            infrastructure.VerticalAngle_deg = -89.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-89.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90] and Max [90]. At Min - 1 should return false with one error
            infrastructure.VerticalAngle_deg = -91.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90] and Max [90]. At Max should return true and no errors
            infrastructure.VerticalAngle_deg = 90.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(90.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            infrastructure.VerticalAngle_deg = 89.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(89.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90] and Max [90]. At Max + 1 should return false with one error
            infrastructure.VerticalAngle_deg = 91.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(91.0f, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [HorizontalAngle_deg] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min should return true and no errors
            infrastructure.HorizontalAngle_deg = -180.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-180.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            infrastructure.HorizontalAngle_deg = -179.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-179.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min - 1 should return false with one error
            infrastructure.HorizontalAngle_deg = -181.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max should return true and no errors
            infrastructure.HorizontalAngle_deg = 180.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(180.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            infrastructure.HorizontalAngle_deg = 179.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(179.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max + 1 should return false with one error
            infrastructure.HorizontalAngle_deg = 181.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0f, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayRate_per_day] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DecayRate_per_day has Min [0] and Max [1000]. At Min should return true and no errors
            infrastructure.DecayRate_per_day = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.DecayRate_per_day = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.DecayRate_per_day = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max should return true and no errors
            infrastructure.DecayRate_per_day = 1000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.DecayRate_per_day = 999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.DecayRate_per_day = 1001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, infrastructure.DecayRate_per_day);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [NearFieldVelocity_m_s] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.NearFieldVelocity_m_s = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 10.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 9.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.NearFieldVelocity_m_s = 11.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0f, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldVelocity_m_s] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.FarFieldVelocity_m_s = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 10.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 9.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.FarFieldVelocity_m_s = 11.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0f, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [ReceivingWaterSalinity_PSU] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Min should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Min - 1 should return false with one error
            infrastructure.ReceivingWaterSalinity_PSU = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Max should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 40.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(40.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 39.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(39.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0] and Max [40]. At Max + 1 should return false with one error
            infrastructure.ReceivingWaterSalinity_PSU = 41.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0f, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [ReceivingWaterTemperature_C] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Min should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Min - 1 should return false with one error
            infrastructure.ReceivingWaterTemperature_C = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "0", "40")).Any());
            Assert.AreEqual(-1.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Max should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 40.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(40.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 39.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(39.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [0] and Max [40]. At Max + 1 should return false with one error
            infrastructure.ReceivingWaterTemperature_C = 41.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "0", "40")).Any());
            Assert.AreEqual(41.0f, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [ReceivingWater_MPN_per_100ml] of type [int]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 20000000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(20000000, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 19999999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(19999999, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = 20000001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [DistanceFromShore_m] of type [float]
            //-----------------------------------

            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DistanceFromShore_m has Min [0] and Max [10000]. At Min should return true and no errors
            infrastructure.DistanceFromShore_m = 0.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            infrastructure.DistanceFromShore_m = 1.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0] and Max [10000]. At Min - 1 should return false with one error
            infrastructure.DistanceFromShore_m = -1.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0] and Max [10000]. At Max should return true and no errors
            infrastructure.DistanceFromShore_m = 10000.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10000.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            infrastructure.DistanceFromShore_m = 9999.0f;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9999.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(0, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0] and Max [10000]. At Max + 1 should return false with one error
            infrastructure.DistanceFromShore_m = 10001.0f;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(0, infrastructureService.GetRead().Count());

            //-----------------------------------
            // doing property [SeeOtherTVItemID] of type [int]
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
            // doing property [CivicAddressTVItemID] of type [int]
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
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
