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
    public partial class MWQMRunLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageMWQMRunLanguageID), new[] { "MWQMRunLanguageID" });
                }
            }

            //MWQMRunLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MWQMRun MWQMRunMWQMRunID = (from c in db.MWQMRuns where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMRun, ModelsRes.MWQMRunLanguageMWQMRunID, mwqmRunLanguage.MWQMRunID.ToString()), new[] { "MWQMRunID" });
            }

            retStr = enums.LanguageOK(mwqmRunLanguage.Language);
            if (mwqmRunLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunComment), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(mwqmRunLanguage.TranslationStatusRunComment);
            if (mwqmRunLanguage.TranslationStatusRunComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunComment), new[] { "TranslationStatusRunComment" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunWeatherComment), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (mwqmRunLanguage.TranslationStatusRunWeatherComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment), new[] { "TranslationStatusRunWeatherComment" });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.LastUpdateContactTVText) && mwqmRunLanguage.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.LanguageText) && mwqmRunLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.TranslationStatusRunCommentText) && mwqmRunLanguage.TranslationStatusRunCommentText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunLanguageTranslationStatusRunCommentText, "100"), new[] { "TranslationStatusRunCommentText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.TranslationStatusRunWeatherCommentText) && mwqmRunLanguage.TranslationStatusRunWeatherCommentText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherCommentText, "100"), new[] { "TranslationStatusRunWeatherCommentText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMRunLanguage GetMWQMRunLanguageWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            IQueryable<MWQMRunLanguage> mwqmRunLanguageQuery = (from c in GetRead()
                                                where c.MWQMRunLanguageID == MWQMRunLanguageID
                                                select c);

            return FillMWQMRunLanguage(mwqmRunLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Add(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool AddRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
                if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;
            }

            db.MWQMRunLanguages.AddRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public bool Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            if (!db.MWQMRunLanguages.Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
            {
                mwqmRunLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMRunLanguages.Remove(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                if (!db.MWQMRunLanguages.Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    mwqmRunLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMRunLanguages.RemoveRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public bool Update(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Update(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
                if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;
            }
            db.MWQMRunLanguages.UpdateRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public IQueryable<MWQMRunLanguage> GetRead()
        {
            return db.MWQMRunLanguages.AsNoTracking();
        }
        public IQueryable<MWQMRunLanguage> GetEdit()
        {
            return db.MWQMRunLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMRunLanguage> FillMWQMRunLanguage(IQueryable<MWQMRunLanguage> mwqmRunLanguageQuery)
        {
            List<MWQMRunLanguage> MWQMRunLanguageList = (from c in mwqmRunLanguageQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMRunLanguage
                                         {
                                             MWQMRunLanguageID = c.MWQMRunLanguageID,
                                             MWQMRunID = c.MWQMRunID,
                                             Language = c.Language,
                                             RunComment = c.RunComment,
                                             TranslationStatusRunComment = c.TranslationStatusRunComment,
                                             RunWeatherComment = c.RunWeatherComment,
                                             TranslationStatusRunWeatherComment = c.TranslationStatusRunWeatherComment,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MWQMRunLanguage mwqmRunLanguage in MWQMRunLanguageList)
            {
                mwqmRunLanguage.LanguageText = enums.GetEnumText_LanguageEnum(mwqmRunLanguage.Language);
                mwqmRunLanguage.TranslationStatusRunCommentText = enums.GetEnumText_TranslationStatusEnum(mwqmRunLanguage.TranslationStatusRunComment);
                mwqmRunLanguage.TranslationStatusRunWeatherCommentText = enums.GetEnumText_TranslationStatusEnum(mwqmRunLanguage.TranslationStatusRunWeatherComment);
            }

            return MWQMRunLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMRunLanguage mwqmRunLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
