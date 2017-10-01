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
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillLanguageService spillLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {
            //spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            // Need to implement (no items found, would need to add at least one in the TestDB) [SpillLanguage SpillID Spill SpillID]
            if (OmitPropName != "Language") spillLanguage.Language = LanguageRequest;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            //Error: property [SpillLanguageWeb] and type [SpillLanguage] is  not implemented
            //Error: property [SpillLanguageReport] and type [SpillLanguage] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") spillLanguage.HasErrors = true;

            return spillLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SpillLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = spillLanguageService.GetRead().Count();

                    Assert.AreEqual(spillLanguageService.GetRead().Count(), spillLanguageService.GetEdit().Count());

                    spillLanguageService.Add(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, spillLanguageService.GetRead().Where(c => c == spillLanguage).Any());
                    spillLanguageService.Update(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, spillLanguageService.GetRead().Count());
                    spillLanguageService.Delete(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, spillLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // spillLanguage.SpillLanguageID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 0;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageSpillLanguageID), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 10000000;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SpillLanguage, CSSPModelsRes.SpillLanguageSpillLanguageID, spillLanguage.SpillLanguageID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID", AllowableTVtypeList = Error)]
                    // spillLanguage.SpillID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Spill, CSSPModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.Language = (LanguageEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageLanguage), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // spillLanguage.SpillComment   (String)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
                    Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                    Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
                    Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageSpillComment)).Any());
                    Assert.AreEqual(null, spillLanguage.SpillComment);
                    Assert.AreEqual(count, spillLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageTranslationStatus), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spillLanguage.SpillLanguageWeb   (SpillLanguageWeb)
                    // -----------------------------------

                    //Error: Type not implemented [SpillLanguageWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spillLanguage.SpillLanguageReport   (SpillLanguageReport)
                    // -----------------------------------

                    //Error: Type not implemented [SpillLanguageReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spillLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // spillLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 1;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillLanguageLastUpdateContactTVItemID, "Contact"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SpillLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
                    SpillLanguage spillLanguage = (from c in spillLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(spillLanguage);

                    SpillLanguage spillLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(spillLanguageRet.SpillLanguageID);
                        Assert.IsNotNull(spillLanguageRet.SpillID);
                        Assert.IsNotNull(spillLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageRet.SpillComment));
                        Assert.IsNotNull(spillLanguageRet.TranslationStatus);
                        Assert.IsNotNull(spillLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(spillLanguageRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (spillLanguageRet.SpillLanguageWeb != null)
                            {
                                Assert.IsNull(spillLanguageRet.SpillLanguageWeb);
                            }
                            if (spillLanguageRet.SpillLanguageReport != null)
                            {
                                Assert.IsNull(spillLanguageRet.SpillLanguageReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (spillLanguageRet.SpillLanguageWeb != null)
                            {
                                Assert.IsNotNull(spillLanguageRet.SpillLanguageWeb);
                            }
                            if (spillLanguageRet.SpillLanguageReport != null)
                            {
                                Assert.IsNotNull(spillLanguageRet.SpillLanguageReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of SpillLanguage
        #endregion Tests Get List of SpillLanguage

    }
}
