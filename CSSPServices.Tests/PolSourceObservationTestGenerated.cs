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
    public partial class PolSourceObservationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObservationService polSourceObservationService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationTest() : base()
        {
            polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObservation GetFilledRandomPolSourceObservation(string OmitPropName)
        {
            PolSourceObservation polSourceObservation = new PolSourceObservation();

            if (OmitPropName != "PolSourceSiteID") polSourceObservation.PolSourceSiteID = 1;
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = GetRandomDateTime();
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservation.LastUpdateContactTVItemID = 2;

            return polSourceObservation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObservation_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = polSourceObservationService.GetRead().Count();

            polSourceObservationService.Add(polSourceObservation);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, polSourceObservationService.GetRead().Where(c => c == polSourceObservation).Any());
            polSourceObservationService.Update(polSourceObservation);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, polSourceObservationService.GetRead().Count());
            polSourceObservationService.Delete(polSourceObservation);
            if (polSourceObservation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // polSourceObservation.PolSourceObservationID   (Int32)
            //-----------------------------------
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            polSourceObservation.PolSourceObservationID = 0;
            polSourceObservationService.Update(polSourceObservation);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationPolSourceObservationID), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "PolSourceSite", Plurial = "s", FieldID = "PolSourceSiteID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // polSourceObservation.PolSourceSiteID   (Int32)
            //-----------------------------------
            // PolSourceSiteID will automatically be initialized at 0 --> not null


            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // PolSourceSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.PolSourceSiteID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.PolSourceSiteID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // PolSourceSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.PolSourceSiteID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.PolSourceSiteID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // PolSourceSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.PolSourceSiteID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationPolSourceSiteID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.PolSourceSiteID);
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // polSourceObservation.ObservationDate_Local   (DateTime)
            //-----------------------------------
            // ObservationDate_Local will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // polSourceObservation.ContactTVItemID   (Int32)
            //-----------------------------------
            // ContactTVItemID will automatically be initialized at 0 --> not null


            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.ContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.ContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.ContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            // polSourceObservation.Observation_ToBeDeleted   (String)
            //-----------------------------------
            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservation_ToBeDeleted)).Any());
            Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());


            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // polSourceObservation.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // polSourceObservation.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // polSourceObservation.PolSourceObservationIssues   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // polSourceObservation.ContactTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // polSourceObservation.PolSourceSite   (PolSourceSite)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // polSourceObservation.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
