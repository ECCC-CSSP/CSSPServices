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
    ///     <para>bonjour PolSourceObservation</para>
    /// </summary>
    public partial class PolSourceObservationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;
            polSourceObservation.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationPolSourceObservationID"), new[] { "PolSourceObservationID" });
                }

                if (!GetRead().Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationPolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = (from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceObservationPolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), new[] { "PolSourceSiteID" });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationObservationDate_Local"), new[] { "ObservationDate_Local" });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationObservationDate_Local", "1980"), new[] { "ObservationDate_Local" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationObservation_ToBeDeleted"), new[] { "Observation_ToBeDeleted" });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationLastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceObservation GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceObservation> GetPolSourceObservationList()
        {
            IQueryable<PolSourceObservation> PolSourceObservationQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            PolSourceObservationQuery = EnhanceQueryStatements<PolSourceObservation>(PolSourceObservationQuery) as IQueryable<PolSourceObservation>;

            return PolSourceObservationQuery;
        }
        public PolSourceObservationWeb GetPolSourceObservationWebWithPolSourceObservationID(int PolSourceObservationID)
        {
            return FillPolSourceObservationWeb().FirstOrDefault();

        }
        public IQueryable<PolSourceObservationWeb> GetPolSourceObservationWebList()
        {
            IQueryable<PolSourceObservationWeb> PolSourceObservationWebQuery = FillPolSourceObservationWeb();

            PolSourceObservationWebQuery = EnhanceQueryStatements<PolSourceObservationWeb>(PolSourceObservationWebQuery) as IQueryable<PolSourceObservationWeb>;

            return PolSourceObservationWebQuery;
        }
        public PolSourceObservationReport GetPolSourceObservationReportWithPolSourceObservationID(int PolSourceObservationID)
        {
            return FillPolSourceObservationReport().FirstOrDefault();

        }
        public IQueryable<PolSourceObservationReport> GetPolSourceObservationReportList()
        {
            IQueryable<PolSourceObservationReport> PolSourceObservationReportQuery = FillPolSourceObservationReport();

            PolSourceObservationReportQuery = EnhanceQueryStatements<PolSourceObservationReport>(PolSourceObservationReportQuery) as IQueryable<PolSourceObservationReport>;

            return PolSourceObservationReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Add(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool Delete(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Delete);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Remove(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool Update(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Update(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public IQueryable<PolSourceObservation> GetRead()
        {
            IQueryable<PolSourceObservation> polSourceObservationQuery = db.PolSourceObservations.AsNoTracking();

            return polSourceObservationQuery;
        }
        public IQueryable<PolSourceObservation> GetEdit()
        {
            IQueryable<PolSourceObservation> polSourceObservationQuery = db.PolSourceObservations;

            return polSourceObservationQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated PolSourceObservationFillWeb
        private IQueryable<PolSourceObservationWeb> FillPolSourceObservationWeb()
        {
             IQueryable<PolSourceObservationWeb>  PolSourceObservationWebQuery = (from c in db.PolSourceObservations
                let PolSourceSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new PolSourceObservationWeb
                    {
                        PolSourceSiteTVItemLanguage = PolSourceSiteTVItemLanguage,
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        PolSourceObservationID = c.PolSourceObservationID,
                        PolSourceSiteID = c.PolSourceSiteID,
                        ObservationDate_Local = c.ObservationDate_Local,
                        ContactTVItemID = c.ContactTVItemID,
                        Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return PolSourceObservationWebQuery;
        }
        #endregion Functions private Generated PolSourceObservationFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceObservation polSourceObservation)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservation.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
