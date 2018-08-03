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
        public MikeBoundaryConditionService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionID"), new[] { "MikeBoundaryConditionID" });
                }

                if (!GetRead().Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                {
                    mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionMikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), new[] { "MikeBoundaryConditionID" });
                }
            }

            TVItem TVItemMikeBoundaryConditionTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();

            if (TVItemMikeBoundaryConditionTVItemID == null)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionMikeBoundaryConditionTVItemID", mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), new[] { "MikeBoundaryConditionTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeBoundaryConditionMikeBoundaryConditionTVItemID", "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), new[] { "MikeBoundaryConditionTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionCode"), new[] { "MikeBoundaryConditionCode" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionCode", "100"), new[] { "MikeBoundaryConditionCode" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionName"), new[] { "MikeBoundaryConditionName" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionName", "100"), new[] { "MikeBoundaryConditionName" });
            }

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionMikeBoundaryConditionLength_m", "1", "100000"), new[] { "MikeBoundaryConditionLength_m" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionFormat"), new[] { "MikeBoundaryConditionFormat" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionFormat", "100"), new[] { "MikeBoundaryConditionFormat" });
            }

            retStr = enums.EnumTypeOK(typeof(MikeBoundaryConditionLevelOrVelocityEnum), (int?)mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            if (mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity"), new[] { "MikeBoundaryConditionLevelOrVelocity" });
            }

            retStr = enums.EnumTypeOK(typeof(WebTideDataSetEnum), (int?)mikeBoundaryCondition.WebTideDataSet);
            if (mikeBoundaryCondition.WebTideDataSet == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionWebTideDataSet"), new[] { "WebTideDataSet" });
            }

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionNumberOfWebTideNodes", "0", "1000"), new[] { "NumberOfWebTideNodes" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionWebTideDataFromStartToEndDate"), new[] { "WebTideDataFromStartToEndDate" });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mikeBoundaryCondition.TVType);
            if (mikeBoundaryCondition.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionTVType"), new[] { "TVType" });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year == 1)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
                {
                mikeBoundaryCondition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeBoundaryConditionLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeBoundaryCondition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionLastUpdateContactTVItemID", mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeBoundaryConditionLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public MikeBoundaryCondition GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                    select c).FirstOrDefault();

        }
        public IQueryable<MikeBoundaryCondition> GetMikeBoundaryConditionList()
        {
            IQueryable<MikeBoundaryCondition> MikeBoundaryConditionQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MikeBoundaryConditionQuery = EnhanceQueryStatements<MikeBoundaryCondition>(MikeBoundaryConditionQuery) as IQueryable<MikeBoundaryCondition>;

            return MikeBoundaryConditionQuery;
        }
        public MikeBoundaryConditionWeb GetMikeBoundaryConditionWebWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            return FillMikeBoundaryConditionWeb().FirstOrDefault();

        }
        public IQueryable<MikeBoundaryConditionWeb> GetMikeBoundaryConditionWebList()
        {
            IQueryable<MikeBoundaryConditionWeb> MikeBoundaryConditionWebQuery = FillMikeBoundaryConditionWeb();

            MikeBoundaryConditionWebQuery = EnhanceQueryStatements<MikeBoundaryConditionWeb>(MikeBoundaryConditionWebQuery) as IQueryable<MikeBoundaryConditionWeb>;

            return MikeBoundaryConditionWebQuery;
        }
        public MikeBoundaryConditionReport GetMikeBoundaryConditionReportWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            return FillMikeBoundaryConditionReport().FirstOrDefault();

        }
        public IQueryable<MikeBoundaryConditionReport> GetMikeBoundaryConditionReportList()
        {
            IQueryable<MikeBoundaryConditionReport> MikeBoundaryConditionReportQuery = FillMikeBoundaryConditionReport();

            MikeBoundaryConditionReportQuery = EnhanceQueryStatements<MikeBoundaryConditionReport>(MikeBoundaryConditionReportQuery) as IQueryable<MikeBoundaryConditionReport>;

            return MikeBoundaryConditionReportQuery;
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
            IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery = db.MikeBoundaryConditions.AsNoTracking();

            return mikeBoundaryConditionQuery;
        }
        public IQueryable<MikeBoundaryCondition> GetEdit()
        {
            IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery = db.MikeBoundaryConditions;

            return mikeBoundaryConditionQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MikeBoundaryConditionFillWeb
        private IQueryable<MikeBoundaryConditionWeb> FillMikeBoundaryConditionWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MikeBoundaryConditionLevelOrVelocityEnumList = enums.GetEnumTextOrderedList(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            List<EnumIDAndText> WebTideDataSetEnumList = enums.GetEnumTextOrderedList(typeof(WebTideDataSetEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<MikeBoundaryConditionWeb>  MikeBoundaryConditionWebQuery = (from c in db.MikeBoundaryConditions
                let MikeBoundaryConditionTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeBoundaryConditionTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MikeBoundaryConditionWeb
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
                    });

            return MikeBoundaryConditionWebQuery;
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
