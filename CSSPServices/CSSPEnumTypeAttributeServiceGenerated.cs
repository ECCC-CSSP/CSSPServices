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
    public partial class CSSPEnumTypeAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPEnumTypeAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            CSSPEnumTypeAttribute cSSPEnumTypeAttribute = validationContext.ObjectInstance as CSSPEnumTypeAttribute;

            if (string.IsNullOrWhiteSpace(cSSPEnumTypeAttribute.ErrorMessage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPEnumTypeAttributeErrorMessage), new[] { ModelsRes.CSSPEnumTypeAttributeErrorMessage });
            }

            // ErrorMessage has no validation

            if (string.IsNullOrWhiteSpace(cSSPEnumTypeAttribute.ErrorMessageResourceName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPEnumTypeAttributeErrorMessageResourceName), new[] { ModelsRes.CSSPEnumTypeAttributeErrorMessageResourceName });
            }

            // ErrorMessageResourceName has no validation

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPEnumTypeAttribute cSSPEnumTypeAttribute)
        {
            cSSPEnumTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPEnumTypeAttribute), ActionDBTypeEnum.Create);
            if (cSSPEnumTypeAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPEnumTypeAttributes.Add(cSSPEnumTypeAttribute);

            if (!TryToSave(cSSPEnumTypeAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPEnumTypeAttribute> cSSPEnumTypeAttributeList)
        {
            foreach (CSSPEnumTypeAttribute cSSPEnumTypeAttribute in cSSPEnumTypeAttributeList)
            {
                cSSPEnumTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPEnumTypeAttribute), ActionDBTypeEnum.Create);
                if (cSSPEnumTypeAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPEnumTypeAttributes.AddRange(cSSPEnumTypeAttributeList);

            if (!TryToSaveRange(cSSPEnumTypeAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPEnumTypeAttribute cSSPEnumTypeAttribute)
        {
            if (!db.CSSPEnumTypeAttributes.Where(c => c.CSSPEnumTypeAttributeID == cSSPEnumTypeAttribute.CSSPEnumTypeAttributeID).Any())
            {
                cSSPEnumTypeAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPEnumTypeAttribute", "CSSPEnumTypeAttributeID", cSSPEnumTypeAttribute.CSSPEnumTypeAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPEnumTypeAttributes.Remove(cSSPEnumTypeAttribute);

            if (!TryToSave(cSSPEnumTypeAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPEnumTypeAttribute> cSSPEnumTypeAttributeList)
        {
            foreach (CSSPEnumTypeAttribute cSSPEnumTypeAttribute in cSSPEnumTypeAttributeList)
            {
                if (!db.CSSPEnumTypeAttributes.Where(c => c.CSSPEnumTypeAttributeID == cSSPEnumTypeAttribute.CSSPEnumTypeAttributeID).Any())
                {
                    cSSPEnumTypeAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPEnumTypeAttribute", "CSSPEnumTypeAttributeID", cSSPEnumTypeAttribute.CSSPEnumTypeAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPEnumTypeAttributes.RemoveRange(cSSPEnumTypeAttributeList);

            if (!TryToSaveRange(cSSPEnumTypeAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPEnumTypeAttribute cSSPEnumTypeAttribute)
        {
            cSSPEnumTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPEnumTypeAttribute), ActionDBTypeEnum.Update);
            if (cSSPEnumTypeAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPEnumTypeAttributes.Update(cSSPEnumTypeAttribute);

            if (!TryToSave(cSSPEnumTypeAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPEnumTypeAttribute> cSSPEnumTypeAttributeList)
        {
            foreach (CSSPEnumTypeAttribute cSSPEnumTypeAttribute in cSSPEnumTypeAttributeList)
            {
                cSSPEnumTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPEnumTypeAttribute), ActionDBTypeEnum.Update);
                if (cSSPEnumTypeAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPEnumTypeAttributes.UpdateRange(cSSPEnumTypeAttributeList);

            if (!TryToSaveRange(cSSPEnumTypeAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPEnumTypeAttribute> GetRead()
        {
            return db.CSSPEnumTypeAttributes.AsNoTracking();
        }
        public IQueryable<CSSPEnumTypeAttribute> GetEdit()
        {
            return db.CSSPEnumTypeAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPEnumTypeAttribute cSSPEnumTypeAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPEnumTypeAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPEnumTypeAttribute> cSSPEnumTypeAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPEnumTypeAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
