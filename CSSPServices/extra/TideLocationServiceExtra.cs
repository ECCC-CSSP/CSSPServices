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
    public partial class TideLocationService
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
        private IQueryable<TideLocation> FillTideLocationReport(IQueryable<TideLocation> tideLocationQuery)
        {
            tideLocationQuery = (from c in tideLocationQuery
                                 let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                && cl.Language == LanguageRequest
                                                                select cl).FirstOrDefault()
                                 select new TideLocation
                                 {
                                     TideLocationID = c.TideLocationID,
                                     Zone = c.Zone,
                                     Name = c.Name,
                                     Prov = c.Prov,
                                     sid = c.sid,
                                     Lat = c.Lat,
                                     Lng = c.Lng,
                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     TideLocationWeb = new TideLocationWeb
                                     {
                                         LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                     },
                                     TideLocationReport = new TideLocationReport
                                     {
                                         TideLocationReportTest = "TideLocationReportTest",
                                     },
                                     HasErrors = false,
                                     ValidationResults = null,
                                 });

            return tideLocationQuery;
        }
        #endregion Functions private
    }
}
