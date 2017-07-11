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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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

            //InfrastructureTVItemID has no Range Attribute

                //Error: Type not implemented [VPScenarioStatus] of type [ScenarioStatusEnum]

                //Error: Type not implemented [VPScenarioStatus] of type [ScenarioStatusEnum]
            //UseAsBestEstimate (bool) is required but no testing needed 

            //EffluentFlow_m3_s (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EffluentFlow_m3_s has no Range Attribute

            //EffluentConcentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EffluentConcentration_MPN_100ml has no Range Attribute

            //FroudeNumber (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FroudeNumber has no Range Attribute

            //PortDiameter_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PortDiameter_m has no Range Attribute

            //PortDepth_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PortDepth_m has no Range Attribute

            //PortElevation_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PortElevation_m has no Range Attribute

            //VerticalAngle_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VerticalAngle_deg has no Range Attribute

            //HorizontalAngle_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HorizontalAngle_deg has no Range Attribute

            //NumberOfPorts (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //NumberOfPorts has no Range Attribute

            //PortSpacing_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PortSpacing_m has no Range Attribute

            //AcuteMixZone_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AcuteMixZone_m has no Range Attribute

            //ChronicMixZone_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ChronicMixZone_m has no Range Attribute

            //EffluentSalinity_PSU (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EffluentSalinity_PSU has no Range Attribute

            //EffluentTemperature_C (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EffluentTemperature_C has no Range Attribute

            //EffluentVelocity_m_s (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EffluentVelocity_m_s has no Range Attribute

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
