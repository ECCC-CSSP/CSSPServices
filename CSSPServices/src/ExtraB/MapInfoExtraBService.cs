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
    public partial class MapInfoService
    {
        #region Functions private Generated FillMapInfoExtraB
        private IQueryable<MapInfoExtraB> FillMapInfoExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> MapInfoDrawTypeEnumList = enums.GetEnumTextOrderedList(typeof(MapInfoDrawTypeEnum));

             IQueryable<MapInfoExtraB> MapInfoExtraBQuery = (from c in db.MapInfos
                let MapInfoReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                let MapInfoDrawTypeText = (from e in MapInfoDrawTypeEnumList
                    where e.EnumID == (int?)c.MapInfoDrawType
                    select e.EnumText).FirstOrDefault()
                    select new MapInfoExtraB
                    {
                        MapInfoReportTest = MapInfoReportTest,
                        TVItemText = TVItemText,
                        LastUpdateContactText = LastUpdateContactText,
                        TVTypeText = TVTypeText,
                        MapInfoDrawTypeText = MapInfoDrawTypeText,
                        MapInfoID = c.MapInfoID,
                        TVItemID = c.TVItemID,
                        TVType = c.TVType,
                        LatMin = c.LatMin,
                        LatMax = c.LatMax,
                        LngMin = c.LngMin,
                        LngMax = c.LngMax,
                        MapInfoDrawType = c.MapInfoDrawType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MapInfoExtraBQuery;
        }
        #endregion Functions private Generated FillMapInfoExtraB

    }
}
