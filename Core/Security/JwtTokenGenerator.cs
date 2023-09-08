using Core.Interfaces;
using Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken(string customerName, int customerId, int cardNumber)
        {
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var signingKey = new SymmetricSecurityKey(key);

            var token = new JwtTokenBuilder()
                .AddSecurityKey(signingKey)
                .AddSubject(customerName)
                .AddIssuer(_jwtOptions.Issuer)
                .AddAudience(_jwtOptions.Audience)
                .AddClaim(ClaimTypes.NameIdentifier, customerName)
                .AddClaim("CustomerId", customerId.ToString())
                .AddClaim("CardNumber", cardNumber.ToString())
                .AddExpiry(60) // 1 hour
                .Build();

            return token.Value;
        }

        public sealed class JwtToken
        {
            private readonly JwtSecurityToken _token;

            internal JwtToken(JwtSecurityToken token)
            {
                _token = token;
            }

            public string Value => new JwtSecurityTokenHandler().WriteToken(_token);
        }

        public sealed class JwtTokenBuilder
        {
            private SecurityKey _securityKey;
            private string _subject = "";
            private string _issuer = "";
            private string _audience = "";
            private readonly Dictionary<string, string> _claims = new();
            private int _expiryInMinutes = 5;

            public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
            {
                _securityKey = securityKey;
                return this;
            }

            public JwtTokenBuilder AddSubject(string subject)
            {
                _subject = subject;
                return this;
            }

            public JwtTokenBuilder AddIssuer(string issuer)
            {
                _issuer = issuer;
                return this;
            }

            public JwtTokenBuilder AddAudience(string audience)
            {
                _audience = audience;
                return this;
            }

            public JwtTokenBuilder AddClaim(string type, string value)
            {
                _claims.Add(type, value);
                return this;
            }

            public JwtTokenBuilder AddExpiry(int expiryInMinutes)
            {
                _expiryInMinutes = expiryInMinutes;
                return this;
            }

            public JwtToken Build()
            {
                EnsureArguments();

                var claims = new List<Claim>
                    {
                        new(JwtRegisteredClaimNames.Sub, _subject),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }
                    .Union(_claims.Select(item => new Claim(item.Key, item.Value)));

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                    signingCredentials: new SigningCredentials(
                        _securityKey,
                        SecurityAlgorithms.HmacSha256));

                return new JwtToken(token);
            }

            #region " private "

            private void EnsureArguments()
            {
                if (_securityKey == null)
                    throw new ArgumentNullException($"Security Key");

                if (string.IsNullOrEmpty(_subject))
                    throw new ArgumentNullException($"Subject");

                if (string.IsNullOrEmpty(_issuer))
                    throw new ArgumentNullException($"Issuer");

                if (string.IsNullOrEmpty(_audience))
                    throw new ArgumentNullException($"Audience");
            }

            #endregion
        }
    }
}
