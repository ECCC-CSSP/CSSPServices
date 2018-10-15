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
        #region Functions private Generated FillEmailDistributionListContactExtraA
        private IQueryable<EmailDistributionListContactExtraA> FillEmailDistributionListContactExtraA()
        {
             IQueryable<EmailDistributionListContactExtraA> EmailDistributionListContactExtraAQuery = (from c in db.EmailDistributionListContacts
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailDistributionListContactExtraA
                    {
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
                    }).AsNoTracking();

            return EmailDistributionListContactExtraAQuery;
        }
        #endregion Functions private Generated FillEmailDistributionListContactExtraA

    }
}
