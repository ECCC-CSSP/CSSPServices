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
    public partial class SamplingPlanSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), new[] { ModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID });
                }
            }

            //SamplingPlanSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsector.SamplingPlanID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSamplingPlanID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSamplingPlanID });
            }

            if (!((from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorSamplingPlanID });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsector.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSubsectorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorSubsectorTVItemID });
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC), new[] { ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC });
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC, "1980"), new[] { ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsector.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Add(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool AddRange(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
            foreach (SamplingPlanSubsector samplingPlanSubsector in samplingPlanSubsectorList)
            {
                samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
                if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;
            }

            db.SamplingPlanSubsectors.AddRange(samplingPlanSubsectorList);

            if (!TryToSaveRange(samplingPlanSubsectorList)) return false;

            return true;
        }
        public bool Delete(SamplingPlanSubsector samplingPlanSubsector)
        {
            if (!db.SamplingPlanSubsectors.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool DeleteRange(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
            foreach (SamplingPlanSubsector samplingPlanSubsector in samplingPlanSubsectorList)
            {
                if (!db.SamplingPlanSubsectors.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    samplingPlanSubsectorList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.SamplingPlanSubsectors.RemoveRange(samplingPlanSubsectorList);

            if (!TryToSaveRange(samplingPlanSubsectorList)) return false;

            return true;
        }
        public bool Update(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Update(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool UpdateRange(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
            foreach (SamplingPlanSubsector samplingPlanSubsector in samplingPlanSubsectorList)
            {
                samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
                if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;
            }
            db.SamplingPlanSubsectors.UpdateRange(samplingPlanSubsectorList);

            if (!TryToSaveRange(samplingPlanSubsectorList)) return false;

            return true;
        }
        public IQueryable<SamplingPlanSubsector> GetRead()
        {
            return db.SamplingPlanSubsectors.AsNoTracking();
        }
        public IQueryable<SamplingPlanSubsector> GetEdit()
        {
            return db.SamplingPlanSubsectors;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(SamplingPlanSubsector samplingPlanSubsector)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsectorList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
