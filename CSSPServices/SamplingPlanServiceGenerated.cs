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
    public partial class SamplingPlanService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            SamplingPlan samplingPlan = validationContext.ObjectInstance as SamplingPlan;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlan.SamplingPlanID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanID), new[] { ModelsRes.SamplingPlanSamplingPlanID });
                }
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanName), new[] { ModelsRes.SamplingPlanSamplingPlanName });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanName, "200"), new[] { ModelsRes.SamplingPlanSamplingPlanName });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanForGroupName), new[] { ModelsRes.SamplingPlanForGroupName });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanForGroupName, "100"), new[] { ModelsRes.SamplingPlanForGroupName });
            }

            retStr = enums.SampleTypeOK(samplingPlan.SampleType);
            if (samplingPlan.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSampleType), new[] { ModelsRes.SamplingPlanSampleType });
            }

            retStr = enums.SamplingPlanTypeOK(samplingPlan.SamplingPlanType);
            if (samplingPlan.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanType), new[] { ModelsRes.SamplingPlanSamplingPlanType });
            }

            retStr = enums.LabSheetTypeOK(samplingPlan.LabSheetType);
            if (samplingPlan.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLabSheetType), new[] { ModelsRes.SamplingPlanLabSheetType });
            }

            //ProvinceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.ProvinceTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanProvinceTVItemID, "1"), new[] { ModelsRes.SamplingPlanProvinceTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlan.ProvinceTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanProvinceTVItemID, samplingPlan.ProvinceTVItemID.ToString()), new[] { ModelsRes.SamplingPlanProvinceTVItemID });
            }

            //CreatorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.CreatorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanCreatorTVItemID, "1"), new[] { ModelsRes.SamplingPlanCreatorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlan.CreatorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanCreatorTVItemID, samplingPlan.CreatorTVItemID.ToString()), new[] { ModelsRes.SamplingPlanCreatorTVItemID });
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050"), new[] { ModelsRes.SamplingPlanYear });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanAccessCode), new[] { ModelsRes.SamplingPlanAccessCode });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanAccessCode, "15"), new[] { ModelsRes.SamplingPlanAccessCode });
            }

            //DailyDuplicatePrecisionCriteria (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), new[] { ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria });
            }

            //IntertechDuplicatePrecisionCriteria (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria });
            }

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (samplingPlan.SamplingPlanFileTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, "1"), new[] { ModelsRes.SamplingPlanSamplingPlanFileTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, samplingPlan.SamplingPlanFileTVItemID.ToString()), new[] { ModelsRes.SamplingPlanSamplingPlanFileTVItemID });
            }

            if (samplingPlan.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLastUpdateDate_UTC), new[] { ModelsRes.SamplingPlanLastUpdateDate_UTC });
            }

            if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SamplingPlanLastUpdateDate_UTC, "1980"), new[] { ModelsRes.SamplingPlanLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SamplingPlanLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanLastUpdateContactTVItemID, samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.SamplingPlanLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(SamplingPlan samplingPlan)
        {
            samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create);
            if (samplingPlan.ValidationResults.Count() > 0) return false;

            db.SamplingPlans.Add(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool AddRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create);
                if (samplingPlan.ValidationResults.Count() > 0) return false;
            }

            db.SamplingPlans.AddRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

            return true;
        }
        public bool Delete(SamplingPlan samplingPlan)
        {
            if (!db.SamplingPlans.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
            {
                samplingPlan.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SamplingPlans.Remove(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool DeleteRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                if (!db.SamplingPlans.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    samplingPlanList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.SamplingPlans.RemoveRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

            return true;
        }
        public bool Update(SamplingPlan samplingPlan)
        {
            samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update);
            if (samplingPlan.ValidationResults.Count() > 0) return false;

            db.SamplingPlans.Update(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool UpdateRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update);
                if (samplingPlan.ValidationResults.Count() > 0) return false;
            }
            db.SamplingPlans.UpdateRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

            return true;
        }
        public IQueryable<SamplingPlan> GetRead()
        {
            return db.SamplingPlans.AsNoTracking();
        }
        public IQueryable<SamplingPlan> GetEdit()
        {
            return db.SamplingPlans;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(SamplingPlan samplingPlan)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlan.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<SamplingPlan> samplingPlanList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
