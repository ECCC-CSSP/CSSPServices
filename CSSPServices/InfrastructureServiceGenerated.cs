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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureInfrastructureID), new[] { ModelsRes.InfrastructureInfrastructureID });
                }
            }

            //InfrastructureID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (infrastructure.InfrastructureTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureInfrastructureTVItemID, "1"), new[] { ModelsRes.InfrastructureInfrastructureTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureInfrastructureTVItemID, infrastructure.InfrastructureTVItemID.ToString()), new[] { ModelsRes.InfrastructureInfrastructureTVItemID });
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePrismID, "0", "100000"), new[] { ModelsRes.InfrastructurePrismID });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTPID, "0", "100000"), new[] { ModelsRes.InfrastructureTPID });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureLSID, "0", "100000"), new[] { ModelsRes.InfrastructureLSID });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSiteID, "0", "100000"), new[] { ModelsRes.InfrastructureSiteID });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureSite, "0", "100000"), new[] { ModelsRes.InfrastructureSite });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.InfrastructureInfrastructureCategory, "1", "1"), new[] { ModelsRes.InfrastructureInfrastructureCategory });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.InfrastructureTypeOK(infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == InfrastructureTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureInfrastructureType });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.FacilityTypeOK(infrastructure.FacilityType);
                if (infrastructure.FacilityType == FacilityTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureFacilityType });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfCells, "0", "10"), new[] { ModelsRes.InfrastructureNumberOfCells });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfAeratedCells, "0", "10"), new[] { ModelsRes.InfrastructureNumberOfAeratedCells });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.AerationTypeOK(infrastructure.AerationType);
                if (infrastructure.AerationType == AerationTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureAerationType });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.PreliminaryTreatmentTypeOK(infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == PreliminaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructurePreliminaryTreatmentType });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.PrimaryTreatmentTypeOK(infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == PrimaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructurePrimaryTreatmentType });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.SecondaryTreatmentTypeOK(infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == SecondaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureSecondaryTreatmentType });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.TertiaryTreatmentTypeOK(infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == TertiaryTreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureTertiaryTreatmentType });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.TreatmentTypeOK(infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == TreatmentTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureTreatmentType });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.DisinfectionTypeOK(infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == DisinfectionTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureDisinfectionType });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.CollectionSystemTypeOK(infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == CollectionSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureCollectionSystemType });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.AlarmSystemTypeOK(infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == AlarmSystemTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.InfrastructureAlarmSystemType });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDesignFlow_m3_day, "0", "1000000"), new[] { ModelsRes.InfrastructureDesignFlow_m3_day });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageFlow_m3_day, "0", "1000000"), new[] { ModelsRes.InfrastructureAverageFlow_m3_day });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePeakFlow_m3_day, "0", "1000000"), new[] { ModelsRes.InfrastructurePeakFlow_m3_day });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePopServed, "0", "1000000"), new[] { ModelsRes.InfrastructurePopServed });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePercFlowOfTotal, "0", "100"), new[] { ModelsRes.InfrastructurePercFlowOfTotal });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureTimeOffset_hour, "-10", "0"), new[] { ModelsRes.InfrastructureTimeOffset_hour });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureAverageDepth_m, "0", "1000"), new[] { ModelsRes.InfrastructureAverageDepth_m });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNumberOfPorts, "1", "1000"), new[] { ModelsRes.InfrastructureNumberOfPorts });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortDiameter_m, "0", "10"), new[] { ModelsRes.InfrastructurePortDiameter_m });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortSpacing_m, "0", "10000"), new[] { ModelsRes.InfrastructurePortSpacing_m });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructurePortElevation_m, "0", "1000"), new[] { ModelsRes.InfrastructurePortElevation_m });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureVerticalAngle_deg, "-90", "90"), new[] { ModelsRes.InfrastructureVerticalAngle_deg });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureHorizontalAngle_deg, "-180", "180"), new[] { ModelsRes.InfrastructureHorizontalAngle_deg });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDecayRate_per_day, "0", "100"), new[] { ModelsRes.InfrastructureDecayRate_per_day });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureNearFieldVelocity_m_s, "0", "10"), new[] { ModelsRes.InfrastructureNearFieldVelocity_m_s });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureFarFieldVelocity_m_s, "0", "10"), new[] { ModelsRes.InfrastructureFarFieldVelocity_m_s });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterSalinity_PSU, "0", "40"), new[] { ModelsRes.InfrastructureReceivingWaterSalinity_PSU });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWaterTemperature_C, "-10", "40"), new[] { ModelsRes.InfrastructureReceivingWaterTemperature_C });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureReceivingWater_MPN_per_100ml, "0", "10000000"), new[] { ModelsRes.InfrastructureReceivingWater_MPN_per_100ml });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.InfrastructureDistanceFromShore_m, "0", "1000"), new[] { ModelsRes.InfrastructureDistanceFromShore_m });
                }
            }

            if (infrastructure.SeeOtherTVItemID != null)
            {
                if (infrastructure.SeeOtherTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureSeeOtherTVItemID, "1"), new[] { ModelsRes.InfrastructureSeeOtherTVItemID });
                }
            }

            if (infrastructure.SeeOtherTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == infrastructure.SeeOtherTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureSeeOtherTVItemID, infrastructure.SeeOtherTVItemID.ToString()), new[] { ModelsRes.InfrastructureSeeOtherTVItemID });
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                if (infrastructure.CivicAddressTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureCivicAddressTVItemID, "1"), new[] { ModelsRes.InfrastructureCivicAddressTVItemID });
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureCivicAddressTVItemID, infrastructure.CivicAddressTVItemID.ToString()), new[] { ModelsRes.InfrastructureCivicAddressTVItemID });
                }
            }

            if (infrastructure.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLastUpdateDate_UTC), new[] { ModelsRes.InfrastructureLastUpdateDate_UTC });
            }

            if (infrastructure.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.InfrastructureLastUpdateDate_UTC, "1980"), new[] { ModelsRes.InfrastructureLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (infrastructure.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLastUpdateContactTVItemID, "1"), new[] { ModelsRes.InfrastructureLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLastUpdateContactTVItemID, infrastructure.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.InfrastructureLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Add(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        public bool AddRange(List<Infrastructure> infrastructureList)
        {
            foreach (Infrastructure infrastructure in infrastructureList)
            {
                infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
                if (infrastructure.ValidationResults.Count() > 0) return false;
            }

            db.Infrastructures.AddRange(infrastructureList);

            if (!TryToSaveRange(infrastructureList)) return false;

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
        public bool DeleteRange(List<Infrastructure> infrastructureList)
        {
            foreach (Infrastructure infrastructure in infrastructureList)
            {
                if (!db.Infrastructures.Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                {
                    infrastructureList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Infrastructures.RemoveRange(infrastructureList);

            if (!TryToSaveRange(infrastructureList)) return false;

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
        public bool UpdateRange(List<Infrastructure> infrastructureList)
        {
            foreach (Infrastructure infrastructure in infrastructureList)
            {
                infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
                if (infrastructure.ValidationResults.Count() > 0) return false;
            }
            db.Infrastructures.UpdateRange(infrastructureList);

            if (!TryToSaveRange(infrastructureList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<Infrastructure> infrastructureList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructureList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
