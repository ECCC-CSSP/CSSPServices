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
    ///     <para>bonjour MWQMSampleLanguage</para>
    /// </summary>
    public partial class MWQMSampleLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSampleLanguage mwqmSampleLanguage = validationContext.ObjectInstance as MWQMSampleLanguage;
            mwqmSampleLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSampleLanguage.MWQMSampleLanguageID == 0)
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageMWQMSampleLanguageID), new[] { "MWQMSampleLanguageID" });
                }

                if (!GetRead().Where(c => c.MWQMSampleLanguageID == mwqmSampleLanguage.MWQMSampleLanguageID).Any())
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSampleLanguage, CSSPModelsRes.MWQMSampleLanguageMWQMSampleLanguageID, mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), new[] { "MWQMSampleLanguageID" });
                }
            }

            //MWQMSampleLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSampleID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MWQMSample MWQMSampleMWQMSampleID = (from c in db.MWQMSamples where c.MWQMSampleID == mwqmSampleLanguage.MWQMSampleID select c).FirstOrDefault();

            if (MWQMSampleMWQMSampleID == null)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSample, CSSPModelsRes.MWQMSampleLanguageMWQMSampleID, mwqmSampleLanguage.MWQMSampleID.ToString()), new[] { "MWQMSampleID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSampleLanguage.Language);
            if (mwqmSampleLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleLanguage.MWQMSampleNote))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageMWQMSampleNote), new[] { "MWQMSampleNote" });
            }

            //MWQMSampleNote has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSampleLanguage.TranslationStatus);
            if (mwqmSampleLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

                //Error: Type not implemented [MWQMSampleLanguageWeb] of type [MWQMSampleLanguageWeb]
                //Error: Type not implemented [MWQMSampleLanguageReport] of type [MWQMSampleLanguageReport]
            if (mwqmSampleLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSampleLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSampleLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSampleLanguage GetMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMSampleLanguageID == MWQMSampleLanguageID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSampleLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSampleLanguage(mwqmSampleLanguageQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMSampleLanguage> GetMWQMSampleLanguageList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSampleLanguageQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSampleLanguage(mwqmSampleLanguageQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Create);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Add(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool Delete(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Delete);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Remove(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool Update(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Update);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Update(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public IQueryable<MWQMSampleLanguage> GetRead()
        {
            return db.MWQMSampleLanguages.AsNoTracking();
        }
        public IQueryable<MWQMSampleLanguage> GetEdit()
        {
            return db.MWQMSampleLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<MWQMSampleLanguage> FillMWQMSampleLanguage_Show_Copy_To_MWQMSampleLanguageServiceExtra_As_Fill_MWQMSampleLanguage(IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            mwqmSampleLanguageQuery = (from c in mwqmSampleLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMSampleLanguage
                    {
                        MWQMSampleLanguageID = c.MWQMSampleLanguageID,
                        MWQMSampleID = c.MWQMSampleID,
                        Language = c.Language,
                        MWQMSampleNote = c.MWQMSampleNote,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        MWQMSampleLanguageWeb = new MWQMSampleLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        MWQMSampleLanguageReport = new MWQMSampleLanguageReport
                        {
                            MWQMSampleLanguageReportTest = "MWQMSampleLanguageReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmSampleLanguageQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMSampleLanguage mwqmSampleLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSampleLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
