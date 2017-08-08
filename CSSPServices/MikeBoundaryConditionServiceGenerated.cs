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
    public partial class MikeBoundaryConditionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeBoundaryCondition mikeBoundaryCondition = validationContext.ObjectInstance as MikeBoundaryCondition;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeBoundaryCondition.MikeBoundaryConditionID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionID), new[] { "MikeBoundaryConditionID" });
                }
            }

            //MikeBoundaryConditionID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeBoundaryConditionTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMikeBoundaryConditionTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).FirstOrDefault();

            if (TVItemMikeBoundaryConditionTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), new[] { "MikeBoundaryConditionTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), new[] { "MikeBoundaryConditionTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode), new[] { "MikeBoundaryConditionCode" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100"), new[] { "MikeBoundaryConditionCode" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName), new[] { "MikeBoundaryConditionName" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100"), new[] { "MikeBoundaryConditionName" });
            }

            //MikeBoundaryConditionLength_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), new[] { "MikeBoundaryConditionLength_m" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat), new[] { "MikeBoundaryConditionFormat" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100"), new[] { "MikeBoundaryConditionFormat" });
            }

            retStr = enums.MikeBoundaryConditionLevelOrVelocityOK(mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            if (mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity == MikeBoundaryConditionLevelOrVelocityEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity), new[] { "MikeBoundaryConditionLevelOrVelocity" });
            }

            retStr = enums.WebTideDataSetOK(mikeBoundaryCondition.WebTideDataSet);
            if (mikeBoundaryCondition.WebTideDataSet == WebTideDataSetEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataSet), new[] { "WebTideDataSet" });
            }

            //NumberOfWebTideNodes (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), new[] { "NumberOfWebTideNodes" });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate), new[] { "WebTideDataFromStartToEndDate" });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.TVTypeOK(mikeBoundaryCondition.TVType);
            if (mikeBoundaryCondition.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionTVType), new[] { "TVType" });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionTVText) && mikeBoundaryCondition.MikeBoundaryConditionTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVText, "200"), new[] { "MikeBoundaryConditionTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.LastUpdateContactTVText) && mikeBoundaryCondition.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocityText) && mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocityText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText, "100"), new[] { "MikeBoundaryConditionLevelOrVelocityText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataSetText) && mikeBoundaryCondition.WebTideDataSetText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionWebTideDataSetText, "100"), new[] { "WebTideDataSetText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.TVTypeText) && mikeBoundaryCondition.TVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionTVTypeText, "100"), new[] { "TVTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeBoundaryCondition GetMikeBoundaryConditionWithMikeBoundaryConditionID(int MikeBoundaryConditionID)
        {
            IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery = (from c in GetRead()
                                                where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                                select c);

            return FillMikeBoundaryCondition(mikeBoundaryConditionQuery).FirstOrDefault();
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
        public bool AddRange(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            foreach (MikeBoundaryCondition mikeBoundaryCondition in mikeBoundaryConditionList)
            {
                mikeBoundaryCondition.ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Create);
                if (mikeBoundaryCondition.ValidationResults.Count() > 0) return false;
            }

            db.MikeBoundaryConditions.AddRange(mikeBoundaryConditionList);

            if (!TryToSaveRange(mikeBoundaryConditionList)) return false;

            return true;
        }
        public bool Delete(MikeBoundaryCondition mikeBoundaryCondition)
        {
            if (!db.MikeBoundaryConditions.Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
            {
                mikeBoundaryCondition.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MikeBoundaryConditions.Remove(mikeBoundaryCondition);

            if (!TryToSave(mikeBoundaryCondition)) return false;

            return true;
        }
        public bool DeleteRange(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            foreach (MikeBoundaryCondition mikeBoundaryCondition in mikeBoundaryConditionList)
            {
                if (!db.MikeBoundaryConditions.Where(c => c.MikeBoundaryConditionID == mikeBoundaryCondition.MikeBoundaryConditionID).Any())
                {
                    mikeBoundaryConditionList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MikeBoundaryConditions.RemoveRange(mikeBoundaryConditionList);

            if (!TryToSaveRange(mikeBoundaryConditionList)) return false;

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
        public bool UpdateRange(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            foreach (MikeBoundaryCondition mikeBoundaryCondition in mikeBoundaryConditionList)
            {
                mikeBoundaryCondition.ValidationResults = Validate(new ValidationContext(mikeBoundaryCondition), ActionDBTypeEnum.Update);
                if (mikeBoundaryCondition.ValidationResults.Count() > 0) return false;
            }
            db.MikeBoundaryConditions.UpdateRange(mikeBoundaryConditionList);

            if (!TryToSaveRange(mikeBoundaryConditionList)) return false;

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

        #region Functions private Generated Fill Class
        private List<MikeBoundaryCondition> FillMikeBoundaryCondition(IQueryable<MikeBoundaryCondition> mikeBoundaryConditionQuery)
        {
            List<MikeBoundaryCondition> MikeBoundaryConditionList = (from c in mikeBoundaryConditionQuery
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
                                             MikeBoundaryConditionTVText = MikeBoundaryConditionTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MikeBoundaryCondition mikeBoundaryCondition in MikeBoundaryConditionList)
            {
                mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocityText = enums.GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum(mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
                mikeBoundaryCondition.WebTideDataSetText = enums.GetEnumText_WebTideDataSetEnum(mikeBoundaryCondition.WebTideDataSet);
                mikeBoundaryCondition.TVTypeText = enums.GetEnumText_TVTypeEnum(mikeBoundaryCondition.TVType);
            }

            return MikeBoundaryConditionList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        private bool TryToSaveRange(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeBoundaryConditionList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
