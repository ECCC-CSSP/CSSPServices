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
    ///     <para>bonjour EmailDistributionList</para>
    /// </summary>
    public partial class EmailDistributionListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionList emailDistributionList = validationContext.ObjectInstance as EmailDistributionList;
            emailDistributionList.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionList.EmailDistributionListID == 0)
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListEmailDistributionListID"), new[] { "EmailDistributionListID" });
                }

                if (!(from c in db.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListEmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
                }
            }

            TVItem TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListCountryTVItemID", emailDistributionList.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemCountryTVItemID.TVType))
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListCountryTVItemID", "Country"), new[] { "CountryTVItemID" });
                }
            }

            if (emailDistributionList.Ordinal < 0 || emailDistributionList.Ordinal > 1000)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EmailDistributionListOrdinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (emailDistributionList.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionList.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListLastUpdateContactTVItemID", emailDistributionList.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public EmailDistributionList GetEmailDistributionListWithEmailDistributionListID(int EmailDistributionListID)
        {
            return (from c in db.EmailDistributionLists
                    where c.EmailDistributionListID == EmailDistributionListID
                    select c).FirstOrDefault();

        }
        public IQueryable<EmailDistributionList> GetEmailDistributionListList()
        {
            IQueryable<EmailDistributionList> EmailDistributionListQuery = (from c in db.EmailDistributionLists select c);

            EmailDistributionListQuery = EnhanceQueryStatements<EmailDistributionList>(EmailDistributionListQuery) as IQueryable<EmailDistributionList>;

            return EmailDistributionListQuery;
        }
        public EmailDistributionList_A GetEmailDistributionList_AWithEmailDistributionListID(int EmailDistributionListID)
        {
            return FillEmailDistributionList_A().Where(c => c.EmailDistributionListID == EmailDistributionListID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionList_A> GetEmailDistributionList_AList()
        {
            IQueryable<EmailDistributionList_A> EmailDistributionList_AQuery = FillEmailDistributionList_A();

            EmailDistributionList_AQuery = EnhanceQueryStatements<EmailDistributionList_A>(EmailDistributionList_AQuery) as IQueryable<EmailDistributionList_A>;

            return EmailDistributionList_AQuery;
        }
        public EmailDistributionList_B GetEmailDistributionList_BWithEmailDistributionListID(int EmailDistributionListID)
        {
            return FillEmailDistributionList_B().Where(c => c.EmailDistributionListID == EmailDistributionListID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionList_B> GetEmailDistributionList_BList()
        {
            IQueryable<EmailDistributionList_B> EmailDistributionList_BQuery = FillEmailDistributionList_B();

            EmailDistributionList_BQuery = EnhanceQueryStatements<EmailDistributionList_B>(EmailDistributionList_BQuery) as IQueryable<EmailDistributionList_B>;

            return EmailDistributionList_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Create);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Add(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        public bool Delete(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Delete);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Remove(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        public bool Update(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Update);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Update(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(EmailDistributionList emailDistributionList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionList.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
