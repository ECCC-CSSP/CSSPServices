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
    public partial class EmailDistributionListContactService
    {
        #region Functions private Generated EmailDistributionListContactFillReport
        private IQueryable<EmailDistributionListContactReport> FillEmailDistributionListContactReport()
        {
             IQueryable<EmailDistributionListContactReport>  EmailDistributionListContactReportQuery = (from c in db.EmailDistributionListContacts
                let EmailDistributionListContactReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailDistributionListContactReport
                    {
                        EmailDistributionListContactReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        EmailDistributionListContactID = c.EmailDistributionListContactID,
                        EmailDistributionListID = c.EmailDistributionListID,
                        IsCC = c.IsCC,
                        Name = c.Name,
                        Email = c.Email,
                        CMPRainfallSeasonal = c.CMPRainfallSeasonal,
                        CMPWastewater = c.CMPWastewater,
                        EmergencyWeather = c.EmergencyWeather,
                        EmergencyWastewater = c.EmergencyWastewater,
                        ReopeningAllTypes = c.ReopeningAllTypes,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return EmailDistributionListContactReportQuery;
        }
        #endregion Functions private Generated EmailDistributionListContactFillReport

    }
}