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
    public partial class LatLngService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LatLngService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            LatLng latLng = validationContext.ObjectInstance as LatLng;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //Lat is required but no testing needed as it is automatically set to 0.0f

            //Lng is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (latLng.Lat < -180f || latLng.Lat > 180f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LatLngLat, "-180f", "180f"), new[] { ModelsRes.LatLngLat });
            }

            if (latLng.Lng < -90f || latLng.Lng > 90f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LatLngLng, "-90f", "90f"), new[] { ModelsRes.LatLngLng });
            }


        }
        #endregion Validation

    }
}
