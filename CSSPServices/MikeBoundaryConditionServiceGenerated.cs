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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionID), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionID });
                }
            }

            //MikeBoundaryConditionID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeBoundaryConditionTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.MikeBoundaryConditionTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "1"), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.MikeBoundaryConditionTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionCode) && mikeBoundaryCondition.MikeBoundaryConditionCode.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100"), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionName) && mikeBoundaryCondition.MikeBoundaryConditionName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100"), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName });
            }

            //MikeBoundaryConditionLength_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.MikeBoundaryConditionLength_m < 1 || mikeBoundaryCondition.MikeBoundaryConditionLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "1", "100000"), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat });
            }

            if (!string.IsNullOrWhiteSpace(mikeBoundaryCondition.MikeBoundaryConditionFormat) && mikeBoundaryCondition.MikeBoundaryConditionFormat.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100"), new[] { ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat });
            }

                //Error: Type not implemented [MikeBoundaryConditionLevelOrVelocity] of type [MikeBoundaryConditionLevelOrVelocityEnum]

                //Error: Type not implemented [MikeBoundaryConditionLevelOrVelocity] of type [MikeBoundaryConditionLevelOrVelocityEnum]
            retStr = enums.WebTideDataSetOK(mikeBoundaryCondition.WebTideDataSet);
            if (mikeBoundaryCondition.WebTideDataSet == WebTideDataSetEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataSet), new[] { ModelsRes.MikeBoundaryConditionWebTideDataSet });
            }

            //NumberOfWebTideNodes (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.NumberOfWebTideNodes < 0 || mikeBoundaryCondition.NumberOfWebTideNodes > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "0", "1000"), new[] { ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes });
            }

            if (string.IsNullOrWhiteSpace(mikeBoundaryCondition.WebTideDataFromStartToEndDate))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate), new[] { ModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate });
            }

            //WebTideDataFromStartToEndDate has no StringLength Attribute

            retStr = enums.TVTypeOK(mikeBoundaryCondition.TVType);
            if (mikeBoundaryCondition.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionTVType), new[] { ModelsRes.MikeBoundaryConditionTVType });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC), new[] { ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC });
            }

            if (mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeBoundaryCondition.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeBoundaryCondition.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
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
        #endregion Functions public

        #region Functions private
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
        #endregion Functions private
    }
}
