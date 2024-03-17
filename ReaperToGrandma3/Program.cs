using System;
using ReaperToGrandma3.Classes;


namespace ReaperToGrandma3
{
    internal class Program
    {
        static readonly LocalConfigStore LocalConfigStore = new LocalConfigStore();
        
        public static string SelectedFile;

        static void Main(string[] args)
        {
            Console.Title = "reapma3";

            
            var configFileExists = LocalConfigStore.CheckConfigFileExists();

            if (!configFileExists)
            {
                LocalConfigStore.SetDefaults();
            }
            
            MainMenu();
        }

        internal static void MainMenu()
        {
            Console.Clear();
            
            Console.Write("\r\n\r\n                         _  \r\n ._ _   _. ._  ._ _   _. _) \r\n | (/_ (_| |_) | | | (_| _) \r\n           |                \r\n\r\n");


            var menu = new EasyConsole.Menu();
            menu.Add("Read Local Configuration", ReadLocalConfiguration);
            menu.Add("Update Local Configuration", WriteLocalConfiguration);
            menu.Add("Reset Local Configuration", ResetLocalConfiguration);
            menu.Add("Convert Reaper File", GetReaperTimeCodeFile);
            menu.Display();

        }

        private static void ResetLocalConfiguration()
        {
            LocalConfigStore.DeleteConfigFile();
            Console.WriteLine("Deleted");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            MainMenu();

        }

        private static void WriteLocalConfiguration()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("You can manually edit the configuration within LocalConfig.txt");
            Console.WriteLine("\n");
            var parameters = new ParametersLocalConfigStore();

            Console.WriteLine("Enter or paste save Location (no trailing slash) (eg. c:\\mygrandmafiles)");
            parameters.Datapools = Console.ReadLine();

            Console.WriteLine("Sequence Number (eg. 10)");
            parameters.SequenceNo = Console.ReadLine();

            Console.WriteLine("Executor (eg. 1.215)");
            parameters.Executor = Console.ReadLine();

            Console.WriteLine("Timecode Number (eg. 1)");
            parameters.TimecodeNo = Console.ReadLine();

            LocalConfigStore.WriteConfigFile(parameters);

            Console.WriteLine("Saved");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            MainMenu();
        }


        private static void ReadLocalConfiguration()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("You can manually edit the configuration within LocalConfig.txt");
            Console.WriteLine("\n");

            var config = LocalConfigStore.ReadConfigFile();
            Console.WriteLine("Local Configuration");
            Console.WriteLine("Save Location: " + config.Datapools);
            Console.WriteLine("Executor: " + config.Executor);
            Console.WriteLine("Sequence No.: " + config.SequenceNo);
            Console.WriteLine("Timecode Number: " + config.TimecodeNo);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            MainMenu();
        }


        /// <summary>
        /// Get Reaper Timecode File, submits for conversion
        /// </summary>
        private static void GetReaperTimeCodeFile()
        {
            Console.Clear();

            var fileOperations = new FileOperations();
            var filesInRootFolder = fileOperations.ListCsvFilesInRootFolder();

            var menuOfFiles = new EasyConsole.Menu();
            
            int i = 1;

            foreach (var file in filesInRootFolder)
            {
                menuOfFiles.Add(file, () => { SelectedFile = file; });
                i++;
            }

            menuOfFiles.Display();

            var reaperMarkerFileConversion = new ReaperMarkerFileConversion(SelectedFile);
            reaperMarkerFileConversion.Convert();

            Console.Clear();

            Console.Write("\r\n\r\n                         _  \r\n ._ _   _. ._  ._ _   _. _) \r\n | (/_ (_| |_) | | | (_| _) \r\n           |                \r\n\r\n");

            Console.WriteLine("Done, application will now close. Press any key to continue");
            Console.ReadLine();

        }
    }
}
