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
    public partial class SamplingPlanAndFilesLabSheetCountService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = validationContext.ObjectInstance as SamplingPlanAndFilesLabSheetCount;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount != null && samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount, "0"), new[] { ModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount });
            }

            if (samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount != null && samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount, "0"), new[] { ModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount });
            }


        }
        #endregion Validation

    }
}
