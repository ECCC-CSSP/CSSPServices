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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanAndFilesLabSheetCount GetFilledRandomSamplingPlanAndFilesLabSheetCount(string OmitPropName)
        {
            SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = new SamplingPlanAndFilesLabSheetCount();

            if (OmitPropName != "LabSheetHistoryCount") samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = GetRandomInt(0, 10);
            if (OmitPropName != "LabSheetTransferredCount") samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = GetRandomInt(0, 10);
            if (OmitPropName != "HasErrors") samplingPlanAndFilesLabSheetCount.HasErrors = true;

            return samplingPlanAndFilesLabSheetCount;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanAndFilesLabSheetCount_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanAndFilesLabSheetCountService samplingPlanAndFilesLabSheetCountService = new SamplingPlanAndFilesLabSheetCountService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount = GetFilledRandomSamplingPlanAndFilesLabSheetCount("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
