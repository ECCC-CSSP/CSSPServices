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
    public partial class PolSourceObservationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationService polSourceObservationService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationServiceTest() : base()
        {
            //polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "PolSourceSiteTVText") polSourceObservation.PolSourceSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "ContactTVText") polSourceObservation.ContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") polSourceObservation.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") polSourceObservation.HasErrors = true;

            return polSourceObservation;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObservation_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(polSourceObservationService.GetRead().Count(), polSourceObservationService.GetEdit().Count());

                polSourceObservationService.Add(polSourceObservation);
                if (polSourceObservation.HasErrors)
                {
                    Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, polSourceObservationService.GetRead().Where(c => c == polSourceObservation).Any());
                polSourceObservationService.Update(polSourceObservation);
                if (polSourceObservation.HasErrors)
                {
                    Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, polSourceObservationService.GetRead().Count());
                polSourceObservationService.Delete(polSourceObservation);
                if (polSourceObservation.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationPolSourceObservationID), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 10000000;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationPolSourceObservationID, polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID", AllowableTVtypeList = Error)]
                    // polSourceObservation.PolSourceSiteID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceSiteID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceSite, CSSPModelsRes.PolSourceObservationPolSourceSiteID, polSourceObservation.PolSourceSiteID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.ObservationDate_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.ContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationContactTVItemID, polSourceObservation.ContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationContactTVItemID, "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceObservation.Observation_ToBeDeleted   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationObservation_ToBeDeleted)).Any());
                    Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, polSourceObservation.LastUpdateContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "PolSourceSiteID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // polSourceObservation.PolSourceSiteTVText   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceSiteTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationPolSourceSiteTVText, "200"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "ContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // polSourceObservation.ContactTVText   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationContactTVText, "200"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // polSourceObservation.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationLastUpdateContactTVText, "200"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void PolSourceObservation_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in polSourceObservationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    PolSourceObservation polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                    Assert.IsNotNull(polSourceObservationRet.PolSourceObservationID);
                    Assert.IsNotNull(polSourceObservationRet.PolSourceSiteID);
                    Assert.IsNotNull(polSourceObservationRet.ObservationDate_Local);
                    Assert.IsNotNull(polSourceObservationRet.ContactTVItemID);
                    Assert.IsNotNull(polSourceObservationRet.Observation_ToBeDeleted);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationRet.Observation_ToBeDeleted));
                    Assert.IsNotNull(polSourceObservationRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(polSourceObservationRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(polSourceObservationRet.PolSourceSiteTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationRet.PolSourceSiteTVText));
                    Assert.IsNotNull(polSourceObservationRet.ContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationRet.ContactTVText));
                    Assert.IsNotNull(polSourceObservationRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationRet.LastUpdateContactTVText));
                    Assert.IsNotNull(polSourceObservationRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
