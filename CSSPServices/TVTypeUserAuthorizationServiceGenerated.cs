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
    public partial class TVTypeUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTypeUserAuthorization tvTypeUserAuthorization = validationContext.ObjectInstance as TVTypeUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvTypeUserAuthorization.TVTypeUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), new[] { "TVTypeUserAuthorizationID" });
                }
            }

            //TVTypeUserAuthorizationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationContactTVItemID, tvTypeUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVTypeUserAuthorizationContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            retStr = enums.TVTypeOK(tvTypeUserAuthorization.TVType);
            if (tvTypeUserAuthorization.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVType), new[] { "TVType" });
            }

            retStr = enums.TVAuthOK(tvTypeUserAuthorization.TVAuth);
            if (tvTypeUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVAuth), new[] { "TVAuth" });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorization.TVTypeText) && tvTypeUserAuthorization.TVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVTypeUserAuthorizationTVTypeText, "100"), new[] { "TVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorization.TVAuthText) && tvTypeUserAuthorization.TVAuthText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVTypeUserAuthorizationTVAuthText, "100"), new[] { "TVAuthText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVTypeUserAuthorization GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery = (from c in GetRead()
                                                where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                                select c);

            return FillTVTypeUserAuthorization(tvTypeUserAuthorizationQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool AddRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
                if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;
            }

            db.TVTypeUserAuthorizations.AddRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public bool Delete(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if (!db.TVTypeUserAuthorizations.Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
            {
                tvTypeUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool DeleteRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                if (!db.TVTypeUserAuthorizations.Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                {
                    tvTypeUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVTypeUserAuthorizations.RemoveRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public bool Update(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVTypeUserAuthorizations.Update(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool UpdateRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
                if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;
            }
            db.TVTypeUserAuthorizations.UpdateRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public IQueryable<TVTypeUserAuthorization> GetRead()
        {
            return db.TVTypeUserAuthorizations.AsNoTracking();
        }
        public IQueryable<TVTypeUserAuthorization> GetEdit()
        {
            return db.TVTypeUserAuthorizations;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVTypeUserAuthorization> FillTVTypeUserAuthorization(IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery)
        {
            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in tvTypeUserAuthorizationQuery
                                         select new TVTypeUserAuthorization
                                         {
                                             TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                             ContactTVItemID = c.ContactTVItemID,
                                             TVType = c.TVType,
                                             TVAuth = c.TVAuth,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in TVTypeUserAuthorizationList)
            {
                tvTypeUserAuthorization.TVTypeText = enums.GetEnumText_TVTypeEnum(tvTypeUserAuthorization.TVType);
                tvTypeUserAuthorization.TVAuthText = enums.GetEnumText_TVAuthEnum(tvTypeUserAuthorization.TVAuth);
            }

            return TVTypeUserAuthorizationList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvTypeUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvTypeUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
