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
    public partial class VPResValuesService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResValuesService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            VPResValues vpResValues = validationContext.ObjectInstance as VPResValues;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //Conc is required but no testing needed as it is automatically set to 0

            //Dilu is required but no testing needed as it is automatically set to 0.0f

            //FarfieldWidth is required but no testing needed as it is automatically set to 0.0f

            //Distance is required but no testing needed as it is automatically set to 0.0f

            //TheTime is required but no testing needed as it is automatically set to 0.0f

            //Decay is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (vpResValues.Conc < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResValuesConc, "0"), new[] { ModelsRes.VPResValuesConc });
            }

            // Dilu no min or max length set
            // FarfieldWidth no min or max length set
            // Distance no min or max length set
            // TheTime no min or max length set
            // Decay no min or max length set

        }
        #endregion Validation

    }
}
