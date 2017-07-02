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
    public partial class URLNumberOfSamplesService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            URLNumberOfSamples uRLNumberOfSamples = validationContext.ObjectInstance as URLNumberOfSamples;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (string.IsNullOrWhiteSpace(uRLNumberOfSamples.url))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.URLNumberOfSamplesurl), new[] { ModelsRes.URLNumberOfSamplesurl });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(uRLNumberOfSamples.url) && (uRLNumberOfSamples.url.Length < 1) || (uRLNumberOfSamples.url.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.URLNumberOfSamplesurl, "1", "255"), new[] { ModelsRes.URLNumberOfSamplesurl });
            }

            // NumberOfSamples no min or max length set

        }
        #endregion Validation

    }
}
