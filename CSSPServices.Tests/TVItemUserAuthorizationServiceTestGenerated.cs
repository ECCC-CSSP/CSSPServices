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
    public partial class TVItemUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationServiceTest() : base()
        {
            //tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 1;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 1;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 1;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 1;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "ContactTVText") tvItemUserAuthorization.ContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TVText1") tvItemUserAuthorization.TVText1 = GetRandomString("", 5);
            if (OmitPropName != "TVText2") tvItemUserAuthorization.TVText2 = GetRandomString("", 5);
            if (OmitPropName != "TVText3") tvItemUserAuthorization.TVText3 = GetRandomString("", 5);
            if (OmitPropName != "TVText4") tvItemUserAuthorization.TVText4 = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tvItemUserAuthorization.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TVAuthText") tvItemUserAuthorization.TVAuthText = GetRandomString("", 5);

            return tvItemUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemUserAuthorization_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = tvItemUserAuthorizationService.GetRead().Count();

                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
                tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetRead().Count());
                tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // tvItemUserAuthorization.TVItemUserAuthorizationID   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemUserAuthorizationID = 0;
                tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // tvItemUserAuthorization.ContactTVItemID   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.ContactTVItemID = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.ContactTVItemID = 1;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemUserAuthorization.TVItemID1   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID1 = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID1 = 2;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID1, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemUserAuthorization.TVItemID2   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID2 = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID2 = 2;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID2, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemUserAuthorization.TVItemID3   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID3 = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID3 = 2;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID3, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemUserAuthorization.TVItemID4   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID4 = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVItemID4 = 2;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationTVItemID4, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
                tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "ContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.ContactTVText   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.ContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationContactTVText, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID1", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.TVText1   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVText1 = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVText1, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID2", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.TVText2   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVText2 = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVText2, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID3", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.TVText3   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVText3 = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVText3, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID4", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.TVText4   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVText4 = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVText4, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemUserAuthorization.LastUpdateContactTVText   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVText, "200"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItemUserAuthorization.TVAuthText   (String)
                // -----------------------------------

                tvItemUserAuthorization = null;
                tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                tvItemUserAuthorization.TVAuthText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemUserAuthorizationTVAuthText, "100"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvItemUserAuthorization.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItemUserAuthorization_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
                TVItemUserAuthorization tvItemUserAuthorization = (from c in tvItemUserAuthorizationService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tvItemUserAuthorization);

                TVItemUserAuthorization tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID);
                Assert.AreEqual(tvItemUserAuthorization.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);
                Assert.AreEqual(tvItemUserAuthorization.ContactTVItemID, tvItemUserAuthorizationRet.ContactTVItemID);
                Assert.AreEqual(tvItemUserAuthorization.TVItemID1, tvItemUserAuthorizationRet.TVItemID1);
                Assert.AreEqual(tvItemUserAuthorization.TVItemID2, tvItemUserAuthorizationRet.TVItemID2);
                Assert.AreEqual(tvItemUserAuthorization.TVItemID3, tvItemUserAuthorizationRet.TVItemID3);
                Assert.AreEqual(tvItemUserAuthorization.TVItemID4, tvItemUserAuthorizationRet.TVItemID4);
                Assert.AreEqual(tvItemUserAuthorization.TVAuth, tvItemUserAuthorizationRet.TVAuth);
                Assert.AreEqual(tvItemUserAuthorization.LastUpdateDate_UTC, tvItemUserAuthorizationRet.LastUpdateDate_UTC);
                Assert.AreEqual(tvItemUserAuthorization.LastUpdateContactTVItemID, tvItemUserAuthorizationRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(tvItemUserAuthorizationRet.ContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.ContactTVText));
                Assert.IsNotNull(tvItemUserAuthorizationRet.TVText1);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVText1));
                Assert.IsNotNull(tvItemUserAuthorizationRet.TVText2);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVText2));
                Assert.IsNotNull(tvItemUserAuthorizationRet.TVText3);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVText3));
                Assert.IsNotNull(tvItemUserAuthorizationRet.TVText4);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVText4));
                Assert.IsNotNull(tvItemUserAuthorizationRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.LastUpdateContactTVText));
                Assert.IsNotNull(tvItemUserAuthorizationRet.TVAuthText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVAuthText));
            }
        }
        #endregion Tests Get With Key

    }
}
