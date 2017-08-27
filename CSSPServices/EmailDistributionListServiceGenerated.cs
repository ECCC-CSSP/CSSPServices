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
    public partial class EmailDistributionListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListEmailDistributionListID), new[] { "EmailDistributionListID" });
                }

                if (!GetRead().Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                {
                    emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListEmailDistributionListID, emailDistributionList.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
                }
            }

            //EmailDistributionListID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CountryTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListCountryTVItemID, emailDistributionList.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListCountryTVItemID, "Country"), new[] { "CountryTVItemID" });
                }
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionList.Ordinal < 0 || emailDistributionList.Ordinal > 1000)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            if (emailDistributionList.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionList.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionList.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.EmailDistributionListLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, emailDistributionList.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionList.CountryTVText) && emailDistributionList.CountryTVText.Length > 200)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListCountryTVText, "200"), new[] { "CountryTVText" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionList.LastUpdateContactTVText) && emailDistributionList.LastUpdateContactTVText.Length > 200)
            {
                emailDistributionList.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
            IQueryable<EmailDistributionList> emailDistributionListQuery = (from c in GetRead()
                                                where c.EmailDistributionListID == EmailDistributionListID
                                                select c);

            return FillEmailDistributionList(emailDistributionListQuery).FirstOrDefault();
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
        public IQueryable<EmailDistributionList> GetRead()
        {
            return db.EmailDistributionLists.AsNoTracking();
        }
        public IQueryable<EmailDistributionList> GetEdit()
        {
            return db.EmailDistributionLists;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<EmailDistributionList> FillEmailDistributionList(IQueryable<EmailDistributionList> emailDistributionListQuery)
        {
            List<EmailDistributionList> EmailDistributionListList = (from c in emailDistributionListQuery
                                         let CountryTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.CountryTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new EmailDistributionList
                                         {
                                             EmailDistributionListID = c.EmailDistributionListID,
                                             CountryTVItemID = c.CountryTVItemID,
                                             Ordinal = c.Ordinal,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             CountryTVText = CountryTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return EmailDistributionListList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
