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
        public MWQMSubsectorLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID), new[] { "MWQMSubsectorLanguageID" });
                }

                if (!GetRead().Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsectorLanguage, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID, mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString()), new[] { "MWQMSubsectorLanguageID" });
                }
            }

            //MWQMSubsectorLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MWQMSubsector MWQMSubsectorMWQMSubsectorID = (from c in db.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();

            if (MWQMSubsectorMWQMSubsectorID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsector, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), new[] { "MWQMSubsectorID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSubsectorLanguage.Language);
            if (mwqmSubsectorLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageSubsectorDesc), new[] { "SubsectorDesc" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc) && mwqmSubsectorLanguage.SubsectorDesc.Length > 250)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250"), new[] { "SubsectorDesc" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusSubsectorDesc);
            if (mwqmSubsectorLanguage.TranslationStatusSubsectorDesc == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusSubsectorDesc), new[] { "TranslationStatusSubsectorDesc" });
            }

            //LogBook has no StringLength Attribute

            if (mwqmSubsectorLanguage.TranslationStatusLogBook != null)
            {
                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusLogBook);
                if (mwqmSubsectorLanguage.TranslationStatusLogBook == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusLogBook), new[] { "TranslationStatusLogBook" });
                }
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSubsectorLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.LastUpdateContactTVText) && mwqmSubsectorLanguage.LastUpdateContactTVText.Length > 200)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.LanguageText) && mwqmSubsectorLanguage.LanguageText.Length > 100)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.TranslationStatusSubsectorDescText) && mwqmSubsectorLanguage.TranslationStatusSubsectorDescText.Length > 100)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusSubsectorDescText, "100"), new[] { "TranslationStatusSubsectorDescText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.TranslationStatusLogBookText) && mwqmSubsectorLanguage.TranslationStatusLogBookText.Length > 100)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorLanguageTranslationStatusLogBookText, "100"), new[] { "TranslationStatusLogBookText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
            IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery = (from c in GetRead()
                                                where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                                select c);

            return FillMWQMSubsectorLanguage(mwqmSubsectorLanguageQuery).FirstOrDefault();
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
        public IQueryable<MWQMSubsectorLanguage> GetRead()
        {
            return db.MWQMSubsectorLanguages.AsNoTracking();
        }
        public IQueryable<MWQMSubsectorLanguage> GetEdit()
        {
            return db.MWQMSubsectorLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMSubsectorLanguage> FillMWQMSubsectorLanguage(IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery)
        {
            List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList = (from c in mwqmSubsectorLanguageQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMSubsectorLanguage
                                         {
                                             MWQMSubsectorLanguageID = c.MWQMSubsectorLanguageID,
                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                             Language = c.Language,
                                             SubsectorDesc = c.SubsectorDesc,
                                             TranslationStatusSubsectorDesc = c.TranslationStatusSubsectorDesc,
                                             LogBook = c.LogBook,
                                             TranslationStatusLogBook = c.TranslationStatusLogBook,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MWQMSubsectorLanguage mwqmSubsectorLanguage in MWQMSubsectorLanguageList)
            {
                mwqmSubsectorLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)mwqmSubsectorLanguage.Language);
                mwqmSubsectorLanguage.TranslationStatusSubsectorDescText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusSubsectorDesc);
                mwqmSubsectorLanguage.TranslationStatusLogBookText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)mwqmSubsectorLanguage.TranslationStatusLogBook);
            }

            return MWQMSubsectorLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
