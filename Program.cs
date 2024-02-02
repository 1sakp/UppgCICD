using System;
using System.IO;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "/encrypt for encryption and /decrypt for decrypt\nSyntax: /[endpoint]?input='[string]'&key=[int]");

app.MapGet("/encrypt", (string input, int key) => Encrypt(input, key));

app.MapGet("/decrypt", (string input, int key) => Decrypt(input, key));

app.Run();

static string Encrypt(string input, int key)
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

static string Decrypt(string input, int key)
{
    return Encrypt(input, 26 - key); // Decrypts by using the oposite of encrypt
}