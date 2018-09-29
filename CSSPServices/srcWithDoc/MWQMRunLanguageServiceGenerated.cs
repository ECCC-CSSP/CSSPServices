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
        public MWQMRunLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageMWQMRunLanguageID"), new[] { "MWQMRunLanguageID" });
                }

                if (!(from c in db.MWQMRunLanguages select c).Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageMWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString()), new[] { "MWQMRunLanguageID" });
                }
            }

            MWQMRun MWQMRunMWQMRunID = (from c in db.MWQMRuns where c.MWQMRunID == mwqmRunLanguage.MWQMRunID select c).FirstOrDefault();

            if (MWQMRunMWQMRunID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunLanguageMWQMRunID", mwqmRunLanguage.MWQMRunID.ToString()), new[] { "MWQMRunID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmRunLanguage.Language);
            if (mwqmRunLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageRunComment"), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunComment);
            if (mwqmRunLanguage.TranslationStatusRunComment == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageTranslationStatusRunComment"), new[] { "TranslationStatusRunComment" });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageRunWeatherComment"), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (mwqmRunLanguage.TranslationStatusRunWeatherComment == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageTranslationStatusRunWeatherComment"), new[] { "TranslationStatusRunWeatherComment" });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmRunLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmRunLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLanguageLastUpdateContactTVItemID", mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.MWQMRunLanguages
                    where c.MWQMRunLanguageID == MWQMRunLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMRunLanguage> GetMWQMRunLanguageList()
        {
            IQueryable<MWQMRunLanguage> MWQMRunLanguageQuery = (from c in db.MWQMRunLanguages select c);

            MWQMRunLanguageQuery = EnhanceQueryStatements<MWQMRunLanguage>(MWQMRunLanguageQuery) as IQueryable<MWQMRunLanguage>;

            return MWQMRunLanguageQuery;
        }
        public MWQMRunLanguage_A GetMWQMRunLanguage_AWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            return FillMWQMRunLanguage_A().Where(c => c.MWQMRunLanguageID == MWQMRunLanguageID).FirstOrDefault();

        }
        public IQueryable<MWQMRunLanguage_A> GetMWQMRunLanguage_AList()
        {
            IQueryable<MWQMRunLanguage_A> MWQMRunLanguage_AQuery = FillMWQMRunLanguage_A();

            MWQMRunLanguage_AQuery = EnhanceQueryStatements<MWQMRunLanguage_A>(MWQMRunLanguage_AQuery) as IQueryable<MWQMRunLanguage_A>;

            return MWQMRunLanguage_AQuery;
        }
        public MWQMRunLanguage_B GetMWQMRunLanguage_BWithMWQMRunLanguageID(int MWQMRunLanguageID)
        {
            return FillMWQMRunLanguage_B().Where(c => c.MWQMRunLanguageID == MWQMRunLanguageID).FirstOrDefault();

        }
        public IQueryable<MWQMRunLanguage_B> GetMWQMRunLanguage_BList()
        {
            IQueryable<MWQMRunLanguage_B> MWQMRunLanguage_BQuery = FillMWQMRunLanguage_B();

            MWQMRunLanguage_BQuery = EnhanceQueryStatements<MWQMRunLanguage_B>(MWQMRunLanguage_BQuery) as IQueryable<MWQMRunLanguage_B>;

            return MWQMRunLanguage_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
