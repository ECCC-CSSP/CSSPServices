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
    public partial class MWQMSubsectorService
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
        private IQueryable<MWQMSubsector> FillMWQMSubsectorReport(IQueryable<MWQMSubsector> mwqmSubsectorQuery, string FilterAndOrderText)
        {
            mwqmSubsectorQuery = (from c in mwqmSubsectorQuery
                                  let SubsectorTVText = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.MWQMSubsectorTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl.TVText).FirstOrDefault()
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  select new MWQMSubsector
                                  {
                                      MWQMSubsectorID = c.MWQMSubsectorID,
                                      MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                      SubsectorHistoricKey = c.SubsectorHistoricKey,
                                      TideLocationSIDText = c.TideLocationSIDText,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      MWQMSubsectorWeb = new MWQMSubsectorWeb
                                      {
                                          SubsectorTVText = SubsectorTVText,
                                          LastUpdateContactTVText = LastUpdateContactTVText,
                                      },
                                      MWQMSubsectorReport = new MWQMSubsectorReport
                                      {
                                          MWQMSubsectorReportTest = "MWQMSubsectorReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return mwqmSubsectorQuery;
        }
        #endregion Functions private
    }
}
