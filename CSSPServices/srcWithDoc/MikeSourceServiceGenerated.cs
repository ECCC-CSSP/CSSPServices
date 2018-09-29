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
        public MikeSourceService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceMikeSourceID"), new[] { "MikeSourceID" });
                }

                if (!(from c in db.MikeSources select c).Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceMikeSourceID", mikeSource.MikeSourceID.ToString()), new[] { "MikeSourceID" });
                }
            }

            TVItem TVItemMikeSourceTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceMikeSourceTVItemID", mikeSource.MikeSourceTVItemID.ToString()), new[] { "MikeSourceTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceMikeSourceTVItemID", "MikeSource"), new[] { "MikeSourceTVItemID" });
                }
            }

            if (mikeSource.HydrometricTVItemID != null)
            {
                TVItem TVItemHydrometricTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.HydrometricTVItemID select c).FirstOrDefault();

                if (TVItemHydrometricTVItemID == null)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceHydrometricTVItemID", (mikeSource.HydrometricTVItemID == null ? "" : mikeSource.HydrometricTVItemID.ToString())), new[] { "HydrometricTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.HydrometricSite,
                    };
                    if (!AllowableTVTypes.Contains(TVItemHydrometricTVItemID.TVType))
                    {
                        mikeSource.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceHydrometricTVItemID", "HydrometricSite"), new[] { "HydrometricTVItemID" });
                    }
                }
            }

            if (mikeSource.DrainageArea_km2 != null)
            {
                if (mikeSource.DrainageArea_km2 < 0 || mikeSource.DrainageArea_km2 > 1000000)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceDrainageArea_km2", "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (mikeSource.Factor != null)
            {
                if (mikeSource.Factor < 0 || mikeSource.Factor > 1000000)
                {
                    mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceFactor", "0", "1000000"), new[] { "Factor" });
                }
            }

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceSourceNumberString"), new[] { "SourceNumberString" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeSourceSourceNumberString", "50"), new[] { "SourceNumberString" });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSource.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeSourceLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSource.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceLastUpdateContactTVItemID", mikeSource.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public MikeSource GetMikeSourceWithMikeSourceID(int MikeSourceID)
        {
            return (from c in db.MikeSources
                    where c.MikeSourceID == MikeSourceID
                    select c).FirstOrDefault();

        }
        public IQueryable<MikeSource> GetMikeSourceList()
        {
            IQueryable<MikeSource> MikeSourceQuery = (from c in db.MikeSources select c);

            MikeSourceQuery = EnhanceQueryStatements<MikeSource>(MikeSourceQuery) as IQueryable<MikeSource>;

            return MikeSourceQuery;
        }
        public MikeSource_A GetMikeSource_AWithMikeSourceID(int MikeSourceID)
        {
            return FillMikeSource_A().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();

        }
        public IQueryable<MikeSource_A> GetMikeSource_AList()
        {
            IQueryable<MikeSource_A> MikeSource_AQuery = FillMikeSource_A();

            MikeSource_AQuery = EnhanceQueryStatements<MikeSource_A>(MikeSource_AQuery) as IQueryable<MikeSource_A>;

            return MikeSource_AQuery;
        }
        public MikeSource_B GetMikeSource_BWithMikeSourceID(int MikeSourceID)
        {
            return FillMikeSource_B().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();

        }
        public IQueryable<MikeSource_B> GetMikeSource_BList()
        {
            IQueryable<MikeSource_B> MikeSource_BQuery = FillMikeSource_B();

            MikeSource_BQuery = EnhanceQueryStatements<MikeSource_B>(MikeSource_BQuery) as IQueryable<MikeSource_B>;

            return MikeSource_BQuery;
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
        #endregion Functions public Generated CRUD

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
