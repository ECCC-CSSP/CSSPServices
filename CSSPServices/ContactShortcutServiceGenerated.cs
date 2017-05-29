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
    public partial class ContactShortcutService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ContactShortcut contactShortcut = validationContext.ObjectInstance as ContactShortcut;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactShortcut.ContactShortcutID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutContactShortcutID), new[] { ModelsRes.ContactShortcutContactShortcutID });
                }
            }

            //ContactID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutText), new[] { ModelsRes.ContactShortcutShortCutText });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutAddress), new[] { ModelsRes.ContactShortcutShortCutAddress });
            }

            if (contactShortcut.LastUpdateDate_UTC == null || contactShortcut.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutLastUpdateDate_UTC), new[] { ModelsRes.ContactShortcutLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contactShortcut.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutContactID, "1"), new[] { ModelsRes.ContactShortcutContactID });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutText, "100"), new[] { ModelsRes.ContactShortcutShortCutText });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutAddress, "200"), new[] { ModelsRes.ContactShortcutShortCutAddress });
            }

            if (contactShortcut.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ContactShortcutLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(ContactShortcut contactShortcut)
        {
            contactShortcut.ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Create);
            if (contactShortcut.ValidationResults.Count() > 0) return false;

            db.ContactShortcuts.Add(contactShortcut);

            if (!TryToSave(contactShortcut)) return false;

            return true;
        }
        public bool AddRange(List<ContactShortcut> contactShortcutList)
        {
            foreach (ContactShortcut contactShortcut in contactShortcutList)
            {
                contactShortcut.ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Create);
                if (contactShortcut.ValidationResults.Count() > 0) return false;
            }

            db.ContactShortcuts.AddRange(contactShortcutList);

            if (!TryToSaveRange(contactShortcutList)) return false;

            return true;
        }
        public bool Delete(ContactShortcut contactShortcut)
        {
            if (!db.ContactShortcuts.Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
            {
                contactShortcut.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ContactShortcuts.Remove(contactShortcut);

            if (!TryToSave(contactShortcut)) return false;

            return true;
        }
        public bool DeleteRange(List<ContactShortcut> contactShortcutList)
        {
            foreach (ContactShortcut contactShortcut in contactShortcutList)
            {
                if (!db.ContactShortcuts.Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                {
                    contactShortcutList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutID", contactShortcut.ContactShortcutID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ContactShortcuts.RemoveRange(contactShortcutList);

            if (!TryToSaveRange(contactShortcutList)) return false;

            return true;
        }
        public bool Update(ContactShortcut contactShortcut)
        {
            contactShortcut.ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Update);
            if (contactShortcut.ValidationResults.Count() > 0) return false;

            db.ContactShortcuts.Update(contactShortcut);

            if (!TryToSave(contactShortcut)) return false;

            return true;
        }
        public bool UpdateRange(List<ContactShortcut> contactShortcutList)
        {
            foreach (ContactShortcut contactShortcut in contactShortcutList)
            {
                contactShortcut.ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Update);
                if (contactShortcut.ValidationResults.Count() > 0) return false;
            }
            db.ContactShortcuts.UpdateRange(contactShortcutList);

            if (!TryToSaveRange(contactShortcutList)) return false;

            return true;
        }
        public IQueryable<ContactShortcut> GetRead()
        {
            return db.ContactShortcuts.AsNoTracking();
        }
        public IQueryable<ContactShortcut> GetEdit()
        {
            return db.ContactShortcuts;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(ContactShortcut contactShortcut)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactShortcut.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<ContactShortcut> contactShortcutList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactShortcutList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
