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
        public NodeLayerService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //Layer (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (nodeLayer.Layer < 1 || nodeLayer.Layer > 100)
            {
                nodeLayer.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.NodeLayerLayer, "1", "100"), new[] { "Layer" });
            }

            //Z (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Z has no Range Attribute

            //HasErrors (bool) is required but no testing needed 

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
