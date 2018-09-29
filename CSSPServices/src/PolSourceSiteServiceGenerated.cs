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
    ///     <para>bonjour PolSourceSite</para>
    /// </summary>
    public partial class PolSourceSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceSite polSourceSite = validationContext.ObjectInstance as PolSourceSite;
            polSourceSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSite.PolSourceSiteID == 0)
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceSitePolSourceSiteID"), new[] { "PolSourceSiteID" });
                }

                if (!(from c in db.PolSourceSites select c).Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSitePolSourceSiteID", polSourceSite.PolSourceSiteID.ToString()), new[] { "PolSourceSiteID" });
                }
            }

            TVItem TVItemPolSourceSiteTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();

            if (TVItemPolSourceSiteTVItemID == null)
            {
                polSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSitePolSourceSiteTVItemID", polSourceSite.PolSourceSiteTVItemID.ToString()), new[] { "PolSourceSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteTVItemID.TVType))
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSitePolSourceSiteTVItemID", "PolSourceSite"), new[] { "PolSourceSiteTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSite.Temp_Locator_CanDelete) && polSourceSite.Temp_Locator_CanDelete.Length > 50)
            {
                polSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "PolSourceSiteTemp_Locator_CanDelete", "50"), new[] { "Temp_Locator_CanDelete" });
            }

            if (polSourceSite.Oldsiteid != null)
            {
                if (polSourceSite.Oldsiteid < 0 || polSourceSite.Oldsiteid > 1000)
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteOldsiteid", "0", "1000"), new[] { "Oldsiteid" });
                }
            }

            if (polSourceSite.Site != null)
            {
                if (polSourceSite.Site < 0 || polSourceSite.Site > 1000)
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSite", "0", "1000"), new[] { "Site" });
                }
            }

            if (polSourceSite.SiteID != null)
            {
                if (polSourceSite.SiteID < 0 || polSourceSite.SiteID > 1000)
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSiteID", "0", "1000"), new[] { "SiteID" });
                }
            }

            if (polSourceSite.InactiveReason != null)
            {
                retStr = enums.EnumTypeOK(typeof(PolSourceInactiveReasonEnum), (int?)polSourceSite.InactiveReason);
                if (polSourceSite.InactiveReason == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteInactiveReason"), new[] { "InactiveReason" });
                }
            }

            if (polSourceSite.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteCivicAddressTVItemID", (polSourceSite.CivicAddressTVItemID == null ? "" : polSourceSite.CivicAddressTVItemID.ToString())), new[] { "CivicAddressTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        polSourceSite.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSiteCivicAddressTVItemID", "Address"), new[] { "CivicAddressTVItemID" });
                    }
                }
            }

            if (polSourceSite.LastUpdateDate_UTC.Year == 1)
            {
                polSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceSite.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteLastUpdateContactTVItemID", polSourceSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceSite GetPolSourceSiteWithPolSourceSiteID(int PolSourceSiteID)
        {
            return (from c in db.PolSourceSites
                    where c.PolSourceSiteID == PolSourceSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceSite> GetPolSourceSiteList()
        {
            IQueryable<PolSourceSite> PolSourceSiteQuery = (from c in db.PolSourceSites select c);

            PolSourceSiteQuery = EnhanceQueryStatements<PolSourceSite>(PolSourceSiteQuery) as IQueryable<PolSourceSite>;

            return PolSourceSiteQuery;
        }
        public PolSourceSite_A GetPolSourceSite_AWithPolSourceSiteID(int PolSourceSiteID)
        {
            return FillPolSourceSite_A().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();

        }
        public IQueryable<PolSourceSite_A> GetPolSourceSite_AList()
        {
            IQueryable<PolSourceSite_A> PolSourceSite_AQuery = FillPolSourceSite_A();

            PolSourceSite_AQuery = EnhanceQueryStatements<PolSourceSite_A>(PolSourceSite_AQuery) as IQueryable<PolSourceSite_A>;

            return PolSourceSite_AQuery;
        }
        public PolSourceSite_B GetPolSourceSite_BWithPolSourceSiteID(int PolSourceSiteID)
        {
            return FillPolSourceSite_B().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();

        }
        public IQueryable<PolSourceSite_B> GetPolSourceSite_BList()
        {
            IQueryable<PolSourceSite_B> PolSourceSite_BQuery = FillPolSourceSite_B();

            PolSourceSite_BQuery = EnhanceQueryStatements<PolSourceSite_B>(PolSourceSite_BQuery) as IQueryable<PolSourceSite_B>;

            return PolSourceSite_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceSite polSourceSite)
        {
            polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Create);
            if (polSourceSite.ValidationResults.Count() > 0) return false;

            db.PolSourceSites.Add(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        public bool Delete(PolSourceSite polSourceSite)
        {
            polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Delete);
            if (polSourceSite.ValidationResults.Count() > 0) return false;

            db.PolSourceSites.Remove(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        public bool Update(PolSourceSite polSourceSite)
        {
            polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Update);
            if (polSourceSite.ValidationResults.Count() > 0) return false;

            db.PolSourceSites.Update(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceSite polSourceSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
