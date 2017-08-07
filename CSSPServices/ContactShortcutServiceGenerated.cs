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
        #endregion Properties

        #region Constructors
        public ContactShortcutService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactShortcut contactShortcut = validationContext.ObjectInstance as ContactShortcut;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactShortcut.ContactShortcutID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutContactShortcutID), new[] { "ContactShortcutID" });
                }
            }

            //ContactShortcutID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactShortcutContactID, contactShortcut.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutText), new[] { "ShortCutText" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutText, "100"), new[] { "ShortCutText" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutAddress), new[] { "ShortCutAddress" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutAddress, "200"), new[] { "ShortCutAddress" });
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ContactShortcutLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactShortcutLastUpdateContactTVItemID, contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactShortcutLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactShortcut GetContactShortcutWithContactShortcutID(int ContactShortcutID)
        {
            IQueryable<ContactShortcut> contactShortcutQuery = (from c in GetRead()
                                                where c.ContactShortcutID == ContactShortcutID
                                                select c);

            return FillContactShortcut(contactShortcutQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<ContactShortcut> FillContactShortcut(IQueryable<ContactShortcut> contactShortcutQuery)
        {
            List<ContactShortcut> ContactShortcutList = (from c in contactShortcutQuery
                                         select new ContactShortcut
                                         {
                                             ContactShortcutID = c.ContactShortcutID,
                                             ContactID = c.ContactID,
                                             ShortCutText = c.ShortCutText,
                                             ShortCutAddress = c.ShortCutAddress,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            return ContactShortcutList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
