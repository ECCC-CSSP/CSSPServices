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
    ///     <para>bonjour TVItemUserAuthorization</para>
    /// </summary>
    public partial class TVItemUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;
            tvItemUserAuthorization.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationTVItemUserAuthorizationID"), new[] { "TVItemUserAuthorizationID" });
                }

                if (!(from c in db.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationTVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), new[] { "TVItemUserAuthorizationID" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationContactTVItemID", tvItemUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            TVItem TVItemTVItemID1 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();

            if (TVItemTVItemID1 == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID1", tvItemUserAuthorization.TVItemID1.ToString()), new[] { "TVItemID1" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Contact,
                    TVTypeEnum.Country,
                    TVTypeEnum.Email,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.Tel,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.BoxModel,
                    TVTypeEnum.VisualPlumesScenario,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MeshNode,
                    TVTypeEnum.WebTideNode,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.SeeOther,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.MapInfo,
                    TVTypeEnum.MapInfoPoint,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID1.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID1", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID1" });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();

                if (TVItemTVItemID2 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID2", (tvItemUserAuthorization.TVItemID2 == null ? "" : tvItemUserAuthorization.TVItemID2.ToString())), new[] { "TVItemID2" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOther,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID2", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID2" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                TVItem TVItemTVItemID3 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();

                if (TVItemTVItemID3 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID3", (tvItemUserAuthorization.TVItemID3 == null ? "" : tvItemUserAuthorization.TVItemID3.ToString())), new[] { "TVItemID3" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOther,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID3.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID3", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID3" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                TVItem TVItemTVItemID4 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();

                if (TVItemTVItemID4 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationTVItemID4", (tvItemUserAuthorization.TVItemID4 == null ? "" : tvItemUserAuthorization.TVItemID4.ToString())), new[] { "TVItemID4" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Address,
                        TVTypeEnum.Area,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.Contact,
                        TVTypeEnum.Country,
                        TVTypeEnum.Email,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.TideSite,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.Spill,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.OtherInfrastructure,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MeshNode,
                        TVTypeEnum.WebTideNode,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.SeeOther,
                        TVTypeEnum.LineOverflow,
                        TVTypeEnum.MapInfo,
                        TVTypeEnum.MapInfoPoint,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID4.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationTVItemID4", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID4" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemUserAuthorization.TVAuth);
            if (tvItemUserAuthorization.TVAuth == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationTVAuth"), new[] { "TVAuth" });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemUserAuthorizationLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemUserAuthorizationLastUpdateContactTVItemID", tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemUserAuthorizationLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return (from c in db.TVItemUserAuthorizations
                    where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVItemUserAuthorization> GetTVItemUserAuthorizationList()
        {
            IQueryable<TVItemUserAuthorization> TVItemUserAuthorizationQuery = (from c in db.TVItemUserAuthorizations select c);

            TVItemUserAuthorizationQuery = EnhanceQueryStatements<TVItemUserAuthorization>(TVItemUserAuthorizationQuery) as IQueryable<TVItemUserAuthorization>;

            return TVItemUserAuthorizationQuery;
        }
        public TVItemUserAuthorizationExtraA GetTVItemUserAuthorizationExtraAWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return FillTVItemUserAuthorizationExtraA().Where(c => c.TVItemUserAuthorizationID == TVItemUserAuthorizationID).FirstOrDefault();

        }
        public IQueryable<TVItemUserAuthorizationExtraA> GetTVItemUserAuthorizationExtraAList()
        {
            IQueryable<TVItemUserAuthorizationExtraA> TVItemUserAuthorizationExtraAQuery = FillTVItemUserAuthorizationExtraA();

            TVItemUserAuthorizationExtraAQuery = EnhanceQueryStatements<TVItemUserAuthorizationExtraA>(TVItemUserAuthorizationExtraAQuery) as IQueryable<TVItemUserAuthorizationExtraA>;

            return TVItemUserAuthorizationExtraAQuery;
        }
        public TVItemUserAuthorizationExtraB GetTVItemUserAuthorizationExtraBWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return FillTVItemUserAuthorizationExtraB().Where(c => c.TVItemUserAuthorizationID == TVItemUserAuthorizationID).FirstOrDefault();

        }
        public IQueryable<TVItemUserAuthorizationExtraB> GetTVItemUserAuthorizationExtraBList()
        {
            IQueryable<TVItemUserAuthorizationExtraB> TVItemUserAuthorizationExtraBQuery = FillTVItemUserAuthorizationExtraB();

            TVItemUserAuthorizationExtraBQuery = EnhanceQueryStatements<TVItemUserAuthorizationExtraB>(TVItemUserAuthorizationExtraBQuery) as IQueryable<TVItemUserAuthorizationExtraB>;

            return TVItemUserAuthorizationExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Add(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool Delete(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Delete);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool Update(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Update(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(TVItemUserAuthorization tvItemUserAuthorization)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
