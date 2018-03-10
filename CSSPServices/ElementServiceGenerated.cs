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
        public ElementService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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

            if (element.ID < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementID, "1"), new[] { "ID" });
            }

            if (element.Type < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementType, "1"), new[] { "Type" });
            }

            if (element.NumbOfNodes < 1)
            {
                element.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ElementNumbOfNodes, "1"), new[] { "NumbOfNodes" });
            }

            //Value has no Range Attribute

            //XNode0 has no Range Attribute

            //YNode0 has no Range Attribute

            //ZNode0 has no Range Attribute

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
