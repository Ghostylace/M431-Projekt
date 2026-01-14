using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace API;

public static class PasswordHasher
{
    public static string Hash(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }

    public static bool Verify(string password,string salt, string hash)
    {
        string passwordhash = Hash(password, salt);
        return string.Equals(passwordhash, hash);
    }
}

