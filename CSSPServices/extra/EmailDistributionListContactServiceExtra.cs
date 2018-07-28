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
    public partial class EmailDistributionListContactService
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
        private IQueryable<EmailDistributionListContact> FillEmailDistributionListContactReport(IQueryable<EmailDistributionListContact> emailDistributionListContactQuery)
        {
            emailDistributionListContactQuery = (from c in emailDistributionListContactQuery
                                                 let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                                where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                                && cl.Language == LanguageRequest
                                                                                select cl.TVText).FirstOrDefault()
                                                 let EmailDistributionListContactReportTest = (from cl in db.TVItemLanguages
                                                                                               where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                                               && cl.Language == LanguageRequest
                                                                                               select cl.TVText).FirstOrDefault()
                                                 select new EmailDistributionListContact
                                                 {
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
                                                     EmailDistributionListContactWeb = new EmailDistributionListContactWeb
                                                     {
                                                         LastUpdateContactTVText = LastUpdateContactTVText,
                                                     },
                                                     EmailDistributionListContactReport = new EmailDistributionListContactReport
                                                     {
                                                         EmailDistributionListContactReportTest = EmailDistributionListContactReportTest,
                                                     },
                                                     HasErrors = false,
                                                     ValidationResults = null,
                                                 });

            return emailDistributionListContactQuery;
        }
        #endregion Functions private
    }
}
