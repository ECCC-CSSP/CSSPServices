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
    public partial class ReportSectionService
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
        private IQueryable<ReportSection> FillReportSectionReport(IQueryable<ReportSection> ReportSectionQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            ReportSectionQuery = (from c in ReportSectionQuery
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  let ReportSectionName = (from cl in db.ReportSectionLanguages
                                                           where cl.ReportSectionID == c.ReportSectionID
                                                           && cl.Language == LanguageRequest
                                                           select cl.ReportSectionName).FirstOrDefault()
                                  let ReportSectionText = (from cl in db.ReportSectionLanguages
                                                           where cl.ReportSectionID == c.ReportSectionID
                                                           && cl.Language == LanguageRequest
                                                           select cl.ReportSectionText).FirstOrDefault()
                                  select new ReportSection
                               {
                                   ReportSectionID = c.ReportSectionID,
                                   ReportTypeID = c.ReportTypeID,
                                   TVItemID = c.TVItemID,
                                   Ordinal = c.Ordinal,
                                   IsStatic = c.IsStatic,
                                   ParentReportSectionID = c.ParentReportSectionID,
                                   Year = c.Year,
                                   Locked = c.Locked,
                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   ReportSectionWeb = new ReportSectionWeb
                                   {
                                       LastUpdateContactTVText = LastUpdateContactTVText,
                                       ReportSectionName = ReportSectionName,
                                       ReportSectionText = ReportSectionText,
                                   },
                                   ReportSectionReport = new ReportSectionReport
                                   {
                                       ReportSectionReportTest = "ReportSectionReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return ReportSectionQuery;
        }
        #endregion Functions private
    }
}
