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
    ///     <para>bonjour BoxModel</para>
    /// </summary>
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
            boxModel.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModel.BoxModelID == 0)
                {
                    boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelBoxModelID), new[] { "BoxModelID" });
                }

                if (!GetRead().Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                {
                    boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModel, CSSPModelsRes.BoxModelBoxModelID, boxModel.BoxModelID.ToString()), new[] { "BoxModelID" });
                }
            }

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelInfrastructureTVItemID, boxModel.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            //Flow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 10000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlow_m3_day, "0", "10000"), new[] { "Flow_m3_day" });
            }

            //Depth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDepth_m, "0", "1000"), new[] { "Depth_m" });
            }

            //Temperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelTemperature_C, "-15", "40"), new[] { "Temperature_C" });
            }

            //Dilution (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDilution, "0", "10000000"), new[] { "Dilution" });
            }

            //DecayRate_per_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDecayRate_per_day, "0", "100"), new[] { "DecayRate_per_day" });
            }

            //FCUntreated_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), new[] { "FCUntreated_MPN_100ml" });
            }

            //FCPreDisinfection_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), new[] { "FCPreDisinfection_MPN_100ml" });
            }

            //Concentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            //T90_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.T90_hour < 0)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelT90_hour, "0"), new[] { "T90_hour" });
            }

            //FlowDuration_hour (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 24)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlowDuration_hour, "0", "24"), new[] { "FlowDuration_hour" });
            }

                //Error: Type not implemented [BoxModelWeb] of type [BoxModelWeb]
                //Error: Type not implemented [BoxModelReport] of type [BoxModelReport]
            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.BoxModelLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelLastUpdateContactTVItemID, boxModel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public BoxModel GetBoxModelWithBoxModelID(int BoxModelID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<BoxModel> boxModelQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.BoxModelID == BoxModelID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return boxModelQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillBoxModel(boxModelQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<BoxModel> GetBoxModelList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<BoxModel> boxModelQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return boxModelQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillBoxModel(boxModelQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
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
        public bool Delete(BoxModel boxModel)
        {
            boxModel.ValidationResults = Validate(new ValidationContext(boxModel), ActionDBTypeEnum.Delete);
            if (boxModel.ValidationResults.Count() > 0) return false;

            db.BoxModels.Remove(boxModel);

            if (!TryToSave(boxModel)) return false;

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
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<BoxModel> FillBoxModel_Show_Copy_To_BoxModelServiceExtra_As_Fill_BoxModel(IQueryable<BoxModel> boxModelQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            boxModelQuery = (from c in boxModelQuery
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
                        BoxModelWeb = new BoxModelWeb
                        {
                            InfrastructureTVText = InfrastructureTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        BoxModelReport = new BoxModelReport
                        {
                            BoxModelReportTest = "BoxModelReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return boxModelQuery;
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
        #endregion Functions private Generated

    }
}
