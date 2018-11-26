/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
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
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [ContactPreferenceController](CSSPWebAPI.Controllers.ContactPreferenceController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.ContactPreference](CSSPModels.ContactPreference.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class ContactPreferenceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB ContactPreferences table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public ContactPreferenceService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all ContactPreferenceService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
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
        /// <summary>
        /// Gets the ContactPreference model with the ContactPreferenceID identifier
        /// </summary>
        /// <param name="ContactPreferenceID">Is the identifier of [ContactPreferences](CSSPModels.ContactPreference.html) table of CSSPDB</param>
        /// <returns>[ContactPreference](CSSPModels.ContactPreference.html) object connected to the CSSPDB</returns>
        public ContactPreference GetContactPreferenceWithContactPreferenceID(int ContactPreferenceID)
        {
            return (from c in db.ContactPreferences
                    where c.ContactPreferenceID == ContactPreferenceID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [ContactPreference](CSSPModels.ContactPreference.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [ContactPreference](CSSPModels.ContactPreference.html)</returns>
        public IQueryable<ContactPreference> GetContactPreferenceList()
        {
            IQueryable<ContactPreference> ContactPreferenceQuery = (from c in db.ContactPreferences select c);

            ContactPreferenceQuery = EnhanceQueryStatements<ContactPreference>(ContactPreferenceQuery) as IQueryable<ContactPreference>;

            return ContactPreferenceQuery;
        }
        /// <summary>
        /// Gets the ContactPreferenceExtraA model with the ContactPreferenceID identifier
        /// </summary>
        /// <param name="ContactPreferenceID">Is the identifier of [ContactPreferences](CSSPModels.ContactPreference.html) table of CSSPDB</param>
        /// <returns>[ContactPreferenceExtraA](CSSPModels.ContactPreferenceExtraA.html) object connected to the CSSPDB</returns>
        public ContactPreferenceExtraA GetContactPreferenceExtraAWithContactPreferenceID(int ContactPreferenceID)
        {
            return FillContactPreferenceExtraA().Where(c => c.ContactPreferenceID == ContactPreferenceID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [ContactPreferenceExtraA](CSSPModels.ContactPreferenceExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [ContactPreferenceExtraA](CSSPModels.ContactPreferenceExtraA.html)</returns>
        public IQueryable<ContactPreferenceExtraA> GetContactPreferenceExtraAList()
        {
            IQueryable<ContactPreferenceExtraA> ContactPreferenceExtraAQuery = FillContactPreferenceExtraA();

            ContactPreferenceExtraAQuery = EnhanceQueryStatements<ContactPreferenceExtraA>(ContactPreferenceExtraAQuery) as IQueryable<ContactPreferenceExtraA>;

            return ContactPreferenceExtraAQuery;
        }
        /// <summary>
        /// Gets the ContactPreferenceExtraB model with the ContactPreferenceID identifier
        /// </summary>
        /// <param name="ContactPreferenceID">Is the identifier of [ContactPreferences](CSSPModels.ContactPreference.html) table of CSSPDB</param>
        /// <returns>[ContactPreferenceExtraB](CSSPModels.ContactPreferenceExtraB.html) object connected to the CSSPDB</returns>
        public ContactPreferenceExtraB GetContactPreferenceExtraBWithContactPreferenceID(int ContactPreferenceID)
        {
            return FillContactPreferenceExtraB().Where(c => c.ContactPreferenceID == ContactPreferenceID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [ContactPreferenceExtraB](CSSPModels.ContactPreferenceExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [ContactPreferenceExtraB](CSSPModels.ContactPreferenceExtraB.html)</returns>
        public IQueryable<ContactPreferenceExtraB> GetContactPreferenceExtraBList()
        {
            IQueryable<ContactPreferenceExtraB> ContactPreferenceExtraBQuery = FillContactPreferenceExtraB();

            ContactPreferenceExtraBQuery = EnhanceQueryStatements<ContactPreferenceExtraB>(ContactPreferenceExtraBQuery) as IQueryable<ContactPreferenceExtraB>;

            return ContactPreferenceExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [ContactPreference](CSSPModels.ContactPreference.html) item in CSSPDB
        /// </summary>
        /// <param name="contactPreference">Is the ContactPreference item the client want to add to CSSPDB</param>
        /// <returns>true if ContactPreference item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Create);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Add(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [ContactPreference](CSSPModels.ContactPreference.html) item in CSSPDB
        /// </summary>
        /// <param name="contactPreference">Is the ContactPreference item the client want to add to CSSPDB. What's important here is the ContactPreferenceID</param>
        /// <returns>true if ContactPreference item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(ContactPreference contactPreference)
        {
            contactPreference.ValidationResults = Validate(new ValidationContext(contactPreference), ActionDBTypeEnum.Delete);
            if (contactPreference.ValidationResults.Count() > 0) return false;

            db.ContactPreferences.Remove(contactPreference);

            if (!TryToSave(contactPreference)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [ContactPreference](CSSPModels.ContactPreference.html) item in CSSPDB
        /// </summary>
        /// <param name="contactPreference">Is the ContactPreference item the client want to add to CSSPDB. What's important here is the ContactPreferenceID</param>
        /// <returns>true if ContactPreference item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [ContactPreference](CSSPModels.ContactPreference.html) item
        /// </summary>
        /// <param name="contactPreference">Is the ContactPreference item the client want to add to CSSPDB. What's important here is the ContactPreferenceID</param>
        /// <returns>true if ContactPreference item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
