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
        public ContactPreferenceService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactPreference contactPreference = validationContext.ObjectInstance as ContactPreference;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactPreference.ContactPreferenceID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceContactPreferenceID), new[] { "ContactPreferenceID" });
                }
            }

            //ContactPreferenceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), new[] { "ContactID" });
            }

            retStr = enums.TVTypeOK(contactPreference.TVType);
            if (contactPreference.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceTVType), new[] { "TVType" });
            }

            //MarkerSize (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), new[] { "MarkerSize" });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ContactPreferenceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(contactPreference.TVTypeText) && contactPreference.TVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactPreferenceTVTypeText, "100"), new[] { "TVTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactPreference GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            IQueryable<ContactPreference> contactPreferenceQuery = (from c in GetRead()
                                                where c.ContactPreferenceID == ContactPreferenceID
                                                select c);

            return FillContactPreference(contactPreferenceQuery).FirstOrDefault();
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<ContactPreference> FillContactPreference(IQueryable<ContactPreference> contactPreferenceQuery)
        {
            List<ContactPreference> ContactPreferenceList = (from c in contactPreferenceQuery
                                         select new ContactPreference
                                         {
                                             ContactPreferenceID = c.ContactPreferenceID,
                                             ContactID = c.ContactID,
                                             TVType = c.TVType,
                                             MarkerSize = c.MarkerSize,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (ContactPreference contactPreference in ContactPreferenceList)
            {
                contactPreference.TVTypeText = enums.GetEnumText_TVTypeEnum(contactPreference.TVType);
            }

            return ContactPreferenceList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
