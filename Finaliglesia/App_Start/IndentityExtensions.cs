using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;

namespace App.Extensions
{
    public static class IndentityExtensions
    {
        public static string GetNombreCompleto(this IIdentity entidad)
        {
            var claim = ((ClaimsIdentity)entidad).FindFirst("NombreCompleto");
            return (claim != null) ? claim.Value : string.Empty;

        }

    }
}