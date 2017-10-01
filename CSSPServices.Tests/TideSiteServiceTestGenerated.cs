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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideSiteService tideSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {
            //tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            // Need to implement (no items found, would need to add at least one in the TestDB) [TideSite TideSiteTVItemID TVItem TVItemID]
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomDouble(-100.0D, 100.0D);
            //Error: property [TideSiteWeb] and type [TideSite] is  not implemented
            //Error: property [TideSiteReport] and type [TideSite] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") tideSite.HasErrors = true;

            return tideSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideSite tideSite = GetFilledRandomTideSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideSiteService.GetRead().Count();

                    Assert.AreEqual(tideSiteService.GetRead().Count(), tideSiteService.GetEdit().Count());

                    tideSiteService.Add(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideSiteService.GetRead().Where(c => c == tideSite).Any());
                    tideSiteService.Update(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideSiteService.GetRead().Count());
                    tideSiteService.Delete(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideSite.TideSiteID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 0;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteTideSiteID), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 10000000;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideSite, CSSPModelsRes.TideSiteTideSiteID, tideSite.TideSiteID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideSite.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteTideSiteTVItemID, tideSite.TideSiteTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteTideSiteTVItemID, "TideSite"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideSite.WebTideModel   (String)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("WebTideModel");
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(1, tideSite.ValidationResults.Count());
                    Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteWebTideModel)).Any());
                    Assert.AreEqual(null, tideSite.WebTideModel);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideModel = GetRandomString("", 101);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideSiteWebTideModel, "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-100, 100)]
                    // tideSite.WebTideDatum_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WebTideDatum_m]

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = -101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = 101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideSite.TideSiteWeb   (TideSiteWeb)
                    // -----------------------------------

                    //Error: Type not implemented [TideSiteWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideSite.TideSiteReport   (TideSiteReport)
                    // -----------------------------------

                    //Error: Type not implemented [TideSiteReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, tideSite.LastUpdateContactTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, "Contact"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TideSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
                    TideSite tideSite = (from c in tideSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    TideSite tideSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(tideSiteRet.TideSiteID);
                        Assert.IsNotNull(tideSiteRet.TideSiteTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.WebTideModel));
                        Assert.IsNotNull(tideSiteRet.WebTideDatum_m);
                        Assert.IsNotNull(tideSiteRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tideSiteRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (tideSiteRet.TideSiteWeb != null)
                            {
                                Assert.IsNull(tideSiteRet.TideSiteWeb);
                            }
                            if (tideSiteRet.TideSiteReport != null)
                            {
                                Assert.IsNull(tideSiteRet.TideSiteReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (tideSiteRet.TideSiteWeb != null)
                            {
                                Assert.IsNotNull(tideSiteRet.TideSiteWeb);
                            }
                            if (tideSiteRet.TideSiteReport != null)
                            {
                                Assert.IsNotNull(tideSiteRet.TideSiteReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TideSite
        #endregion Tests Get List of TideSite

    }
}
