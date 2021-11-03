using System;
using System.Security.Cryptography;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ABCar.Business.Helpers
{
    public static class PasswordHasher
    {
        public static void SetHashedPasswordAndSalt(this KorisnickiRacun korisnickiRacun, string password, byte[] salt = null)
        {
            //u slucaju da salt nije proslijedjen
            if (salt == null)
                salt = korisnickiRacun.Salt;

            // u slucaju da salt nije proslijedjen niti postoji za KorisnickiRacun 
            if (salt == null)
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }


            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            korisnickiRacun.Lozinka = hashed;
            korisnickiRacun.Salt = salt;
        }

        public static string GetHash(string password, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;

        }

    }
}
