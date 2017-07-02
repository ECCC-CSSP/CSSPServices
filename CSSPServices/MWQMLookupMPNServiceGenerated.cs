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
            MWQMLookupMPN mwqmLookupMPN = validationContext.ObjectInstance as MWQMLookupMPN;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmLookupMPN.MWQMLookupMPNID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNMWQMLookupMPNID), new[] { ModelsRes.MWQMLookupMPNMWQMLookupMPNID });
                }
            }

            //Tubes10 (int) is required but no testing needed as it is automatically set to 0

            //Tubes1 (int) is required but no testing needed as it is automatically set to 0

            //Tubes01 (int) is required but no testing needed as it is automatically set to 0

            //MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            if (mwqmLookupMPN.LastUpdateDate_UTC == null || mwqmLookupMPN.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC), new[] { ModelsRes.MWQMLookupMPNLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes10 });
            }

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes1 });
            }

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5"), new[] { ModelsRes.MWQMLookupMPNTubes01 });
            }

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 1700)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "1700"), new[] { ModelsRes.MWQMLookupMPNMPN_100ml });
            }

            if (mwqmLookupMPN.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID });
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
