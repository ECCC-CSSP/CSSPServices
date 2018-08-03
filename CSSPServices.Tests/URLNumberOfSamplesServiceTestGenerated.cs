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
    public partial class URLNumberOfSamplesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private URLNumberOfSamplesService uRLNumberOfSamplesService { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesServiceTest() : base()
        {
            //uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private URLNumberOfSamples GetFilledRandomURLNumberOfSamples(string OmitPropName)
        {
            URLNumberOfSamples uRLNumberOfSamples = new URLNumberOfSamples();

            if (OmitPropName != "url") uRLNumberOfSamples.url = GetRandomString("", 6);
            // should implement a Range for the property NumberOfSamples and type URLNumberOfSamples

            return uRLNumberOfSamples;
        }
        #endregion Functions private
    }
}
