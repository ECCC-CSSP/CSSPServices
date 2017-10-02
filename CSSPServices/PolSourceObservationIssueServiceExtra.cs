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
    public partial class PolSourceObservationIssueService
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
        private IQueryable<PolSourceObservationIssue> FillPolSourceObservationIssueReport(IQueryable<PolSourceObservationIssue> polSourceObservationIssueQuery, string FilterAndOrderText)
        {
            polSourceObservationIssueQuery = (from c in polSourceObservationIssueQuery
                                              let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                             where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                             && cl.Language == LanguageRequest
                                                                             select cl.TVText).FirstOrDefault()
                                              select new PolSourceObservationIssue
                                              {
                                                  PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                                                  PolSourceObservationID = c.PolSourceObservationID,
                                                  ObservationInfo = c.ObservationInfo,
                                                  Ordinal = c.Ordinal,
                                                  LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                  LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                  PolSourceObservationIssueWeb = new PolSourceObservationIssueWeb
                                                  {
                                                      LastUpdateContactTVText = LastUpdateContactTVText,
                                                  },
                                                  PolSourceObservationIssueReport = new PolSourceObservationIssueReport
                                                  {
                                                      PolSourceObservationIssueReportTest = "PolSourceObservationIssueReportTest",
                                                  },
                                                  HasErrors = false,
                                                  ValidationResults = null,
                                              });

            return polSourceObservationIssueQuery;
        }
        #endregion Functions private
    }
}
