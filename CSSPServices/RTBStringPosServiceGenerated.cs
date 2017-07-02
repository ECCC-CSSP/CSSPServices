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
    public partial class RTBStringPosService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RTBStringPosService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            RTBStringPos rTBStringPos = validationContext.ObjectInstance as RTBStringPos;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //StartPos is required but no testing needed as it is automatically set to 0

            //EndPos is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (rTBStringPos.StartPos < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RTBStringPosStartPos, "0"), new[] { ModelsRes.RTBStringPosStartPos });
            }

            if (rTBStringPos.EndPos < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RTBStringPosEndPos, "0"), new[] { ModelsRes.RTBStringPosEndPos });
            }

            // Text no min or max length set
            // TagText no min or max length set

        }
        #endregion Validation

    }
}
