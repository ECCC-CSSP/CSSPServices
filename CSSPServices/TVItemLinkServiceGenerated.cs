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
    public partial class TVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLinkService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemLink tvItemLink = validationContext.ObjectInstance as TVItemLink;
            tvItemLink.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemLink.TVItemLinkID == 0)
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVItemLinkID), new[] { "TVItemLinkID" });
                }

                if (!GetRead().Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItemLink, ModelsRes.TVItemLinkTVItemLinkID, tvItemLink.TVItemLinkID.ToString()), new[] { "TVItemLinkID" });
                }
            }

            //TVItemLinkID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FromTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemFromTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.FromTVItemID select c).FirstOrDefault();

            if (TVItemFromTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), new[] { "FromTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemFromTVItemID.TVType))
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkFromTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "FromTVItemID" });
                }
            }

            //ToTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemToTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.ToTVItemID select c).FirstOrDefault();

            if (TVItemToTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), new[] { "ToTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemToTVItemID.TVType))
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkToTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "ToTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.FromTVType);
            if (tvItemLink.FromTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkFromTVType), new[] { "FromTVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.ToTVType);
            if (tvItemLink.ToTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkToTVType), new[] { "ToTVType" });
            }

            if (tvItemLink.StartDateTime_Local != null && ((DateTime)tvItemLink.StartDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkStartDateTime_Local, "1980"), new[] { ModelsRes.TVItemLinkStartDateTime_Local });
            }

            if (tvItemLink.EndDateTime_Local != null && ((DateTime)tvItemLink.EndDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkEndDateTime_Local, "1980"), new[] { ModelsRes.TVItemLinkEndDateTime_Local });
            }

            if (tvItemLink.StartDateTime_Local > tvItemLink.EndDateTime_Local)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.TVItemLinkEndDateTime_Local, ModelsRes.TVItemLinkStartDateTime_Local), new[] { ModelsRes.TVItemLinkEndDateTime_Local });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLink.Ordinal < 0 || tvItemLink.Ordinal > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100"), new[] { "Ordinal" });
            }

            //TVLevel (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLink.TVLevel < 0 || tvItemLink.TVLevel > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLink.TVPath))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.TVPath) && tvItemLink.TVPath.Length > 250)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkTVPath, "250"), new[] { "TVPath" });
            }

            if (tvItemLink.ParentTVItemLinkID != null)
            {
                TVItemLink TVItemLinkParentTVItemLinkID = (from c in db.TVItemLinks where c.TVItemLinkID == tvItemLink.ParentTVItemLinkID select c).FirstOrDefault();

                if (TVItemLinkParentTVItemLinkID == null)
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItemLink, ModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), new[] { "ParentTVItemLinkID" });
                }
            }

            if (tvItemLink.LastUpdateDate_UTC.Year == 1)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLink.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.FromTVText) && tvItemLink.FromTVText.Length > 200)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkFromTVText, "200"), new[] { "FromTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.ToTVText) && tvItemLink.ToTVText.Length > 200)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkToTVText, "200"), new[] { "ToTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.LastUpdateContactTVText) && tvItemLink.LastUpdateContactTVText.Length > 200)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.FromTVTypeText) && tvItemLink.FromTVTypeText.Length > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkFromTVTypeText, "100"), new[] { "FromTVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.ToTVTypeText) && tvItemLink.ToTVTypeText.Length > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkToTVTypeText, "100"), new[] { "ToTVTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItemLink GetTVItemLinkWithTVItemLinkID(int TVItemLinkID)
        {
            IQueryable<TVItemLink> tvItemLinkQuery = (from c in GetRead()
                                                where c.TVItemLinkID == TVItemLinkID
                                                select c);

            return FillTVItemLink(tvItemLinkQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVItemLink tvItemLink)
        {
            tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Create);
            if (tvItemLink.ValidationResults.Count() > 0) return false;

            db.TVItemLinks.Add(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public bool Delete(TVItemLink tvItemLink)
        {
            tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Delete);
            if (tvItemLink.ValidationResults.Count() > 0) return false;

            db.TVItemLinks.Remove(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public bool Update(TVItemLink tvItemLink)
        {
            tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Update);
            if (tvItemLink.ValidationResults.Count() > 0) return false;

            db.TVItemLinks.Update(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public IQueryable<TVItemLink> GetRead()
        {
            return db.TVItemLinks.AsNoTracking();
        }
        public IQueryable<TVItemLink> GetEdit()
        {
            return db.TVItemLinks;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVItemLink> FillTVItemLink(IQueryable<TVItemLink> tvItemLinkQuery)
        {
            List<TVItemLink> TVItemLinkList = (from c in tvItemLinkQuery
                                         let FromTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.FromTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let ToTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.ToTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new TVItemLink
                                         {
                                             TVItemLinkID = c.TVItemLinkID,
                                             FromTVItemID = c.FromTVItemID,
                                             ToTVItemID = c.ToTVItemID,
                                             FromTVType = c.FromTVType,
                                             ToTVType = c.ToTVType,
                                             StartDateTime_Local = c.StartDateTime_Local,
                                             EndDateTime_Local = c.EndDateTime_Local,
                                             Ordinal = c.Ordinal,
                                             TVLevel = c.TVLevel,
                                             TVPath = c.TVPath,
                                             ParentTVItemLinkID = c.ParentTVItemLinkID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             FromTVText = FromTVText,
                                             ToTVText = ToTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVItemLink tvItemLink in TVItemLinkList)
            {
                tvItemLink.FromTVTypeText = enums.GetResValueForTypeAndID(typeof(TVTypeEnum), (int?)tvItemLink.FromTVType);
                tvItemLink.ToTVTypeText = enums.GetResValueForTypeAndID(typeof(TVTypeEnum), (int?)tvItemLink.ToTVType);
            }

            return TVItemLinkList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(TVItemLink tvItemLink)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLink.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
