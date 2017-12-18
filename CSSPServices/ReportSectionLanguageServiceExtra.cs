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
    public partial class ReportSectionLanguageService
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
        private IQueryable<ReportSectionLanguage> FillReportSectionLanguageReport(IQueryable<ReportSectionLanguage> ReportSectionLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            ReportSectionLanguageQuery = (from c in ReportSectionLanguageQuery
                                       let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                      where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                      && cl.Language == LanguageRequest
                                                                      select cl.TVText).FirstOrDefault()
                                       select new ReportSectionLanguage
                                       {
                                           ReportSectionLanguageID = c.ReportSectionLanguageID,
                                           ReportSectionID = c.ReportSectionID,
                                           Language = c.Language,
                                           ReportSectionName = c.ReportSectionName,
                                           TranslationStatusReportSectionName = c.TranslationStatusReportSectionName,
                                           ReportSectionText = c.ReportSectionText,
                                           TranslationStatusReportSectionText = c.TranslationStatusReportSectionText,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           ReportSectionLanguageWeb = new ReportSectionLanguageWeb
                                           {
                                               LastUpdateContactTVText = LastUpdateContactTVText,
                                               LanguageText = (from e in LanguageEnumList
                                                               where e.EnumID == (int?)c.Language
                                                               select e.EnumText).FirstOrDefault(),
                                               TranslationStatusReportSectionNameText = (from e in TranslationStatusEnumList
                                                                                         where e.EnumID == (int?)c.TranslationStatusReportSectionName
                                                                                         select e.EnumText).FirstOrDefault(),
                                               TranslationStatusReportSectionNameTextText = (from e in TranslationStatusEnumList
                                                                                             where e.EnumID == (int?)c.TranslationStatusReportSectionText
                                                                                             select e.EnumText).FirstOrDefault(),
                                           },
                                           ReportSectionLanguageReport = new ReportSectionLanguageReport
                                           {
                                               ReportSectionLanguageReportTest = "ReportSectionLanguageReportTest",
                                           },
                                           HasErrors = false,
                                           ValidationResults = null,
                                       });

            return ReportSectionLanguageQuery;
        }
        #endregion Functions private
    }
}
