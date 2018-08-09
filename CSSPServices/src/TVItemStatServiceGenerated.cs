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
    ///     <para>bonjour TVItemStat</para>
    /// </summary>
    public partial class TVItemStatService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemStatService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemStat tvItemStat = validationContext.ObjectInstance as TVItemStat;
            tvItemStat.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemStat.TVItemStatID == 0)
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemStatTVItemStatID"), new[] { "TVItemStatID" });
                }

                if (!(from c in db.TVItemStats select c).Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatTVItemStatID", tvItemStat.TVItemStatID.ToString()), new[] { "TVItemStatID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemStatTVItemID", tvItemStat.TVItemID.ToString()), new[] { "TVItemID" });
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
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemStatTVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemStat.TVType);
            if (tvItemStat.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemStatTVType"), new[] { "TVType" });
            }

            if (tvItemStat.ChildCount < 0 || tvItemStat.ChildCount > 10000000)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemStatChildCount", "0", "10000000"), new[] { "ChildCount" });
            }

            if (tvItemStat.LastUpdateDate_UTC.Year == 1)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemStatLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemStat.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemStatLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemStatLastUpdateContactTVItemID", tvItemStat.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemStatLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItemStat GetTVItemStatWithTVItemStatID(int TVItemStatID)
        {
            return (from c in db.TVItemStats
                    where c.TVItemStatID == TVItemStatID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVItemStat> GetTVItemStatList()
        {
            IQueryable<TVItemStat> TVItemStatQuery = (from c in db.TVItemStats select c);

            TVItemStatQuery = EnhanceQueryStatements<TVItemStat>(TVItemStatQuery) as IQueryable<TVItemStat>;

            return TVItemStatQuery;
        }
        public TVItemStat_A GetTVItemStat_AWithTVItemStatID(int TVItemStatID)
        {
            return FillTVItemStat_A().Where(c => c.TVItemStatID == TVItemStatID).FirstOrDefault();

        }
        public IQueryable<TVItemStat_A> GetTVItemStat_AList()
        {
            IQueryable<TVItemStat_A> TVItemStat_AQuery = FillTVItemStat_A();

            TVItemStat_AQuery = EnhanceQueryStatements<TVItemStat_A>(TVItemStat_AQuery) as IQueryable<TVItemStat_A>;

            return TVItemStat_AQuery;
        }
        public TVItemStat_B GetTVItemStat_BWithTVItemStatID(int TVItemStatID)
        {
            return FillTVItemStat_B().Where(c => c.TVItemStatID == TVItemStatID).FirstOrDefault();

        }
        public IQueryable<TVItemStat_B> GetTVItemStat_BList()
        {
            IQueryable<TVItemStat_B> TVItemStat_BQuery = FillTVItemStat_B();

            TVItemStat_BQuery = EnhanceQueryStatements<TVItemStat_B>(TVItemStat_BQuery) as IQueryable<TVItemStat_B>;

            return TVItemStat_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Add(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        public bool Delete(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Delete);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Remove(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        public bool Update(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Update(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(TVItemStat tvItemStat)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemStat.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
