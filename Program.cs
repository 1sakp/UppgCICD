using System;
using System.IO;
using System.Security.Cryptography;
using application;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "/encrypt for encryption and /decrypt for decrypt\nSyntax: /[endpoint]?input='[string]'&key=[int]\n[IMPORTANT]--> Key must be larger than 0 and smaller than 27");

app.MapGet("/encrypt", (string input, int key) => Crypt.Encrypt(input, key));

app.MapGet("/decrypt", (string input, int key) => Crypt.Decrypt(input, key));

app.Run();

namespace application
{
    class Crypt
    {
        public static string Encrypt(string input, int key)
        {
            char[] result = input.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    char offset = char.IsUpper(result[i]) ? 'A' : 'a';
                    result[i] = (char)(((result[i] + key - offset) % 26) + offset);
                }
            }
            return new string(result);
        }

        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }
    }
}