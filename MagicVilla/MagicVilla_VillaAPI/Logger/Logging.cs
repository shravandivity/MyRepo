using System;
namespace MagicVilla_VillaAPI.Logger
{
	public class Logging : ILogging
	{
		public Logging()
		{
		}

        public void Log(string message, string type = "")
        {
            if (type == "error")
            {
                Console.WriteLine($"Error - {message}");
            }
            else
            {
                Console.WriteLine($"Message - {message}");
            }
        }
    }
}

