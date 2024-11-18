using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static string EncryptMD5(string text)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    static string EncryptSHA256(string text)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    static string EncryptSHA1(string text)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    static void Main(string[] args)
    {
        Console.Write(" > Introduce la cadena a encriptar usando MD5: ");
        string textoOriginal = Console.ReadLine();

        string hashMD5 = EncryptMD5(textoOriginal);
        string hashSHA256 = EncryptSHA256(textoOriginal);
        string hashSHA1 = EncryptSHA1(textoOriginal);

        Console.WriteLine($"Texto original: {textoOriginal}");
        Console.WriteLine($"Hash MD5: {hashMD5}");
        Console.WriteLine($"Hash SHA256: {hashSHA256}");
        Console.WriteLine($"Hash SHA1: {hashSHA1}");
    }
}

