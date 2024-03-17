using ReaperToGrandma3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


namespace ReaperToGrandma3.Classes
{
    public class GrandMaMacro
    {
        LocalConfigStore localConfigStore = new LocalConfigStore();
        private readonly string _sequenceNo;
        private readonly string _executor;
        private readonly string _datapool;
        private readonly string _timecodeNo;

        /// <summary>
        /// Constructor
        /// </summary>
        public GrandMaMacro()
        {
            _sequenceNo = localConfigStore.ReadConfigFile().SequenceNo;
            _executor = localConfigStore.ReadConfigFile().Executor;
            _datapool = localConfigStore.ReadConfigFile().Datapools;
            _timecodeNo = localConfigStore.ReadConfigFile().TimecodeNo;
        }
        
        /// <summary>
        /// Generate the macro file for import into Grandma3
        /// </summary>
        /// <param name="reaperTimeCodeObject"></param>
        public void GenerateCuesImportTimCodeFile(List<ReaperTimeCodeFileModel> reaperTimeCodeObject)
        {
            //get number of time codes in the object
            var numberOfTimeCodes = reaperTimeCodeObject.Count;

            var gma3 = new GrandMaMacroModel.GMA3();

            gma3.DataVersion = "1.0.0.3";

            gma3.Macro = new GrandMaMacroModel.GMA3Macro();
            gma3.Macro.name = "Time Code Import";
            gma3.Macro.Guid = Regex.Replace(Guid.NewGuid().ToString("N").ToUpper(), ".{2}", "$0 ");

            gma3.Macro.MacroLine = new GrandMaMacroModel.GMA3MacroMacroLine[numberOfTimeCodes+7];

            GrandMaMacroModel.GMA3MacroMacroLine commandPrefix = new GrandMaMacroModel.GMA3MacroMacroLine();
            commandPrefix.Command = $"Delete timecode {_timecodeNo} /nc"; //Delete timecode 1 /nc

            gma3.Macro.MacroLine[0] = commandPrefix;
            
            int i = 1;
            foreach (var reaperTimeCodeFileModel in reaperTimeCodeObject)
            {
                GrandMaMacroModel.GMA3MacroMacroLine m = new GrandMaMacroModel.GMA3MacroMacroLine();

                string commandLine = $@"Store Sequence {_sequenceNo} Cue {i} ""{reaperTimeCodeFileModel.TimeCodeMarkerName}""   /m";

                m.Command = commandLine;

                gma3.Macro.MacroLine[i] = m;

                i++;
            }

            var suffix = MarcoSuffix();
            foreach (var ms in MarcoSuffix())
            {
                GrandMaMacroModel.GMA3MacroMacroLine macro = new GrandMaMacroModel.GMA3MacroMacroLine();

                macro.Command = ms;

                gma3.Macro.MacroLine[i] = macro;
                i++;
            }

            Helpers.CheckFolderExistsAndCreate($"{_datapool}\\macros");

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer slz = new XmlSerializer(typeof(GrandMaMacroModel.GMA3));
            using (StreamWriter writer = new StreamWriter($"{_datapool}\\macros\\GrandMa3TimeCodeMacro.xml"))
            {
                slz.Serialize(writer, gma3, ns);
                writer.Close();
            }
        }

        private List<string> MarcoSuffix()
        {
            List<string> commandSuffix = new List<string>();
            commandSuffix.Add($@"Assign Sequence {_sequenceNo} At Page {_executor}");
            commandSuffix.Add($@"Label Sequence {_sequenceNo} ""CueList {_sequenceNo}""");
            commandSuffix.Add($@"Import Timecode {_timecodeNo} ""GrandMa3TimeCode""  /nc");
            commandSuffix.Add($@"Label Timecode {_timecodeNo} ""timecode {_timecodeNo}""  /nc");

            return commandSuffix;
        }
        
    }
}
