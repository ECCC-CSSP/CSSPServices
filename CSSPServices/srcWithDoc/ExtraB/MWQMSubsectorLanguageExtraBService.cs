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
        #region Functions private Generated FillMWQMSubsectorLanguageExtraB
        private IQueryable<MWQMSubsectorLanguageExtraB> FillMWQMSubsectorLanguageExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<MWQMSubsectorLanguageExtraB> MWQMSubsectorLanguageExtraBQuery = (from c in db.MWQMSubsectorLanguages
                let MWQMSubsectorLanguageReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusSubsectorDescText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusSubsectorDesc
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusLogBookText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatusLogBook
                    select e.EnumText).FirstOrDefault()
                    select new MWQMSubsectorLanguageExtraB
                    {
                        MWQMSubsectorLanguageReportTest = MWQMSubsectorLanguageReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        LanguageText = LanguageText,
                        TranslationStatusSubsectorDescText = TranslationStatusSubsectorDescText,
                        TranslationStatusLogBookText = TranslationStatusLogBookText,
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

            return MWQMSubsectorLanguageExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMSubsectorLanguageExtraB

    }
}
