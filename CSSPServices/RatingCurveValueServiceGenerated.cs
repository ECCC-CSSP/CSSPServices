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
        #endregion Properties

        #region Constructors
        public RatingCurveValueService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueRatingCurveValueID), new[] { "RatingCurveValueID" });
                }
            }

            //RatingCurveValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //RatingCurveID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            RatingCurve RatingCurveRatingCurveID = (from c in db.RatingCurves where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.RatingCurve, ModelsRes.RatingCurveValueRatingCurveID, ratingCurveValue.RatingCurveID.ToString()), new[] { "RatingCurveID" });
            }

            //StageValue_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000"), new[] { "StageValue_m" });
            }

            //DischargeValue_m3_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), new[] { "DischargeValue_m3_s" });
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RatingCurveValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(ratingCurveValue.LastUpdateContactTVText) && ratingCurveValue.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveValueLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RatingCurveValue GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            IQueryable<RatingCurveValue> ratingCurveValueQuery = (from c in GetRead()
                                                where c.RatingCurveValueID == RatingCurveValueID
                                                select c);

            return FillRatingCurveValue(ratingCurveValueQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(RatingCurveValue ratingCurveValue)
        {
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Create);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Add(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

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
        public bool Update(RatingCurveValue ratingCurveValue)
        {
            if (!db.RatingCurveValues.Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
            {
                ratingCurveValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString())) }.AsEnumerable();
                return false;
            }

            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Update);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Update(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<RatingCurveValue> FillRatingCurveValue(IQueryable<RatingCurveValue> ratingCurveValueQuery)
        {
            List<RatingCurveValue> RatingCurveValueList = (from c in ratingCurveValueQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new RatingCurveValue
                                         {
                                             RatingCurveValueID = c.RatingCurveValueID,
                                             RatingCurveID = c.RatingCurveID,
                                             StageValue_m = c.StageValue_m,
                                             DischargeValue_m3_s = c.DischargeValue_m3_s,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return RatingCurveValueList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
