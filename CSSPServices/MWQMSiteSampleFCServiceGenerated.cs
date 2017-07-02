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
    public partial class MWQMSiteSampleFCService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MWQMSiteSampleFC mwqmSiteSampleFC = validationContext.ObjectInstance as MWQMSiteSampleFC;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

                //Error: Type not implemented [SampleDate] of type [System.DateTime]

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Error no min or max length set
            if (mwqmSiteSampleFC.FC != null && (mwqmSiteSampleFC.FC < 1 || mwqmSiteSampleFC.FC > 100000000))
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteSampleFCFC, "1", "100000000"), new[] { ModelsRes.MWQMSiteSampleFCFC });
            }

            // Sal no min or max length set
            // Temp no min or max length set
            // PH no min or max length set
            // DO no min or max length set
            // Depth no min or max length set
            // SampCount no min or max length set
            // MinFC no min or max length set
            // MaxFC no min or max length set
            // GeoMean no min or max length set
            // Median no min or max length set
            // P90 no min or max length set
            // PercOver43 no min or max length set
            // PercOver260 no min or max length set

        }
        #endregion Validation

    }
}
