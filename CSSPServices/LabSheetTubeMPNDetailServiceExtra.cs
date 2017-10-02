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
    public partial class LabSheetTubeMPNDetailService
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
        private IQueryable<LabSheetTubeMPNDetail> FillLabSheetTubeMPNDetailReport(IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            labSheetTubeMPNDetailQuery = (from c in labSheetTubeMPNDetailQuery
                                          let MWQMSiteTVText = (from cl in db.TVItemLanguages
                                                                where cl.TVItemID == c.MWQMSiteTVItemID
                                                                && cl.Language == LanguageRequest
                                                                select cl.TVText).FirstOrDefault()
                                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                         && cl.Language == LanguageRequest
                                                                         select cl.TVText).FirstOrDefault()
                                          select new LabSheetTubeMPNDetail
                                          {
                                              LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                                              LabSheetDetailID = c.LabSheetDetailID,
                                              Ordinal = c.Ordinal,
                                              MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                              SampleDateTime = c.SampleDateTime,
                                              MPN = c.MPN,
                                              Tube10 = c.Tube10,
                                              Tube1_0 = c.Tube1_0,
                                              Tube0_1 = c.Tube0_1,
                                              Salinity = c.Salinity,
                                              Temperature = c.Temperature,
                                              ProcessedBy = c.ProcessedBy,
                                              SampleType = c.SampleType,
                                              SiteComment = c.SiteComment,
                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                              LabSheetTubeMPNDetailWeb = new LabSheetTubeMPNDetailWeb
                                              {
                                                  MWQMSiteTVText = MWQMSiteTVText,
                                                  LastUpdateContactTVText = LastUpdateContactTVText,
                                                  SampleTypeText = (from e in SampleTypeEnumList
                                                                    where e.EnumID == (int?)c.SampleType
                                                                    select e.EnumText).FirstOrDefault(),
                                              },
                                              LabSheetTubeMPNDetailReport = new LabSheetTubeMPNDetailReport
                                              {
                                                  LabSheetTubeMPNDetailReportTest = "LabSheetTubeMPNDetailReportTest",
                                              },
                                              HasErrors = false,
                                              ValidationResults = null,
                                          });

            return labSheetTubeMPNDetailQuery;
        }
        #endregion Functions private
    }
}
