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
    public partial class AppTaskLanguageService
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
        private IQueryable<AppTaskLanguage> FillAppTaskLanguageReport(IQueryable<AppTaskLanguage> appTaskLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            appTaskLanguageQuery = (from c in appTaskLanguageQuery
                                    let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                   where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                   && cl.Language == LanguageRequest
                                                                   select cl.TVText).FirstOrDefault()
                                    select new AppTaskLanguage
                                    {
                                        AppTaskLanguageID = c.AppTaskLanguageID,
                                        AppTaskID = c.AppTaskID,
                                        Language = c.Language,
                                        StatusText = c.StatusText,
                                        ErrorText = c.ErrorText,
                                        TranslationStatus = c.TranslationStatus,
                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                        AppTaskLanguageWeb = new AppTaskLanguageWeb
                                        {
                                            LastUpdateContactTVText = LastUpdateContactTVText,
                                            LanguageText = (from e in LanguageEnumList
                                                            where e.EnumID == (int?)c.Language
                                                            select e.EnumText).FirstOrDefault(),
                                            TranslationStatusText = (from e in TranslationStatusEnumList
                                                                     where e.EnumID == (int?)c.TranslationStatus
                                                                     select e.EnumText).FirstOrDefault(),
                                        },
                                        AppTaskLanguageReport = new AppTaskLanguageReport
                                        {
                                            AppTaskLanguageReportTest = "AppTaskLanguageReportTest",
                                        },
                                        HasErrors = false,
                                        ValidationResults = null,
                                    });

            return appTaskLanguageQuery;
        }
        #endregion Functions private
    }
}
