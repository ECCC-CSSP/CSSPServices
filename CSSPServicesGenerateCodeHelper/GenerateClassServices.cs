using System;
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

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateClassServices : GenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        public CSSPWebToolsDBContext db { get; set; }
        private string DLLFileName { get; set; }
        private RichTextBox RichTextBoxStatus { get; set; }
        private Label LabelStatus { get; set; }
        private string GenerateFilePath { get; set; }
        #endregion Properties

        #region Constructors
        public GenerateClassServices(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
        {
            db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryNoDBShape);
            this.DLLFileName = DLLFileName;
            this.RichTextBoxStatus = richTextBoxStatus;
            this.LabelStatus = lblStatus;
            this.GenerateFilePath = GenerateFilePath;
        }
        #endregion Constructors

        #region Functions private
        private void CreateClassServiceFunctionsPrivateRegion(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
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
        private void CreateClassServiceFunctionsPublicRegion(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
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
        private void CreateValidation_Emails(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (!entityProp.IsKey)
                        {
                            switch (entityProp.PropType)
                            {
                                case "bool":
                                case "DateTime":
                                case "DateTimeOffset":
                                case "int":
                                case "float":
                                    {
                                        // nothing
                                    }
                                    break;
                                case "string":
                                    {
                                        if (prop.Name.Contains("Email") || (TypeName == "AspNetUser" && prop.Name == "UserName"))
                                        {
                                            sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                                            sb.AppendLine(@"                if (!regex.IsMatch(" + TypeNameLower + @"." + prop.Name + @"))");
                                            sb.AppendLine(@"                {");
                                            sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"                }");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        if (prop.PropertyType.FullName.Contains("Enum"))
                                        {
                                            // nothing
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"                //Error: Type not implemented [" + entityProp.PropName + "] of type [" + entityProp.PropType + "]");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        CreateValidation_LengthsNotMapped(prop, TypeName, TypeNameLower, sb);
                    }
                }
                else
                {
                    CreateValidation_LengthsNotMapped(prop, TypeName, TypeNameLower, sb);
                }
            }
        }
        private void CreateValidation_Lengths(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (!entityProp.IsKey)
                        {
                            switch (entityProp.PropType)
                            {
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
                                case "int":
                                    {
                                        if (entityProp.MinInt != null && entityProp.MaxInt != null)
                                        {
                                            if (entityProp.MinInt > entityProp.MaxInt)
                                            {
                                                sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" < " + entityProp.MinInt.ToString() + @" || " + TypeNameLower + @"." + entityProp.PropName + @" > " + entityProp.MaxInt.ToString() + @")");
                                                sb.AppendLine(@"            {");
                                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinInt.ToString() + @""", """ + entityProp.MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                                sb.AppendLine(@"            }");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                        else if (entityProp.MinInt != null)
                                        {
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" < " + entityProp.MinInt.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                        else if (entityProp.MaxInt != null)
                                        {
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" > " + entityProp.MaxInt.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
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
                                case "float":
                                    {
                                        if (entityProp.MinFloat != null && entityProp.MaxFloat != null)
                                        {
                                            if (entityProp.MinFloat > entityProp.MaxFloat)
                                            {
                                                sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" < " + entityProp.MinFloat.ToString() + @" || " + TypeNameLower + @"." + entityProp.PropName + @" > " + entityProp.MaxFloat.ToString() + @")");
                                                sb.AppendLine(@"            {");
                                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinFloat.ToString() + @""", """ + entityProp.MaxFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                                sb.AppendLine(@"            }");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                        else if (entityProp.MinFloat != null)
                                        {
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" < " + entityProp.MinFloat.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                        else if (entityProp.MaxFloat != null)
                                        {
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" > " + entityProp.MaxFloat.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MaxFloat.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
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
                                case "string":
                                    {
                                        if (entityProp.MinInt != null && entityProp.MaxLength != 0)
                                        {
                                            if (entityProp.MinInt > entityProp.MaxLength)
                                            {
                                                sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && (" + TypeNameLower + @"." + entityProp.PropName + @".Length < " + entityProp.MinInt.ToString() + @" || " + TypeNameLower + @"." + entityProp.PropName + @".Length > " + entityProp.MaxLength.ToString() + @"))");
                                                sb.AppendLine(@"            {");
                                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinInt.ToString() + @""", """ + entityProp.MaxLength.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                                sb.AppendLine(@"            }");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                        else if (entityProp.MinInt != null)
                                        {
                                            sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + entityProp.PropName + @".Length < " + entityProp.MinInt.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                        else if (entityProp.MaxLength != 0)
                                        {
                                            sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + entityProp.PropName + @".Length > " + entityProp.MaxLength.ToString() + @")");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + entityProp.PropName + @", """ + entityProp.MaxLength.ToString() + @"""), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
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
                                        if (prop.PropertyType.FullName.Contains("Enum"))
                                        {
                                            if (!entityProp.IsRequired)
                                            {
                                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null)");
                                                sb.AppendLine(@"            {");
                                                sb.AppendLine(@"                retStr = enums." + entityProp.PropType.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                                                sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == " + entityProp.PropType + ".Error || !string.IsNullOrWhiteSpace(retStr))");
                                                sb.AppendLine(@"                {");
                                                sb.AppendLine(@"                    yield return new ValidationResult(retStr, new[] { ModelsRes." + TypeName + @"" + prop.Name + @" });");
                                                sb.AppendLine(@"                }");
                                                sb.AppendLine(@"            }");
                                                sb.AppendLine(@"");
                                            }
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"                //Error: Type not implemented [" + entityProp.PropName + "] of type [" + entityProp.PropType + "]");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        CreateValidation_LengthsNotMapped(prop, TypeName, TypeNameLower, sb);
                    }
                }
                else
                {
                    CreateValidation_LengthsNotMapped(prop, TypeName, TypeNameLower, sb);
                }
            }
        }
        private void CreateValidation_LengthsNotMapped(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb)
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
                    if (prop.PropertyType.FullName.Contains("System.String"))
                    {
                        if (MinInt != null && MaxInt != 0)
                        {
                            if (MinInt > MaxInt)
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                            }
                            else
                            {
                                if ((TypeName == "Contact" && prop.Name == "Password") || (TypeName == "Contact" && prop.Name == "ConfirmPassword"))
                                {
                                    sb.AppendLine(@"            if (addContactType == AddContactType.Register)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && (" + TypeNameLower + @"." + prop.Name + @".Length < " + MinInt.ToString() + @") || (" + TypeNameLower + @"." + prop.Name + @".Length > " + MaxInt.ToString() + @"))");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @""", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && (" + TypeNameLower + @"." + prop.Name + @".Length < " + MinInt.ToString() + @") || (" + TypeNameLower + @"." + prop.Name + @".Length > " + MaxInt.ToString() + @"))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @""", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                        }
                        else if (MinInt != null)
                        {
                            if ((TypeName == "Contact" && prop.Name == "Password") || (TypeName == "Contact" && prop.Name == "ConfirmPassword"))
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.Register)");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + prop.Name + @".Length < " + MinInt.ToString() + @")");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + prop.Name + @".Length < " + MinInt.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        else if (MaxInt != 0)
                        {
                            if ((TypeName == "Contact" && prop.Name == "Password") || (TypeName == "Contact" && prop.Name == "ConfirmPassword"))
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.Register)");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + prop.Name + @".Length > " + MaxInt.ToString() + @")");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (!string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @") && " + TypeNameLower + @"." + prop.Name + @".Length > " + MaxInt.ToString() + @")");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + prop.Name + @", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        else
                        {
                            sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_string,");
                            sb.AppendLine(@"");
                        }
                    }
                    else if (prop.PropertyType.FullName.Contains("System.Boolean"))
                    {
                        // nothing
                    }
                    else if (prop.PropertyType.FullName.Contains("System.Int32"))
                    {
                        if (MinInt != null && MaxInt != null)
                        {
                            if (MinInt > MaxInt)
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                            }
                            else
                            {
                                if (TypeName == "Contact" && prop.Name == "ParentTVItemID")
                                {
                                    sb.AppendLine(@"            if (addContactType == AddContactType.LoggedIn)");
                                    sb.AppendLine(@"            {");
                                    if (Required != null && Required == true)
                                    {
                                        sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @" || " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" != null && (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @" || " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @"))");
                                    }
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @""", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    if (Required != null && Required == true)
                                    {
                                        sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @" || " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @" || " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @"))");
                                    }
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @""", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                        }
                        else if (MinInt != null)
                        {
                            if (TypeName == "Contact" && prop.Name == "ParentTVItemID")
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.LoggedIn)");
                                sb.AppendLine(@"            {");
                                if (Required != null && Required == true)
                                {
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @")");
                                }
                                else
                                {
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @")");
                                }
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                if (Required != null && Required == true)
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @")");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" < " + MinInt.ToString() + @")");
                                }
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MinInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        else if (MaxInt != null)
                        {
                            if (TypeName == "Contact" && prop.Name == "ParentTVItemID")
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.LoggedIn)");
                                sb.AppendLine(@"            {");
                                if (Required != null && Required == true)
                                {
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                }
                                else
                                {
                                    sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                }
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                if (Required != null && Required == true)
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" > " + MaxInt.ToString() + @")");
                                }
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MaxInt.ToString() + @"""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        else
                        {
                            sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                            sb.AppendLine(@"");
                        }
                    }
                    else if (prop.PropertyType.FullName.Contains("System.Single"))
                    {
                        if (MinFloat != null && MaxFloat != null)
                        {
                            if (MinFloat > MaxFloat)
                            {
                                sb.AppendLine(@"                " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                            }
                            else
                            {
                                if (Required != null && Required == true)
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" < " + MinFloat.ToString() + @"f || " + TypeNameLower + @"." + prop.Name + @" > " + MaxFloat.ToString() + @"f)");
                                }
                                else
                                {
                                    sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && (" + TypeNameLower + @"." + prop.Name + @" < " + MinFloat.ToString() + @"f || " + TypeNameLower + @"." + prop.Name + @" > " + MaxFloat.ToString() + @"f))");
                                }
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + prop.Name + @", """ + MinFloat.ToString() + @"f"", """ + MaxFloat.ToString() + @"f""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        else if (MinFloat != null)
                        {
                            if (Required != null && Required == true)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" < " + MinFloat.ToString() + @"f)");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" < " + MinFloat.ToString() + @"f)");
                            }
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MinFloat.ToString() + @"f""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        else if (MaxFloat != null)
                        {
                            if (Required != null && Required == true)
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" > " + MaxFloat.ToString() + @"f)");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null && " + TypeNameLower + @"." + prop.Name + @" > " + MaxFloat.ToString() + @"f)");
                            }
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + prop.Name + @", """ + MaxFloat.ToString() + @"f""), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        else
                        {
                            sb.AppendLine(@"                " + prop.Name + @" = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_double_or_single,");
                            sb.AppendLine(@"");
                        }
                    }
                    else if (prop.Name.EndsWith("Enum"))
                    {
                        if (Required != null && Required == true)
                        {
                            sb.AppendLine(@"            retStr = enums." + prop.PropertyType.Name.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == " + prop.PropertyType.Name + ".Error || !string.IsNullOrWhiteSpace(retStr))");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                yield return new ValidationResult(retStr, new[] { ModelsRes." + TypeName + prop.Name + @" });");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        else
                        {
                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" != null)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                retStr = enums." + prop.PropertyType.Name.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                            sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == " + prop.PropertyType.Name + ".Error || !string.IsNullOrWhiteSpace(retStr))");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    yield return new ValidationResult(retStr, new[] { ModelsRes." + TypeName + prop.Name + @" });");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                    }
                    else
                    {
                        sb.AppendLine(@"                " + prop.Name + @" = GetRandomSomethingElse(),");
                    }

                }
            }
        }
        private void CreateValidation_Required(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (!entityProp.IsKey && entityProp.IsRequired)
                        {
                            switch (entityProp.PropType)
                            {
                                case "int":
                                    {
                                        sb.AppendLine(@"            //" + entityProp.PropName + @" (" + entityProp.PropType + @") is required but no testing needed as it is automatically set to 0");
                                        sb.AppendLine(@"");
                                    }
                                    break;
                                case "float":
                                    {
                                        sb.AppendLine(@"            //" + entityProp.PropName + @" (" + entityProp.PropType + @") is required but no testing needed as it is automatically set to 0.0f");
                                        sb.AppendLine(@"");
                                    }
                                    break;
                                case "bool":
                                    {
                                        sb.AppendLine(@"            //" + entityProp.PropName + @" (bool) is required but no testing needed ");
                                        sb.AppendLine(@"");
                                    }
                                    break;
                                case "DateTime":
                                case "DateTimeOffset":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" == null || " + TypeNameLower + @"." + entityProp.PropName + @".Year < 1900 )");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                case "string":
                                    {
                                        if (!entityProp.IsKey && entityProp.IsRequired)
                                        {
                                            sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + entityProp.PropName + @"))");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        if (prop.PropertyType.FullName.Contains("Enum"))
                                        {
                                            sb.AppendLine(@"            retStr = enums." + entityProp.PropType.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
                                            sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == " + entityProp.PropType + @".Error || !string.IsNullOrWhiteSpace(retStr))");
                                            sb.AppendLine(@"            {");
                                            sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                            sb.AppendLine(@"            }");
                                            sb.AppendLine(@"");
                                        }
                                        else
                                        {
                                            sb.AppendLine(@"                //Error: Type not implemented [" + entityProp.PropName + "] of type [" + entityProp.PropType + "]");
                                            sb.AppendLine(@"");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        CreateValidation_RequiredNotMapped(prop, TypeName, TypeNameLower, sb);
                    }
                }
                else
                {
                    CreateValidation_RequiredNotMapped(prop, TypeName, TypeNameLower, sb);
                }
            }
        }
        private void CreateValidation_RequiredNotMapped(PropertyInfo prop, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!prop.GetGetMethod().IsVirtual)
            {
                bool? Required = null;
                foreach (CustomAttributeData attr in prop.CustomAttributes)
                {
                    if (attr.AttributeType.Name == "RequiredAttribute")
                    {
                        Required = true;
                    }
                }

                if (prop.Name != "ValidationResults")
                {
                    if (Required != null && Required == true)
                    {
                        if (prop.PropertyType.FullName == "System.String")
                        {
                            if ((TypeName == "Contact" && prop.Name == "Password") || (TypeName == "Contact" && prop.Name == "ConfirmPassword"))
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.Register)");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"                if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + prop.Name + @"))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"");
                            }
                        }
                        else if (prop.PropertyType.FullName == "System.Boolean")
                        {
                            sb.AppendLine(@"            //" + prop.Name + @" (bool) is required but no testing needed ");
                            sb.AppendLine(@"");
                        }
                        else if (prop.PropertyType.FullName == "System.Int32")
                        {
                            if ((TypeName == "Contact" && prop.Name == "ParentTVItemID"))
                            {
                                sb.AppendLine(@"            if (addContactType == AddContactType.LoggedIn)");
                                sb.AppendLine(@"            {");
                                sb.AppendLine(@"                if (" + TypeNameLower + @"." + prop.Name + @" == 0)");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + prop.Name + @"), new[] { ModelsRes." + TypeName + prop.Name + @" });");
                                sb.AppendLine(@"                }");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine(@"            //" + prop.Name + @" is required but no testing needed as it is automatically set to 0");
                                sb.AppendLine(@"");
                            }
                        }
                        else if (prop.PropertyType.FullName == "System.Single")
                        {
                            sb.AppendLine(@"            //" + prop.Name + @" is required but no testing needed as it is automatically set to 0.0f");
                            sb.AppendLine(@"");
                        }
                        else if (prop.PropertyType.FullName.StartsWith("Nullable"))
                        {
                            sb.AppendLine(@"                " + prop.Name + @" = GetRandomSomething(),");
                        }
                        else
                        {
                            sb.AppendLine(@"                " + prop.Name + @" = GetRandomSomethingElse(),");
                        }
                    }
                }
            }
        }
        private void CreateValidation_Keys(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (entityType != null)
                {
                    IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

                    EntityProp entityProp = FillEntityProp(entProp, entityType, type, TypeName, TypeNameLower);
                    if (entProp != null)
                    {
                        if (entityProp.IsKey)
                        {
                            if (prop.PropertyType.FullName == "System.String")
                            {
                                sb.AppendLine(@"                if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + entityProp.PropName + @"))");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                sb.AppendLine(@"                }");
                            }
                            else if (prop.PropertyType.FullName == "System.Int32" || prop.PropertyType.FullName == "System.Int64")
                            {
                                //int? Min = GetEntityValueInt(entProp, "Min");
                                //int? Max = GetEntityValueInt(entProp, "Max");

                                //if (Min == 0)
                                //{
                                //    sb.AppendLine(@"                if (" + TypeNameLower + @"." + entityProp.PropName + @" < " + Min.ToString() + @")");
                                //    sb.AppendLine(@"                {");
                                //    sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                //    sb.AppendLine(@"                }");
                                //}
                                //else
                                //{
                                sb.AppendLine(@"                if (" + TypeNameLower + @"." + entityProp.PropName + @" == 0)");
                                sb.AppendLine(@"                {");
                                sb.AppendLine(@"                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
                                sb.AppendLine(@"                }");
                                //}
                            }
                            else
                            {
                                sb.AppendLine(@"                NeedToImplement_" + prop.PropertyType.FullName + "_InCreateValidationOfKeys=0;");
                            }
                        }
                    }
                }
            }
        }
        private void CreateValidation_ObjectExist(IEntityType entityType, Type type, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            //foreach (PropertyInfo prop in type.GetProperties())
            //{
            //    if (entityType != null)
            //    {
            //        IProperty entProp = entityType.GetProperties().Where(c => c.Name == prop.Name).FirstOrDefault();

            //        EntityProp entityProp = FillEntityProp(entProp, entityType, type, TypeName, TypeNameLower);
            //        if (entProp != null)
            //        {
            //            if (!entityProp.IsKey && entityProp.IsRequired)
            //            {
            //                switch (entityProp.PropType)
            //                {
            //                    case "int":
            //                        {
            //                            sb.AppendLine(@"            //" + entityProp.PropName + @" (" + entityProp.PropType + @") is required but no testing needed as it is automatically set to 0");
            //                            sb.AppendLine(@"");
            //                        }
            //                        break;
            //                    case "float":
            //                        {
            //                            sb.AppendLine(@"            //" + entityProp.PropName + @" (" + entityProp.PropType + @") is required but no testing needed as it is automatically set to 0.0f");
            //                            sb.AppendLine(@"");
            //                        }
            //                        break;
            //                    case "bool":
            //                        {
            //                            sb.AppendLine(@"            //" + entityProp.PropName + @" (bool) is required but no testing needed ");
            //                            sb.AppendLine(@"");
            //                        }
            //                        break;
            //                    case "DateTime":
            //                    case "DateTimeOffset":
            //                        {
            //                            if (!entityProp.IsKey && entityProp.IsRequired)
            //                            {
            //                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + entityProp.PropName + @" == null || " + TypeNameLower + @"." + entityProp.PropName + @".Year < 1900 )");
            //                                sb.AppendLine(@"            {");
            //                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
            //                                sb.AppendLine(@"            }");
            //                                sb.AppendLine(@"");
            //                            }
            //                        }
            //                        break;
            //                    case "string":
            //                        {
            //                            if (!entityProp.IsKey && entityProp.IsRequired)
            //                            {
            //                                sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(" + TypeNameLower + @"." + entityProp.PropName + @"))");
            //                                sb.AppendLine(@"            {");
            //                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
            //                                sb.AppendLine(@"            }");
            //                                sb.AppendLine(@"");
            //                            }
            //                        }
            //                        break;
            //                    default:
            //                        {
            //                            if (prop.PropertyType.FullName.Contains("Enum"))
            //                            {
            //                                sb.AppendLine(@"            retStr = enums." + entityProp.PropType.Replace("Enum", "") + @"OK(" + TypeNameLower + @"." + prop.Name + @");");
            //                                sb.AppendLine(@"            if (" + TypeNameLower + @"." + prop.Name + @" == " + entityProp.PropType + @".Error || !string.IsNullOrWhiteSpace(retStr))");
            //                                sb.AppendLine(@"            {");
            //                                sb.AppendLine(@"                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + entityProp.PropName + @"), new[] { ModelsRes." + TypeName + entityProp.PropName + @" });");
            //                                sb.AppendLine(@"            }");
            //                                sb.AppendLine(@"");
            //                            }
            //                            else
            //                            {
            //                                sb.AppendLine(@"                //Error: Type not implemented [" + entityProp.PropName + "] of type [" + entityProp.PropType + "]");
            //                                sb.AppendLine(@"");
            //                            }
            //                        }
            //                        break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            CreateValidationOfIsRequiredNotMapped(prop, TypeName, TypeNameLower, sb);
            //        }
            //    }
            //    else
            //    {
            //        CreateValidationOfIsRequiredNotMapped(prop, TypeName, TypeNameLower, sb);
            //    }
            //}

            sb.AppendLine(@"                yield return new ValidationResult(""DatabaseType is > MemoryNoDBShape"");");
        }
        #endregion Functions private

        #region Functions public
        /// <summary>
        /// 
        /// </summary>
        public void GenerateCodeOf_ClassServiceGenerated_cs()
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
                //bool ClassNotMapped = false;
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

                entityType = db.Model.GetEntityTypes().Where(c => c.Name == "CSSPModels." + TypeName).FirstOrDefault();

                //foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                //{
                //    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                //    {
                //        ClassNotMapped = true;
                //        break;
                //    }
                //}

                //if (type.Name != "BoxModel")
                //{
                //    continue;
                //}

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
                sb.AppendLine(@"        private CSSPWebToolsDBContext db { get; set; }");
                sb.AppendLine(@"        private DatabaseTypeEnum DatabaseType { get; set; }");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine(@"        public " + TypeName + @"Service(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)");
                sb.AppendLine(@"            : base(LanguageRequest, User)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            this.DatabaseType = DatabaseType;");
                sb.AppendLine(@"            this.db = new CSSPWebToolsDBContext(this.DatabaseType);");
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
                if (TypePropHasEnum(entityType, type, TypeName, TypeNameLower))
                {
                    sb.AppendLine(@"            string retStr = """";");
                    sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                }
                sb.AppendLine(@"            " + TypeName + @" " + TypeNameLower + @" = validationContext.ObjectInstance as " + TypeName + @";");
                sb.AppendLine(@"");
                sb.AppendLine(@"            // ----------------------------------------------------");
                sb.AppendLine(@"            // Property is required validation");
                sb.AppendLine(@"            // ----------------------------------------------------");
                sb.AppendLine(@"");
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update)");
                sb.AppendLine(@"            {");

                CreateValidation_Keys(entityType, type, TypeName, TypeNameLower, sb);

                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                CreateValidation_Required(entityType, type, TypeName, TypeNameLower, sb);

                sb.AppendLine(@"            // ----------------------------------------------------");
                sb.AppendLine(@"            // Property other validation");
                sb.AppendLine(@"            // ----------------------------------------------------");
                sb.AppendLine(@"");


                CreateValidation_Lengths(entityType, type, TypeName, TypeNameLower, sb);

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
                }

                CreateValidation_Emails(entityType, type, TypeName, TypeNameLower, sb);


                //CreateValidationOfObjectExist(entityType, type, TypeName, TypeNameLower, sb);

                sb.AppendLine(@"");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Validation");
                sb.AppendLine(@"");

                CreateClassServiceFunctionsPublicRegion(entityType, type, TypeName, TypeNameLower, sb);

                CreateClassServiceFunctionsPrivateRegion(entityType, type, TypeName, TypeNameLower, sb);

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
