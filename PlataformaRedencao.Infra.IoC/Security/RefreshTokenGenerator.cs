using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using PlataformaRedencao.Application.Security;

namespace PlataformaRedencao.Infra.IoC.Security
{
    /// <summary>
    /// Generates cryptographically secure refresh token values using random bytes.
    /// </summary>
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        /// <inheritdoc />
        public string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(bytes);
        }
    }
}