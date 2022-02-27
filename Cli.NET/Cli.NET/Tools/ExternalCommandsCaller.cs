using System.Diagnostics;

namespace Cli.NET.Tools
{
    public static class ExternalCommandsCaller
    {
        //TODO: MAKE UNIX/MACOS COMMANDS
        public static async Task<Tuple<string, string>?> Run(string command)
        {
            var system = Environment.OSVersion;

            return system.Platform switch
            {
                PlatformID.Win32NT => await CallWindowsCmd(command),
                PlatformID.Win32S => await CallWindowsCmd(command),
                PlatformID.Win32Windows => await CallWindowsCmd(command),
                PlatformID.WinCE => await CallWindowsCmd(command),
                _ => null,
            };
        }

        private static async Task<Tuple<string, string>> CallWindowsCmd(string command)
        {
            var system32Folder = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\System32\";
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = system32Folder + "cmd.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = system32Folder,
                }
            };

            proc.Start();
            string output = await proc.StandardOutput.ReadToEndAsync();
            string errors = await proc.StandardError.ReadToEndAsync();

            await proc.WaitForExitAsync();
            return Tuple.Create(output, errors);
        }
    }
}
