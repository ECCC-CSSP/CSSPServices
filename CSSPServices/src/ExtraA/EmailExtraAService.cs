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
        #region Functions private Generated FillEmailExtraA
        private IQueryable<EmailExtraA> FillEmailExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> EmailTypeEnumList = enums.GetEnumTextOrderedList(typeof(EmailTypeEnum));

             IQueryable<EmailExtraA> EmailExtraAQuery = (from c in db.Emails
                let EmailText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.EmailTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let EmailTypeText = (from e in EmailTypeEnumList
                    where e.EnumID == (int?)c.EmailType
                    select e.EnumText).FirstOrDefault()
                    select new EmailExtraA
                    {
                        EmailText = EmailText,
                        LastUpdateContactText = LastUpdateContactText,
                        EmailTypeText = EmailTypeText,
                        EmailID = c.EmailID,
                        EmailTVItemID = c.EmailTVItemID,
                        EmailAddress = c.EmailAddress,
                        EmailType = c.EmailType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return EmailExtraAQuery;
        }
        #endregion Functions private Generated FillEmailExtraA

    }
}
