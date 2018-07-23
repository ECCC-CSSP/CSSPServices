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
    ///     <para>bonjour TideSite</para>
    /// </summary>
    public partial class TideSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideSite tideSite = validationContext.ObjectInstance as TideSite;
            tideSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideSite.TideSiteID == 0)
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteTideSiteID), new[] { "TideSiteID" });
                }

                if (!GetRead().Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideSite, CSSPModelsRes.TideSiteTideSiteID, tideSite.TideSiteID.ToString()), new[] { "TideSiteID" });
                }
            }

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteTideSiteTVItemID, tideSite.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteTideSiteTVItemID, "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tideSite.WebTideModel))
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteWebTideModel), new[] { "WebTideModel" });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.WebTideModel) && tideSite.WebTideModel.Length > 100)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideSiteWebTideModel, "100"), new[] { "WebTideModel" });
            }

            if (tideSite.WebTideDatum_m < -100 || tideSite.WebTideDatum_m > 100)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideSiteWebTideDatum_m, "-100", "100"), new[] { "WebTideDatum_m" });
            }

            if (tideSite.LastUpdateDate_UTC.Year == 1)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideSite.LastUpdateDate_UTC.Year < 1980)
                {
                tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, tideSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tideSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tideSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TideSite GetTideSiteWithTideSiteID(int TideSiteID)
        {
            IQueryable<TideSite> tideSiteQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TideSiteID == TideSiteID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tideSiteQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTideSiteWeb(tideSiteQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTideSiteReport(tideSiteQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TideSite> GetTideSiteList()
        {
            IQueryable<TideSite> tideSiteQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tideSiteQuery = EnhanceQueryStatements<TideSite>(tideSiteQuery) as IQueryable<TideSite>;

                        return tideSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tideSiteQuery = FillTideSiteWeb(tideSiteQuery);

                        tideSiteQuery = EnhanceQueryStatements<TideSite>(tideSiteQuery) as IQueryable<TideSite>;

                        return tideSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tideSiteQuery = FillTideSiteReport(tideSiteQuery);

                        tideSiteQuery = EnhanceQueryStatements<TideSite>(tideSiteQuery) as IQueryable<TideSite>;

                        return tideSiteQuery;
                    }
                default:
                    {
                        tideSiteQuery = tideSiteQuery.Where(c => c.TideSiteID == 0);

                        return tideSiteQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Add(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool Delete(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Delete);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Remove(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool Update(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Update(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public IQueryable<TideSite> GetRead()
        {
            IQueryable<TideSite> tideSiteQuery = db.TideSites.AsNoTracking();

            return tideSiteQuery;
        }
        public IQueryable<TideSite> GetEdit()
        {
            IQueryable<TideSite> tideSiteQuery = db.TideSites;

            return tideSiteQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TideSiteFillWeb
        private IQueryable<TideSite> FillTideSiteWeb(IQueryable<TideSite> tideSiteQuery)
        {
            tideSiteQuery = (from c in tideSiteQuery
                let TideSiteTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TideSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TideSite
                    {
                        TideSiteID = c.TideSiteID,
                        TideSiteTVItemID = c.TideSiteTVItemID,
                        WebTideModel = c.WebTideModel,
                        WebTideDatum_m = c.WebTideDatum_m,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TideSiteWeb = new TideSiteWeb
                        {
                            TideSiteTVText = TideSiteTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        TideSiteReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tideSiteQuery;
        }
        #endregion Functions private Generated TideSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(TideSite tideSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
