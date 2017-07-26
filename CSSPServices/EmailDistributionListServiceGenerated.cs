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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (emailDistributionList.EmailDistributionListID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListEmailDistributionListID), new[] { ModelsRes.EmailDistributionListEmailDistributionListID });
                }
            }

            //EmailDistributionListID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CountryTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionList.CountryTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListCountryTVItemID, "1"), new[] { ModelsRes.EmailDistributionListCountryTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == emailDistributionList.CountryTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListCountryTVItemID, emailDistributionList.CountryTVItemID.ToString()), new[] { ModelsRes.EmailDistributionListCountryTVItemID });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionList.RegionName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListRegionName), new[] { ModelsRes.EmailDistributionListRegionName });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionList.RegionName) && emailDistributionList.RegionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListRegionName, "100"), new[] { ModelsRes.EmailDistributionListRegionName });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionList.Ordinal < 0 || emailDistributionList.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000"), new[] { ModelsRes.EmailDistributionListOrdinal });
            }

            if (emailDistributionList.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLastUpdateDate_UTC), new[] { ModelsRes.EmailDistributionListLastUpdateDate_UTC });
            }
            else
            {
                if (emailDistributionList.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.EmailDistributionListLastUpdateDate_UTC, "1980"), new[] { ModelsRes.EmailDistributionListLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionList.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, "1"), new[] { ModelsRes.EmailDistributionListLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == emailDistributionList.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, emailDistributionList.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.EmailDistributionListLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(EmailDistributionList emailDistributionList)
        {
            emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Create);
            if (emailDistributionList.ValidationResults.Count() > 0) return false;

            db.EmailDistributionLists.Add(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        public bool AddRange(List<EmailDistributionList> emailDistributionListList)
        {
            foreach (EmailDistributionList emailDistributionList in emailDistributionListList)
            {
                emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Create);
                if (emailDistributionList.ValidationResults.Count() > 0) return false;
            }

            db.EmailDistributionLists.AddRange(emailDistributionListList);

            if (!TryToSaveRange(emailDistributionListList)) return false;

            return true;
        }
        public bool Delete(EmailDistributionList emailDistributionList)
        {
            if (!db.EmailDistributionLists.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
            {
                emailDistributionList.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString())) }.AsEnumerable();
                return false;
            }

            db.EmailDistributionLists.Remove(emailDistributionList);

            if (!TryToSave(emailDistributionList)) return false;

            return true;
        }
        public bool DeleteRange(List<EmailDistributionList> emailDistributionListList)
        {
            foreach (EmailDistributionList emailDistributionList in emailDistributionListList)
            {
                if (!db.EmailDistributionLists.Where(c => c.EmailDistributionListID == emailDistributionList.EmailDistributionListID).Any())
                {
                    emailDistributionListList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.EmailDistributionLists.RemoveRange(emailDistributionListList);

            if (!TryToSaveRange(emailDistributionListList)) return false;

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
        public bool UpdateRange(List<EmailDistributionList> emailDistributionListList)
        {
            foreach (EmailDistributionList emailDistributionList in emailDistributionListList)
            {
                emailDistributionList.ValidationResults = Validate(new ValidationContext(emailDistributionList), ActionDBTypeEnum.Update);
                if (emailDistributionList.ValidationResults.Count() > 0) return false;
            }
            db.EmailDistributionLists.UpdateRange(emailDistributionListList);

            if (!TryToSaveRange(emailDistributionListList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<EmailDistributionList> emailDistributionListList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionListList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
