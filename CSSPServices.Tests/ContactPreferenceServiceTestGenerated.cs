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
    public partial class ContactPreferenceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactPreferenceService contactPreferenceService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceServiceTest() : base()
        {
            //contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "TVTypeText") contactPreference.TVTypeText = GetRandomString("", 5);

            return contactPreference;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactPreference_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);

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
                // [CSSPExist(TypeName = "Contact", Plurial = "s", FieldID = "ContactID", AllowableTVtypeList = Error)]
                // contactPreference.ContactID   (Int32)
                // -----------------------------------

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.ContactID = 0;
                contactPreferenceService.Add(contactPreference);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // contactPreference.TVType   (TVTypeEnum)
                // -----------------------------------

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.TVType = (TVTypeEnum)1000000;
                contactPreferenceService.Add(contactPreference);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceTVType), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(1, 1000)]
                // contactPreference.MarkerSize   (Int32)
                // -----------------------------------

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.MarkerSize = 0;
                Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.MarkerSize = 1001;
                Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // contactPreference.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // contactPreference.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.LastUpdateContactTVItemID = 0;
                contactPreferenceService.Add(contactPreference);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.LastUpdateContactTVItemID = 1;
                contactPreferenceService.Add(contactPreference);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // contactPreference.TVTypeText   (String)
                // -----------------------------------

                contactPreference = null;
                contactPreference = GetFilledRandomContactPreference("");
                contactPreference.TVTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactPreferenceTVTypeText, "100"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // contactPreference.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactPreference_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContactPreferenceService contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);

                ContactPreference contactPreference = (from c in contactPreferenceService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(contactPreference);

                ContactPreference contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                Assert.AreEqual(contactPreference.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);
            }
        }
        #endregion Tests Get With Key

    }
}
