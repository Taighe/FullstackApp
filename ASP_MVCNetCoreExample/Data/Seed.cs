using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ASP_MVCNetCoreExample.Models;
using System.Security.Cryptography;
using System.Text;

namespace ASP_MVCNetCoreExample.Data
{
    public class Seed
    {
        private const string USERSEED_PATH = "Data/UserSeedData.json";
        private const string PASSWORD = "Passw0rd";
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) 
                return;

            var userData = await File.ReadAllTextAsync(USERSEED_PATH);
            var users = JsonSerializer.Deserialize<List<UserModel>>(userData);
            foreach(var user in users)
            {
                using(var hmac = new HMACSHA512())
                {
                    user.UserName = user.UserName.ToLower();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(PASSWORD));
                    user.PasswordSalt = hmac.Key;

                    context.Users.Add(user);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
