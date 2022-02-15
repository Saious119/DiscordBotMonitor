using System.Diagnostics;

namespace DBM
{
    public class BotController
    {
        public string BotStatus = "Offline :'(";
        Process CurrentProc;
        string BotName;
        public BotController(string Botname)  { BotName = Botname; } 

        public void StartBot(string startscript)
        {
            if (BotStatus != "Online")
            {
                try
                {

                    CurrentProc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = startscript,
                            Arguments = "",
                            UseShellExecute = false,
                            WorkingDirectory = "/home/andym/DiscordBotMonitor/DBM",
                            RedirectStandardOutput = true,
                            CreateNoWindow = false
                        }
                    };
                    CurrentProc.Start();
                    BotStatus = "Online";
                }
                catch (Exception e)
                {
                    BotStatus = "Offline :'(";
                    Console.WriteLine(e.Message);
                }
            }

        }
        public void StopBot()
        {
            if (BotStatus == "Online")
            {
                CurrentProc.Kill(true);
                CurrentProc.Dispose();
                BotStatus = "Offline";
            }
        }
    }
}
