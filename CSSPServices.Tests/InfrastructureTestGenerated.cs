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
        private InfrastructureService infrastructureService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureTest() : base()
        {
            infrastructureService = new InfrastructureService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Infrastructure GetFilledRandomInfrastructure(string OmitPropName)
        {
            Infrastructure infrastructure = new Infrastructure();

            if (OmitPropName != "InfrastructureTVItemID") infrastructure.InfrastructureTVItemID = 16;
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
            if (OmitPropName != "DesignFlow_m3_day") infrastructure.DesignFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "AverageFlow_m3_day") infrastructure.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "PeakFlow_m3_day") infrastructure.PeakFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "PopServed") infrastructure.PopServed = GetRandomInt(0, 1000000);
            if (OmitPropName != "CanOverflow") infrastructure.CanOverflow = true;
            if (OmitPropName != "PercFlowOfTotal") infrastructure.PercFlowOfTotal = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "TimeOffset_hour") infrastructure.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "TempCatchAllRemoveLater") infrastructure.TempCatchAllRemoveLater = GetRandomString("", 20);
            if (OmitPropName != "AverageDepth_m") infrastructure.AverageDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "NumberOfPorts") infrastructure.NumberOfPorts = GetRandomInt(1, 1000);
            if (OmitPropName != "PortDiameter_m") infrastructure.PortDiameter_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "PortSpacing_m") infrastructure.PortSpacing_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "PortElevation_m") infrastructure.PortElevation_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") infrastructure.VerticalAngle_deg = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "HorizontalAngle_deg") infrastructure.HorizontalAngle_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "DecayRate_per_day") infrastructure.DecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "NearFieldVelocity_m_s") infrastructure.NearFieldVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FarFieldVelocity_m_s") infrastructure.FarFieldVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "ReceivingWaterSalinity_PSU") infrastructure.ReceivingWaterSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "ReceivingWaterTemperature_C") infrastructure.ReceivingWaterTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ReceivingWater_MPN_per_100ml") infrastructure.ReceivingWater_MPN_per_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "DistanceFromShore_m") infrastructure.DistanceFromShore_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "SeeOtherTVItemID") infrastructure.SeeOtherTVItemID = 16;
            if (OmitPropName != "CivicAddressTVItemID") infrastructure.CivicAddressTVItemID = 28;
            if (OmitPropName != "LastUpdateDate_UTC") infrastructure.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructure.LastUpdateContactTVItemID = 2;

            return infrastructure;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Infrastructure_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Infrastructure infrastructure = GetFilledRandomInfrastructure("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = infrastructureService.GetRead().Count();

            infrastructureService.Add(infrastructure);
            if (infrastructure.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, infrastructureService.GetRead().Where(c => c == infrastructure).Any());
            infrastructureService.Update(infrastructure);
            if (infrastructure.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, infrastructureService.GetRead().Count());
            infrastructureService.Delete(infrastructure);
            if (infrastructure.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // infrastructure.InfrastructureID   (Int32)
            // -----------------------------------

            infrastructure = GetFilledRandomInfrastructure("");
            infrastructure.InfrastructureID = 0;
            infrastructureService.Update(infrastructure);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureID), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            // [Range(1, -1)]
            // infrastructure.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.InfrastructureTVItemID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000)]
            // infrastructure.PrismID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PrismID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.PrismID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.PrismID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.PrismID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.PrismID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.PrismID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.PrismID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.PrismID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PrismID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.PrismID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.PrismID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000)]
            // infrastructure.TPID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // TPID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.TPID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.TPID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.TPID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.TPID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.TPID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.TPID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.TPID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TPID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.TPID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.TPID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000)]
            // infrastructure.LSID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // LSID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.LSID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.LSID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.LSID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.LSID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.LSID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.LSID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.LSID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LSID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.LSID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.LSID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000)]
            // infrastructure.SiteID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // SiteID has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.SiteID = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.SiteID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.SiteID = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.SiteID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.SiteID = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.SiteID = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.SiteID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SiteID has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.SiteID = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.SiteID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000)]
            // infrastructure.Site   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // Site has Min [0] and Max [100000]. At Min should return true and no errors
            infrastructure.Site = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            infrastructure.Site = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Min - 1 should return false with one error
            infrastructure.Site = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000")).Any());
            Assert.AreEqual(-1, infrastructure.Site);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max should return true and no errors
            infrastructure.Site = 100000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100000, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            infrastructure.Site = 99999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99999, infrastructure.Site);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // Site has Min [0] and Max [100000]. At Max + 1 should return false with one error
            infrastructure.Site = 100001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000")).Any());
            Assert.AreEqual(100001, infrastructure.Site);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(1, MinimumLength = 1)]
            // infrastructure.InfrastructureCategory   (String)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            // InfrastructureCategory has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string infrastructureInfrastructureCategoryMin = GetRandomString("", 1);
            infrastructure.InfrastructureCategory = infrastructureInfrastructureCategoryMin;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(infrastructureInfrastructureCategoryMin, infrastructure.InfrastructureCategory);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // InfrastructureCategory has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            infrastructureInfrastructureCategoryMin = GetRandomString("", 1);
            infrastructure.InfrastructureCategory = infrastructureInfrastructureCategoryMin;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(infrastructureInfrastructureCategoryMin, infrastructure.InfrastructureCategory);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // InfrastructureCategory has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            infrastructureInfrastructureCategoryMin = GetRandomString("", 2);
            infrastructure.InfrastructureCategory = infrastructureInfrastructureCategoryMin;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.InfrastructureInfrastructureCategory, "1", "1")).Any());
            Assert.AreEqual(infrastructureInfrastructureCategoryMin, infrastructure.InfrastructureCategory);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.InfrastructureType   (InfrastructureTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.FacilityType   (FacilityTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // infrastructure.IsMechanicallyAerated   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // infrastructure.NumberOfCells   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfCells has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.NumberOfCells = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.NumberOfCells = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.NumberOfCells = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10")).Any());
            Assert.AreEqual(-1, infrastructure.NumberOfCells);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.NumberOfCells = 10;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.NumberOfCells = 9;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9, infrastructure.NumberOfCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfCells has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.NumberOfCells = 11;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10")).Any());
            Assert.AreEqual(11, infrastructure.NumberOfCells);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // infrastructure.NumberOfAeratedCells   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min should return true and no errors
            infrastructure.NumberOfAeratedCells = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min + 1 should return true and no errors
            infrastructure.NumberOfAeratedCells = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Min - 1 should return false with one error
            infrastructure.NumberOfAeratedCells = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10")).Any());
            Assert.AreEqual(-1, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max should return true and no errors
            infrastructure.NumberOfAeratedCells = 10;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max - 1 should return true and no errors
            infrastructure.NumberOfAeratedCells = 9;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfAeratedCells has Min [0] and Max [10]. At Max + 1 should return false with one error
            infrastructure.NumberOfAeratedCells = 11;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10")).Any());
            Assert.AreEqual(11, infrastructure.NumberOfAeratedCells);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.AerationType   (AerationTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.PreliminaryTreatmentType   (PreliminaryTreatmentTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.PrimaryTreatmentType   (PrimaryTreatmentTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.SecondaryTreatmentType   (SecondaryTreatmentTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.TertiaryTreatmentType   (TertiaryTreatmentTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.TreatmentType   (TreatmentTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.DisinfectionType   (DisinfectionTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.CollectionSystemType   (CollectionSystemTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // infrastructure.AlarmSystemType   (AlarmSystemTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000000)]
            // infrastructure.DesignFlow_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [DesignFlow_m3_day]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            infrastructure.DesignFlow_m3_day = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            infrastructure.DesignFlow_m3_day = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            infrastructure.DesignFlow_m3_day = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            infrastructure.DesignFlow_m3_day = 1000000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            infrastructure.DesignFlow_m3_day = 999999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DesignFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            infrastructure.DesignFlow_m3_day = 1000001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, infrastructure.DesignFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000000)]
            // infrastructure.AverageFlow_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [AverageFlow_m3_day]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            infrastructure.AverageFlow_m3_day = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            infrastructure.AverageFlow_m3_day = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            infrastructure.AverageFlow_m3_day = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            infrastructure.AverageFlow_m3_day = 1000000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            infrastructure.AverageFlow_m3_day = 999999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            infrastructure.AverageFlow_m3_day = 1000001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, infrastructure.AverageFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000000)]
            // infrastructure.PeakFlow_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [PeakFlow_m3_day]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            infrastructure.PeakFlow_m3_day = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            infrastructure.PeakFlow_m3_day = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            infrastructure.PeakFlow_m3_day = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            infrastructure.PeakFlow_m3_day = 1000000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            infrastructure.PeakFlow_m3_day = 999999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PeakFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            infrastructure.PeakFlow_m3_day = 1000001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, infrastructure.PeakFlow_m3_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000000)]
            // infrastructure.PopServed   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PopServed has Min [0] and Max [1000000]. At Min should return true and no errors
            infrastructure.PopServed = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            infrastructure.PopServed = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            infrastructure.PopServed = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000")).Any());
            Assert.AreEqual(-1, infrastructure.PopServed);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max should return true and no errors
            infrastructure.PopServed = 1000000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000000, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            infrastructure.PopServed = 999999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999999, infrastructure.PopServed);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PopServed has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            infrastructure.PopServed = 1000001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000")).Any());
            Assert.AreEqual(1000001, infrastructure.PopServed);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // infrastructure.CanOverflow   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // infrastructure.PercFlowOfTotal   (Double)
            // -----------------------------------

            //Error: Type not implemented [PercFlowOfTotal]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            infrastructure.PercFlowOfTotal = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            infrastructure.PercFlowOfTotal = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            infrastructure.PercFlowOfTotal = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100")).Any());
            Assert.AreEqual(-1.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            infrastructure.PercFlowOfTotal = 100.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            infrastructure.PercFlowOfTotal = 99.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PercFlowOfTotal has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            infrastructure.PercFlowOfTotal = 101.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100")).Any());
            Assert.AreEqual(101.0D, infrastructure.PercFlowOfTotal);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(-10, 0)]
            // infrastructure.TimeOffset_hour   (Double)
            // -----------------------------------

            //Error: Type not implemented [TimeOffset_hour]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min should return true and no errors
            infrastructure.TimeOffset_hour = -10.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-10.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min + 1 should return true and no errors
            infrastructure.TimeOffset_hour = -9.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-9.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min - 1 should return false with one error
            infrastructure.TimeOffset_hour = -11.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(-11.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max should return true and no errors
            infrastructure.TimeOffset_hour = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max - 1 should return true and no errors
            infrastructure.TimeOffset_hour = -1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-1.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max + 1 should return false with one error
            infrastructure.TimeOffset_hour = 1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(1.0D, infrastructure.TimeOffset_hour);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // infrastructure.TempCatchAllRemoveLater   (String)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // infrastructure.AverageDepth_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [AverageDepth_m]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            infrastructure.AverageDepth_m = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            infrastructure.AverageDepth_m = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            infrastructure.AverageDepth_m = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            infrastructure.AverageDepth_m = 1000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            infrastructure.AverageDepth_m = 999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // AverageDepth_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            infrastructure.AverageDepth_m = 1001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, infrastructure.AverageDepth_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(1, 1000)]
            // infrastructure.NumberOfPorts   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NumberOfPorts has Min [1] and Max [1000]. At Min should return true and no errors
            infrastructure.NumberOfPorts = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            infrastructure.NumberOfPorts = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Min - 1 should return false with one error
            infrastructure.NumberOfPorts = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000")).Any());
            Assert.AreEqual(0, infrastructure.NumberOfPorts);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max should return true and no errors
            infrastructure.NumberOfPorts = 1000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            infrastructure.NumberOfPorts = 999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999, infrastructure.NumberOfPorts);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [1000]. At Max + 1 should return false with one error
            infrastructure.NumberOfPorts = 1001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000")).Any());
            Assert.AreEqual(1001, infrastructure.NumberOfPorts);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // infrastructure.PortDiameter_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortDiameter_m]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            infrastructure.PortDiameter_m = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            infrastructure.PortDiameter_m = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            infrastructure.PortDiameter_m = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10")).Any());
            Assert.AreEqual(-1.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            infrastructure.PortDiameter_m = 10.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            infrastructure.PortDiameter_m = 9.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            infrastructure.PortDiameter_m = 11.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10")).Any());
            Assert.AreEqual(11.0D, infrastructure.PortDiameter_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10000)]
            // infrastructure.PortSpacing_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortSpacing_m]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            infrastructure.PortSpacing_m = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            infrastructure.PortSpacing_m = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            infrastructure.PortSpacing_m = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            infrastructure.PortSpacing_m = 10000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10000.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            infrastructure.PortSpacing_m = 9999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9999.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            infrastructure.PortSpacing_m = 10001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, infrastructure.PortSpacing_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // infrastructure.PortElevation_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortElevation_m]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            infrastructure.PortElevation_m = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            infrastructure.PortElevation_m = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            infrastructure.PortElevation_m = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            infrastructure.PortElevation_m = 1000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            infrastructure.PortElevation_m = 999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            infrastructure.PortElevation_m = 1001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, infrastructure.PortElevation_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(-90, 90)]
            // infrastructure.VerticalAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [VerticalAngle_deg]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            infrastructure.VerticalAngle_deg = -90.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-90.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            infrastructure.VerticalAngle_deg = -89.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-89.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            infrastructure.VerticalAngle_deg = -91.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            infrastructure.VerticalAngle_deg = 90.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(90.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            infrastructure.VerticalAngle_deg = 89.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(89.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            infrastructure.VerticalAngle_deg = 91.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(91.0D, infrastructure.VerticalAngle_deg);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(-180, 180)]
            // infrastructure.HorizontalAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [HorizontalAngle_deg]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            infrastructure.HorizontalAngle_deg = -180.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-180.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            infrastructure.HorizontalAngle_deg = -179.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-179.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            infrastructure.HorizontalAngle_deg = -181.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            infrastructure.HorizontalAngle_deg = 180.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(180.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            infrastructure.HorizontalAngle_deg = 179.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(179.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            infrastructure.HorizontalAngle_deg = 181.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0D, infrastructure.HorizontalAngle_deg);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // infrastructure.DecayRate_per_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [DecayRate_per_day]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            infrastructure.DecayRate_per_day = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            infrastructure.DecayRate_per_day = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            infrastructure.DecayRate_per_day = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            infrastructure.DecayRate_per_day = 100.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(100.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            infrastructure.DecayRate_per_day = 99.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(99.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            infrastructure.DecayRate_per_day = 101.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0D, infrastructure.DecayRate_per_day);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // infrastructure.NearFieldVelocity_m_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [NearFieldVelocity_m_s]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            infrastructure.NearFieldVelocity_m_s = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 10.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            infrastructure.NearFieldVelocity_m_s = 9.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // NearFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            infrastructure.NearFieldVelocity_m_s = 11.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, infrastructure.NearFieldVelocity_m_s);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // infrastructure.FarFieldVelocity_m_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [FarFieldVelocity_m_s]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            infrastructure.FarFieldVelocity_m_s = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 10.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            infrastructure.FarFieldVelocity_m_s = 9.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // FarFieldVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            infrastructure.FarFieldVelocity_m_s = 11.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, infrastructure.FarFieldVelocity_m_s);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 40)]
            // infrastructure.ReceivingWaterSalinity_PSU   (Double)
            // -----------------------------------

            //Error: Type not implemented [ReceivingWaterSalinity_PSU]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            infrastructure.ReceivingWaterSalinity_PSU = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 40.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(40.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWaterSalinity_PSU = 39.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(39.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            infrastructure.ReceivingWaterSalinity_PSU = 41.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, infrastructure.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(-10, 40)]
            // infrastructure.ReceivingWaterTemperature_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [ReceivingWaterTemperature_C]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = -10.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-10.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = -9.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(-9.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            infrastructure.ReceivingWaterTemperature_C = -11.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 40.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(40.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWaterTemperature_C = 39.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(39.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWaterTemperature_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            infrastructure.ReceivingWaterTemperature_C = 41.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, infrastructure.ReceivingWaterTemperature_C);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10000000)]
            // infrastructure.ReceivingWater_MPN_per_100ml   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 0;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = -1;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 10000000;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(10000000, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            infrastructure.ReceivingWater_MPN_per_100ml = 9999999;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(9999999, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // ReceivingWater_MPN_per_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            infrastructure.ReceivingWater_MPN_per_100ml = 10000001;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, infrastructure.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // infrastructure.DistanceFromShore_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [DistanceFromShore_m]


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            infrastructure.DistanceFromShore_m = 0.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(0.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            infrastructure.DistanceFromShore_m = 1.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            infrastructure.DistanceFromShore_m = -1.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            infrastructure.DistanceFromShore_m = 1000.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1000.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            infrastructure.DistanceFromShore_m = 999.0D;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(999.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // DistanceFromShore_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            infrastructure.DistanceFromShore_m = 1001.0D;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, infrastructure.DistanceFromShore_m);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            // [Range(1, -1)]
            // infrastructure.SeeOtherTVItemID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.SeeOtherTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.SeeOtherTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // SeeOtherTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.SeeOtherTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureSeeOtherTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.SeeOtherTVItemID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Address)]
            // [Range(1, -1)]
            // infrastructure.CivicAddressTVItemID   (Int32)
            // -----------------------------------


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.CivicAddressTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.CivicAddressTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.CivicAddressTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureCivicAddressTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.CivicAddressTVItemID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // infrastructure.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // infrastructure.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            infrastructure = null;
            infrastructure = GetFilledRandomInfrastructure("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructure.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(1, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructure.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, infrastructureService.Add(infrastructure));
            Assert.AreEqual(0, infrastructure.ValidationResults.Count());
            Assert.AreEqual(2, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureService.Delete(infrastructure));
            Assert.AreEqual(count, infrastructureService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructure.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, infrastructureService.Add(infrastructure));
            Assert.IsTrue(infrastructure.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructure.LastUpdateContactTVItemID);
            Assert.AreEqual(count, infrastructureService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // infrastructure.InfrastructureLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // infrastructure.InfrastructureTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // infrastructure.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
