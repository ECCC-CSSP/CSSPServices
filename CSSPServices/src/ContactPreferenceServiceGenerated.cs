/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        #endregion Properties

        #region Constructors
        public ContactPreferenceService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactPreference contactPreference = validationContext.ObjectInstance as ContactPreference;
            contactPreference.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactPreference.ContactPreferenceID == 0)
                {
                    contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceID"), new[] { "ContactPreferenceID" });
                }

                if (!(from c in db.ContactPreferences select c).Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceID", contactPreference.ContactPreferenceID.ToString()), new[] { "ContactPreferenceID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contactPreference.ContactID.ToString()), new[] { "ContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)contactPreference.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MarkerSize", "1", "1000"), new[] { "MarkerSize" });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", contactPreference.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactPreference GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            return (from c in db.ContactPreferences
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

        }
        public IQueryable<ContactPreference> GetContactPreferenceList()
        {
            IQueryable<ContactPreference> ContactPreferenceQuery = (from c in db.ContactPreferences select c);

            ContactPreferenceQuery = EnhanceQueryStatements<ContactPreference>(ContactPreferenceQuery) as IQueryable<ContactPreference>;

            return ContactPreferenceQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Add(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        public bool Delete(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Delete);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Remove(contactPreference);

            if (!TryToSave(contactPreference)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
