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
    public partial class OtherFilesToUploadService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            OtherFilesToUpload otherFilesToUpload = validationContext.ObjectInstance as OtherFilesToUpload;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //MikeScenarioID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Error no min or max length set
            if (otherFilesToUpload.MikeScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.OtherFilesToUploadMikeScenarioID, "1"), new[] { ModelsRes.OtherFilesToUploadMikeScenarioID });
            }


        }
        #endregion Validation

    }
}
