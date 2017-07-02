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
    public partial class PolSourceObservationIssueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceObservationIssue polSourceObservationIssue = validationContext.ObjectInstance as PolSourceObservationIssue;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (polSourceObservationIssue.PolSourceObservationIssueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), new[] { ModelsRes.PolSourceObservationIssuePolSourceObservationIssueID });
                }
            }

            //PolSourceObservationID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueObservationInfo), new[] { ModelsRes.PolSourceObservationIssueObservationInfo });
            }

            //Ordinal (int) is required but no testing needed as it is automatically set to 0

            if (polSourceObservationIssue.LastUpdateDate_UTC == null || polSourceObservationIssue.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueLastUpdateDate_UTC), new[] { ModelsRes.PolSourceObservationIssueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (polSourceObservationIssue.PolSourceObservationID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssuePolSourceObservationID, "1"), new[] { ModelsRes.PolSourceObservationIssuePolSourceObservationID });
            }

            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo) && polSourceObservationIssue.ObservationInfo.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObservationIssueObservationInfo, "250"), new[] { ModelsRes.PolSourceObservationIssueObservationInfo });
            }

            if (polSourceObservationIssue.Ordinal < 0 || polSourceObservationIssue.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), new[] { ModelsRes.PolSourceObservationIssueOrdinal });
            }

            if (polSourceObservationIssue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(PolSourceObservationIssue polSourceObservationIssue)
        {
            polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Create);
            if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;

            db.PolSourceObservationIssues.Add(polSourceObservationIssue);

            if (!TryToSave(polSourceObservationIssue)) return false;

            return true;
        }
        public bool AddRange(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
            {
                polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Create);
                if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;
            }

            db.PolSourceObservationIssues.AddRange(polSourceObservationIssueList);

            if (!TryToSaveRange(polSourceObservationIssueList)) return false;

            return true;
        }
        public bool Delete(PolSourceObservationIssue polSourceObservationIssue)
        {
            if (!db.PolSourceObservationIssues.Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
            {
                polSourceObservationIssue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString())) }.AsEnumerable();
                return false;
            }

            db.PolSourceObservationIssues.Remove(polSourceObservationIssue);

            if (!TryToSave(polSourceObservationIssue)) return false;

            return true;
        }
        public bool DeleteRange(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
            {
                if (!db.PolSourceObservationIssues.Where(c => c.PolSourceObservationIssueID == polSourceObservationIssue.PolSourceObservationIssueID).Any())
                {
                    polSourceObservationIssueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.PolSourceObservationIssues.RemoveRange(polSourceObservationIssueList);

            if (!TryToSaveRange(polSourceObservationIssueList)) return false;

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
        public bool UpdateRange(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
            {
                polSourceObservationIssue.ValidationResults = Validate(new ValidationContext(polSourceObservationIssue), ActionDBTypeEnum.Update);
                if (polSourceObservationIssue.ValidationResults.Count() > 0) return false;
            }
            db.PolSourceObservationIssues.UpdateRange(polSourceObservationIssueList);

            if (!TryToSaveRange(polSourceObservationIssueList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservationIssueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
