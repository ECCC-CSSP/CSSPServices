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
    public partial class ContactShortcutService
    {
        #region Functions private Generated ContactShortcutFillReport
        private IQueryable<ContactShortcutReport> FillContactShortcutReport()
        {
             IQueryable<ContactShortcutReport>  ContactShortcutReportQuery = (from c in db.ContactShortcuts
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ContactShortcutReport
                    {
                        ContactShortcutReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ContactShortcutID = c.ContactShortcutID,
                        ContactID = c.ContactID,
                        ShortCutText = c.ShortCutText,
                        ShortCutAddress = c.ShortCutAddress,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return ContactShortcutReportQuery;
        }
        #endregion Functions private Generated ContactShortcutFillReport

    }
}
