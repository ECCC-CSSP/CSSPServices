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
    ///     <para>bonjour ReportTypeLanguage</para>
    /// </summary>
    public partial class ReportTypeLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ReportTypeLanguage reportTypeLanguage = validationContext.ObjectInstance as ReportTypeLanguage;
            reportTypeLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportTypeLanguage.ReportTypeLanguageID == 0)
                {
                    reportTypeLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageReportTypeLanguageID), new[] { "ReportTypeLanguageID" });
                }

                if (!GetRead().Where(c => c.ReportTypeLanguageID == reportTypeLanguage.ReportTypeLanguageID).Any())
                {
                    reportTypeLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportTypeLanguage, CSSPModelsRes.ReportTypeLanguageReportTypeLanguageID, reportTypeLanguage.ReportTypeLanguageID.ToString()), new[] { "ReportTypeLanguageID" });
                }
            }

            ReportType ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == reportTypeLanguage.ReportTypeID select c).FirstOrDefault();

            if (ReportTypeReportTypeID == null)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportTypeLanguageReportTypeID, reportTypeLanguage.ReportTypeID.ToString()), new[] { "ReportTypeID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)reportTypeLanguage.Language);
            if (reportTypeLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(reportTypeLanguage.Name))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(reportTypeLanguage.Name) && reportTypeLanguage.Name.Length > 100)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageName, "100"), new[] { "Name" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)reportTypeLanguage.TranslationStatusName);
            if (reportTypeLanguage.TranslationStatusName == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusName), new[] { "TranslationStatusName" });
            }

            if (string.IsNullOrWhiteSpace(reportTypeLanguage.Description))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageDescription), new[] { "Description" });
            }

            if (!string.IsNullOrWhiteSpace(reportTypeLanguage.Description) && reportTypeLanguage.Description.Length > 1000)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageDescription, "1000"), new[] { "Description" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)reportTypeLanguage.TranslationStatusDescription);
            if (reportTypeLanguage.TranslationStatusDescription == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusDescription), new[] { "TranslationStatusDescription" });
            }

            if (string.IsNullOrWhiteSpace(reportTypeLanguage.StartOfFileName))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageStartOfFileName), new[] { "StartOfFileName" });
            }

            if (!string.IsNullOrWhiteSpace(reportTypeLanguage.StartOfFileName) && reportTypeLanguage.StartOfFileName.Length > 100)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageStartOfFileName, "100"), new[] { "StartOfFileName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)reportTypeLanguage.TranslationStatusStartOfFileName);
            if (reportTypeLanguage.TranslationStatusStartOfFileName == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusStartOfFileName), new[] { "TranslationStatusStartOfFileName" });
            }

            if (reportTypeLanguage.LastUpdateDate_UTC.Year == 1)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportTypeLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                reportTypeLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportTypeLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportTypeLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportTypeLanguageLastUpdateContactTVItemID, reportTypeLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    reportTypeLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportTypeLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                reportTypeLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ReportTypeLanguage GetReportTypeLanguageWithReportTypeLanguageID(int ReportTypeLanguageID)
        {
            IQueryable<ReportTypeLanguage> reportTypeLanguageQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ReportTypeLanguageID == ReportTypeLanguageID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return reportTypeLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillReportTypeLanguageWeb(reportTypeLanguageQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillReportTypeLanguageReport(reportTypeLanguageQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ReportTypeLanguage> GetReportTypeLanguageList()
        {
            IQueryable<ReportTypeLanguage> reportTypeLanguageQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        reportTypeLanguageQuery = EnhanceQueryStatements<ReportTypeLanguage>(reportTypeLanguageQuery) as IQueryable<ReportTypeLanguage>;

                        return reportTypeLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        reportTypeLanguageQuery = FillReportTypeLanguageWeb(reportTypeLanguageQuery);

                        reportTypeLanguageQuery = EnhanceQueryStatements<ReportTypeLanguage>(reportTypeLanguageQuery) as IQueryable<ReportTypeLanguage>;

                        return reportTypeLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        reportTypeLanguageQuery = FillReportTypeLanguageReport(reportTypeLanguageQuery);

                        reportTypeLanguageQuery = EnhanceQueryStatements<ReportTypeLanguage>(reportTypeLanguageQuery) as IQueryable<ReportTypeLanguage>;

                        return reportTypeLanguageQuery;
                    }
                default:
                    {
                        reportTypeLanguageQuery = reportTypeLanguageQuery.Where(c => c.ReportTypeLanguageID == 0);

                        return reportTypeLanguageQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ReportTypeLanguage reportTypeLanguage)
        {
            reportTypeLanguage.ValidationResults = Validate(new ValidationContext(reportTypeLanguage), ActionDBTypeEnum.Create);
            if (reportTypeLanguage.ValidationResults.Count() > 0) return false;

            db.ReportTypeLanguages.Add(reportTypeLanguage);

            if (!TryToSave(reportTypeLanguage)) return false;

            return true;
        }
        public bool Delete(ReportTypeLanguage reportTypeLanguage)
        {
            reportTypeLanguage.ValidationResults = Validate(new ValidationContext(reportTypeLanguage), ActionDBTypeEnum.Delete);
            if (reportTypeLanguage.ValidationResults.Count() > 0) return false;

            db.ReportTypeLanguages.Remove(reportTypeLanguage);

            if (!TryToSave(reportTypeLanguage)) return false;

            return true;
        }
        public bool Update(ReportTypeLanguage reportTypeLanguage)
        {
            reportTypeLanguage.ValidationResults = Validate(new ValidationContext(reportTypeLanguage), ActionDBTypeEnum.Update);
            if (reportTypeLanguage.ValidationResults.Count() > 0) return false;

            db.ReportTypeLanguages.Update(reportTypeLanguage);

            if (!TryToSave(reportTypeLanguage)) return false;

            return true;
        }
        public IQueryable<ReportTypeLanguage> GetRead()
        {
            IQueryable<ReportTypeLanguage> reportTypeLanguageQuery = db.ReportTypeLanguages.AsNoTracking();

            return reportTypeLanguageQuery;
        }
        public IQueryable<ReportTypeLanguage> GetEdit()
        {
            IQueryable<ReportTypeLanguage> reportTypeLanguageQuery = db.ReportTypeLanguages;

            return reportTypeLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ReportTypeLanguageFillWeb
        private IQueryable<ReportTypeLanguage> FillReportTypeLanguageWeb(IQueryable<ReportTypeLanguage> reportTypeLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            reportTypeLanguageQuery = (from c in reportTypeLanguageQuery
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportTypeLanguage
                    {
                        ReportTypeLanguageID = c.ReportTypeLanguageID,
                        ReportTypeID = c.ReportTypeID,
                        Language = c.Language,
                        Name = c.Name,
                        TranslationStatusName = c.TranslationStatusName,
                        Description = c.Description,
                        TranslationStatusDescription = c.TranslationStatusDescription,
                        StartOfFileName = c.StartOfFileName,
                        TranslationStatusStartOfFileName = c.TranslationStatusStartOfFileName,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ReportTypeLanguageWeb = new ReportTypeLanguageWeb
                        {
                            LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusNameText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusName
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusDescriptionText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusDescription
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusStartOfFileNameText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusStartOfFileName
                                select e.EnumText).FirstOrDefault(),
                        },
                        ReportTypeLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return reportTypeLanguageQuery;
        }
        #endregion Functions private Generated ReportTypeLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(ReportTypeLanguage reportTypeLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                reportTypeLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
