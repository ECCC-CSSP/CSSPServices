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
        #endregion Properties

        #region Constructors
        public RatingCurveService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurve ratingCurve = validationContext.ObjectInstance as RatingCurve;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (ratingCurve.RatingCurveID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveID), new[] { ModelsRes.RatingCurveRatingCurveID });
                }
            }

            //RatingCurveID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (ratingCurve.HydrometricSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveHydrometricSiteID, "1"), new[] { ModelsRes.RatingCurveHydrometricSiteID });
            }

            if (!((from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), new[] { ModelsRes.RatingCurveHydrometricSiteID });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveNumber), new[] { ModelsRes.RatingCurveRatingCurveNumber });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveRatingCurveNumber, "50"), new[] { ModelsRes.RatingCurveRatingCurveNumber });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveLastUpdateDate_UTC), new[] { ModelsRes.RatingCurveLastUpdateDate_UTC });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RatingCurveLastUpdateDate_UTC, "1980"), new[] { ModelsRes.RatingCurveLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (ratingCurve.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveLastUpdateContactTVItemID, "1"), new[] { ModelsRes.RatingCurveLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.RatingCurveLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
