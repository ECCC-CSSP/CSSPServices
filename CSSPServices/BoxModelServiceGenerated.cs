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
        #endregion Properties

        #region Constructors
        public BoxModelService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelBoxModelID), new[] { "BoxModelID" });
                }
            }

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelInfrastructureTVItemID, boxModel.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            //Flow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "10000"), new[] { "Flow_m3_day" });
            }

            //Depth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000"), new[] { "Depth_m" });
            }

            //Temperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "-15", "40"), new[] { "Temperature_C" });
            }

            //Dilution (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000"), new[] { "Dilution" });
            }

            //DecayRate_per_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "100"), new[] { "DecayRate_per_day" });
            }

            //FCUntreated_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), new[] { "FCUntreated_MPN_100ml" });
            }

            //FCPreDisinfection_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), new[] { "FCPreDisinfection_MPN_100ml" });
            }

            //Concentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            //T90_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.T90_hour < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelT90_hour, "0"), new[] { "T90_hour" });
            }

            //FlowDuration_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 24)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "24"), new[] { "FlowDuration_hour" });
            }

            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLastUpdateContactTVItemID, boxModel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(boxModel.InfrastructureTVText) && boxModel.InfrastructureTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelInfrastructureTVText, "200"), new[] { "InfrastructureTVText" });
            }

            if (!string.IsNullOrWhiteSpace(boxModel.LastUpdateContactTVText) && boxModel.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public BoxModel GetBoxModelWithBoxModelID(int BoxModelID)
        {
            IQueryable<BoxModel> boxModelQuery = (from c in GetRead()
                                                where c.BoxModelID == BoxModelID
                                                select c);

            return FillBoxModel(boxModelQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<BoxModel> FillBoxModel(IQueryable<BoxModel> boxModelQuery)
        {
            List<BoxModel> BoxModelList = (from c in boxModelQuery
                                         let InfrastructureTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.InfrastructureTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new BoxModel
                                         {
                                             BoxModelID = c.BoxModelID,
                                             InfrastructureTVItemID = c.InfrastructureTVItemID,
                                             Flow_m3_day = c.Flow_m3_day,
                                             Depth_m = c.Depth_m,
                                             Temperature_C = c.Temperature_C,
                                             Dilution = c.Dilution,
                                             DecayRate_per_day = c.DecayRate_per_day,
                                             FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                                             FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                                             Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                             T90_hour = c.T90_hour,
                                             FlowDuration_hour = c.FlowDuration_hour,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             InfrastructureTVText = InfrastructureTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return BoxModelList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
