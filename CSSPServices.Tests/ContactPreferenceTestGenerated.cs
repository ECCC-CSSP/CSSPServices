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
    public partial class ContactPreferenceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactPreferenceService contactPreferenceService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceTest() : base()
        {
            contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactPreference GetFilledRandomContactPreference(string OmitPropName)
        {
            ContactPreference contactPreference = new ContactPreference();

            if (OmitPropName != "ContactID") contactPreference.ContactID = 1;
            if (OmitPropName != "TVType") contactPreference.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "MarkerSize") contactPreference.MarkerSize = GetRandomInt(1, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") contactPreference.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactPreference.LastUpdateContactTVItemID = 2;

            return contactPreference;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactPreference_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ContactPreference contactPreference = GetFilledRandomContactPreference("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = contactPreferenceService.GetRead().Count();

            contactPreferenceService.Add(contactPreference);
            if (contactPreference.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, contactPreferenceService.GetRead().Where(c => c == contactPreference).Any());
            contactPreferenceService.Update(contactPreference);
            if (contactPreference.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, contactPreferenceService.GetRead().Count());
            contactPreferenceService.Delete(contactPreference);
            if (contactPreference.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // contactPreference.ContactPreferenceID   (Int32)
            // -----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            contactPreference.ContactPreferenceID = 0;
            contactPreferenceService.Update(contactPreference);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceContactPreferenceID), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "Contact", Plurial = "s", FieldID = "ContactID", TVType = TVTypeEnum.Error)]
            // contactPreference.ContactID   (Int32)
            // -----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            contactPreference.ContactID = 0;
            contactPreferenceService.Add(contactPreference);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

            // ContactID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // contactPreference.TVType   (TVTypeEnum)
            // -----------------------------------

            // TVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 1000)]
            // contactPreference.MarkerSize   (Int32)
            // -----------------------------------

            // MarkerSize will automatically be initialized at 0 --> not null

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            // MarkerSize has Min [1] and Max [1000]. At Min should return true and no errors
            contactPreference.MarkerSize = 1;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(1, contactPreference.MarkerSize);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
            // MarkerSize has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            contactPreference.MarkerSize = 2;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(2, contactPreference.MarkerSize);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
            // MarkerSize has Min [1] and Max [1000]. At Min - 1 should return false with one error
            contactPreference.MarkerSize = 0;
            Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
            Assert.IsTrue(contactPreference.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000")).Any());
            Assert.AreEqual(0, contactPreference.MarkerSize);
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
            // MarkerSize has Min [1] and Max [1000]. At Max should return true and no errors
            contactPreference.MarkerSize = 1000;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(1000, contactPreference.MarkerSize);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
            // MarkerSize has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            contactPreference.MarkerSize = 999;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(999, contactPreference.MarkerSize);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
            // MarkerSize has Min [1] and Max [1000]. At Max + 1 should return false with one error
            contactPreference.MarkerSize = 1001;
            Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
            Assert.IsTrue(contactPreference.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000")).Any());
            Assert.AreEqual(1001, contactPreference.MarkerSize);
            Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contactPreference.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // contactPreference.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            contactPreference.LastUpdateContactTVItemID = 0;
            contactPreferenceService.Add(contactPreference);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contactPreference.Contact   (Contact)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // contactPreference.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
