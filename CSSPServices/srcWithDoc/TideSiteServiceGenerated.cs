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
    ///     <para>bonjour TideSite</para>
    /// </summary>
    public partial class TideSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideSite tideSite = validationContext.ObjectInstance as TideSite;
            tideSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideSite.TideSiteID == 0)
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideSiteTideSiteID"), new[] { "TideSiteID" });
                }

                if (!(from c in db.TideSites select c).Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteTideSiteID", tideSite.TideSiteID.ToString()), new[] { "TideSiteID" });
                }
            }

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTideSiteTVItemID", tideSite.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteTideSiteTVItemID", "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tideSite.WebTideModel))
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideSiteWebTideModel"), new[] { "WebTideModel" });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.WebTideModel) && tideSite.WebTideModel.Length > 100)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TideSiteWebTideModel", "100"), new[] { "WebTideModel" });
            }

            if (tideSite.WebTideDatum_m < -100 || tideSite.WebTideDatum_m > 100)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideSiteWebTideDatum_m", "-100", "100"), new[] { "WebTideDatum_m" });
            }

            if (tideSite.LastUpdateDate_UTC.Year == 1)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideSite.LastUpdateDate_UTC.Year < 1980)
                {
                tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteLastUpdateContactTVItemID", tideSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TideSite GetTideSiteWithTideSiteID(int TideSiteID)
        {
            return (from c in db.TideSites
                    where c.TideSiteID == TideSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<TideSite> GetTideSiteList()
        {
            IQueryable<TideSite> TideSiteQuery = (from c in db.TideSites select c);

            TideSiteQuery = EnhanceQueryStatements<TideSite>(TideSiteQuery) as IQueryable<TideSite>;

            return TideSiteQuery;
        }
        public TideSiteWeb GetTideSiteWebWithTideSiteID(int TideSiteID)
        {
            return FillTideSiteWeb().Where(c => c.TideSiteID == TideSiteID).FirstOrDefault();

        }
        public IQueryable<TideSiteWeb> GetTideSiteWebList()
        {
            IQueryable<TideSiteWeb> TideSiteWebQuery = FillTideSiteWeb();

            TideSiteWebQuery = EnhanceQueryStatements<TideSiteWeb>(TideSiteWebQuery) as IQueryable<TideSiteWeb>;

            return TideSiteWebQuery;
        }
        public TideSiteReport GetTideSiteReportWithTideSiteID(int TideSiteID)
        {
            return FillTideSiteReport().Where(c => c.TideSiteID == TideSiteID).FirstOrDefault();

        }
        public IQueryable<TideSiteReport> GetTideSiteReportList()
        {
            IQueryable<TideSiteReport> TideSiteReportQuery = FillTideSiteReport();

            TideSiteReportQuery = EnhanceQueryStatements<TideSiteReport>(TideSiteReportQuery) as IQueryable<TideSiteReport>;

            return TideSiteReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Add(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool Delete(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Delete);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Remove(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool Update(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Update(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TideSiteFillWeb
        private IQueryable<TideSiteWeb> FillTideSiteWeb()
        {
             IQueryable<TideSiteWeb> TideSiteWebQuery = (from c in db.TideSites
                let TideSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TideSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TideSiteWeb
                    {
                        TideSiteTVItemLanguage = TideSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TideSiteID = c.TideSiteID,
                        TideSiteTVItemID = c.TideSiteTVItemID,
                        WebTideModel = c.WebTideModel,
                        WebTideDatum_m = c.WebTideDatum_m,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TideSiteWebQuery;
        }
        #endregion Functions private Generated TideSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(TideSite tideSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
