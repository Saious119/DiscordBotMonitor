using System.Diagnostics;

namespace DBM
{
    public class BotController
    {
        public string BotStatus = "Offline :'(";
        Process CurrentProc;
        string BotName;
        public string Error = "No Errors!";
        public BotController(string Botname)  { BotName = Botname; } 

        public void StartBot(string startscript, string exec, string dir)
        {
            if (BotStatus != "Online")
            {
                try
                {

                    CurrentProc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = exec,
                            Arguments = startscript,
                            UseShellExecute = false,
                            WorkingDirectory = dir,
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
                    Error = e.Message;
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
