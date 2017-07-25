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
    public partial class VPScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenario vpScenario = validationContext.ObjectInstance as VPScenario;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (vpScenario.VPScenarioID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioID), new[] { ModelsRes.VPScenarioVPScenarioID });
                }
            }

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.InfrastructureTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioInfrastructureTVItemID, "1"), new[] { ModelsRes.VPScenarioInfrastructureTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioInfrastructureTVItemID, vpScenario.InfrastructureTVItemID.ToString()), new[] { ModelsRes.VPScenarioInfrastructureTVItemID });
            }

            retStr = enums.ScenarioStatusOK(vpScenario.VPScenarioStatus);
            if (vpScenario.VPScenarioStatus == ScenarioStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioStatus), new[] { ModelsRes.VPScenarioVPScenarioStatus });
            }

            //UseAsBestEstimate (bool) is required but no testing needed 

            //EffluentFlow_m3_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentFlow_m3_s < 0 || vpScenario.EffluentFlow_m3_s > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), new[] { ModelsRes.VPScenarioEffluentFlow_m3_s });
            }

            //EffluentConcentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentConcentration_MPN_100ml < 0 || vpScenario.EffluentConcentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), new[] { ModelsRes.VPScenarioEffluentConcentration_MPN_100ml });
            }

            //FroudeNumber (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.FroudeNumber < 0 || vpScenario.FroudeNumber > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "10000"), new[] { ModelsRes.VPScenarioFroudeNumber });
            }

            //PortDiameter_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortDiameter_m < 0 || vpScenario.PortDiameter_m > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "10"), new[] { ModelsRes.VPScenarioPortDiameter_m });
            }

            //PortDepth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortDepth_m < 0 || vpScenario.PortDepth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000"), new[] { ModelsRes.VPScenarioPortDepth_m });
            }

            //PortElevation_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortElevation_m < 0 || vpScenario.PortElevation_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000"), new[] { ModelsRes.VPScenarioPortElevation_m });
            }

            //VerticalAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.VerticalAngle_deg < -90 || vpScenario.VerticalAngle_deg > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), new[] { ModelsRes.VPScenarioVerticalAngle_deg });
            }

            //HorizontalAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.HorizontalAngle_deg < -180 || vpScenario.HorizontalAngle_deg > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), new[] { ModelsRes.VPScenarioHorizontalAngle_deg });
            }

            //NumberOfPorts (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.NumberOfPorts < 1 || vpScenario.NumberOfPorts > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100"), new[] { ModelsRes.VPScenarioNumberOfPorts });
            }

            //PortSpacing_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortSpacing_m < 0 || vpScenario.PortSpacing_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000"), new[] { ModelsRes.VPScenarioPortSpacing_m });
            }

            //AcuteMixZone_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.AcuteMixZone_m < 0 || vpScenario.AcuteMixZone_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), new[] { ModelsRes.VPScenarioAcuteMixZone_m });
            }

            //ChronicMixZone_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.ChronicMixZone_m < 0 || vpScenario.ChronicMixZone_m > 40000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), new[] { ModelsRes.VPScenarioChronicMixZone_m });
            }

            //EffluentSalinity_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentSalinity_PSU < 0 || vpScenario.EffluentSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), new[] { ModelsRes.VPScenarioEffluentSalinity_PSU });
            }

            //EffluentTemperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentTemperature_C < -10 || vpScenario.EffluentTemperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), new[] { ModelsRes.VPScenarioEffluentTemperature_C });
            }

            //EffluentVelocity_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentVelocity_m_s < 0 || vpScenario.EffluentVelocity_m_s > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), new[] { ModelsRes.VPScenarioEffluentVelocity_m_s });
            }

            if (string.IsNullOrWhiteSpace(vpScenario.RawResults))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioRawResults), new[] { ModelsRes.VPScenarioRawResults });
            }

            //RawResults has no StringLength Attribute

            if (vpScenario.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLastUpdateDate_UTC), new[] { ModelsRes.VPScenarioLastUpdateDate_UTC });
            }

            if (vpScenario.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPScenarioLastUpdateDate_UTC, "1980"), new[] { ModelsRes.VPScenarioLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPScenarioLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioLastUpdateContactTVItemID, vpScenario.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.VPScenarioLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Create);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Add(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public bool AddRange(List<VPScenario> vpScenarioList)
        {
            foreach (VPScenario vpScenario in vpScenarioList)
            {
                vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Create);
                if (vpScenario.ValidationResults.Count() > 0) return false;
            }

            db.VPScenarios.AddRange(vpScenarioList);

            if (!TryToSaveRange(vpScenarioList)) return false;

            return true;
        }
        public bool Delete(VPScenario vpScenario)
        {
            if (!db.VPScenarios.Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
            {
                vpScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenario.VPScenarioID.ToString())) }.AsEnumerable();
                return false;
            }

            db.VPScenarios.Remove(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public bool DeleteRange(List<VPScenario> vpScenarioList)
        {
            foreach (VPScenario vpScenario in vpScenarioList)
            {
                if (!db.VPScenarios.Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
                {
                    vpScenarioList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpScenario.VPScenarioID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.VPScenarios.RemoveRange(vpScenarioList);

            if (!TryToSaveRange(vpScenarioList)) return false;

            return true;
        }
        public bool Update(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Update);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Update(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public bool UpdateRange(List<VPScenario> vpScenarioList)
        {
            foreach (VPScenario vpScenario in vpScenarioList)
            {
                vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Update);
                if (vpScenario.ValidationResults.Count() > 0) return false;
            }
            db.VPScenarios.UpdateRange(vpScenarioList);

            if (!TryToSaveRange(vpScenarioList)) return false;

            return true;
        }
        public IQueryable<VPScenario> GetRead()
        {
            return db.VPScenarios.AsNoTracking();
        }
        public IQueryable<VPScenario> GetEdit()
        {
            return db.VPScenarios;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(VPScenario vpScenario)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<VPScenario> vpScenarioList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenarioList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
