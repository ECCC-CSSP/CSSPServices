/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class MapInfoPointService
    {
        #region Functions private Generated FillMapInfoPointExtraB
        /// <summary>
        /// Fills items [MapInfoPointExtraB](CSSPModels.MapInfoPointExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of MapInfoPointExtraB</returns>
        private IQueryable<MapInfoPointExtraB> FillMapInfoPointExtraB()
        {
             IQueryable<MapInfoPointExtraB> MapInfoPointExtraBQuery = (from c in db.MapInfoPoints
                let MapInfoPointReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MapInfoPointExtraB
                    {
                        MapInfoPointReportTest = MapInfoPointReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        MapInfoPointID = c.MapInfoPointID,
                        MapInfoID = c.MapInfoID,
                        Ordinal = c.Ordinal,
                        Lat = c.Lat,
                        Lng = c.Lng,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MapInfoPointExtraBQuery;
        }
        #endregion Functions private Generated FillMapInfoPointExtraB

    }
}
