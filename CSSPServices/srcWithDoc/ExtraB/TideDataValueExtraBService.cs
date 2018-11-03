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
    public partial class TideDataValueService
    {
        #region Functions private Generated FillTideDataValueExtraB
        private IQueryable<TideDataValueExtraB> FillTideDataValueExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TideDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(TideDataTypeEnum));
            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));
            List<EnumIDAndText> TideTextEnumList = enums.GetEnumTextOrderedList(typeof(TideTextEnum));

             IQueryable<TideDataValueExtraB> TideDataValueExtraBQuery = (from c in db.TideDataValues
                let TideDataValueReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TideSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TideSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TideDataTypeText = (from e in TideDataTypeEnumList
                    where e.EnumID == (int?)c.TideDataType
                    select e.EnumText).FirstOrDefault()
                let StorageDataTypeText = (from e in StorageDataTypeEnumList
                    where e.EnumID == (int?)c.StorageDataType
                    select e.EnumText).FirstOrDefault()
                let TideStartText = (from e in TideTextEnumList
                    where e.EnumID == (int?)c.TideStart
                    select e.EnumText).FirstOrDefault()
                let TideEndText = (from e in TideTextEnumList
                    where e.EnumID == (int?)c.TideEnd
                    select e.EnumText).FirstOrDefault()
                    select new TideDataValueExtraB
                    {
                        TideDataValueReportTest = TideDataValueReportTest,
                        TideSiteText = TideSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        TideDataTypeText = TideDataTypeText,
                        StorageDataTypeText = StorageDataTypeText,
                        TideStartText = TideStartText,
                        TideEndText = TideEndText,
                        TideDataValueID = c.TideDataValueID,
                        TideSiteTVItemID = c.TideSiteTVItemID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        TideDataType = c.TideDataType,
                        StorageDataType = c.StorageDataType,
                        Depth_m = c.Depth_m,
                        UVelocity_m_s = c.UVelocity_m_s,
                        VVelocity_m_s = c.VVelocity_m_s,
                        TideStart = c.TideStart,
                        TideEnd = c.TideEnd,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TideDataValueExtraBQuery;
        }
        #endregion Functions private Generated FillTideDataValueExtraB

    }
}