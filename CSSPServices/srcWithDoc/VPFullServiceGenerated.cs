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
    ///     <para>bonjour VPFull</para>
    /// </summary>
    public partial class VPFullService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPFullService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPFull vpFull = validationContext.ObjectInstance as VPFull;
            vpFull.HasErrors = false;

                //Error: Type not implemented [VPScenario] of type [VPScenario]

                //Error: Type not implemented [VPScenario] of type [VPScenario]
                //Error: Type not implemented [VPAmbientList] of type [List`1]

                //Error: Type not implemented [VPAmbientList] of type [VPAmbient]
                //Error: Type not implemented [VPResultList] of type [List`1]

                //Error: Type not implemented [VPResultList] of type [VPResult]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpFull.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
