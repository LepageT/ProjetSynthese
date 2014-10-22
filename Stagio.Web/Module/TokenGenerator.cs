using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Stagio.Web.Module
{
    public class TokenGenerator
    {

        public string GenerateToken()
        {
            //For the token generation.
            Random random = new Random((int)DateTime.Now.Ticks);

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 15; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();

        }
    }
}