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
    public partial class CoordService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CoordService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Coord coord = validationContext.ObjectInstance as Coord;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //Lat is required but no testing needed as it is automatically set to 0.0f

            //Lng is required but no testing needed as it is automatically set to 0.0f

            //Ordinal is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (coord.Lat < -180f || coord.Lat > 180f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CoordLat, "-180f", "180f"), new[] { ModelsRes.CoordLat });
            }

            if (coord.Lng < -90f || coord.Lng > 90f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CoordLng, "-90f", "90f"), new[] { ModelsRes.CoordLng });
            }

            if (coord.Ordinal < 0 || coord.Ordinal > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CoordOrdinal, "0", "10000"), new[] { ModelsRes.CoordOrdinal });
            }


        }
        #endregion Validation

    }
}
