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
        #region Functions private Generated FillReportSectionLanguageExtraA
        private IQueryable<ReportSectionLanguageExtraA> FillReportSectionLanguageExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<ReportSectionLanguageExtraA> ReportSectionLanguageExtraAQuery = (from c in db.ReportSectionLanguages
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusReportSectionNameText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusReportSectionName
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusReportSectionNameTextText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusReportSectionText
                    select e.EnumText).FirstOrDefault()
                    select new ReportSectionLanguageExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        LanguageText = LanguageText,
                        TranslationStatusReportSectionNameText = TranslationStatusReportSectionNameText,
                        TranslationStatusReportSectionNameTextText = TranslationStatusReportSectionNameTextText,
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

            return ReportSectionLanguageExtraAQuery;
        }
        #endregion Functions private Generated FillReportSectionLanguageExtraA

    }
}
