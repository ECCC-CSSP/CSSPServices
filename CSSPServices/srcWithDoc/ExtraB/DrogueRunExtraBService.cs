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
    public partial class DrogueRunService
    {
        #region Functions private Generated FillDrogueRunExtraB
        /// <summary>
        /// Fills items [DrogueRunExtraB](CSSPModels.DrogueRunExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of DrogueRunExtraB</returns>
        private IQueryable<DrogueRunExtraB> FillDrogueRunExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> DrogueTypeEnumList = enums.GetEnumTextOrderedList(typeof(DrogueTypeEnum));

             IQueryable<DrogueRunExtraB> DrogueRunExtraBQuery = (from c in db.DrogueRuns
                let DrogueRunReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let DrogueTypeText = (from e in DrogueTypeEnumList
                    where e.EnumID == (int?)c.DrogueType
                    select e.EnumText).FirstOrDefault()
                    select new DrogueRunExtraB
                    {
                        DrogueRunReportTest = DrogueRunReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        DrogueTypeText = DrogueTypeText,
                        DrogueRunID = c.DrogueRunID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        DrogueNumber = c.DrogueNumber,
                        DrogueType = c.DrogueType,
                        RunStartDateTime = c.RunStartDateTime,
                        IsRisingTide = c.IsRisingTide,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return DrogueRunExtraBQuery;
        }
        #endregion Functions private Generated FillDrogueRunExtraB

    }
}
