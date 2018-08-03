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
    ///     <para>bonjour TVItem</para>
    /// </summary>
    public partial class TVItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItem tvItem = validationContext.ObjectInstance as TVItem;
            tvItem.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItem.TVItemID == 0)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVItemID"), new[] { "TVItemID" });
                }

                if (!GetRead().Where(c => c.TVItemID == tvItem.TVItemID).Any())
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemTVItemID", tvItem.TVItemID.ToString()), new[] { "TVItemID" });
                }
            }

            if (tvItem.TVType == TVTypeEnum.Root)
            {
                if (GetRead().Count() > 0)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(CSSPServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { "TVItemTVItemID" });
                }
            }

            if (tvItem.TVLevel < 0 || tvItem.TVLevel > 100)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVItemTVLevel", "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVPath"), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItem.TVPath) && tvItem.TVPath.Length > 250)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemTVPath", "250"), new[] { "TVPath" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
            if (tvItem.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVType"), new[] { "TVType" });
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemParentID = (from c in db.TVItems where c.TVItemID == tvItem.ParentID select c).FirstOrDefault();

                if (TVItemParentID == null)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemParentID", tvItem.ParentID.ToString()), new[] { "ParentID" });
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
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.Classification,
                    };
                    if (!AllowableTVTypes.Contains(TVItemParentID.TVType))
                    {
                        tvItem.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemParentID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), new[] { "ParentID" });
                    }
                }
            }

            if (tvItem.LastUpdateDate_UTC.Year == 1)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItem.LastUpdateDate_UTC.Year < 1980)
                {
                tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVItemLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItem.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemLastUpdateContactTVItemID", tvItem.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        tvItem.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                    }
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItem GetTVItemWithTVItemID(int TVItemID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.TVItemID == TVItemID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVItem> GetTVItemList()
        {
            IQueryable<TVItem> TVItemQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            TVItemQuery = EnhanceQueryStatements<TVItem>(TVItemQuery) as IQueryable<TVItem>;

            return TVItemQuery;
        }
        public TVItemWeb GetTVItemWebWithTVItemID(int TVItemID)
        {
            return FillTVItemWeb().FirstOrDefault();

        }
        public IQueryable<TVItemWeb> GetTVItemWebList()
        {
            IQueryable<TVItemWeb> TVItemWebQuery = FillTVItemWeb();

            TVItemWebQuery = EnhanceQueryStatements<TVItemWeb>(TVItemWebQuery) as IQueryable<TVItemWeb>;

            return TVItemWebQuery;
        }
        public TVItemReport GetTVItemReportWithTVItemID(int TVItemID)
        {
            return FillTVItemReport().FirstOrDefault();

        }
        public IQueryable<TVItemReport> GetTVItemReportList()
        {
            IQueryable<TVItemReport> TVItemReportQuery = FillTVItemReport();

            TVItemReportQuery = EnhanceQueryStatements<TVItemReport>(TVItemReportQuery) as IQueryable<TVItemReport>;

            return TVItemReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Add(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public bool Delete(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Delete);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Remove(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public bool Update(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Update);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Update(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public IQueryable<TVItem> GetRead()
        {
            IQueryable<TVItem> tvItemQuery = db.TVItems.AsNoTracking();

            return tvItemQuery;
        }
        public IQueryable<TVItem> GetEdit()
        {
            IQueryable<TVItem> tvItemQuery = db.TVItems;

            return tvItemQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVItemFillWeb
        private IQueryable<TVItemWeb> FillTVItemWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemWeb>  TVItemWebQuery = (from c in db.TVItems
                let TVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVItemWeb
                    {
                        TVItemLanguage = TVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        TVItemID = c.TVItemID,
                        TVLevel = c.TVLevel,
                        TVPath = c.TVPath,
                        TVType = c.TVType,
                        ParentID = c.ParentID,
                        IsActive = c.IsActive,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return TVItemWebQuery;
        }
        #endregion Functions private Generated TVItemFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(TVItem tvItem)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}