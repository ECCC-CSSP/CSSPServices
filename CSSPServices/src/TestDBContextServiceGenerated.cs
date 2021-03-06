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
    public partial class TestDBContextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TestDBContextService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TestDBContext testDBContext = validationContext.ObjectInstance as TestDBContext;
            testDBContext.HasErrors = false;

                //CSSPError: Type not implemented [Configuration] of type [IConfigurationRoot]

                //CSSPError: Type not implemented [Configuration] of type [IConfigurationRoot]
            if (string.IsNullOrWhiteSpace(testDBContext.Error))
            {
                testDBContext.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Error"), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                testDBContext.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TestDBContext testDBContext)
        {
            testDBContext.ValidationResults = Validate(new ValidationContext(testDBContext), ActionDBTypeEnum.Create);
            if (testDBContext.ValidationResults.Count() > 0) return false;

            db.TestDBContexts.Add(testDBContext);

            if (!TryToSave(testDBContext)) return false;

            return true;
        }
        public bool Delete(TestDBContext testDBContext)
        {
            testDBContext.ValidationResults = Validate(new ValidationContext(testDBContext), ActionDBTypeEnum.Delete);
            if (testDBContext.ValidationResults.Count() > 0) return false;

            db.TestDBContexts.Remove(testDBContext);

            if (!TryToSave(testDBContext)) return false;

            return true;
        }
        public bool Update(TestDBContext testDBContext)
        {
            testDBContext.ValidationResults = Validate(new ValidationContext(testDBContext), ActionDBTypeEnum.Update);
            if (testDBContext.ValidationResults.Count() > 0) return false;

            db.TestDBContexts.Update(testDBContext);

            if (!TryToSave(testDBContext)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(TestDBContext testDBContext)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                testDBContext.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
