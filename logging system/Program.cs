using Newtonsoft.Json;
using System;
using System.IO;

namespace logging_system
{
    class Program
    {
        static void Main(string[] args)
        {
            // add log with specific driver name
            var addPathWithDriverName = Log("C://TestAddLog//NewLogFolder", "Hello there this is a tes");

            Console.WriteLine(addPathWithDriverName);

            Console.WriteLine("______________________________________________________");

            // add log without specifing the driver name
            var obj = new { name = "SOMA", email = "LogTest@test.com" };
            var addPathWithoutDriverName = Log("LogFolder", JsonConvert.SerializeObject(obj));


            Console.WriteLine(addPathWithoutDriverName);

            Console.WriteLine("______________________________________________________");
        }

        static string Log(string path, string content)
        {
            try
            {
                var today = DateTime.Now;

                /** check the drive name 
                 * if the drive name doesn't exist we will user the default one C://Logs//
                 * 
                **/
                string drive = Path.GetPathRoot(path);
                if (string.IsNullOrEmpty(drive))
                    path = $"C://Logs//{path}";

                path = $"{path}//{today.ToString("yyyy-MM")}";

                // create folders in the path if doesn't exist
                Directory.CreateDirectory(path);

                // add file with today's date  name to the path
                path = $"{path}//{today.ToString("yyyy-MM-dd")}.txt";

                // create the file if not exist , append to the file if exist
                using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
                {
                    sw.WriteLine($"{today} : {content}");
                }

                return $"the path : {path} successfuly created!";
            }
            catch (Exception ex)
            {
                return $"failed to create the path due : {ex.Message.ToString()}";
            }
        }
    }
}
