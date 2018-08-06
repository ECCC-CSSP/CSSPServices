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
    ///     <para>bonjour TVTypeUserAuthorization</para>
    /// </summary>
    public partial class TVTypeUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTypeUserAuthorization tvTypeUserAuthorization = validationContext.ObjectInstance as TVTypeUserAuthorization;
            tvTypeUserAuthorization.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvTypeUserAuthorization.TVTypeUserAuthorizationID == 0)
                {
                    tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVTypeUserAuthorizationID"), new[] { "TVTypeUserAuthorizationID" });
                }

                if (!(from c in db.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                {
                    tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationTVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), new[] { "TVTypeUserAuthorizationID" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVTypeUserAuthorizationContactTVItemID", tvTypeUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVTypeUserAuthorizationContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvTypeUserAuthorization.TVType);
            if (tvTypeUserAuthorization.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvTypeUserAuthorization.TVAuth);
            if (tvTypeUserAuthorization.TVAuth == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVAuth"), new[] { "TVAuth" });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVTypeUserAuthorizationLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVTypeUserAuthorizationLastUpdateContactTVItemID", tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVTypeUserAuthorizationLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVTypeUserAuthorization GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            return (from c in db.TVTypeUserAuthorizations
                    where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVTypeUserAuthorization> GetTVTypeUserAuthorizationList()
        {
            IQueryable<TVTypeUserAuthorization> TVTypeUserAuthorizationQuery = (from c in db.TVTypeUserAuthorizations select c);

            TVTypeUserAuthorizationQuery = EnhanceQueryStatements<TVTypeUserAuthorization>(TVTypeUserAuthorizationQuery) as IQueryable<TVTypeUserAuthorization>;

            return TVTypeUserAuthorizationQuery;
        }
        public TVTypeUserAuthorizationWeb GetTVTypeUserAuthorizationWebWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            return FillTVTypeUserAuthorizationWeb().Where(c => c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID).FirstOrDefault();

        }
        public IQueryable<TVTypeUserAuthorizationWeb> GetTVTypeUserAuthorizationWebList()
        {
            IQueryable<TVTypeUserAuthorizationWeb> TVTypeUserAuthorizationWebQuery = FillTVTypeUserAuthorizationWeb();

            TVTypeUserAuthorizationWebQuery = EnhanceQueryStatements<TVTypeUserAuthorizationWeb>(TVTypeUserAuthorizationWebQuery) as IQueryable<TVTypeUserAuthorizationWeb>;

            return TVTypeUserAuthorizationWebQuery;
        }
        public TVTypeUserAuthorizationReport GetTVTypeUserAuthorizationReportWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID)
        {
            return FillTVTypeUserAuthorizationReport().Where(c => c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID).FirstOrDefault();

        }
        public IQueryable<TVTypeUserAuthorizationReport> GetTVTypeUserAuthorizationReportList()
        {
            IQueryable<TVTypeUserAuthorizationReport> TVTypeUserAuthorizationReportQuery = FillTVTypeUserAuthorizationReport();

            TVTypeUserAuthorizationReportQuery = EnhanceQueryStatements<TVTypeUserAuthorizationReport>(TVTypeUserAuthorizationReportQuery) as IQueryable<TVTypeUserAuthorizationReport>;

            return TVTypeUserAuthorizationReportQuery;
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
        public bool Delete(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Delete);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVTypeUserAuthorizationFillWeb
        private IQueryable<TVTypeUserAuthorizationWeb> FillTVTypeUserAuthorizationWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVTypeUserAuthorizationWeb> TVTypeUserAuthorizationWebQuery = (from c in db.TVTypeUserAuthorizations
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVTypeUserAuthorizationWeb
                    {
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        TVAuthText = (from e in TVAuthEnumList
                                where e.EnumID == (int?)c.TVAuth
                                select e.EnumText).FirstOrDefault(),
                        TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVType = c.TVType,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVTypeUserAuthorizationWebQuery;
        }
        #endregion Functions private Generated TVTypeUserAuthorizationFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
