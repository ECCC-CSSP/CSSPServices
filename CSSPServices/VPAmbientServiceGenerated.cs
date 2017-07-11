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
    public partial class VPAmbientService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;

            //VPAmbientID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPAmbientID has no Range Attribute

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioID has no Range Attribute

            //Row (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Row has no Range Attribute

            //MeasurementDepth_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MeasurementDepth_m has no Range Attribute

            //CurrentSpeed_m_s (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CurrentSpeed_m_s has no Range Attribute

            //CurrentDirection_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CurrentDirection_deg has no Range Attribute

            //AmbientSalinity_PSU (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AmbientSalinity_PSU has no Range Attribute

            //AmbientTemperature_C (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AmbientTemperature_C has no Range Attribute

            //BackgroundConcentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BackgroundConcentration_MPN_100ml has no Range Attribute

            //PollutantDecayRate_per_day (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PollutantDecayRate_per_day has no Range Attribute

            //FarFieldCurrentSpeed_m_s (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FarFieldCurrentSpeed_m_s has no Range Attribute

            //FarFieldCurrentDirection_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FarFieldCurrentDirection_deg has no Range Attribute

            //FarFieldDiffusionCoefficient (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FarFieldDiffusionCoefficient has no Range Attribute

            if (vpAmbient.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientLastUpdateDate_UTC), new[] { ModelsRes.VPAmbientLastUpdateDate_UTC });
            }

            if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPAmbientLastUpdateDate_UTC, "1980"), new[] { ModelsRes.VPAmbientLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPAmbientLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPAmbientLastUpdateContactTVItemID, vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.VPAmbientLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Add(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool AddRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
                if (vpAmbient.ValidationResults.Count() > 0) return false;
            }

            db.VPAmbients.AddRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public bool Delete(VPAmbient vpAmbient)
        {
            if (!db.VPAmbients.Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
            {
                vpAmbient.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString())) }.AsEnumerable();
                return false;
            }

            db.VPAmbients.Remove(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool DeleteRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                if (!db.VPAmbients.Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                {
                    vpAmbientList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.VPAmbients.RemoveRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public bool Update(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Update(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool UpdateRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
                if (vpAmbient.ValidationResults.Count() > 0) return false;
            }
            db.VPAmbients.UpdateRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public IQueryable<VPAmbient> GetRead()
        {
            return db.VPAmbients.AsNoTracking();
        }
        public IQueryable<VPAmbient> GetEdit()
        {
            return db.VPAmbients;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(VPAmbient vpAmbient)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpAmbient.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<VPAmbient> vpAmbientList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpAmbientList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
