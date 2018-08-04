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
        public TVItemLinkService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkTVItemLinkID"), new[] { "TVItemLinkID" });
                }

                if (!(from c in db.TVItemLinks select c).Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkTVItemLinkID", tvItemLink.TVItemLinkID.ToString()), new[] { "TVItemLinkID" });
                }
            }

            TVItem TVItemFromTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.FromTVItemID select c).FirstOrDefault();

            if (TVItemFromTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkFromTVItemID", tvItemLink.FromTVItemID.ToString()), new[] { "FromTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkFromTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "FromTVItemID" });
                }
            }

            TVItem TVItemToTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.ToTVItemID select c).FirstOrDefault();

            if (TVItemToTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkToTVItemID", tvItemLink.ToTVItemID.ToString()), new[] { "ToTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkToTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "ToTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.FromTVType);
            if (tvItemLink.FromTVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkFromTVType"), new[] { "FromTVType" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemLink.ToTVType);
            if (tvItemLink.ToTVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkToTVType"), new[] { "ToTVType" });
            }

            if (tvItemLink.StartDateTime_Local != null && ((DateTime)tvItemLink.StartDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkStartDateTime_Local", "1980"), new[] { "TVItemLinkStartDateTime_Local" });
            }

            if (tvItemLink.EndDateTime_Local != null && ((DateTime)tvItemLink.EndDateTime_Local).Year < 1980)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkEndDateTime_Local", "1980"), new[] { "TVItemLinkEndDateTime_Local" });
            }

            if (tvItemLink.StartDateTime_Local > tvItemLink.EndDateTime_Local)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "TVItemLinkEndDateTime_Local", "TVItemLinkStartDateTime_Local"), new[] { "TVItemLinkEndDateTime_Local" });
            }

            if (tvItemLink.Ordinal < 0 || tvItemLink.Ordinal > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkOrdinal", "0", "100"), new[] { "Ordinal" });
            }

            if (tvItemLink.TVLevel < 0 || tvItemLink.TVLevel > 100)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemLinkTVLevel", "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLink.TVPath))
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkTVPath"), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.TVPath) && tvItemLink.TVPath.Length > 250)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemLinkTVPath", "250"), new[] { "TVPath" });
            }

            if (tvItemLink.ParentTVItemLinkID != null)
            {
                TVItemLink TVItemLinkParentTVItemLinkID = (from c in db.TVItemLinks where c.TVItemLinkID == tvItemLink.ParentTVItemLinkID select c).FirstOrDefault();

                if (TVItemLinkParentTVItemLinkID == null)
                {
                    tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkParentTVItemLinkID", (tvItemLink.ParentTVItemLinkID == null ? "" : tvItemLink.ParentTVItemLinkID.ToString())), new[] { "ParentTVItemLinkID" });
                }
            }

            if (tvItemLink.LastUpdateDate_UTC.Year == 1)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLinkLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLink.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemLink.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLinkLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLinkLastUpdateContactTVItemID", tvItemLink.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLinkLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            return (from c in db.TVItemLinks
                    where c.TVItemLinkID == TVItemLinkID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVItemLink> GetTVItemLinkList()
        {
            IQueryable<TVItemLink> TVItemLinkQuery = (from c in db.TVItemLinks select c);

            TVItemLinkQuery = EnhanceQueryStatements<TVItemLink>(TVItemLinkQuery) as IQueryable<TVItemLink>;

            return TVItemLinkQuery;
        }
        public TVItemLinkWeb GetTVItemLinkWebWithTVItemLinkID(int TVItemLinkID)
        {
            return FillTVItemLinkWeb().Where(c => c.TVItemLinkID == TVItemLinkID).FirstOrDefault();

        }
        public IQueryable<TVItemLinkWeb> GetTVItemLinkWebList()
        {
            IQueryable<TVItemLinkWeb> TVItemLinkWebQuery = FillTVItemLinkWeb();

            TVItemLinkWebQuery = EnhanceQueryStatements<TVItemLinkWeb>(TVItemLinkWebQuery) as IQueryable<TVItemLinkWeb>;

            return TVItemLinkWebQuery;
        }
        public TVItemLinkReport GetTVItemLinkReportWithTVItemLinkID(int TVItemLinkID)
        {
            return FillTVItemLinkReport().Where(c => c.TVItemLinkID == TVItemLinkID).FirstOrDefault();

        }
        public IQueryable<TVItemLinkReport> GetTVItemLinkReportList()
        {
            IQueryable<TVItemLinkReport> TVItemLinkReportQuery = FillTVItemLinkReport();

            TVItemLinkReportQuery = EnhanceQueryStatements<TVItemLinkReport>(TVItemLinkReportQuery) as IQueryable<TVItemLinkReport>;

            return TVItemLinkReportQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVItemLinkFillWeb
        private IQueryable<TVItemLinkWeb> FillTVItemLinkWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemLinkWeb>  TVItemLinkWebQuery = (from c in db.TVItemLinks
                let FromTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.FromTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ToTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ToTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVItemLinkWeb
                    {
                        FromTVItemLanguage = FromTVItemLanguage,
                        ToTVItemLanguage = ToTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        FromTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.FromTVType
                                select e.EnumText).FirstOrDefault(),
                        ToTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.ToTVType
                                select e.EnumText).FirstOrDefault(),
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVItemLinkWebQuery;
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
