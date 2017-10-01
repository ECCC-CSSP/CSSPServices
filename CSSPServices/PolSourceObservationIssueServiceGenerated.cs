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
        public PolSourceObservationIssueService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //PolSourceObservationIssueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PolSourceObservationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            PolSourceObservation PolSourceObservationPolSourceObservationID = (from c in db.PolSourceObservations where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID select c).FirstOrDefault();

            if (PolSourceObservationPolSourceObservationID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationID, polSourceObservationIssue.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
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

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceObservationIssue.Ordinal < 0 || polSourceObservationIssue.Ordinal > 1000)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

                //Error: Type not implemented [PolSourceObservationIssueWeb] of type [PolSourceObservationIssueWeb]
                //Error: Type not implemented [PolSourceObservationIssueReport] of type [PolSourceObservationIssueReport]
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservationIssue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceObservationIssue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceObservationIssue GetPolSourceObservationIssueWithPolSourceObservationIssueID(int PolSourceObservationIssueID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return polSourceObservationIssueQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillPolSourceObservationIssue(polSourceObservationIssueQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<PolSourceObservationIssue> GetPolSourceObservationIssueList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return polSourceObservationIssueQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillPolSourceObservationIssue(polSourceObservationIssueQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
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

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<PolSourceObservationIssue> FillPolSourceObservationIssue_Show_Copy_To_PolSourceObservationIssueServiceExtra_As_Fill_PolSourceObservationIssue(IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
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
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        PolSourceObservationIssueWeb = new PolSourceObservationIssueWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        PolSourceObservationIssueReport = new PolSourceObservationIssueReport
                        {
                            PolSourceObservationIssueReportTest = "PolSourceObservationIssueReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return polSourceObservationIssueQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
