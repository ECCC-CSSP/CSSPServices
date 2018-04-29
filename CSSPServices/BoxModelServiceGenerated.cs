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
        public BoxModelService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelInfrastructureTVItemID, (boxModel.InfrastructureTVItemID == null ? "" : boxModel.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
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

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 10000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlow_m3_day, "0", "10000"), new[] { "Flow_m3_day" });
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDepth_m, "0", "1000"), new[] { "Depth_m" });
            }

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelTemperature_C, "-15", "40"), new[] { "Temperature_C" });
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDilution, "0", "10000000"), new[] { "Dilution" });
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelDecayRate_per_day, "0", "100"), new[] { "DecayRate_per_day" });
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000"), new[] { "FCUntreated_MPN_100ml" });
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000"), new[] { "FCPreDisinfection_MPN_100ml" });
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (boxModel.T90_hour < 0)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelT90_hour, "0"), new[] { "T90_hour" });
            }

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 24)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelFlowDuration_hour, "0", "24"), new[] { "FlowDuration_hour" });
            }

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

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelLastUpdateContactTVItemID, (boxModel.LastUpdateContactTVItemID == null ? "" : boxModel.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public BoxModel GetBoxModelWithBoxModelID(int BoxModelID, GetParam getParam)
        {
            IQueryable<BoxModel> boxModelQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.BoxModelID == BoxModelID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return boxModelQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillBoxModelWeb(boxModelQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillBoxModelReport(boxModelQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<BoxModel> GetBoxModelList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<BoxModel> boxModelQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            boxModelQuery  = boxModelQuery.OrderByDescending(c => c.BoxModelID);
                        }
                        boxModelQuery = boxModelQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return boxModelQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            boxModelQuery = FillBoxModelWeb(boxModelQuery, FilterAndOrderText).OrderByDescending(c => c.BoxModelID);
                        }
                        boxModelQuery = FillBoxModelWeb(boxModelQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return boxModelQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            boxModelQuery = FillBoxModelReport(boxModelQuery, FilterAndOrderText).OrderByDescending(c => c.BoxModelID);
                        }
                        boxModelQuery = FillBoxModelReport(boxModelQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return boxModelQuery;
                    }
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
            if (GetParam.OrderAscending)
            {
                return db.BoxModels.AsNoTracking();
            }
            else
            {
                return db.BoxModels.AsNoTracking().OrderByDescending(c => c.BoxModelID);
            }
        }
        public IQueryable<BoxModel> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.BoxModels;
            }
            else
            {
                return db.BoxModels.OrderByDescending(c => c.BoxModelID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated BoxModelFillWeb
        private IQueryable<BoxModel> FillBoxModelWeb(IQueryable<BoxModel> boxModelQuery, string FilterAndOrderText)
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
                        BoxModelReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return boxModelQuery;
        }
        #endregion Functions private Generated BoxModelFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
