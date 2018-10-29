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
    public partial class TVFileLanguageService
    {
        #region Functions private Generated FillTVFileLanguageExtraA
        private IQueryable<TVFileLanguageExtraA> FillTVFileLanguageExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<TVFileLanguageExtraA> TVFileLanguageExtraAQuery = (from c in db.TVFileLanguages
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatus
                    select e.EnumText).FirstOrDefault()
                    select new TVFileLanguageExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        LanguageText = LanguageText,
                        TranslationStatusText = TranslationStatusText,
                        TVFileLanguageID = c.TVFileLanguageID,
                        TVFileID = c.TVFileID,
                        Language = c.Language,
                        FileDescription = c.FileDescription,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVFileLanguageExtraAQuery;
        }
        #endregion Functions private Generated FillTVFileLanguageExtraA

    }
}
