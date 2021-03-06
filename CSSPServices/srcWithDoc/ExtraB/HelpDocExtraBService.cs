/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class HelpDocService
    {
        #region Functions private Generated FillHelpDocExtraB
        /// <summary>
        /// Fills items [HelpDocExtraB](CSSPModels.HelpDocExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of HelpDocExtraB</returns>
        private IQueryable<HelpDocExtraB> FillHelpDocExtraB()
        {
            Enums enums = new Enums(LanguageRequest);


             IQueryable<HelpDocExtraB> HelpDocExtraBQuery = (from c in db.HelpDocs
                let EmailReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new HelpDocExtraB
                    {
                        EmailReportTest = EmailReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        HelpDocID = c.HelpDocID,
                        DocKey = c.DocKey,
                        Language = c.Language,
                        DocHTMLText = c.DocHTMLText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HelpDocExtraBQuery;
        }
        #endregion Functions private Generated FillHelpDocExtraB

    }
}
