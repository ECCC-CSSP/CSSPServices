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
    public partial class AppTaskLanguageService
    {
        #region Functions private Generated AppTaskLanguageFillReport
        private IQueryable<AppTaskLanguageReport> FillAppTaskLanguageReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<AppTaskLanguageReport>  AppTaskLanguageReportQuery = (from c in db.AppTaskLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AppTaskLanguageReport
                    {
                        AppTaskLanguageReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        AppTaskLanguageID = c.AppTaskLanguageID,
                        AppTaskID = c.AppTaskID,
                        Language = c.Language,
                        StatusText = c.StatusText,
                        ErrorText = c.ErrorText,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return AppTaskLanguageReportQuery;
        }
        #endregion Functions private Generated AppTaskLanguageFillReport

    }
}
