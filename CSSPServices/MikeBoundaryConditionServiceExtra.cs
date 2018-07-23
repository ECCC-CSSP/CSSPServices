using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class MikeBoundaryConditionService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<MikeBoundaryCondition> FillMikeBoundaryConditionReport(IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MikeBoundaryConditionLevelOrVelocityEnumList = enums.GetEnumTextOrderedList(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            List<EnumIDAndText> WebTideDataSetEnumList = enums.GetEnumTextOrderedList(typeof(WebTideDataSetEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            mikeBoundaryConditionQuery = (from c in mikeBoundaryConditionQuery
                                          let MikeBoundaryConditionTVText = (from cl in db.TVItemLanguages
                                                                             where cl.TVItemID == c.MikeBoundaryConditionTVItemID
                                                                             && cl.Language == LanguageRequest
                                                                             select cl.TVText).FirstOrDefault()
                                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                         && cl.Language == LanguageRequest
                                                                         select cl.TVText).FirstOrDefault()
                                          select new MikeBoundaryCondition
                                          {
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
                                              MikeBoundaryConditionWeb = new MikeBoundaryConditionWeb
                                              {
                                                  MikeBoundaryConditionTVText = MikeBoundaryConditionTVText,
                                                  LastUpdateContactTVText = LastUpdateContactTVText,
                                                  MikeBoundaryConditionLevelOrVelocityText = (from e in MikeBoundaryConditionLevelOrVelocityEnumList
                                                                                              where e.EnumID == (int?)c.MikeBoundaryConditionLevelOrVelocity
                                                                                              select e.EnumText).FirstOrDefault(),
                                                  WebTideDataSetText = (from e in WebTideDataSetEnumList
                                                                        where e.EnumID == (int?)c.WebTideDataSet
                                                                        select e.EnumText).FirstOrDefault(),
                                                  TVTypeText = (from e in TVTypeEnumList
                                                                where e.EnumID == (int?)c.TVType
                                                                select e.EnumText).FirstOrDefault(),
                                              },
                                              MikeBoundaryConditionReport = new MikeBoundaryConditionReport
                                              {
                                                  MikeBoundaryConditionReportTest = "MikeBoundaryConditionReportTest",
                                              },
                                              HasErrors = false,
                                              ValidationResults = null,
                                          });

            return mikeBoundaryConditionQuery;
        }
        #endregion Functions private
    }
}
