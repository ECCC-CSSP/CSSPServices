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
    public partial class EmailService
    {
        #region Functions private Generated EmailFillReport
        private IQueryable<EmailReport> FillEmailReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> EmailTypeEnumList = enums.GetEnumTextOrderedList(typeof(EmailTypeEnum));

             IQueryable<EmailReport>  EmailReportQuery = (from c in db.Emails
                let EmailTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.EmailTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailReport
                    {
                        EmailReportTest = "Testing Report",
                        EmailTVItemLanguage = EmailTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        EmailTypeText = (from e in EmailTypeEnumList
                                where e.EnumID == (int?)c.EmailType
                                select e.EnumText).FirstOrDefault(),
                        EmailID = c.EmailID,
                        EmailTVItemID = c.EmailTVItemID,
                        EmailAddress = c.EmailAddress,
                        EmailType = c.EmailType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return EmailReportQuery;
        }
        #endregion Functions private Generated EmailFillReport

    }
}
