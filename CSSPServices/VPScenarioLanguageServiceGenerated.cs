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
    ///     <para>bonjour VPScenarioLanguage</para>
    /// </summary>
    public partial class VPScenarioLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenarioLanguage vpScenarioLanguage = validationContext.ObjectInstance as VPScenarioLanguage;
            vpScenarioLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpScenarioLanguage.VPScenarioLanguageID == 0)
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID), new[] { "VPScenarioLanguageID" });
                }

                if (!GetRead().Where(c => c.VPScenarioLanguageID == vpScenarioLanguage.VPScenarioLanguageID).Any())
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenarioLanguage, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID, vpScenarioLanguage.VPScenarioLanguageID.ToString()), new[] { "VPScenarioLanguageID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpScenarioLanguage.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPScenarioLanguageVPScenarioID, vpScenarioLanguage.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)vpScenarioLanguage.Language);
            if (vpScenarioLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioName), new[] { "VPScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName) && vpScenarioLanguage.VPScenarioName.Length > 100)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioLanguageVPScenarioName, "100"), new[] { "VPScenarioName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)vpScenarioLanguage.TranslationStatus);
            if (vpScenarioLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (vpScenarioLanguage.LastUpdateDate_UTC.Year == 1)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenarioLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPScenarioLanguage GetVPScenarioLanguageWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.VPScenarioLanguageID == VPScenarioLanguageID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return vpScenarioLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillVPScenarioLanguageWeb(vpScenarioLanguageQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillVPScenarioLanguageReport(vpScenarioLanguageQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<VPScenarioLanguage> GetVPScenarioLanguageList()
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        vpScenarioLanguageQuery = EnhanceQueryStatements<VPScenarioLanguage>(vpScenarioLanguageQuery) as IQueryable<VPScenarioLanguage>;

                        return vpScenarioLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        vpScenarioLanguageQuery = FillVPScenarioLanguageWeb(vpScenarioLanguageQuery);

                        vpScenarioLanguageQuery = EnhanceQueryStatements<VPScenarioLanguage>(vpScenarioLanguageQuery) as IQueryable<VPScenarioLanguage>;

                        return vpScenarioLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        vpScenarioLanguageQuery = FillVPScenarioLanguageReport(vpScenarioLanguageQuery);

                        vpScenarioLanguageQuery = EnhanceQueryStatements<VPScenarioLanguage>(vpScenarioLanguageQuery) as IQueryable<VPScenarioLanguage>;

                        return vpScenarioLanguageQuery;
                    }
                default:
                    {
                        vpScenarioLanguageQuery = vpScenarioLanguageQuery.Where(c => c.VPScenarioLanguageID == 0);

                        return vpScenarioLanguageQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Create);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Add(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public bool Delete(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Delete);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Remove(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public bool Update(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Update);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Update(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public IQueryable<VPScenarioLanguage> GetRead()
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = db.VPScenarioLanguages.AsNoTracking();

            return vpScenarioLanguageQuery;
        }
        public IQueryable<VPScenarioLanguage> GetEdit()
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = db.VPScenarioLanguages;

            return vpScenarioLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated VPScenarioLanguageFillWeb
        private IQueryable<VPScenarioLanguage> FillVPScenarioLanguageWeb(IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            vpScenarioLanguageQuery = (from c in vpScenarioLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new VPScenarioLanguage
                    {
                        VPScenarioLanguageID = c.VPScenarioLanguageID,
                        VPScenarioID = c.VPScenarioID,
                        Language = c.Language,
                        VPScenarioName = c.VPScenarioName,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        VPScenarioLanguageWeb = new VPScenarioLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        VPScenarioLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return vpScenarioLanguageQuery;
        }
        #endregion Functions private Generated VPScenarioLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(VPScenarioLanguage vpScenarioLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenarioLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
