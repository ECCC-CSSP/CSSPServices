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
    public partial class TideSiteService
    {
        #region Functions private Generated FillTideSiteExtraB
        /// <summary>
        /// Fills items [TideSiteExtraB](CSSPModels.TideSiteExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of TideSiteExtraB</returns>
        private IQueryable<TideSiteExtraB> FillTideSiteExtraB()
        {
             IQueryable<TideSiteExtraB> TideSiteExtraBQuery = (from c in db.TideSites
                let TideSiteReportTest = (from cl in db.TVItemLanguages
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
                    select new TideSiteExtraB
                    {
                        TideSiteReportTest = TideSiteReportTest,
                        TideSiteText = TideSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        TideSiteID = c.TideSiteID,
                        TideSiteTVItemID = c.TideSiteTVItemID,
                        TideSiteName = c.TideSiteName,
                        Province = c.Province,
                        sid = c.sid,
                        Zone = c.Zone,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TideSiteExtraBQuery;
        }
        #endregion Functions private Generated FillTideSiteExtraB

    }
}
