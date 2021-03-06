/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
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
    public partial class MikeScenarioResultService
    {
        #region Functions private Generated FillMikeScenarioResultExtraA
        private IQueryable<MikeScenarioResultExtraA> FillMikeScenarioResultExtraA()
        {
             IQueryable<MikeScenarioResultExtraA> MikeScenarioResultExtraAQuery = (from c in db.MikeScenarioResults
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MikeScenarioResultExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        MikeScenarioResultID = c.MikeScenarioResultID,
                        MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                        MikeResultsJSON = c.MikeResultsJSON,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MikeScenarioResultExtraAQuery;
        }
        #endregion Functions private Generated FillMikeScenarioResultExtraA

    }
}
