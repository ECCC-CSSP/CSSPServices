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
    public partial class ResetPasswordService
    {
        #region Functions private Generated FillResetPasswordExtraA
        private IQueryable<ResetPasswordExtraA> FillResetPasswordExtraA()
        {
             IQueryable<ResetPasswordExtraA> ResetPasswordExtraAQuery = (from c in db.ResetPasswords
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ResetPasswordExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        ResetPasswordID = c.ResetPasswordID,
                        Email = c.Email,
                        ExpireDate_Local = c.ExpireDate_Local,
                        Code = c.Code,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ResetPasswordExtraAQuery;
        }
        #endregion Functions private Generated FillResetPasswordExtraA

    }
}
