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
        #region Functions private Generated FillMapInfoPoint_A
        private IQueryable<MapInfoPoint_A> FillMapInfoPoint_A()
        {
             IQueryable<MapInfoPoint_A> MapInfoPoint_AQuery = (from c in db.MapInfoPoints
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MapInfoPoint_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
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

            return MapInfoPoint_AQuery;
        }
        #endregion Functions private Generated FillMapInfoPoint_A

    }
}
