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
        #endregion Properties

        #region Constructors
        public GenerateClassServicesTest(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
            : base(DLLFileName, GenerateFilePath, richTextBoxStatus, lblStatus)
        {
        }
        #endregion Constructors

        #region Functions private
        private void CreateClass_CRUD_Testing(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
            }
            else
            {
                sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
            }
            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.GetRead().Where(c => c == " + TypeNameLower + @").Any());");
            PropertyInfo prop = type.GetProperties().Where(c => c.Name == "LastUpdateContactTVItemID").FirstOrDefault();
            if (prop == null)
            {
                prop = type.GetProperties().Skip(1).Take(1).FirstOrDefault();
            }

            if (prop != null)
            {
                CSSPModelsGenerateCodeHelper.CSSPProp csspProp = new CSSPModelsGenerateCodeHelper.CSSPProp();
                if (!ModelGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                {
                    return;
                }

                switch (csspProp.PropType)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                        {
                            int? Min = csspProp.MinInt;
                            int? Max = csspProp.MaxInt;

                            if (Min != null && Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + Min.ToString() + @", " + Max.ToString() + @");");
                            }
                            else if (Min != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + Min.ToString() + @", " + (Min + 10).ToString() + @");");
                            }
                            else if (Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + (Max - 10).ToString() + @", " + Max.ToString() + @");");
                            }
                            else
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(1, 1000);");
                            }
                        }
                        break;
                    case "String":
                        {
                            int? Min = csspProp.MinInt;
                            int? Max = csspProp.MaxInt;

                            if (Min != null && Max != null)
                            {
                                int NumberOfCharacter = (int)Min + 3;
                                if (NumberOfCharacter > Max)
                                {
                                    NumberOfCharacter = (int)Max;
                                }
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + NumberOfCharacter.ToString() + @");");
                            }
                            else if (Min != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + (Min + 3).ToString() + @");");
                            }
                            else if (Max != null)
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + (Max - 3).ToString() + @");");
                            }
                            else
                            {
                                sb.AppendLine(@"            " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 5);");
                            }
                        }
                        break;
                    default:
                        {
                            sb.AppendLine(@"            //Need To Implement " + prop.Name + @" Of Type " + csspProp.PropType);
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
        private void CreateClass_Min_And_Max_Properties_Testing(CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
                sb.AppendLine(@"");
                sb.AppendLine(@"            //-----------------------------------");
                sb.AppendLine(@"            // doing property [" + csspProp.PropName + "] of type [" + csspProp.PropType + "]");
                sb.AppendLine(@"            //-----------------------------------");
                switch (csspProp.PropType)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                        {
                            int? Min = csspProp.MinInt;
                            int? Max = csspProp.MaxInt;

                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                if (Min != null && Max != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + Min.ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + Min.ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min + 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Min + 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Min + 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min - 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Min - 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Min - 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + Max.ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + Max.ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Max - 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Max - 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Max + 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Max + 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                }
                                else if (Min != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + Min.ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + Min.ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min + 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Min + 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Min + 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min - 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Min - 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Min - 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                }
                                else if (Max != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + Max.ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + Max.ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Max - 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Max - 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + (Max + 1).ToString() + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + (Max + 1).ToString() + ", " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                }
                            }
                        }
                        break;
                    case "Single":
                        {
                            float? Min = csspProp.MinFloat;
                            float? Max = csspProp.MaxFloat;

                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                if (Min != null && Max != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)Min).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)Min).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min + 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Min + 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Min - 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Min - 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)Max).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)Max).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Max - 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Max + 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                }
                                else if (Min != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)Min).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)Min).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min + 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Min + 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [" + Min + "] and Max [empty]. At Min - 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Min - 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Min - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                }
                                else if (Max != null)
                                {
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)Max).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)Max).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max - 1 should return true and no errors");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Max - 1)).ToString("F1") + "f;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max - 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has Min [empty] and Max [" + Max + "]. At Max + 1 should return false with one error");
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + ((float)(Max + 1)).ToString("F1") + ";");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Max.ToString() + @""")).Any());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + ((float)(Max + 1)).ToString("F1") + "f, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                }
                            }
                        }
                        break;
                    case "Boolean":
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
                    case "String":
                        {
                            int? Min = csspProp.MinInt;
                            int? Max = csspProp.MaxInt;

                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                                sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                                if (Min != null && Max > 0)
                                {
                                    sb.AppendLine(@"");
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Min should return true and no errors");
                                    if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + Min.ToString() + ");");
                                    }
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    if (Min + 1 < Max)
                                    {
                                        sb.AppendLine(@"");
                                        sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Min + 1 should return true and no errors");
                                        if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Min + 1).ToString() + ");");
                                        }
                                        sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                    }

                                    if (Min - 1 > 0)
                                    {
                                        if (!(csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName")))
                                        {
                                            sb.AppendLine(@"");
                                            sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Min - 1 should return false with one error");
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Min - 1).ToString() + ");");
                                            sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                            if (TypeName == "Contact")
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                            }
                                            sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                            sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                            sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                        }
                                    }

                                    sb.AppendLine(@"");
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Max should return true and no errors");
                                    if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                    {
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + Max.ToString() + ");");
                                    }
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    if (Max - 1 > 0 && Max - 1 > Min)
                                    {
                                        sb.AppendLine(@"");
                                        sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Max - 1 should return true and no errors");
                                        if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Max - 1).ToString() + ");");
                                        }
                                        sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                    }

                                    if (!(csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName")))
                                    {
                                        sb.AppendLine(@"");
                                        sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [" + Max + "]. At Max + 1 should return false with one error");
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Max + 1).ToString() + ");");
                                        sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""", """ + Max.ToString() + @""")).Any());");
                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                    }
                                }
                                else if (Min != null)
                                {
                                    sb.AppendLine(@"");
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min should return true and no errors");
                                    if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + Min.ToString() + ");");
                                    }
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    sb.AppendLine(@"");
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min + 1 should return true and no errors");
                                    if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                    {
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Min + 1).ToString() + ");");
                                    }
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    if (Min - 1 > 0)
                                    {
                                        if (!(csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName")))
                                        {
                                            sb.AppendLine(@"");
                                            sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [" + Min + "] and MaxLength [empty]. At Min - 1 should return false with one error");
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Min - 1).ToString() + ");");
                                            sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                            if (TypeName == "Contact")
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                            }
                                            sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Min.ToString() + @""")).Any());");
                                            sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                            sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                        }
                                    }
                                }
                                else if (Max > 0)
                                {
                                    sb.AppendLine(@"");
                                    sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [empty] and MaxLength [" + Max + "]. At Max should return true and no errors");
                                    if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            string " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + Max.ToString() + ");");
                                    }
                                    sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                    if (TypeName == "Contact")
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                    }
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                    sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                    sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                    sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");

                                    if (Max - 1 > 0)
                                    {
                                        sb.AppendLine(@"");
                                        sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [empty] and MaxLength [" + Max + "]. At Max - 1 should return true and no errors");
                                        if (csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName"))
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomEmail();");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Max - 1).ToString() + ");");
                                        }
                                        sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @".ValidationResults.Count());");
                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
                                        sb.AppendLine(@"            Assert.AreEqual(true, " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @"));");
                                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                                    }

                                    if (!(csspProp.PropName.Contains("Email") || (TypeName == "Contact" && csspProp.PropName == "UserName")))
                                    {
                                        sb.AppendLine(@"");
                                        sb.AppendLine(@"            // " + csspProp.PropName + @" has MinLength [empty] and MaxLength [" + Max + "]. At Max + 1 should return false with one error");
                                        sb.AppendLine(@"            " + TypeNameLower + csspProp.PropName + @"Min = GetRandomString("""", " + (Max + 1).ToString() + ");");
                                        sb.AppendLine(@"            " + TypeNameLower + @"." + csspProp.PropName + @" = " + TypeNameLower + csspProp.PropName + @"Min;");
                                        if (TypeName == "Contact")
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                        }
                                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + Max.ToString() + @""")).Any());");
                                        sb.AppendLine(@"            Assert.AreEqual(" + TypeNameLower + csspProp.PropName + @"Min, " + TypeNameLower + @"." + csspProp.PropName + @");");
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
        private void CreateClass_Required_Properties_Testing(CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    {
                        if (!csspProp.IsKey && !csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            // " + csspProp.PropName + @" will automatically be initialized at 0 --> not null");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    if (!csspProp.IsKey && !csspProp.IsNullable)
                    {
                        sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                        sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + csspProp.PropName + @""");");
                        if (TypeName == "Contact")
                        {
                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                        }
                        else
                        {
                            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                        }
                        sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + csspProp.PropName + @")).Any());");
                        if (csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            Assert.IsTrue(((DateTime)" + TypeNameLower + @"." + csspProp.PropName + @").Year < 1900);");
                        }
                        else
                        {
                            sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @"." + csspProp.PropName + @".Year < 1900);");
                        }
                        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                        sb.AppendLine(@"");
                    }
                    break;
                case "String":
                    {
                        if (!csspProp.IsKey && !csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + csspProp.PropName + @""");");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                            }
                            else
                            {
                                sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                            }
                            sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                            sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + csspProp.PropName + @")).Any());");
                            sb.AppendLine(@"            Assert.AreEqual(null, " + TypeNameLower + @"." + csspProp.PropName + @");");
                            sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
                default:
                    {
                        //if (csspProp.PropType.Contains("Enum"))
                        //{
                        //    if (!entityProp.IsKey && entityProp.IsRequired)
                        //    {
                        //        sb.AppendLine(@"            " + TypeNameLower + @" = null;");
                        //        sb.AppendLine(@"            " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + prop.Name + @""");");
                        //        if (TypeName == "Contact")
                        //        {
                        //            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", ContactService.AddContactType.First));");
                        //        }
                        //        else
                        //        {
                        //            sb.AppendLine(@"            Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                        //        }
                        //        sb.AppendLine(@"            Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                        //        sb.AppendLine(@"            Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @")).Any());");
                        //        sb.AppendLine(@"            Assert.AreEqual(" + entityProp.PropType + ".Error, " + TypeNameLower + @"." + prop.Name + @");");
                        //        sb.AppendLine(@"            Assert.AreEqual(0, " + TypeNameLower + @"Service.GetRead().Count());");
                        //        sb.AppendLine(@"");
                        //    }
                        //}
                        //else
                        //{
                        sb.AppendLine(@"            //Error: Type not implemented [" + csspProp.PropName + "]");
                        sb.AppendLine(@"");
                        //}
                    }
                    break;
            }
        }
        private void CreateGetFilledRandomClass(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                    {
                        if (csspProp.IsKey)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + prop.Name + @";");
                        }
                        else
                        {
                            if (csspProp.MinInt != null && csspProp.MaxInt != null)
                            {
                                if (csspProp.MinInt > csspProp.MaxInt)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + csspProp.MinInt.ToString() + ", " + csspProp.MaxInt.ToString() + ");");
                                }
                            }
                            else if (csspProp.MinInt != null)
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + csspProp.MinInt.ToString() + ", " + (csspProp.MinInt + 10).ToString() + ");");
                            }
                            else if (csspProp.MaxInt != null)
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + (csspProp.MaxInt - 10).ToString() + ", " + csspProp.MaxInt.ToString() + ");");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(1, 1000);");
                            }
                        }
                    }
                    break;
                case "Single":
                    {
                        if (csspProp.MinFloat != null && csspProp.MaxFloat != null)
                        {
                            if (csspProp.MinFloat > csspProp.MaxFloat)
                            {
                                sb.AppendLine(@"            " + prop.Name + @" = Custom_MinLengthBiggerCustom_MaxLengthPleaseFix,");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + csspProp.MinFloat.ToString() + ".0f, " + csspProp.MaxFloat.ToString() + ".0f);");
                            }
                        }
                        else if (csspProp.MinFloat != null)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + csspProp.MinFloat.ToString() + ".0f, " + (csspProp.MinFloat + 10.0f).ToString() + ".0f);");
                        }
                        else if (csspProp.MaxFloat != null)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + (csspProp.MaxFloat - 10.0f).ToString() + ".0f, " + csspProp.MaxFloat.ToString() + ".0f);");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(1.0f, 1000.0f);");
                        }
                    }
                    break;
                case "Double":
                    {
                        if (csspProp.MinFloat != null && csspProp.MaxFloat != null)
                        {
                            if (csspProp.MinFloat > csspProp.MaxFloat)
                            {
                                sb.AppendLine(@"            " + prop.Name + @" = Custom_MinLengthBiggerCustom_MaxLengthPleaseFix,");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + csspProp.MinFloat.ToString() + ".0D, " + csspProp.MaxFloat.ToString() + ".0D);");
                            }
                        }
                        else if (csspProp.MinFloat != null)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + csspProp.MinFloat.ToString() + ".0D, " + (csspProp.MinFloat + 10.0D).ToString() + ".0D);");
                        }
                        else if (csspProp.MaxFloat != null)
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + (csspProp.MaxFloat - 10.0D).ToString() + ".0D, " + csspProp.MaxFloat.ToString() + ".0D);");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(1.0D, 1000.0D);");
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDateTime();");
                    }
                    break;
                case "Boolean":
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = true;");
                    }
                    break;
                case "String":
                    {
                        if (prop.Name.Contains("Email") || (TypeName == "AspNetUser" && prop.Name == "UserName"))
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.MinInt != null && csspProp.MaxLength > 0)
                            {
                                if (csspProp.MinInt > csspProp.MaxLength)
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    int? StrLen = (int)csspProp.MinInt + 5;
                                    if (StrLen > csspProp.MaxLength)
                                    {
                                        StrLen = csspProp.MaxLength;
                                    }
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                                }
                            }
                            else if (csspProp.MinInt != null)
                            {
                                int StrLen = (int)csspProp.MinInt + 5;
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                            }
                            else if (csspProp.MaxLength > 0)
                            {
                                int? StrLen = 5;
                                if (StrLen > csspProp.MaxLength)
                                {
                                    StrLen = csspProp.MaxLength;
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
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = language;");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + csspProp.PropType + @")GetRandomEnumType(typeof(" + csspProp.PropType + "));");
                            }
                        }
                        else
                        {
                            sb.AppendLine(@"            //Error: Type not implemented [" + csspProp.PropName + "]");
                        }
                    }
                    break;
            }
        }
        //private void WritePropGetRandom(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb, int? MinInt, int? MaxInt, float? MinFloat, float? MaxFloat, bool? Required)
        //{
        //    if (csspProp.PropType.Contains("System.String"))
        //    {
        //        if (prop.Name.Contains("Email"))
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomEmail();");
        //        }
        //        else
        //        {
        //            if (MinInt != null && MaxInt != null)
        //            {
        //                if (TypeName == "ResetPassword" && prop.Name == "ConfirmPassword")
        //                {
        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + TypeNameLower + @".Password;");
        //                }
        //                else
        //                {
        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MinInt.ToString() + @");");
        //                }
        //            }
        //            else if (MinInt != null)
        //            {
        //                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MinInt.ToString() + @");");
        //            }
        //            else if (MaxInt != null)
        //            {
        //                if (MaxInt < 5)
        //                {
        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", " + MaxInt.ToString() + @");");
        //                }
        //                else
        //                {
        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 5);");
        //                }
        //            }
        //            else
        //            {
        //                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 5);");
        //            }
        //        }
        //    }
        //    else if (csspProp.PropType.Contains("System.Boolean"))
        //    {
        //        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = true;");
        //    }
        //    else if (csspProp.PropType.Contains("System.Int32"))
        //    {
        //        if (MinInt != null && MaxInt != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + MinInt.ToString() + @", " + MaxInt.ToString() + @");");
        //        }
        //        else if (MinInt != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + MinInt.ToString() + @", " + (MinInt + 10).ToString() + @");");
        //        }
        //        else if (MaxInt != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(" + (MaxInt - 10).ToString() + @", " + MaxInt.ToString() + @");");
        //        }
        //        else
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomInt(1, 5);");
        //        }
        //    }
        //    else if (csspProp.PropType.Contains("System.Single"))
        //    {
        //        if (MinFloat != null && MaxFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + MinFloat.ToString() + @", " + MaxFloat.ToString() + @");");
        //        }
        //        else if (MinFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + MinFloat.ToString() + @", " + (MinFloat + 10.0f).ToString() + @");");
        //        }
        //        else if (MaxFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(" + (MaxFloat - 10.0f).ToString() + @", " + MaxFloat.ToString() + @");");
        //        }
        //        else
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomFloat(1.0f, 5.0f);");
        //        }
        //    }
        //    else if (csspProp.PropType.Contains("System.Double"))
        //    {
        //        if (MinFloat != null && MaxFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + MinFloat.ToString() + @", " + MaxFloat.ToString() + @");");
        //        }
        //        else if (MinFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + MinFloat.ToString() + @", " + (MinFloat + 10.0f).ToString() + @");");
        //        }
        //        else if (MaxFloat != null)
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(" + (MaxFloat - 10.0f).ToString() + @", " + MaxFloat.ToString() + @");");
        //        }
        //        else
        //        {
        //            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDouble(1.0f, 5.0f);");
        //        }
        //    }
        //    else if (csspProp.PropType.Contains("System.DateTime"))
        //    {
        //        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomDateTime();");
        //    }
        //    else
        //    {
        //        if (csspProp.PropType.Contains("Enum"))
        //        {
        //            if (csspProp.PropType.Contains("LanguageEnum"))
        //            {
        //                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = language;");
        //            }
        //            else
        //            {
        //                string enumPropName = "";
        //                if (csspProp.PropType.StartsWith("System.Nullable"))
        //                {
        //                    enumPropName = csspProp.PropType.Substring(csspProp.PropType.IndexOf("[[") + 2);
        //                    enumPropName = enumPropName.Substring(enumPropName.IndexOf(".") + 1);
        //                    enumPropName = enumPropName.Substring(0, enumPropName.IndexOf(","));

        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + enumPropName + @")GetRandomEnumType(typeof(" + enumPropName + "));");
        //                }
        //                else
        //                {
        //                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + csspProp.PropType + @")GetRandomEnumType(typeof(" + csspProp.PropType + "));");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            sb.AppendLine(@"            //Error: Type not implemented [" + prop.Name + "]");
        //        }
        //    }
        //}
        //private void WritePropNotMapped(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb)
        //{
        //    if (!prop.GetGetMethod().IsVirtual)
        //    {
        //        bool? Required = null;
        //        int? MinInt = null;
        //        int? MaxInt = null;
        //        float? MinFloat = null;
        //        float? MaxFloat = null;
        //        foreach (CustomAttributeData attr in prop.CustomAttributes)
        //        {
        //            if (attr.AttributeType.Name == "RequiredAttribute")
        //            {
        //                Required = true;
        //            }
        //            if (attr.AttributeType.Name == "RangeAttribute")
        //            {
        //                if (csspProp.PropType.Contains("System.Int32") || csspProp.PropType.Contains("System.String"))
        //                {
        //                    MinInt = ((int?)attr.ConstructorArguments[0].Value);
        //                    if (MinInt == -1)
        //                    {
        //                        MinInt = null;
        //                    }
        //                    MaxInt = ((int?)attr.ConstructorArguments[1].Value);
        //                    if (MaxInt == -1)
        //                    {
        //                        MaxInt = null;
        //                    }
        //                }
        //                else if (csspProp.PropType.Contains("System.Single"))
        //                {
        //                    MinFloat = ((float?)((double)attr.ConstructorArguments[0].Value));
        //                    if (MinFloat == -1.0f)
        //                    {
        //                        MinFloat = null;
        //                    }
        //                    MaxFloat = ((float?)((double)attr.ConstructorArguments[1].Value));
        //                    if (MaxFloat == -1.0f)
        //                    {
        //                        MaxFloat = null;
        //                    }
        //                }
        //                else
        //                {
        //                }
        //            }
        //        }

        //        if (prop.Name != "ValidationResults")
        //        {
        //            WritePropGetRandom(prop, TypeName, TypeNameLower, sb, MinInt, MaxInt, MinFloat, MaxFloat, Required);
        //        }
        //    }
        //}
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

                if (type.Name.StartsWith("<")
                                   || type.Name.StartsWith("ModelsRes")
                                   || type.Name.StartsWith("Application")
                                   || type.Name.StartsWith("CSSPAfter")
                                   || type.Name.StartsWith("CSSPAllowNull")
                                   || type.Name.StartsWith("CSSPBigger")
                                   || type.Name.StartsWith("CSSPEnumType")
                                   || type.Name.StartsWith("CSSPExist")
                                   || type.Name.StartsWith("CSSPWebToolsDBContext"))
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

                //if (TypeName != "HydrometricSite")
                //{
                //    continue;
                //}

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
                sb.AppendLine(@"        private " + TypeName + @" GetFilledRandom" + TypeName + @"(string OmitPropName)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            " + TypeName + @"ID += 1;");
                sb.AppendLine(@"");
                sb.AppendLine(@"            " + TypeName + " " + TypeNameLower + @" = new " + TypeName + @"();");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    CSSPModelsGenerateCodeHelper.CSSPProp csspProp = new CSSPModelsGenerateCodeHelper.CSSPProp();
                    if (!ModelGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                    {
                        return;
                    }

                    if (prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"");
                sb.AppendLine(@"            return " + TypeNameLower + @";");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests Generated");
                sb.AppendLine(@"        [TestMethod]");
                sb.AppendLine(@"        public void " + TypeName + @"_Testing()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            SetupTestHelper(culture);");
                sb.AppendLine(@"            " + TypeName + @"Service " + TypeNameLower + @"Service = new " + TypeName + @"Service(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);");
                sb.AppendLine(@"            " + TypeName + @" " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                sb.AppendLine(@"");

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // CRUD testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");


                if (!ClassNotMapped)
                {
                    CreateClass_CRUD_Testing(type, TypeName, TypeNameLower, sb);
                    sb.AppendLine(@"");
                }

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // Required properties testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPModelsGenerateCodeHelper.CSSPProp csspProp = new CSSPModelsGenerateCodeHelper.CSSPProp();
                        if (!ModelGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            return;
                        }

                        CreateClass_Required_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                    }
                }

                sb.AppendLine(@"");

                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // Min and Max properties testing");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"            // -------------------------------");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPModelsGenerateCodeHelper.CSSPProp csspProp = new CSSPModelsGenerateCodeHelper.CSSPProp();
                        if (!ModelGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            return;
                        }

                        CreateClass_Min_And_Max_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                    }
                }
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
