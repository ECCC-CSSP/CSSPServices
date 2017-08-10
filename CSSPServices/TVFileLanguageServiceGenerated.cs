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
    public partial class TVFileLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFileLanguage tvFileLanguage = validationContext.ObjectInstance as TVFileLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTVFileLanguageID), new[] { "TVFileLanguageID" });
                }
            }

            //TVFileLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVFileID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVFile TVFileTVFileID = (from c in db.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();

            if (TVFileTVFileID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVFile, ModelsRes.TVFileLanguageTVFileID, tvFileLanguage.TVFileID.ToString()), new[] { "TVFileID" });
            }

            retStr = enums.LanguageOK(tvFileLanguage.Language);
            if (tvFileLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLanguage), new[] { "Language" });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.TranslationStatusOK(tvFileLanguage.TranslationStatus);
            if (tvFileLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVFileLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFileLanguage.LastUpdateContactTVText) && tvFileLanguage.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFileLanguage.LanguageText) && tvFileLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFileLanguage.TranslationStatusText) && tvFileLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVFileLanguage GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID)
        {
            IQueryable<TVFileLanguage> tvFileLanguageQuery = (from c in GetRead()
                                                where c.TVFileLanguageID == TVFileLanguageID
                                                select c);

            return FillTVFileLanguage(tvFileLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Add(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool Delete(TVFileLanguage tvFileLanguage)
        {
            if (!db.TVFileLanguages.Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVFileLanguages.Remove(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool Update(TVFileLanguage tvFileLanguage)
        {
            if (!db.TVFileLanguages.Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Update(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public IQueryable<TVFileLanguage> GetRead()
        {
            return db.TVFileLanguages.AsNoTracking();
        }
        public IQueryable<TVFileLanguage> GetEdit()
        {
            return db.TVFileLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVFileLanguage> FillTVFileLanguage(IQueryable<TVFileLanguage> tvFileLanguageQuery)
        {
            List<TVFileLanguage> TVFileLanguageList = (from c in tvFileLanguageQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new TVFileLanguage
                                         {
                                             TVFileLanguageID = c.TVFileLanguageID,
                                             TVFileID = c.TVFileID,
                                             Language = c.Language,
                                             FileDescription = c.FileDescription,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVFileLanguage tvFileLanguage in TVFileLanguageList)
            {
                tvFileLanguage.LanguageText = enums.GetEnumText_LanguageEnum(tvFileLanguage.Language);
                tvFileLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(tvFileLanguage.TranslationStatus);
            }

            return TVFileLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(TVFileLanguage tvFileLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
