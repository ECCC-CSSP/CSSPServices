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
    ///     <para>bonjour SamplingPlanAndFilesLabSheetCount</para>
    /// </summary>
    public partial class SamplingPlanAndFilesLabSheetCountService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = validationContext.ObjectInstance as SamplingPlanAndFilesLabSheetCount;
            samplingPlanAndFilesLabSheetCount.HasErrors = false;

            if (samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount < 0)
            {
                samplingPlanAndFilesLabSheetCount.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount", "0"), new[] { "LabSheetHistoryCount" });
            }

            if (samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount < 0)
            {
                samplingPlanAndFilesLabSheetCount.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount", "0"), new[] { "LabSheetTransferredCount" });
            }

                //Error: Type not implemented [SamplingPlan] of type [SamplingPlan]

                //Error: Type not implemented [SamplingPlan] of type [SamplingPlan]
                //Error: Type not implemented [TVFileSamplingPlanFileTXT] of type [TVFile]

                //Error: Type not implemented [TVFileSamplingPlanFileTXT] of type [TVFile]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlanAndFilesLabSheetCount.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}