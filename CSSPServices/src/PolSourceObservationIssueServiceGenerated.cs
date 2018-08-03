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
    ///     <para>bonjour PolSourceObservationIssue</para>
    /// </summary>
    public partial class PolSourceObservationIssueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObservationIssue polSourceObservationIssue = validationContext.ObjectInstance as PolSourceObservationIssue;
            polSourceObservationIssue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservationIssue.PolSourceObservationIssueID == 0)
                {
                    polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssuePolSourceObservationIssueID"), new[] { "PolSourceObservationIssueID" });
                }

                if (!GetRead().Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
                {
                    polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssuePolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString()), new[] { "PolSourceObservationIssueID" });
                }
            }

            PolSourceObservation PolSourceObservationPolSourceObservationID = (from c in db.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();

            if (PolSourceObservationPolSourceObservationID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationIssuePolSourceObservationID", polSourceObservationIssue.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
            }

            if (string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo))
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssueObservationInfo"), new[] { "ObservationInfo" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo) && polSourceObservationIssue.ObservationInfo.Length > 250)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "PolSourceObservationIssueObservationInfo", "250"), new[] { "ObservationInfo" });
            }

            if (polSourceObservationIssue.Ordinal < 0 || polSourceObservationIssue.Ordinal > 1000)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceObservationIssueOrdinal", "0", "1000"), new[] { "Ordinal" });
            }

            //ExtraComment has no StringLength Attribute

            if (polSourceObservationIssue.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssueLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservationIssue.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationIssueLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationIssueLastUpdateContactTVItemID", polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationIssueLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceObservationIssue GetPolSourceObservationIssueWithPolSourceObservationIssueID(int PolSourceObservationIssueID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceObservationIssue> GetPolSourceObservationIssueList()
        {
            IQueryable<PolSourceObservationIssue> PolSourceObservationIssueQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            PolSourceObservationIssueQuery = EnhanceQueryStatements<PolSourceObservationIssue>(PolSourceObservationIssueQuery) as IQueryable<PolSourceObservationIssue>;

            return PolSourceObservationIssueQuery;
        }
        public PolSourceObservationIssueWeb GetPolSourceObservationIssueWebWithPolSourceObservationIssueID(int PolSourceObservationIssueID)
        {
            return FillPolSourceObservationIssueWeb().FirstOrDefault();

        }
        public IQueryable<PolSourceObservationIssueWeb> GetPolSourceObservationIssueWebList()
        {
            IQueryable<PolSourceObservationIssueWeb> PolSourceObservationIssueWebQuery = FillPolSourceObservationIssueWeb();

            PolSourceObservationIssueWebQuery = EnhanceQueryStatements<PolSourceObservationIssueWeb>(PolSourceObservationIssueWebQuery) as IQueryable<PolSourceObservationIssueWeb>;

            return PolSourceObservationIssueWebQuery;
        }
        public PolSourceObservationIssueReport GetPolSourceObservationIssueReportWithPolSourceObservationIssueID(int PolSourceObservationIssueID)
        {
            return FillPolSourceObservationIssueReport().FirstOrDefault();

        }
        public IQueryable<PolSourceObservationIssueReport> GetPolSourceObservationIssueReportList()
        {
            IQueryable<PolSourceObservationIssueReport> PolSourceObservationIssueReportQuery = FillPolSourceObservationIssueReport();

            PolSourceObservationIssueReportQuery = EnhanceQueryStatements<PolSourceObservationIssueReport>(PolSourceObservationIssueReportQuery) as IQueryable<PolSourceObservationIssueReport>;

            return PolSourceObservationIssueReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceObservationIssue polSourceObservationIssue)
        {
            polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Create);
            if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;

            db.PolSourceObservationIssues.Add(polSourceObservationIssue);

            if (!TryToSave(polSourceObservationIssue)) return false;

            return true;
        }
        public bool Delete(PolSourceObservationIssue polSourceObservationIssue)
        {
            polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Delete);
            if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;

            db.PolSourceObservationIssues.Remove(polSourceObservationIssue);

            if (!TryToSave(polSourceObservationIssue)) return false;

            return true;
        }
        public bool Update(PolSourceObservationIssue polSourceObservationIssue)
        {
            polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Update);
            if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;

            db.PolSourceObservationIssues.Update(polSourceObservationIssue);

            if (!TryToSave(polSourceObservationIssue)) return false;

            return true;
        }
        public IQueryable<PolSourceObservationIssue> GetRead()
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = db.PolSourceObservationIssues.AsNoTracking();

            return polSourceObservationIssueQuery;
        }
        public IQueryable<PolSourceObservationIssue> GetEdit()
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = db.PolSourceObservationIssues;

            return polSourceObservationIssueQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated PolSourceObservationIssueFillWeb
        private IQueryable<PolSourceObservationIssueWeb> FillPolSourceObservationIssueWeb()
        {
             IQueryable<PolSourceObservationIssueWeb>  PolSourceObservationIssueWebQuery = (from c in db.PolSourceObservationIssues
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new PolSourceObservationIssueWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                        PolSourceObservationID = c.PolSourceObservationID,
                        ObservationInfo = c.ObservationInfo,
                        Ordinal = c.Ordinal,
                        ExtraComment = c.ExtraComment,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return PolSourceObservationIssueWebQuery;
        }
        #endregion Functions private Generated PolSourceObservationIssueFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceObservationIssue polSourceObservationIssue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservationIssue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
