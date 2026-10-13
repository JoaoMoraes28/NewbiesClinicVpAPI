using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace ClinicVp.ConfigurationExtensions.HashedPassword
{
    public class SecurityPassword
    {

        public static string GetPassHashed(string password)
        {
            int iterations = 4;
            int memorySize = 33536;
            int parallelism = 2;

            var salt = RandomNumberGenerator.GetBytes(16);
            var passwordBytes = Encoding.UTF32.GetBytes(password);
            using var argon = new Argon2id(passwordBytes)
            {
                Salt = salt,
                DegreeOfParallelism = parallelism,
                MemorySize = memorySize,
                Iterations = iterations
            };

            var hash = argon.GetBytes(32);

            return $"{Convert.ToBase64String(salt)}.{parallelism}.{memorySize}.{iterations}.{Convert.ToBase64String(hash)}";
            ;
        }


        public static bool VerifyPassword(string password, string passwordHashed)
        {
            var partsPassword = passwordHashed.Split(".");

            var salt = Convert.FromBase64String(partsPassword[0]);
            int parallelism = int.Parse(partsPassword[1]);
            int memorySize = int.Parse(partsPassword[2]);
            int iterations = int.Parse(partsPassword[3]);

            var hashSaved = Convert.FromBase64String(partsPassword[4]);

            var passwordBbytes = Encoding.UTF32.GetBytes(password);

            using var argon = new Argon2id(passwordBbytes)
            {
                Salt = salt,
                DegreeOfParallelism = parallelism,
                MemorySize = memorySize,
                Iterations = iterations
            };

            var newHash = argon.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(newHash, hashSaved);
        }
    }
}
