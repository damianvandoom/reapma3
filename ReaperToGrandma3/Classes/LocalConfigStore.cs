using System;
using System.IO;
using Newtonsoft.Json;

namespace ReaperToGrandma3.Classes
{
    public class LocalConfigStore
    {
        private ParametersLocalConfigStore _parametersLocalConfigStore;

        /// <summary>
        ///  This method is used to write the local config file
        /// </summary>
        /// <param name="parameters"></param>
        public void WriteConfigFile(ParametersLocalConfigStore parameters)
        {
            _parametersLocalConfigStore = parameters;

            var messageString = JsonConvert.SerializeObject(_parametersLocalConfigStore);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LocalConfig.txt", messageString);
        }

        /// <summary>
        ///  This method is used to read the local config file
        /// </summary>
        /// <returns></returns>
        public ParametersLocalConfigStore ReadConfigFile()
        {
            var config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "LocalConfig.txt");

            var configFile = JsonConvert.DeserializeObject<ParametersLocalConfigStore>(config);

            return configFile;

        }

        /// <summary>
        ///  This method is used to check if the local config file exists
        /// </summary>
        /// <returns></returns>
        public bool CheckConfigFileExists()
        {
            return File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LocalConfig.txt");
        }

        /// <summary>
        ///  This method is used to delete the local config file
        /// </summary>
        public void DeleteConfigFile()
        {
            if (CheckConfigFileExists())
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "LocalConfig.txt");

            }

            Console.WriteLine("Config removed, closing app");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void SetDefaults()
        {
            var defaults = new ParametersLocalConfigStore();
            defaults.SequenceNo = "10";
            defaults.Executor = "1.215";
            defaults.Datapools = @"C:\\ProgramData\\MALightingTechnology\\gma3_library\\datapools";
            defaults.TimecodeNo = @"1";//timecode 1

            WriteConfigFile(defaults);
        }
    }


    /// <summary>
    /// This class is used to store the parameters of the local config file
    /// </summary>
    public class ParametersLocalConfigStore
    {
        public string SequenceNo { get; set; }
        public string Executor { get; set; }
        public string Datapools { get; set; }
        public string TimecodeNo { get; set; }

    }

}
