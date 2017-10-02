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
    public partial class MWQMSampleService
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
        private IQueryable<MWQMSample> FillMWQMSampleReport(IQueryable<MWQMSample> mwqmSampleQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            mwqmSampleQuery = (from c in mwqmSampleQuery
                               let MWQMSiteTVText = (from cl in db.TVItemLanguages
                                                     where cl.TVItemID == c.MWQMSiteTVItemID
                                                     && cl.Language == LanguageRequest
                                                     select cl.TVText).FirstOrDefault()
                               let MWQMRunTVText = (from cl in db.TVItemLanguages
                                                    where cl.TVItemID == c.MWQMRunTVItemID
                                                    && cl.Language == LanguageRequest
                                                    select cl.TVText).FirstOrDefault()
                               let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                               select new MWQMSample
                               {
                                   MWQMSampleID = c.MWQMSampleID,
                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                   MWQMRunTVItemID = c.MWQMRunTVItemID,
                                   SampleDateTime_Local = c.SampleDateTime_Local,
                                   Depth_m = c.Depth_m,
                                   FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                   Salinity_PPT = c.Salinity_PPT,
                                   WaterTemp_C = c.WaterTemp_C,
                                   PH = c.PH,
                                   SampleTypesText = c.SampleTypesText,
                                   SampleType_old = c.SampleType_old,
                                   Tube_10 = c.Tube_10,
                                   Tube_1_0 = c.Tube_1_0,
                                   Tube_0_1 = c.Tube_0_1,
                                   ProcessedBy = c.ProcessedBy,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   MWQMSampleWeb = new MWQMSampleWeb
                                   {
                                       MWQMSiteTVText = MWQMSiteTVText,
                                       MWQMRunTVText = MWQMRunTVText,
                                       LastUpdateContactTVText = LastUpdateContactTVText,
                                       SampleType_oldText = (from e in SampleTypeEnumList
                                                             where e.EnumID == (int?)c.SampleType_old
                                                             select e.EnumText).FirstOrDefault(),
                                   },
                                   MWQMSampleReport = new MWQMSampleReport
                                   {
                                       MWQMSampleReportTest = "MWQMSampleReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return mwqmSampleQuery;
        }
        #endregion Functions private
    }
}
