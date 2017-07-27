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
    public partial class MikeSourceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeSourceService mikeSourceService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceTest() : base()
        {
            mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;

            return mikeSource;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeSource_Testing()
        {

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

            mikeSource = GetFilledRandomMikeSource("");
            mikeSource.MikeSourceID = 0;
            mikeSourceService.Update(mikeSource);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceMikeSourceID), mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MikeSource)]
            // [Range(1, -1)]
            // mikeSource.MikeSourceTVItemID   (Int32)
            // -----------------------------------

            // MikeSourceTVItemID will automatically be initialized at 0 --> not null


            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSource.MikeSourceTVItemID = 1;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(1, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSource.MikeSourceTVItemID = 2;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(2, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSource.MikeSourceTVItemID = 0;
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceMikeSourceTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.IsContinuous   (Boolean)
            // -----------------------------------

            // IsContinuous will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.Include   (Boolean)
            // -----------------------------------

            // Include will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // mikeSource.IsRiver   (Boolean)
            // -----------------------------------

            // IsRiver will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());


            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");

            // SourceNumberString has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string mikeSourceSourceNumberStringMin = GetRandomString("", 50);
            mikeSource.SourceNumberString = mikeSourceSourceNumberStringMin;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(mikeSourceSourceNumberStringMin, mikeSource.SourceNumberString);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // SourceNumberString has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            mikeSourceSourceNumberStringMin = GetRandomString("", 49);
            mikeSource.SourceNumberString = mikeSourceSourceNumberStringMin;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(mikeSourceSourceNumberStringMin, mikeSource.SourceNumberString);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // SourceNumberString has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            mikeSourceSourceNumberStringMin = GetRandomString("", 51);
            mikeSource.SourceNumberString = mikeSourceSourceNumberStringMin;
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceSourceNumberString, "50")).Any());
            Assert.AreEqual(mikeSourceSourceNumberStringMin, mikeSource.SourceNumberString);
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSource.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // mikeSource.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSource.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(1, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSource.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(2, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSource.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mikeSource.MikeSourceStartEnds   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mikeSource.MikeSourceTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mikeSource.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
