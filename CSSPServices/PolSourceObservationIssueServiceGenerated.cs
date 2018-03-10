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
        public PolSourceObservationIssueService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), new[] { "PolSourceObservationIssueID" });
                }

                if (!GetRead().Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
                {
                    polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservationIssue, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID, polSourceObservationIssue.PolSourceObservationIssueID.ToString()), new[] { "PolSourceObservationIssueID" });
                }
            }

            PolSourceObservation PolSourceObservationPolSourceObservationID = (from c in db.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();

            if (PolSourceObservationPolSourceObservationID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationID, (polSourceObservationIssue.PolSourceObservationID == null ? "" : polSourceObservationIssue.PolSourceObservationID.ToString())), new[] { "PolSourceObservationID" });
            }

            if (string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo))
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssueObservationInfo), new[] { "ObservationInfo" });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo) && polSourceObservationIssue.ObservationInfo.Length > 250)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationIssueObservationInfo, "250"), new[] { "ObservationInfo" });
            }

            if (polSourceObservationIssue.Ordinal < 0 || polSourceObservationIssue.Ordinal > 1000)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            //ExtraComment has no StringLength Attribute

            if (polSourceObservationIssue.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservationIssue.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservationIssue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationIssueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, (polSourceObservationIssue.LastUpdateContactTVItemID == null ? "" : polSourceObservationIssue.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public PolSourceObservationIssue GetPolSourceObservationIssueWithPolSourceObservationIssueID(int PolSourceObservationIssueID, GetParam getParam)
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return polSourceObservationIssueQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillPolSourceObservationIssueWeb(polSourceObservationIssueQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillPolSourceObservationIssueReport(polSourceObservationIssueQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<PolSourceObservationIssue> GetPolSourceObservationIssueList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationIssueQuery  = polSourceObservationIssueQuery.OrderByDescending(c => c.PolSourceObservationIssueID);
                        }
                        polSourceObservationIssueQuery = polSourceObservationIssueQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationIssueQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationIssueQuery = FillPolSourceObservationIssueWeb(polSourceObservationIssueQuery, FilterAndOrderText).OrderByDescending(c => c.PolSourceObservationIssueID);
                        }
                        polSourceObservationIssueQuery = FillPolSourceObservationIssueWeb(polSourceObservationIssueQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationIssueQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationIssueQuery = FillPolSourceObservationIssueReport(polSourceObservationIssueQuery, FilterAndOrderText).OrderByDescending(c => c.PolSourceObservationIssueID);
                        }
                        polSourceObservationIssueQuery = FillPolSourceObservationIssueReport(polSourceObservationIssueQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationIssueQuery;
                    }
                default:
                    return null;
            }
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
            return db.PolSourceObservationIssues.AsNoTracking();
        }
        public IQueryable<PolSourceObservationIssue> GetEdit()
        {
            return db.PolSourceObservationIssues;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated PolSourceObservationIssueFillWeb
        private IQueryable<PolSourceObservationIssue> FillPolSourceObservationIssueWeb(IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery, string FilterAndOrderText)
        {
            polSourceObservationIssueQuery = (from c in polSourceObservationIssueQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new PolSourceObservationIssue
                    {
                        PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                        PolSourceObservationID = c.PolSourceObservationID,
                        ObservationInfo = c.ObservationInfo,
                        Ordinal = c.Ordinal,
                        ExtraComment = c.ExtraComment,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        PolSourceObservationIssueWeb = new PolSourceObservationIssueWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        PolSourceObservationIssueReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return polSourceObservationIssueQuery;
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
