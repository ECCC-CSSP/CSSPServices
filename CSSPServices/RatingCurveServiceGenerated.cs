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
    public partial class RatingCurveService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            RatingCurve ratingCurve = validationContext.ObjectInstance as RatingCurve;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (ratingCurve.RatingCurveID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveID), new[] { ModelsRes.RatingCurveRatingCurveID });
                }
            }

            //HydrometricSiteID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveNumber), new[] { ModelsRes.RatingCurveRatingCurveNumber });
            }

            if (ratingCurve.LastUpdateDate_UTC == null || ratingCurve.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveLastUpdateDate_UTC), new[] { ModelsRes.RatingCurveLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (ratingCurve.HydrometricSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveHydrometricSiteID, "1"), new[] { ModelsRes.RatingCurveHydrometricSiteID });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveRatingCurveNumber, "50"), new[] { ModelsRes.RatingCurveRatingCurveNumber });
            }

            if (ratingCurve.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveLastUpdateContactTVItemID, "1"), new[] { ModelsRes.RatingCurveLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Add(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        public bool AddRange(List<RatingCurve> ratingCurveList)
        {
            foreach (RatingCurve ratingCurve in ratingCurveList)
            {
                ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
                if (ratingCurve.ValidationResults.Count() > 0) return false;
            }

            db.RatingCurves.AddRange(ratingCurveList);

            if (!TryToSaveRange(ratingCurveList)) return false;

            return true;
        }
        public bool Delete(RatingCurve ratingCurve)
        {
            if (!db.RatingCurves.Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
            {
                ratingCurve.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString())) }.AsEnumerable();
                return false;
            }

            db.RatingCurves.Remove(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        public bool DeleteRange(List<RatingCurve> ratingCurveList)
        {
            foreach (RatingCurve ratingCurve in ratingCurveList)
            {
                if (!db.RatingCurves.Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                {
                    ratingCurveList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.RatingCurves.RemoveRange(ratingCurveList);

            if (!TryToSaveRange(ratingCurveList)) return false;

            return true;
        }
        public bool Update(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Update(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        public bool UpdateRange(List<RatingCurve> ratingCurveList)
        {
            foreach (RatingCurve ratingCurve in ratingCurveList)
            {
                ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
                if (ratingCurve.ValidationResults.Count() > 0) return false;
            }
            db.RatingCurves.UpdateRange(ratingCurveList);

            if (!TryToSaveRange(ratingCurveList)) return false;

            return true;
        }
        public IQueryable<RatingCurve> GetRead()
        {
            return db.RatingCurves.AsNoTracking();
        }
        public IQueryable<RatingCurve> GetEdit()
        {
            return db.RatingCurves;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(RatingCurve ratingCurve)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurve.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<RatingCurve> ratingCurveList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurveList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
