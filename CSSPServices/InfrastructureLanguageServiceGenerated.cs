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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageInfrastructureLanguageID), new[] { "InfrastructureLanguageID" });
                }
            }

            //InfrastructureLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Infrastructure InfrastructureInfrastructureID = (from c in db.Infrastructures where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Infrastructure, ModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), new[] { "InfrastructureID" });
            }

            retStr = enums.LanguageOK(infrastructureLanguage.Language);
            if (infrastructureLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageComment), new[] { "Comment" });
            }

            //Comment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(infrastructureLanguage.TranslationStatus);
            if (infrastructureLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.InfrastructureLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.LastUpdateContactTVText) && infrastructureLanguage.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.LanguageText) && infrastructureLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(infrastructureLanguage.TranslationStatusText) && infrastructureLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
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
            if (!db.InfrastructureLanguages.Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.InfrastructureLanguages.Remove(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool Update(InfrastructureLanguage infrastructureLanguage)
        {
            if (!db.InfrastructureLanguages.Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

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
                infrastructureLanguage.LanguageText = enums.GetEnumText_LanguageEnum(infrastructureLanguage.Language);
                infrastructureLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(infrastructureLanguage.TranslationStatus);
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
