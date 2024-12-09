﻿using System.Security.Cryptography;
using System.Text;

namespace CentralAdminApp.Domain.Helpers
{
    
    public class SHA256Helper
    {
        public static string Encrypt(string value)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}