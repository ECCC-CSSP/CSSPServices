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
        public RatingCurveValueService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveValueRatingCurveValueID), new[] { "RatingCurveValueID" });
                }

                if (!GetRead().Where(c => c.RatingCurveValueID == ratingCurveValue.RatingCurveValueID).Any())
                {
                    ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurveValue, CSSPModelsRes.RatingCurveValueRatingCurveValueID, ratingCurveValue.RatingCurveValueID.ToString()), new[] { "RatingCurveValueID" });
                }
            }

            RatingCurve RatingCurveRatingCurveID = (from c in db.RatingCurves where c.RatingCurveID == ratingCurveValue.RatingCurveID select c).FirstOrDefault();

            if (RatingCurveRatingCurveID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurve, CSSPModelsRes.RatingCurveValueRatingCurveID, ratingCurveValue.RatingCurveID.ToString()), new[] { "RatingCurveID" });
            }

            if (ratingCurveValue.StageValue_m < 0 || ratingCurveValue.StageValue_m > 1000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueStageValue_m, "0", "1000"), new[] { "StageValue_m" });
            }

            if (ratingCurveValue.DischargeValue_m3_s < 0 || ratingCurveValue.DischargeValue_m3_s > 1000000)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), new[] { "DischargeValue_m3_s" });
            }

            if (ratingCurveValue.LastUpdateDate_UTC.Year == 1)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurveValue.LastUpdateDate_UTC.Year < 1980)
                {
                ratingCurveValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RatingCurveValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurveValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ratingCurveValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<RatingCurveValue> ratingCurveValueQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.RatingCurveValueID == RatingCurveValueID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return ratingCurveValueQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillRatingCurveValueWeb(ratingCurveValueQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillRatingCurveValueReport(ratingCurveValueQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<RatingCurveValue> GetRatingCurveValueList()
        {
            IQueryable<RatingCurveValue> ratingCurveValueQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        ratingCurveValueQuery = EnhanceQueryStatements<RatingCurveValue>(ratingCurveValueQuery) as IQueryable<RatingCurveValue>;

                        return ratingCurveValueQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        ratingCurveValueQuery = FillRatingCurveValueWeb(ratingCurveValueQuery);

                        ratingCurveValueQuery = EnhanceQueryStatements<RatingCurveValue>(ratingCurveValueQuery) as IQueryable<RatingCurveValue>;

                        return ratingCurveValueQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        ratingCurveValueQuery = FillRatingCurveValueReport(ratingCurveValueQuery);

                        ratingCurveValueQuery = EnhanceQueryStatements<RatingCurveValue>(ratingCurveValueQuery) as IQueryable<RatingCurveValue>;

                        return ratingCurveValueQuery;
                    }
                default:
                    {
                        ratingCurveValueQuery = ratingCurveValueQuery.Where(c => c.RatingCurveValueID == 0);

                        return ratingCurveValueQuery;
                    }
            }
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
        public IQueryable<RatingCurveValue> GetRead()
        {
            IQueryable<RatingCurveValue> ratingCurveValueQuery = db.RatingCurveValues.AsNoTracking();

            return ratingCurveValueQuery;
        }
        public IQueryable<RatingCurveValue> GetEdit()
        {
            IQueryable<RatingCurveValue> ratingCurveValueQuery = db.RatingCurveValues;

            return ratingCurveValueQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated RatingCurveValueFillWeb
        private IQueryable<RatingCurveValue> FillRatingCurveValueWeb(IQueryable<RatingCurveValue> ratingCurveValueQuery)
        {
            ratingCurveValueQuery = (from c in ratingCurveValueQuery
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
                        RatingCurveValueWeb = new RatingCurveValueWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        RatingCurveValueReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return ratingCurveValueQuery;
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
