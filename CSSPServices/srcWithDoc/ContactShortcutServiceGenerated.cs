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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutContactShortcutID), new[] { "ContactShortcutID" });
                }

                if (!GetRead().Where(c => c.ContactShortcutID == contactShortcut.ContactShortcutID).Any())
                {
                    contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactShortcut, CSSPModelsRes.ContactShortcutContactShortcutID, contactShortcut.ContactShortcutID.ToString()), new[] { "ContactShortcutID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactShortcut.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactShortcutContactID, contactShortcut.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutText))
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutShortCutText), new[] { "ShortCutText" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutText) && contactShortcut.ShortCutText.Length > 100)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactShortcutShortCutText, "100"), new[] { "ShortCutText" });
            }

            if (string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress))
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutShortCutAddress), new[] { "ShortCutAddress" });
            }

            if (!string.IsNullOrWhiteSpace(contactShortcut.ShortCutAddress) && contactShortcut.ShortCutAddress.Length > 200)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactShortcutShortCutAddress, "200"), new[] { "ShortCutAddress" });
            }

            if (contactShortcut.LastUpdateDate_UTC.Year == 1)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactShortcut.LastUpdateDate_UTC.Year < 1980)
                {
                contactShortcut.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactShortcutLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactShortcut.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactShortcut.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactShortcutLastUpdateContactTVItemID, contactShortcut.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactShortcutLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<ContactShortcut> contactShortcutQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ContactShortcutID == ContactShortcutID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactShortcutQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillContactShortcutWeb(contactShortcutQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContactShortcutReport(contactShortcutQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ContactShortcut> GetContactShortcutList()
        {
            IQueryable<ContactShortcut> contactShortcutQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        contactShortcutQuery = EnhanceQueryStatements<ContactShortcut>(contactShortcutQuery) as IQueryable<ContactShortcut>;

                        return contactShortcutQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        contactShortcutQuery = FillContactShortcutWeb(contactShortcutQuery);

                        contactShortcutQuery = EnhanceQueryStatements<ContactShortcut>(contactShortcutQuery) as IQueryable<ContactShortcut>;

                        return contactShortcutQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        contactShortcutQuery = FillContactShortcutReport(contactShortcutQuery);

                        contactShortcutQuery = EnhanceQueryStatements<ContactShortcut>(contactShortcutQuery) as IQueryable<ContactShortcut>;

                        return contactShortcutQuery;
                    }
                default:
                    {
                        contactShortcutQuery = contactShortcutQuery.Where(c => c.ContactShortcutID == 0);

                        return contactShortcutQuery;
                    }
            }
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
        public IQueryable<ContactShortcut> GetRead()
        {
            IQueryable<ContactShortcut> contactShortcutQuery = db.ContactShortcuts.AsNoTracking();

            return contactShortcutQuery;
        }
        public IQueryable<ContactShortcut> GetEdit()
        {
            IQueryable<ContactShortcut> contactShortcutQuery = db.ContactShortcuts;

            return contactShortcutQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ContactShortcutFillWeb
        private IQueryable<ContactShortcut> FillContactShortcutWeb(IQueryable<ContactShortcut> contactShortcutQuery)
        {
            contactShortcutQuery = (from c in contactShortcutQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ContactShortcut
                    {
                        ContactShortcutID = c.ContactShortcutID,
                        ContactID = c.ContactID,
                        ShortCutText = c.ShortCutText,
                        ShortCutAddress = c.ShortCutAddress,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ContactShortcutWeb = new ContactShortcutWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        ContactShortcutReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return contactShortcutQuery;
        }
        #endregion Functions private Generated ContactShortcutFillWeb

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
