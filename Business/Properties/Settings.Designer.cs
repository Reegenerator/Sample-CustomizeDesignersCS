// -------------------------------------------------------
// Automatically generated with Kodeo's Reegenerator
// Generator: CustomizeDesigners.Settings.SettingsRenderer
// Generation date: 2014-01-19 10:44
// Generated by: Win81vm\Admin
// -------------------------------------------------------

namespace Business.Properties {
	
	
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
	internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
		private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
		public static Settings Default {
			get {
				return defaultInstance;
			}
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("tete\"a")]
		public string Hello {
			get {
				return ((string)(this["Hello"]));
			} 
			set {
				this["Hello"] = value;
			} 
		}
 		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("0")]
		public uint Setting {
			get {
				return ((uint)(this["Setting"]));
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute(@"
        <?xml version=""1.0"" encoding=""utf-16""?>
        <ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
        <string>aa</string>
        <string>dfgs</string>
        <string>sdfgsd</string>
        <string>fgs</string>
        </ArrayOfString>
      ")]
		public global::System.Collections.Specialized.StringCollection Array {
			get {
				return ((global::System.Collections.Specialized.StringCollection)(this["Array"]));
			} 
			set {
				this["Array"] = value;
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
		[global::System.Configuration.DefaultSettingValueAttribute("http://")]
		public string WSUrl {
			get {
				return ((string)(this["WSUrl"]));
			} 
			set {
				this["WSUrl"] = value;
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("dfgdfgdfg")]
		public string Other {
			get {
				return ((string)(this["Other"]));
			} 
			set {
				this["Other"] = value;
			} 
		}
 		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("")]
		public string ddd {
			get {
				return ((string)(this["ddd"]));
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("")]
		public string xx {
			get {
				return ((string)(this["xx"]));
			} 
			set {
				this["xx"] = value;
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("ddd")]
		public string mysett {
			get {
				return ((string)(this["mysett"]));
			} 
			set {
				this["mysett"] = value;
			} 
		}
 		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
		[global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4609/WebService/Service.asmx")]
		public string Business_localhost_Service {
			get {
				return ((string)(this["Business_localhost_Service"]));
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("fffff")]
		public string Steve {
			get {
				return ((string)(this["Steve"]));
			} 
			set {
				this["Steve"] = value;
			} 
		}
 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("string setting value")]
		public string StringSetting {
			get {
				return ((string)(this["StringSetting"]));
			} 
			set {
				this["StringSetting"] = value;
			} 
		}
 		[global::System.Configuration.ApplicationScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
		[global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\DesignDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")]
		public string ConnectionString {
			get {
				return ((string)(this["ConnectionString"]));
			}
		}

 		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("test")]
		public string Test {
			get {
				return ((string)(this["Test"]));
			} 
			set {
				this["Test"] = value;
			} 
		}

	}
}
