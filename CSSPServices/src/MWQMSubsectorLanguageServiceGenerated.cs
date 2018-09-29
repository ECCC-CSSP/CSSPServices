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
    ///     <para>bonjour MWQMSubsectorLanguage</para>
    /// </summary>
    public partial class MWQMSubsectorLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSubsectorLanguage mwqmSubsectorLanguage = validationContext.ObjectInstance as MWQMSubsectorLanguage;
            mwqmSubsectorLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsectorLanguage.MWQMSubsectorLanguageID == 0)
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageMWQMSubsectorLanguageID"), new[] { "MWQMSubsectorLanguageID" });
                }

                if (!(from c in db.MWQMSubsectorLanguages select c).Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageMWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), new[] { "MWQMSubsectorLanguageID" });
                }
            }

            MWQMSubsector MWQMSubsectorMWQMSubsectorID = (from c in db.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();

            if (MWQMSubsectorMWQMSubsectorID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorLanguageMWQMSubsectorID", mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), new[] { "MWQMSubsectorID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSubsectorLanguage.Language);
            if (mwqmSubsectorLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageSubsectorDesc"), new[] { "SubsectorDesc" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc) && mwqmSubsectorLanguage.SubsectorDesc.Length > 250)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorLanguageSubsectorDesc", "250"), new[] { "SubsectorDesc" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusSubsectorDesc);
            if (mwqmSubsectorLanguage.TranslationStatusSubsectorDesc == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageTranslationStatusSubsectorDesc"), new[] { "TranslationStatusSubsectorDesc" });
            }

            //LogBook has no StringLength Attribute

            if (mwqmSubsectorLanguage.TranslationStatusLogBook != null)
            {
                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusLogBook);
                if (mwqmSubsectorLanguage.TranslationStatusLogBook == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageTranslationStatusLogBook"), new[] { "TranslationStatusLogBook" });
                }
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSubsectorLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorLanguageLastUpdateContactTVItemID", mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSubsectorLanguage GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID)
        {
            return (from c in db.MWQMSubsectorLanguages
                    where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSubsectorLanguage> GetMWQMSubsectorLanguageList()
        {
            IQueryable<MWQMSubsectorLanguage> MWQMSubsectorLanguageQuery = (from c in db.MWQMSubsectorLanguages select c);

            MWQMSubsectorLanguageQuery = EnhanceQueryStatements<MWQMSubsectorLanguage>(MWQMSubsectorLanguageQuery) as IQueryable<MWQMSubsectorLanguage>;

            return MWQMSubsectorLanguageQuery;
        }
        public MWQMSubsectorLanguage_A GetMWQMSubsectorLanguage_AWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID)
        {
            return FillMWQMSubsectorLanguage_A().Where(c => c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID).FirstOrDefault();

        }
        public IQueryable<MWQMSubsectorLanguage_A> GetMWQMSubsectorLanguage_AList()
        {
            IQueryable<MWQMSubsectorLanguage_A> MWQMSubsectorLanguage_AQuery = FillMWQMSubsectorLanguage_A();

            MWQMSubsectorLanguage_AQuery = EnhanceQueryStatements<MWQMSubsectorLanguage_A>(MWQMSubsectorLanguage_AQuery) as IQueryable<MWQMSubsectorLanguage_A>;

            return MWQMSubsectorLanguage_AQuery;
        }
        public MWQMSubsectorLanguage_B GetMWQMSubsectorLanguage_BWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID)
        {
            return FillMWQMSubsectorLanguage_B().Where(c => c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID).FirstOrDefault();

        }
        public IQueryable<MWQMSubsectorLanguage_B> GetMWQMSubsectorLanguage_BList()
        {
            IQueryable<MWQMSubsectorLanguage_B> MWQMSubsectorLanguage_BQuery = FillMWQMSubsectorLanguage_B();

            MWQMSubsectorLanguage_BQuery = EnhanceQueryStatements<MWQMSubsectorLanguage_B>(MWQMSubsectorLanguage_BQuery) as IQueryable<MWQMSubsectorLanguage_B>;

            return MWQMSubsectorLanguage_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Create);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool Delete(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Delete);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool Update(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Update);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectorLanguages.Update(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsectorLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
