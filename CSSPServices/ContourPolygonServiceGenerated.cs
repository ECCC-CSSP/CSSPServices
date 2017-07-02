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
    public partial class ContourPolygonService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContourPolygonService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ContourPolygon contourPolygon = validationContext.ObjectInstance as ContourPolygon;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ContourValue is required but no testing needed as it is automatically set to 0.0f

            //Layer is required but no testing needed as it is automatically set to 0

            //Depth is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contourPolygon.ContourValue < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContourPolygonContourValue, "0f"), new[] { ModelsRes.ContourPolygonContourValue });
            }

            if (contourPolygon.Layer < 1 || contourPolygon.Layer > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContourPolygonLayer, "1", "100"), new[] { ModelsRes.ContourPolygonLayer });
            }

            if (contourPolygon.Depth < 1f || contourPolygon.Depth > 10000f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContourPolygonDepth, "1f", "10000f"), new[] { ModelsRes.ContourPolygonDepth });
            }


        }
        #endregion Validation

    }
}
