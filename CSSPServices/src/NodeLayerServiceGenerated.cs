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
    ///     <para>bonjour NodeLayer</para>
    /// </summary>
    public partial class NodeLayerService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public NodeLayerService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            NodeLayer nodeLayer = validationContext.ObjectInstance as NodeLayer;
            nodeLayer.HasErrors = false;

            if (nodeLayer.Layer < 1 || nodeLayer.Layer > 100)
            {
                nodeLayer.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NodeLayerLayer", "1", "100"), new[] { "Layer" });
            }

            //Z has no Range Attribute

                //Error: Type not implemented [Node] of type [Node]

                //Error: Type not implemented [Node] of type [Node]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                nodeLayer.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
