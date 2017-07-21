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
    public partial class ElementService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ElementService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Element element = validationContext.ObjectInstance as Element;

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementID, "1"), new[] { ModelsRes.ElementID });
            }

            //Type (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.Type < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementType, "1"), new[] { ModelsRes.ElementType });
            }

            //NumbOfNodes (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (element.NumbOfNodes < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ElementNumbOfNodes, "1"), new[] { ModelsRes.ElementNumbOfNodes });
            }

            //Value (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Value has no Range Attribute

            //XNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //XNode0 has no Range Attribute

            //YNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //YNode0 has no Range Attribute

            //ZNode0 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ZNode0 has no Range Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
