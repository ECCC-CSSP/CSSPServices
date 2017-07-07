using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateClassServicesTest : GenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private string DLLFileName { get; set; }
        private RichTextBox RichTextBoxStatus { get; set; }
        private Label LabelStatus { get; set; }
        private string GenerateFilePath { get; set; }
        #endregion Properties

        #region Constructors
        public GenerateClassServicesTest(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
        {
            db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryNoDBShape);
            this.DLLFileName = DLLFileName;
            this.RichTextBoxStatus = richTextBoxStatus;
            this.LabelStatus = lblStatus;
            this.GenerateFilePath = GenerateFilePath;
        }
        #endregion Constructors

        #region Functions private
        private void CreateClass_CRUD_Testing(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"            " + TypeName + @" " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
            }
            else
            {
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
            }
            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.GetRead().Where(c => c == " + TypeNameLower + @").Any());");
            PropertyInfo propertyInfo = type.GetProperties().Where(c => c.Name == "LastUpdateContactTVItemID").FirstOrDefault();
            if (propertyInfo == null)
            {
                propertyInfo = type.GetProperties().Skip(1).Take(1).FirstOrDefault();
            }

            if (propertyInfo != null && entityType != null)
            {
                IProperty entProp = entityType.GetProperties().Where(c => c.Name == propertyInfo.Name).FirstOrDefault();

                switch (propertyInfo.PropertyType.FullName)
                {
                    case "System.Int32":
                    case "System.Int64":
                        {
                            int? Min = GetEntityValueInt(entProp, "Range", 0);
                            int? Max = GetEntityValueInt(entProp, "Range", 1);

                            if (Min != null && Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomInt(" + Min.ToString() + @", " + Max.ToString() + @");");
                            }
                            else if (Min != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomInt(" + Min.ToString() + @", " + (Min + 10).ToString() + @");");
                            }
                            else if (Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomInt(" + (Max - 10).ToString() + @", " + Max.ToString() + @");");
                            }
                            else
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomInt(1, 1000);");
                            }
                        }
                        break;
                    case "System.String":
                        {
                            int? Min = GetEntityValueInt(entProp, "Range", 0);
                            int? Max = GetEntityValueInt(entProp, "Range", 1);

                            if (Min != null && Max != null)
                            {
                                int NumberOfCharacter = (int)Min + 3;
                                if (NumberOfCharacter > Max)
                                {
                                    NumberOfCharacter = (int)Max;
                                }
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomString("""", " + NumberOfCharacter.ToString() + @");");
                            }
                            else if (Min != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomString("""", " + (Min + 3).ToString() + @");");
                            }
                            else if (Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomString("""", " + (Max - 3).ToString() + @");");
                            }
                            else
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + propertyInfo.Name + @" = GetRandomString("""", 5);");
                            }
                        }
                        break;
                    default:
                        {
                            sb.AppendLine(@"            //Need To Implement " + propertyInfo.Name + @" Of Type " + propertyInfo.PropertyType.FullName);
                            sb.AppendLine(@"            ImplementLineAbove = 1;");
                        }
                        break;
                }
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Update(" + TypeNameLower + @"));");
                sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @"Service.GetRead().Count());");
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
            }
            else
            {
                sb.AppendLine(@"            NeedToFindAValueToChangeForUpdateForClass_" + type.Name + ";");
            }
        }
        private void CreateClass_Min_And_Max_Properties_Testing(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(prop, entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (TypeName.StartsWith("AspNet"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine(@"");
                            sb.AppendLine(@"            //-----------------------------------");
                            sb.AppendLine(@"            // doing property [" + prop.Name + "] of type [" + entityProp.PropType + "]");
                            sb.AppendLine(@"            //-----------------------------------");
                            switch (entityProp.PropType)
                            {
                                case "int":
                                    {
                                        int? Min = GetEntityValueInt(entProp, "Range", 0);
                                        int? Max = GetEntityValueInt(entProp, "Range", 1);

                                        if (!entityProp.IsKey)
                                        {
                                            sb.AppendLine(@"");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                            if (Min != null && Max != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + Min.ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + Min.ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min + 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Min + 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Min + 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min - 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Min - 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Min - 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + Max.ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + Max.ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Max - 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Max - 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Max + 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Max + 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                            }
                                            else if (Min != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + Min.ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + Min.ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min + 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Min + 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Min + 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min - 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Min - 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Min - 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                            }
                                            else if (Max != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + Max.ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + Max.ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Max - 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Max - 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + (Max + 1).ToString() + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + (Max + 1).ToString() + ", " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                            }
                                        }
                                    }
                                    break;
                                case "float":
                                    {
                                        float? Min = GetEntityValueFloat(entProp, "Range", 0);
                                        float? Max = GetEntityValueFloat(entProp, "Range", 1);

                                        if (!entityProp.IsKey)
                                        {
                                            sb.AppendLine(@"");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                            if (Min != null && Max != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)Min).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)Min).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min + 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Min + 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Min - 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Min - 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)Max).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)Max).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Max - 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Max + 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                            }
                                            else if (Min != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)Min).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)Min).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min + 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Min + 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [" + Min + "] and Max [empty]. At Min - 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Min - 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                            }
                                            else if (Max != null)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)Max).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)Max).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Max - 1)).ToString("F1") + "f;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"            // " + prop.Name + @" has Min [empty] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + ((float)(Max + 1)).ToString("F1") + ";");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + Max.ToString() + @""")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                            }
                                        }
                                    }
                                    break;
                                case "bool":
                                    {
                                        // nothing
                                    }
                                    break;
                                case "DateTime":
                                case "DateTimeOffset":
                                    {
                                        // nothing
                                    }
                                    break;
                                case "string":
                                    {
                                        int? Min = GetEntityValueInt(entProp, "Range", 0);

                                        if (!entityProp.IsKey)
                                        {
                                            sb.AppendLine(@"");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                            if (Min != null && entityProp.MaxLength > 0)
                                            {
                                                sb.AppendLine(@"");
                                                sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Min should return true and no errors");
                                                if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + Min.ToString() + ");");
                                                }
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                if (Min + 1 < entityProp.MaxLength)
                                                {
                                                    sb.AppendLine(@"");
                                                    sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Min + 1 should return true and no errors");
                                                    if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (Min + 1).ToString() + ");");
                                                    }
                                                    sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                    if (TypeName == "Contact")
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                    }
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                }

                                                if (Min - 1 > 0)
                                                {
                                                    if (!(prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName")))
                                                    {
                                                        sb.AppendLine(@"");
                                                        sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Min - 1 should return false with one error");
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (Min - 1).ToString() + ");");
                                                        sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                        if (TypeName == "Contact")
                                                        {
                                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                        }
                                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + entityProp.MaxLength.ToString() + @""")).Any());");
                                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                    }
                                                }

                                                sb.AppendLine(@"");
                                                sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Max should return true and no errors");
                                                if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                {
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + entityProp.MaxLength.ToString() + ");");
                                                }
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                if (entityProp.MaxLength - 1 > 0 && entityProp.MaxLength - 1 > Min)
                                                {
                                                    sb.AppendLine(@"");
                                                    sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Max - 1 should return true and no errors");
                                                    if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (entityProp.MaxLength - 1).ToString() + ");");
                                                    }
                                                    sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                    if (TypeName == "Contact")
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                    }
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                }

                                                if (!(prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName")))
                                                {
                                                    sb.AppendLine(@"");
                                                    sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [" + entityProp.MaxLength + "]. At Max + 1 should return false with one error");
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (entityProp.MaxLength + 1).ToString() + ");");
                                                    sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                    if (TypeName == "Contact")
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                    }
                                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""", """ + entityProp.MaxLength.ToString() + @""")).Any());");
                                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                }
                                            }
                                            else if (Min != null)
                                            {
                                                sb.AppendLine(@"");
                                                sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min should return true and no errors");
                                                if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + Min.ToString() + ");");
                                                }
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                sb.AppendLine(@"");
                                                sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min + 1 should return true and no errors");
                                                if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                {
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (Min + 1).ToString() + ");");
                                                }
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                if (Min - 1 > 0)
                                                {
                                                    if (!(prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName")))
                                                    {
                                                        sb.AppendLine(@"");
                                                        sb.AppendLine(@"            // " + prop.Name + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min - 1 should return false with one error");
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (Min - 1).ToString() + ");");
                                                        sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                        if (TypeName == "Contact")
                                                        {
                                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                        }
                                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + Min.ToString() + @""")).Any());");
                                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                    }
                                                }
                                            }
                                            else if (entityProp.MaxLength > 0)
                                            {
                                                sb.AppendLine(@"");
                                                sb.AppendLine(@"            // " + prop.Name + @" has MinLength [empty] and MaxLength [" + entityProp.MaxLength + "]. At Max should return true and no errors");
                                                if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            string " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + entityProp.MaxLength.ToString() + ");");
                                                }
                                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                                if (entityProp.MaxLength - 1 > 0)
                                                {
                                                    sb.AppendLine(@"");
                                                    sb.AppendLine(@"            // " + prop.Name + @" has MinLength [empty] and MaxLength [" + entityProp.MaxLength + "]. At Max - 1 should return true and no errors");
                                                    if (prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName"))
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomEmail();");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (entityProp.MaxLength - 1).ToString() + ");");
                                                    }
                                                    sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                    if (TypeName == "Contact")
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                    }
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                }

                                                if (!(prop.Name.Contains("Email") || (TypeName == "Contact" && prop.Name == "UserName")))
                                                {
                                                    sb.AppendLine(@"");
                                                    sb.AppendLine(@"            // " + prop.Name + @" has MinLength [empty] and MaxLength [" + entityProp.MaxLength + "]. At Max + 1 should return false with one error");
                                                    sb.AppendLine(@"            " + TypeNameLower + prop.Name + @"Min = GetRandomString("""", " + (entityProp.MaxLength + 1).ToString() + ");");
                                                    sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + prop.Name + @"Min;");
                                                    if (TypeName == "Contact")
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                    }
                                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + entityProp.MaxLength.ToString() + @""")).Any());");
                                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + prop.Name + @"Min, " + TypeNameLower + @"." + prop.Name + @");");
                                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                }
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
        }
        private void CreateClass_Required_Properties_Testing(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(prop, entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (TypeName.StartsWith("AspNet"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            switch (entityProp.PropType)
                            {
                                case "int":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            sb.AppendLine(@"            // " + prop.Name + @" will automatically be initialized at 0 --> not null");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                case "float":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            if (!entityProp.IsKey && entityProp.IsRequired)
                                            {
                                                sb.AppendLine(@"            // " + prop.Name + @" will automatically be initialized at 0.0f --> not null");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                    }
                                    break;
                                case "bool":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            sb.AppendLine(@"            // " + prop.Name + @" will automatically be initialized at false --> not null");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                case "DateTime":
                                case "DateTimeOffset":
                                    if (!entityProp.IsKey && entityProp.IsRequired)
                                    {
                                        sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                        sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + prop.Name + @""");");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @")).Any());");
                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @"." + prop.Name + @".Year < 1900);");
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                        sb.AppendLine(@"");
                                    }
                                    break;
                                case "string":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                            sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + prop.Name + @""");");
                                            if (TypeName == "Contact")
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                            }
                                            sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                                            sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @")).Any());");
                                            sb.AppendLine(@"            Assert.AreEqual(null, " + TypeNameLower + @"." + prop.Name + @");");
                                            sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        if (prop.PropertyType.FullName.Contains("Enum"))
                                        {
                                            if (!entityProp.IsKey && entityProp.IsRequired)
                                            {
                                                sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                                sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + prop.Name + @""");");
                                                if (TypeName == "Contact")
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                                }
                                                sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                                                sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @")).Any());");
                                                sb.AppendLine(@"            Assert.AreEqual(" + entityProp.PropType + ".Error, " + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            //Error: Type not implemented [" + entityProp.PropName + "]");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
        private void CreateGetFilledRandomClass(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private " + TypeName + @" GetFilledRandom" + TypeName + @"(string OmitPropName)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            " + TypeName + @"ID += 1;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            " + TypeName + " " + TypeNameLower + @" = new " + TypeName + @"();");
            sb.AppendLine(@"");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(prop, entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        switch (entityProp.PropType)
                        {
                            case "int":
                                {
                                    if (entityProp.IsKey)
                                    {
                                        if (type.Name == "AspNetUserClaim")
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = AspNetUserClaimID; ");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + prop.Name + @";");
                                        }
                                    }
                                    else
                                    {
                                        if (entityProp.MinInt != null && entityProp.MaxInt != null)
                                        {
                                            if (entityProp.MinInt > entityProp.MaxInt)
                                            {
                                                sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + entityProp.MinInt.ToString() + ", " + entityProp.MaxInt.ToString() + ");");
                                            }
                                        }
                                        else if (entityProp.MinInt != null)
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + entityProp.MinInt.ToString() + ", " + (entityProp.MinInt + 10).ToString() + ");");
                                        }
                                        else if (entityProp.MaxInt != null)
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + (entityProp.MaxInt - 10).ToString() + ", " + entityProp.MaxInt.ToString() + ");");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(1, 1000);");
                                        }
                                    }
                                }
                                break;
                            case "float":
                                {
                                    if (entityProp.MinFloat != null && entityProp.MaxFloat != null)
                                    {
                                        if (entityProp.MinFloat > entityProp.MaxFloat)
                                        {
                                            sb.AppendLine(@"            " + prop.Name + @" = Custom_MinLengthBiggerCustom_MaxLengthPleaseFix,");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + entityProp.MinFloat.ToString() + ", " + entityProp.MaxFloat.ToString() + ");");
                                        }
                                    }
                                    else if (entityProp.MinFloat != null)
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + entityProp.MinFloat.ToString() + ", " + (entityProp.MinFloat + 10.0f).ToString() + ");");
                                    }
                                    else if (entityProp.MaxFloat != null)
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + (entityProp.MaxFloat - 10.0f).ToString() + ", " + entityProp.MaxFloat.ToString() + ");");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(1.0f, 1000.0f);");
                                    }
                                }
                                break;
                            case "double":
                                {
                                    if (entityProp.MinFloat != null && entityProp.MaxFloat != null)
                                    {
                                        if (entityProp.MinFloat > entityProp.MaxFloat)
                                        {
                                            sb.AppendLine(@"            " + prop.Name + @" = Custom_MinLengthBiggerCustom_MaxLengthPleaseFix,");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + entityProp.MinFloat.ToString() + ", " + entityProp.MaxFloat.ToString() + ");");
                                        }
                                    }
                                    else if (entityProp.MinFloat != null)
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + entityProp.MinFloat.ToString() + ", " + (entityProp.MinFloat + 10.0f).ToString() + ");");
                                    }
                                    else if (entityProp.MaxFloat != null)
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + (entityProp.MaxFloat - 10.0f).ToString() + ", " + entityProp.MaxFloat.ToString() + ");");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(1.0f, 1000.0f);");
                                    }
                                }
                                break;
                            case "DateTime":
                            case "DateTimeOffset":
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDateTime();");
                                }
                                break;
                            case "bool":
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = true;");
                                }
                                break;
                            case "string":
                                {
                                    if (prop.Name.Contains("Email") || (TypeName == "AspNetUser" && prop.Name == "UserName"))
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        if (entityProp.MinInt != null && entityProp.MaxLength > 0)
                                        {
                                            if (entityProp.MinInt > entityProp.MaxLength)
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = MinBiggerMaxLengthPleaseFix;");
                                            }
                                            else
                                            {
                                                int? StrLen = (int)entityProp.MinInt + 5;
                                                if (StrLen > entityProp.MaxLength)
                                                {
                                                    StrLen = entityProp.MaxLength;
                                                }
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                                            }
                                        }
                                        else if (entityProp.MinInt != null)
                                        {
                                            int StrLen = (int)entityProp.MinInt + 5;
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                                        }
                                        else if (entityProp.MaxLength > 0)
                                        {
                                            int? StrLen = 5;
                                            if (StrLen > entityProp.MaxLength)
                                            {
                                                StrLen = entityProp.MaxLength;
                                            }
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 20);");
                                        }
                                    }
                                }
                                break;
                            default:
                                {
                                    if (prop.PropertyType.FullName.Contains("Enum"))
                                    {
                                        if (prop.PropertyType.FullName.Contains("LanguageEnum"))
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = language;");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + entityProp.PropType + @")GetRandomEnumType(typeof(" + entityProp.PropType + "));");
                                        }
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            //Error: Type not implemented [" + entityProp.PropName + "]");
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        WritePropNotMapped(prop, TypeName, TypeNameLower, sb);
                    }
                }
                else
                {
                    WritePropNotMapped(prop, TypeName, TypeNameLower, sb);
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"            return " + TypeNameLower + @";");
            sb.AppendLine(@"        }");
        }
        private void WritePropGetRandom(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb, int? MinInt, int? MaxInt, float? MinFloat, float? MaxFloat, bool? Required)
        {
            if (prop.PropertyType.FullName.Contains("System.String"))
            {
                if (prop.Name.Contains("Email"))
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomEmail();");
                }
                else
                {
                    if (MinInt != null && MaxInt != null)
                    {
                        if (TypeName == "ResetPassword" && prop.Name == "ConfirmPassword")
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + @".Password;");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MinInt.ToString() + @");");
                        }
                    }
                    else if (MinInt != null)
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MinInt.ToString() + @");");
                    }
                    else if (MaxInt != null)
                    {
                        if (MaxInt < 5)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MaxInt.ToString() + @");");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 5);");
                        }
                    }
                    else
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 5);");
                    }
                }
            }
            else if (prop.PropertyType.FullName.Contains("System.Boolean"))
            {
                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = true;");
            }
            else if (prop.PropertyType.FullName.Contains("System.Int32"))
            {
                if (MinInt != null && MaxInt != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + MinInt.ToString() + @", " + MaxInt.ToString() + @");");
                }
                else if (MinInt != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + MinInt.ToString() + @", " + (MinInt + 10).ToString() + @");");
                }
                else if (MaxInt != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + (MaxInt - 10).ToString() + @", " + MaxInt.ToString() + @");");
                }
                else
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(1, 5);");
                }
            }
            else if (prop.PropertyType.FullName.Contains("System.Single"))
            {
                if (MinFloat != null && MaxFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + MinFloat.ToString() + @", " + MaxFloat.ToString() + @");");
                }
                else if (MinFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + MinFloat.ToString() + @", " + (MinFloat + 10.0f).ToString() + @");");
                }
                else if (MaxFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + (MaxFloat - 10.0f).ToString() + @", " + MaxFloat.ToString() + @");");
                }
                else
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(1.0f, 5.0f);");
                }
            }
            else if (prop.PropertyType.FullName.Contains("System.Double"))
            {
                if (MinFloat != null && MaxFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + MinFloat.ToString() + @", " + MaxFloat.ToString() + @");");
                }
                else if (MinFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + MinFloat.ToString() + @", " + (MinFloat + 10.0f).ToString() + @");");
                }
                else if (MaxFloat != null)
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + (MaxFloat - 10.0f).ToString() + @", " + MaxFloat.ToString() + @");");
                }
                else
                {
                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(1.0f, 5.0f);");
                }
            }
            else if (prop.PropertyType.FullName.Contains("System.DateTime"))
            {
                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDateTime();");
            }
            else
            {
                if (prop.PropertyType.FullName.Contains("Enum"))
                {
                    if (prop.PropertyType.FullName.Contains("LanguageEnum"))
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = language;");
                    }
                    else
                    {
                        string enumPropName = "";
                        if (prop.PropertyType.FullName.StartsWith("System.Nullable"))
                        {
                            enumPropName = prop.PropertyType.FullName.Substring(prop.PropertyType.FullName.IndexOf("[[") + 2);
                            enumPropName = enumPropName.Substring(enumPropName.IndexOf(".") + 1);
                            enumPropName = enumPropName.Substring(0, enumPropName.IndexOf(","));

                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + enumPropName + @")GetRandomEnumType(typeof(" + enumPropName + "));");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + prop.PropertyType.FullName + @")GetRandomEnumType(typeof(" + prop.PropertyType.FullName + "));");
                        }
                    }
                }
                else
                {
                    sb.AppendLine(@"            //Error: Type not implemented [" + prop.Name + "]");
                }
            }
        }
        private void WritePropNotMapped(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!prop.GetGetMethod().IsVirtual)
            {
                bool? Required = null;
                int? MinInt = null;
                int? MaxInt = null;
                float? MinFloat = null;
                float? MaxFloat = null;
                foreach (CustomAttributeData attr in prop.CustomAttributes)
                {
                    if (attr.AttributeType.Name == "RequiredAttribute")
                    {
                        Required = true;
                    }
                    if (attr.AttributeType.Name == "RangeAttribute")
                    {
                        if (prop.PropertyType.FullName.Contains("System.Int32") || prop.PropertyType.FullName.Contains("System.String"))
                        {
                            MinInt = ((int?)attr.ConstructorArguments[0].Value);
                            if (MinInt == -1)
                            {
                                MinInt = null;
                            }
                            MaxInt = ((int?)attr.ConstructorArguments[1].Value);
                            if (MaxInt == -1)
                            {
                                MaxInt = null;
                            }
                        }
                        else if (prop.PropertyType.FullName.Contains("System.Single"))
                        {
                            MinFloat = ((float?)((double)attr.ConstructorArguments[0].Value));
                            if (MinFloat == -1.0f)
                            {
                                MinFloat = null;
                            }
                            MaxFloat = ((float?)((double)attr.ConstructorArguments[1].Value));
                            if (MaxFloat == -1.0f)
                            {
                                MaxFloat = null;
                            }
                        }
                        else
                        {
                        }
                    }
                }

                if (prop.Name != "ValidationResults")
                {
                    WritePropGetRandom(prop, TypeName, TypeNameLower, sb, MinInt, MaxInt, MinFloat, MaxFloat, Required);
                }
            }
        }
        #endregion Functions private

        #region Functions private
        public void GenerateCodeOf_ClassTestGenerated()
        {
            FileInfo fiDLL = new FileInfo(DLLFileName);

            if (!fiDLL.Exists)
            {
                RichTextBoxStatus.AppendText(fiDLL.FullName + " does not exist");
                return;
            }

            RichTextBoxStatus.Text = "";

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;
                IEntityType entityType = null;

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

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                //if (TypeName != "AppTaskLanguage")
                //{
                //    continue;
                //}

                entityType = db.Model.GetEntityTypes().Where(c => c.Name == "CSSPModels." + TypeName).FirstOrDefault();

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
                sb.AppendLine(@"    public partial class " + TypeName + "Test : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine(@"        private int " + TypeName + "ID { get; set; }");
                sb.AppendLine(@"        private LanguageEnum language { get; set; }");
                sb.AppendLine(@"        private CultureInfo culture { get; set; }");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine(@"        public " + TypeName + "Test() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            language = LanguageEnum.en;");
                sb.AppendLine(@"            culture = new CultureInfo(language.ToString() + ""-CA"");");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Functions public");
                sb.AppendLine(@"        #endregion Functions public");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Functions private");

                CreateGetFilledRandomClass(entityType, type, TypeName, TypeNameLower, sb);

                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests Generated");
                sb.AppendLine(@"        [TestMethod]");
                sb.AppendLine(@"        public void " + TypeName + @"_Testing()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            SetupTestHelper(culture);");
                sb.AppendLine(@"            " + TypeName + @"Service " + TypeNameLower + @"Service = new " + TypeName + @"Service(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);");
                sb.AppendLine(@"");

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // CRUD testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    CreateClass_CRUD_Testing(entityType, type, TypeName, TypeNameLower, sb);
                    sb.AppendLine(@"");
                }

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // Required properties testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");

                CreateClass_Required_Properties_Testing(entityType, type, TypeName, TypeNameLower, sb);
                sb.AppendLine(@"");

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // Min and Max properties testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");

                CreateClass_Min_And_Max_Properties_Testing(entityType, type, TypeName, TypeNameLower, sb);
                sb.AppendLine(@"");

                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Tests Generated");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(GenerateFilePath + TypeName + "TestGenerated.cs");
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                RichTextBoxStatus.AppendText("Created [" + fiOutputGen.FullName + "] ...\r\n");

                LabelStatus.Text = "Done ...";
            }
        }
        #endregion Functions private
    }
}
