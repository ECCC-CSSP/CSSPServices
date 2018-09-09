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
    public partial class MWQMSubsectorLanguageService
    {
        #region Functions private Generated FillMWQMSubsectorLanguage_A
        private IQueryable<MWQMSubsectorLanguage_A> FillMWQMSubsectorLanguage_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<MWQMSubsectorLanguage_A> MWQMSubsectorLanguage_AQuery = (from c in db.MWQMSubsectorLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSubsectorLanguage_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusSubsectorDescText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusSubsectorDesc
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusLogBookText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatusLogBook
                                select e.EnumText).FirstOrDefault(),
                        MWQMSubsectorLanguageID = c.MWQMSubsectorLanguageID,
                        MWQMSubsectorID = c.MWQMSubsectorID,
                        Language = c.Language,
                        SubsectorDesc = c.SubsectorDesc,
                        TranslationStatusSubsectorDesc = c.TranslationStatusSubsectorDesc,
                        LogBook = c.LogBook,
                        TranslationStatusLogBook = c.TranslationStatusLogBook,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSubsectorLanguage_AQuery;
        }
        #endregion Functions private Generated FillMWQMSubsectorLanguage_A

    }
}
