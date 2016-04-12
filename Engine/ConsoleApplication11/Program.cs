using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Engine
{
    class Program
    {

        String vertexStart = "";
        String vertexEnd = "";

        static void Main(String[] args)
        {
            String FileConnect = Environment.CurrentDirectory;
            String sdwConnectionString = System.IO.File.ReadAllText(FileConnect + @"\Config.txt");
            SqlConnection sdwDBConnection;

            sdwDBConnection = new SqlConnection(sdwConnectionString);

            // Open the connection
            sdwDBConnection.Open();
            
            Engine e = new Engine(args);
            
            e.engine(sdwDBConnection);

            Console.ReadLine();
        }

    }
}