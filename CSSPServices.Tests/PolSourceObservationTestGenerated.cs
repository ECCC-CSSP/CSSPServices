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
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceObservation.PolSourceObservationID   (Int32)
            // -----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            polSourceObservation.PolSourceObservationID = 0;
            polSourceObservationService.Update(polSourceObservation);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationPolSourceObservationID), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "PolSourceSite", Plurial = "s", FieldID = "PolSourceSiteID", TVType = TVTypeEnum.Error)]
            // polSourceObservation.PolSourceSiteID   (Int32)
            // -----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            polSourceObservation.PolSourceSiteID = 0;
            polSourceObservationService.Add(polSourceObservation);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.PolSourceSite, ModelsRes.PolSourceObservationPolSourceSiteID, polSourceObservation.PolSourceSiteID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

            // PolSourceSiteID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceObservation.ObservationDate_Local   (DateTime)
            // -----------------------------------

            // ObservationDate_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // polSourceObservation.ContactTVItemID   (Int32)
            // -----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            polSourceObservation.ContactTVItemID = 0;
            polSourceObservationService.Add(polSourceObservation);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceObservationContactTVItemID, polSourceObservation.ContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

            // ContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // polSourceObservation.Observation_ToBeDeleted   (String)
            // -----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
            Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
            Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
            Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceObservationObservation_ToBeDeleted)).Any());
            Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
            Assert.AreEqual(0, polSourceObservationService.GetRead().Count());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceObservation.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // polSourceObservation.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceObservation = null;
            polSourceObservation = GetFilledRandomPolSourceObservation("");
            polSourceObservation.LastUpdateContactTVItemID = 0;
            polSourceObservationService.Add(polSourceObservation);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceObservationLastUpdateContactTVItemID, polSourceObservation.LastUpdateContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceObservation.PolSourceObservationIssues   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceObservation.ContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceObservation.PolSourceSite   (PolSourceSite)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // polSourceObservation.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
