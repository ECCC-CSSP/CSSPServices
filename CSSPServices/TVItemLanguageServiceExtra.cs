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
    public partial class TVItemLanguageService
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
        #endregion Function public

        #region Function private
        private IQueryable<TVItemLanguage> FillTVItemLanguageReport(IQueryable<TVItemLanguage> tvItemLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            tvItemLanguageQuery = (from c in tvItemLanguageQuery
                                   let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                  where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                  && cl.Language == LanguageRequest
                                                                  select cl.TVText).FirstOrDefault()
                                   select new TVItemLanguage
                                   {
                                       TVItemLanguageID = c.TVItemLanguageID,
                                       TVItemID = c.TVItemID,
                                       Language = c.Language,
                                       TVText = c.TVText,
                                       TranslationStatus = c.TranslationStatus,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       TVItemLanguageWeb = new TVItemLanguageWeb
                                       {
                                           LastUpdateContactTVText = LastUpdateContactTVText,
                                           LanguageText = (from e in LanguageEnumList
                                                           where e.EnumID == (int?)c.Language
                                                           select e.EnumText).FirstOrDefault(),
                                           TranslationStatusText = (from e in TranslationStatusEnumList
                                                                    where e.EnumID == (int?)c.TranslationStatus
                                                                    select e.EnumText).FirstOrDefault(),
                                       },
                                       TVItemLanguageReport = new TVItemLanguageReport
                                       {
                                           TVItemLanguageReportTest = "TVItemLanguageReportTest",
                                       },
                                       HasErrors = false,
                                       ValidationResults = null,
                                   });

            return tvItemLanguageQuery;
        }
        #endregion Functions private    
    }
}
