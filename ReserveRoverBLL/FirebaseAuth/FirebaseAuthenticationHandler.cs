using System.Security.Claims;
using System.Text.Encodings.Web;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace ReserveRoverBLL.FirebaseAuth;

public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string BearerPrefix = "Bearer ";

    private readonly FirebaseApp _firebaseApp;
    
    public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, FirebaseApp firebaseApp) : base(options, logger, encoder, clock)
    {
        _firebaseApp = firebaseApp;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Context.Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.NoResult();
        }

        string? bearerToken = Context.Request.Headers["Authorization"];

        if (bearerToken == null || !bearerToken.StartsWith(BearerPrefix))
        {
            return AuthenticateResult.Fail("Invalid scheme.");
        }

        var token = bearerToken.Substring(BearerPrefix.Length);

        try
        {
            var firebaseToken = await FirebaseAdmin.Auth.FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);

            return AuthenticateResult.Success(CreateAuthenticationTicket(firebaseToken));
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail(ex);
        }
    }
    
    private AuthenticationTicket CreateAuthenticationTicket(FirebaseToken firebaseToken)
    {
        var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
        {
            new(ToClaims(firebaseToken.Claims), nameof(ClaimsIdentity))
        });

        return new AuthenticationTicket(claimsPrincipal, JwtBearerDefaults.AuthenticationScheme);
    }

    private static IEnumerable<Claim> ToClaims(IReadOnlyDictionary<string, object> claims)
    {
        var firebase = claims.GetValueOrDefault("firebase", "").ToString();
        var signInProvider = firebase?.Split(',')
            .Select(s => s.Split(':'))
            .FirstOrDefault(a => a[0] == "sign_in_provider")?[1];

        var resultClaims = new List<Claim>();
        
        switch (signInProvider)
        {
            case "email":
            {
                var emailVerified = claims.GetValueOrDefault("email_verified", "").ToString();
                if (emailVerified != "True")
                    throw new Exception("Email is not verified.");

                resultClaims.AddRange(new Claim[]
                {
                    new(FirebaseUserClaim.Email, claims.GetValueOrDefault("email", "").ToString()!),
                    new(FirebaseUserClaim.EmailVerified, emailVerified)
                });
                break;
            }
            case "phone":
                resultClaims.AddRange(new Claim[]
                {
                    new(FirebaseUserClaim.Phone, claims.GetValueOrDefault("phone", "").ToString()!)
                });
                break;
        }

        resultClaims.AddRange(new Claim[]
        {
            new(FirebaseUserClaim.Id, claims.GetValueOrDefault("user_id", "").ToString()!),
            new(FirebaseUserClaim.Username, claims.GetValueOrDefault("name", "").ToString()!),
            new(ClaimTypes.Role, claims.GetValueOrDefault("role", "").ToString()!)
        });
        
        return resultClaims;
    }
}