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
    ///     <para>bonjour Element</para>
    /// </summary>
    public partial class ElementService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ElementService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Element element = validationContext.ObjectInstance as Element;
            element.HasErrors = false;

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.ID < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementID, "1"), new[] { "ID" });
            }

            //Type (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.Type < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementType, "1"), new[] { "Type" });
            }

            //NumbOfNodes (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.NumbOfNodes < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementNumbOfNodes, "1"), new[] { "NumbOfNodes" });
            }

            //Value (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Value has no Range Attribute

            //XNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //XNode0 has no Range Attribute

            //YNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //YNode0 has no Range Attribute

            //ZNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ZNode0 has no Range Attribute

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                element.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
