﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.IO;
using CSSPModels;
using CSSPEnums;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateClassServices : GenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public GenerateClassServices(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
            : base(DLLFileName, GenerateFilePath, richTextBoxStatus, lblStatus)
        {
        }
        #endregion Constructors

        #region Functions private
        private void CreateClassServiceFunctionsPrivateRegion(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions private");
            sb.AppendLine(@"        private bool TryToSave(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        private bool TryToSaveRange(List<" + TypeName + @"> " + TypeNameLower + @"List)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                " + TypeNameLower + @"List[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private");
        }
        private void CreateClassServiceFunctionsPublicRegion(Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            sb.AppendLine(@"        #region Functions public");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"        public bool Add(" + TypeName + @" " + TypeNameLower + @", AddContactType addContactType)");
            }
            else
            {
                sb.AppendLine(@"        public bool Add(" + TypeName + @" " + TypeNameLower + @")");
            }
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine(@"            if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Add(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool AddRange(List<" + TypeName + @"> " + TypeNameLower + @"List)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (" + TypeName + @" " + TypeNameLower + @" in " + TypeNameLower + @"List)");
            sb.AppendLine(@"            {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create, ContactService.AddContactType.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine(@"                if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".AddRange(" + TypeNameLower + @"List);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSaveRange(" + TypeNameLower + @"List)) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool Delete(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            if (TypeName == "AspNetRole" || TypeName == "AspNetUserClaim" || TypeName == "AspNetUser")
            {
                sb.AppendLine(@"            if (!db." + TypeName + Plurial + @".Where(c => c.Id == " + TypeNameLower + @".Id).Any())");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", ""Id"", " + TypeNameLower + @".Id.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                return false;");
                sb.AppendLine(@"            }");
            }
            else if (TypeName == "AspNetUserLogin" || TypeName == "AspNetUserRole")
            {
                sb.AppendLine(@"            if (!db." + TypeName + Plurial + @".Where(c => c.UserId == " + TypeNameLower + @".UserId).Any())");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", ""UserId"", " + TypeNameLower + @".UserId.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                return false;");
                sb.AppendLine(@"            }");
            }
            else
            {
                sb.AppendLine(@"            if (!db." + TypeName + Plurial + @".Where(c => c." + TypeName + @"ID == " + TypeNameLower + @"." + TypeName + @"ID).Any())");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", """ + TypeName + @"ID"", " + TypeNameLower + @"." + TypeName + @"ID.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                return false;");
                sb.AppendLine(@"            }");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Remove(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool DeleteRange(List<" + TypeName + @"> " + TypeNameLower + @"List)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (" + TypeName + @" " + TypeNameLower + @" in " + TypeNameLower + @"List)");
            sb.AppendLine(@"            {");
            if (TypeName == "AspNetRole" || TypeName == "AspNetUserClaim" || TypeName == "AspNetUser")
            {
                sb.AppendLine(@"                if (!db." + TypeName + Plurial + @".Where(c => c.Id == " + TypeNameLower + @".Id).Any())");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + @"List[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", ""Id"", " + TypeNameLower + @".Id.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                    return false;");
                sb.AppendLine(@"                }");
            }
            else if (TypeName == "AspNetUserLogin" || TypeName == "AspNetUserRole")
            {
                sb.AppendLine(@"                if (!db." + TypeName + Plurial + @".Where(c => c.UserId == " + TypeNameLower + @".UserId).Any())");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + @"List[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", ""UserId"", " + TypeNameLower + @".UserId.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                    return false;");
                sb.AppendLine(@"                }");
            }
            else
            {
                sb.AppendLine(@"                if (!db." + TypeName + Plurial + @".Where(c => c." + TypeName + @"ID == " + TypeNameLower + @"." + TypeName + @"ID).Any())");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeNameLower + @"List[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, """ + TypeName + @""", """ + TypeName + @"ID"", " + TypeNameLower + @"." + TypeName + @"ID.ToString())) }.AsEnumerable();");
                sb.AppendLine(@"                    return false;");
                sb.AppendLine(@"                }");
            }
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".RemoveRange(" + TypeNameLower + @"List);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSaveRange(" + TypeNameLower + @"List)) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool Update(" + TypeName + @" " + TypeNameLower + @")");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update, ContactService.AddContactType.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"            " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine(@"            if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".Update(" + TypeNameLower + @");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSave(" + TypeNameLower + @")) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public bool UpdateRange(List<" + TypeName + @"> " + TypeNameLower + @"List)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (" + TypeName + @" " + TypeNameLower + @" in " + TypeNameLower + @"List)");
            sb.AppendLine(@"            {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update, ContactService.AddContactType.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"                " + TypeNameLower + @".ValidationResults = Validate(new ValidationContext(" + TypeNameLower + @"), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine(@"                if (" + TypeNameLower + @".ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            db." + TypeName + Plurial + @".UpdateRange(" + TypeNameLower + @"List);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (!TryToSaveRange(" + TypeNameLower + @"List)) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public IQueryable<" + TypeName + @"> GetRead()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            return db." + TypeName + Plurial + @".AsNoTracking();");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        public IQueryable<" + TypeName + @"> GetEdit()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            return db." + TypeName + Plurial + @";");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public");
            sb.AppendLine(@"");
        }
        private void CreateValidation_AfterYear(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine(@"            if (" + TypeNameLower + "." + csspProp.PropName + " != null && ((DateTime)" + TypeNameLower + "." + csspProp.PropName + ").Year < " + csspProp.Year + ")");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Year + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + " });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"            if (" + TypeNameLower + "." + csspProp.PropName + ".Year < " + csspProp.Year + ")");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Year + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + " });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateValidation_Bigger(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine(@"            if (" + TypeNameLower + "." + csspProp.OtherField + " < " + TypeNameLower + "." + csspProp.PropName + ")");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes." + TypeName + csspProp.PropName + ", ModelsRes." + TypeName + csspProp.OtherField + "), new[] { ModelsRes." + TypeName + csspProp.PropName + " });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        private void CreateValidation_Email(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.dataType == DataType.EmailAddress)
            {
                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                sb.AppendLine(@"                if (!regex.IsMatch(" + TypeNameLower + @"." + prop.Name + @"))");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }
        }
        private void CreateValidation_EnumType(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.HasCSSPEnumTypeAttribute)
            {
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                retStr = enums." + csspProp.PropType.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == " + csspProp.PropType + ".Error || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    yield return new ValidationResult(retStr, new[] { ModelsRes." + TypeName + @"" + prop.Name + @" });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"            retStr = enums." + prop.PropertyType.Name.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == " + prop.PropertyType.Name + @".Error || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateValidation_Length(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsKey)
            {
                switch (csspProp.PropType)
                {
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
                    case "Int16":
                    case "Int32":
                    case "Int64":
                        {
                            if (csspProp.MinInt == null && csspProp.MaxInt == null)
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" has no Range Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MinInt != null && csspProp.MaxInt != null)
                            {
                                if (csspProp.MinInt > csspProp.MaxInt)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinInt.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxInt.ToString() + @")");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinInt.ToString() + @""", """ + csspProp.MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.MinInt != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinInt.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MaxInt != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxInt.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "Single":
                        {
                            if (csspProp.MinFloat == null && csspProp.MaxFloat == null)
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" has no Range Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MinFloat != null && csspProp.MaxFloat != null)
                            {
                                if (csspProp.MinFloat > csspProp.MaxFloat)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinFloat.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxFloat.ToString() + @")");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinFloat.ToString() + @""", """ + csspProp.MaxFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.MinFloat != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinFloat.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MaxFloat != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxFloat.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MaxFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_double_or_single,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "Double":
                        {
                            if (csspProp.MinDouble == null && csspProp.MaxDouble == null)
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" has no Range Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MinDouble != null && csspProp.MaxDouble != null)
                            {
                                if (csspProp.MinDouble > csspProp.MaxDouble)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinDouble.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxDouble.ToString() + @")");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinDouble.ToString() + @""", """ + csspProp.MaxDouble.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.MinDouble != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" < " + csspProp.MinDouble.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinDouble.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MaxDouble != null)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + csspProp.PropName + @" > " + csspProp.MaxDouble.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MaxDouble.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_double_or_single,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (csspProp.MinLength == null && csspProp.MaxLength == null)
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" has no StringLength Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MinLength != null && csspProp.MaxLength != null)
                            {
                                if (csspProp.MinLength > csspProp.MaxLength)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && (" + TypeNameLower + @"." + csspProp.PropName + @".Length < " + csspProp.MinLength.ToString() + @" || " + TypeNameLower + @"." + csspProp.PropName + @".Length > " + csspProp.MaxLength.ToString() + @"))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinLength.ToString() + @""", """ + csspProp.MaxLength.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.MinLength != null)
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + csspProp.PropName + @".Length < " + csspProp.MinLength.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MinLength.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.MaxLength != null)
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + csspProp.PropName + @".Length > " + csspProp.MaxLength.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.MaxLength.ToString() + @"""), new[] { ModelsRes." + TypeName + csspProp.PropName + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"            // " + prop.Name + @" has no validation");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine(@"                //Error: Type not implemented [" + csspProp.PropName + "] of type [" + csspProp.PropType + "]");
                            }
                        }
                        break;
                }
            }
        }
        private void CreateValidation_NotNullable(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsNullable)
                switch (prop.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            sb.AppendLine(@"            //" + prop.Name + @" (" + prop.PropertyType.Name + @") is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "Boolean":
                        {
                            sb.AppendLine(@"            //" + prop.Name + @" (bool) is required but no testing needed ");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == null)");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine(@"                //Error: Type not implemented [" + prop.Name + "] of type [" + prop.PropertyType.Name + "]");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                }
        }
        private void CreateValidation_Key(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update)");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == 0)");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

            }
        }
        private void CreateValidation_Exist(PropertyInfo prop, CSSPModelsGenerateCodeHelper.CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.ObjectExistTypeName) && !string.IsNullOrWhiteSpace(csspProp.ObjectExistPlurial) && !string.IsNullOrWhiteSpace(csspProp.ObjectExistFieldID))
            {
                if (TypeName == "TVItem" && (csspProp.PropName == "ParentID" || csspProp.PropName == "LastUpdateContactTVItemID"))
                {
                    sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (!((from c in db." + csspProp.ObjectExistTypeName + csspProp.ObjectExistPlurial + " where c." + csspProp.ObjectExistFieldID + " == " + TypeNameLower + "." + csspProp.PropName + " select c).Any()))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes." + csspProp.ObjectExistTypeName + ", ModelsRes." + TypeName + csspProp.PropName + ", " + TypeNameLower + "." + csspProp.PropName + ".ToString()), new[] { ModelsRes." + TypeName + csspProp.PropName + " });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine(@"            if (!((from c in db." + csspProp.ObjectExistTypeName + csspProp.ObjectExistPlurial + " where c." + csspProp.ObjectExistFieldID + " == " + TypeNameLower + "." + csspProp.PropName + " select c).Any()))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes." + csspProp.ObjectExistTypeName + ", ModelsRes." + TypeName + csspProp.PropName + ", " + TypeNameLower + "." + csspProp.PropName + ".ToString()), new[] { ModelsRes." + TypeName + csspProp.PropName + " });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }
        }
        #endregion Functions private

        #region Functions public
        /// <summary>
        /// 
        /// </summary>
        public void GenerateCodeOf_ClassServiceGenerated()
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
                //IEntityType entityType = null;

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

                if (ModelGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                if (type.Name != "TVItem")
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

                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    public partial class " + TypeName + @"Service : BaseService");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"        private CSSPWebToolsDBContext db { get; set; }");
                    sb.AppendLine(@"        private DatabaseTypeEnum DatabaseType { get; set; }");
                }
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine(@"        public " + TypeName + @"Service(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)");
                sb.AppendLine(@"            : base(LanguageRequest, ContactID)");
                sb.AppendLine(@"        {");
                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"            this.DatabaseType = DatabaseType;");
                    sb.AppendLine(@"            this.db = new CSSPWebToolsDBContext(this.DatabaseType);");
                }
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Validation");
                if (TypeName == "Contact")
                {
                    sb.AppendLine(@"        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactType addContactType)");
                }
                else
                {
                    sb.AppendLine(@"        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)");
                }
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            string retStr = """";");
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine(@"            " + TypeName + @" " + TypeNameLower + @" = validationContext.ObjectInstance as " + TypeName + @";");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (DatabaseType > DatabaseTypeEnum.MemoryNoDBShape)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    if (GetRead().Count() > 0)");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine(@"                        yield return new ValidationResult(ServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ModelsRes.TVItemTVItemID });");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPModelsGenerateCodeHelper.CSSPProp csspProp = new CSSPModelsGenerateCodeHelper.CSSPProp();
                    if (!ModelGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                    {
                        RichTextBoxStatus.AppendText("Error while creating code [" + csspProp.Error + "]");
                        return;
                    }

                    if (!ClassNotMapped)
                    {
                        CreateValidation_Key(prop, csspProp, TypeName, TypeNameLower, sb);
                    }

                    CreateValidation_NotNullable(prop, csspProp, TypeName, TypeNameLower, sb);

                    CreateValidation_Length(prop, csspProp, TypeName, TypeNameLower, sb);


                    CreateValidation_Email(prop, csspProp, TypeName, TypeNameLower, sb);

                    CreateValidation_AfterYear(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Bigger(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_Exist(prop, csspProp, TypeName, TypeNameLower, sb);
                    CreateValidation_EnumType(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"            retStr = """";");
                sb.AppendLine(@"            if (retStr != """")");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                yield return new ValidationResult(""AAA"", new[] { ""AAA"" });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Validation");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    CreateClassServiceFunctionsPublicRegion(type, TypeName, TypeNameLower, sb);

                    CreateClassServiceFunctionsPrivateRegion(type, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(GenerateFilePath + TypeName + "ServiceGenerated.cs");
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                RichTextBoxStatus.AppendText("Created [" + fiOutputGen.FullName + "] ...\r\n");

                LabelStatus.Text = "Done ...";
            }
        }
        #endregion Functions public
    }
}
