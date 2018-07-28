using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class AspNetUserService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        public bool Login(string username, string password)
        {
            bool exist = (from c in GetRead()
                          where c.UserName == username
                          && c.PasswordHash == password
                          select c).Any();

            return false;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
