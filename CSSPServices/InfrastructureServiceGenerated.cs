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
    public partial class InfrastructureService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Infrastructure infrastructure = validationContext.ObjectInstance as Infrastructure;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (infrastructure.InfrastructureID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureID), new[] { "InfrastructureID" });
                }
            }

            //InfrastructureID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureInfrastructureTVItemID, infrastructure.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000"), new[] { "PrismID" });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000"), new[] { "TPID" });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000"), new[] { "LSID" });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000"), new[] { "SiteID" });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000"), new[] { "Site" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.InfrastructureInfrastructureCategory, "1", "1"), new[] { "InfrastructureCategory" });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.InfrastructureTypeOK(infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == InfrastructureTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureType), new[] { "InfrastructureType" });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.FacilityTypeOK(infrastructure.FacilityType);
                if (infrastructure.FacilityType == FacilityTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureFacilityType), new[] { "FacilityType" });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10"), new[] { "NumberOfCells" });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10"), new[] { "NumberOfAeratedCells" });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.AerationTypeOK(infrastructure.AerationType);
                if (infrastructure.AerationType == AerationTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureAerationType), new[] { "AerationType" });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.PreliminaryTreatmentTypeOK(infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == PreliminaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructurePreliminaryTreatmentType), new[] { "PreliminaryTreatmentType" });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.PrimaryTreatmentTypeOK(infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == PrimaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructurePrimaryTreatmentType), new[] { "PrimaryTreatmentType" });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.SecondaryTreatmentTypeOK(infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == SecondaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureSecondaryTreatmentType), new[] { "SecondaryTreatmentType" });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.TertiaryTreatmentTypeOK(infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == TertiaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureTertiaryTreatmentType), new[] { "TertiaryTreatmentType" });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.TreatmentTypeOK(infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == TreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureTreatmentType), new[] { "TreatmentType" });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.DisinfectionTypeOK(infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == DisinfectionTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureDisinfectionType), new[] { "DisinfectionType" });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.CollectionSystemTypeOK(infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == CollectionSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureCollectionSystemType), new[] { "CollectionSystemType" });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.AlarmSystemTypeOK(infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == AlarmSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureAlarmSystemType), new[] { "AlarmSystemType" });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000"), new[] { "DesignFlow_m3_day" });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000"), new[] { "AverageFlow_m3_day" });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000"), new[] { "PeakFlow_m3_day" });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000"), new[] { "PopServed" });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100"), new[] { "PercFlowOfTotal" });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000"), new[] { "AverageDepth_m" });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000"), new[] { "NumberOfPorts" });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000"), new[] { "PortSpacing_m" });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100"), new[] { "DecayRate_per_day" });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10"), new[] { "NearFieldVelocity_m_s" });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10"), new[] { "FarFieldVelocity_m_s" });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40"), new[] { "ReceivingWaterSalinity_PSU" });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40"), new[] { "ReceivingWaterTemperature_C" });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000"), new[] { "ReceivingWater_MPN_per_100ml" });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000"), new[] { "DistanceFromShore_m" });
                }
            }

            if (infrastructure.SeeOtherTVItemID != null)
            {
                TVItem TVItemSeeOtherTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.SeeOtherTVItemID select c).FirstOrDefault();

                if (TVItemSeeOtherTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureSeeOtherTVItemID, infrastructure.SeeOtherTVItemID.ToString()), new[] { "SeeOtherTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSeeOtherTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureSeeOtherTVItemID, "Infrastructure"), new[] { "SeeOtherTVItemID" });
                    }
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureCivicAddressTVItemID, infrastructure.CivicAddressTVItemID.ToString()), new[] { "CivicAddressTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureCivicAddressTVItemID, "Infrastructure"), new[] { "CivicAddressTVItemID" });
                    }
                }
            }

            if (infrastructure.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructure.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.InfrastructureLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLastUpdateContactTVItemID, infrastructure.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureTVText) && infrastructure.InfrastructureTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureInfrastructureTVText, "200"), new[] { "InfrastructureTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.SeeOtherTVText) && infrastructure.SeeOtherTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureSeeOtherTVText, "200"), new[] { "SeeOtherTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.CivicAddressTVText) && infrastructure.CivicAddressTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureCivicAddressTVText, "200"), new[] { "CivicAddressTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.LastUpdateContactTVText) && infrastructure.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureTypeText) && infrastructure.InfrastructureTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureInfrastructureTypeText, "100"), new[] { "InfrastructureTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.FacilityTypeText) && infrastructure.FacilityTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureFacilityTypeText, "100"), new[] { "FacilityTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.AerationTypeText) && infrastructure.AerationTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureAerationTypeText, "100"), new[] { "AerationTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.PreliminaryTreatmentTypeText) && infrastructure.PreliminaryTreatmentTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructurePreliminaryTreatmentTypeText, "100"), new[] { "PreliminaryTreatmentTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.PrimaryTreatmentTypeText) && infrastructure.PrimaryTreatmentTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructurePrimaryTreatmentTypeText, "100"), new[] { "PrimaryTreatmentTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.SecondaryTreatmentTypeText) && infrastructure.SecondaryTreatmentTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureSecondaryTreatmentTypeText, "100"), new[] { "SecondaryTreatmentTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.TertiaryTreatmentTypeText) && infrastructure.TertiaryTreatmentTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureTertiaryTreatmentTypeText, "100"), new[] { "TertiaryTreatmentTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.TreatmentTypeText) && infrastructure.TreatmentTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureTreatmentTypeText, "100"), new[] { "TreatmentTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.DisinfectionTypeText) && infrastructure.DisinfectionTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureDisinfectionTypeText, "100"), new[] { "DisinfectionTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.CollectionSystemTypeText) && infrastructure.CollectionSystemTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureCollectionSystemTypeText, "100"), new[] { "CollectionSystemTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.AlarmSystemTypeText) && infrastructure.AlarmSystemTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureAlarmSystemTypeText, "100"), new[] { "AlarmSystemTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Infrastructure GetInfrastructureWithInfrastructureID(int InfrastructureID)
        {
            IQueryable<Infrastructure> infrastructureQuery = (from c in GetRead()
                                                where c.InfrastructureID == InfrastructureID
                                                select c);

            return FillInfrastructure(infrastructureQuery).FirstOrDefault();
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
            if (!db.Infrastructures.Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
            {
                infrastructure.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Infrastructures.Remove(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public bool Update(Infrastructure infrastructure)
        {
            if (!db.Infrastructures.Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
            {
                infrastructure.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString())) }.AsEnumerable();
                return false;
            }

            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Update(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public IQueryable<Infrastructure> GetRead()
        {
            return db.Infrastructures.AsNoTracking();
        }
        public IQueryable<Infrastructure> GetEdit()
        {
            return db.Infrastructures;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<Infrastructure> FillInfrastructure(IQueryable<Infrastructure> infrastructureQuery)
        {
            List<Infrastructure> InfrastructureList = (from c in infrastructureQuery
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
                                             InfrastructureTVText = InfrastructureTVText,
                                             SeeOtherTVText = SeeOtherTVText,
                                             CivicAddressTVText = CivicAddressTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (Infrastructure infrastructure in InfrastructureList)
            {
                infrastructure.InfrastructureTypeText = enums.GetEnumText_InfrastructureTypeEnum(infrastructure.InfrastructureType);
                infrastructure.FacilityTypeText = enums.GetEnumText_FacilityTypeEnum(infrastructure.FacilityType);
                infrastructure.AerationTypeText = enums.GetEnumText_AerationTypeEnum(infrastructure.AerationType);
                infrastructure.PreliminaryTreatmentTypeText = enums.GetEnumText_PreliminaryTreatmentTypeEnum(infrastructure.PreliminaryTreatmentType);
                infrastructure.PrimaryTreatmentTypeText = enums.GetEnumText_PrimaryTreatmentTypeEnum(infrastructure.PrimaryTreatmentType);
                infrastructure.SecondaryTreatmentTypeText = enums.GetEnumText_SecondaryTreatmentTypeEnum(infrastructure.SecondaryTreatmentType);
                infrastructure.TertiaryTreatmentTypeText = enums.GetEnumText_TertiaryTreatmentTypeEnum(infrastructure.TertiaryTreatmentType);
                infrastructure.TreatmentTypeText = enums.GetEnumText_TreatmentTypeEnum(infrastructure.TreatmentType);
                infrastructure.DisinfectionTypeText = enums.GetEnumText_DisinfectionTypeEnum(infrastructure.DisinfectionType);
                infrastructure.CollectionSystemTypeText = enums.GetEnumText_CollectionSystemTypeEnum(infrastructure.CollectionSystemType);
                infrastructure.AlarmSystemTypeText = enums.GetEnumText_AlarmSystemTypeEnum(infrastructure.AlarmSystemType);
            }

            return InfrastructureList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
