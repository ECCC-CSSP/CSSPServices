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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveID), new[] { "RatingCurveID" });
                }
            }

            //RatingCurveID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveNumber), new[] { "RatingCurveNumber" });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveRatingCurveNumber, "50"), new[] { "RatingCurveNumber" });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RatingCurveLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RatingCurveLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.LastUpdateContactTVText) && ratingCurve.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RatingCurve GetRatingCurveWithRatingCurveID(int RatingCurveID)
        {
            IQueryable<RatingCurve> ratingCurveQuery = (from c in GetRead()
                                                where c.RatingCurveID == RatingCurveID
                                                select c);

            return FillRatingCurve(ratingCurveQuery).FirstOrDefault();
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
            if (!db.RatingCurves.Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
            {
                ratingCurve.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString())) }.AsEnumerable();
                return false;
            }

            db.RatingCurves.Remove(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        public bool Update(RatingCurve ratingCurve)
        {
            if (!db.RatingCurves.Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
            {
                ratingCurve.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveID", ratingCurve.RatingCurveID.ToString())) }.AsEnumerable();
                return false;
            }

            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Update(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<RatingCurve> FillRatingCurve(IQueryable<RatingCurve> ratingCurveQuery)
        {
            List<RatingCurve> RatingCurveList = (from c in ratingCurveQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new RatingCurve
                                         {
                                             RatingCurveID = c.RatingCurveID,
                                             HydrometricSiteID = c.HydrometricSiteID,
                                             RatingCurveNumber = c.RatingCurveNumber,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return RatingCurveList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
