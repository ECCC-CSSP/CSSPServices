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
    public partial class MapInfoPointService
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
        private IQueryable<MapInfoPoint> FillMapInfoPointReport(IQueryable<MapInfoPoint> mapInfoPointQuery)
        {
            mapInfoPointQuery = (from c in mapInfoPointQuery
                                 let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                && cl.Language == LanguageRequest
                                                                select cl).FirstOrDefault()
                                 select new MapInfoPoint
                                 {
                                     MapInfoPointID = c.MapInfoPointID,
                                     MapInfoID = c.MapInfoID,
                                     Ordinal = c.Ordinal,
                                     Lat = c.Lat,
                                     Lng = c.Lng,
                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     MapInfoPointWeb = new MapInfoPointWeb
                                     {
                                         LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                     },
                                     MapInfoPointReport = new MapInfoPointReport
                                     {
                                         MapInfoPointReportTest = "MapInfoPointReportTest",
                                     },
                                     HasErrors = false,
                                     ValidationResults = null,
                                 });

            return mapInfoPointQuery;
        }
        #endregion Functions private
    }
}
