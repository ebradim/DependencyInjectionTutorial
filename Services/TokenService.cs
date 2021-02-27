using System;

namespace Services
{
    public class TokenService
    {
        int rand;
        public TokenService()
        {
            rand = new Random().Next();
        }

        public void PrintToken()
        {
            Console.WriteLine($"{typeof(TokenService)} is printing your token: {rand}");
        }
        public int GetToken()
        {
            return this.rand;
        }
    }
}