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
    public partial class PolyPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolyPointService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            PolyPoint polyPoint = validationContext.ObjectInstance as PolyPoint;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //XCoord is required but no testing needed as it is automatically set to 0.0f

            //YCoord is required but no testing needed as it is automatically set to 0.0f

            //Z is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (polyPoint.XCoord < -180f || polyPoint.XCoord > 180f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolyPointXCoord, "-180f", "180f"), new[] { ModelsRes.PolyPointXCoord });
            }

            if (polyPoint.YCoord < -90f || polyPoint.YCoord > 90f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolyPointYCoord, "-90f", "90f"), new[] { ModelsRes.PolyPointYCoord });
            }

            // Z no min or max length set

        }
        #endregion Validation

    }
}
