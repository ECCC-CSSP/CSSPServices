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
    public partial class CalDecayService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CalDecayService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CalDecay calDecay = validationContext.ObjectInstance as CalDecay;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //Decay is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(calDecay.Error) && (calDecay.Error.Length < 0) || (calDecay.Error.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CalDecayError, "0", "255"), new[] { ModelsRes.CalDecayError });
            }

            if (calDecay.Decay < 0D)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.CalDecayDecay, "0D"), new[] { ModelsRes.CalDecayDecay });
            }


        }
        #endregion Validation

    }
}
