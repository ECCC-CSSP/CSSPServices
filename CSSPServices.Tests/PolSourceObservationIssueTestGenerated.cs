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
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 0;
            polSourceObservationIssueService.Update(polSourceObservationIssue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "PolSourceObservation", Plurial = "s", FieldID = "PolSourceObservationID", TVType = TVTypeEnum.Error)]
            // polSourceObservationIssue.PolSourceObservationID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationID = 0;
            polSourceObservationIssueService.Add(polSourceObservationIssue);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.PolSourceObservation, ModelsRes.PolSourceObservationIssuePolSourceObservationID, polSourceObservationIssue.PolSourceObservationID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // polSourceObservationIssue.ObservationInfo   (String)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
            Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationIssueObservationInfo)).Any());
            Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceObservationIssueObservationInfo, "250"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // polSourceObservationIssue.Ordinal   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = -1;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = 1001;
            Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 0;
            polSourceObservationIssueService.Add(polSourceObservationIssue);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 1;
            polSourceObservationIssueService.Add(polSourceObservationIssue);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "Contact"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceObservationIssue.PolSourceObservation   (PolSourceObservation)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // polSourceObservationIssue.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
