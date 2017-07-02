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
    public partial class ElementService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ElementService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Element element = validationContext.ObjectInstance as Element;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ID is required but no testing needed as it is automatically set to 0

            //Type is required but no testing needed as it is automatically set to 0

            //NumbOfNodes is required but no testing needed as it is automatically set to 0

            //Value is required but no testing needed as it is automatically set to 0.0f

            //XNode0 is required but no testing needed as it is automatically set to 0.0f

            //YNode0 is required but no testing needed as it is automatically set to 0.0f

            //ZNode0 is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (element.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementID, "1"), new[] { ModelsRes.ElementID });
            }

            if (element.Type < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementType, "1"), new[] { ModelsRes.ElementType });
            }

            if (element.NumbOfNodes < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementNumbOfNodes, "1"), new[] { ModelsRes.ElementNumbOfNodes });
            }

            // Value no min or max length set
            // XNode0 no min or max length set
            // YNode0 no min or max length set
            // ZNode0 no min or max length set

        }
        #endregion Validation

    }
}
