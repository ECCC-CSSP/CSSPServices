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
    public partial class ReportTypeLanguageService
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
        private IQueryable<ReportTypeLanguage> FillReportTypeLanguageReport(IQueryable<ReportTypeLanguage> ReportTypeLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            ReportTypeLanguageQuery = (from c in ReportTypeLanguageQuery
                                       let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                      where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                      && cl.Language == LanguageRequest
                                                                      select cl.TVText).FirstOrDefault()
                                       select new ReportTypeLanguage
                                       {
                                           ReportTypeLanguageID = c.ReportTypeLanguageID,
                                           ReportTypeID = c.ReportTypeID,
                                           Language = c.Language,
                                           Name = c.Name,
                                           TranslationStatusName = c.TranslationStatusName,
                                           Description = c.Description,
                                           TranslationStatusDescription = c.TranslationStatusDescription,
                                           StartOfFileName = c.StartOfFileName,
                                           TranslationStatusStartOfFileName = c.TranslationStatusStartOfFileName,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           ReportTypeLanguageWeb = new ReportTypeLanguageWeb
                                           {
                                               LastUpdateContactTVText = LastUpdateContactTVText,
                                               LanguageText = (from e in LanguageEnumList
                                                               where e.EnumID == (int?)c.Language
                                                               select e.EnumText).FirstOrDefault(),
                                               TranslationStatusNameText = (from e in TranslationStatusEnumList
                                                                            where e.EnumID == (int?)c.TranslationStatusName
                                                                            select e.EnumText).FirstOrDefault(),
                                               TranslationStatusDescriptionText = (from e in TranslationStatusEnumList
                                                                                   where e.EnumID == (int?)c.TranslationStatusDescription
                                                                                   select e.EnumText).FirstOrDefault(),
                                               TranslationStatusStartOfFileNameText = (from e in TranslationStatusEnumList
                                                                                       where e.EnumID == (int?)c.TranslationStatusStartOfFileName
                                                                                       select e.EnumText).FirstOrDefault(),
                                           },
                                           ReportTypeLanguageReport = new ReportTypeLanguageReport
                                           {
                                               ReportTypeLanguageReportTest = "ReportTypeLanguageReportTest",
                                           },
                                           HasErrors = false,
                                           ValidationResults = null,
                                       });

            return ReportTypeLanguageQuery;
        }
        #endregion Functions private
    }
}
