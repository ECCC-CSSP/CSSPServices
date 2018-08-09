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
        public BoxModelService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelBoxModelID"), new[] { "BoxModelID" });
                }

                if (!(from c in db.BoxModels select c).Where(c => c.BoxModelID == boxModel.BoxModelID).Any())
                {
                    boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelBoxModelID", boxModel.BoxModelID.ToString()), new[] { "BoxModelID" });
                }
            }

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelInfrastructureTVItemID", boxModel.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelInfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (boxModel.Flow_m3_day < 0 || boxModel.Flow_m3_day > 10000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlow_m3_day", "0", "10000"), new[] { "Flow_m3_day" });
            }

            if (boxModel.Depth_m < 0 || boxModel.Depth_m > 1000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDepth_m", "0", "1000"), new[] { "Depth_m" });
            }

            if (boxModel.Temperature_C < -15 || boxModel.Temperature_C > 40)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelTemperature_C", "-15", "40"), new[] { "Temperature_C" });
            }

            if (boxModel.Dilution < 0 || boxModel.Dilution > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDilution", "0", "10000000"), new[] { "Dilution" });
            }

            if (boxModel.DecayRate_per_day < 0 || boxModel.DecayRate_per_day > 100)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelDecayRate_per_day", "0", "100"), new[] { "DecayRate_per_day" });
            }

            if (boxModel.FCUntreated_MPN_100ml < 0 || boxModel.FCUntreated_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCUntreated_MPN_100ml", "0", "10000000"), new[] { "FCUntreated_MPN_100ml" });
            }

            if (boxModel.FCPreDisinfection_MPN_100ml < 0 || boxModel.FCPreDisinfection_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFCPreDisinfection_MPN_100ml", "0", "10000000"), new[] { "FCPreDisinfection_MPN_100ml" });
            }

            if (boxModel.Concentration_MPN_100ml < 0 || boxModel.Concentration_MPN_100ml > 10000000)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelConcentration_MPN_100ml", "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (boxModel.T90_hour < 0)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelT90_hour", "0"), new[] { "T90_hour" });
            }

            if (boxModel.FlowDuration_hour < 0 || boxModel.FlowDuration_hour > 24)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelFlowDuration_hour", "0", "24"), new[] { "FlowDuration_hour" });
            }

            if (boxModel.LastUpdateDate_UTC.Year == 1)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModel.LastUpdateDate_UTC.Year < 1980)
                {
                boxModel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelLastUpdateContactTVItemID", boxModel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public BoxModel GetBoxModelWithBoxModelID(int BoxModelID)
        {
            return (from c in db.BoxModels
                    where c.BoxModelID == BoxModelID
                    select c).FirstOrDefault();

        }
        public IQueryable<BoxModel> GetBoxModelList()
        {
            IQueryable<BoxModel> BoxModelQuery = (from c in db.BoxModels select c);

            BoxModelQuery = EnhanceQueryStatements<BoxModel>(BoxModelQuery) as IQueryable<BoxModel>;

            return BoxModelQuery;
        }
        public BoxModel_A GetBoxModel_AWithBoxModelID(int BoxModelID)
        {
            return FillBoxModel_A().Where(c => c.BoxModelID == BoxModelID).FirstOrDefault();

        }
        public IQueryable<BoxModel_A> GetBoxModel_AList()
        {
            IQueryable<BoxModel_A> BoxModel_AQuery = FillBoxModel_A();

            BoxModel_AQuery = EnhanceQueryStatements<BoxModel_A>(BoxModel_AQuery) as IQueryable<BoxModel_A>;

            return BoxModel_AQuery;
        }
        public BoxModel_B GetBoxModel_BWithBoxModelID(int BoxModelID)
        {
            return FillBoxModel_B().Where(c => c.BoxModelID == BoxModelID).FirstOrDefault();

        }
        public IQueryable<BoxModel_B> GetBoxModel_BList()
        {
            IQueryable<BoxModel_B> BoxModel_BQuery = FillBoxModel_B();

            BoxModel_BQuery = EnhanceQueryStatements<BoxModel_B>(BoxModel_BQuery) as IQueryable<BoxModel_B>;

            return BoxModel_BQuery;
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
        #endregion Functions public Generated CRUD

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
