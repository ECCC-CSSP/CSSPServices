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
        public TVItemUserAuthorizationService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), new[] { "TVItemUserAuthorizationID" });
                }

                if (!GetRead().Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemUserAuthorization, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID, tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), new[] { "TVItemUserAuthorizationID" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, (tvItemUserAuthorization.ContactTVItemID == null ? "" : tvItemUserAuthorization.ContactTVItemID.ToString())), new[] { "ContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            TVItem TVItemTVItemID1 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();

            if (TVItemTVItemID1 == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, (tvItemUserAuthorization.TVItemID1 == null ? "" : tvItemUserAuthorization.TVItemID1.ToString())), new[] { "TVItemID1" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID1" });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();

                if (TVItemTVItemID2 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, (tvItemUserAuthorization.TVItemID2 == null ? "" : tvItemUserAuthorization.TVItemID2.ToString())), new[] { "TVItemID2" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID2" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                TVItem TVItemTVItemID3 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();

                if (TVItemTVItemID3 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, (tvItemUserAuthorization.TVItemID3 == null ? "" : tvItemUserAuthorization.TVItemID3.ToString())), new[] { "TVItemID3" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID3" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                TVItem TVItemTVItemID4 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();

                if (TVItemTVItemID4 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, (tvItemUserAuthorization.TVItemID4 == null ? "" : tvItemUserAuthorization.TVItemID4.ToString())), new[] { "TVItemID4" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID4" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemUserAuthorization.TVAuth);
            if (tvItemUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVAuth), new[] { "TVAuth" });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, (tvItemUserAuthorization.LastUpdateContactTVItemID == null ? "" : tvItemUserAuthorization.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID, GetParam getParam)
        {
            IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvItemUserAuthorizationQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVItemUserAuthorizationWeb(tvItemUserAuthorizationQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVItemUserAuthorizationReport(tvItemUserAuthorizationQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVItemUserAuthorization> GetTVItemUserAuthorizationList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvItemUserAuthorizationQuery  = tvItemUserAuthorizationQuery.OrderByDescending(c => c.TVItemUserAuthorizationID);
                        }
                        tvItemUserAuthorizationQuery = tvItemUserAuthorizationQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return tvItemUserAuthorizationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvItemUserAuthorizationQuery = FillTVItemUserAuthorizationWeb(tvItemUserAuthorizationQuery, FilterAndOrderText).OrderByDescending(c => c.TVItemUserAuthorizationID);
                        }
                        tvItemUserAuthorizationQuery = FillTVItemUserAuthorizationWeb(tvItemUserAuthorizationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return tvItemUserAuthorizationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            tvItemUserAuthorizationQuery = FillTVItemUserAuthorizationReport(tvItemUserAuthorizationQuery, FilterAndOrderText).OrderByDescending(c => c.TVItemUserAuthorizationID);
                        }
                        tvItemUserAuthorizationQuery = FillTVItemUserAuthorizationReport(tvItemUserAuthorizationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return tvItemUserAuthorizationQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<TVItemUserAuthorization> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.TVItemUserAuthorizations.AsNoTracking();
            }
            else
            {
                return db.TVItemUserAuthorizations.AsNoTracking().OrderByDescending(c => c.TVItemUserAuthorizationID);
            }
        }
        public IQueryable<TVItemUserAuthorization> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.TVItemUserAuthorizations;
            }
            else
            {
                return db.TVItemUserAuthorizations.OrderByDescending(c => c.TVItemUserAuthorizationID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVItemUserAuthorizationFillWeb
        private IQueryable<TVItemUserAuthorization> FillTVItemUserAuthorizationWeb(IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

            tvItemUserAuthorizationQuery = (from c in tvItemUserAuthorizationQuery
                let ContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVText1 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID1
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVText2 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID2
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVText3 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID3
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVText4 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID4
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TVItemUserAuthorization
                    {
                        TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVItemID1 = c.TVItemID1,
                        TVItemID2 = c.TVItemID2,
                        TVItemID3 = c.TVItemID3,
                        TVItemID4 = c.TVItemID4,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TVItemUserAuthorizationWeb = new TVItemUserAuthorizationWeb
                        {
                            ContactTVText = ContactTVText,
                            TVText1 = TVText1,
                            TVText2 = TVText2,
                            TVText3 = TVText3,
                            TVText4 = TVText4,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TVAuthText = (from e in TVAuthEnumList
                                where e.EnumID == (int?)c.TVAuth
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVItemUserAuthorizationReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvItemUserAuthorizationQuery;
        }
        #endregion Functions private Generated TVItemUserAuthorizationFillWeb

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
