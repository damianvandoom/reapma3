using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaperToGrandma3.Models
{
    public class GrandMaMacroModel
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class GMA3
        {

            private GMA3Macro macroField;

            private string dataVersionField;

            /// <remarks/>
            public GMA3Macro Macro
            {
                get
                {
                    return this.macroField;
                }
                set
                {
                    this.macroField = value;
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
        public partial class GMA3Macro
        {

            private GMA3MacroMacroLine[] macroLineField;

            private string nameField;

            private string guidField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MacroLine")]
            public GMA3MacroMacroLine[] MacroLine
            {
                get
                {
                    return this.macroLineField;
                }
                set
                {
                    this.macroLineField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
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
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class GMA3MacroMacroLine
        {

            private string commandField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Command
            {
                get
                {
                    return this.commandField;
                }
                set
                {
                    this.commandField = value;
                }
            }
        }


    }
}
