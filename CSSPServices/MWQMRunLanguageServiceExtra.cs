using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class MWQMRunLanguageService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<MWQMRunLanguage> FillMWQMRunLanguageReport(IQueryable<MWQMRunLanguage> mwqmRunLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            mwqmRunLanguageQuery = (from c in mwqmRunLanguageQuery
                                    let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                   where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                   && cl.Language == LanguageRequest
                                                                   select cl.TVText).FirstOrDefault()
                                    select new MWQMRunLanguage
                                    {
                                        MWQMRunLanguageID = c.MWQMRunLanguageID,
                                        MWQMRunID = c.MWQMRunID,
                                        Language = c.Language,
                                        RunComment = c.RunComment,
                                        TranslationStatusRunComment = c.TranslationStatusRunComment,
                                        RunWeatherComment = c.RunWeatherComment,
                                        TranslationStatusRunWeatherComment = c.TranslationStatusRunWeatherComment,
                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                        MWQMRunLanguageWeb = new MWQMRunLanguageWeb
                                        {
                                            LastUpdateContactTVText = LastUpdateContactTVText,
                                            LanguageText = (from e in LanguageEnumList
                                                            where e.EnumID == (int?)c.Language
                                                            select e.EnumText).FirstOrDefault(),
                                            TranslationStatusRunCommentText = (from e in TranslationStatusEnumList
                                                                               where e.EnumID == (int?)c.TranslationStatusRunComment
                                                                               select e.EnumText).FirstOrDefault(),
                                            TranslationStatusRunWeatherCommentText = (from e in TranslationStatusEnumList
                                                                                      where e.EnumID == (int?)c.TranslationStatusRunWeatherComment
                                                                                      select e.EnumText).FirstOrDefault(),
                                        },
                                        MWQMRunLanguageReport = new MWQMRunLanguageReport
                                        {
                                            MWQMRunLanguageReportTest = "MWQMRunLanguageReportTest",
                                        },
                                        HasErrors = false,
                                        ValidationResults = null,
                                    });

            return mwqmRunLanguageQuery;
        }
        #endregion Functions private
    }
}
