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
    ///     <para>bonjour ContactPreference</para>
    /// </summary>
    public partial class ContactPreferenceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactPreferenceService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceContactPreferenceID"), new[] { "ContactPreferenceID" });
                }

                if (!(from c in db.ContactPreferences select c).Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceContactPreferenceID", contactPreference.ContactPreferenceID.ToString()), new[] { "ContactPreferenceID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactPreferenceContactID", contactPreference.ContactID.ToString()), new[] { "ContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)contactPreference.TVType);
            if (contactPreference.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceTVType"), new[] { "TVType" });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ContactPreferenceMarkerSize", "1", "1000"), new[] { "MarkerSize" });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactPreferenceLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactPreferenceLastUpdateContactTVItemID", contactPreference.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactPreferenceLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
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
        public ContactPreferenceWeb GetContactPreferenceWebWithContactPreferenceID(int ContactPreferenceID)
        {
            return FillContactPreferenceWeb().Where(c => c.ContactPreferenceID == ContactPreferenceID).FirstOrDefault();

        }
        public IQueryable<ContactPreferenceWeb> GetContactPreferenceWebList()
        {
            IQueryable<ContactPreferenceWeb> ContactPreferenceWebQuery = FillContactPreferenceWeb();

            ContactPreferenceWebQuery = EnhanceQueryStatements<ContactPreferenceWeb>(ContactPreferenceWebQuery) as IQueryable<ContactPreferenceWeb>;

            return ContactPreferenceWebQuery;
        }
        public ContactPreferenceReport GetContactPreferenceReportWithContactPreferenceID(int ContactPreferenceID)
        {
            return FillContactPreferenceReport().Where(c => c.ContactPreferenceID == ContactPreferenceID).FirstOrDefault();

        }
        public IQueryable<ContactPreferenceReport> GetContactPreferenceReportList()
        {
            IQueryable<ContactPreferenceReport> ContactPreferenceReportQuery = FillContactPreferenceReport();

            ContactPreferenceReportQuery = EnhanceQueryStatements<ContactPreferenceReport>(ContactPreferenceReportQuery) as IQueryable<ContactPreferenceReport>;

            return ContactPreferenceReportQuery;
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

        #region Functions private Generated ContactPreferenceFillWeb
        private IQueryable<ContactPreferenceWeb> FillContactPreferenceWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<ContactPreferenceWeb> ContactPreferenceWebQuery = (from c in db.ContactPreferences
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ContactPreferenceWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        ContactPreferenceID = c.ContactPreferenceID,
                        ContactID = c.ContactID,
                        TVType = c.TVType,
                        MarkerSize = c.MarkerSize,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ContactPreferenceWebQuery;
        }
        #endregion Functions private Generated ContactPreferenceFillWeb

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
