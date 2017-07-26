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
        private PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueTest() : base()
        {
            polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            return polSourceObservationIssue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObservationIssue_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = polSourceObservationIssueService.GetRead().Count();

            polSourceObservationIssueService.Add(polSourceObservationIssue);
            if (polSourceObservationIssue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, polSourceObservationIssueService.GetRead().Where(c => c == polSourceObservationIssue).Any());
            polSourceObservationIssueService.Update(polSourceObservationIssue);
            if (polSourceObservationIssue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, polSourceObservationIssueService.GetRead().Count());
            polSourceObservationIssueService.Delete(polSourceObservationIssue);
            if (polSourceObservationIssue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
            //-----------------------------------
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 0;
            polSourceObservationIssueService.Update(polSourceObservationIssue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "PolSourceObservation", Plurial = "s", FieldID = "PolSourceObservationID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // polSourceObservationIssue.PolSourceObservationID   (Int32)
            //-----------------------------------
            // PolSourceObservationID will automatically be initialized at 0 --> not null


            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // PolSourceObservationID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservationIssue.PolSourceObservationID = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // PolSourceObservationID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservationIssue.PolSourceObservationID = 2;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // PolSourceObservationID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservationIssue.PolSourceObservationID = 0;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssuePolSourceObservationID, "1")).Any());
            Assert.AreEqual(0, polSourceObservationIssue.PolSourceObservationID);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(250))]
            // polSourceObservationIssue.ObservationInfo   (String)
            //-----------------------------------
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueObservationInfo)).Any());
            Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(0, polSourceObservationIssueService.GetRead().Count());


            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string polSourceObservationIssueObservationInfoMin = GetRandomString("", 250);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            polSourceObservationIssueObservationInfoMin = GetRandomString("", 249);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            // ObservationInfo has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            polSourceObservationIssueObservationInfoMin = GetRandomString("", 251);
            polSourceObservationIssue.ObservationInfo = polSourceObservationIssueObservationInfoMin;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObservationIssueObservationInfo, "250")).Any());
            Assert.AreEqual(polSourceObservationIssueObservationInfoMin, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // polSourceObservationIssue.Ordinal   (Int32)
            //-----------------------------------
            // Ordinal will automatically be initialized at 0 --> not null


            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            polSourceObservationIssue.Ordinal = 0;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(0, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            polSourceObservationIssue.Ordinal = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            polSourceObservationIssue.Ordinal = -1;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            polSourceObservationIssue.Ordinal = 1000;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1000, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            polSourceObservationIssue.Ordinal = 999;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(999, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            polSourceObservationIssue.Ordinal = 1001;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, polSourceObservationIssue.Ordinal);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservationIssue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservationIssue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(0, polSourceObservationIssue.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationIssueService.Delete(polSourceObservationIssue));
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservationIssue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservationIssue.LastUpdateContactTVItemID);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // polSourceObservationIssue.PolSourceObservation   (PolSourceObservation)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // polSourceObservationIssue.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
