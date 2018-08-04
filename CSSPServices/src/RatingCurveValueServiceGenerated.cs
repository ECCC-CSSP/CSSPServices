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
    /// <summary>
    ///     <para>bonjour RatingCurveValue</para>
    /// </summary>
    public partial class RatingCurveValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveValueService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurveValue ratingCurveValue = validationContext.ObjectInstance as RatingCurveValue;
            ratingCurveValue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurveValue.RatingCurveValueID == 0)
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveValueRatingCurveValueID"), new[] { "RatingCurveValueID" });
                }

                if (!(from c in db.RatingCurveValues select c).Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueRatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString()), new[] { "RatingCurveValueID" });
                }
            }

            RatingCurve RatingCurveRatingCurveID = (from c in db.RatingCurves where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveValueRatingCurveID", ratingCurveValue.RatingCurveID.ToString()), new[] { "RatingCurveID" });
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueStageValue_m", "0", "1000"), new[] { "StageValue_m" });
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueDischargeValue_m3_s", "0", "1000000"), new[] { "DischargeValue_m3_s" });
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveValueLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RatingCurveValueLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RatingCurveValueLastUpdateContactTVItemID", ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "RatingCurveValueLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RatingCurveValue GetRatingCurveValueWithRatingCurveValueID(int RatingCurveValueID)
        {
            return (from c in db.RatingCurveValues
                    where c.RatingCurveValueID == RatingCurveValueID
                    select c).FirstOrDefault();

        }
        public IQueryable<RatingCurveValue> GetRatingCurveValueList()
        {
            IQueryable<RatingCurveValue> RatingCurveValueQuery = (from c in db.RatingCurveValues select c);

            RatingCurveValueQuery = EnhanceQueryStatements<RatingCurveValue>(RatingCurveValueQuery) as IQueryable<RatingCurveValue>;

            return RatingCurveValueQuery;
        }
        public RatingCurveValueWeb GetRatingCurveValueWebWithRatingCurveValueID(int RatingCurveValueID)
        {
            return FillRatingCurveValueWeb().Where(c => c.RatingCurveValueID == RatingCurveValueID).FirstOrDefault();

        }
        public IQueryable<RatingCurveValueWeb> GetRatingCurveValueWebList()
        {
            IQueryable<RatingCurveValueWeb> RatingCurveValueWebQuery = FillRatingCurveValueWeb();

            RatingCurveValueWebQuery = EnhanceQueryStatements<RatingCurveValueWeb>(RatingCurveValueWebQuery) as IQueryable<RatingCurveValueWeb>;

            return RatingCurveValueWebQuery;
        }
        public RatingCurveValueReport GetRatingCurveValueReportWithRatingCurveValueID(int RatingCurveValueID)
        {
            return FillRatingCurveValueReport().Where(c => c.RatingCurveValueID == RatingCurveValueID).FirstOrDefault();

        }
        public IQueryable<RatingCurveValueReport> GetRatingCurveValueReportList()
        {
            IQueryable<RatingCurveValueReport> RatingCurveValueReportQuery = FillRatingCurveValueReport();

            RatingCurveValueReportQuery = EnhanceQueryStatements<RatingCurveValueReport>(RatingCurveValueReportQuery) as IQueryable<RatingCurveValueReport>;

            return RatingCurveValueReportQuery;
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
            ratingCurveValue.ValidationResults = Validate(new ValidationContext(ratingCurveValue), ActionDBTypeEnum.Delete);
            if (ratingCurveValue.ValidationResults.Count() > 0) return false;

            db.RatingCurveValues.Remove(ratingCurveValue);

            if (!TryToSave(ratingCurveValue)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated RatingCurveValueFillWeb
        private IQueryable<RatingCurveValueWeb> FillRatingCurveValueWeb()
        {
             IQueryable<RatingCurveValueWeb>  RatingCurveValueWebQuery = (from c in db.RatingCurveValues
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new RatingCurveValueWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        RatingCurveValueID = c.RatingCurveValueID,
                        RatingCurveID = c.RatingCurveID,
                        StageValue_m = c.StageValue_m,
                        DischargeValue_m3_s = c.DischargeValue_m3_s,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RatingCurveValueWebQuery;
        }
        #endregion Functions private Generated RatingCurveValueFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
