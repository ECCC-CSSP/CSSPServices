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
    public partial class LabSheetAndA1SheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetAndA1SheetService labSheetAndA1SheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetServiceTest() : base()
        {
            //labSheetAndA1SheetService = new LabSheetAndA1SheetService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private LabSheetAndA1Sheet GetFilledRandomLabSheetAndA1Sheet(string OmitPropName)
        {
            LabSheetAndA1Sheet labSheetAndA1Sheet = new LabSheetAndA1Sheet();

            //CSSPError: property [LabSheet] and type [LabSheetAndA1Sheet] is  not implemented
            //CSSPError: property [LabSheetA1Sheet] and type [LabSheetAndA1Sheet] is  not implemented

            return labSheetAndA1Sheet;
        }
        #endregion Functions private
    }
}
