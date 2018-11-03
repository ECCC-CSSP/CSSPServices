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
        #region Functions private Generated FillMWQMRunLanguageExtraA
        private IQueryable<MWQMRunLanguageExtraA> FillMWQMRunLanguageExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<MWQMRunLanguageExtraA> MWQMRunLanguageExtraAQuery = (from c in db.MWQMRunLanguages
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusRunCommentText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusRunComment
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusRunWeatherCommentText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusRunWeatherComment
                    select e.EnumText).FirstOrDefault()
                    select new MWQMRunLanguageExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        LanguageText = LanguageText,
                        TranslationStatusRunCommentText = TranslationStatusRunCommentText,
                        TranslationStatusRunWeatherCommentText = TranslationStatusRunWeatherCommentText,
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
                    }).AsNoTracking();

            return MWQMRunLanguageExtraAQuery;
        }
        #endregion Functions private Generated FillMWQMRunLanguageExtraA

    }
}