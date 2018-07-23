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
    public partial class SpillService
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
        private IQueryable<Spill> FillSpillReport(IQueryable<Spill> spillQuery)
        {
            spillQuery = (from c in spillQuery
                          let MunicipalityTVText = (from cl in db.TVItemLanguages
                                                    where cl.TVItemID == c.MunicipalityTVItemID
                                                    && cl.Language == LanguageRequest
                                                    select cl.TVText).FirstOrDefault()
                          let InfrastructureTVText = (from cl in db.TVItemLanguages
                                                      where cl.TVItemID == c.InfrastructureTVItemID
                                                      && cl.Language == LanguageRequest
                                                      select cl.TVText).FirstOrDefault()
                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl.TVText).FirstOrDefault()
                          select new Spill
                          {
                              SpillID = c.SpillID,
                              MunicipalityTVItemID = c.MunicipalityTVItemID,
                              InfrastructureTVItemID = c.InfrastructureTVItemID,
                              StartDateTime_Local = c.StartDateTime_Local,
                              EndDateTime_Local = c.EndDateTime_Local,
                              AverageFlow_m3_day = c.AverageFlow_m3_day,
                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                              SpillWeb = new SpillWeb
                              {
                                  MunicipalityTVText = MunicipalityTVText,
                                  InfrastructureTVText = InfrastructureTVText,
                                  LastUpdateContactTVText = LastUpdateContactTVText,
                              },
                              SpillReport = new SpillReport
                              {
                                  SpillReportTest = "SpillReportTest",
                              },
                              HasErrors = false,
                              ValidationResults = null,
                          });

            return spillQuery;
        }
        #endregion Functions private
    }
}
