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
    public partial class PolSourceObservationIssueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int PolSourceObservationIssueID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssueID += 1;

            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationIssueID") polSourceObservationIssue.PolSourceObservationIssueID = PolSourceObservationIssueID;
            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = GetRandomInt(1, 11);
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return polSourceObservationIssue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObservationIssue_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(true, polSourceObservationIssueService.GetRead().Where(c => c == polSourceObservationIssue).Any());
            polSourceObservationIssue.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, polSourceObservationIssueService.Update(polSourceObservationIssue));
            Assert.AreEqual(1, polSourceObservationIssueService.GetRead().Count());
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // PolSourceObservationID will automatically be initialized at 0 --> not null

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueObservationInfo)).Any());
            Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            // Ordinal will automatically be initialized at 0 --> not null

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("LastUpdateDate_UTC");
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(polSourceObservationIssue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [PolSourceObservationIssueID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceObservationID] of type [int]
            //-----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // PolSourceObservationID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservationIssue.PolSourceObservationID = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // PolSourceObservationID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservationIssue.PolSourceObservationID = 2;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // PolSourceObservationID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservationIssue.PolSourceObservationID = 0;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssuePolSourceObservationID, "1")).Any());
            Assert.AreEqual(0, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            // doing property [ObservationInfo] of type [string]
            //-----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string polSourceObservationIssueObservationInfoMin = GetRandomString("", 250);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            polSourceObservationIssueObservationInfoMin = GetRandomString("", 249);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            polSourceObservationIssueObservationInfoMin = GetRandomString("", 251);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObservationIssueObservationInfo, "250")).Any());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            // doing property [Ordinal] of type [int]
            //-----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            polSourceObservationIssue.Ordinal = 0;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(0, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            polSourceObservationIssue.Ordinal = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            polSourceObservationIssue.Ordinal = -1;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            polSourceObservationIssue.Ordinal = 1000;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1000, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            polSourceObservationIssue.Ordinal = 999;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(999, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            polSourceObservationIssue.Ordinal = 1001;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservationIssue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservationIssue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservationIssue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
