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
    ///     <para>bonjour InputSummary</para>
    /// </summary>
    public partial class InputSummaryService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InputSummaryService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            InputSummary inputSummary = validationContext.ObjectInstance as InputSummary;
            inputSummary.HasErrors = false;

            if (string.IsNullOrWhiteSpace(inputSummary.Error))
            {
                inputSummary.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InputSummaryError"), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(inputSummary.Summary))
            {
                inputSummary.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InputSummarySummary"), new[] { "Summary" });
            }

            //Summary has no StringLength Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                inputSummary.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
