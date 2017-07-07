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
    public partial class CSSPObjectExistAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPObjectExistAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPObjectExistAttribute cSSPObjectExistAttribute = validationContext.ObjectInstance as CSSPObjectExistAttribute;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // TableName no min or max length set
            // ErrorMessage no min or max length set
            // ErrorMessageResourceName no min or max length set
                ErrorMessageResourceType = GetRandomSomethingElse(),

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPObjectExistAttribute cSSPObjectExistAttribute)
        {
            cSSPObjectExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPObjectExistAttribute), ActionDBTypeEnum.Create);
            if (cSSPObjectExistAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPObjectExistAttributes.Add(cSSPObjectExistAttribute);

            if (!TryToSave(cSSPObjectExistAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPObjectExistAttribute> cSSPObjectExistAttributeList)
        {
            foreach (CSSPObjectExistAttribute cSSPObjectExistAttribute in cSSPObjectExistAttributeList)
            {
                cSSPObjectExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPObjectExistAttribute), ActionDBTypeEnum.Create);
                if (cSSPObjectExistAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPObjectExistAttributes.AddRange(cSSPObjectExistAttributeList);

            if (!TryToSaveRange(cSSPObjectExistAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPObjectExistAttribute cSSPObjectExistAttribute)
        {
            if (!db.CSSPObjectExistAttributes.Where(c => c.CSSPObjectExistAttributeID == cSSPObjectExistAttribute.CSSPObjectExistAttributeID).Any())
            {
                cSSPObjectExistAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPObjectExistAttribute", "CSSPObjectExistAttributeID", cSSPObjectExistAttribute.CSSPObjectExistAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPObjectExistAttributes.Remove(cSSPObjectExistAttribute);

            if (!TryToSave(cSSPObjectExistAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPObjectExistAttribute> cSSPObjectExistAttributeList)
        {
            foreach (CSSPObjectExistAttribute cSSPObjectExistAttribute in cSSPObjectExistAttributeList)
            {
                if (!db.CSSPObjectExistAttributes.Where(c => c.CSSPObjectExistAttributeID == cSSPObjectExistAttribute.CSSPObjectExistAttributeID).Any())
                {
                    cSSPObjectExistAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPObjectExistAttribute", "CSSPObjectExistAttributeID", cSSPObjectExistAttribute.CSSPObjectExistAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPObjectExistAttributes.RemoveRange(cSSPObjectExistAttributeList);

            if (!TryToSaveRange(cSSPObjectExistAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPObjectExistAttribute cSSPObjectExistAttribute)
        {
            cSSPObjectExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPObjectExistAttribute), ActionDBTypeEnum.Update);
            if (cSSPObjectExistAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPObjectExistAttributes.Update(cSSPObjectExistAttribute);

            if (!TryToSave(cSSPObjectExistAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPObjectExistAttribute> cSSPObjectExistAttributeList)
        {
            foreach (CSSPObjectExistAttribute cSSPObjectExistAttribute in cSSPObjectExistAttributeList)
            {
                cSSPObjectExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPObjectExistAttribute), ActionDBTypeEnum.Update);
                if (cSSPObjectExistAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPObjectExistAttributes.UpdateRange(cSSPObjectExistAttributeList);

            if (!TryToSaveRange(cSSPObjectExistAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPObjectExistAttribute> GetRead()
        {
            return db.CSSPObjectExistAttributes.AsNoTracking();
        }
        public IQueryable<CSSPObjectExistAttribute> GetEdit()
        {
            return db.CSSPObjectExistAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPObjectExistAttribute cSSPObjectExistAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPObjectExistAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPObjectExistAttribute> cSSPObjectExistAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPObjectExistAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
