namespace Infrastructure.Security
{
    public interface IPasswordHashProvider
    {
        /// <summary>
        /// Creates a  hash of the password.
        /// </summary>
        string CreatePasswordHash(string password);

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        bool ValidatePassword(string password, string correctHash);
    }
}