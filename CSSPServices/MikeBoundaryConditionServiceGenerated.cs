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
    /// <summary>
    ///     <para>bonjour MikeBoundaryCondition</para>
    /// </summary>
    public partial class MikeBoundaryConditionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeBoundaryCondition mikeBoundaryCondition = validationContext.ObjectInstance as MikeBoundaryCondition;
            mikeBoundaryCondition.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeBoundaryCondition.MikeBoundaryConditionID == 0)
                {
                    mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionID), new[] { "MikeBoundaryConditionID" });
                }

                if (!GetRead().Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                {
                    mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeBoundaryCondition, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionID, mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), new[] { "MikeBoundaryConditionID" });
                }
            }

            TVItem TVItemMikeBoundaryConditionTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();

            if (TVItemMikeBoundaryConditionTVItemID == null)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, (mikeBoundaryCondition.MikeBoundaryConditionTVItemID == null ? "" : mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString())), new[] { "MikeBoundaryConditionTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeBoundaryConditionTVItemID.TVType))
                {
                    mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), new[] { "MikeBoundaryConditionTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode), new[] { "MikeBoundaryConditionCode" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100"), new[] { "MikeBoundaryConditionCode" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionName), new[] { "MikeBoundaryConditionName" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100"), new[] { "MikeBoundaryConditionName" });
            }

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), new[] { "MikeBoundaryConditionLength_m" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat), new[] { "MikeBoundaryConditionFormat" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100"), new[] { "MikeBoundaryConditionFormat" });
            }

            retStr = enums.EnumTypeOK(typeof(MikeBoundaryConditionLevelOrVelocityEnum), (int?)mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            if (mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity == MikeBoundaryConditionLevelOrVelocityEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity), new[] { "MikeBoundaryConditionLevelOrVelocity" });
            }

            retStr = enums.EnumTypeOK(typeof(WebTideDataSetEnum), (int?)mikeBoundaryCondition.WebTideDataSet);
            if (mikeBoundaryCondition.WebTideDataSet == WebTideDataSetEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionWebTideDataSet), new[] { "WebTideDataSet" });
            }

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), new[] { "NumberOfWebTideNodes" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate), new[] { "WebTideDataFromStartToEndDate" });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mikeBoundaryCondition.TVType);
            if (mikeBoundaryCondition.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionTVType), new[] { "TVType" });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year == 1)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeBoundaryConditionLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
                {
                mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeBoundaryConditionLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, (mikeBoundaryCondition.LastUpdateContactTVItemID == null ? "" : mikeBoundaryCondition.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeBoundaryCondition GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID, GetParam getParam)
        {
            IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mikeBoundaryConditionQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMikeBoundaryConditionWeb(mikeBoundaryConditionQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMikeBoundaryConditionReport(mikeBoundaryConditionQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MikeBoundaryCondition> GetMikeBoundaryConditionList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mikeBoundaryConditionQuery  = mikeBoundaryConditionQuery.OrderByDescending(c => c.MikeBoundaryConditionID);
                        }
                        mikeBoundaryConditionQuery = mikeBoundaryConditionQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return mikeBoundaryConditionQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mikeBoundaryConditionQuery = FillMikeBoundaryConditionWeb(mikeBoundaryConditionQuery, FilterAndOrderText).OrderByDescending(c => c.MikeBoundaryConditionID);
                        }
                        mikeBoundaryConditionQuery = FillMikeBoundaryConditionWeb(mikeBoundaryConditionQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mikeBoundaryConditionQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mikeBoundaryConditionQuery = FillMikeBoundaryConditionReport(mikeBoundaryConditionQuery, FilterAndOrderText).OrderByDescending(c => c.MikeBoundaryConditionID);
                        }
                        mikeBoundaryConditionQuery = FillMikeBoundaryConditionReport(mikeBoundaryConditionQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mikeBoundaryConditionQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeBoundaryCondition mikeBoundaryCondition)
        {
            mikeBoundaryCondition.ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Create);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0) return false;

            db.MikeBoundaryConditions.Add(mikeBoundaryCondition);

            if (!TryToSave(mikeBoundaryCondition)) return false;

            return true;
        }
        public bool Delete(MikeBoundaryCondition mikeBoundaryCondition)
        {
            mikeBoundaryCondition.ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Delete);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0) return false;

            db.MikeBoundaryConditions.Remove(mikeBoundaryCondition);

            if (!TryToSave(mikeBoundaryCondition)) return false;

            return true;
        }
        public bool Update(MikeBoundaryCondition mikeBoundaryCondition)
        {
            mikeBoundaryCondition.ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Update);
            if (mikeBoundaryCondition.ValidationResults.Count() > 0) return false;

            db.MikeBoundaryConditions.Update(mikeBoundaryCondition);

            if (!TryToSave(mikeBoundaryCondition)) return false;

            return true;
        }
        public IQueryable<MikeBoundaryCondition> GetRead()
        {
            return db.MikeBoundaryConditions.AsNoTracking();
        }
        public IQueryable<MikeBoundaryCondition> GetEdit()
        {
            return db.MikeBoundaryConditions;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MikeBoundaryConditionFillWeb
        private IQueryable<MikeBoundaryCondition> FillMikeBoundaryConditionWeb(IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery, string FilterAndOrderText)
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
                        MikeBoundaryConditionReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mikeBoundaryConditionQuery;
        }
        #endregion Functions private Generated MikeBoundaryConditionFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MikeBoundaryCondition mikeBoundaryCondition)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeBoundaryCondition.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
