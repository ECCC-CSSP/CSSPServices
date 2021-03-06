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
    public partial class EmailDistributionListContactService
    {
        #region Functions private Generated FillEmailDistributionListContactExtraB
        /// <summary>
        /// Fills items [EmailDistributionListContactExtraB](CSSPModels.EmailDistributionListContactExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of EmailDistributionListContactExtraB</returns>
        private IQueryable<EmailDistributionListContactExtraB> FillEmailDistributionListContactExtraB()
        {
             IQueryable<EmailDistributionListContactExtraB> EmailDistributionListContactExtraBQuery = (from c in db.EmailDistributionListContacts
                let EmailDistributionListContactReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new EmailDistributionListContactExtraB
                    {
                        EmailDistributionListContactReportTest = EmailDistributionListContactReportTest,
                        LastUpdateContactText = LastUpdateContactText,
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

            return EmailDistributionListContactExtraBQuery;
        }
        #endregion Functions private Generated FillEmailDistributionListContactExtraB

    }
}
