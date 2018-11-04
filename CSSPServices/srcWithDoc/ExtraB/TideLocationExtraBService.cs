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
    public partial class TideLocationService
    {
        #region Functions private Generated FillTideLocationExtraB
        /// <summary>
        /// Fills items [TideLocationExtraB](CSSPModels.TideLocationExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of TideLocationExtraB</returns>
        private IQueryable<TideLocationExtraB> FillTideLocationExtraB()
        {
             IQueryable<TideLocationExtraB> TideLocationExtraBQuery = (from c in db.TideLocations
                let TideLocationReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TideLocationExtraB
                    {
                        TideLocationReportTest = TideLocationReportTest,
                        LastUpdateContactText = LastUpdateContactText,
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

            return TideLocationExtraBQuery;
        }
        #endregion Functions private Generated FillTideLocationExtraB

    }
}
