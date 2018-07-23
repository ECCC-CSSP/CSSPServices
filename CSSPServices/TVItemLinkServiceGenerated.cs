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
    ///     <para>bonjour TVItemLink</para>
    /// </summary>
    public partial class TVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLinkService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVItemLinkID), new[] { "TVItemLinkID" });
                }

                if (!GetRead().Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkTVItemLinkID, tvItemLink.TVItemLinkID.ToString()), new[] { "TVItemLinkID" });
                }
            }

            TVItem TVItemFromTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.FromTVItemID select c).FirstOrDefault();

            if (TVItemFromTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), new[] { "FromTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemFromTVItemID.TVType))
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkFromTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "FromTVItemID" });
                }
            }

            TVItem TVItemToTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.ToTVItemID select c).FirstOrDefault();

            if (TVItemToTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), new[] { "ToTVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemToTVItemID.TVType))
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkToTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "ToTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.FromTVType);
            if (tvItemLink.FromTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkFromTVType), new[] { "FromTVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.ToTVType);
            if (tvItemLink.ToTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkToTVType), new[] { "ToTVType" });
            }

            if (tvItemLink.StartDateTime_Local != null && ((DateTime)tvItemLink.StartDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkStartDateTime_Local, "1980"), new[] { CSSPModelsRes.TVItemLinkStartDateTime_Local });
            }

            if (tvItemLink.EndDateTime_Local != null && ((DateTime)tvItemLink.EndDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkEndDateTime_Local, "1980"), new[] { CSSPModelsRes.TVItemLinkEndDateTime_Local });
            }

            if (tvItemLink.StartDateTime_Local > tvItemLink.EndDateTime_Local)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.TVItemLinkEndDateTime_Local, CSSPModelsRes.TVItemLinkStartDateTime_Local), new[] { CSSPModelsRes.TVItemLinkEndDateTime_Local });
            }

            if (tvItemLink.Ordinal < 0 || tvItemLink.Ordinal > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkOrdinal, "0", "100"), new[] { "Ordinal" });
            }

            if (tvItemLink.TVLevel < 0 || tvItemLink.TVLevel > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemLinkTVLevel, "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLink.TVPath))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.TVPath) && tvItemLink.TVPath.Length > 250)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLinkTVPath, "250"), new[] { "TVPath" });
            }

            if (tvItemLink.ParentTVItemLinkID != null)
            {
                TVItemLink TVItemLinkParentTVItemLinkID = (from c in db.TVItemLinks where c.TVItemLinkID == tvItemLink.ParentTVItemLinkID select c).FirstOrDefault();

                if (TVItemLinkParentTVItemLinkID == null)
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLink, CSSPModelsRes.TVItemLinkParentTVItemLinkID, (tvItemLink.ParentTVItemLinkID == null ? "" : tvItemLink.ParentTVItemLinkID.ToString())), new[] { "ParentTVItemLinkID" });
                }
            }

            if (tvItemLink.LastUpdateDate_UTC.Year == 1)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLink.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLinkLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            IQueryable<TVItemLink> tvItemLinkQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVItemLinkID == TVItemLinkID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvItemLinkQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVItemLinkWeb(tvItemLinkQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVItemLinkReport(tvItemLinkQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVItemLink> GetTVItemLinkList()
        {
            IQueryable<TVItemLink> tvItemLinkQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tvItemLinkQuery = EnhanceQueryStatements<TVItemLink>(tvItemLinkQuery) as IQueryable<TVItemLink>;

                        return tvItemLinkQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tvItemLinkQuery = FillTVItemLinkWeb(tvItemLinkQuery);

                        tvItemLinkQuery = EnhanceQueryStatements<TVItemLink>(tvItemLinkQuery) as IQueryable<TVItemLink>;

                        return tvItemLinkQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tvItemLinkQuery = FillTVItemLinkReport(tvItemLinkQuery);

                        tvItemLinkQuery = EnhanceQueryStatements<TVItemLink>(tvItemLinkQuery) as IQueryable<TVItemLink>;

                        return tvItemLinkQuery;
                    }
                default:
                    {
                        tvItemLinkQuery = tvItemLinkQuery.Where(c => c.TVItemLinkID == 0);

                        return tvItemLinkQuery;
                    }
            }
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
            IQueryable<TVItemLink> tvItemLinkQuery = db.TVItemLinks.AsNoTracking();

            return tvItemLinkQuery;
        }
        public IQueryable<TVItemLink> GetEdit()
        {
            IQueryable<TVItemLink> tvItemLinkQuery = db.TVItemLinks;

            return tvItemLinkQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVItemLinkFillWeb
        private IQueryable<TVItemLink> FillTVItemLinkWeb(IQueryable<TVItemLink> tvItemLinkQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            tvItemLinkQuery = (from c in tvItemLinkQuery
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
                        TVItemLinkWeb = new TVItemLinkWeb
                        {
                            FromTVText = FromTVText,
                            ToTVText = ToTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            FromTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.FromTVType
                                select e.EnumText).FirstOrDefault(),
                            ToTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.ToTVType
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVItemLinkReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvItemLinkQuery;
        }
        #endregion Functions private Generated TVItemLinkFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
