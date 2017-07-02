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
        public NodeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Node node = validationContext.ObjectInstance as Node;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ID is required but no testing needed as it is automatically set to 0

            //X is required but no testing needed as it is automatically set to 0.0f

            //Y is required but no testing needed as it is automatically set to 0.0f

            //Z is required but no testing needed as it is automatically set to 0.0f

            //Code is required but no testing needed as it is automatically set to 0

            //Value is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (node.ID < 1 || node.ID > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.NodeID, "1", "1000000"), new[] { ModelsRes.NodeID });
            }

            // X no min or max length set
            // Y no min or max length set
            // Z no min or max length set
            // Code no min or max length set
            // Value no min or max length set

        }
        #endregion Validation

    }
}
