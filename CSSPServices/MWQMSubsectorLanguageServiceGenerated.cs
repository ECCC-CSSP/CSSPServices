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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSubsectorLanguage.MWQMSubsectorLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID), new[] { "MWQMSubsectorLanguageID" });
                }
            }

            //MWQMSubsectorLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MWQMSubsector MWQMSubsectorMWQMSubsectorID = (from c in db.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();

            if (MWQMSubsectorMWQMSubsectorID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMSubsector, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), new[] { "MWQMSubsectorID" });
            }

            retStr = enums.LanguageOK(mwqmSubsectorLanguage.Language);
            if (mwqmSubsectorLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageSubsectorDesc), new[] { "SubsectorDesc" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc) && mwqmSubsectorLanguage.SubsectorDesc.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250"), new[] { "SubsectorDesc" });
            }

            retStr = enums.TranslationStatusOK(mwqmSubsectorLanguage.TranslationStatus);
            if (mwqmSubsectorLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.LastUpdateContactTVText) && mwqmSubsectorLanguage.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.LanguageText) && mwqmSubsectorLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.TranslationStatusText) && mwqmSubsectorLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
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
            if (!db.MWQMSubsectorLanguages.Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
            {
                mwqmSubsectorLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool Update(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            if (!db.MWQMSubsectorLanguages.Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
            {
                mwqmSubsectorLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

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
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MWQMSubsectorLanguage mwqmSubsectorLanguage in MWQMSubsectorLanguageList)
            {
                mwqmSubsectorLanguage.LanguageText = enums.GetEnumText_LanguageEnum(mwqmSubsectorLanguage.Language);
                mwqmSubsectorLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(mwqmSubsectorLanguage.TranslationStatus);
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
