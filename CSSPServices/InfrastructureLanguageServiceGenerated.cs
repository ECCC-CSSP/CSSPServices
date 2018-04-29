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
    ///     <para>bonjour InfrastructureLanguage</para>
    /// </summary>
    public partial class InfrastructureLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            InfrastructureLanguage infrastructureLanguage = validationContext.ObjectInstance as InfrastructureLanguage;
            infrastructureLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID), new[] { "InfrastructureLanguageID" });
                }

                if (!GetRead().Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.InfrastructureLanguage, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID, infrastructureLanguage.InfrastructureLanguageID.ToString()), new[] { "InfrastructureLanguageID" });
                }
            }

            Infrastructure InfrastructureInfrastructureID = (from c in db.Infrastructures where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Infrastructure, CSSPModelsRes.InfrastructureLanguageInfrastructureID, (infrastructureLanguage.InfrastructureID == null ? "" : infrastructureLanguage.InfrastructureID.ToString())), new[] { "InfrastructureID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)infrastructureLanguage.Language);
            if (infrastructureLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageComment), new[] { "Comment" });
            }

            //Comment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)infrastructureLanguage.TranslationStatus);
            if (infrastructureLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, (infrastructureLanguage.LastUpdateContactTVItemID == null ? "" : infrastructureLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public InfrastructureLanguage GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID, GetParam getParam)
        {
            IQueryable<InfrastructureLanguage> infrastructureLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.InfrastructureLanguageID == InfrastructureLanguageID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return infrastructureLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillInfrastructureLanguageWeb(infrastructureLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillInfrastructureLanguageReport(infrastructureLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<InfrastructureLanguage> GetInfrastructureLanguageList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<InfrastructureLanguage> infrastructureLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureLanguageQuery  = infrastructureLanguageQuery.OrderByDescending(c => c.InfrastructureLanguageID);
                        }
                        infrastructureLanguageQuery = infrastructureLanguageQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureLanguageQuery = FillInfrastructureLanguageWeb(infrastructureLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.InfrastructureLanguageID);
                        }
                        infrastructureLanguageQuery = FillInfrastructureLanguageWeb(infrastructureLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            infrastructureLanguageQuery = FillInfrastructureLanguageReport(infrastructureLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.InfrastructureLanguageID);
                        }
                        infrastructureLanguageQuery = FillInfrastructureLanguageReport(infrastructureLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return infrastructureLanguageQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Add(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool Delete(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Delete);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Remove(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool Update(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Update(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public IQueryable<InfrastructureLanguage> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.InfrastructureLanguages.AsNoTracking();
            }
            else
            {
                return db.InfrastructureLanguages.AsNoTracking().OrderByDescending(c => c.InfrastructureLanguageID);
            }
        }
        public IQueryable<InfrastructureLanguage> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.InfrastructureLanguages;
            }
            else
            {
                return db.InfrastructureLanguages.OrderByDescending(c => c.InfrastructureLanguageID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated InfrastructureLanguageFillWeb
        private IQueryable<InfrastructureLanguage> FillInfrastructureLanguageWeb(IQueryable<InfrastructureLanguage> infrastructureLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            infrastructureLanguageQuery = (from c in infrastructureLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new InfrastructureLanguage
                    {
                        InfrastructureLanguageID = c.InfrastructureLanguageID,
                        InfrastructureID = c.InfrastructureID,
                        Language = c.Language,
                        Comment = c.Comment,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        InfrastructureLanguageWeb = new InfrastructureLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        InfrastructureLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return infrastructureLanguageQuery;
        }
        #endregion Functions private Generated InfrastructureLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(InfrastructureLanguage infrastructureLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
