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
    public partial class InfrastructureServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InfrastructureService infrastructureService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureServiceTest() : base()
        {
            //infrastructureService = new InfrastructureService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "CivicAddressTVItemID") infrastructure.CivicAddressTVItemID = 16;
            if (OmitPropName != "LastUpdateDate_UTC") infrastructure.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructure.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "InfrastructureTVText") infrastructure.InfrastructureTVText = GetRandomString("", 5);
            if (OmitPropName != "SeeOtherTVText") infrastructure.SeeOtherTVText = GetRandomString("", 5);
            if (OmitPropName != "CivicAddressTVText") infrastructure.CivicAddressTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") infrastructure.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "InfrastructureTypeText") infrastructure.InfrastructureTypeText = GetRandomString("", 5);
            if (OmitPropName != "FacilityTypeText") infrastructure.FacilityTypeText = GetRandomString("", 5);
            if (OmitPropName != "AerationTypeText") infrastructure.AerationTypeText = GetRandomString("", 5);
            if (OmitPropName != "PreliminaryTreatmentTypeText") infrastructure.PreliminaryTreatmentTypeText = GetRandomString("", 5);
            if (OmitPropName != "PrimaryTreatmentTypeText") infrastructure.PrimaryTreatmentTypeText = GetRandomString("", 5);
            if (OmitPropName != "SecondaryTreatmentTypeText") infrastructure.SecondaryTreatmentTypeText = GetRandomString("", 5);
            if (OmitPropName != "TertiaryTreatmentTypeText") infrastructure.TertiaryTreatmentTypeText = GetRandomString("", 5);
            if (OmitPropName != "TreatmentTypeText") infrastructure.TreatmentTypeText = GetRandomString("", 5);
            if (OmitPropName != "DisinfectionTypeText") infrastructure.DisinfectionTypeText = GetRandomString("", 5);
            if (OmitPropName != "CollectionSystemTypeText") infrastructure.CollectionSystemTypeText = GetRandomString("", 5);
            if (OmitPropName != "AlarmSystemTypeText") infrastructure.AlarmSystemTypeText = GetRandomString("", 5);

            return infrastructure;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Infrastructure_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, dbTestDB, ContactID);

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

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureID = 0;
                infrastructureService.Update(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureID), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                // infrastructure.InfrastructureTVItemID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureTVItemID = 0;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureInfrastructureTVItemID, infrastructure.InfrastructureTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureTVItemID = 1;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureInfrastructureTVItemID, "Infrastructure"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [Range(0, 100000)]
                // infrastructure.PrismID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PrismID = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PrismID = 100001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 100000)]
                // infrastructure.TPID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TPID = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TPID = 100001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 100000)]
                // infrastructure.LSID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.LSID = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.LSID = 100001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 100000)]
                // infrastructure.SiteID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SiteID = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SiteID = 100001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 100000)]
                // infrastructure.Site   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.Site = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.Site = 100001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(1, MinimumLength = 1)]
                // infrastructure.InfrastructureCategory   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureCategory = GetRandomString("", 2);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.InfrastructureInfrastructureCategory, "1", "1"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.InfrastructureType   (InfrastructureTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureType = (InfrastructureTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.FacilityType   (FacilityTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.FacilityType = (FacilityTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureFacilityType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


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
                infrastructure.NumberOfCells = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NumberOfCells = 11;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // infrastructure.NumberOfAeratedCells   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NumberOfAeratedCells = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NumberOfAeratedCells = 11;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.AerationType   (AerationTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AerationType = (AerationTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureAerationType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.PreliminaryTreatmentType   (PreliminaryTreatmentTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructurePreliminaryTreatmentType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.PrimaryTreatmentType   (PrimaryTreatmentTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructurePrimaryTreatmentType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.SecondaryTreatmentType   (SecondaryTreatmentTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureSecondaryTreatmentType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.TertiaryTreatmentType   (TertiaryTreatmentTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureTertiaryTreatmentType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.TreatmentType   (TreatmentTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TreatmentType = (TreatmentTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureTreatmentType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.DisinfectionType   (DisinfectionTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DisinfectionType = (DisinfectionTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureDisinfectionType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.CollectionSystemType   (CollectionSystemTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.CollectionSystemType = (CollectionSystemTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureCollectionSystemType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPEnumType]
                // infrastructure.AlarmSystemType   (AlarmSystemTypeEnum)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AlarmSystemType = (AlarmSystemTypeEnum)1000000;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureAlarmSystemType), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000000)]
                // infrastructure.DesignFlow_m3_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [DesignFlow_m3_day]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DesignFlow_m3_day = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DesignFlow_m3_day = 1000001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000000)]
                // infrastructure.AverageFlow_m3_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [AverageFlow_m3_day]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AverageFlow_m3_day = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AverageFlow_m3_day = 1000001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000000)]
                // infrastructure.PeakFlow_m3_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [PeakFlow_m3_day]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PeakFlow_m3_day = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PeakFlow_m3_day = 1000001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000000)]
                // infrastructure.PopServed   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PopServed = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PopServed = 1000001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
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
                infrastructure.PercFlowOfTotal = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PercFlowOfTotal = 101.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-10, 0)]
                // infrastructure.TimeOffset_hour   (Double)
                // -----------------------------------

                //Error: Type not implemented [TimeOffset_hour]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TimeOffset_hour = -11.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TimeOffset_hour = 1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // infrastructure.TempCatchAllRemoveLater   (String)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000)]
                // infrastructure.AverageDepth_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [AverageDepth_m]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AverageDepth_m = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AverageDepth_m = 1001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(1, 1000)]
                // infrastructure.NumberOfPorts   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NumberOfPorts = 0;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NumberOfPorts = 1001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // infrastructure.PortDiameter_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [PortDiameter_m]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortDiameter_m = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortDiameter_m = 11.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10000)]
                // infrastructure.PortSpacing_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [PortSpacing_m]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortSpacing_m = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortSpacing_m = 10001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000)]
                // infrastructure.PortElevation_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [PortElevation_m]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortElevation_m = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PortElevation_m = 1001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-90, 90)]
                // infrastructure.VerticalAngle_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [VerticalAngle_deg]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.VerticalAngle_deg = -91.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.VerticalAngle_deg = 91.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-180, 180)]
                // infrastructure.HorizontalAngle_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [HorizontalAngle_deg]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.HorizontalAngle_deg = -181.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.HorizontalAngle_deg = 181.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 100)]
                // infrastructure.DecayRate_per_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [DecayRate_per_day]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DecayRate_per_day = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DecayRate_per_day = 101.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // infrastructure.NearFieldVelocity_m_s   (Double)
                // -----------------------------------

                //Error: Type not implemented [NearFieldVelocity_m_s]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NearFieldVelocity_m_s = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.NearFieldVelocity_m_s = 11.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // infrastructure.FarFieldVelocity_m_s   (Double)
                // -----------------------------------

                //Error: Type not implemented [FarFieldVelocity_m_s]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.FarFieldVelocity_m_s = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.FarFieldVelocity_m_s = 11.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 40)]
                // infrastructure.ReceivingWaterSalinity_PSU   (Double)
                // -----------------------------------

                //Error: Type not implemented [ReceivingWaterSalinity_PSU]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWaterSalinity_PSU = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWaterSalinity_PSU = 41.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-10, 40)]
                // infrastructure.ReceivingWaterTemperature_C   (Double)
                // -----------------------------------

                //Error: Type not implemented [ReceivingWaterTemperature_C]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWaterTemperature_C = -11.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWaterTemperature_C = 41.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10000000)]
                // infrastructure.ReceivingWater_MPN_per_100ml   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWater_MPN_per_100ml = -1;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.ReceivingWater_MPN_per_100ml = 10000001;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000)]
                // infrastructure.DistanceFromShore_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [DistanceFromShore_m]

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DistanceFromShore_m = -1.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());
                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DistanceFromShore_m = 1001.0D;
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                // infrastructure.SeeOtherTVItemID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SeeOtherTVItemID = 0;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureSeeOtherTVItemID, infrastructure.SeeOtherTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SeeOtherTVItemID = 1;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureSeeOtherTVItemID, "Infrastructure"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                // infrastructure.CivicAddressTVItemID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.CivicAddressTVItemID = 0;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureCivicAddressTVItemID, infrastructure.CivicAddressTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.CivicAddressTVItemID = 1;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureCivicAddressTVItemID, "Infrastructure"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // infrastructure.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // infrastructure.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.LastUpdateContactTVItemID = 0;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLastUpdateContactTVItemID, infrastructure.LastUpdateContactTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.LastUpdateContactTVItemID = 1;
                infrastructureService.Add(infrastructure);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureLastUpdateContactTVItemID, "Contact"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "InfrastructureTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // infrastructure.InfrastructureTVText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureTVText = GetRandomString("", 201);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureInfrastructureTVText, "200"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "SeeOtherTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // infrastructure.SeeOtherTVText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SeeOtherTVText = GetRandomString("", 201);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureSeeOtherTVText, "200"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "CivicAddressTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // infrastructure.CivicAddressTVText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.CivicAddressTVText = GetRandomString("", 201);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureCivicAddressTVText, "200"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // infrastructure.LastUpdateContactTVText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLastUpdateContactTVText, "200"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.InfrastructureTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.InfrastructureTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureInfrastructureTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.FacilityTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.FacilityTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureFacilityTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.AerationTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AerationTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureAerationTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.PreliminaryTreatmentTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PreliminaryTreatmentTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructurePreliminaryTreatmentTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.PrimaryTreatmentTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.PrimaryTreatmentTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructurePrimaryTreatmentTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.SecondaryTreatmentTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.SecondaryTreatmentTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureSecondaryTreatmentTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.TertiaryTreatmentTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TertiaryTreatmentTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureTertiaryTreatmentTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.TreatmentTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.TreatmentTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureTreatmentTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.DisinfectionTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.DisinfectionTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureDisinfectionTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.CollectionSystemTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.CollectionSystemTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureCollectionSystemTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructure.AlarmSystemTypeText   (String)
                // -----------------------------------

                infrastructure = null;
                infrastructure = GetFilledRandomInfrastructure("");
                infrastructure.AlarmSystemTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureAlarmSystemTypeText, "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // infrastructure.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void Infrastructure_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, dbTestDB, ContactID);
                Infrastructure infrastructure = (from c in infrastructureService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(infrastructure);

                Infrastructure infrastructureRet = infrastructureService.GetInfrastructureWithInfrastructureID(infrastructure.InfrastructureID);
                Assert.IsNotNull(infrastructureRet.InfrastructureID);
                Assert.IsNotNull(infrastructureRet.InfrastructureTVItemID);
                if (infrastructureRet.PrismID != null)
                {
                   Assert.IsNotNull(infrastructureRet.PrismID);
                }
                if (infrastructureRet.TPID != null)
                {
                   Assert.IsNotNull(infrastructureRet.TPID);
                }
                if (infrastructureRet.LSID != null)
                {
                   Assert.IsNotNull(infrastructureRet.LSID);
                }
                if (infrastructureRet.SiteID != null)
                {
                   Assert.IsNotNull(infrastructureRet.SiteID);
                }
                if (infrastructureRet.Site != null)
                {
                   Assert.IsNotNull(infrastructureRet.Site);
                }
                if (infrastructureRet.InfrastructureCategory != null)
                {
                   Assert.IsNotNull(infrastructureRet.InfrastructureCategory);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.InfrastructureCategory));
                }
                if (infrastructureRet.InfrastructureType != null)
                {
                   Assert.IsNotNull(infrastructureRet.InfrastructureType);
                }
                if (infrastructureRet.FacilityType != null)
                {
                   Assert.IsNotNull(infrastructureRet.FacilityType);
                }
                if (infrastructureRet.IsMechanicallyAerated != null)
                {
                   Assert.IsNotNull(infrastructureRet.IsMechanicallyAerated);
                }
                if (infrastructureRet.NumberOfCells != null)
                {
                   Assert.IsNotNull(infrastructureRet.NumberOfCells);
                }
                if (infrastructureRet.NumberOfAeratedCells != null)
                {
                   Assert.IsNotNull(infrastructureRet.NumberOfAeratedCells);
                }
                if (infrastructureRet.AerationType != null)
                {
                   Assert.IsNotNull(infrastructureRet.AerationType);
                }
                if (infrastructureRet.PreliminaryTreatmentType != null)
                {
                   Assert.IsNotNull(infrastructureRet.PreliminaryTreatmentType);
                }
                if (infrastructureRet.PrimaryTreatmentType != null)
                {
                   Assert.IsNotNull(infrastructureRet.PrimaryTreatmentType);
                }
                if (infrastructureRet.SecondaryTreatmentType != null)
                {
                   Assert.IsNotNull(infrastructureRet.SecondaryTreatmentType);
                }
                if (infrastructureRet.TertiaryTreatmentType != null)
                {
                   Assert.IsNotNull(infrastructureRet.TertiaryTreatmentType);
                }
                if (infrastructureRet.TreatmentType != null)
                {
                   Assert.IsNotNull(infrastructureRet.TreatmentType);
                }
                if (infrastructureRet.DisinfectionType != null)
                {
                   Assert.IsNotNull(infrastructureRet.DisinfectionType);
                }
                if (infrastructureRet.CollectionSystemType != null)
                {
                   Assert.IsNotNull(infrastructureRet.CollectionSystemType);
                }
                if (infrastructureRet.AlarmSystemType != null)
                {
                   Assert.IsNotNull(infrastructureRet.AlarmSystemType);
                }
                if (infrastructureRet.DesignFlow_m3_day != null)
                {
                   Assert.IsNotNull(infrastructureRet.DesignFlow_m3_day);
                }
                if (infrastructureRet.AverageFlow_m3_day != null)
                {
                   Assert.IsNotNull(infrastructureRet.AverageFlow_m3_day);
                }
                if (infrastructureRet.PeakFlow_m3_day != null)
                {
                   Assert.IsNotNull(infrastructureRet.PeakFlow_m3_day);
                }
                if (infrastructureRet.PopServed != null)
                {
                   Assert.IsNotNull(infrastructureRet.PopServed);
                }
                if (infrastructureRet.CanOverflow != null)
                {
                   Assert.IsNotNull(infrastructureRet.CanOverflow);
                }
                if (infrastructureRet.PercFlowOfTotal != null)
                {
                   Assert.IsNotNull(infrastructureRet.PercFlowOfTotal);
                }
                if (infrastructureRet.TimeOffset_hour != null)
                {
                   Assert.IsNotNull(infrastructureRet.TimeOffset_hour);
                }
                if (infrastructureRet.TempCatchAllRemoveLater != null)
                {
                   Assert.IsNotNull(infrastructureRet.TempCatchAllRemoveLater);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.TempCatchAllRemoveLater));
                }
                if (infrastructureRet.AverageDepth_m != null)
                {
                   Assert.IsNotNull(infrastructureRet.AverageDepth_m);
                }
                if (infrastructureRet.NumberOfPorts != null)
                {
                   Assert.IsNotNull(infrastructureRet.NumberOfPorts);
                }
                if (infrastructureRet.PortDiameter_m != null)
                {
                   Assert.IsNotNull(infrastructureRet.PortDiameter_m);
                }
                if (infrastructureRet.PortSpacing_m != null)
                {
                   Assert.IsNotNull(infrastructureRet.PortSpacing_m);
                }
                if (infrastructureRet.PortElevation_m != null)
                {
                   Assert.IsNotNull(infrastructureRet.PortElevation_m);
                }
                if (infrastructureRet.VerticalAngle_deg != null)
                {
                   Assert.IsNotNull(infrastructureRet.VerticalAngle_deg);
                }
                if (infrastructureRet.HorizontalAngle_deg != null)
                {
                   Assert.IsNotNull(infrastructureRet.HorizontalAngle_deg);
                }
                if (infrastructureRet.DecayRate_per_day != null)
                {
                   Assert.IsNotNull(infrastructureRet.DecayRate_per_day);
                }
                if (infrastructureRet.NearFieldVelocity_m_s != null)
                {
                   Assert.IsNotNull(infrastructureRet.NearFieldVelocity_m_s);
                }
                if (infrastructureRet.FarFieldVelocity_m_s != null)
                {
                   Assert.IsNotNull(infrastructureRet.FarFieldVelocity_m_s);
                }
                if (infrastructureRet.ReceivingWaterSalinity_PSU != null)
                {
                   Assert.IsNotNull(infrastructureRet.ReceivingWaterSalinity_PSU);
                }
                if (infrastructureRet.ReceivingWaterTemperature_C != null)
                {
                   Assert.IsNotNull(infrastructureRet.ReceivingWaterTemperature_C);
                }
                if (infrastructureRet.ReceivingWater_MPN_per_100ml != null)
                {
                   Assert.IsNotNull(infrastructureRet.ReceivingWater_MPN_per_100ml);
                }
                if (infrastructureRet.DistanceFromShore_m != null)
                {
                   Assert.IsNotNull(infrastructureRet.DistanceFromShore_m);
                }
                if (infrastructureRet.SeeOtherTVItemID != null)
                {
                   Assert.IsNotNull(infrastructureRet.SeeOtherTVItemID);
                }
                if (infrastructureRet.CivicAddressTVItemID != null)
                {
                   Assert.IsNotNull(infrastructureRet.CivicAddressTVItemID);
                }
                Assert.IsNotNull(infrastructureRet.LastUpdateDate_UTC);
                Assert.IsNotNull(infrastructureRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(infrastructureRet.InfrastructureTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.InfrastructureTVText));
                if (infrastructureRet.SeeOtherTVItemID != null)
                {
                   Assert.IsNotNull(infrastructureRet.SeeOtherTVText);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.SeeOtherTVText));
                }
                if (infrastructureRet.CivicAddressTVItemID != null)
                {
                   Assert.IsNotNull(infrastructureRet.CivicAddressTVText);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.CivicAddressTVText));
                }
                Assert.IsNotNull(infrastructureRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.LastUpdateContactTVText));
                Assert.IsNotNull(infrastructureRet.InfrastructureTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.InfrastructureTypeText));
                Assert.IsNotNull(infrastructureRet.FacilityTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.FacilityTypeText));
                Assert.IsNotNull(infrastructureRet.AerationTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.AerationTypeText));
                Assert.IsNotNull(infrastructureRet.PreliminaryTreatmentTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.PreliminaryTreatmentTypeText));
                Assert.IsNotNull(infrastructureRet.PrimaryTreatmentTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.PrimaryTreatmentTypeText));
                Assert.IsNotNull(infrastructureRet.SecondaryTreatmentTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.SecondaryTreatmentTypeText));
                Assert.IsNotNull(infrastructureRet.TertiaryTreatmentTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.TertiaryTreatmentTypeText));
                Assert.IsNotNull(infrastructureRet.TreatmentTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.TreatmentTypeText));
                Assert.IsNotNull(infrastructureRet.DisinfectionTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.DisinfectionTypeText));
                Assert.IsNotNull(infrastructureRet.CollectionSystemTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.CollectionSystemTypeText));
                Assert.IsNotNull(infrastructureRet.AlarmSystemTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureRet.AlarmSystemTypeText));
            }
        }
        #endregion Tests Get With Key

    }
}