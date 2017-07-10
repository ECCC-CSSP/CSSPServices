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
    public partial class CSSPExistAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPExistAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            CSSPExistAttribute cSSPExistAttribute = validationContext.ObjectInstance as CSSPExistAttribute;

            if (string.IsNullOrWhiteSpace(cSSPExistAttribute.TypeName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPExistAttributeTypeName), new[] { ModelsRes.CSSPExistAttributeTypeName });
            }

            // TypeName has no validation

            if (string.IsNullOrWhiteSpace(cSSPExistAttribute.Plurial))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPExistAttributePlurial), new[] { ModelsRes.CSSPExistAttributePlurial });
            }

            // Plurial has no validation

            if (string.IsNullOrWhiteSpace(cSSPExistAttribute.FieldID))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPExistAttributeFieldID), new[] { ModelsRes.CSSPExistAttributeFieldID });
            }

            // FieldID has no validation

            if (string.IsNullOrWhiteSpace(cSSPExistAttribute.ErrorMessage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPExistAttributeErrorMessage), new[] { ModelsRes.CSSPExistAttributeErrorMessage });
            }

            // ErrorMessage has no validation

            if (string.IsNullOrWhiteSpace(cSSPExistAttribute.ErrorMessageResourceName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPExistAttributeErrorMessageResourceName), new[] { ModelsRes.CSSPExistAttributeErrorMessageResourceName });
            }

            // ErrorMessageResourceName has no validation

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPExistAttribute cSSPExistAttribute)
        {
            cSSPExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPExistAttribute), ActionDBTypeEnum.Create);
            if (cSSPExistAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPExistAttributes.Add(cSSPExistAttribute);

            if (!TryToSave(cSSPExistAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPExistAttribute> cSSPExistAttributeList)
        {
            foreach (CSSPExistAttribute cSSPExistAttribute in cSSPExistAttributeList)
            {
                cSSPExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPExistAttribute), ActionDBTypeEnum.Create);
                if (cSSPExistAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPExistAttributes.AddRange(cSSPExistAttributeList);

            if (!TryToSaveRange(cSSPExistAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPExistAttribute cSSPExistAttribute)
        {
            if (!db.CSSPExistAttributes.Where(c => c.CSSPExistAttributeID == cSSPExistAttribute.CSSPExistAttributeID).Any())
            {
                cSSPExistAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPExistAttribute", "CSSPExistAttributeID", cSSPExistAttribute.CSSPExistAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPExistAttributes.Remove(cSSPExistAttribute);

            if (!TryToSave(cSSPExistAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPExistAttribute> cSSPExistAttributeList)
        {
            foreach (CSSPExistAttribute cSSPExistAttribute in cSSPExistAttributeList)
            {
                if (!db.CSSPExistAttributes.Where(c => c.CSSPExistAttributeID == cSSPExistAttribute.CSSPExistAttributeID).Any())
                {
                    cSSPExistAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPExistAttribute", "CSSPExistAttributeID", cSSPExistAttribute.CSSPExistAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPExistAttributes.RemoveRange(cSSPExistAttributeList);

            if (!TryToSaveRange(cSSPExistAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPExistAttribute cSSPExistAttribute)
        {
            cSSPExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPExistAttribute), ActionDBTypeEnum.Update);
            if (cSSPExistAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPExistAttributes.Update(cSSPExistAttribute);

            if (!TryToSave(cSSPExistAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPExistAttribute> cSSPExistAttributeList)
        {
            foreach (CSSPExistAttribute cSSPExistAttribute in cSSPExistAttributeList)
            {
                cSSPExistAttribute.ValidationResults = Validate(new ValidationContext(cSSPExistAttribute), ActionDBTypeEnum.Update);
                if (cSSPExistAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPExistAttributes.UpdateRange(cSSPExistAttributeList);

            if (!TryToSaveRange(cSSPExistAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPExistAttribute> GetRead()
        {
            return db.CSSPExistAttributes.AsNoTracking();
        }
        public IQueryable<CSSPExistAttribute> GetEdit()
        {
            return db.CSSPExistAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPExistAttribute cSSPExistAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPExistAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPExistAttribute> cSSPExistAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPExistAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
