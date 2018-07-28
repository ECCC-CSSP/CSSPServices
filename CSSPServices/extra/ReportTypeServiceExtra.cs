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
    public partial class ReportTypeService
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
        private IQueryable<ReportType> FillReportTypeReport(IQueryable<ReportType> ReportTypeQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            ReportTypeQuery = (from c in ReportTypeQuery
                               let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                               select new ReportType
                               {
                                   ReportTypeID = c.ReportTypeID,
                                   TVType = c.TVType,
                                   FileType = c.FileType,
                                   UniqueCode = c.UniqueCode,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   ReportTypeWeb = new ReportTypeWeb
                                   {
                                       LastUpdateContactTVText = LastUpdateContactTVText,
                                   },
                                   ReportTypeReport = new ReportTypeReport
                                   {
                                       ReportTypeReportTest = "ReportTypeReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return ReportTypeQuery;
        }
        #endregion Functions private
    }
}
