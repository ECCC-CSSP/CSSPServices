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
        private int PolSourceObservationID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObservation GetFilledRandomPolSourceObservation(string OmitPropName)
        {
            PolSourceObservationID += 1;

            PolSourceObservation polSourceObservation = new PolSourceObservation();

            if (OmitPropName != "PolSourceObservationID") polSourceObservation.PolSourceObservationID = PolSourceObservationID;
            if (OmitPropName != "PolSourceSiteTVItemID") polSourceObservation.PolSourceSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = GetRandomDateTime();
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservation.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return polSourceObservation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObservation_Testing()
        {
            SetupTestHelper(culture);
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation("");
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(true, polSourceObservationService.GetRead().Where(c => c == polSourceObservation).Any());
            polSourceObservation.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, polSourceObservationService.Update(polSourceObservation));
            Assert.AreEqual(1, polSourceObservationService.GetRead().Count());
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // PolSourceSiteTVItemID will automatically be initialized at 0 --> not null

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("ObservationDate_Local");
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservationDate_Local)).Any());
            Assert.IsTrue(polSourceObservation.ObservationDate_Local.Year < 1900);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            // ContactTVItemID will automatically be initialized at 0 --> not null

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservation_ToBeDeleted)).Any());
            Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("LastUpdateDate_UTC");
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationLastUpdateDate_UTC)).Any());
            Assert.IsTrue(polSourceObservation.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [PolSourceObservationID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceSiteTVItemID] of type [int]
            //-----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.PolSourceSiteTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.PolSourceSiteTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.PolSourceSiteTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.PolSourceSiteTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.PolSourceSiteTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationPolSourceSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.PolSourceSiteTVItemID);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            //-----------------------------------
            // doing property [ObservationDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactTVItemID] of type [int]
            //-----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.ContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.ContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.ContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.ContactTVItemID);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

            //-----------------------------------
            // doing property [Observation_ToBeDeleted] of type [string]
            //-----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceObservation.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(1, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceObservation.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(0, polSourceObservation.ValidationResults.Count());
            Assert.AreEqual(2, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceObservationService.Delete(polSourceObservation));
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceObservation.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceObservation.LastUpdateContactTVItemID);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
