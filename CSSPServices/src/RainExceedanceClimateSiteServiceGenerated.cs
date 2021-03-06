/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class RainExceedanceClimateSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RainExceedanceClimateSite rainExceedanceClimateSite = validationContext.ObjectInstance as RainExceedanceClimateSite;
            rainExceedanceClimateSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (rainExceedanceClimateSite.RainExceedanceClimateSiteID == 0)
                {
                    rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceClimateSiteID"), new[] { "RainExceedanceClimateSiteID" });
                }

                if (!(from c in db.RainExceedanceClimateSites select c).Where(c => c.RainExceedanceClimateSiteID == rainExceedanceClimateSite.RainExceedanceClimateSiteID).Any())
                {
                    rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RainExceedanceClimateSite", "RainExceedanceClimateSiteID", rainExceedanceClimateSite.RainExceedanceClimateSiteID.ToString()), new[] { "RainExceedanceClimateSiteID" });
                }
            }

            TVItem TVItemRainExceedanceTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedanceClimateSite.RainExceedanceTVItemID select c).FirstOrDefault();

            if (TVItemRainExceedanceTVItemID == null)
            {
                rainExceedanceClimateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RainExceedanceTVItemID", rainExceedanceClimateSite.RainExceedanceTVItemID.ToString()), new[] { "RainExceedanceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.RainExceedance,
                };
                if (!AllowableTVTypes.Contains(TVItemRainExceedanceTVItemID.TVType))
                {
                    rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "RainExceedanceTVItemID", "RainExceedance"), new[] { "RainExceedanceTVItemID" });
                }
            }

            TVItem TVItemClimateSiteTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedanceClimateSite.ClimateSiteTVItemID select c).FirstOrDefault();

            if (TVItemClimateSiteTVItemID == null)
            {
                rainExceedanceClimateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ClimateSiteTVItemID", rainExceedanceClimateSite.ClimateSiteTVItemID.ToString()), new[] { "ClimateSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                };
                if (!AllowableTVTypes.Contains(TVItemClimateSiteTVItemID.TVType))
                {
                    rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ClimateSiteTVItemID", "ClimateSite"), new[] { "ClimateSiteTVItemID" });
                }
            }

            if (rainExceedanceClimateSite.LastUpdateDate_UTC.Year == 1)
            {
                rainExceedanceClimateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (rainExceedanceClimateSite.LastUpdateDate_UTC.Year < 1980)
                {
                rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedanceClimateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                rainExceedanceClimateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", rainExceedanceClimateSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    rainExceedanceClimateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                rainExceedanceClimateSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RainExceedanceClimateSite GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(int RainExceedanceClimateSiteID)
        {
            return (from c in db.RainExceedanceClimateSites
                    where c.RainExceedanceClimateSiteID == RainExceedanceClimateSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<RainExceedanceClimateSite> GetRainExceedanceClimateSiteList()
        {
            IQueryable<RainExceedanceClimateSite> RainExceedanceClimateSiteQuery = (from c in db.RainExceedanceClimateSites select c);

            RainExceedanceClimateSiteQuery = EnhanceQueryStatements<RainExceedanceClimateSite>(RainExceedanceClimateSiteQuery) as IQueryable<RainExceedanceClimateSite>;

            return RainExceedanceClimateSiteQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            rainExceedanceClimateSite.ValidationResults = Validate(new ValidationContext(rainExceedanceClimateSite), ActionDBTypeEnum.Create);
            if (rainExceedanceClimateSite.ValidationResults.Count() > 0) return false;

            db.RainExceedanceClimateSites.Add(rainExceedanceClimateSite);

            if (!TryToSave(rainExceedanceClimateSite)) return false;

            return true;
        }
        public bool Delete(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            rainExceedanceClimateSite.ValidationResults = Validate(new ValidationContext(rainExceedanceClimateSite), ActionDBTypeEnum.Delete);
            if (rainExceedanceClimateSite.ValidationResults.Count() > 0) return false;

            db.RainExceedanceClimateSites.Remove(rainExceedanceClimateSite);

            if (!TryToSave(rainExceedanceClimateSite)) return false;

            return true;
        }
        public bool Update(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            rainExceedanceClimateSite.ValidationResults = Validate(new ValidationContext(rainExceedanceClimateSite), ActionDBTypeEnum.Update);
            if (rainExceedanceClimateSite.ValidationResults.Count() > 0) return false;

            db.RainExceedanceClimateSites.Update(rainExceedanceClimateSite);

            if (!TryToSave(rainExceedanceClimateSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(RainExceedanceClimateSite rainExceedanceClimateSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                rainExceedanceClimateSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
