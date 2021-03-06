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
    public partial class DataPathOfTideServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private DataPathOfTideService dataPathOfTideService { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideServiceTest() : base()
        {
            //dataPathOfTideService = new DataPathOfTideService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private DataPathOfTide GetFilledRandomDataPathOfTide(string OmitPropName)
        {
            DataPathOfTide dataPathOfTide = new DataPathOfTide();

            if (OmitPropName != "Text") dataPathOfTide.Text = GetRandomString("", 6);
            if (OmitPropName != "WebTideDataSet") dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "WebTideDataSetText") dataPathOfTide.WebTideDataSetText = GetRandomString("", 5);

            return dataPathOfTide;
        }
        #endregion Functions private
    }
}
