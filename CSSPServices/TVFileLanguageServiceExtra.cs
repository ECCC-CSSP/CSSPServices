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
    public partial class TVFileLanguageService
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
        private IQueryable<TVFileLanguage> FillTVFileLanguageReport(IQueryable<TVFileLanguage> tvFileLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            tvFileLanguageQuery = (from c in tvFileLanguageQuery
                                   let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                  where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                  && cl.Language == LanguageRequest
                                                                  select cl.TVText).FirstOrDefault()
                                   select new TVFileLanguage
                                   {
                                       TVFileLanguageID = c.TVFileLanguageID,
                                       TVFileID = c.TVFileID,
                                       Language = c.Language,
                                       FileDescription = c.FileDescription,
                                       TranslationStatus = c.TranslationStatus,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       TVFileLanguageWeb = new TVFileLanguageWeb
                                       {
                                           LastUpdateContactTVText = LastUpdateContactTVText,
                                           LanguageText = (from e in LanguageEnumList
                                                           where e.EnumID == (int?)c.Language
                                                           select e.EnumText).FirstOrDefault(),
                                           TranslationStatusText = (from e in TranslationStatusEnumList
                                                                    where e.EnumID == (int?)c.TranslationStatus
                                                                    select e.EnumText).FirstOrDefault(),
                                       },
                                       TVFileLanguageReport = new TVFileLanguageReport
                                       {
                                           TVFileLanguageReportTest = "TVFileLanguageReportTest",
                                       },
                                       HasErrors = false,
                                       ValidationResults = null,
                                   });

            return tvFileLanguageQuery;
        }
        #endregion Functions private
    }
}
