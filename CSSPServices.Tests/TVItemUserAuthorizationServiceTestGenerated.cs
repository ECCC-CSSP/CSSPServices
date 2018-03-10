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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new GetParam(), dbTestDB, ContactID);

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

                    Assert.AreEqual(tvItemUserAuthorizationService.GetRead().Count(), tvItemUserAuthorizationService.GetEdit().Count());

                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetRead().Count());
                    tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
                    if (tvItemUserAuthorization.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;
                    tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemUserAuthorization, CSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID, tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.ContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItemUserAuthorization.TVItemID1   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID1 = 2;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID1, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItemUserAuthorization.TVItemID2   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID2 = 2;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID2, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItemUserAuthorization.TVItemID3   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID3 = 2;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID3, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItemUserAuthorization.TVItemID4   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemID4 = 2;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationTVItemID4, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationTVAuth), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.TVItemUserAuthorizationWeb   (TVItemUserAuthorizationWeb)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationWeb = null;
                    Assert.IsNull(tvItemUserAuthorization.TVItemUserAuthorizationWeb);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationWeb = new TVItemUserAuthorizationWeb();
                    Assert.IsNotNull(tvItemUserAuthorization.TVItemUserAuthorizationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.TVItemUserAuthorizationReport   (TVItemUserAuthorizationReport)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationReport = null;
                    Assert.IsNull(tvItemUserAuthorization.TVItemUserAuthorizationReport);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.TVItemUserAuthorizationReport = new TVItemUserAuthorizationReport();
                    Assert.IsNotNull(tvItemUserAuthorization.TVItemUserAuthorizationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime();
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC, "1980"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemUserAuthorization = null;
                    tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
                    tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemUserAuthorization.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new GetParam(), dbTestDB, ContactID);
                    TVItemUserAuthorization tvItemUserAuthorization = (from c in tvItemUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemUserAuthorization);

                    TVItemUserAuthorization tvItemUserAuthorizationRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID, getParam);
                            Assert.IsNull(tvItemUserAuthorizationRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorization.TVItemUserAuthorizationID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TVItemUserAuthorization fields
                        Assert.IsNotNull(tvItemUserAuthorizationRet.TVItemUserAuthorizationID);
                        Assert.IsNotNull(tvItemUserAuthorizationRet.ContactTVItemID);
                        Assert.IsNotNull(tvItemUserAuthorizationRet.TVItemID1);
                        if (tvItemUserAuthorizationRet.TVItemID2 != null)
                        {
                            Assert.IsNotNull(tvItemUserAuthorizationRet.TVItemID2);
                        }
                        if (tvItemUserAuthorizationRet.TVItemID3 != null)
                        {
                            Assert.IsNotNull(tvItemUserAuthorizationRet.TVItemID3);
                        }
                        if (tvItemUserAuthorizationRet.TVItemID4 != null)
                        {
                            Assert.IsNotNull(tvItemUserAuthorizationRet.TVItemID4);
                        }
                        Assert.IsNotNull(tvItemUserAuthorizationRet.TVAuth);
                        Assert.IsNotNull(tvItemUserAuthorizationRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvItemUserAuthorizationRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TVItemUserAuthorizationWeb and TVItemUserAuthorizationReport fields should be null here
                            Assert.IsNull(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb);
                            Assert.IsNull(tvItemUserAuthorizationRet.TVItemUserAuthorizationReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TVItemUserAuthorizationWeb fields should not be null and TVItemUserAuthorizationReport fields should be null here
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.ContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.ContactTVText));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText1 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText1));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText2 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText2));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText3 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText3));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText4 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText4));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.LastUpdateContactTVText));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVAuthText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVAuthText));
                            }
                            Assert.IsNull(tvItemUserAuthorizationRet.TVItemUserAuthorizationReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TVItemUserAuthorizationWeb and TVItemUserAuthorizationReport fields should NOT be null here
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.ContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.ContactTVText));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText1 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText1));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText2 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText2));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText3 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText3));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText4 != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVText4));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.LastUpdateContactTVText));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVAuthText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationWeb.TVAuthText));
                            }
                            if (tvItemUserAuthorizationRet.TVItemUserAuthorizationReport.TVItemUserAuthorizationReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemUserAuthorizationRet.TVItemUserAuthorizationReport.TVItemUserAuthorizationReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVItemUserAuthorization
        #endregion Tests Get List of TVItemUserAuthorization

    }
}
