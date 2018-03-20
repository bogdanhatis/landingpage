using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class SQLHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=192.168.230.184;Initial Catalog=LandingPage;Integrated Security=False;User ID=sa;Password=1234abcd.;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";                
            }
        }
    }
}
