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
    ///     <para>bonjour RatingCurve</para>
    /// </summary>
    public partial class RatingCurveService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurve ratingCurve = validationContext.ObjectInstance as RatingCurve;
            ratingCurve.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurve.RatingCurveID == 0)
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveID"), new[] { "RatingCurveID" });
                }

                if (!(from c in db.RatingCurves select c).Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveRatingCurveID", ratingCurve.RatingCurveID.ToString()), new[] { "RatingCurveID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "RatingCurveHydrometricSiteID", ratingCurve.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveNumber"), new[] { "RatingCurveNumber" });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RatingCurveRatingCurveNumber", "50"), new[] { "RatingCurveNumber" });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RatingCurveLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RatingCurveLastUpdateContactTVItemID", ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "RatingCurveLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RatingCurve GetRatingCurveWithRatingCurveID(int RatingCurveID)
        {
            return (from c in db.RatingCurves
                    where c.RatingCurveID == RatingCurveID
                    select c).FirstOrDefault();

        }
        public IQueryable<RatingCurve> GetRatingCurveList()
        {
            IQueryable<RatingCurve> RatingCurveQuery = (from c in db.RatingCurves select c);

            RatingCurveQuery = EnhanceQueryStatements<RatingCurve>(RatingCurveQuery) as IQueryable<RatingCurve>;

            return RatingCurveQuery;
        }
        public RatingCurveWeb GetRatingCurveWebWithRatingCurveID(int RatingCurveID)
        {
            return FillRatingCurveWeb().Where(c => c.RatingCurveID == RatingCurveID).FirstOrDefault();

        }
        public IQueryable<RatingCurveWeb> GetRatingCurveWebList()
        {
            IQueryable<RatingCurveWeb> RatingCurveWebQuery = FillRatingCurveWeb();

            RatingCurveWebQuery = EnhanceQueryStatements<RatingCurveWeb>(RatingCurveWebQuery) as IQueryable<RatingCurveWeb>;

            return RatingCurveWebQuery;
        }
        public RatingCurveReport GetRatingCurveReportWithRatingCurveID(int RatingCurveID)
        {
            return FillRatingCurveReport().Where(c => c.RatingCurveID == RatingCurveID).FirstOrDefault();

        }
        public IQueryable<RatingCurveReport> GetRatingCurveReportList()
        {
            IQueryable<RatingCurveReport> RatingCurveReportQuery = FillRatingCurveReport();

            RatingCurveReportQuery = EnhanceQueryStatements<RatingCurveReport>(RatingCurveReportQuery) as IQueryable<RatingCurveReport>;

            return RatingCurveReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Add(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        public bool Delete(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Delete);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Remove(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated RatingCurveFillWeb
        private IQueryable<RatingCurveWeb> FillRatingCurveWeb()
        {
             IQueryable<RatingCurveWeb> RatingCurveWebQuery = (from c in db.RatingCurves
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new RatingCurveWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        RatingCurveID = c.RatingCurveID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        RatingCurveNumber = c.RatingCurveNumber,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RatingCurveWebQuery;
        }
        #endregion Functions private Generated RatingCurveFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
