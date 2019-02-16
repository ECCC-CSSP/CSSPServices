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
    public partial class DrogueRunPositionService
    {
        #region Functions private Generated FillDrogueRunPositionExtraA
        private IQueryable<DrogueRunPositionExtraA> FillDrogueRunPositionExtraA()
        {
             IQueryable<DrogueRunPositionExtraA> DrogueRunPositionExtraAQuery = (from c in db.DrogueRunPositions
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new DrogueRunPositionExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        DrogueRunPositionID = c.DrogueRunPositionID,
                        DrogueRunID = c.DrogueRunID,
                        Ordinal = c.Ordinal,
                        StepLat = c.StepLat,
                        StepLng = c.StepLng,
                        StepDateTime_Local = c.StepDateTime_Local,
                        CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                        CalculatedDirection_deg = c.CalculatedDirection_deg,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return DrogueRunPositionExtraAQuery;
        }
        #endregion Functions private Generated FillDrogueRunPositionExtraA

    }
}