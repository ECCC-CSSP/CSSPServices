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
        #region Functions private Generated FillMapInfo_A
        private IQueryable<MapInfo_A> FillMapInfo_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> MapInfoDrawTypeEnumList = enums.GetEnumTextOrderedList(typeof(MapInfoDrawTypeEnum));

             IQueryable<MapInfo_A> MapInfo_AQuery = (from c in db.MapInfos
                let TVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MapInfo_A
                    {
                        TVItemLanguage = TVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        MapInfoDrawTypeText = (from e in MapInfoDrawTypeEnumList
                                where e.EnumID == (int?)c.MapInfoDrawType
                                select e.EnumText).FirstOrDefault(),
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

            return MapInfo_AQuery;
        }
        #endregion Functions private Generated FillMapInfo_A

    }
}
