// -------------------------------------------------------
// Automatically generated with Kodeo's Reegenerator
// Generator: RgenTemplate (internal)
// Generation date: 2013-12-22 11:23
// Generated by: KODEOACER\radusib
// -------------------------------------------------------
namespace CustomizeDesigners.Dbml
{
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reegenerator", "2.0.4.0")]
    public partial class DbmlRenderer : Kodeo.Reegenerator.Generators.CodeRenderer
    {
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<returns></returns>
        public override Kodeo.Reegenerator.Generators.RenderResults Render()
        {
            base.Output.Write("#pragma warning disable 1591\r\n \r\n// ---------------------------------------------" +
                    "----------\r\n// Automatically generated with Kodeo\'s Reegenerator\r\n// Generator: " +
                    "CustomizeDesigners.Dbml.DbmlRenderer\r\n// Generation date: ");
            base.Output.Write( System.DateTime.Now.ToString("yyyy-MM-dd hh:mm") );
            base.Output.Write("\r\n// Generated by: ");
            base.Output.Write( System.Security.Principal.WindowsIdentity.GetCurrent().Name );
            base.Output.Write("\r\n// -------------------------------------------------------\r\n\r\nnamespace ");
            base.Output.Write( base.ProjectItem.CodeNamespace );
            base.Output.Write(@"
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name=""");
            base.Output.Write( this.database.Name );
            base.Output.Write("\")]\r\n\t");
            base.Output.Write( GetAccessModifier(this.database.AccessModifier) );
            base.Output.Write(" partial class ");
            base.Output.Write( this.database.Class );
            base.Output.Write(" : ");
            base.Output.Write( string.IsNullOrEmpty(this.database.BaseType) ? "System.Data.Linq.DataContext" : this.database.BaseType );
            base.Output.Write(" \r\n\t{\r\n\t\t\r\n\t\tprivate static System.Data.Linq.Mapping.MappingSource mappingSource " +
                    "= new AttributeMappingSource();\r\n\t\t\r\n\t#region Extensibility Method Definitions\r\n" +
                    "\tpartial void OnCreated();\r\n");
 RenderDatabaseExtensibility(); 
            base.Output.Write("\r\n\t#endregion\r\n\t\r\n\t\tpublic ");
            base.Output.Write( this.database.Class );
            base.Output.Write("() : \r\n\t\t\t\tbase(global::");
            base.Output.Write( this.database.Connection.SettingsObjectName );
            base.Output.Write(".Default.");
            base.Output.Write( this.database.Connection.SettingsPropertyName );
            base.Output.Write(", mappingSource)\r\n\t\t{\r\n\t\t\tOnCreated();\r\n\t\t}\r\n\r\n\t\tpublic ");
            base.Output.Write( this.database.Class );
            base.Output.Write("(string connection) : \r\n\t\t\t\tbase(connection, mappingSource)\r\n\t\t{\r\n\t\t\tOnCreated();" +
                    "\r\n\t\t}\r\n\t\t\r\n\t\tpublic ");
            base.Output.Write( this.database.Class );
            base.Output.Write("(System.Data.IDbConnection connection) : \r\n\t\t\t\tbase(connection, mappingSource)\r\n\t" +
                    "\t{\r\n\t\t\tOnCreated();\r\n\t\t}\r\n\t\t\r\n\t\tpublic ");
            base.Output.Write( this.database.Class );
            base.Output.Write("(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : \r\n\t\t\t" +
                    "\tbase(connection, mappingSource)\r\n\t\t{\r\n\t\t\tOnCreated();\r\n\t\t}\r\n\t\t\r\n\t\tpublic ");
            base.Output.Write( this.database.Class );
            base.Output.Write("(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource map" +
                    "pingSource) : \r\n\t\t\t\tbase(connection, mappingSource)\r\n\t\t{\r\n\t\t\tOnCreated();\r\n\t\t}\r\n" +
                    "");
 
	RenderDatabaseTablesProperties(); 
	RenderDatabaseFunctions(); 

            base.Output.Write("\r\n\t}\r\n");
 
	RenderTables();
	RenderFunctionsResults(); 

            base.Output.Write("\r\n}\r\n#pragma warning restore 1591");
            base.Output.WriteLine();
            return new Kodeo.Reegenerator.Generators.RenderResults(base.Output.ToString());
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        public virtual void RenderDatabaseTableExtensibility(Table table)
        {
            base.Output.Write("\tpartial void Insert");
            base.Output.Write( table.Type.Name );
            base.Output.Write("(");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" instance);\r\n\tpartial void Update");
            base.Output.Write( table.Type.Name );
            base.Output.Write("(");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" instance);\r\n\tpartial void Delete");
            base.Output.Write( table.Type.Name );
            base.Output.Write("(");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" instance);");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        public virtual void RenderDatabaseTableProperty(Table table)
        {
            base.Output.Write("\t\tpublic System.Data.Linq.Table< ");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" > ");
            base.Output.Write( table.Member );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this.GetTable< ");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" >();\r\n\t\t\t}\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        public virtual void RenderTable(Table table)
        {
            base.Output.Write("\t[Table(Name=\"");
            base.Output.Write( table.Name );
            base.Output.Write("\")]\r\n\t");
            base.Output.Write( GetAccessModifier(table.AccessModifier) );
            base.Output.Write(" partial class ");
            base.Output.Write( table.Type.Name );
            base.Output.Write(" : INotifyPropertyChanging, INotifyPropertyChanged\r\n\t{\r\n\t\t\r\n\t\tprivate static Prop" +
                    "ertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(Str" +
                    "ing.Empty);\r\n\r\n");
 RenderTypePrivateProperties(table.Type); 
            base.Output.Write("\t\t\r\n\r\n\t#region Extensibility Method Definitions\r\n\tpartial void OnLoaded();\r\n\tpart" +
                    "ial void OnValidate(System.Data.Linq.ChangeAction action);\r\n\tpartial void OnCrea" +
                    "ted();\r\n");
 RenderTableColumnsExtensibilities(table); 
            base.Output.Write("\r\n\t#endregion\r\n\t\t\r\n\t\tpublic ");
            base.Output.Write( table.Type.Name );
            base.Output.Write("()\r\n\t\t{\r\n");
 RenderTableAssociationsInitializations(table); 
            base.Output.Write("\r\n\t\t\tOnCreated();\r\n\t\t}\r\n");
  RenderTableProperties(table); 
            base.Output.Write(@"
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
");
 RenderTableAssociationsAttachDetach(table); 
            base.Output.Write("\r\n\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        public virtual void RenderTableSimple(Table table)
        {
            base.Output.Write("\t[Table(Name=\"");
            base.Output.Write( table.Name );
            base.Output.Write("\")]\r\n\t");
            base.Output.Write( GetAccessModifier(table.AccessModifier) );
            base.Output.Write(" partial class ");
            base.Output.Write( table.Type.Name );
            base.Output.Write("\r\n\t{\r\n");
 RenderTypePrivateProperties(table.Type); 
            base.Output.Write("\t\t\r\n\t\tpublic ");
            base.Output.Write( table.Type.Name );
            base.Output.Write("()\r\n\t\t{\r\n\t\t}\r\n");
  RenderTableProperties(table, true); 
            base.Output.Write("\r\n\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="column"></param>
        public virtual void RenderColumnAsPrivateProperty(Column column)
        {
            base.Output.Write("\t\tprivate ");
            base.Output.Write( ColumnType(column) );
            base.Output.Write(" _");
            base.Output.Write( column.Name );
            base.Output.Write(";");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="association"></param>
        public virtual void RenderAssociationAsPrivateProperty(Association association)
        {
 if (association.IsForeignKey) { 
            base.Output.Write("\t\r\n\t\tprivate EntityRef< ");
            base.Output.Write( association.Type );
            base.Output.Write(" > _");
            base.Output.Write( association.Member );
            base.Output.Write(";\r\n");
 } else { 
            base.Output.Write("\r\n\t\tprivate EntitySet< ");
            base.Output.Write( association.Type );
            base.Output.Write(" > _");
            base.Output.Write( association.Member );
            base.Output.Write(";\r\n");
 } 
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="column"></param>
        public virtual void RenderTableColumnExtensibility(Column column)
        {
            base.Output.Write("    partial void On");
            base.Output.Write( column.Name );
            base.Output.Write("Changing(");
            base.Output.Write( ColumnType(column) );
            base.Output.Write(" value);\r\n    partial void On");
            base.Output.Write( column.Name );
            base.Output.Write("Changed();");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="association"></param>
        public virtual void RenderTableAssociationInitialization(Association association)
        {
 if (association.IsForeignKey) { 
            base.Output.Write("\t\r\n\t\t\tthis._");
            base.Output.Write( association.Member );
            base.Output.Write(" = default(EntityRef< ");
            base.Output.Write( association.Type );
            base.Output.Write(" >);\r\n");
 } else { 
            base.Output.Write("\r\n\t\t\tthis._");
            base.Output.Write( association.Member );
            base.Output.Write(" = new EntitySet< ");
            base.Output.Write( association.Type );
            base.Output.Write(" >(new Action< ");
            base.Output.Write( association.Type );
            base.Output.Write(" >(this.attach_");
            base.Output.Write( association.Member );
            base.Output.Write("), new Action< ");
            base.Output.Write( association.Type );
            base.Output.Write(" >(this.detach_");
            base.Output.Write( association.Member );
            base.Output.Write("));\r\n");
 } 
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        ///<param name="column"></param>
        public virtual void RenderColumnAsProperty(Table table, Column column)
        {
            base.Output.Write("\t\t[Column(");
            base.Output.Write( GetPropertyAttributes(table, column) );
            base.Output.Write(")]\r\n\t\tpublic ");
            base.Output.Write( ColumnType(column) );
            base.Output.Write(" ");
            base.Output.Write( column.Name );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this._");
            base.Output.Write( column.Name );
            base.Output.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\tif ((this._");
            base.Output.Write( column.Name );
            base.Output.Write(" != value))\r\n\t\t\t\t{\r\n");
 RenderForeignKeysChecks(table, column); 
            base.Output.Write("\t\t\t\t\r\n\t\t\t\t\tthis.On");
            base.Output.Write( column.Name );
            base.Output.Write("Changing(value);\r\n\t\t\t\t\tthis.SendPropertyChanging();\r\n\t\t\t\t\tthis._");
            base.Output.Write( column.Name );
            base.Output.Write(" = value;\r\n\t\t\t\t\tthis.SendPropertyChanged(\"");
            base.Output.Write( column.Name );
            base.Output.Write("\");\r\n\t\t\t\t\tthis.On");
            base.Output.Write( column.Name );
            base.Output.Write("Changed();\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        ///<param name="column"></param>
        public virtual void RenderColumnAsPropertySimple(Table table, Column column)
        {
            base.Output.Write("\t\t[Column(");
            base.Output.Write( GetPropertyAttributes(table, column) );
            base.Output.Write(")]\r\n\t\tpublic ");
            base.Output.Write( ColumnType(column) );
            base.Output.Write(" ");
            base.Output.Write( column.Name );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this._");
            base.Output.Write( column.Name );
            base.Output.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\tif ((this._");
            base.Output.Write( column.Name );
            base.Output.Write(" != value))\r\n\t\t\t\t{\r\n\t\t\t\t\tthis._");
            base.Output.Write( column.Name );
            base.Output.Write(" = value;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="column"></param>
        ///<param name="association"></param>
        public virtual void RenderForeignKeyCheck(Column column, Association association)
        {
            base.Output.Write("\t\t\t\t\tif (this._");
            base.Output.Write( association.Member );
            base.Output.Write(".HasLoadedOrAssignedValue)\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tthrow new System.Data.Linq.ForeignKeyRe" +
                    "ferenceAlreadyHasValueException();\r\n\t\t\t\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="association"></param>
        public virtual void RenderForeignKeyAssociationAsProperty(Association association)
        {
            base.Output.Write("\t\t[Association(Name=\"");
            base.Output.Write( association.Name );
            base.Output.Write("\", Storage=\"_");
            base.Output.Write( association.Member );
            base.Output.Write("\", OtherKey=\"");
            base.Output.Write( association.OtherKey );
            base.Output.Write("\")]\r\n\t\tpublic EntitySet< ");
            base.Output.Write( association.Type );
            base.Output.Write(" > ");
            base.Output.Write( association.Member );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this._");
            base.Output.Write( association.Member );
            base.Output.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\tthis._");
            base.Output.Write( association.Member );
            base.Output.Write(".Assign(value);\r\n\t\t\t}\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        ///<param name="association"></param>
        public virtual void RenderAssociationAsProperty(Table table, Association association)
        {
            base.Output.Write("\t\t[Association(Name=\"");
            base.Output.Write( association.Name );
            base.Output.Write("\", Storage=\"_");
            base.Output.Write( association.Member );
            base.Output.Write("\"");
            base.Output.Write( RenderAssociationAsPropertyHelper3(association) );
            base.Output.Write(", IsForeignKey=true)]\r\n\t\tpublic ");
            base.Output.Write( association.Type );
            base.Output.Write(" ");
            base.Output.Write( association.Member );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this._");
            base.Output.Write( association.Member );
            base.Output.Write(".Entity;\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\t");
            base.Output.Write( association.Type );
            base.Output.Write(" previousValue = this._");
            base.Output.Write( association.Member );
            base.Output.Write(".Entity;\r\n\t\t\t\tif (((previousValue != value) \r\n\t\t\t\t\t\t\t|| (this._");
            base.Output.Write( association.Member );
            base.Output.Write(".HasLoadedOrAssignedValue == false)))\r\n\t\t\t\t{\r\n\t\t\t\t\tthis.SendPropertyChanging();\r\n" +
                    "\t\t\t\t\tif ((previousValue != null))\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tthis._");
            base.Output.Write( association.Member );
            base.Output.Write(".Entity = null;\r\n\t\t\t\t\t\tpreviousValue.");
            base.Output.Write( table.Member );
            base.Output.Write(".Remove(this);\r\n\t\t\t\t\t}\r\n\t\t\t\t\tthis._");
            base.Output.Write( association.Member );
            base.Output.Write(".Entity = value;\r\n\t\t\t\t\tif ((value != null))\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tvalue.");
            base.Output.Write( table.Member );
            base.Output.Write(".Add(this);\r\n\t\t\t\t\t\t");
            base.Output.Write( RenderAssociationAsPropertyHelper1(table, association) );
            base.Output.Write("\r\n\t\t\t\t\t}\r\n\t\t\t\t\telse\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t");
            base.Output.Write( RenderAssociationAsPropertyHelper2(table, association) );
            base.Output.Write("\r\n\t\t\t\t\t}\r\n\t\t\t\t\tthis.SendPropertyChanged(\"");
            base.Output.Write( association.Member );
            base.Output.Write("\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="table"></param>
        ///<param name="association"></param>
        ///<param name="parentAssociation"></param>
        public virtual void RenderTableAssociationAttachDetach(Table table, Association association, Association parentAssociation)
        {
            base.Output.Write("\t\tprivate void attach_");
            base.Output.Write( association.Member );
            base.Output.Write("(");
            base.Output.Write( association.Type );
            base.Output.Write(" entity)\r\n\t\t{\r\n\t\t\tthis.SendPropertyChanging();\r\n\t\t\tentity.");
            base.Output.Write( parentAssociation.Member );
            base.Output.Write(" = this;\r\n\t\t}\r\n\t\t\r\n\t\tprivate void detach_");
            base.Output.Write( association.Member );
            base.Output.Write("(");
            base.Output.Write( association.Type );
            base.Output.Write(" entity)\r\n\t\t{\r\n\t\t\tthis.SendPropertyChanging();\r\n\t\t\tentity.");
            base.Output.Write( parentAssociation.Member );
            base.Output.Write(" = null;\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="function"></param>
        public virtual void RenderDatabaseSPReturningRecordset(Function function)
        {
            base.Output.Write("\t\t[Function(Name=\"");
            base.Output.Write( function.Name );
            base.Output.Write("\")]\r\n\t\tpublic ISingleResult< ");
            base.Output.Write( ((Dbml.Type)function.Items[0]).Name );
            base.Output.Write(" > ");
            base.Output.Write( function.Method );
            base.Output.Write("(");
            base.Output.Write( GetFunctionParametersDeclare(function) );
            base.Output.Write(")\r\n\t\t{\r\n\t\t\tIExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(Met" +
                    "hodInfo.GetCurrentMethod()))");
            base.Output.Write( GetFunctionParametersCall(function) );
            base.Output.Write(");");
            base.Output.Write( RenderFillOutParameter(function) );
            base.Output.Write("\r\n\t\t\treturn ((ISingleResult< ");
            base.Output.Write( ((Dbml.Type)function.Items[0]).Name );
            base.Output.Write(" >)(result.ReturnValue));\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="function"></param>
        public virtual void RenderDatabaseSPReturningSingleValue(Function function)
        {
            base.Output.Write("\t\t[Function(Name=\"");
            base.Output.Write( function.Name );
            base.Output.Write("\")]\r\n\t\tpublic ");
            base.Output.Write( LangType(((Return)function.Items[0]).Type) );
            base.Output.Write(" ");
            base.Output.Write( function.Method );
            base.Output.Write("(");
            base.Output.Write( GetFunctionParametersDeclare(function) );
            base.Output.Write(")\r\n\t\t{\r\n\t\t\tIExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(Met" +
                    "hodInfo.GetCurrentMethod()))");
            base.Output.Write( GetFunctionParametersCall(function) );
            base.Output.Write(");");
            base.Output.Write( RenderFillOutParameter(function) );
            base.Output.Write("\r\n\t\t\treturn ((");
            base.Output.Write( LangType(((Return)function.Items[0]).Type) );
            base.Output.Write(")(result.ReturnValue));\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="function"></param>
        ///<param name="type"></param>
        public virtual void RenderFunctionResult(Function function, Dbml.Type type)
        {
            base.Output.Write("\t");
            base.Output.Write( GetAccessModifier(function.AccessModifier) );
            base.Output.Write(" partial class ");
            base.Output.Write( type.Name );
            base.Output.Write("\r\n\t{\r\n");
 RenderTypePrivateProperties(type); 
            base.Output.Write("\t\t\r\n\t\tpublic ");
            base.Output.Write( type.Name );
            base.Output.Write("()\r\n\t\t{\r\n\t\t}\r\n");
  RenderFunctionResultProperties(function); 
            base.Output.Write("\r\n\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="type"></param>
        ///<param name="column"></param>
        public virtual void RenderFunctionResultProperty(Dbml.Type type, Column column)
        {
            base.Output.Write("\t\t[Column(");
            base.Output.Write( GetFunctionResultPropertyAttributes(type, column) );
            base.Output.Write(")]\r\n\t\tpublic ");
            base.Output.Write( ColumnType(column) );
            base.Output.Write(" ");
            base.Output.Write( column.Name );
            base.Output.Write("\r\n\t\t{\r\n\t\t\tget\r\n\t\t\t{\r\n\t\t\t\treturn this._");
            base.Output.Write( column.Name );
            base.Output.Write(";\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\tif ((this._");
            base.Output.Write( column.Name );
            base.Output.Write(" != value))\r\n\t\t\t\t{\r\n\t\t\t\t\tthis._");
            base.Output.Write( column.Name );
            base.Output.Write(" = value;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="function"></param>
        public virtual void RenderDatabaseFnSingleValue(Function function)
        {
            base.Output.Write("\t\t[Function(Name=\"");
            base.Output.Write( function.Name );
            base.Output.Write("\", IsComposable=true)]\r\n\t\tpublic System.Nullable< ");
            base.Output.Write( LangType(((Return)function.Items[0]).Type) );
            base.Output.Write(" > ");
            base.Output.Write( function.Method );
            base.Output.Write("(");
            base.Output.Write( GetFunctionParametersDeclare(function) );
            base.Output.Write(")\r\n\t\t{\r\n\t\t\treturn ((System.Nullable< ");
            base.Output.Write( LangType(((Return)function.Items[0]).Type) );
            base.Output.Write(" >)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))");
            base.Output.Write( GetFunctionParametersCall(function) );
            base.Output.Write(").ReturnValue));\r\n\t\t}");
            base.Output.WriteLine();
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="function"></param>
        public virtual void RenderDatabaseFnRecordset(Function function)
        {
            base.Output.Write("\t\t[Function(Name=\"");
            base.Output.Write( function.Name );
            base.Output.Write("\", IsComposable=true)]\r\n\t\tpublic IQueryable< ");
            base.Output.Write( ((Dbml.Type)function.Items[0]).Name );
            base.Output.Write(" > ");
            base.Output.Write( function.Method );
            base.Output.Write("(");
            base.Output.Write( GetFunctionParametersDeclare(function) );
            base.Output.Write(")\r\n\t\t{\r\n\t\t\treturn this.CreateMethodCallQuery< ");
            base.Output.Write( ((Dbml.Type)function.Items[0]).Name );
            base.Output.Write(" >(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))");
            base.Output.Write( GetFunctionParametersCall(function) );
            base.Output.Write(");\r\n\t\t}");
            base.Output.WriteLine();
        }
    }
}