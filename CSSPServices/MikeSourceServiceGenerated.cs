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
    ///     <para>bonjour MikeSource</para>
    /// </summary>
    public partial class MikeSourceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;
            mikeSource.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceMikeSourceID), new[] { "MikeSourceID" });
                }

                if (!GetRead().Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSource, CSSPModelsRes.MikeSourceMikeSourceID, mikeSource.MikeSourceID.ToString()), new[] { "MikeSourceID" });
                }
            }

            TVItem TVItemMikeSourceTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceMikeSourceTVItemID, (mikeSource.MikeSourceTVItemID == null ? "" : mikeSource.MikeSourceTVItemID.ToString())), new[] { "MikeSourceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeSourceTVItemID.TVType))
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceMikeSourceTVItemID, "MikeSource"), new[] { "MikeSourceTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceSourceNumberString), new[] { "SourceNumberString" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeSourceSourceNumberString, "50"), new[] { "SourceNumberString" });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceLastUpdateContactTVItemID, (mikeSource.LastUpdateContactTVItemID == null ? "" : mikeSource.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeSource GetMikeSourceWithMikeSourceID(int MikeSourceID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MikeSource> mikeSourceQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MikeSourceID == MikeSourceID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mikeSourceQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMikeSourceWeb(mikeSourceQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMikeSourceReport(mikeSourceQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MikeSource> GetMikeSourceList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MikeSource> mikeSourceQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mikeSourceQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMikeSourceWeb(mikeSourceQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMikeSourceReport(mikeSourceQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Add(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool Delete(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Delete);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Remove(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool Update(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Update(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public IQueryable<MikeSource> GetRead()
        {
            return db.MikeSources.AsNoTracking();
        }
        public IQueryable<MikeSource> GetEdit()
        {
            return db.MikeSources;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MikeSourceFillWeb
        private IQueryable<MikeSource> FillMikeSourceWeb(IQueryable<MikeSource> mikeSourceQuery, string FilterAndOrderText)
        {
            mikeSourceQuery = (from c in mikeSourceQuery
                let MikeSourceTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeSourceTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MikeSource
                    {
                        MikeSourceID = c.MikeSourceID,
                        MikeSourceTVItemID = c.MikeSourceTVItemID,
                        IsContinuous = c.IsContinuous,
                        Include = c.Include,
                        IsRiver = c.IsRiver,
                        SourceNumberString = c.SourceNumberString,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        MikeSourceWeb = new MikeSourceWeb
                        {
                            MikeSourceTVText = MikeSourceTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        MikeSourceReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mikeSourceQuery;
        }
        #endregion Functions private Generated MikeSourceFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MikeSource mikeSource)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
