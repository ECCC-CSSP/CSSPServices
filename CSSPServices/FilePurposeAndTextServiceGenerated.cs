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
    public partial class FilePurposeAndTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FilePurposeAndText filePurposeAndText = validationContext.ObjectInstance as FilePurposeAndText;
            filePurposeAndText.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)filePurposeAndText.FilePurpose);
            if (filePurposeAndText.FilePurpose == FilePurposeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                filePurposeAndText.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.FilePurposeAndTextFilePurpose), new[] { "FilePurpose" });
            }

            if (!string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText) && filePurposeAndText.FilePurposeText.Length > 100)
            {
                filePurposeAndText.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.FilePurposeAndTextFilePurposeText, "100"), new[] { "FilePurposeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                filePurposeAndText.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
