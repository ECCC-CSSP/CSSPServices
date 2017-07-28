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
        public VPResValuesService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResValues vpResValues = validationContext.ObjectInstance as VPResValues;

            //Conc (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpResValues.Conc < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResValuesConc, "0"), new[] { "Conc" });
            }

            //Dilu (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Dilu has no Range Attribute

            //FarfieldWidth (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FarfieldWidth has no Range Attribute

            //Distance (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Distance has no Range Attribute

            //TheTime (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TheTime has no Range Attribute

            //Decay (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Decay has no Range Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
