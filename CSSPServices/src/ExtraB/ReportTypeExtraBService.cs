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
        #region Functions private Generated FillReportTypeExtraB
        private IQueryable<ReportTypeExtraB> FillReportTypeExtraB()
        {
            Enums enums = new Enums(LanguageRequest);


             IQueryable<ReportTypeExtraB> ReportTypeExtraBQuery = (from c in db.ReportTypes
                let ReportTypeReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ReportTypeExtraB
                    {
                        ReportTypeReportTest = ReportTypeReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        ReportTypeID = c.ReportTypeID,
                        TVType = c.TVType,
                        FileType = c.FileType,
                        UniqueCode = c.UniqueCode,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ReportTypeExtraBQuery;
        }
        #endregion Functions private Generated FillReportTypeExtraB

    }
}
