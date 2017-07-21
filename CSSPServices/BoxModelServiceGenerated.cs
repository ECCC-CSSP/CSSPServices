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
    public partial class BoxModelService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            BoxModel boxModel = validationContext.ObjectInstance as BoxModel;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModel.BoxModelID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelBoxModelID), new[] { ModelsRes.BoxModelBoxModelID });
                }
            }

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.InfrastructureTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelInfrastructureTVItemID, "1"), new[] { ModelsRes.BoxModelInfrastructureTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelInfrastructureTVItemID, boxModel.InfrastructureTVItemID.ToString()), new[] { ModelsRes.BoxModelInfrastructureTVItemID });
            }

            //Flow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "10000"), new[] { ModelsRes.BoxModelFlow_m3_day });
            }

            //Depth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000"), new[] { ModelsRes.BoxModelDepth_m });
            }

            //Temperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "-15", "40"), new[] { ModelsRes.BoxModelTemperature_C });
            }

            //Dilution (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000"), new[] { ModelsRes.BoxModelDilution });
            }

            //DecayRate_per_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "100"), new[] { ModelsRes.BoxModelDecayRate_per_day });
            }

            //FCUntreated_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), new[] { ModelsRes.BoxModelFCUntreated_MPN_100ml });
            }

            //FCPreDisinfection_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), new[] { ModelsRes.BoxModelFCPreDisinfection_MPN_100ml });
            }

            //Concentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), new[] { ModelsRes.BoxModelConcentration_MPN_100ml });
            }

            //T90_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.T90_hour < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelT90_hour, "0"), new[] { ModelsRes.BoxModelT90_hour });
            }

            //FlowDuration_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 24)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "24"), new[] { ModelsRes.BoxModelFlowDuration_hour });
            }

            if (boxModel.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLastUpdateDate_UTC), new[] { ModelsRes.BoxModelLastUpdateDate_UTC });
            }

            if (boxModel.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelLastUpdateDate_UTC, "1980"), new[] { ModelsRes.BoxModelLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLastUpdateContactTVItemID, "1"), new[] { ModelsRes.BoxModelLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLastUpdateContactTVItemID, boxModel.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.BoxModelLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(BoxModel boxModel)
        {
            boxModel.ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Create);
            if (boxModel.ValidationResults.Count() > 0) return false;

            db.BoxModels.Add(boxModel);

            if (!TryToSave(boxModel)) return false;

            return true;
        }
        public bool AddRange(List<BoxModel> boxModelList)
        {
            foreach (BoxModel boxModel in boxModelList)
            {
                boxModel.ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Create);
                if (boxModel.ValidationResults.Count() > 0) return false;
            }

            db.BoxModels.AddRange(boxModelList);

            if (!TryToSaveRange(boxModelList)) return false;

            return true;
        }
        public bool Delete(BoxModel boxModel)
        {
            if (!db.BoxModels.Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
            {
                boxModel.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString())) }.AsEnumerable();
                return false;
            }

            db.BoxModels.Remove(boxModel);

            if (!TryToSave(boxModel)) return false;

            return true;
        }
        public bool DeleteRange(List<BoxModel> boxModelList)
        {
            foreach (BoxModel boxModel in boxModelList)
            {
                if (!db.BoxModels.Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                {
                    boxModelList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModel.BoxModelID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.BoxModels.RemoveRange(boxModelList);

            if (!TryToSaveRange(boxModelList)) return false;

            return true;
        }
        public bool Update(BoxModel boxModel)
        {
            boxModel.ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Update);
            if (boxModel.ValidationResults.Count() > 0) return false;

            db.BoxModels.Update(boxModel);

            if (!TryToSave(boxModel)) return false;

            return true;
        }
        public bool UpdateRange(List<BoxModel> boxModelList)
        {
            foreach (BoxModel boxModel in boxModelList)
            {
                boxModel.ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Update);
                if (boxModel.ValidationResults.Count() > 0) return false;
            }
            db.BoxModels.UpdateRange(boxModelList);

            if (!TryToSaveRange(boxModelList)) return false;

            return true;
        }
        public IQueryable<BoxModel> GetRead()
        {
            return db.BoxModels.AsNoTracking();
        }
        public IQueryable<BoxModel> GetEdit()
        {
            return db.BoxModels;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(BoxModel boxModel)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModel.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<BoxModel> boxModelList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
