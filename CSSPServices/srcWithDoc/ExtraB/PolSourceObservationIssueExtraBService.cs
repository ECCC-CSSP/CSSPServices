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
    public partial class PolSourceObservationIssueService
    {
        #region Functions private Generated FillPolSourceObservationIssueExtraB
        private IQueryable<PolSourceObservationIssueExtraB> FillPolSourceObservationIssueExtraB()
        {
             IQueryable<PolSourceObservationIssueExtraB> PolSourceObservationIssueExtraBQuery = (from c in db.PolSourceObservationIssues
                let PolSourceObservationIssueReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new PolSourceObservationIssueExtraB
                    {
                        PolSourceObservationIssueReportTest = PolSourceObservationIssueReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                        PolSourceObservationID = c.PolSourceObservationID,
                        ObservationInfo = c.ObservationInfo,
                        Ordinal = c.Ordinal,
                        ExtraComment = c.ExtraComment,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return PolSourceObservationIssueExtraBQuery;
        }
        #endregion Functions private Generated FillPolSourceObservationIssueExtraB

    }
}
