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
    public partial class LabSheetTubeMPNDetailService
    {
        #region Functions private Generated FillLabSheetTubeMPNDetailExtraA
        private IQueryable<LabSheetTubeMPNDetailExtraA> FillLabSheetTubeMPNDetailExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

             IQueryable<LabSheetTubeMPNDetailExtraA> LabSheetTubeMPNDetailExtraAQuery = (from c in db.LabSheetTubeMPNDetails
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SampleTypeText = (from e in SampleTypeEnumList
                    where e.EnumID == (int?)c.SampleType
                    select e.EnumText).FirstOrDefault()
                    select new LabSheetTubeMPNDetailExtraA
                    {
                        MWQMSiteText = MWQMSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        SampleTypeText = SampleTypeText,
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return LabSheetTubeMPNDetailExtraAQuery;
        }
        #endregion Functions private Generated FillLabSheetTubeMPNDetailExtraA

    }
}
