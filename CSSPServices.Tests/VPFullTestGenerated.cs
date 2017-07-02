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
    public partial class VPFullTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int VPFullID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPFull GetFilledRandomVPFull(string OmitPropName)
        {
            VPFullID += 1;

            VPFull vpFull = new VPFull();

            if (OmitPropName != "VPScenarioID") vpFull.VPScenarioID = GetRandomInt(1, 5);
            if (OmitPropName != "InfrastructureTVItemID") vpFull.InfrastructureTVItemID = GetRandomInt(1, 5);
            if (OmitPropName != "VPScenarioStatus") vpFull.VPScenarioStatus = (CSSPEnums.ScenarioStatusEnum)GetRandomEnumType(typeof(CSSPEnums.ScenarioStatusEnum));
            if (OmitPropName != "UseAsBestEstimate") vpFull.UseAsBestEstimate = true;
            if (OmitPropName != "EffluentFlow_m3_s") vpFull.EffluentFlow_m3_s = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") vpFull.EffluentConcentration_MPN_100ml = GetRandomInt(1, 5);
            if (OmitPropName != "FroudeNumber") vpFull.FroudeNumber = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "PortDiameter_m") vpFull.PortDiameter_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "PortDepth_m") vpFull.PortDepth_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "PortElevation_m") vpFull.PortElevation_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "VerticalAngle_deg") vpFull.VerticalAngle_deg = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "HorizontalAngle_deg") vpFull.HorizontalAngle_deg = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "NumberOfPorts") vpFull.NumberOfPorts = GetRandomInt(1, 5);
            if (OmitPropName != "PortSpacing_m") vpFull.PortSpacing_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "AcuteMixZone_m") vpFull.AcuteMixZone_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "ChronicMixZone_m") vpFull.ChronicMixZone_m = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "EffluentSalinity_PSU") vpFull.EffluentSalinity_PSU = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "EffluentTemperature_C") vpFull.EffluentTemperature_C = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "EffluentVelocity_m_s") vpFull.EffluentVelocity_m_s = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "RawResults") vpFull.RawResults = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") vpFull.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpFull.LastUpdateContactTVItemID = GetRandomInt(1, 5);

            return vpFull;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPFull_Testing()
        {
            SetupTestHelper(culture);
            VPFullService vpFullService = new VPFullService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
