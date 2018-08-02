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
    public partial class EmailDistributionListService
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
        private IQueryable<EmailDistributionList> FillEmailDistributionListReport(IQueryable<EmailDistributionList> emailDistributionListQuery)
        {
            emailDistributionListQuery = (from c in emailDistributionListQuery
                                          let CountryTVItemLanguage = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.CountryTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl).FirstOrDefault()
                                          let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                         && cl.Language == LanguageRequest
                                                                         select cl).FirstOrDefault()
                                          select new EmailDistributionList
                                          {
                                              EmailDistributionListID = c.EmailDistributionListID,
                                              CountryTVItemID = c.CountryTVItemID,
                                              Ordinal = c.Ordinal,
                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                              EmailDistributionListWeb = new EmailDistributionListWeb
                                              {
                                                  CountryTVItemLanguage = CountryTVItemLanguage,
                                                  LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                              },
                                              EmailDistributionListReport = new EmailDistributionListReport
                                              {
                                                  EmailDistributionReportTest = "EmailDistributionReportTest",
                                              },
                                              HasErrors = false,
                                              ValidationResults = null,
                                          });

            return emailDistributionListQuery;
        }
        #endregion Functions private
    }
}
