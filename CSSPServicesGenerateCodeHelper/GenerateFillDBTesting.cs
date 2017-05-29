using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateFillDBTesting
    {
        #region Variables
        #endregion Variables

        #region Properties
        private string DLLFileName { get; set; }
        private RichTextBox RichTextBoxStatus { get; set; }
        private Label LabelStatus { get; set; }
        private string GenerateFilePath { get; set; }
        #endregion Properties

        #region Constructors
        public GenerateFillDBTesting(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
        {
            this.DLLFileName = DLLFileName;
            this.RichTextBoxStatus = richTextBoxStatus;
            this.LabelStatus = lblStatus;
            this.GenerateFilePath = GenerateFilePath;
        }
        #endregion Constructors

        #region Functions private
        public void GenerateCodeOf__FillDBTestGenerated()
        {
            StringBuilder sb = new StringBuilder();

            FileInfo fiDLL = new FileInfo(DLLFileName);

            if (!fiDLL.Exists)
            {
                RichTextBoxStatus.AppendText(fiDLL.FullName + " does not exist");
                return;
            }
            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();

            RichTextBoxStatus.Text = "";

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
            sb.AppendLine(@"namespace CSSPServices.Tests");
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

                LabelStatus.Text = TypeName;
                LabelStatus.Refresh();
                Application.DoEvents();

                if (TypeName.StartsWith("<") || TypeName.StartsWith("ModelsRes") || TypeName.StartsWith("Application") || TypeName.StartsWith("CSSPWebToolsDBContext"))
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

                LabelStatus.Text = TypeName;
                LabelStatus.Refresh();
                Application.DoEvents();

                if (TypeName.StartsWith("<") || TypeName.StartsWith("ModelsRes") || TypeName.StartsWith("Application") || TypeName.StartsWith("CSSPWebToolsDBContext"))
                {
                    continue;
                }

                sb.AppendLine(@"            " + TypeNameLower + "Service = new " + TypeName + "Service(LanguageRequest, User, DatabaseTypeEnum.MemoryWithDBShape);");
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
            sb.AppendLine(@"            SetupTestHelper(LoginEmail, new CultureInfo(""en-CA""));");
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
            sb.AppendLine(@"            // Adding First AspNetUser Object");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            AspNetUser aspNetUser = new AspNetUser();");
            sb.AppendLine(@"            aspNetUser.UserName = ""Charles.LeBlanc2@canada.ca"";");
            sb.AppendLine(@"            aspNetUser.Email = ""Charles.LeBlanc2@canada.ca"";");
            sb.AppendLine(@"            aspNetUser.Password = GetRandomPassword();");
            sb.AppendLine(@"            aspNetUser.Id = GetRandomString("""", 30);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            aspNetUserService.Add(aspNetUser);");
            sb.AppendLine(@"            Assert.AreEqual(1, aspNetUserService.GetRead().Count());");
            sb.AppendLine(@"            Assert.AreEqual(0, aspNetUser.ValidationResults.Count());");
            sb.AppendLine(@"            Assert.AreEqual(aspNetUser.UserName, aspNetUserService.GetRead().First().UserName);");
            sb.AppendLine(@"            Assert.AreEqual(aspNetUser.Email, aspNetUserService.GetRead().First().Email);");
            sb.AppendLine(@"            Assert.AreEqual(aspNetUser.Id, aspNetUserService.GetRead().First().Id);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // Adding First Contact Object");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Contact contact = new Contact();");
            sb.AppendLine(@"            contact.FirstName = ""Charles"";");
            sb.AppendLine(@"            contact.Initial = ""G"";");
            sb.AppendLine(@"            contact.LastName = ""LeBlanc"";");
            sb.AppendLine(@"            contact.Id = aspNetUser.Id;");
            sb.AppendLine(@"            contact.WebName = GetRandomString("""", 20);");
            sb.AppendLine(@"            contact.LoginEmail = aspNetUser.Email;");
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
            sb.AppendLine(@"            Assert.AreEqual(TVTypeEnum.Contact, tvItemRoot.TVType);");
            sb.AppendLine(@"            Assert.AreEqual(1, tvItemTestContact.ParentID);");
            sb.AppendLine(@"            Assert.AreEqual(2, tvItemTestContact.TVItemID);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            //FileInfo fiOutputGen = new FileInfo(textBoxBaseDir.Text + textBoxFile1ToGenerate.Text + "_FillDBAllTestGenerated.cs");
            FileInfo fiOutputGen = new FileInfo(GenerateFilePath + "_FillDBAllTestGenerated.cs");
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
            }

            RichTextBoxStatus.AppendText("Created [" + fiOutputGen.FullName + "] ...\r\n");

            LabelStatus.Text = "Done ...";
        }
        #endregion Functions private
    }
}
