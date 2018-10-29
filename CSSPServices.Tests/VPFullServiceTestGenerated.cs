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
    public partial class VPFullServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPFullService vpFullService { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullServiceTest() : base()
        {
            //vpFullService = new VPFullService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private VPFull GetFilledRandomVPFull(string OmitPropName)
        {
            VPFull vpFull = new VPFull();

            //CSSPError: property [VPScenario] and type [VPFull] is  not implemented
            //CSSPError: property [VPAmbientList] and type [VPFull] is  not implemented
            //CSSPError: property [VPResultList] and type [VPFull] is  not implemented

            return vpFull;
        }
        #endregion Functions private
    }
}
