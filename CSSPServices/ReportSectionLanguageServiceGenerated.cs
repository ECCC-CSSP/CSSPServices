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
    ///     <para>bonjour ReportSectionLanguage</para>
    /// </summary>
    public partial class ReportSectionLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ReportSectionLanguage reportSectionLanguage = validationContext.ObjectInstance as ReportSectionLanguage;
            reportSectionLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportSectionLanguage.ReportSectionLanguageID == 0)
                {
                    reportSectionLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionLanguageID), new[] { "ReportSectionLanguageID" });
                }

                if (!GetRead().Where(c => c.ReportSectionLanguageID == reportSectionLanguage.ReportSectionLanguageID).Any())
                {
                    reportSectionLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSectionLanguage, CSSPModelsRes.ReportSectionLanguageReportSectionLanguageID, reportSectionLanguage.ReportSectionLanguageID.ToString()), new[] { "ReportSectionLanguageID" });
                }
            }

            ReportSection ReportSectionReportSectionID = (from c in db.ReportSections where c.ReportSectionID == reportSectionLanguage.ReportSectionID select c).FirstOrDefault();

            if (ReportSectionReportSectionID == null)
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionLanguageReportSectionID, (reportSectionLanguage.ReportSectionID == null ? "" : reportSectionLanguage.ReportSectionID.ToString())), new[] { "ReportSectionID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportSectionLanguage.Language);
            if (reportSectionLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(reportSectionLanguage.ReportSectionName))
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionName), new[] { "ReportSectionName" });
            }

            if (!string.IsNullOrWhiteSpace(reportSectionLanguage.ReportSectionName) && reportSectionLanguage.ReportSectionName.Length > 100)
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportSectionLanguageReportSectionName, "100"), new[] { "ReportSectionName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)reportSectionLanguage.TranslationStatusReportSectionName);
            if (reportSectionLanguage.TranslationStatusReportSectionName == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageTranslationStatusReportSectionName), new[] { "TranslationStatusReportSectionName" });
            }

            if (string.IsNullOrWhiteSpace(reportSectionLanguage.ReportSectionText))
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionText), new[] { "ReportSectionText" });
            }

            if (!string.IsNullOrWhiteSpace(reportSectionLanguage.ReportSectionText) && reportSectionLanguage.ReportSectionText.Length > 10000)
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportSectionLanguageReportSectionText, "10000"), new[] { "ReportSectionText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)reportSectionLanguage.TranslationStatusReportSectionText);
            if (reportSectionLanguage.TranslationStatusReportSectionText == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageTranslationStatusReportSectionText), new[] { "TranslationStatusReportSectionText" });
            }

            if (reportSectionLanguage.LastUpdateDate_UTC.Year == 1)
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportSectionLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                reportSectionLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportSectionLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportSectionLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionLanguageLastUpdateContactTVItemID, (reportSectionLanguage.LastUpdateContactTVItemID == null ? "" : reportSectionLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    reportSectionLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                reportSectionLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ReportSectionLanguage GetReportSectionLanguageWithReportSectionLanguageID(int ReportSectionLanguageID, GetParam getParam)
        {
            IQueryable<ReportSectionLanguage> reportSectionLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ReportSectionLanguageID == ReportSectionLanguageID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return reportSectionLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillReportSectionLanguageWeb(reportSectionLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillReportSectionLanguageReport(reportSectionLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ReportSectionLanguage> GetReportSectionLanguageList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<ReportSectionLanguage> reportSectionLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportSectionLanguageQuery  = reportSectionLanguageQuery.OrderByDescending(c => c.ReportSectionLanguageID);
                        }
                        reportSectionLanguageQuery = reportSectionLanguageQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return reportSectionLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportSectionLanguageQuery = FillReportSectionLanguageWeb(reportSectionLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.ReportSectionLanguageID);
                        }
                        reportSectionLanguageQuery = FillReportSectionLanguageWeb(reportSectionLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return reportSectionLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportSectionLanguageQuery = FillReportSectionLanguageReport(reportSectionLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.ReportSectionLanguageID);
                        }
                        reportSectionLanguageQuery = FillReportSectionLanguageReport(reportSectionLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return reportSectionLanguageQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ReportSectionLanguage reportSectionLanguage)
        {
            reportSectionLanguage.ValidationResults = Validate(new ValidationContext(reportSectionLanguage), ActionDBTypeEnum.Create);
            if (reportSectionLanguage.ValidationResults.Count() > 0) return false;

            db.ReportSectionLanguages.Add(reportSectionLanguage);

            if (!TryToSave(reportSectionLanguage)) return false;

            return true;
        }
        public bool Delete(ReportSectionLanguage reportSectionLanguage)
        {
            reportSectionLanguage.ValidationResults = Validate(new ValidationContext(reportSectionLanguage), ActionDBTypeEnum.Delete);
            if (reportSectionLanguage.ValidationResults.Count() > 0) return false;

            db.ReportSectionLanguages.Remove(reportSectionLanguage);

            if (!TryToSave(reportSectionLanguage)) return false;

            return true;
        }
        public bool Update(ReportSectionLanguage reportSectionLanguage)
        {
            reportSectionLanguage.ValidationResults = Validate(new ValidationContext(reportSectionLanguage), ActionDBTypeEnum.Update);
            if (reportSectionLanguage.ValidationResults.Count() > 0) return false;

            db.ReportSectionLanguages.Update(reportSectionLanguage);

            if (!TryToSave(reportSectionLanguage)) return false;

            return true;
        }
        public IQueryable<ReportSectionLanguage> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.ReportSectionLanguages.AsNoTracking();
            }
            else
            {
                return db.ReportSectionLanguages.AsNoTracking().OrderByDescending(c => c.ReportSectionLanguageID);
            }
        }
        public IQueryable<ReportSectionLanguage> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.ReportSectionLanguages;
            }
            else
            {
                return db.ReportSectionLanguages.OrderByDescending(c => c.ReportSectionLanguageID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ReportSectionLanguageFillWeb
        private IQueryable<ReportSectionLanguage> FillReportSectionLanguageWeb(IQueryable<ReportSectionLanguage> reportSectionLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            reportSectionLanguageQuery = (from c in reportSectionLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ReportSectionLanguage
                    {
                        ReportSectionLanguageID = c.ReportSectionLanguageID,
                        ReportSectionID = c.ReportSectionID,
                        Language = c.Language,
                        ReportSectionName = c.ReportSectionName,
                        TranslationStatusReportSectionName = c.TranslationStatusReportSectionName,
                        ReportSectionText = c.ReportSectionText,
                        TranslationStatusReportSectionText = c.TranslationStatusReportSectionText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ReportSectionLanguageWeb = new ReportSectionLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusReportSectionNameText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusReportSectionName
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusReportSectionNameTextText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusReportSectionText
                                select e.EnumText).FirstOrDefault(),
                        },
                        ReportSectionLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return reportSectionLanguageQuery;
        }
        #endregion Functions private Generated ReportSectionLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(ReportSectionLanguage reportSectionLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                reportSectionLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
