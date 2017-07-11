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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNMWQMLookupMPNID), new[] { ModelsRes.MWQMLookupMPNMWQMLookupMPNID });
                }
            }

            //MWQMLookupMPNID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Tubes10 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes10 });
            }

            //Tubes1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes1 });
            }

            //Tubes01 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes01 });
            }

            //MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), new[] { ModelsRes.MWQMLookupMPNMPN_100ml });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC), new[] { ModelsRes.MWQMLookupMPNLastUpdateDate_UTC });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMLookupMPNLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Add(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool AddRange(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
            foreach (MWQMLookupMPN mwqmLookupMPN in mwqmLookupMPNList)
            {
                mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
                if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;
            }

            db.MWQMLookupMPNs.AddRange(mwqmLookupMPNList);

            if (!TryToSaveRange(mwqmLookupMPNList)) return false;

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
        public bool DeleteRange(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
            foreach (MWQMLookupMPN mwqmLookupMPN in mwqmLookupMPNList)
            {
                if (!db.MWQMLookupMPNs.Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
                {
                    mwqmLookupMPNList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMLookupMPNs.RemoveRange(mwqmLookupMPNList);

            if (!TryToSaveRange(mwqmLookupMPNList)) return false;

            return true;
        }
        public bool Update(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Update(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
            foreach (MWQMLookupMPN mwqmLookupMPN in mwqmLookupMPNList)
            {
                mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
                if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;
            }
            db.MWQMLookupMPNs.UpdateRange(mwqmLookupMPNList);

            if (!TryToSaveRange(mwqmLookupMPNList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmLookupMPNList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
