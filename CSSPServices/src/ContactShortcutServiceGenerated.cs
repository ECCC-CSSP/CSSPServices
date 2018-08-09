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
    ///     <para>bonjour ContactShortcut</para>
    /// </summary>
    public partial class ContactShortcutService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactShortcutService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactShortcut contactShortcut = validationContext.ObjectInstance as ContactShortcut;
            contactShortcut.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactShortcut.ContactShortcutID == 0)
                {
                    contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutContactShortcutID"), new[] { "ContactShortcutID" });
                }

                if (!(from c in db.ContactShortcuts select c).Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                {
                    contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutContactShortcutID", contactShortcut.ContactShortcutID.ToString()), new[] { "ContactShortcutID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactShortcutContactID", contactShortcut.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutShortCutText"), new[] { "ShortCutText" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactShortcutShortCutText", "100"), new[] { "ShortCutText" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutShortCutAddress"), new[] { "ShortCutAddress" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactShortcutShortCutAddress", "200"), new[] { "ShortCutAddress" });
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactShortcutLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactShortcutLastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactShortcutLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactShortcut GetContactShortcutWithContactShortcutID(int ContactShortcutID)
        {
            return (from c in db.ContactShortcuts
                    where c.ContactShortcutID == ContactShortcutID
                    select c).FirstOrDefault();

        }
        public IQueryable<ContactShortcut> GetContactShortcutList()
        {
            IQueryable<ContactShortcut> ContactShortcutQuery = (from c in db.ContactShortcuts select c);

            ContactShortcutQuery = EnhanceQueryStatements<ContactShortcut>(ContactShortcutQuery) as IQueryable<ContactShortcut>;

            return ContactShortcutQuery;
        }
        public ContactShortcut_A GetContactShortcut_AWithContactShortcutID(int ContactShortcutID)
        {
            return FillContactShortcut_A().Where(c => c.ContactShortcutID == ContactShortcutID).FirstOrDefault();

        }
        public IQueryable<ContactShortcut_A> GetContactShortcut_AList()
        {
            IQueryable<ContactShortcut_A> ContactShortcut_AQuery = FillContactShortcut_A();

            ContactShortcut_AQuery = EnhanceQueryStatements<ContactShortcut_A>(ContactShortcut_AQuery) as IQueryable<ContactShortcut_A>;

            return ContactShortcut_AQuery;
        }
        public ContactShortcut_B GetContactShortcut_BWithContactShortcutID(int ContactShortcutID)
        {
            return FillContactShortcut_B().Where(c => c.ContactShortcutID == ContactShortcutID).FirstOrDefault();

        }
        public IQueryable<ContactShortcut_B> GetContactShortcut_BList()
        {
            IQueryable<ContactShortcut_B> ContactShortcut_BQuery = FillContactShortcut_B();

            ContactShortcut_BQuery = EnhanceQueryStatements<ContactShortcut_B>(ContactShortcut_BQuery) as IQueryable<ContactShortcut_B>;

            return ContactShortcut_BQuery;
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
        public bool Delete(ContactShortcut contactShortcut)
        {
            contactShortcut.ValidationResults = Validate(new ValidationContext(contactShortcut), ActionDBTypeEnum.Delete);
            if (contactShortcut.ValidationResults.Count() > 0) return false;

            db.ContactShortcuts.Remove(contactShortcut);

            if (!TryToSave(contactShortcut)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
