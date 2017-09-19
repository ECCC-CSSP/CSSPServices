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
    ///     <para>bonjour MWQMRunLanguage</para>
    /// </summary>
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
            mwqmRunLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageMWQMRunLanguageID), new[] { "MWQMRunLanguageID" });
                }

                if (!GetRead().Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRunLanguage, CSSPModelsRes.MWQMRunLanguageMWQMRunLanguageID, mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { "MWQMRunLanguageID" });
                }
            }

            //MWQMRunLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MWQMRun MWQMRunMWQMRunID = (from c in db.MWQMRuns where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRun, CSSPModelsRes.MWQMRunLanguageMWQMRunID, mwqmRunLanguage.MWQMRunID.ToString()), new[] { "MWQMRunID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (mwqmRunLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageRunComment), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (mwqmRunLanguage.TranslationStatusRunComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunComment), new[] { "TranslationStatusRunComment" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageRunWeatherComment), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (mwqmRunLanguage.TranslationStatusRunWeatherComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment), new[] { "TranslationStatusRunWeatherComment" });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.LastUpdateContactTVText) && mwqmRunLanguage.LastUpdateContactTVText.Length > 200)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.LanguageText) && mwqmRunLanguage.LanguageText.Length > 100)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.TranslationStatusRunCommentText) && mwqmRunLanguage.TranslationStatusRunCommentText.Length > 100)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunCommentText, "100"), new[] { "TranslationStatusRunCommentText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRunLanguage.TranslationStatusRunWeatherCommentText) && mwqmRunLanguage.TranslationStatusRunWeatherCommentText.Length > 100)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLanguageTranslationStatusRunWeatherCommentText, "100"), new[] { "TranslationStatusRunWeatherCommentText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmRunLanguage.HasErrors = true;
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
        public bool Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Delete);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Remove(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

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
                mwqmRunLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
                mwqmRunLanguage.TranslationStatusRunCommentText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
                mwqmRunLanguage.TranslationStatusRunWeatherCommentText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
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
        #endregion Functions private Generated

    }
}
