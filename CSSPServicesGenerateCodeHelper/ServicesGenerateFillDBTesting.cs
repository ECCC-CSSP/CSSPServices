﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesGenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Functions private
        public void GenerateCodeOf__FillDBTestGenerated()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fiDLL = new FileInfo(servicesFiles.CSSPModelsDLL);

            if (!fiDLL.Exists)
            {
                ErrorEvent(new ErrorEventArgs(fiDLL.FullName + " does not exist"));
                return;
            }
            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();

            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using CSSPModels;");
            sb.AppendLine(@"using CSSPServices;");
            sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
            sb.AppendLine(@"using System.Reflection;");
            sb.AppendLine(@"using CSSPEnums;");
            sb.AppendLine(@"using System.Security.Principal;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using CSSPServices.Resources;");
            sb.AppendLine(@"using CSSPModels.Resources;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPServicesFillDB.Tests");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    [TestClass]");
            sb.AppendLine(@"    public partial class FillDBTest : TestHelper");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        #region Variables");
            sb.AppendLine(@"        #endregion Variables");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Properties");
            sb.AppendLine(@"        public List<LanguageEnum> AllowableLanguageList { get; set; }");

            foreach (Type type in types)
            {
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = type.Name.Substring(0, 4).ToLower() + type.Name.Substring(4);
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = type.Name.Substring(0, 2).ToLower() + type.Name.Substring(2);
                }
                else
                {
                    TypeNameLower = type.Name.Substring(0, 1).ToLower() + type.Name.Substring(1);
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                sb.AppendLine(@"        " + TypeName + "Service " + TypeNameLower + "Service { get; set; }");
            }
            sb.AppendLine(@"        #endregion Properties");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Constructors");
            sb.AppendLine(@"        public FillDBTest() : base()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            AllowableLanguageList = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };");
            foreach (Type type in types)
            {
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = type.Name.Substring(0, 4).ToLower() + type.Name.Substring(4);
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = type.Name.Substring(0, 2).ToLower() + type.Name.Substring(2);
                }
                else
                {
                    TypeNameLower = type.Name.Substring(0, 1).ToLower() + type.Name.Substring(1);
                }

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                Application.DoEvents();

                if (TypeName.StartsWith("<") || TypeName.StartsWith("ModelsRes") || TypeName.StartsWith("Application") || TypeName.StartsWith("CSSPWebToolsDBContext"))
                {
                    continue;
                }

                sb.AppendLine(@"            " + TypeNameLower + "Service = new " + TypeName + "Service(LanguageRequest, ContactID, DatabaseTypeEnum.MemoryTestDB);");
            }
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Constructors");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Functions public");
            sb.AppendLine(@"        #endregion Functions public");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Functions private");
            sb.AppendLine(@"        #endregion Functions private");
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Tests Generated");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine(@"        public void FillDBTestAll()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            // should also run this test with CultureInfo(""fr-CA"")");
            sb.AppendLine(@"            SetupTestHelper(new CultureInfo(""en-CA""));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // Adding First TVItem Object");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            TVItem tvItemRoot = new TVItem();");
            sb.AppendLine(@"            tvItemService.AddRoot(tvItemRoot);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemService.GetRead().Count());");
            sb.AppendLine(@"            Assert.AreEqual(2, tvItemLanguageService.GetRead().Count());");
            sb.AppendLine(@"            Assert.AreEqual(""p1"", tvItemRoot.TVPath);");
            sb.AppendLine(@"            Assert.AreEqual(0, tvItemRoot.TVLevel);");
            sb.AppendLine(@"            Assert.AreEqual(TVTypeEnum.Root, tvItemRoot.TVType);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemRoot.ParentID);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemRoot.TVItemID);");
            sb.AppendLine(@"            Assert.AreEqual(LanguageEnum.en, tvItemRoot.TVItemLanguages.First().Language);");
            sb.AppendLine(@"            Assert.AreEqual(ServicesRes.Root, tvItemRoot.TVItemLanguages.First().TVText);");
            sb.AppendLine(@"            Assert.AreEqual(tvItemRoot.TVItemID, tvItemRoot.TVItemLanguages.First().TVItemID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // Adding First Contact Object");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            byte[] PasswordHash;");
            sb.AppendLine(@"            byte[] PasswordSalt;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Register register = new Register();");
            sb.AppendLine(@"            register.LoginEmail = ""Charles.LeBlanc2@canada.ca"";");
            sb.AppendLine(@"            register.FirstName = ""Charles"";");
            sb.AppendLine(@"            register.Initial = ""G"";");
            sb.AppendLine(@"            register.LastName = ""LeBlanc"";");
            sb.AppendLine(@"            register.WebName = GetRandomString("""", 20);");
            sb.AppendLine(@"            register.Password = ""aaaaaaaaaa2!"";");
            sb.AppendLine(@"            register.ConfirmPassword = register.Password;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Contact contact = new Contact();");
            sb.AppendLine(@"            contact.FirstName = ""Charles"";");
            sb.AppendLine(@"            contact.Initial = ""G"";");
            sb.AppendLine(@"            contact.LastName = ""LeBlanc"";");
            sb.AppendLine(@"            contact.WebName = GetRandomString("""", 20);");
            sb.AppendLine(@"            contact.LoginEmail = ""Charles.LeBlanc2@canada.ca"";");
            sb.AppendLine(@"            contact.LastUpdateDate_UTC = DateTime.UtcNow;");
            sb.AppendLine(@"            contact.LastUpdateContactTVItemID = 1;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            contactService.AddContact(contact, ContactService.AddContactType.First);");
            sb.AppendLine(@"            Assert.AreEqual(1, contactService.GetRead().Count());");
            sb.AppendLine(@"            Assert.AreEqual(0, contact.ValidationResults.Count());");
            sb.AppendLine(@"            Assert.AreEqual(contact.FirstName, contactService.GetRead().FirstOrDefault().FirstName);");
            sb.AppendLine(@"            Assert.AreEqual(contact.Initial, contactService.GetRead().FirstOrDefault().Initial);");
            sb.AppendLine(@"            Assert.AreEqual(contact.LastName, contactService.GetRead().FirstOrDefault().LastName);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            TVItem tvItemTestContact = tvItemService.GetRead().Where(c => c.TVItemID == contact.ContactTVItemID).FirstOrDefault();");
            sb.AppendLine(@"            Assert.AreEqual(""p1p"" + contact.ContactTVItemID, tvItemTestContact.TVPath);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemTestContact.TVLevel);");
            sb.AppendLine(@"            Assert.AreEqual(TVTypeEnum.Contact, tvItemTestContact.TVType);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemTestContact.ParentID);");
            sb.AppendLine(@"            Assert.AreEqual(2, tvItemTestContact.TVItemID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            ContactLogin contactLogin = new ContactLogin();");
            sb.AppendLine(@"            contactLogin.ContactID = contact.ContactID;");
            sb.AppendLine(@"            contactLogin.LoginEmail = contact.LoginEmail;");
            sb.AppendLine(@"            contactLogin.Password = register.Password;");
            sb.AppendLine(@"            contactLogin.ConfirmPassword = contactLogin.Password;");
            sb.AppendLine(@"            contactLogin.PasswordHash = PasswordHash;");
            sb.AppendLine(@"            contactLogin.PasswordSalt = PasswordSalt;");
            sb.AppendLine(@"            contactLogin.LastUpdateDate_UTC = DateTime.UtcNow;");
            sb.AppendLine(@"            contactLogin.LastUpdateContactTVItemID = contact.ContactTVItemID;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Assert.IsTrue(contactLoginService.Add(contactLogin));");
            sb.AppendLine(@"            Assert.AreEqual(0, contactLogin.ValidationResults.Count());");
            sb.AppendLine(@"            Assert.AreEqual(contact.ContactID, contactLogin.ContactID);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            //FileInfo fiOutputGen = new FileInfo(textBoxBaseDir.Text + textBoxFile1ToGenerate.Text + "_FillDBAllTestGenerated.cs");
            FileInfo fiOutputGen = new FileInfo(servicesFiles.BaseDir + servicesFiles.BaseDirFillDBTest + "_FillDBAllTestGenerated.cs");
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
            }

            ErrorEvent(new ErrorEventArgs("Created [" + fiOutputGen.FullName + "] ..."));

            StatusTempEvent(new StatusEventArgs("Done ..."));
        }
        #endregion Functions private
    }
}