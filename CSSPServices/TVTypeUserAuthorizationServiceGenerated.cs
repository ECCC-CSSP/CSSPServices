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
        public TVTypeUserAuthorizationService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), new[] { "TVTypeUserAuthorizationID" });
                }

                if (!GetRead().Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                {
                    tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVTypeUserAuthorization, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID, tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), new[] { "TVTypeUserAuthorizationID" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, (tvTypeUserAuthorization.ContactTVItemID == null ? "" : tvTypeUserAuthorization.ContactTVItemID.ToString())), new[] { "ContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvTypeUserAuthorization.TVType);
            if (tvTypeUserAuthorization.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVType), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvTypeUserAuthorization.TVAuth);
            if (tvTypeUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVAuth), new[] { "TVAuth" });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                tvTypeUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvTypeUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, (tvTypeUserAuthorization.LastUpdateContactTVItemID == null ? "" : tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public TVTypeUserAuthorization GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(int TVTypeUserAuthorizationID, GetParam getParam)
        {
            IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvTypeUserAuthorizationQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVTypeUserAuthorizationWeb(tvTypeUserAuthorizationQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVTypeUserAuthorizationReport(tvTypeUserAuthorizationQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVTypeUserAuthorization> GetTVTypeUserAuthorizationList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvTypeUserAuthorizationQuery  = tvTypeUserAuthorizationQuery.OrderByDescending(c => c.TVTypeUserAuthorizationID);
                        }
                        tvTypeUserAuthorizationQuery = tvTypeUserAuthorizationQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return tvTypeUserAuthorizationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvTypeUserAuthorizationQuery = FillTVTypeUserAuthorizationWeb(tvTypeUserAuthorizationQuery, FilterAndOrderText).OrderByDescending(c => c.TVTypeUserAuthorizationID);
                        }
                        tvTypeUserAuthorizationQuery = FillTVTypeUserAuthorizationWeb(tvTypeUserAuthorizationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return tvTypeUserAuthorizationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvTypeUserAuthorizationQuery = FillTVTypeUserAuthorizationReport(tvTypeUserAuthorizationQuery, FilterAndOrderText).OrderByDescending(c => c.TVTypeUserAuthorizationID);
                        }
                        tvTypeUserAuthorizationQuery = FillTVTypeUserAuthorizationReport(tvTypeUserAuthorizationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return tvTypeUserAuthorizationQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<TVTypeUserAuthorization> GetRead()
        {
            return db.TVTypeUserAuthorizations.AsNoTracking();
        }
        public IQueryable<TVTypeUserAuthorization> GetEdit()
        {
            return db.TVTypeUserAuthorizations;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVTypeUserAuthorizationFillWeb
        private IQueryable<TVTypeUserAuthorization> FillTVTypeUserAuthorizationWeb(IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

            tvTypeUserAuthorizationQuery = (from c in tvTypeUserAuthorizationQuery
                let ContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TVTypeUserAuthorization
                    {
                        TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVType = c.TVType,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TVTypeUserAuthorizationWeb = new TVTypeUserAuthorizationWeb
                        {
                            ContactTVText = ContactTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                            TVAuthText = (from e in TVAuthEnumList
                                where e.EnumID == (int?)c.TVAuth
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVTypeUserAuthorizationReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvTypeUserAuthorizationQuery;
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
