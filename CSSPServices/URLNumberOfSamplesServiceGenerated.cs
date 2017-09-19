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
    ///     <para>bonjour URLNumberOfSamples</para>
    /// </summary>
    public partial class URLNumberOfSamplesService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            URLNumberOfSamples uRLNumberOfSamples = validationContext.ObjectInstance as URLNumberOfSamples;
            uRLNumberOfSamples.HasErrors = false;

            if (string.IsNullOrWhiteSpace(uRLNumberOfSamples.url))
            {
                uRLNumberOfSamples.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.URLNumberOfSamplesurl), new[] { "url" });
            }

            if (!string.IsNullOrWhiteSpace(uRLNumberOfSamples.url) && (uRLNumberOfSamples.url.Length < 1 || uRLNumberOfSamples.url.Length > 255))
            {
                uRLNumberOfSamples.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.URLNumberOfSamplesurl, "1", "255"), new[] { "url" });
            }

            //NumberOfSamples (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //NumberOfSamples has no Range Attribute

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                uRLNumberOfSamples.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
