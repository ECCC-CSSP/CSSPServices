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
    public partial class CSSPDateAfterYearService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDateAfterYearService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPDateAfterYear cSSPDateAfterYear = validationContext.ObjectInstance as CSSPDateAfterYear;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Year no min or max length set
            // ErrorMessage no min or max length set
            // ErrorMessageResourceName no min or max length set
                ErrorMessageResourceType = GetRandomSomethingElse(),

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPDateAfterYear cSSPDateAfterYear)
        {
            cSSPDateAfterYear.ValidationResults = Validate(new ValidationContext(cSSPDateAfterYear), ActionDBTypeEnum.Create);
            if (cSSPDateAfterYear.ValidationResults.Count() > 0) return false;

            db.CSSPDateAfterYears.Add(cSSPDateAfterYear);

            if (!TryToSave(cSSPDateAfterYear)) return false;

            return true;
        }
        public bool AddRange(List<CSSPDateAfterYear> cSSPDateAfterYearList)
        {
            foreach (CSSPDateAfterYear cSSPDateAfterYear in cSSPDateAfterYearList)
            {
                cSSPDateAfterYear.ValidationResults = Validate(new ValidationContext(cSSPDateAfterYear), ActionDBTypeEnum.Create);
                if (cSSPDateAfterYear.ValidationResults.Count() > 0) return false;
            }

            db.CSSPDateAfterYears.AddRange(cSSPDateAfterYearList);

            if (!TryToSaveRange(cSSPDateAfterYearList)) return false;

            return true;
        }
        public bool Delete(CSSPDateAfterYear cSSPDateAfterYear)
        {
            if (!db.CSSPDateAfterYears.Where(c => c.CSSPDateAfterYearID == cSSPDateAfterYear.CSSPDateAfterYearID).Any())
            {
                cSSPDateAfterYear.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPDateAfterYear", "CSSPDateAfterYearID", cSSPDateAfterYear.CSSPDateAfterYearID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPDateAfterYears.Remove(cSSPDateAfterYear);

            if (!TryToSave(cSSPDateAfterYear)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPDateAfterYear> cSSPDateAfterYearList)
        {
            foreach (CSSPDateAfterYear cSSPDateAfterYear in cSSPDateAfterYearList)
            {
                if (!db.CSSPDateAfterYears.Where(c => c.CSSPDateAfterYearID == cSSPDateAfterYear.CSSPDateAfterYearID).Any())
                {
                    cSSPDateAfterYearList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPDateAfterYear", "CSSPDateAfterYearID", cSSPDateAfterYear.CSSPDateAfterYearID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPDateAfterYears.RemoveRange(cSSPDateAfterYearList);

            if (!TryToSaveRange(cSSPDateAfterYearList)) return false;

            return true;
        }
        public bool Update(CSSPDateAfterYear cSSPDateAfterYear)
        {
            cSSPDateAfterYear.ValidationResults = Validate(new ValidationContext(cSSPDateAfterYear), ActionDBTypeEnum.Update);
            if (cSSPDateAfterYear.ValidationResults.Count() > 0) return false;

            db.CSSPDateAfterYears.Update(cSSPDateAfterYear);

            if (!TryToSave(cSSPDateAfterYear)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPDateAfterYear> cSSPDateAfterYearList)
        {
            foreach (CSSPDateAfterYear cSSPDateAfterYear in cSSPDateAfterYearList)
            {
                cSSPDateAfterYear.ValidationResults = Validate(new ValidationContext(cSSPDateAfterYear), ActionDBTypeEnum.Update);
                if (cSSPDateAfterYear.ValidationResults.Count() > 0) return false;
            }
            db.CSSPDateAfterYears.UpdateRange(cSSPDateAfterYearList);

            if (!TryToSaveRange(cSSPDateAfterYearList)) return false;

            return true;
        }
        public IQueryable<CSSPDateAfterYear> GetRead()
        {
            return db.CSSPDateAfterYears.AsNoTracking();
        }
        public IQueryable<CSSPDateAfterYear> GetEdit()
        {
            return db.CSSPDateAfterYears;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPDateAfterYear cSSPDateAfterYear)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPDateAfterYear.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPDateAfterYear> cSSPDateAfterYearList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPDateAfterYearList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
