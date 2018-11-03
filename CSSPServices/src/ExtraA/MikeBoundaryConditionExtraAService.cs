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
    public partial class MikeBoundaryConditionService
    {
        #region Functions private Generated FillMikeBoundaryConditionExtraA
        private IQueryable<MikeBoundaryConditionExtraA> FillMikeBoundaryConditionExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MikeBoundaryConditionLevelOrVelocityEnumList = enums.GetEnumTextOrderedList(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            List<EnumIDAndText> WebTideDataSetEnumList = enums.GetEnumTextOrderedList(typeof(WebTideDataSetEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<MikeBoundaryConditionExtraA> MikeBoundaryConditionExtraAQuery = (from c in db.MikeBoundaryConditions
                let MikeBoundaryConditionText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeBoundaryConditionTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MikeBoundaryConditionLevelOrVelocityText = (from e in MikeBoundaryConditionLevelOrVelocityEnumList
                    where e.EnumID == (int?)c.MikeBoundaryConditionLevelOrVelocity
                    select e.EnumText).FirstOrDefault()
                let WebTideDataSetText = (from e in WebTideDataSetEnumList
                    where e.EnumID == (int?)c.WebTideDataSet
                    select e.EnumText).FirstOrDefault()
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                    select new MikeBoundaryConditionExtraA
                    {
                        MikeBoundaryConditionText = MikeBoundaryConditionText,
                        LastUpdateContactText = LastUpdateContactText,
                        MikeBoundaryConditionLevelOrVelocityText = MikeBoundaryConditionLevelOrVelocityText,
                        WebTideDataSetText = WebTideDataSetText,
                        TVTypeText = TVTypeText,
                        MikeBoundaryConditionID = c.MikeBoundaryConditionID,
                        MikeBoundaryConditionTVItemID = c.MikeBoundaryConditionTVItemID,
                        MikeBoundaryConditionCode = c.MikeBoundaryConditionCode,
                        MikeBoundaryConditionName = c.MikeBoundaryConditionName,
                        MikeBoundaryConditionLength_m = c.MikeBoundaryConditionLength_m,
                        MikeBoundaryConditionFormat = c.MikeBoundaryConditionFormat,
                        MikeBoundaryConditionLevelOrVelocity = c.MikeBoundaryConditionLevelOrVelocity,
                        WebTideDataSet = c.WebTideDataSet,
                        NumberOfWebTideNodes = c.NumberOfWebTideNodes,
                        WebTideDataFromStartToEndDate = c.WebTideDataFromStartToEndDate,
                        TVType = c.TVType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MikeBoundaryConditionExtraAQuery;
        }
        #endregion Functions private Generated FillMikeBoundaryConditionExtraA

    }
}