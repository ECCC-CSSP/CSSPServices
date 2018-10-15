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
    public partial class ContactService
    {
        #region Functions private Generated FillContactExtraB
        private IQueryable<ContactExtraB> FillContactExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ContactTitleEnumList = enums.GetEnumTextOrderedList(typeof(ContactTitleEnum));

             IQueryable<ContactExtraB> ContactExtraBQuery = (from c in db.Contacts
                let ContactReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ParentTVItemID = (from cl in db.TVItems
                    where cl.TVItemID == c.ContactTVItemID
                    select cl.ParentID).FirstOrDefault()
                    select new ContactExtraB
                    {
                        ContactReportTest = ContactReportTest,
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ParentTVItemID = ParentTVItemID,
                        ContactTitleText = (from e in ContactTitleEnumList
                                where e.EnumID == (int?)c.ContactTitle
                                select e.EnumText).FirstOrDefault(),
                        ContactID = c.ContactID,
                        Id = c.Id,
                        ContactTVItemID = c.ContactTVItemID,
                        LoginEmail = c.LoginEmail,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Initial = c.Initial,
                        WebName = c.WebName,
                        ContactTitle = c.ContactTitle,
                        IsAdmin = c.IsAdmin,
                        EmailValidated = c.EmailValidated,
                        Disabled = c.Disabled,
                        IsNew = c.IsNew,
                        SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ContactExtraBQuery;
        }
        #endregion Functions private Generated FillContactExtraB

    }
}
