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
    public partial class ContactPreferenceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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
            ContactPreference contactPreference = validationContext.ObjectInstance as ContactPreference;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactPreference.ContactPreferenceID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceContactPreferenceID), new[] { ModelsRes.ContactPreferenceContactPreferenceID });
                }
            }

            //ContactID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.TVTypeOK(contactPreference.TVType);
            if (contactPreference.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceTVType), new[] { ModelsRes.ContactPreferenceTVType });
            }

            //MarkerSize (int) is required but no testing needed as it is automatically set to 0

            if (contactPreference.LastUpdateDate_UTC == null || contactPreference.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceLastUpdateDate_UTC), new[] { ModelsRes.ContactPreferenceLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contactPreference.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactPreferenceContactID, "1"), new[] { ModelsRes.ContactPreferenceContactID });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), new[] { ModelsRes.ContactPreferenceMarkerSize });
            }

            if (contactPreference.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ContactPreferenceLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Add(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        public bool AddRange(List<ContactPreference> contactPreferenceList)
        {
            foreach (ContactPreference contactPreference in contactPreferenceList)
            {
                contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
                if (contactPreference.ValidationResults.Count() > 0) return false;
            }

            db.ContactPreferences.AddRange(contactPreferenceList);

            if (!TryToSaveRange(contactPreferenceList)) return false;

            return true;
        }
        public bool Delete(ContactPreference contactPreference)
        {
            if (!db.ContactPreferences.Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
            {
                contactPreference.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", contactPreference.ContactPreferenceID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ContactPreferences.Remove(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        public bool DeleteRange(List<ContactPreference> contactPreferenceList)
        {
            foreach (ContactPreference contactPreference in contactPreferenceList)
            {
                if (!db.ContactPreferences.Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    contactPreferenceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", contactPreference.ContactPreferenceID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ContactPreferences.RemoveRange(contactPreferenceList);

            if (!TryToSaveRange(contactPreferenceList)) return false;

            return true;
        }
        public bool Update(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Update);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Update(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        public bool UpdateRange(List<ContactPreference> contactPreferenceList)
        {
            foreach (ContactPreference contactPreference in contactPreferenceList)
            {
                contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Update);
                if (contactPreference.ValidationResults.Count() > 0) return false;
            }
            db.ContactPreferences.UpdateRange(contactPreferenceList);

            if (!TryToSaveRange(contactPreferenceList)) return false;

            return true;
        }
        public IQueryable<ContactPreference> GetRead()
        {
            return db.ContactPreferences.AsNoTracking();
        }
        public IQueryable<ContactPreference> GetEdit()
        {
            return db.ContactPreferences;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(ContactPreference contactPreference)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactPreference.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<ContactPreference> contactPreferenceList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactPreferenceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
