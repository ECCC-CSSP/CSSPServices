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
    public partial class MWQMSampleService
    {
        #region Functions private Generated FillMWQMSample_B
        private IQueryable<MWQMSample_B> FillMWQMSample_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

             IQueryable<MWQMSample_B> MWQMSample_BQuery = (from c in db.MWQMSamples
                let MWQMSampleReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let MWQMRunTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMRunTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSample_B
                    {
                        MWQMSampleReportTest = MWQMSampleReportTest,
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        MWQMRunTVItemLanguage = MWQMRunTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SampleType_oldText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType_old
                                select e.EnumText).FirstOrDefault(),
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
                        UseForOpenData = c.UseForOpenData,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSample_BQuery;
        }
        #endregion Functions private Generated FillMWQMSample_B

    }
}
