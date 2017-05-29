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
    public partial class RatingCurveValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueRatingCurveValueID), new[] { ModelsRes.RatingCurveValueRatingCurveValueID });
                }
            }

            //RatingCurveID (int) is required but no testing needed as it is automatically set to 0

            //StageValue_m (float) is required but no testing needed as it is automatically set to 0.0f

            //DischargeValue_m3_s (float) is required but no testing needed as it is automatically set to 0.0f

            if (ratingCurveValue.LastUpdateDate_UTC == null || ratingCurveValue.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueLastUpdateDate_UTC), new[] { ModelsRes.RatingCurveValueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (ratingCurveValue.RatingCurveID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueRatingCurveID, "1"), new[] { ModelsRes.RatingCurveValueRatingCurveID });
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000"), new[] { ModelsRes.RatingCurveValueStageValue_m });
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), new[] { ModelsRes.RatingCurveValueDischargeValue_m3_s });
            }

            if (ratingCurveValue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.RatingCurveValueLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Add(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        public bool AddRange(List<RatingCurveValue> ratingCurveValueList)
        {
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create);
                if (ratingCurveValue.ValidationResults.Count() > 0) return false;
            }

            db.RatingCurveValues.AddRange(ratingCurveValueList);

            if (!TryToSaveRange(ratingCurveValueList)) return false;

            return true;
        }
        public bool Delete(RatingCurveValue ratingCurveValue)
        {
            if (!db.RatingCurveValues.Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
            {
                ratingCurveValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString())) }.AsEnumerable();
                return false;
            }

            db.RatingCurveValues.Remove(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        public bool DeleteRange(List<RatingCurveValue> ratingCurveValueList)
        {
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                if (!db.RatingCurveValues.Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    ratingCurveValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.RatingCurveValues.RemoveRange(ratingCurveValueList);

            if (!TryToSaveRange(ratingCurveValueList)) return false;

            return true;
        }
        public bool Update(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Update(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

            return true;
        }
        public bool UpdateRange(List<RatingCurveValue> ratingCurveValueList)
        {
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update);
                if (ratingCurveValue.ValidationResults.Count() > 0) return false;
            }
            db.RatingCurveValues.UpdateRange(ratingCurveValueList);

            if (!TryToSaveRange(ratingCurveValueList)) return false;

            return true;
        }
        public IQueryable<RatingCurveValue> GetRead()
        {
            return db.RatingCurveValues.AsNoTracking();
        }
        public IQueryable<RatingCurveValue> GetEdit()
        {
            return db.RatingCurveValues;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(RatingCurveValue ratingCurveValue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurveValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<RatingCurveValue> ratingCurveValueList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurveValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
