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
        #region Functions private Generated FillPolSourceObservationIssue_A
        private IQueryable<PolSourceObservationIssue_A> FillPolSourceObservationIssue_A()
        {
             IQueryable<PolSourceObservationIssue_A> PolSourceObservationIssue_AQuery = (from c in db.PolSourceObservationIssues
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new PolSourceObservationIssue_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
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

            return PolSourceObservationIssue_AQuery;
        }
        #endregion Functions private Generated FillPolSourceObservationIssue_A

    }
}
