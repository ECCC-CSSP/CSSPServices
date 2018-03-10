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
        public ContactPreferenceService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceContactPreferenceID), new[] { "ContactPreferenceID" });
                }

                if (!GetRead().Where(c => c.ContactPreferenceID == contactPreference.ContactPreferenceID).Any())
                {
                    contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactPreference, CSSPModelsRes.ContactPreferenceContactPreferenceID, contactPreference.ContactPreferenceID.ToString()), new[] { "ContactPreferenceID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactPreference.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactPreferenceContactID, (contactPreference.ContactID == null ? "" : contactPreference.ContactID.ToString())), new[] { "ContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)contactPreference.TVType);
            if (contactPreference.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceTVType), new[] { "TVType" });
            }

            if (contactPreference.MarkerSize < 1 || contactPreference.MarkerSize > 1000)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContactPreferenceMarkerSize, "1", "1000"), new[] { "MarkerSize" });
            }

            if (contactPreference.LastUpdateDate_UTC.Year == 1)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactPreference.LastUpdateDate_UTC.Year < 1980)
                {
                contactPreference.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactPreference.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactPreference.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, (contactPreference.LastUpdateContactTVItemID == null ? "" : contactPreference.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public ContactPreference GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID, GetParam getParam)
        {
            IQueryable<ContactPreference> contactPreferenceQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ContactPreferenceID == ContactPreferenceID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactPreferenceQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillContactPreferenceWeb(contactPreferenceQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContactPreferenceReport(contactPreferenceQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ContactPreference> GetContactPreferenceList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<ContactPreference> contactPreferenceQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            contactPreferenceQuery  = contactPreferenceQuery.OrderByDescending(c => c.ContactPreferenceID);
                        }
                        contactPreferenceQuery = contactPreferenceQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return contactPreferenceQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            contactPreferenceQuery = FillContactPreferenceWeb(contactPreferenceQuery, FilterAndOrderText).OrderByDescending(c => c.ContactPreferenceID);
                        }
                        contactPreferenceQuery = FillContactPreferenceWeb(contactPreferenceQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return contactPreferenceQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            contactPreferenceQuery = FillContactPreferenceReport(contactPreferenceQuery, FilterAndOrderText).OrderByDescending(c => c.ContactPreferenceID);
                        }
                        contactPreferenceQuery = FillContactPreferenceReport(contactPreferenceQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return contactPreferenceQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<ContactPreference> GetRead()
        {
            return db.ContactPreferences.AsNoTracking();
        }
        public IQueryable<ContactPreference> GetEdit()
        {
            return db.ContactPreferences;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ContactPreferenceFillWeb
        private IQueryable<ContactPreference> FillContactPreferenceWeb(IQueryable<ContactPreference> contactPreferenceQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            contactPreferenceQuery = (from c in contactPreferenceQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ContactPreference
                    {
                        ContactPreferenceID = c.ContactPreferenceID,
                        ContactID = c.ContactID,
                        TVType = c.TVType,
                        MarkerSize = c.MarkerSize,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ContactPreferenceWeb = new ContactPreferenceWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        },
                        ContactPreferenceReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return contactPreferenceQuery;
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
