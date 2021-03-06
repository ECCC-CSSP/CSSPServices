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
    public partial class PolSourceSiteEffectService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceSiteEffect polSourceSiteEffect = validationContext.ObjectInstance as PolSourceSiteEffect;
            polSourceSiteEffect.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceSiteEffect.PolSourceSiteEffectID == 0)
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteEffectID"), new[] { "PolSourceSiteEffectID" });
                }

                if (!(from c in db.PolSourceSiteEffects select c).Where(c => c.PolSourceSiteEffectID == polSourceSiteEffect.PolSourceSiteEffectID).Any())
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSiteEffect", "PolSourceSiteEffectID", polSourceSiteEffect.PolSourceSiteEffectID.ToString()), new[] { "PolSourceSiteEffectID" });
                }
            }

            TVItem TVItemPolSourceSiteOrInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemPolSourceSiteOrInfrastructureTVItemID == null)
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteOrInfrastructureTVItemID", polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID.ToString()), new[] { "PolSourceSiteOrInfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteOrInfrastructureTVItemID.TVType))
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSiteOrInfrastructureTVItemID", "Infrastructure,PolSourceSite"), new[] { "PolSourceSiteOrInfrastructureTVItemID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteTVItemID", polSourceSiteEffect.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(polSourceSiteEffect.PolSourceSiteEffectTermIDs) && polSourceSiteEffect.PolSourceSiteEffectTermIDs.Length > 250)
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "PolSourceSiteEffectTermIDs", "250"), new[] { "PolSourceSiteEffectTermIDs" });
            }

            //Comments has no StringLength Attribute

            if (polSourceSiteEffect.AnalysisDocumentTVItemID != null)
            {
                TVItem TVItemAnalysisDocumentTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.AnalysisDocumentTVItemID select c).FirstOrDefault();

                if (TVItemAnalysisDocumentTVItemID == null)
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AnalysisDocumentTVItemID", (polSourceSiteEffect.AnalysisDocumentTVItemID == null ? "" : polSourceSiteEffect.AnalysisDocumentTVItemID.ToString())), new[] { "AnalysisDocumentTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemAnalysisDocumentTVItemID.TVType))
                    {
                        polSourceSiteEffect.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AnalysisDocumentTVItemID", "File"), new[] { "AnalysisDocumentTVItemID" });
                    }
                }
            }

            if (polSourceSiteEffect.LastUpdateDate_UTC.Year == 1)
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceSiteEffect.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceSiteEffect.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceSiteEffect.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceSiteEffect.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceSiteEffect.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceSiteEffect GetPolSourceSiteEffectWithPolSourceSiteEffectID(int PolSourceSiteEffectID)
        {
            return (from c in db.PolSourceSiteEffects
                    where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceSiteEffect> GetPolSourceSiteEffectList()
        {
            IQueryable<PolSourceSiteEffect> PolSourceSiteEffectQuery = (from c in db.PolSourceSiteEffects select c);

            PolSourceSiteEffectQuery = EnhanceQueryStatements<PolSourceSiteEffect>(PolSourceSiteEffectQuery) as IQueryable<PolSourceSiteEffect>;

            return PolSourceSiteEffectQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceSiteEffect polSourceSiteEffect)
        {
            polSourceSiteEffect.ValidationResults = Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Create);
            if (polSourceSiteEffect.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffects.Add(polSourceSiteEffect);

            if (!TryToSave(polSourceSiteEffect)) return false;

            return true;
        }
        public bool Delete(PolSourceSiteEffect polSourceSiteEffect)
        {
            polSourceSiteEffect.ValidationResults = Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Delete);
            if (polSourceSiteEffect.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffects.Remove(polSourceSiteEffect);

            if (!TryToSave(polSourceSiteEffect)) return false;

            return true;
        }
        public bool Update(PolSourceSiteEffect polSourceSiteEffect)
        {
            polSourceSiteEffect.ValidationResults = Validate(new ValidationContext(polSourceSiteEffect), ActionDBTypeEnum.Update);
            if (polSourceSiteEffect.ValidationResults.Count() > 0) return false;

            db.PolSourceSiteEffects.Update(polSourceSiteEffect);

            if (!TryToSave(polSourceSiteEffect)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceSiteEffect polSourceSiteEffect)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceSiteEffect.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
