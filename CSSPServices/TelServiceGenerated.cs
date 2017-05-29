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
    public partial class TelService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TelService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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
            Tel tel = validationContext.ObjectInstance as Tel;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tel.TelID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelID), new[] { ModelsRes.TelTelID });
                }
            }

            //TelTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(tel.TelNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelNumber), new[] { ModelsRes.TelTelNumber });
            }

            retStr = enums.TelTypeOK(tel.TelType);
            if (tel.TelType == TelTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelType), new[] { ModelsRes.TelTelType });
            }

            if (tel.LastUpdateDate_UTC == null || tel.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelLastUpdateDate_UTC), new[] { ModelsRes.TelLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tel.TelTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TelTelTVItemID, "1"), new[] { ModelsRes.TelTelTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(tel.TelNumber) && tel.TelNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelNumber, "50"), new[] { ModelsRes.TelTelNumber });
            }

            if (tel.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TelLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TelLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(Tel tel)
        {
            tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Create);
            if (tel.ValidationResults.Count() > 0) return false;

            db.Tels.Add(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool AddRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Create);
                if (tel.ValidationResults.Count() > 0) return false;
            }

            db.Tels.AddRange(telList);

            if (!TryToSaveRange(telList)) return false;

            return true;
        }
        public bool Delete(Tel tel)
        {
            if (!db.Tels.Where(c => c.TelID == tel.TelID).Any())
            {
                tel.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Tels.Remove(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool DeleteRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                if (!db.Tels.Where(c => c.TelID == tel.TelID).Any())
                {
                    telList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Tels.RemoveRange(telList);

            if (!TryToSaveRange(telList)) return false;

            return true;
        }
        public bool Update(Tel tel)
        {
            tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Update);
            if (tel.ValidationResults.Count() > 0) return false;

            db.Tels.Update(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool UpdateRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Update);
                if (tel.ValidationResults.Count() > 0) return false;
            }
            db.Tels.UpdateRange(telList);

            if (!TryToSaveRange(telList)) return false;

            return true;
        }
        public IQueryable<Tel> GetRead()
        {
            return db.Tels.AsNoTracking();
        }
        public IQueryable<Tel> GetEdit()
        {
            return db.Tels;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(Tel tel)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tel.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<Tel> telList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                telList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
