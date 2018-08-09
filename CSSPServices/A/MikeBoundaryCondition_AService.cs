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
        #region Functions private Generated FillMikeBoundaryCondition_A
        private IQueryable<MikeBoundaryCondition_A> FillMikeBoundaryCondition_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MikeBoundaryConditionLevelOrVelocityEnumList = enums.GetEnumTextOrderedList(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            List<EnumIDAndText> WebTideDataSetEnumList = enums.GetEnumTextOrderedList(typeof(WebTideDataSetEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<MikeBoundaryCondition_A> MikeBoundaryCondition_AQuery = (from c in db.MikeBoundaryConditions
                let MikeBoundaryConditionTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeBoundaryConditionTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MikeBoundaryCondition_A
                    {
                        MikeBoundaryConditionTVItemLanguage = MikeBoundaryConditionTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MikeBoundaryConditionLevelOrVelocityText = (from e in MikeBoundaryConditionLevelOrVelocityEnumList
                                where e.EnumID == (int?)c.MikeBoundaryConditionLevelOrVelocity
                                select e.EnumText).FirstOrDefault(),
                        WebTideDataSetText = (from e in WebTideDataSetEnumList
                                where e.EnumID == (int?)c.WebTideDataSet
                                select e.EnumText).FirstOrDefault(),
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
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

            return MikeBoundaryCondition_AQuery;
        }
        #endregion Functions private Generated FillMikeBoundaryCondition_A

    }
}
