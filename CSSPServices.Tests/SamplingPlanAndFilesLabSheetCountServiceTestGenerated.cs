using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class SamplingPlanAndFilesLabSheetCountServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanAndFilesLabSheetCountService samplingPlanAndFilesLabSheetCountService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountServiceTest() : base()
        {
            //samplingPlanAndFilesLabSheetCountService = new SamplingPlanAndFilesLabSheetCountService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private SamplingPlanAndFilesLabSheetCount GetFilledRandomSamplingPlanAndFilesLabSheetCount(string OmitPropName)
        {
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = new SamplingPlanAndFilesLabSheetCount();

            if (OmitPropName != "LabSheetHistoryCount") samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = GetRandomInt(0, 10);
            if (OmitPropName != "LabSheetTransferredCount") samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = GetRandomInt(0, 10);
            //Error: property [SamplingPlan] and type [SamplingPlanAndFilesLabSheetCount] is  not implemented
            //Error: property [TVFileSamplingPlanFileTXT] and type [SamplingPlanAndFilesLabSheetCount] is  not implemented

            return samplingPlanAndFilesLabSheetCount;
        }
        #endregion Functions private
    }
}
