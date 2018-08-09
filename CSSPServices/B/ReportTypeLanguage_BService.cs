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
        #region Functions private Generated FillReportTypeLanguage_B
        private IQueryable<ReportTypeLanguage_B> FillReportTypeLanguage_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<ReportTypeLanguage_B> ReportTypeLanguage_BQuery = (from c in db.ReportTypeLanguages
                let ReportTypeLanguageReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportTypeLanguage_B
                    {
                        ReportTypeLanguageReportTest = ReportTypeLanguageReportTest,
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

            return ReportTypeLanguage_BQuery;
        }
        #endregion Functions private Generated FillReportTypeLanguage_B

    }
}
