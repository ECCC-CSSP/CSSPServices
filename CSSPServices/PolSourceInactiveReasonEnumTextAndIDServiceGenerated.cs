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
    public partial class PolSourceInactiveReasonEnumTextAndIDService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = validationContext.ObjectInstance as PolSourceInactiveReasonEnumTextAndID;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Text no min or max length set
            if (polSourceInactiveReasonEnumTextAndID.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceInactiveReasonEnumTextAndIDID, "1"), new[] { ModelsRes.PolSourceInactiveReasonEnumTextAndIDID });
            }


        }
        #endregion Validation

    }
}
