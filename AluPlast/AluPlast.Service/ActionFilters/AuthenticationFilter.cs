using AluPlast.ControlLoader.Interfaces;
using AluPlast.Logowanie.Interfaces;
using AluPlast.Logowanie.MockService;
using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AluPlast.Service.ActionFilters
{
    public class AuthenticationFilter : AuthorizationFilterAttribute
    {
        private readonly string Role;

        public AuthenticationFilter(string role = "")
        {
            this.Role = role;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authRequest = actionContext.Request.Headers.Authorization;

            if (authRequest==null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            else
            {
                if (authRequest.Scheme=="Alu")
                {
                    var parameters = authRequest.Parameter.Split(';');

                    if (parameters.Count() >= 2)
                    {
                        var user = parameters[0];
                        var password = parameters[1];

                        var uzytkownik = new Uzytkownik { FirstName = "Marcin", Password = "123" };

                        IAuthenticationService authenticationService = new DbAuthenticationService();

                        var isValid = authenticationService.IsValid(uzytkownik, password);

                        if (isValid)
                        {
                            // Get roles
                            var roles = new List<string> { "Trener", "Magazynier" };

                            var identity = new GenericIdentity(uzytkownik.FullName);

                            identity.AddClaim(new Claim("http://aluplast.pl/OdczytFaktur", "true", "bool"));
                            identity.AddClaim(new Claim("DeviceId", "123456", "int"));
                            identity.AddClaim(new Claim("<xml></xml>", "123456", "xml"));
                            identity.AddClaim(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));

                            var currentPrincipal = new GenericPrincipal(identity, roles.ToArray());

                            Thread.CurrentPrincipal = currentPrincipal;

                            if (!string.IsNullOrEmpty(Role) && !Thread.CurrentPrincipal.IsInRole(Role))
                            {
                                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                                return;
                            }

                            return;
                        }


                    }

                }

                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;

            }
        }

            //if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
            //{
            //}

            //   base.OnAuthorization(actionContext);
    }
}
