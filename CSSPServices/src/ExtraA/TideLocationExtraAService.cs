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
    public partial class TideLocationService
    {
        #region Functions private Generated FillTideLocationExtraA
        private IQueryable<TideLocationExtraA> FillTideLocationExtraA()
        {
             IQueryable<TideLocationExtraA> TideLocationExtraAQuery = (from c in db.TideLocations
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TideLocationExtraA
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TideLocationID = c.TideLocationID,
                        Zone = c.Zone,
                        Name = c.Name,
                        Prov = c.Prov,
                        sid = c.sid,
                        Lat = c.Lat,
                        Lng = c.Lng,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TideLocationExtraAQuery;
        }
        #endregion Functions private Generated FillTideLocationExtraA

    }
}
