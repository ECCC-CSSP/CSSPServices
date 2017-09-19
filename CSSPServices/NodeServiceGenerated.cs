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
    ///     <para>bonjour Node</para>
    /// </summary>
    public partial class NodeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public NodeService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Node node = validationContext.ObjectInstance as Node;
            node.HasErrors = false;

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (node.ID < 1 || node.ID > 1000000)
            {
                node.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.NodeID, "1", "1000000"), new[] { "ID" });
            }

            //X (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //X has no Range Attribute

            //Y (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Y has no Range Attribute

            //Z (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Z has no Range Attribute

            //Code (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Code has no Range Attribute

            //Value (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Value has no Range Attribute

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                node.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
