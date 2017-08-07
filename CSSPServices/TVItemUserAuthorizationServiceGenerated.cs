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
    public partial class TVItemUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), new[] { "TVItemUserAuthorizationID" });
                }
            }

            //TVItemUserAuthorizationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            //TVItemID1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID1 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();

            if (TVItemTVItemID1 == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), new[] { "TVItemID1" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Country,
                    TVTypeEnum.Province,
                    TVTypeEnum.Area,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.MWQMSiteSample,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Spill,
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID1.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID1, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID1" });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();

                if (TVItemTVItemID2 == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), new[] { "TVItemID2" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Country,
                        TVTypeEnum.Province,
                        TVTypeEnum.Area,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.MWQMSiteSample,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.Spill,
                        TVTypeEnum.TideSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID2, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID2" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                TVItem TVItemTVItemID3 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();

                if (TVItemTVItemID3 == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), new[] { "TVItemID3" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Country,
                        TVTypeEnum.Province,
                        TVTypeEnum.Area,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.MWQMSiteSample,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.Spill,
                        TVTypeEnum.TideSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID3.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID3, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID3" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                TVItem TVItemTVItemID4 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();

                if (TVItemTVItemID4 == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), new[] { "TVItemID4" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Root,
                        TVTypeEnum.Country,
                        TVTypeEnum.Province,
                        TVTypeEnum.Area,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.ClimateSite,
                        TVTypeEnum.File,
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.MWQMSiteSample,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.SamplingPlan,
                        TVTypeEnum.Spill,
                        TVTypeEnum.TideSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID4.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID4, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID4" });
                    }
                }
            }

            retStr = enums.TVAuthOK(tvItemUserAuthorization.TVAuth);
            if (tvItemUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth), new[] { "TVAuth" });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorization.TVAuthText) && tvItemUserAuthorization.TVAuthText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVAuthText, "100"), new[] { "TVAuthText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery = (from c in GetRead()
                                                where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                                select c);

            return FillTVItemUserAuthorization(tvItemUserAuthorizationQuery).FirstOrDefault();
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
        public bool AddRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;
            }

            db.TVItemUserAuthorizations.AddRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

            return true;
        }
        public bool Delete(TVItemUserAuthorization tvItemUserAuthorization)
        {
            if (!db.TVItemUserAuthorizations.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
            {
                tvItemUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                if (!db.TVItemUserAuthorizations.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                {
                    tvItemUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

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
        public bool UpdateRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;
            }
            db.TVItemUserAuthorizations.UpdateRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

            return true;
        }
        public IQueryable<TVItemUserAuthorization> GetRead()
        {
            return db.TVItemUserAuthorizations.AsNoTracking();
        }
        public IQueryable<TVItemUserAuthorization> GetEdit()
        {
            return db.TVItemUserAuthorizations;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVItemUserAuthorization> FillTVItemUserAuthorization(IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery)
        {
            List<TVItemUserAuthorization> TVItemUserAuthorizationList = (from c in tvItemUserAuthorizationQuery
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
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVItemUserAuthorization tvItemUserAuthorization in TVItemUserAuthorizationList)
            {
                tvItemUserAuthorization.TVAuthText = enums.GetEnumText_TVAuthEnum(tvItemUserAuthorization.TVAuth);
            }

            return TVItemUserAuthorizationList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        private bool TryToSaveRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
