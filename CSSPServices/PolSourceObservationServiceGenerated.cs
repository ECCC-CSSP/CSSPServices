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
        public PolSourceObservationService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationPolSourceObservationID), new[] { ModelsRes.PolSourceObservationPolSourceObservationID });
                }
            }

            //PolSourceObservationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PolSourceSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceObservation.PolSourceSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationPolSourceSiteID, "1"), new[] { ModelsRes.PolSourceObservationPolSourceSiteID });
            }

            if (!((from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.PolSourceSite, ModelsRes.PolSourceObservationPolSourceSiteID, polSourceObservation.PolSourceSiteID.ToString()), new[] { ModelsRes.PolSourceObservationPolSourceSiteID });
            }

            if (polSourceObservation.ObservationDate_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservationDate_Local), new[] { ModelsRes.PolSourceObservationObservationDate_Local });
            }

            if (polSourceObservation.ObservationDate_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.PolSourceObservationObservationDate_Local, "1980"), new[] { ModelsRes.PolSourceObservationObservationDate_Local });
            }

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceObservation.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationContactTVItemID, "1"), new[] { ModelsRes.PolSourceObservationContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceObservationContactTVItemID, polSourceObservation.ContactTVItemID.ToString()), new[] { ModelsRes.PolSourceObservationContactTVItemID });
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservation_ToBeDeleted), new[] { ModelsRes.PolSourceObservationObservation_ToBeDeleted });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationLastUpdateDate_UTC), new[] { ModelsRes.PolSourceObservationLastUpdateDate_UTC });
            }

            if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.PolSourceObservationLastUpdateDate_UTC, "1980"), new[] { ModelsRes.PolSourceObservationLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceObservation.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, "1"), new[] { ModelsRes.PolSourceObservationLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.PolSourceObservationLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
