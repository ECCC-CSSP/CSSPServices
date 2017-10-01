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
    public partial class MikeSourceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeSourceService mikeSourceService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceServiceTest() : base()
        {
            //mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeSource GetFilledRandomMikeSource(string OmitPropName)
        {
            MikeSource mikeSource = new MikeSource();

            // Need to implement (no items found, would need to add at least one in the TestDB) [MikeSource MikeSourceTVItemID TVItem TVItemID]
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            //Error: property [MikeSourceWeb] and type [MikeSource] is  not implemented
            //Error: property [MikeSourceReport] and type [MikeSource] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") mikeSource.HasErrors = true;

            return mikeSource;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeSource_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceService mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeSource mikeSource = GetFilledRandomMikeSource("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeSourceService.GetRead().Count();

                    Assert.AreEqual(mikeSourceService.GetRead().Count(), mikeSourceService.GetEdit().Count());

                    mikeSourceService.Add(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeSourceService.GetRead().Where(c => c == mikeSource).Any());
                    mikeSourceService.Update(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeSourceService.GetRead().Count());
                    mikeSourceService.Delete(mikeSource);
                    if (mikeSource.HasErrors)
                    {
                        Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeSource.MikeSourceID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceID = 0;
                    mikeSourceService.Update(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceMikeSourceID), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceID = 10000000;
                    mikeSourceService.Update(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSource, CSSPModelsRes.MikeSourceMikeSourceID, mikeSource.MikeSourceID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeSource)]
                    // mikeSource.MikeSourceTVItemID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceTVItemID = 0;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceMikeSourceTVItemID, mikeSource.MikeSourceTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.MikeSourceTVItemID = 1;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceMikeSourceTVItemID, "MikeSource"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.IsContinuous   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.Include   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeSource.IsRiver   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // mikeSource.SourceNumberString   (String)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("SourceNumberString");
                    Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                    Assert.AreEqual(1, mikeSource.ValidationResults.Count());
                    Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceSourceNumberString)).Any());
                    Assert.AreEqual(null, mikeSource.SourceNumberString);
                    Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.SourceNumberString = GetRandomString("", 51);
                    Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MikeSourceSourceNumberString, "50"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeSource.MikeSourceWeb   (MikeSourceWeb)
                    // -----------------------------------

                    //Error: Type not implemented [MikeSourceWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeSource.MikeSourceReport   (MikeSourceReport)
                    // -----------------------------------

                    //Error: Type not implemented [MikeSourceReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSource.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeSource.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateContactTVItemID = 0;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceLastUpdateContactTVItemID, mikeSource.LastUpdateContactTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSource = null;
                    mikeSource = GetFilledRandomMikeSource("");
                    mikeSource.LastUpdateContactTVItemID = 1;
                    mikeSourceService.Add(mikeSource);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceLastUpdateContactTVItemID, "Contact"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSource.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSource.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MikeSource_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceService mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);
                    MikeSource mikeSource = (from c in mikeSourceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSource);

                    MikeSource mikeSourceRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(mikeSourceRet.MikeSourceID);
                        Assert.IsNotNull(mikeSourceRet.MikeSourceTVItemID);
                        Assert.IsNotNull(mikeSourceRet.IsContinuous);
                        Assert.IsNotNull(mikeSourceRet.Include);
                        Assert.IsNotNull(mikeSourceRet.IsRiver);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSourceRet.SourceNumberString));
                        Assert.IsNotNull(mikeSourceRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mikeSourceRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (mikeSourceRet.MikeSourceWeb != null)
                            {
                                Assert.IsNull(mikeSourceRet.MikeSourceWeb);
                            }
                            if (mikeSourceRet.MikeSourceReport != null)
                            {
                                Assert.IsNull(mikeSourceRet.MikeSourceReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (mikeSourceRet.MikeSourceWeb != null)
                            {
                                Assert.IsNotNull(mikeSourceRet.MikeSourceWeb);
                            }
                            if (mikeSourceRet.MikeSourceReport != null)
                            {
                                Assert.IsNotNull(mikeSourceRet.MikeSourceReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MikeSource
        #endregion Tests Get List of MikeSource

    }
}
