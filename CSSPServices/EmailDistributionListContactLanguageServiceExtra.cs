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
    public partial class EmailDistributionListContactLanguageService
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
        private IQueryable<EmailDistributionListContactLanguage> FillEmailDistributionListContactLanguageReport(IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            emailDistributionListContactLanguageQuery = (from c in emailDistributionListContactLanguageQuery
                                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                                        where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                                        && cl.Language == LanguageRequest
                                                                                        select cl.TVText).FirstOrDefault()
                                                         select new EmailDistributionListContactLanguage
                                                         {
                                                             EmailDistributionListContactLanguageID = c.EmailDistributionListContactLanguageID,
                                                             EmailDistributionListContactID = c.EmailDistributionListContactID,
                                                             Language = c.Language,
                                                             Agency = c.Agency,
                                                             TranslationStatus = c.TranslationStatus,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             EmailDistributionListContactLanguageWeb = new EmailDistributionListContactLanguageWeb
                                                             {
                                                                 LastUpdateContactTVText = LastUpdateContactTVText,
                                                                 LanguageText = (from e in LanguageEnumList
                                                                                 where e.EnumID == (int?)c.Language
                                                                                 select e.EnumText).FirstOrDefault(),
                                                                 TranslationStatusText = (from e in TranslationStatusEnumList
                                                                                          where e.EnumID == (int?)c.TranslationStatus
                                                                                          select e.EnumText).FirstOrDefault(),
                                                             },
                                                             EmailDistributionListContactLanguageReport = new EmailDistributionListContactLanguageReport
                                                             {
                                                                 EmailDistributionListContactLanguageReportTest = "EmailDistributionListContactLanguageReportTest",
                                                             },
                                                             HasErrors = false,
                                                             ValidationResults = null,
                                                         });

            return emailDistributionListContactLanguageQuery;
        }
        #endregion Functions private
    }
}
