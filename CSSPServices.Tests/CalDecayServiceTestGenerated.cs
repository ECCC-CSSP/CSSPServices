 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class CalDecayServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private CalDecayService calDecayService { get; set; }
        #endregion Properties

        #region Constructors
        public CalDecayServiceTest() : base()
        {
            //calDecayService = new CalDecayService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private CalDecay GetFilledRandomCalDecay(string OmitPropName)
        {
            CalDecay calDecay = new CalDecay();

            if (OmitPropName != "Decay") calDecay.Decay = GetRandomDouble(0.0D, 10.0D);

            return calDecay;
        }
        #endregion Functions private
    }
}
