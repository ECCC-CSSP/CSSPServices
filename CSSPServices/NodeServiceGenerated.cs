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

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (node.ID < 1 || node.ID > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.NodeID, "1", "1000000"), new[] { ModelsRes.NodeID });
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

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
