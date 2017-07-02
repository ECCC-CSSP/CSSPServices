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
        public FilePurposeAndTextService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            FilePurposeAndText filePurposeAndText = validationContext.ObjectInstance as FilePurposeAndText;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            retStr = enums.FilePurposeOK(filePurposeAndText.FilePurpose);
            if (filePurposeAndText.FilePurpose == FilePurposeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.FilePurposeAndTextFilePurpose), new[] { ModelsRes.FilePurposeAndTextFilePurpose });
            }

            if (string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.FilePurposeAndTextFilePurposeText), new[] { ModelsRes.FilePurposeAndTextFilePurposeText });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // FilePurpose no min or max length set
            if (!string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText) && (filePurposeAndText.FilePurposeText.Length < 1) || (filePurposeAndText.FilePurposeText.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.FilePurposeAndTextFilePurposeText, "1", "200"), new[] { ModelsRes.FilePurposeAndTextFilePurposeText });
            }


        }
        #endregion Validation

    }
}
