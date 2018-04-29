using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour Infrastructure</para>
    /// </summary>
    public partial class InfrastructureService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Infrastructure infrastructure = validationContext.ObjectInstance as Infrastructure;
            infrastructure.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructure.InfrastructureID == 0)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureInfrastructureID), new[] { "InfrastructureID" });
                }

                if (!GetRead().Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Infrastructure, CSSPModelsRes.InfrastructureInfrastructureID, infrastructure.InfrastructureID.ToString()), new[] { "InfrastructureID" });
                }
            }

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureInfrastructureTVItemID, (infrastructure.InfrastructureTVItemID == null ? "" : infrastructure.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePrismID, "0", "100000"), new[] { "PrismID" });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureTPID, "0", "100000"), new[] { "TPID" });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureLSID, "0", "100000"), new[] { "LSID" });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureSiteID, "0", "100000"), new[] { "SiteID" });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureSite, "0", "100000"), new[] { "Site" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.InfrastructureInfrastructureCategory, "1", "1"), new[] { "InfrastructureCategory" });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == InfrastructureTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureInfrastructureType), new[] { "InfrastructureType" });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.EnumTypeOK(typeof(FacilityTypeEnum), (int?)infrastructure.FacilityType);
                if (infrastructure.FacilityType == FacilityTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureFacilityType), new[] { "FacilityType" });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureNumberOfCells, "0", "10"), new[] { "NumberOfCells" });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureNumberOfAeratedCells, "0", "10"), new[] { "NumberOfAeratedCells" });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AerationTypeEnum), (int?)infrastructure.AerationType);
                if (infrastructure.AerationType == AerationTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureAerationType), new[] { "AerationType" });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PreliminaryTreatmentTypeEnum), (int?)infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == PreliminaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructurePreliminaryTreatmentType), new[] { "PreliminaryTreatmentType" });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PrimaryTreatmentTypeEnum), (int?)infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == PrimaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructurePrimaryTreatmentType), new[] { "PrimaryTreatmentType" });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SecondaryTreatmentTypeEnum), (int?)infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == SecondaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureSecondaryTreatmentType), new[] { "SecondaryTreatmentType" });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TertiaryTreatmentTypeEnum), (int?)infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == TertiaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureTertiaryTreatmentType), new[] { "TertiaryTreatmentType" });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TreatmentTypeEnum), (int?)infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == TreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureTreatmentType), new[] { "TreatmentType" });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.EnumTypeOK(typeof(DisinfectionTypeEnum), (int?)infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == DisinfectionTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureDisinfectionType), new[] { "DisinfectionType" });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(CollectionSystemTypeEnum), (int?)infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == CollectionSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureCollectionSystemType), new[] { "CollectionSystemType" });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AlarmSystemTypeEnum), (int?)infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == AlarmSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureAlarmSystemType), new[] { "AlarmSystemType" });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000"), new[] { "DesignFlow_m3_day" });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000"), new[] { "AverageFlow_m3_day" });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000"), new[] { "PeakFlow_m3_day" });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePopServed, "0", "1000000"), new[] { "PopServed" });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePercFlowOfTotal, "0", "100"), new[] { "PercFlowOfTotal" });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureTimeOffset_hour, "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureAverageDepth_m, "0", "1000"), new[] { "AverageDepth_m" });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureNumberOfPorts, "1", "1000"), new[] { "NumberOfPorts" });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePortDiameter_m, "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePortSpacing_m, "0", "10000"), new[] { "PortSpacing_m" });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructurePortElevation_m, "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureVerticalAngle_deg, "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureDecayRate_per_day, "0", "100"), new[] { "DecayRate_per_day" });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10"), new[] { "NearFieldVelocity_m_s" });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10"), new[] { "FarFieldVelocity_m_s" });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40"), new[] { "ReceivingWaterSalinity_PSU" });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40"), new[] { "ReceivingWaterTemperature_C" });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000"), new[] { "ReceivingWater_MPN_per_100ml" });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.InfrastructureDistanceFromShore_m, "0", "1000"), new[] { "DistanceFromShore_m" });
                }
            }

            if (infrastructure.SeeOtherTVItemID != null)
            {
                TVItem TVItemSeeOtherTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.SeeOtherTVItemID select c).FirstOrDefault();

                if (TVItemSeeOtherTVItemID == null)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureSeeOtherTVItemID, (infrastructure.SeeOtherTVItemID == null ? "" : infrastructure.SeeOtherTVItemID.ToString())), new[] { "SeeOtherTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSeeOtherTVItemID.TVType))
                    {
                        infrastructure.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureSeeOtherTVItemID, "Infrastructure"), new[] { "SeeOtherTVItemID" });
                    }
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureCivicAddressTVItemID, (infrastructure.CivicAddressTVItemID == null ? "" : infrastructure.CivicAddressTVItemID.ToString())), new[] { "CivicAddressTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        infrastructure.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureCivicAddressTVItemID, "Address"), new[] { "CivicAddressTVItemID" });
                    }
                }
            }

            if (infrastructure.LastUpdateDate_UTC.Year == 1)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructure.LastUpdateDate_UTC.Year < 1980)
                {
                infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.InfrastructureLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureLastUpdateContactTVItemID, (infrastructure.LastUpdateContactTVItemID == null ? "" : infrastructure.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Infrastructure GetInfrastructureWithInfrastructureID(int InfrastructureID, GetParam getParam)
        {
            IQueryable<Infrastructure> infrastructureQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.InfrastructureID == InfrastructureID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return infrastructureQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillInfrastructureWeb(infrastructureQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillInfrastructureReport(infrastructureQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Infrastructure> GetInfrastructureList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<Infrastructure> infrastructureQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureQuery  = infrastructureQuery.OrderByDescending(c => c.InfrastructureID);
                        }
                        infrastructureQuery = infrastructureQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureQuery = FillInfrastructureWeb(infrastructureQuery, FilterAndOrderText).OrderByDescending(c => c.InfrastructureID);
                        }
                        infrastructureQuery = FillInfrastructureWeb(infrastructureQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureQuery = FillInfrastructureReport(infrastructureQuery, FilterAndOrderText).OrderByDescending(c => c.InfrastructureID);
                        }
                        infrastructureQuery = FillInfrastructureReport(infrastructureQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Add(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public bool Delete(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Delete);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Remove(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public bool Update(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Update(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public IQueryable<Infrastructure> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.Infrastructures.AsNoTracking();
            }
            else
            {
                return db.Infrastructures.AsNoTracking().OrderByDescending(c => c.InfrastructureID);
            }
        }
        public IQueryable<Infrastructure> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.Infrastructures;
            }
            else
            {
                return db.Infrastructures.OrderByDescending(c => c.InfrastructureID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated InfrastructureFillWeb
        private IQueryable<Infrastructure> FillInfrastructureWeb(IQueryable<Infrastructure> infrastructureQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> InfrastructureTypeEnumList = enums.GetEnumTextOrderedList(typeof(InfrastructureTypeEnum));
            List<EnumIDAndText> FacilityTypeEnumList = enums.GetEnumTextOrderedList(typeof(FacilityTypeEnum));
            List<EnumIDAndText> AerationTypeEnumList = enums.GetEnumTextOrderedList(typeof(AerationTypeEnum));
            List<EnumIDAndText> PreliminaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(PreliminaryTreatmentTypeEnum));
            List<EnumIDAndText> PrimaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(PrimaryTreatmentTypeEnum));
            List<EnumIDAndText> SecondaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(SecondaryTreatmentTypeEnum));
            List<EnumIDAndText> TertiaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(TertiaryTreatmentTypeEnum));
            List<EnumIDAndText> TreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(TreatmentTypeEnum));
            List<EnumIDAndText> DisinfectionTypeEnumList = enums.GetEnumTextOrderedList(typeof(DisinfectionTypeEnum));
            List<EnumIDAndText> CollectionSystemTypeEnumList = enums.GetEnumTextOrderedList(typeof(CollectionSystemTypeEnum));
            List<EnumIDAndText> AlarmSystemTypeEnumList = enums.GetEnumTextOrderedList(typeof(AlarmSystemTypeEnum));

            infrastructureQuery = (from c in infrastructureQuery
                let InfrastructureTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SeeOtherTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SeeOtherTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CivicAddressTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CivicAddressTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Infrastructure
                    {
                        InfrastructureID = c.InfrastructureID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        PrismID = c.PrismID,
                        TPID = c.TPID,
                        LSID = c.LSID,
                        SiteID = c.SiteID,
                        Site = c.Site,
                        InfrastructureCategory = c.InfrastructureCategory,
                        InfrastructureType = c.InfrastructureType,
                        FacilityType = c.FacilityType,
                        IsMechanicallyAerated = c.IsMechanicallyAerated,
                        NumberOfCells = c.NumberOfCells,
                        NumberOfAeratedCells = c.NumberOfAeratedCells,
                        AerationType = c.AerationType,
                        PreliminaryTreatmentType = c.PreliminaryTreatmentType,
                        PrimaryTreatmentType = c.PrimaryTreatmentType,
                        SecondaryTreatmentType = c.SecondaryTreatmentType,
                        TertiaryTreatmentType = c.TertiaryTreatmentType,
                        TreatmentType = c.TreatmentType,
                        DisinfectionType = c.DisinfectionType,
                        CollectionSystemType = c.CollectionSystemType,
                        AlarmSystemType = c.AlarmSystemType,
                        DesignFlow_m3_day = c.DesignFlow_m3_day,
                        AverageFlow_m3_day = c.AverageFlow_m3_day,
                        PeakFlow_m3_day = c.PeakFlow_m3_day,
                        PopServed = c.PopServed,
                        CanOverflow = c.CanOverflow,
                        PercFlowOfTotal = c.PercFlowOfTotal,
                        TimeOffset_hour = c.TimeOffset_hour,
                        TempCatchAllRemoveLater = c.TempCatchAllRemoveLater,
                        AverageDepth_m = c.AverageDepth_m,
                        NumberOfPorts = c.NumberOfPorts,
                        PortDiameter_m = c.PortDiameter_m,
                        PortSpacing_m = c.PortSpacing_m,
                        PortElevation_m = c.PortElevation_m,
                        VerticalAngle_deg = c.VerticalAngle_deg,
                        HorizontalAngle_deg = c.HorizontalAngle_deg,
                        DecayRate_per_day = c.DecayRate_per_day,
                        NearFieldVelocity_m_s = c.NearFieldVelocity_m_s,
                        FarFieldVelocity_m_s = c.FarFieldVelocity_m_s,
                        ReceivingWaterSalinity_PSU = c.ReceivingWaterSalinity_PSU,
                        ReceivingWaterTemperature_C = c.ReceivingWaterTemperature_C,
                        ReceivingWater_MPN_per_100ml = c.ReceivingWater_MPN_per_100ml,
                        DistanceFromShore_m = c.DistanceFromShore_m,
                        SeeOtherTVItemID = c.SeeOtherTVItemID,
                        CivicAddressTVItemID = c.CivicAddressTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        InfrastructureWeb = new InfrastructureWeb
                        {
                            InfrastructureTVText = InfrastructureTVText,
                            SeeOtherTVText = SeeOtherTVText,
                            CivicAddressTVText = CivicAddressTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            InfrastructureTypeText = (from e in InfrastructureTypeEnumList
                                where e.EnumID == (int?)c.InfrastructureType
                                select e.EnumText).FirstOrDefault(),
                            FacilityTypeText = (from e in FacilityTypeEnumList
                                where e.EnumID == (int?)c.FacilityType
                                select e.EnumText).FirstOrDefault(),
                            AerationTypeText = (from e in AerationTypeEnumList
                                where e.EnumID == (int?)c.AerationType
                                select e.EnumText).FirstOrDefault(),
                            PreliminaryTreatmentTypeText = (from e in PreliminaryTreatmentTypeEnumList
                                where e.EnumID == (int?)c.PreliminaryTreatmentType
                                select e.EnumText).FirstOrDefault(),
                            PrimaryTreatmentTypeText = (from e in PrimaryTreatmentTypeEnumList
                                where e.EnumID == (int?)c.PrimaryTreatmentType
                                select e.EnumText).FirstOrDefault(),
                            SecondaryTreatmentTypeText = (from e in SecondaryTreatmentTypeEnumList
                                where e.EnumID == (int?)c.SecondaryTreatmentType
                                select e.EnumText).FirstOrDefault(),
                            TertiaryTreatmentTypeText = (from e in TertiaryTreatmentTypeEnumList
                                where e.EnumID == (int?)c.TertiaryTreatmentType
                                select e.EnumText).FirstOrDefault(),
                            TreatmentTypeText = (from e in TreatmentTypeEnumList
                                where e.EnumID == (int?)c.TreatmentType
                                select e.EnumText).FirstOrDefault(),
                            DisinfectionTypeText = (from e in DisinfectionTypeEnumList
                                where e.EnumID == (int?)c.DisinfectionType
                                select e.EnumText).FirstOrDefault(),
                            CollectionSystemTypeText = (from e in CollectionSystemTypeEnumList
                                where e.EnumID == (int?)c.CollectionSystemType
                                select e.EnumText).FirstOrDefault(),
                            AlarmSystemTypeText = (from e in AlarmSystemTypeEnumList
                                where e.EnumID == (int?)c.AlarmSystemType
                                select e.EnumText).FirstOrDefault(),
                        },
                        InfrastructureReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return infrastructureQuery;
        }
        #endregion Functions private Generated InfrastructureFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(Infrastructure infrastructure)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructure.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
