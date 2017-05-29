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
    public partial class PolSourceObservationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationPolSourceObservationID), new[] { ModelsRes.PolSourceObservationPolSourceObservationID });
                }
            }

            //PolSourceSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (polSourceObservation.ObservationDate_Local == null || polSourceObservation.ObservationDate_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservationDate_Local), new[] { ModelsRes.PolSourceObservationObservationDate_Local });
            }

            //ContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservation_ToBeDeleted), new[] { ModelsRes.PolSourceObservationObservation_ToBeDeleted });
            }

            if (polSourceObservation.LastUpdateDate_UTC == null || polSourceObservation.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationLastUpdateDate_UTC), new[] { ModelsRes.PolSourceObservationLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (polSourceObservation.PolSourceSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationPolSourceSiteTVItemID, "1"), new[] { ModelsRes.PolSourceObservationPolSourceSiteTVItemID });
            }

            if (polSourceObservation.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationContactTVItemID, "1"), new[] { ModelsRes.PolSourceObservationContactTVItemID });
            }

            // Observation_ToBeDeleted has no validation

            if (polSourceObservation.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, "1"), new[] { ModelsRes.PolSourceObservationLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Add(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool AddRange(List<PolSourceObservation> polSourceObservationList)
        {
            foreach (PolSourceObservation polSourceObservation in polSourceObservationList)
            {
                polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
                if (polSourceObservation.ValidationResults.Count() > 0) return false;
            }

            db.PolSourceObservations.AddRange(polSourceObservationList);

            if (!TryToSaveRange(polSourceObservationList)) return false;

            return true;
        }
        public bool Delete(PolSourceObservation polSourceObservation)
        {
            if (!db.PolSourceObservations.Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
            {
                polSourceObservation.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.PolSourceObservations.Remove(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool DeleteRange(List<PolSourceObservation> polSourceObservationList)
        {
            foreach (PolSourceObservation polSourceObservation in polSourceObservationList)
            {
                if (!db.PolSourceObservations.Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    polSourceObservationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.PolSourceObservations.RemoveRange(polSourceObservationList);

            if (!TryToSaveRange(polSourceObservationList)) return false;

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
        public bool UpdateRange(List<PolSourceObservation> polSourceObservationList)
        {
            foreach (PolSourceObservation polSourceObservation in polSourceObservationList)
            {
                polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
                if (polSourceObservation.ValidationResults.Count() > 0) return false;
            }
            db.PolSourceObservations.UpdateRange(polSourceObservationList);

            if (!TryToSaveRange(polSourceObservationList)) return false;

            return true;
        }
        public IQueryable<PolSourceObservation> GetRead()
        {
            return db.PolSourceObservations.AsNoTracking();
        }
        public IQueryable<PolSourceObservation> GetEdit()
        {
            return db.PolSourceObservations;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<PolSourceObservation> polSourceObservationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
