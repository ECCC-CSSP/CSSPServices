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
        public InfrastructureLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //InfrastructureLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Infrastructure InfrastructureInfrastructureID = (from c in db.Infrastructures where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Infrastructure, CSSPModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), new[] { "InfrastructureID" });
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.LastUpdateContactTVText) && infrastructureLanguage.LastUpdateContactTVText.Length > 200)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.LanguageText) && infrastructureLanguage.LanguageText.Length > 100)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.InfrastructureLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.TranslationStatusText) && infrastructureLanguage.TranslationStatusText.Length > 100)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.InfrastructureLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public InfrastructureLanguage GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            IQueryable<InfrastructureLanguage> infrastructureLanguageQuery = (from c in GetRead()
                                                where c.InfrastructureLanguageID == InfrastructureLanguageID
                                                select c);

            return FillInfrastructureLanguage(infrastructureLanguageQuery).FirstOrDefault();
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
            return db.InfrastructureLanguages.AsNoTracking();
        }
        public IQueryable<InfrastructureLanguage> GetEdit()
        {
            return db.InfrastructureLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<InfrastructureLanguage> FillInfrastructureLanguage(IQueryable<InfrastructureLanguage> infrastructureLanguageQuery)
        {
            List<InfrastructureLanguage> InfrastructureLanguageList = (from c in infrastructureLanguageQuery
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
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (InfrastructureLanguage infrastructureLanguage in InfrastructureLanguageList)
            {
                infrastructureLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)infrastructureLanguage.Language);
                infrastructureLanguage.TranslationStatusText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)infrastructureLanguage.TranslationStatus);
            }

            return InfrastructureLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
