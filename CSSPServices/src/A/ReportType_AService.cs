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
    public partial class ReportTypeService
    {
        #region Functions private Generated FillReportType_A
        private IQueryable<ReportType_A> FillReportType_A()
        {
            Enums enums = new Enums(LanguageRequest);


             IQueryable<ReportType_A> ReportType_AQuery = (from c in db.ReportTypes
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportType_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ReportTypeID = c.ReportTypeID,
                        TVType = c.TVType,
                        FileType = c.FileType,
                        UniqueCode = c.UniqueCode,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ReportType_AQuery;
        }
        #endregion Functions private Generated FillReportType_A

    }
}