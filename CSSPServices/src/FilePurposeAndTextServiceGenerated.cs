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
    /// <summary>
    ///     <para>bonjour FilePurposeAndText</para>
    /// </summary>
    public partial class FilePurposeAndTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
            if (filePurposeAndText.FilePurpose == null || !string.IsNullOrWhiteSpace(retStr))
            {
                filePurposeAndText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FilePurposeAndTextFilePurpose"), new[] { "FilePurpose" });
            }

            if (!string.IsNullOrWhiteSpace(filePurposeAndText.FilePurposeText) && filePurposeAndText.FilePurposeText.Length > 100)
            {
                filePurposeAndText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "FilePurposeAndTextFilePurposeText", "100"), new[] { "FilePurposeText" });
            }

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
