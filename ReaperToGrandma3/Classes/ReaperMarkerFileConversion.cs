using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using ReaperToGrandma3.Models;
using static ReaperToGrandma3.Models.GrandMaTimeCodeModel;

namespace ReaperToGrandma3.Classes
{
    public class ReaperMarkerFileConversion
    {
        private readonly FileInfo _file;
        private readonly string _sequenceNo;
        private readonly string _executor;
        private readonly string _datapool;
        private readonly string _timecodeNo;

        LocalConfigStore localConfigStore = new LocalConfigStore();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileToConvert"></param>
        public ReaperMarkerFileConversion(string fileToConvert)
        {
            //convert fileToConvert to file path
            _file = new FileInfo(fileToConvert);

            _sequenceNo = localConfigStore.ReadConfigFile().SequenceNo;
            _executor = localConfigStore.ReadConfigFile().Executor;
            _datapool = localConfigStore.ReadConfigFile().Datapools;
            _timecodeNo = localConfigStore.ReadConfigFile().TimecodeNo;
        }

        /// <summary>
        /// Convert the file to a format that can be imported into Grandma3
        /// </summary>
        public void Convert()
        {
            //read the file
            var fileContents = File.ReadAllLines(_file.FullName);

            //parse the file from CSV to object
            var reaperTimeCodeFileModel = new List<ReaperTimeCodeFileModel>();
            
            //loop through the file and add to the object
            int i = 0;
            foreach (var line in fileContents)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                var lineArray = line.Split(',');
                var timeCodeModel = new ReaperTimeCodeFileModel
                {
                    TimeCodeNumber = lineArray[0],
                    TimeCodeMarkerName = lineArray[1],
                    Time = decimal.Parse(lineArray[2])
                };
                reaperTimeCodeFileModel.Add(timeCodeModel);
            }

            //Convert to XML
            ConvertReaperTimeCodeObjectToGrandMa3TimeCodeXml(reaperTimeCodeFileModel);

            //create the XML file for the macro import
            GrandMaMacro marco = new GrandMaMacro();
            marco.GenerateCuesImportTimCodeFile(reaperTimeCodeFileModel);

        }

        /// <summary>
        /// Convert the Reaper Time Code Object to a format that can be imported into Grandma3
        /// </summary>
        /// <param name="reaperTimeCodeObject"></param>
        private void ConvertReaperTimeCodeObjectToGrandMa3TimeCodeXml(List<ReaperTimeCodeFileModel> reaperTimeCodeObject)
        {
            //get number of time codes in the object
            var numberOfTimeCodes = reaperTimeCodeObject.Count;
            //get last time code duration in the object
            var lastTimeCodeDuration = reaperTimeCodeObject[numberOfTimeCodes - 1].Time;

            var gma3 = new GMA3();

            gma3.DataVersion = "1.9.7.0";

            gma3.Timecode = new GMA3Timecode();
            gma3.Timecode.Guid = Regex.Replace(Guid.NewGuid().ToString("N").ToUpper(), ".{2}", "$0 ");
            gma3.Timecode.Name = $"timecode {_timecodeNo}"; //timecode 1
            gma3.Timecode.Goto = "as Go";
            gma3.Timecode.Duration = lastTimeCodeDuration.ToString(); //15.63s


            gma3.Timecode.TrackGroup = new GMA3TimecodeTrackGroup();
            gma3.Timecode.TrackGroup.Play = "";
            gma3.Timecode.TrackGroup.Rec = "";

            gma3.Timecode.TrackGroup.MarkerTrack = new GMA3TimecodeTrackGroupMarkerTrack();
            gma3.Timecode.TrackGroup.MarkerTrack.Name = "Marker";

            gma3.Timecode.TrackGroup.Track = new GMA3TimecodeTrackGroupTrack();
            gma3.Timecode.TrackGroup.Track.Name = $"CueList {_sequenceNo}"; //CueList 10
            gma3.Timecode.TrackGroup.Track.Guid = Regex.Replace(Guid.NewGuid().ToString("N").ToUpper(), ".{2}", "$0 ");
            gma3.Timecode.TrackGroup.Track.Target = $"ShowData.DataPools.Default.Sequences.CueList {_sequenceNo}"; //match track.name 
            gma3.Timecode.TrackGroup.Track.Play = "";
            gma3.Timecode.TrackGroup.Track.Rec = "";

            gma3.Timecode.TrackGroup.Track.TimeRange = new GMA3TimecodeTrackGroupTrackTimeRange();
            gma3.Timecode.TrackGroup.Track.TimeRange.Guid = Regex.Replace(Guid.NewGuid().ToString("N").ToUpper(), ".{2}", "$0 ");
            gma3.Timecode.TrackGroup.Track.TimeRange.Duration = "To End";
            gma3.Timecode.TrackGroup.Track.TimeRange.Play = "";
            gma3.Timecode.TrackGroup.Track.TimeRange.Rec = "";
            
            gma3.Timecode.TrackGroup.Track.TimeRange.CmdSubTrack = new GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent[numberOfTimeCodes];

            int i = 0;
            int valCueDestination = 1000;

            foreach (var reaperTimeCodeFileModel in reaperTimeCodeObject)
            {
                GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent t = new GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent();
                t.Name = "Go+";
                t.Time = String.Format("{0:0.00000000}s", reaperTimeCodeFileModel.Time); ; //1.36000000s

                t.RealtimeCmd = new GMA3TimecodeTrackGroupTrackTimeRangeCmdEventRealtimeCmd();
                t.RealtimeCmd.Type = "Key";
                t.RealtimeCmd.Source = "Original";
                t.RealtimeCmd.UserProfile = 0;
                t.RealtimeCmd.User = 0;
                t.RealtimeCmd.Status = "On";
                t.RealtimeCmd.IsRealtime = 0;
                t.RealtimeCmd.IsXFade = 0;
                t.RealtimeCmd.IgnoreFollow = 0;
                t.RealtimeCmd.Assert = 0;
                t.RealtimeCmd.IgnoreNetwork = 0;
                t.RealtimeCmd.FromTriggerNode = 0;
                t.RealtimeCmd.IgnoreExecTime = 0;
                t.RealtimeCmd.IssuedByTimecode = 0;
                t.RealtimeCmd.FromLocalHardwareFader = 0;
                t.RealtimeCmd.Object = "12.12.0.5.9";
                t.RealtimeCmd.ExecToken = "Go+";
                t.RealtimeCmd.ValCueDestination = $"12.12.0.5.9.{valCueDestination}"; //final val inc by 1000 each cmd
                gma3.Timecode.TrackGroup.Track.TimeRange.CmdSubTrack[i] = t;
                i++;
                valCueDestination += 1000;
            }
            
            Helpers.CheckFolderExistsAndCreate($"{_datapool}\\timecodes");

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer slz = new XmlSerializer(typeof(GMA3));
            using (StreamWriter writer = new StreamWriter($"{_datapool}\\timecodes\\GrandMa3TimeCode.xml"))
            {
                slz.Serialize(writer, gma3, ns);
                writer.Close();
            }


        }



    }
}
