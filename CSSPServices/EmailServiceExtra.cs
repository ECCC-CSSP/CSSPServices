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
    public partial class EmailService
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
        private IQueryable<Email> FillEmailReport(IQueryable<Email> emailQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> EmailTypeEnumList = enums.GetEnumTextOrderedList(typeof(EmailTypeEnum));

            emailQuery = (from c in emailQuery
                          let EmailTVText = (from cl in db.TVItemLanguages
                                             where cl.TVItemID == c.EmailTVItemID
                                             && cl.Language == LanguageRequest
                                             select cl.TVText).FirstOrDefault()
                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl.TVText).FirstOrDefault()
                          select new Email
                          {
                              EmailID = c.EmailID,
                              EmailTVItemID = c.EmailTVItemID,
                              EmailAddress = c.EmailAddress,
                              EmailType = c.EmailType,
                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                              EmailWeb = new EmailWeb
                              {
                                  EmailTVText = EmailTVText,
                                  LastUpdateContactTVText = LastUpdateContactTVText,
                                  EmailTypeText = (from e in EmailTypeEnumList
                                                   where e.EnumID == (int?)c.EmailType
                                                   select e.EnumText).FirstOrDefault(),
                              },
                              EmailReport = new EmailReport
                              {
                                  EmailReportTest = "EmailReportTest",
                              },
                              HasErrors = false,
                              ValidationResults = null,
                          });

            return emailQuery;
        }
        #endregion Functions private
    }
}
