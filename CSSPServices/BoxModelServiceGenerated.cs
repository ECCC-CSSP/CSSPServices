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
            BoxModel boxModel = validationContext.ObjectInstance as BoxModel;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModel.BoxModelID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelBoxModelID), new[] { ModelsRes.BoxModelBoxModelID });
                }
            }

            //InfrastructureTVItemID (int) is required but no testing needed as it is automatically set to 0

            //Flow_m3_day (float) is required but no testing needed as it is automatically set to 0.0f

            //Depth_m (float) is required but no testing needed as it is automatically set to 0.0f

            //Temperature_C (float) is required but no testing needed as it is automatically set to 0.0f

            //Dilution (float) is required but no testing needed as it is automatically set to 0.0f

            //DecayRate_per_day (float) is required but no testing needed as it is automatically set to 0.0f

            //FCUntreated_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //FCPreDisinfection_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //Concentration_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //T90_hour (float) is required but no testing needed as it is automatically set to 0.0f

            //FlowDuration_hour (float) is required but no testing needed as it is automatically set to 0.0f

            if (boxModel.LastUpdateDate_UTC == null || boxModel.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLastUpdateDate_UTC), new[] { ModelsRes.BoxModelLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (boxModel.InfrastructureTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelInfrastructureTVItemID, "1"), new[] { ModelsRes.BoxModelInfrastructureTVItemID });
            }

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "1000000"), new[] { ModelsRes.BoxModelFlow_m3_day });
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000"), new[] { ModelsRes.BoxModelDepth_m });
            }

            if (boxModel.Temperature_C < 0 || boxModel.Temperature_C > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "0", "50"), new[] { ModelsRes.BoxModelTemperature_C });
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "1000000"), new[] { ModelsRes.BoxModelDilution });
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "1000"), new[] { ModelsRes.BoxModelDecayRate_per_day });
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 20000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "20000000"), new[] { ModelsRes.BoxModelFCUntreated_MPN_100ml });
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 20000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "20000000"), new[] { ModelsRes.BoxModelFCPreDisinfection_MPN_100ml });
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 20000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "20000000"), new[] { ModelsRes.BoxModelConcentration_MPN_100ml });
            }

            if (boxModel.T90_hour < 0 || boxModel.T90_hour > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelT90_hour, "0", "10000"), new[] { ModelsRes.BoxModelT90_hour });
            }

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "10000"), new[] { ModelsRes.BoxModelFlowDuration_hour });
            }

            if (boxModel.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLastUpdateContactTVItemID, "1"), new[] { ModelsRes.BoxModelLastUpdateContactTVItemID });
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
