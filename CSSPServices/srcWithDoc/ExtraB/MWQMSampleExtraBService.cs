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
        #region Functions private Generated FillMWQMSampleExtraB
        private IQueryable<MWQMSampleExtraB> FillMWQMSampleExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

             IQueryable<MWQMSampleExtraB> MWQMSampleExtraBQuery = (from c in db.MWQMSamples
                let MWQMSampleReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMRunText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMRunTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SampleType_oldText = (from e in SampleTypeEnumList
                    where e.EnumID == (int?)c.SampleType_old
                    select e.EnumText).FirstOrDefault()
                    select new MWQMSampleExtraB
                    {
                        MWQMSampleReportTest = MWQMSampleReportTest,
                        MWQMSiteText = MWQMSiteText,
                        MWQMRunText = MWQMRunText,
                        LastUpdateContactText = LastUpdateContactText,
                        SampleType_oldText = SampleType_oldText,
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

            return MWQMSampleExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMSampleExtraB

    }
}