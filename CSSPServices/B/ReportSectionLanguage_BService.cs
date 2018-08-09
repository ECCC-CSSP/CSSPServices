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
    public partial class ReportSectionLanguageService
    {
        #region Functions private Generated FillReportSectionLanguage_B
        private IQueryable<ReportSectionLanguage_B> FillReportSectionLanguage_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<ReportSectionLanguage_B> ReportSectionLanguage_BQuery = (from c in db.ReportSectionLanguages
                let ReportSectionLanguageReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportSectionLanguage_B
                    {
                        ReportSectionLanguageReportTest = ReportSectionLanguageReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusReportSectionNameText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusReportSectionName
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusReportSectionNameTextText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusReportSectionText
                                select e.EnumText).FirstOrDefault(),
                        ReportSectionLanguageID = c.ReportSectionLanguageID,
                        ReportSectionID = c.ReportSectionID,
                        Language = c.Language,
                        ReportSectionName = c.ReportSectionName,
                        TranslationStatusReportSectionName = c.TranslationStatusReportSectionName,
                        ReportSectionText = c.ReportSectionText,
                        TranslationStatusReportSectionText = c.TranslationStatusReportSectionText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ReportSectionLanguage_BQuery;
        }
        #endregion Functions private Generated FillReportSectionLanguage_B

    }
}
