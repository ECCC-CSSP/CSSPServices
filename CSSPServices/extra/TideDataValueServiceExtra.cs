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
        #region Functions private Generated TideDataValueFillReport
        private IQueryable<TideDataValueReport> FillTideDataValueReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TideDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(TideDataTypeEnum));
            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));
            List<EnumIDAndText> TideTextEnumList = enums.GetEnumTextOrderedList(typeof(TideTextEnum));

             IQueryable<TideDataValueReport>  TideDataValueReportQuery = (from c in db.TideDataValues
                let TideSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TideSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TideDataValueReport
                    {
                        TideDataValueReportTest = "Testing Report",
                        TideSiteTVItemLanguage = TideSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TideDataTypeText = (from e in TideDataTypeEnumList
                                where e.EnumID == (int?)c.TideDataType
                                select e.EnumText).FirstOrDefault(),
                        StorageDataTypeText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        TideStartText = (from e in TideTextEnumList
                                where e.EnumID == (int?)c.TideStart
                                select e.EnumText).FirstOrDefault(),
                        TideEndText = (from e in TideTextEnumList
                                where e.EnumID == (int?)c.TideEnd
                                select e.EnumText).FirstOrDefault(),
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
                    });

            return TideDataValueReportQuery;
        }
        #endregion Functions private Generated TideDataValueFillReport

    }
}
