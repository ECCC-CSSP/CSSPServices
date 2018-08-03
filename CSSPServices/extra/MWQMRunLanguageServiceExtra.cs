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
    public partial class MWQMRunLanguageService
    {
        #region Functions private Generated MWQMRunLanguageFillReport
        private IQueryable<MWQMRunLanguageReport> FillMWQMRunLanguageReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<MWQMRunLanguageReport>  MWQMRunLanguageReportQuery = (from c in db.MWQMRunLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMRunLanguageReport
                    {
                        MWQMRunLanguageReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusRunCommentText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusRunComment
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusRunWeatherCommentText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusRunWeatherComment
                                select e.EnumText).FirstOrDefault(),
                        MWQMRunLanguageID = c.MWQMRunLanguageID,
                        MWQMRunID = c.MWQMRunID,
                        Language = c.Language,
                        RunComment = c.RunComment,
                        TranslationStatusRunComment = c.TranslationStatusRunComment,
                        RunWeatherComment = c.RunWeatherComment,
                        TranslationStatusRunWeatherComment = c.TranslationStatusRunWeatherComment,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMRunLanguageReportQuery;
        }
        #endregion Functions private Generated MWQMRunLanguageFillReport

    }
}