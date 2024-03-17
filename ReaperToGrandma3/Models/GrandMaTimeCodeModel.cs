using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaperToGrandma3.Models
{
    public class GrandMaTimeCodeModel
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class GMA3
        {

            private GMA3Timecode timecodeField;

            private string dataVersionField;

            /// <remarks/>
            public GMA3Timecode Timecode
            {
                get
                {
                    return this.timecodeField;
                }
                set
                {
                    this.timecodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string DataVersion
            {
                get
                {
                    return this.dataVersionField;
                }
                set
                {
                    this.dataVersionField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3Timecode
        {

            private GMA3TimecodeTrackGroup trackGroupField;

            private string guidField;

            private string nameField;

            private string gotoField;

            private string durationField;

            /// <remarks/>
            public GMA3TimecodeTrackGroup TrackGroup
            {
                get
                {
                    return this.trackGroupField;
                }
                set
                {
                    this.trackGroupField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Guid
            {
                get
                {
                    return this.guidField;
                }
                set
                {
                    this.guidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Goto
            {
                get
                {
                    return this.gotoField;
                }
                set
                {
                    this.gotoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Duration
            {
                get
                {
                    return this.durationField;
                }
                set
                {
                    this.durationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroup
        {

            private GMA3TimecodeTrackGroupMarkerTrack markerTrackField;

            private GMA3TimecodeTrackGroupTrack trackField;

            private string playField;

            private string recField;

            /// <remarks/>
            public GMA3TimecodeTrackGroupMarkerTrack MarkerTrack
            {
                get
                {
                    return this.markerTrackField;
                }
                set
                {
                    this.markerTrackField = value;
                }
            }

            /// <remarks/>
            public GMA3TimecodeTrackGroupTrack Track
            {
                get
                {
                    return this.trackField;
                }
                set
                {
                    this.trackField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Play
            {
                get
                {
                    return this.playField;
                }
                set
                {
                    this.playField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Rec
            {
                get
                {
                    return this.recField;
                }
                set
                {
                    this.recField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroupMarkerTrack
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroupTrack
        {

            private GMA3TimecodeTrackGroupTrackTimeRange timeRangeField;

            private string nameField;

            private string guidField;

            private string targetField;

            private string playField;

            private string recField;

            /// <remarks/>
            public GMA3TimecodeTrackGroupTrackTimeRange TimeRange
            {
                get
                {
                    return this.timeRangeField;
                }
                set
                {
                    this.timeRangeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Guid
            {
                get
                {
                    return this.guidField;
                }
                set
                {
                    this.guidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Target
            {
                get
                {
                    return this.targetField;
                }
                set
                {
                    this.targetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Play
            {
                get
                {
                    return this.playField;
                }
                set
                {
                    this.playField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Rec
            {
                get
                {
                    return this.recField;
                }
                set
                {
                    this.recField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroupTrackTimeRange
        {

            private GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent[] cmdSubTrackField;

            private string guidField;

            private string durationField;

            private string playField;

            private string recField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("CmdEvent", IsNullable = false)]
            public GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent[] CmdSubTrack
            {
                get
                {
                    return this.cmdSubTrackField;
                }
                set
                {
                    this.cmdSubTrackField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Guid
            {
                get
                {
                    return this.guidField;
                }
                set
                {
                    this.guidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Duration
            {
                get
                {
                    return this.durationField;
                }
                set
                {
                    this.durationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Play
            {
                get
                {
                    return this.playField;
                }
                set
                {
                    this.playField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Rec
            {
                get
                {
                    return this.recField;
                }
                set
                {
                    this.recField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroupTrackTimeRangeCmdEvent
        {

            private GMA3TimecodeTrackGroupTrackTimeRangeCmdEventRealtimeCmd realtimeCmdField;

            private string nameField;

            private string timeField;

            /// <remarks/>
            public GMA3TimecodeTrackGroupTrackTimeRangeCmdEventRealtimeCmd RealtimeCmd
            {
                get
                {
                    return this.realtimeCmdField;
                }
                set
                {
                    this.realtimeCmdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Time
            {
                get
                {
                    return this.timeField;
                }
                set
                {
                    this.timeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3TimecodeTrackGroupTrackTimeRangeCmdEventRealtimeCmd
        {

            private string typeField;

            private string sourceField;

            private byte userProfileField;

            private byte userField;

            private string statusField;

            private byte isRealtimeField;

            private byte isXFadeField;

            private byte ignoreFollowField;

            private byte ignoreCommandField;

            private byte assertField;

            private byte ignoreNetworkField;

            private byte fromTriggerNodeField;

            private byte ignoreExecTimeField;

            private byte issuedByTimecodeField;

            private byte fromLocalHardwareFaderField;

            private string objectField;

            private string execTokenField;

            private string valCueDestinationField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Source
            {
                get
                {
                    return this.sourceField;
                }
                set
                {
                    this.sourceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte UserProfile
            {
                get
                {
                    return this.userProfileField;
                }
                set
                {
                    this.userProfileField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte User
            {
                get
                {
                    return this.userField;
                }
                set
                {
                    this.userField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IsRealtime
            {
                get
                {
                    return this.isRealtimeField;
                }
                set
                {
                    this.isRealtimeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IsXFade
            {
                get
                {
                    return this.isXFadeField;
                }
                set
                {
                    this.isXFadeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IgnoreFollow
            {
                get
                {
                    return this.ignoreFollowField;
                }
                set
                {
                    this.ignoreFollowField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IgnoreCommand
            {
                get
                {
                    return this.ignoreCommandField;
                }
                set
                {
                    this.ignoreCommandField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Assert
            {
                get
                {
                    return this.assertField;
                }
                set
                {
                    this.assertField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IgnoreNetwork
            {
                get
                {
                    return this.ignoreNetworkField;
                }
                set
                {
                    this.ignoreNetworkField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte FromTriggerNode
            {
                get
                {
                    return this.fromTriggerNodeField;
                }
                set
                {
                    this.fromTriggerNodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IgnoreExecTime
            {
                get
                {
                    return this.ignoreExecTimeField;
                }
                set
                {
                    this.ignoreExecTimeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte IssuedByTimecode
            {
                get
                {
                    return this.issuedByTimecodeField;
                }
                set
                {
                    this.issuedByTimecodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte FromLocalHardwareFader
            {
                get
                {
                    return this.fromLocalHardwareFaderField;
                }
                set
                {
                    this.fromLocalHardwareFaderField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Object
            {
                get
                {
                    return this.objectField;
                }
                set
                {
                    this.objectField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ExecToken
            {
                get
                {
                    return this.execTokenField;
                }
                set
                {
                    this.execTokenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ValCueDestination
            {
                get
                {
                    return this.valCueDestinationField;
                }
                set
                {
                    this.valCueDestinationField = value;
                }
            }
        }


    }
}
