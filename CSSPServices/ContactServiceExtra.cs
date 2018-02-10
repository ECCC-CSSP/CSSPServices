using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CSSPServices
{
    public partial class ContactService
    {
        #region Variables
        int UniqueCodeSize = 8; // maximum is 12 in the DB
        //int SearchMaxReturn = 10;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    Contact contact = validationContext.ObjectInstance as Contact;

        //    //Contact contactLoggedIn = GetForEdit().Where(c => c.LoginEmail == User.Identity.Name).FirstOrDefault();

        //    //if (contactLoggedIn == null)
        //    //{
        //    //    yield return new ValidationResult(
        //    //          CSSPServicesRes.NeedToBeLoggedIn,
        //    //          new[] { CSSPModelsRes.ContactContactID });
        //    //}

        //    if (contact.ContactTVItemID == 0)
        //    {
        //        yield return new ValidationResult(
        //             string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTVItemID),
        //             new[] { CSSPModelsRes.ContactContactTVItemID });
        //    }

        //    if (contact.WebName.Length < 3 || contact.WebName.Length > 50)
        //    {
        //        yield return new ValidationResult(
        //             string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactWebName, 3, 50),
        //             new[] { CSSPModelsRes.ContactWebName });
        //    }

        //    if (contact.FirstName.Length < 1 || contact.FirstName.Length > 100)
        //    {
        //        yield return new ValidationResult(
        //             string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactFirstName, 1, 100),
        //             new[] { CSSPModelsRes.ContactFirstName });
        //    }

        //    if (!string.IsNullOrWhiteSpace(contact.Initial))
        //    {
        //        if (contact.Initial.Length < 1 || contact.Initial.Length > 50)
        //        {
        //            yield return new ValidationResult(
        //                 string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactInitial, 1, 50),
        //                 new[] { CSSPModelsRes.ContactInitial });
        //        }
        //    }

        //    if (contact.LastName.Length < 1 || contact.LastName.Length > 100)
        //    {
        //        yield return new ValidationResult(
        //             string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactLastName, 1, 100),
        //             new[] { CSSPModelsRes.ContactLastName });
        //    }

        //    Enums enums = new Enums(LanguageRequest);

        //    string retStr = enums.ContactTitleOK(contact.ContactTitle);
        //    if (!string.IsNullOrWhiteSpace(retStr))
        //    {
        //        yield return new ValidationResult(
        //             retStr,
        //             new[] { CSSPModelsRes.ContactContactTitle });
        //    }

        //    if (string.IsNullOrWhiteSpace(contact.LoginEmail))
        //    {
        //        yield return new ValidationResult(
        //                string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail),
        //                new[] { CSSPModelsRes.ContactLoginEmail });
        //    }

        //    if (contact.LoginEmail.Length > 255)
        //    {
        //        yield return new ValidationResult(
        //               string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginEmail, 255),
        //               new[] { CSSPModelsRes.ContactLoginEmail });
        //    }

        //    Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
        //    if (!regex.IsMatch(contact.LoginEmail))
        //    {
        //        yield return new ValidationResult(
        //                   string.Format(CSSPServicesRes._EmailNotWellFormed, contact.LoginEmail),
        //                   new[] { CSSPModelsRes.ContactLoginEmail });
        //    }

        //    //Contact contactExist = null;

        //    //using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
        //    //{

        //    //    contact = (from c in db.Contacts
        //    //               from a in db.AspNetUsers
        //    //               where c.Id == a.Id
        //    //               && a.Email == User.Identity.Name
        //    //               select c).FirstOrDefault<Contact>();

        //    //    if (contact != null)
        //    //    {
        //    //        // Probably trying to register
        //    //        contactExist = (from c in db.Contacts
        //    //                        where c.WebName == contact.WebName.Trim()
        //    //                        select c).FirstOrDefault<Contact>();

        //    //    }
        //    //    else
        //    //    {
        //    //        if (User.Identity.Name != contact.LoginEmail)
        //    //        {
        //    //            // Can only change contact info if contact
        //    //            if (!contact.IsNew && contactLoggedIn == null)
        //    //            {
        //    //                yield return new ValidationResult(
        //    //                    CSSPServicesRes.NotAllowedToChangeContactInformation,
        //    //                    new[] { CSSPModelsRes.ContactLoginEmail });
        //    //            }

        //    //            if (contact.ContactID > 0)
        //    //            {
        //    //                contactExist = (from c in db.Contacts
        //    //                                where c.ContactID != contact.ContactID
        //    //                                && c.WebName == contact.WebName.Trim()
        //    //                                select c).FirstOrDefault<Contact>();
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            // Probably trying to change some info from profile (FirstName, LastName, WebName etc...)
        //    //            contactExist = (from c in db.Contacts
        //    //                            from a in db.AspNetUsers
        //    //                            where c.Id == a.Id
        //    //                            && c.WebName == contact.WebName.Trim()
        //    //                            && a.Email != User.Identity.Name
        //    //                            select c).FirstOrDefault<Contact>();
        //    //        }
        //    //    }

        //    //    if (contactExist != null)
        //    //    {
        //    //        yield return new ValidationResult(
        //    //                        string.Format(CSSPServicesRes._HasToBeUnique, CSSPModelsRes.ContactWebName),
        //    //                        new[] { CSSPModelsRes.ContactLoginEmail });
        //    //    }

        //    //    // checking that the combination of FirstName, LastName and Initial is unique
        //    //    if (contact != null)
        //    //    {
        //    //        // Probably trying to register
        //    //        if (string.IsNullOrWhiteSpace(contact.Initial))
        //    //        {
        //    //            contact.Initial = "";
        //    //        }

        //    //        contactExist = (from c in db.Contacts
        //    //                        where c.FirstName == contact.FirstName.Trim()
        //    //                        && c.LastName == contact.LastName.Trim()
        //    //                        && c.Initial == contact.Initial.Trim()
        //    //                        select c).FirstOrDefault<Contact>();

        //    //    }
        //    //    else
        //    //    {
        //    //        // Probably trying to change some info from profile (FirstName, LastName, WebName etc...)
        //    //        if (string.IsNullOrWhiteSpace(contact.Initial))
        //    //        {
        //    //            contact.Initial = "";
        //    //        }

        //    //        if (User.Identity.Name != contact.LoginEmail)
        //    //        {
        //    //            // Can only change contact info if contact
        //    //            if (!contact.IsNew && contactLoggedIn == null)
        //    //            {
        //    //                yield return new ValidationResult(
        //    //                           CSSPServicesRes.NotAllowedToChangeContactInformation,
        //    //                           new[] { CSSPModelsRes.ContactLoginEmail });
        //    //            }

        //    //            if (contact.ContactID > 0)
        //    //            {
        //    //                contactExist = (from c in db.Contacts
        //    //                                where c.ContactID != contact.ContactID
        //    //                                && c.FirstName == contact.FirstName
        //    //                                && c.LastName == contact.LastName
        //    //                                && c.Initial.Trim() == contact.Initial.Trim()
        //    //                                select c).FirstOrDefault<Contact>();
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            contactExist = (from c in db.Contacts
        //    //                            from a in db.AspNetUsers
        //    //                            where c.Id == a.Id
        //    //                            && c.FirstName == contact.FirstName
        //    //                            && c.LastName == contact.LastName
        //    //                            && c.Initial.Trim() == contact.Initial.Trim()
        //    //                            && a.Email != User.Identity.Name
        //    //                            select c).FirstOrDefault<Contact>();

        //    //        }
        //    //    }

        //    //    if (contactExist != null)
        //    //    {
        //    //        yield return new ValidationResult(
        //    //                     string.Format(CSSPServicesRes._HasToBeUnique, CSSPServicesRes.FullName),
        //    //                     new[] { CSSPModelsRes.ContactLoginEmail });
        //    //    }

        //    //    // checking that Email is unique which is also the UserName of the Users
        //    //    if (contact != null)
        //    //    {
        //    //        contactExist = (from c in db.Contacts
        //    //                        from a in db.AspNetUsers
        //    //                        where c.Id == a.Id
        //    //                        && a.Email == contact.LoginEmail.Trim()
        //    //                        select c).FirstOrDefault<Contact>();

        //    //    }
        //    //    else
        //    //    {
        //    //        if (User.Identity.Name != contact.LoginEmail)
        //    //        {
        //    //            // Can only change contact info if contact
        //    //            if (!contact.IsNew && contactLoggedIn == null)
        //    //            {
        //    //                yield return new ValidationResult(
        //    //                    CSSPServicesRes.NotAllowedToChangeContactInformation,
        //    //                    new[] { CSSPModelsRes.ContactLoginEmail });
        //    //            }

        //    //            if (contact.ContactID > 0)
        //    //            {
        //    //                contactExist = (from c in db.Contacts
        //    //                                where c.ContactID != contact.ContactID
        //    //                                && c.LoginEmail == contact.LoginEmail.Trim()
        //    //                                select c).FirstOrDefault<Contact>();
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            contactExist = (from c in db.Contacts
        //    //                            from a in db.AspNetUsers
        //    //                            where c.Id == a.Id
        //    //                            && a.Email == contact.LoginEmail.Trim()
        //    //                            && a.Email != User.Identity.Name
        //    //                            select c).FirstOrDefault<Contact>();
        //    //        }
        //    //    }

        //    //    if (contactExist != null)
        //    //    {
        //    //        yield return new ValidationResult(
        //    //             string.Format(CSSPServicesRes._HasToBeUnique, CSSPModelsRes.ContactLoginEmail),
        //    //             new[] { CSSPModelsRes.ContactLoginEmail });
        //    //    }
        //    //}
        //}
        #endregion Validation

        #region Functions public

        // Check
        public string CheckCodeEmailExistDB(string CodeEmail)
        {
            CodeEmail = CodeEmail.Trim();

            string[] strArr = CodeEmail.Split(",".ToCharArray()[0]);
            if (strArr.Length != 2)
            {
                return string.Format(CSSPServicesRes._IsNotComposedOf_Parts, CSSPServicesRes.CodeEmail, 2);
            }

            string Code = strArr[0].Trim();
            string Email = strArr[1].Trim();

            if (string.IsNullOrWhiteSpace(Code))
            {
                return string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordCode);
            }
            if (Code.Length != 8)
            {
                return CSSPServicesRes.CodeNeedsToBe8Characters;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordEmail);

            }

            if (Email.Length > 255)
            {
                return string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordEmail, 255);
            }

            Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
            if (!regex.IsMatch(Email))
            {
                return string.Format(CSSPServicesRes._EmailNotWellFormed, Email);
            }

            ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, db, ContactID);

            ResetPassword resetPassword = resetPasswordService.GetRead().Where(c => c.Email == Email && c.Code == Code).OrderByDescending(c => c.ResetPasswordID).FirstOrDefault<ResetPassword>();

            if (resetPassword != null)
                return "true";
            else
                return string.Format(CSSPServicesRes.Code_ForEmail_DoesNotExist, Code, Email);

        }
        public string CheckEmailExistDB(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail);
            }

            if (Email.Length > 255)
            {
                return string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginEmail, 255);
            }

            Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
            if (!regex.IsMatch(Email))
            {
                return string.Format(CSSPServicesRes._EmailNotWellFormed, Email);
            }

            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                Contact contact = (from c in db.Contacts
                                   where c.LoginEmail == Email
                                   select c).FirstOrDefault<Contact>();

                if (contact != null)
                    return "true";
                else
                    return string.Format(CSSPServicesRes._DoesNotExist, Email);
            }
        }
        public string CheckEmailUniquenessDB(string Email)
        {
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {

                Contact contact = (from c in db.Contacts
                                   where c.ContactID == ContactID
                                   select c).FirstOrDefault<Contact>();

                if (contact != null)
                {
                    contact = (from c in db.Contacts
                               where c.LoginEmail == Email
                               && c.ContactID != ContactID
                               select c).FirstOrDefault<Contact>();
                }
                else
                {
                    contact = (from c in db.Contacts
                               where c.LoginEmail == Email
                               select c).FirstOrDefault<Contact>();
                }

                if (contact == null)
                    return "true";
                else
                    return string.Format(CSSPServicesRes._IsAlreadyTaken, Email);

            }
        }
        public string CheckFullNameUniquenessDB(string FullName)
        {
            string[] strArr = FullName.Split(",".ToCharArray()[0]);

            if (strArr.Length != 3)
            {
                return string.Format(CSSPServicesRes._IsNotComposedOf_Parts, CSSPServicesRes.FullName, 3);
            }
            string FirstName = strArr[0].Trim();
            string Initial = strArr[1].Trim();
            string LastName = strArr[2].Trim();

            if (!string.IsNullOrWhiteSpace(Initial))
            {
                if (Initial != "")
                {
                    if (Initial.Last().ToString() == ".")
                    {
                        Initial = Initial.Substring(0, Initial.Length - 1);
                    }
                }
            }
            else
            {
                Initial = "";
            }

            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {

                Contact contact = (from c in db.Contacts
                                   where c.ContactID == ContactID
                                   select c).FirstOrDefault<Contact>();

                if (contact != null)
                {
                    contact = (from c in db.Contacts
                               where c.FirstName == FirstName
                               && c.LastName == LastName
                               && c.Initial == Initial
                               && c.ContactID != ContactID
                               select c).FirstOrDefault<Contact>();
                }
                else
                {
                    contact = (from c in db.Contacts
                               where c.FirstName == FirstName
                               && c.LastName == LastName
                               && c.Initial == Initial
                               select c).FirstOrDefault<Contact>();
                }

                if (contact == null)
                    return "true";
                else
                    return string.Format(CSSPServicesRes._IsAlreadyTaken, strArr[0] + (string.IsNullOrEmpty(strArr[1]) ? " " : " " + strArr[1] + ", ") + strArr[2]);
            }
        }
        public string CheckWebNameUniquenessDB(string WebName)
        {
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                Contact contact = (from c in db.Contacts
                                   where c.ContactID == ContactID
                                   select c).FirstOrDefault<Contact>();

                if (contact != null)
                {
                    contact = (from c in db.Contacts
                               where c.WebName == WebName
                               && c.ContactID != ContactID
                               select c).FirstOrDefault<Contact>();
                }
                else
                {
                    contact = (from c in db.Contacts
                               where c.WebName == WebName
                               select c).FirstOrDefault<Contact>();
                }

                if (contact == null)
                    return "true";
                else
                    return string.Format(CSSPServicesRes._IsAlreadyTaken, WebName);
            }
        }
        public IQueryable<Contact> GetAdminContactListDB()
        {
            return (from c in db.Contacts
                    from t in db.TVTypeUserAuthorizations
                    where c.ContactTVItemID == t.ContactTVItemID
                    && t.TVType == TVTypeEnum.Root
                    && t.TVAuth == TVAuthEnum.Admin
                    select c);
        }
        public IQueryable<Contact> GetContactAndTelEmailAddressListWithContactTVItemIDDB(int ContactTVItemID)
        {
            return (from c in db.Contacts where c.ContactTVItemID == ContactTVItemID select c);



            //List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(ContactTVItemID);

            //List<TelModel> telModelList = new List<TelModel>();
            //List<EmailModel> emailModelList = new List<EmailModel>();
            //List<AddressModel> addressModelList = new List<AddressModel>();
            //foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            //{
            //    if (tvItemLinkModel.ToTVType == TVTypeEnum.Tel)
            //    {
            //        telModelList.Add(_TelService.GetTelModelWithTelTVItemIDDB(tvItemLinkModel.ToTVItemID));
            //    }
            //    if (tvItemLinkModel.ToTVType == TVTypeEnum.Email)
            //    {
            //        emailModelList.Add(_EmailService.GetEmailModelWithEmailTVItemIDDB(tvItemLinkModel.ToTVItemID));
            //    }
            //    if (tvItemLinkModel.ToTVType == TVTypeEnum.Address)
            //    {
            //        addressModelList.Add(_AddressService.GetAddressModelWithAddressTVItemIDDB(tvItemLinkModel.ToTVItemID));
            //    }
            //}

            //contactModel.TelList = telModelList;
            //contactModel.EmailList = emailModelList;
            //contactModel.AddressList = addressModelList;

            //return contactModel;
        }
        public List<string> GetFirstLettersOfLastNameDB()
        {
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                List<string> lastNameFirstLetterList = (from c in db.Contacts
                                                        let first = c.LastName.Substring(0, 1)
                                                        orderby first
                                                        select first.ToUpper()).Distinct().ToList<string>();

                return lastNameFirstLetterList;
            }
        }
        public List<ResetPassword> GetResetPasswordWithExpireDate_LocalSmallerThanToday()
        {
            List<ResetPassword> resetPasswordList = (from r in db.ResetPasswords
                                                     where r.ExpireDate_Local < DateTime.Today
                                                     select r).ToList<ResetPassword>();

            return resetPasswordList;
        }
        public List<ResetPassword> GetResetPasswordWithEmail(string LoginEmail)
        {
            List<ResetPassword> resetPasswordList = (from r in db.ResetPasswords
                                                     where r.Email == LoginEmail
                                                     select r).ToList<ResetPassword>();

            return resetPasswordList;
        }

        // Helper
        public string AddTVTypeUserAuthorization(TVTypeUserAuthorization tvTypeUserAuthorizationNew)
        {
            TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, db, ContactID);
            if (!tvTypeUserAuthorizationService.Add(tvTypeUserAuthorizationNew))
            {
                return tvTypeUserAuthorizationNew.ValidationResults.FirstOrDefault().ErrorMessage;
            }
            //using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            //{
            //    db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
            //    string retStr = DoAddChanges();
            //    if (!string.IsNullOrWhiteSpace(retStr))
            //        return retStr;

            //    LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
            //    if (!string.IsNullOrWhiteSpace(logModel.Error))
            //        return logModel.Error;

            //    return "";
            //}

            return "";
        }
        public bool ContactTVItemIDIsBeingUsed(int ContactTVItemID)
        {
            // Check everywhere ContactTVItemID could exist
            // MWQMRuns SamplingContactTVItemID, LabSampleApprovalContactTVItemID
            // PolSourceObservations ContactTVItemID
            // TVItemLinks FromTVItemID, ToTVItemID

            MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, db, ContactID);
            List<MWQMRun> mwqmRunModelList = mwqmRunService.GetRead().Where(c => c.LabSampleApprovalContactTVItemID == ContactTVItemID).ToList();
            if (mwqmRunModelList.Count > 0)
                return true;

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, db, ContactID);
            PolSourceObservation polSourceObservation = polSourceObservationService.GetRead().Where(c => c.ContactTVItemID == ContactTVItemID).FirstOrDefault();
            if (polSourceObservation != null)
                return true;

            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, db, ContactID);
            int countTVItemLink = tvItemLinkService.GetRead().Where(c => c.FromTVItemID == ContactTVItemID).Count();
            if (countTVItemLink > 0)
                return true;

            countTVItemLink = tvItemLinkService.GetRead().Where(c => c.ToTVItemID == ContactTVItemID).Count();
            if (countTVItemLink > 0)
                return true;

            return false;
        }
        public string CreateTVText(Contact contact)
        {
            return contact.LastName + ", " + contact.FirstName + (string.IsNullOrWhiteSpace(contact.Initial) ? "" : " " + contact.Initial + ".");
        }
        public string CreateUniquePassword()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            string uniquePassword = "";
            for (int i = 0; i < 12; i++)
            {
                uniquePassword += random.Next(0, 9).ToString().First();
            }

            return uniquePassword;
        }
        public string CreateUniqueWebName(string FirstName, string LastName)
        {
            string UniqueWebName = FirstName + "_" + LastName;
            for (int i = 1; i < 100; i++)
            {
                string retStr = CheckWebNameUniquenessDB(UniqueWebName);
                if (retStr == "true")
                {
                    break;
                }
                UniqueWebName = FirstName + "_" + LastName + "_" + i;
            }

            return UniqueWebName;
        }
        //public void Init(LanguageEnum LanguageRequest, IPrincipal User)
        //{
        //    _AspNetUserService = new AspNetUserService(LanguageRequest, User);
        //    _TVTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);
        //    _TVItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);
        //    _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
        //    _ResetPasswordService = new ResetPasswordService(LanguageRequest, User);
        //    _TVItemService = new TVItemService(LanguageRequest, User);
        //    _MWQMRunService = new MWQMRunService(LanguageRequest, User);
        //    _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
        //    _TelService = new TelService(LanguageRequest, User);
        //    _EmailService = new EmailService(LanguageRequest, User);
        //    _AddressService = new AddressService(LanguageRequest, User);
        //    _LogService = new LogService(LanguageRequest, User);
        //}
        public string GenerateUniqueCodeForResetPasswordDB()
        {
            string UniqueCode = "";

            Random r = new Random((int)DateTime.Now.Ticks);

            while (UniqueCode.Length < UniqueCodeSize)
            {
                UniqueCode += (r.Next(0, 9)).ToString();
            }

            return UniqueCode;
        }
        public string GetBodyForSendEmailWithCode(string Email, string Code)
        {
            return CSSPServicesRes.PlsUseFollowingUniqueCodeEtc
                + @"<br />"
                + @"<br />"
                + CSSPServicesRes.YourEmailIs + " " + Email + @"<br />"
                + @"<br />"
                + CSSPServicesRes.CodeIs + " " + Code + @"<br />"
                + @"<br />"
                + CSSPServicesRes.AutoEmailFromServer + @"<br />";
        }
        public string GetBodyOfCreateNewContactAndEmail(string FullNameLoggedIn, string FullNameAdded, string CreatorEmail)
        {
            if (CreatorEmail == "")
            {
                return string.Format(CSSPServicesRes._RegisteredAndAddedInWebSite, @"<b>" + FullNameAdded + @"</b>  @<br />");
            }
            else
            {
                return string.Format(CSSPServicesRes._AddedInWebSiteBy_, @"<b>" + FullNameAdded + "</b>", FullNameLoggedIn + @"<br />");
            }
        }
        public string GetSubjectOfCreateNewContactAndEmail(string FullNameLoggedIn, string FullNameAdded, string CreatorEmail)
        {
            if (CreatorEmail == "")
            {
                return string.Format(CSSPServicesRes._RegisteredAndAddedInWebSite, FullNameAdded);
            }
            else
            {
                return string.Format(CSSPServicesRes.YouBeenAddedInWebSiteBy_, FullNameLoggedIn);
            }
        }
        //public bool SetContactRegister(Contact contact)
        //{
        //    contact.Password = CreateUniquePassword();
        //    contact.ConfirmPassword = contact.Password;
        //    contact.Initial = "";

        //    if (string.IsNullOrWhiteSpace(contact.LoginEmail))
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail)) }.AsEnumerable();
        //        return false;
        //    }

        //    if (contact.LoginEmail.Length > 255)
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginEmail, 255)) }.AsEnumerable();
        //        return false;
        //    }

        //    Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
        //    if (!regex.IsMatch(contact.LoginEmail))
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._EmailNotWellFormed, contact.LoginEmail)) }.AsEnumerable();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(contact.FirstName))
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactFirstName)) }.AsEnumerable();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(contact.LastName))
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLastName)) }.AsEnumerable();
        //        return false;
        //    }

        //    contact.WebName = CreateUniqueWebName(contact.FirstName, contact.LastName);

        //    ContactService contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //    contact.ValidationResults = contactService.Validate(new ValidationContext(contact), ActionDBTypeEnum.Create);
        //    if (contact.ValidationResults.Count() > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        // Post
        //public async Task<bool> AddOrModifyContactUnderParentTVItemIDDB(Contact contact)
        //{
        //    Contact ContactLoggedIn = db.Contacts.Where(c => c.LoginEmail == User.Identity.Name).Select(c => c).FirstOrDefault();
        //    if (ContactLoggedIn == null)
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.NeedToBeLoggedIn) };
        //        return false;
        //    }

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        if (contact.ContactTVItemID == 0)
        //        {
        //            ContactService contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //            contact.ValidationResults = contactService.Validate(new ValidationContext(contact), ActionDBTypeEnum.Create);

        //            TVItemService tvItemService = new TVItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);

        //            TVItem tvItemParent = tvItemService.GetRead().Where(c => c.TVItemID == contact.ParentTVItemID).FirstOrDefault();
        //            if (tvItemParent == null)
        //            {
        //                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemTVItemID, contact.ParentTVItemID.ToString())) };
        //                return false;
        //            }

        //            if (await LoggedInUserCreateNewUserDB(contact))
        //            {
        //                return false;
        //            }

        //            TVItem tvItemContact = tvItemService.GetRead().Where(c => c.TVItemID == contact.ContactTVItemID).FirstOrDefault();
        //            if (tvItemContact == null)
        //            {
        //                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemTVItemID, contact.ContactTVItemID.ToString())) };
        //                return false;
        //            }

        //            TVItemLink tvItemLink = new TVItemLink()
        //            {
        //                FromTVItemID = tvItemParent.TVItemID,
        //                ToTVItemID = contact.ContactTVItemID,
        //                FromTVType = tvItemParent.TVType,
        //                ToTVType = TVTypeEnum.Contact,
        //                StartDateTime_Local = DateTime.Now,
        //                Ordinal = 0,
        //                TVLevel = 0,
        //                TVPath = "p" + tvItemParent.TVItemID + "p" + contact.ContactTVItemID,
        //            };

        //            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //            TVItemLink tvItemLinkExist = tvItemLinkService.GetRead().Where(c => c.FromTVItemID == tvItemParent.TVItemID && c.ToTVItemID == contact.ContactTVItemID).FirstOrDefault();
        //            if (tvItemLinkExist != null)
        //            {
        //                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //                string TVText = tvItemLanguageService.GetRead().Where(c => c.TVItemID == tvItemContact.TVItemID && c.Language == LanguageRequest).Select(c => c.TVText).FirstOrDefault();
        //                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._AlreadyExists, TVText)) };
        //                return false;
        //            }

        //            if (!tvItemLinkService.Add(tvItemLink))
        //            {
        //                contact.ValidationResults = tvItemLink.ValidationResults;
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            ContactService contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //            contact.ValidationResults = contactService.Validate(new ValidationContext(contact), ActionDBTypeEnum.Create);

        //            TVItemService tvItemService = new TVItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);

        //            TVItem tvItemParent = tvItemService.GetRead().Where(c => c.TVItemID == contact.ParentTVItemID).FirstOrDefault();
        //            if (tvItemParent == null)
        //            {
        //                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemTVItemID, contact.ParentTVItemID.ToString())) };
        //                return false;
        //            }

        //            if (await LoggedInUserCreateNewUserDB(contact))
        //            {
        //                return false;
        //            }

        //            //ContactService contactService = new ContactService(LanguageRequest, ContactID, new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB));

        //            Contact contactToChange = db.Contacts.Where(c => c.ContactTVItemID == contact.ContactTVItemID).FirstOrDefault();
        //            if (contactToChange == null)
        //            {
        //                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactContactTVItemID, contact.ContactTVItemID.ToString())) };
        //                return false;
        //            }

        //            if (contactToChange.LoginEmail != contact.LoginEmail)
        //            {
        //                TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //                IQueryable<TVItemLink> tvItemLinkQueryFrom = tvItemLinkService.GetRead().Where(c => c.FromTVItemID == tvItemParent.TVItemID && c.ToTVItemID == contact.ContactTVItemID);
        //                foreach (TVItemLink tvItemLink in tvItemLinkQueryFrom)
        //                {
        //                    tvItemLinkService.Delete(tvItemLink);
        //                    if (tvItemLink.ValidationResults.Count() > 0)
        //                    {
        //                        contact.ValidationResults = tvItemLink.ValidationResults;
        //                        return false;
        //                    }
        //                }
        //                IQueryable<TVItemLink> tvItemLinkQueryTo = tvItemLinkService.GetRead().Where(c => c.FromTVItemID == tvItemParent.TVItemID && c.ToTVItemID == contact.ContactTVItemID);
        //                foreach (TVItemLink tvItemLink in tvItemLinkQueryTo)
        //                {
        //                    tvItemLinkService.Delete(tvItemLink);
        //                    if (tvItemLink.ValidationResults.Count() > 0)
        //                    {
        //                        contact.ValidationResults = tvItemLink.ValidationResults;
        //                        return false;
        //                    }
        //                }
        //                AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //                AspNetUser aspNetUser = aspNetUserService.GetRead().Where(c => c.Id == contactToChange.Id).FirstOrDefault();
        //                if (aspNetUser != null)
        //                {
        //                    aspNetUserService.Delete(aspNetUser);
        //                    if (aspNetUser.ValidationResults.Count() > 0)
        //                    {
        //                        contact.ValidationResults = aspNetUser.ValidationResults;
        //                        return false;
        //                    }
        //                }
        //                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //                IQueryable<TVItemLanguage> tvItemLanguageListToDelete = tvItemLanguageService.GetRead().Where(c => c.TVItemID == contactToChange.ContactTVItemID);
        //                foreach (TVItemLanguage tvItemLanguage in tvItemLanguageListToDelete)
        //                {
        //                    tvItemLanguageService.Delete(tvItemLanguage);
        //                    if (tvItemLanguage.ValidationResults.Count() > 0)
        //                    {
        //                        contact.ValidationResults = tvItemLanguage.ValidationResults;
        //                        return false;
        //                    }
        //                }
        //                TVItem tvItemToDelete = tvItemService.GetRead().Where(c => c.TVItemID == contactToChange.ContactTVItemID).FirstOrDefault();
        //                if (tvItemToDelete != null)
        //                {
        //                    tvItemService.Delete(tvItemToDelete);
        //                    if (tvItemToDelete.ValidationResults.Count() > 0)
        //                    {
        //                        contact.ValidationResults = tvItemToDelete.ValidationResults;
        //                        return false;
        //                    }
        //                }


        //                if (!(await AddOrModifyContactUnderParentTVItemIDDB(contact)))
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                contactToChange.FirstName = contact.FirstName;
        //                contactToChange.Initial = contact.Initial;
        //                contactToChange.LastName = contact.LastName;
        //                contactToChange.ContactTitle = contact.ContactTitle;

        //                if (!contactService.Update(contactToChange))
        //                {
        //                    contact.ValidationResults = contactToChange.ValidationResults;
        //                    return false;
        //                }

        //                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //                foreach (LanguageEnum Lang in LanguageListAllowable)
        //                {
        //                    TVItemLanguage tvItemLanguageToChange = tvItemLanguageService.GetRead().Where(c => c.TVItemID == contactToChange.ContactTVItemID && c.Language == LanguageRequest).FirstOrDefault();
        //                    if (tvItemLanguageToChange == null)
        //                    {
        //                        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLanguage, CSSPModelsRes.TVItemTVItemID, contactToChange.ContactTVItemID.ToString())) };
        //                        return false;
        //                    }
        //                    tvItemLanguageToChange.TVText = CreateTVText(contactToChange);

        //                    if (!tvItemLanguageService.Update(tvItemLanguageToChange))
        //                    {
        //                        contact.ValidationResults = tvItemLanguageToChange.ValidationResults;
        //                        return false;
        //                    }
        //                }
        //            }
        //        }

        //        ts.Complete();
        //    }
        //    return true;
        //}
        //public bool AddContactDB(Contact contact)
        //{
        //    Contact ContactLoggedIn = tvItemService.GetContactLoggedInDB();
        //    if (ContactLoggedIn == null)
        //    {
        //        contactNew.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.NeedToBeLoggedIn) };
        //        return false;
        //    }

        //    string retStr = ContactOK(contact);
        //    if (!string.IsNullOrEmpty(retStr))
        //        return ReturnContactError(retStr);

        //    ContactOK contactOK = IsContactOK();
        //    if (!string.IsNullOrEmpty(contactOK.Error))
        //        return ReturnContactError(contactOK.Error);

        //    TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(contact.ContactTVItemID);
        //    if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
        //        return ReturnContactError(tvItemModelExist.Error);

        //    Contact contactNew = new Contact();
        //    retStr = FillContact(contactNew, contact, contactOK);
        //    if (!string.IsNullOrWhiteSpace(retStr))
        //        return ReturnContactError(retStr);

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        db.Contacts.Add(contactNew);
        //        retStr = DoAddChanges();
        //        if (!string.IsNullOrWhiteSpace(retStr))
        //            return ReturnContactError(retStr);

        //        LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactNew.ContactID, LogCommandEnum.Add, contactNew);
        //        if (!string.IsNullOrWhiteSpace(logModel.Error))
        //            return ReturnContactError(logModel.Error);

        //        TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
        //        tvTypeUserAuthorizationNew.ContactTVItemID = contact.ContactTVItemID;
        //        tvTypeUserAuthorizationNew.TVType = TVTypeEnum.Root;
        //        tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.NoAccess;
        //        tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
        //        tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contactNew.ContactID;

        //        retStr = AddTVTypeUserAuthorization(tvTypeUserAuthorizationNew);
        //        if (!string.IsNullOrWhiteSpace(retStr))
        //            return ReturnContactError(retStr);

        //        ts.Complete();
        //    }
        //    return GetContactWithContactIDDB(contactNew.ContactID);
        //}
        public bool AddContact(Contact contact, AddContactTypeEnum addContactType)
        {
            TVItem tvItemRoot = null;
            Contact LoggedInContact = null;
            TVItem tvItem = new TVItem();

            TVItemService tvItemService = new TVItemService(LanguageRequest, db, ContactID);
            ContactService contactService = new ContactService(LanguageRequest, db, ContactID);
            TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, db, ContactID);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, db, ContactID);

            if (addContactType != AddContactTypeEnum.First)
            {
                LoggedInContact = GetRead().Where(c => c.ContactID == ContactID).FirstOrDefault();
                if (LoggedInContact == null)
                {
                    contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactContactID, ContactID), new[] { CSSPModelsRes.ContactContactID }) };
                    return false;
                }
            }

            if (addContactType == AddContactTypeEnum.First)
            {
                if (contactService.GetRead().Count() > 0)
                {
                    contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.ToAddFirst_Requires_TableToBeEmpty, CSSPModelsRes.Contact, CSSPModelsRes.Contact), new[] { CSSPModelsRes.ContactContactID }) };
                    return false;
                }
            }

            if (contact.ContactTVItemID == 0)
            {
                tvItemRoot = tvItemService.GetRead().Where(c => c.TVLevel == 0).FirstOrDefault();
                if (tvItemRoot == null)
                {
                    contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.CouldNotFindRoot, new[] { CSSPModelsRes.TVItemTVItemID }) };
                    return false;
                }

                //tvItem.TVItemID = tvItemRoot.TVItemID + 1;
                tvItem.TVLevel = 1;
                tvItem.TVPath = tvItemRoot.TVPath + "p0"; // will be changed later
                tvItem.TVType = TVTypeEnum.Contact;
                tvItem.ParentID = tvItemRoot.TVItemID;
                tvItem.IsActive = true;
                tvItem.LastUpdateDate_UTC = DateTime.UtcNow;
                tvItem.LastUpdateContactTVItemID = tvItemRoot.TVItemID;

            }

            using (TransactionScope ts = new TransactionScope())
            {
                if (contact.ContactTVItemID == 0)
                {
                    if (!tvItemService.Add(tvItem))
                    {
                        contact.ValidationResults = tvItem.ValidationResults;
                        return false;
                    }

                    tvItem.TVPath = tvItemRoot.TVPath + "p" + tvItem.TVItemID;

                    if (!tvItemService.Update(tvItem))
                    {
                        contact.ValidationResults = tvItem.ValidationResults;
                        return false;
                    }

                    contact.ContactTVItemID = tvItem.TVItemID;
                }

                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, db, ContactID);
                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    string TVText = CreateTVText(contact);
                    TVItemLanguage tvItemLanguage = new TVItemLanguage()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItem.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    tvItemLanguageService.Add(tvItemLanguage);
                }

                if (!contactService.Add(contact, addContactType)) return false;

                TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
                tvTypeUserAuthorizationNew.ContactTVItemID = contact.ContactTVItemID;
                tvTypeUserAuthorizationNew.TVType = TVTypeEnum.Root;
                if (addContactType == AddContactTypeEnum.First)
                {
                    tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.Admin;
                }
                else if (addContactType == AddContactTypeEnum.LoggedIn)
                {
                    tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.NoAccess;
                }
                else if (addContactType == AddContactTypeEnum.Register)
                {
                    tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.Read;
                }
                else
                {
                    tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.NoAccess;
                }
                tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
                tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contact.ContactID;

                if (!tvTypeUserAuthorizationService.Add(tvTypeUserAuthorizationNew))
                {
                    contact.ValidationResults = tvTypeUserAuthorizationNew.ValidationResults;
                    return false;
                }

                // use to add a link of the contact under the ParentTVItemID
                if (contact.ContactWeb.ParentTVItemID != 0)
                {
                    TVItem tvItemParent = tvItemService.GetRead().Where(c => c.TVItemID == contact.ContactWeb.ParentTVItemID).FirstOrDefault();
                    if (tvItemParent != null)
                    {
                        TVItemLink tvItemLink = new TVItemLink();
                        tvItemLink.FromTVItemID = contact.ContactWeb.ParentTVItemID;
                        tvItemLink.ToTVItemID = contact.ContactTVItemID;
                        tvItemLink.FromTVType = tvItemParent.TVType;
                        tvItemLink.ToTVType = TVTypeEnum.Contact;
                        tvItemLink.Ordinal = 0;
                        tvItemLink.TVLevel = 0;
                        tvItemLink.TVPath = "p" + contact.ContactWeb.ParentTVItemID + "p" + contact.ContactTVItemID;
                        tvItemLink.LastUpdateDate_UTC = DateTime.UtcNow;
                        if (addContactType == AddContactTypeEnum.First)
                        {
                            tvItemLink.LastUpdateContactTVItemID = contact.ContactTVItemID;
                        }
                        else if (addContactType == AddContactTypeEnum.Register)
                        {
                            tvItemLink.LastUpdateContactTVItemID = contact.ContactTVItemID;
                        }
                        else if (addContactType == AddContactTypeEnum.LoggedIn)
                        {
                            tvItemLink.LastUpdateContactTVItemID = LoggedInContact.ContactTVItemID;
                        }
                        else
                        {
                            tvItemLink.LastUpdateContactTVItemID = LoggedInContact.ContactTVItemID;
                        }
                    }
                }

                ts.Complete();
            }
            return true;
        }
        //public async Task<bool> LoggedInUserCreateNewUserDB(Contact contact)
        //{
        //    TVItemService tvItemService = new TVItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);

        //    Contact ContactLoggedIn = GetRead().Where(c => c.LoginEmail == User.Identity.Name).FirstOrDefault();
        //    if (ContactLoggedIn == null)
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.NeedToBeLoggedIn) };
        //        return false;
        //    }

        //    TVItem tvItemModelRoot = tvItemService.GetRead().Where(c => c.TVLevel == 0).FirstOrDefault();
        //    if (tvItemModelRoot == null)
        //    {
        //        contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.CouldNotFindRoot) };
        //        return false;
        //    }

        //    AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);

        //    AspNetUser aspNetUserNew = new AspNetUser();
        //    aspNetUserNew.Email = contact.LoginEmail;
        //    aspNetUserNew.Password = CreateUniquePassword();

        //    if (!aspNetUserService.Add(aspNetUserNew))
        //    {
        //        return false;
        //    }

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        IdentityResult identityResult = await aspNetUserService.AddAspNetUserDB(aspNetUserNew, true);
        //        if (!identityResult.Succeeded)
        //        {
        //            return false;
        //        }

        //        Contact contactToAdd = new Contact();
        //        contactToAdd.Id = aspNetUserNew.Id;
        //        contactToAdd.ContactTVItemID = 1; // will change
        //        contactToAdd.LoginEmail = contact.LoginEmail;
        //        contactToAdd.FirstName = contact.FirstName;
        //        contactToAdd.LastName = contact.LastName;
        //        contactToAdd.Initial = contact.Initial;
        //        contactToAdd.ContactTitle = contact.ContactTitle;
        //        contactToAdd.WebName = CreateUniqueWebName(contact.FirstName, contact.LastName);
        //        contactToAdd.IsAdmin = false;
        //        contactToAdd.IsNew = true;
        //        contactToAdd.SamplingPlanner_ProvincesTVItemID = "";
        //        contactToAdd.EmailValidated = false;
        //        contactToAdd.Disabled = false;

        //        string TVText = CreateTVText(contactToAdd);
        //        if (string.IsNullOrWhiteSpace(TVText))
        //        {
        //            contactToAdd.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVText")) };
        //            return false;
        //        }

        //        TVItem tvItemContact = new TVItem();
        //        if (!tvItemService.AddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact, tvItemContact))
        //        {
        //            contactToAdd.ValidationResults = tvItemContact.ValidationResults;
        //            return false;
        //        }

        //        contactToAdd.ContactTVItemID = tvItemContact.TVItemID;
        //        ContactService contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //        if (!contactService.Add(contactToAdd))
        //        {
        //            //contactToAdd.ValidationResults = contactToAdd.ValidationResults;
        //            return false;
        //        }

        //        TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
        //        tvTypeUserAuthorizationNew.ContactTVItemID = contactToAdd.ContactTVItemID;
        //        tvTypeUserAuthorizationNew.TVType = TVTypeEnum.Root;
        //        tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.NoAccess;
        //        tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
        //        tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = ContactLoggedIn.ContactTVItemID;

        //        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //        if (!tvTypeUserAuthorizationService.Add(tvTypeUserAuthorizationNew))
        //        {
        //            contactToAdd.ValidationResults = tvTypeUserAuthorizationNew.ValidationResults;
        //            return false;
        //        }

        //        ts.Complete();
        //    }
        //    return true;
        //}
        //public bool ContactRegisterDB(Contact contact)
        //{
        //    ContactService contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //    IEnumerable<ValidationResult> validationResultList = contactService.Validate(new ValidationContext(contact), ActionDBTypeEnum.Create);
        //    if (validationResultList.Count() > 0)
        //    {
        //        contact.ValidationResults = validationResultList;
        //        return false;
        //    }

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //        AspNetUser aspNetUser = new AspNetUser()
        //        {
        //            Email = contact.LoginEmail,
        //            Password = contact.Password
        //        };

        //        Task<IdentityResult> identityResult = aspNetUserService.AddAspNetUserDB(aspNetUser, false);
        //        if (!identityResult.Result.Succeeded)
        //        {
        //            contact.ValidationResults = aspNetUser.ValidationResults;
        //        }

        //        TVItemService tvItemService = new TVItemService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //        TVItem tvItemRoot = tvItemService.GetRead().Where(c => c.TVLevel == 0).FirstOrDefault();
        //        if (tvItemRoot == null)
        //        {
        //            contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.CouldNotFindRoot) };
        //            return false;
        //        }

        //        contact.EmailValidated = true;
        //        contact.IsAdmin = false;
        //        contact.Disabled = false;
        //        contact.Id = aspNetUser.Id;
        //        contact.IsNew = false;
        //        contact.SamplingPlanner_ProvincesTVItemID = "";

        //        string TVText = CreateTVText(contact);
        //        if (string.IsNullOrWhiteSpace(TVText))
        //        {
        //            contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVText")) };
        //            return false;
        //        }

        //        TVItem tvItemContact = new TVItem();
        //        if (!tvItemService.AddChildContactTVItemDB(tvItemRoot.TVItemID, TVText, TVTypeEnum.Contact, tvItemContact))
        //        {
        //            contact.ValidationResults = tvItemContact.ValidationResults;
        //            return false;
        //        }

        //        contact.ContactTVItemID = tvItemContact.TVItemID;

        //        if (!contactService.Add(contact))
        //        {
        //            contact.ValidationResults = contact.ValidationResults;
        //            return false;
        //        }

        //        base.User = new GenericPrincipal(new GenericIdentity(contact.LoginEmail, "Forms"), null);

        //        contactService = new ContactService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);
        //        Contact contactRet = contactService.GetEdit().Where(c => c.ContactID == contact.ContactID).FirstOrDefault();
        //        if (contactRet == null)
        //        {
        //            contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactContactID, contact.ContactID.ToString())) };
        //            return false;
        //        }

        //        contact.ContactTVItemID = tvItemContact.TVItemID;
        //        contact.EmailValidated = false;

        //        if (!contactService.Update(contact))
        //        {
        //            contact.ValidationResults = contact.ValidationResults;
        //            return false;
        //        }

        //        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);

        //        TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
        //        tvTypeUserAuthorizationNew.ContactTVItemID = contactRet.ContactTVItemID;
        //        tvTypeUserAuthorizationNew.TVType = TVTypeEnum.Root;
        //        tvTypeUserAuthorizationNew.TVAuth = TVAuthEnum.NoAccess;
        //        tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
        //        tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contact.ContactID;

        //        if (!tvTypeUserAuthorizationService.Add(tvTypeUserAuthorizationNew))
        //        {
        //            contact.ValidationResults = tvTypeUserAuthorizationNew.ValidationResults;
        //            return false;
        //        }

        //        ts.Complete();
        //    }
        //    return true;
        //}
        public bool SetContactDisabledOrEnableForContactDB(Contact contact)
        {
            if (contact == null)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.Contact)) };
                return false;
            }

            if (contact.ContactTVItemID == 0)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTVItemID)) };
                return false;
            }

            Contact contactLoggedIn = GetRead().Where(c => c.ContactID == ContactID).Select(c => c).FirstOrDefault();
            if (contactLoggedIn == null)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.NeedToBeLoggedIn) };
                return false;
            }

            if (!contactLoggedIn.IsAdmin)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(CSSPServicesRes.OnlyAdministratorsCanManageUsers) };
                return false;
            }

            contact.Disabled = !(contact.Disabled);
            contact.LastUpdateDate_UTC = DateTime.UtcNow;
            contact.LastUpdateContactTVItemID = contact.ContactTVItemID;

            ContactService contactService = new ContactService(LanguageRequest, db, ContactID);
            if (!contactService.Update(contact))
            {
                return false;
            }

            return true;
        }
        public bool SetRemoveProvinceDB(Contact contact, int ProvinceTVItemID)
        {
            if (contact == null)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.Contact)) };
                return false;
            }

            if (contact.ContactTVItemID == 0)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTVItemID)) };
                return false;
            }

            if (ProvinceTVItemID == 0)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ProvinceTVItemID")) };
                return false;
            }

            contact.SamplingPlanner_ProvincesTVItemID = contact.SamplingPlanner_ProvincesTVItemID.Replace(ProvinceTVItemID.ToString() + ",", "");

            if (!Update(contact))
            {
                return false;
            }

            return true;
        }
        public bool SetAddProvinceDB(Contact contact, int ProvinceTVItemID)
        {
            if (contact == null)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.Contact)) };
                return false;
            }

            if (contact.ContactTVItemID == 0)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTVItemID)) };
                return false;
            }

            if (ProvinceTVItemID == 0)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ProvinceTVItemID")) };
                return false;
            }

            contact.SamplingPlanner_ProvincesTVItemID = contact.SamplingPlanner_ProvincesTVItemID + ProvinceTVItemID.ToString() + ",";

            if (!Update(contact))
            {
                return false;
            }

            return true;

        }
        public bool TryToSendEmailDB(ResetPassword resetPassword, string LoginEmail)
        {
            string retStr = "";
            ResetPassword resetPasswordNew = new ResetPassword();
            using (TransactionScope ts = new TransactionScope())
            {
                if (string.IsNullOrWhiteSpace(LoginEmail))
                {
                    resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail)) };
                    return false;
                }

                if (LoginEmail.Length > 255)
                {
                    resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginEmail, 255)) };
                    return false;
                }

                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(LoginEmail))
                {
                    resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._EmailNotWellFormed, LoginEmail)) };
                    return false;
                }

                Contact contact = GetRead().Where(c => c.LoginEmail == LoginEmail).FirstOrDefault();
                if (contact == null)
                {
                    resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactLoginEmail, LoginEmail)) };
                    return false;
                }

                // remove all old ResetPassword in the DB
                ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, db, ContactID);

                List<ResetPassword> ResetPasswordList = GetResetPasswordWithExpireDate_LocalSmallerThanToday();
                foreach (ResetPassword resetPasswordToDelete in ResetPasswordList)
                {
                    if (!resetPasswordService.Delete(resetPasswordToDelete))
                    {
                        resetPassword.ValidationResults = resetPasswordToDelete.ValidationResults;
                        return false;
                    }
                }

                // remove all ResetPassword with LoginEmail
                ResetPasswordList = GetResetPasswordWithEmail(LoginEmail);
                foreach (ResetPassword resetPasswordToDelete in ResetPasswordList)
                {
                    if (!resetPasswordService.Delete(resetPasswordToDelete))
                    {
                        resetPassword.ValidationResults = resetPasswordToDelete.ValidationResults;
                        return false;
                    }
                }

                resetPasswordNew = new ResetPassword()
                {
                    Code = GenerateUniqueCodeForResetPasswordDB(),
                    ResetPasswordWeb = new ResetPasswordWeb() { Password = "sleifjlisjf@24@", ConfirmPassword = "sleifjlisjf@24@" },
                    ExpireDate_Local = DateTime.Today.AddDays(1),
                    Email = LoginEmail,
                };

                if (!resetPasswordService.Add(resetPasswordNew))
                {
                    resetPassword.ValidationResults = resetPasswordNew.ValidationResults;
                    return false;
                }

                ts.Complete();
            }

            MailMessage mail = new MailMessage();
            mail.To.Clear();
            mail.To.Add(resetPasswordNew.Email);
            mail.From = new MailAddress(FromEmail);
            mail.Subject = CSSPServicesRes.RequiredInformationToChangeYourPassword;
            mail.Body = CSSPServicesRes.PlsUseFollowingUniqueCodeEtc
                + @"<br />"
                + @"<br />"
                + CSSPServicesRes.YourEmailIs + " " + resetPasswordNew.Email + @"<br />"
                + @"<br />"
                + CSSPServicesRes.CodeIs + " " + resetPasswordNew.Code + @"<br />"
                + @"<br />"
                + CSSPServicesRes.AutoEmailFromServer + @"<br />";
            mail.IsBodyHtml = true;

            retStr = SendEmail(mail);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(retStr) };
                return false;
            }

            return true;
        }
        public string SendEmail(MailMessage mail)
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "atlantic-exgate.Atlantic.int.ec.gc.ca";

            try
            {
                if (CanSendEmail)
                    smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                return string.Format(CSSPServicesRes.EmailWasNotSent_, (ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : ""));
            }

            return "";

            // Search
        }
        #endregion Functions public

        #region Functions private
        private IQueryable<Contact> FillContactReport(IQueryable<Contact> contactQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ContactTitleEnumList = enums.GetEnumTextOrderedList(typeof(ContactTitleEnum));

            contactQuery = (from c in contactQuery
                            let ContactTVText = (from cl in db.TVItemLanguages
                                                 where cl.TVItemID == c.ContactTVItemID
                                                 && cl.Language == LanguageRequest
                                                 select cl.TVText).FirstOrDefault()
                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                            let ParentTVItemID = (from cl in db.TVItems
                                                  where cl.TVItemID == c.ContactTVItemID
                                                  select cl.ParentID).FirstOrDefault()
                            select new Contact
                            {
                                ContactID = c.ContactID,
                                Id = c.Id,
                                ContactTVItemID = c.ContactTVItemID,
                                LoginEmail = c.LoginEmail,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Initial = c.Initial,
                                WebName = c.WebName,
                                ContactTitle = c.ContactTitle,
                                IsAdmin = c.IsAdmin,
                                EmailValidated = c.EmailValidated,
                                Disabled = c.Disabled,
                                IsNew = c.IsNew,
                                SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                ContactWeb = new ContactWeb
                                {
                                    ContactTVText = ContactTVText,
                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                    ParentTVItemID = ParentTVItemID,
                                    ContactTitleText = (from e in ContactTitleEnumList
                                                        where e.EnumID == (int?)c.ContactTitle
                                                        select e.EnumText).FirstOrDefault(),
                                },
                                ContactReport = new ContactReport
                                {
                                    ContactReportTest = "ContactReportTest",
                                },
                                HasErrors = false,
                                ValidationResults = null,
                            });

            return contactQuery;
        }
        #endregion Functions private

    }
}
