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
    public partial class ReportTypeLanguageService
    {
        #region Functions private Generated ReportTypeLanguageFillReport
        private IQueryable<ReportTypeLanguageReport> FillReportTypeLanguageReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<ReportTypeLanguageReport>  ReportTypeLanguageReportQuery = (from c in db.ReportTypeLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportTypeLanguageReport
                    {
                        ReportTypeLanguageReportTest = "Testing Report",
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ReportTypeLanguageReportQuery;
        }
        #endregion Functions private Generated ReportTypeLanguageFillReport

    }
}
