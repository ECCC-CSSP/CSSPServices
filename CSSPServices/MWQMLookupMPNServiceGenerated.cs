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
    public partial class MWQMLookupMPNService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMLookupMPN mwqmLookupMPN = validationContext.ObjectInstance as MWQMLookupMPN;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmLookupMPN.MWQMLookupMPNID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNMWQMLookupMPNID), new[] { "MWQMLookupMPNID" });
                }
            }

            //MWQMLookupMPNID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Tubes10 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5"), new[] { "Tubes10" });
            }

            //Tubes1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5"), new[] { "Tubes1" });
            }

            //Tubes01 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5"), new[] { "Tubes01" });
            }

            //MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), new[] { "MPN_100ml" });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmLookupMPN.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmLookupMPN.LastUpdateContactTVText) && mwqmLookupMPN.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMLookupMPNLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNID(int MWQMLookupMPNID)
        {
            IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery = (from c in GetRead()
                                                where c.MWQMLookupMPNID == MWQMLookupMPNID
                                                select c);

            return FillMWQMLookupMPN(mwqmLookupMPNQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Add(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Delete(MWQMLookupMPN mwqmLookupMPN)
        {
            if (!db.MWQMLookupMPNs.Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMLookupMPNs.Remove(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Update(MWQMLookupMPN mwqmLookupMPN)
        {
            if (!db.MWQMLookupMPNs.Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString())) }.AsEnumerable();
                return false;
            }

            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Update(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public IQueryable<MWQMLookupMPN> GetRead()
        {
            return db.MWQMLookupMPNs.AsNoTracking();
        }
        public IQueryable<MWQMLookupMPN> GetEdit()
        {
            return db.MWQMLookupMPNs;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMLookupMPN> FillMWQMLookupMPN(IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery)
        {
            List<MWQMLookupMPN> MWQMLookupMPNList = (from c in mwqmLookupMPNQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMLookupMPN
                                         {
                                             MWQMLookupMPNID = c.MWQMLookupMPNID,
                                             Tubes10 = c.Tubes10,
                                             Tubes1 = c.Tubes1,
                                             Tubes01 = c.Tubes01,
                                             MPN_100ml = c.MPN_100ml,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return MWQMLookupMPNList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMLookupMPN mwqmLookupMPN)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
