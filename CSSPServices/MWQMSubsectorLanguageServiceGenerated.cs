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
        public MWQMSubsectorLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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

            MWQMSubsector MWQMSubsectorMWQMSubsectorID = (from c in db.MWQMSubsectors where c.MWQMSubsectorID == mwqmSubsectorLanguage.MWQMSubsectorID select c).FirstOrDefault();

            if (MWQMSubsectorMWQMSubsectorID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsector, CSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, (mwqmSubsectorLanguage.MWQMSubsectorID == null ? "" : mwqmSubsectorLanguage.MWQMSubsectorID.ToString())), new[] { "MWQMSubsectorID" });
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

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, (mwqmSubsectorLanguage.LastUpdateContactTVItemID == null ? "" : mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSubsectorLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSubsectorLanguage GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageID(int MWQMSubsectorLanguageID, GetParam getParam)
        {
            IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMSubsectorLanguageID == MWQMSubsectorLanguageID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSubsectorLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMWQMSubsectorLanguageWeb(mwqmSubsectorLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSubsectorLanguageReport(mwqmSubsectorLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMSubsectorLanguage> GetMWQMSubsectorLanguageList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorLanguageQuery  = mwqmSubsectorLanguageQuery.OrderByDescending(c => c.MWQMSubsectorLanguageID);
                        }
                        mwqmSubsectorLanguageQuery = mwqmSubsectorLanguageQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorLanguageQuery = FillMWQMSubsectorLanguageWeb(mwqmSubsectorLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMSubsectorLanguageID);
                        }
                        mwqmSubsectorLanguageQuery = FillMWQMSubsectorLanguageWeb(mwqmSubsectorLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorLanguageQuery = FillMWQMSubsectorLanguageReport(mwqmSubsectorLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMSubsectorLanguageID);
                        }
                        mwqmSubsectorLanguageQuery = FillMWQMSubsectorLanguageReport(mwqmSubsectorLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorLanguageQuery;
                    }
                default:
                    return null;
            }
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
            if (GetParam.OrderAscending)
            {
                return db.MWQMSubsectorLanguages.AsNoTracking();
            }
            else
            {
                return db.MWQMSubsectorLanguages.AsNoTracking().OrderByDescending(c => c.MWQMSubsectorLanguageID);
            }
        }
        public IQueryable<MWQMSubsectorLanguage> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.MWQMSubsectorLanguages;
            }
            else
            {
                return db.MWQMSubsectorLanguages.OrderByDescending(c => c.MWQMSubsectorLanguageID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSubsectorLanguageFillWeb
        private IQueryable<MWQMSubsectorLanguage> FillMWQMSubsectorLanguageWeb(IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            mwqmSubsectorLanguageQuery = (from c in mwqmSubsectorLanguageQuery
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
                        MWQMSubsectorLanguageWeb = new MWQMSubsectorLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusSubsectorDescText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusSubsectorDesc
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusLogBookText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusLogBook
                                select e.EnumText).FirstOrDefault(),
                        },
                        MWQMSubsectorLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmSubsectorLanguageQuery;
        }
        #endregion Functions private Generated MWQMSubsectorLanguageFillWeb

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
