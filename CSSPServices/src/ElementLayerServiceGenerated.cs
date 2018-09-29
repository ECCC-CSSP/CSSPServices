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
    ///     <para>bonjour ElementLayer</para>
    /// </summary>
    public partial class ElementLayerService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ElementLayerService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ElementLayer elementLayer = validationContext.ObjectInstance as ElementLayer;
            elementLayer.HasErrors = false;

            if (elementLayer.Layer < 1 || elementLayer.Layer > 1000)
            {
                elementLayer.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ElementLayerLayer", "1", "1000"), new[] { "Layer" });
            }

            //ZMin has no Range Attribute

            //ZMax has no Range Attribute

                //Error: Type not implemented [Element] of type [Element]

                //Error: Type not implemented [Element] of type [Element]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                elementLayer.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
