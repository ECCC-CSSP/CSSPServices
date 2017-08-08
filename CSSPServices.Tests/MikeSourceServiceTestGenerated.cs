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

            if (OmitPropName != "MikeSourceTVItemID") mikeSource.MikeSourceTVItemID = 27;
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "MikeSourceTVText") mikeSource.MikeSourceTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mikeSource.LastUpdateContactTVText = GetRandomString("", 5);

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

                mikeSourceService.Add(mikeSource);
                if (mikeSource.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mikeSourceService.GetRead().Where(c => c == mikeSource).Any());
                mikeSourceService.Update(mikeSource);
                if (mikeSource.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mikeSourceService.GetRead().Count());
                mikeSourceService.Delete(mikeSource);
                if (mikeSource.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceMikeSourceID), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = MikeSource)]
                // mikeSource.MikeSourceTVItemID   (Int32)
                // -----------------------------------

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.MikeSourceTVItemID = 0;
                mikeSourceService.Add(mikeSource);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceMikeSourceTVItemID, mikeSource.MikeSourceTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.MikeSourceTVItemID = 1;
                mikeSourceService.Add(mikeSource);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeSourceMikeSourceTVItemID, "MikeSource"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceSourceNumberString)).Any());
                Assert.AreEqual(null, mikeSource.SourceNumberString);
                Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.SourceNumberString = GetRandomString("", 51);
                Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceSourceNumberString, "50"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mikeSource.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mikeSource.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.LastUpdateContactTVItemID = 0;
                mikeSourceService.Add(mikeSource);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceLastUpdateContactTVItemID, mikeSource.LastUpdateContactTVItemID.ToString()), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.LastUpdateContactTVItemID = 1;
                mikeSourceService.Add(mikeSource);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeSourceLastUpdateContactTVItemID, "Contact"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // mikeSource.MikeSourceTVText   (String)
                // -----------------------------------

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.MikeSourceTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceMikeSourceTVText, "200"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // mikeSource.LastUpdateContactTVText   (String)
                // -----------------------------------

                mikeSource = null;
                mikeSource = GetFilledRandomMikeSource("");
                mikeSource.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceLastUpdateContactTVText, "200"), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeSourceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mikeSource.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                MikeSourceService mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);

                MikeSource mikeSource = (from c in mikeSourceService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(mikeSource);

                MikeSource mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceID(mikeSource.MikeSourceID);
                Assert.AreEqual(mikeSource.MikeSourceID, mikeSourceRet.MikeSourceID);
            }
        }
        #endregion Tests Get With Key

    }
}
