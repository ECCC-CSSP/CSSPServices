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
    /// <summary>
    ///     <para>bonjour VPResValues</para>
    /// </summary>
    public partial class VPResValuesService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResValuesService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResValues vpResValues = validationContext.ObjectInstance as VPResValues;
            vpResValues.HasErrors = false;

            if (vpResValues.Conc < 0)
            {
                vpResValues.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "VPResValuesConc", "0"), new[] { "Conc" });
            }

            //Dilu has no Range Attribute

            //FarfieldWidth has no Range Attribute

            //Distance has no Range Attribute

            //TheTime has no Range Attribute

            //Decay has no Range Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpResValues.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}