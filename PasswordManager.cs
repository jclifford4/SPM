using System;
using System.Collections.Generic;

class PasswordManager
{
    private Dictionary<string, string> passwordStorage = new Dictionary<string, string>();

    public void StorePassword(string key, string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password), "Password cannot be null");
        }

        string encryptedPassword = EncryptionUtility.EncryptString(password);
        passwordStorage[key] = encryptedPassword;
        Console.WriteLine("Password stored successfully!");
    }

    public void RetrievePassword(string key)
    {
        if (passwordStorage.TryGetValue(key, out var encryptedPassword))
        {
            string decryptedPassword = EncryptionUtility.DecryptString(encryptedPassword);
            Console.WriteLine($"Decrypted Password for {key}: {decryptedPassword}");
        }
        else
        {
            Console.WriteLine("Password not found!");
        }
    }
}
