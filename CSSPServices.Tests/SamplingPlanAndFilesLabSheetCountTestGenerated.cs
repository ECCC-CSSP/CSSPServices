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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class SamplingPlanAndFilesLabSheetCountTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int SamplingPlanAndFilesLabSheetCountID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanAndFilesLabSheetCount GetFilledRandomSamplingPlanAndFilesLabSheetCount(string OmitPropName)
        {
            SamplingPlanAndFilesLabSheetCountID += 1;

            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = new SamplingPlanAndFilesLabSheetCount();

            if (OmitPropName != "LabSheetHistoryCount") samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = GetRandomInt(0, 10);
            if (OmitPropName != "LabSheetTransferredCount") samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = GetRandomInt(0, 10);

            return samplingPlanAndFilesLabSheetCount;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlanAndFilesLabSheetCount_Testing()
        {
            SetupTestHelper(culture);
            SamplingPlanAndFilesLabSheetCountService samplingPlanAndFilesLabSheetCountService = new SamplingPlanAndFilesLabSheetCountService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = GetFilledRandomSamplingPlanAndFilesLabSheetCount("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
