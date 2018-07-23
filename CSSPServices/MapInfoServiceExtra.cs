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
    public partial class MapInfoService
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
        private IQueryable<MapInfo> FillMapInfoReport(IQueryable<MapInfo> mapInfoQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> MapInfoDrawTypeEnumList = enums.GetEnumTextOrderedList(typeof(MapInfoDrawTypeEnum));

            mapInfoQuery = (from c in mapInfoQuery
                            let TVText = (from cl in db.TVItemLanguages
                                          where cl.TVItemID == c.TVItemID
                                          && cl.Language == LanguageRequest
                                          select cl.TVText).FirstOrDefault()
                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                            select new MapInfo
                            {
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
                                MapInfoWeb = new MapInfoWeb
                                {
                                    TVText = TVText,
                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                    TVTypeText = (from e in TVTypeEnumList
                                                  where e.EnumID == (int?)c.TVType
                                                  select e.EnumText).FirstOrDefault(),
                                    MapInfoDrawTypeText = (from e in MapInfoDrawTypeEnumList
                                                           where e.EnumID == (int?)c.MapInfoDrawType
                                                           select e.EnumText).FirstOrDefault(),
                                },
                                MapInfoReport = new MapInfoReport
                                {
                                    MapInfoReportTest = "MapInfoReportTest",
                                },
                                HasErrors = false,
                                ValidationResults = null,
                            });

            return mapInfoQuery;
        }
        #endregion Functions private
    }
}
