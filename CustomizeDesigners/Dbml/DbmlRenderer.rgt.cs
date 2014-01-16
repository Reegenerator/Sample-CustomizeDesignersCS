namespace CustomizeDesigners.Dbml
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Text;

    public partial class DbmlRenderer
    {
        /// <summary>
        /// The database element as deserialized from the dbml file.
        /// </summary>
        private Database database = null;

        /// <summary>
        /// Takes place before the render.
        /// </summary>
        public override void PreRender()
        {
            base.PreRender();
            this.database = DbmlSchemaFactory.Create<Database>(base.ProjectItem); // deserialized the dbml file into the private property.
        }

        private static CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

        /// <summary>
        /// Transforms the .NET name of a type into a C# type. E.g. System.String -> string
        /// </summary>
        private static string LangType(string type)
        {
            return codeProvider.GetTypeOutput(new System.CodeDom.CodeTypeReference(type));
        }

        /// <summary>
        /// Gets the C# type associated with a column.
        /// </summary>
        private string ColumnType(Column column)
        {
            return ColumnType(column, true);
        }

        /// <summary>
        /// Gets the C# type associated with a column.
        /// If it is a nullable type, it will optionally be prefixed with <c>System.</c>
        /// </summary>
        private string ColumnType(Column column, bool prefixNullable)
        {
            string result = LangType(column.Type);
            if (column.CanBeNull)
            {
                System.Type type = System.Type.GetType(column.Type, false);
                if (type != null && type.IsValueType)
                    result = string.Format(prefixNullable ? "System.Nullable<{0}>" : "Nullable<{0}>", result);
            }
            return result;
        }

        /// <summary>
        /// Renders an access modifier
        /// </summary>
        private string GetAccessModifier(AccessModifier accessModifier)
        {
            return accessModifier.ToString().ToLower();
        }

        /// <summary>
        /// Renders the <c>Extensibility</c> region.
        /// </summary>
        private void RenderDatabaseExtensibility()
        {
            if (this.database.Table == null)
                return;
            foreach (Table table in this.database.Table)
            {
                if (GetPrimaryKey(table).Count > 0)
                    RenderDatabaseTableExtensibility(table);
            }
        }

        /// <summary>
        /// Renders all the tables as properties of the data context class.
        /// </summary>
        private void RenderDatabaseTablesProperties()
        {
            if (this.database.Table == null)
                return;
            foreach (Table table in this.database.Table)
            {
                RenderDatabaseTableProperty(table);
            }
        }

        /// <summary>
        /// Renders all the tables as classes.
        /// </summary>
        private void RenderTables()
        {
            if (this.database.Table == null)
                return;
            foreach (Table table in this.database.Table)
            {
                if (GetPrimaryKey(table).Count > 0)
                    RenderTable(table);
                else
                    RenderTableSimple(table);
            }
        }

        /// <summary>
        /// Renders all the columns and relationships of a table as private properties.
        /// </summary>
        private void RenderTypePrivateProperties(Dbml.Type type)
        {
            foreach (object o in type.Items)
            {
                if (o is Column)
                    RenderColumnAsPrivateProperty((Column)o);
                if (o is Association)
                    RenderAssociationAsPrivateProperty((Association)o);
            }
        }

        /// <summary>
        /// Renders the <c>Extensibilty</c> region of a table class.
        /// </summary>
        private void RenderTableColumnsExtensibilities(Table table)
        {
            foreach (object o in table.Type.Items)
            {
                if (o is Column)
                    RenderTableColumnExtensibility((Column)o);
            }
        }

        /// <summary>
        /// Renders the initializations for a table relationships.
        /// </summary>
        private void RenderTableAssociationsInitializations(Table table)
        {
            foreach (object o in table.Type.Items)
            {
                if (o is Association)
                    RenderTableAssociationInitialization((Association)o);
            }
        }

        /// <summary>
        /// Renders all the table fields as properties.
        /// </summary>
        private void RenderTableProperties(Table table)
        {
            RenderTableProperties(table, false);
        }

        /// <summary>
        /// Renders all the table fields as properties in simple or complex form.
        /// </summary>
        private void RenderTableProperties(Table table, bool renderSimpleProperty)
        {
            foreach (object o in table.Type.Items)
            {
                if (o is Column)
                {
                    if (renderSimpleProperty)
                        RenderColumnAsPropertySimple(table, (Column)o);
                    else
                        RenderColumnAsProperty(table, (Column)o);
                }
                if (o is Association)
                {
                    Association association = (Association)o;
                    if (!association.IsForeignKey)
                        RenderForeignKeyAssociationAsProperty(association);
                    else
                        RenderAssociationAsProperty(table, association);
                }
            }
        }

        /// <summary>
        /// Gets the table from the database having a specified name.
        /// </summary>
        private Table GetTable(string name)
        {
            foreach (Table table in this.database.Table)
                if (table.Type.Name == name)
                    return table;
            throw new ArgumentException(string.Format("Cannot find table {0}", name), "name");
        }

        /// <summary>
        /// Gets a list with all the fields' names of a table that form the primary key
        /// </summary>
        private List<string> GetPrimaryKey(Table table)
        {
            List<string> primaryKeys = new List<string>();
            foreach (object o in table.Type.Items)
            {
                Column column = o as Column;
                if (column != null && column.IsPrimaryKey)
                    primaryKeys.Add(column.Name);
            }
            return primaryKeys;
        }

        /// <summary>
        /// Renders the set portion of the property derived from a relationship
        /// that assigns the members of the property.
        /// </summary>
        private string RenderAssociationAsPropertyHelper1(Table table, Association association)
        {
            List<string> keys = new List<string>(association.ThisKey.Split(','));

            List<string> primaryKeys;
            if (string.IsNullOrEmpty(association.OtherKey))
            {
                Table parentTable = this.GetTable(association.Type);
                primaryKeys = GetPrimaryKey(parentTable);
            }
            else
                primaryKeys = new List<string>(association.OtherKey.Split(','));

            if (keys.Count != primaryKeys.Count)
            {
                throw new ApplicationException(string.Format(
                    "The parent and child keys do not match for association {0}", association.Name));
            }
            int pos = 0;
            return Join(keys, "\r\n\t\t", delegate(string key)
            {
                return string.Format("this._{0} = value.{1};", key, primaryKeys[pos++]);
            });
        }

        /// <summary>
        /// Renders the set portion of the property derived from a relationship
        /// that assigns default values to the members of the property.
        /// </summary>
        private string RenderAssociationAsPropertyHelper2(Table table, Association association)
        {
            List<string> keys = new List<string>(association.ThisKey.Split(','));

            return Join(keys, "\r\n\t\t", delegate(string key)
            {
                foreach (object o in table.Type.Items)
                {
                    Column column = o as Column;
                    if (column == null)
                        continue;
                    if (column.Name == key)
                        return string.Format("this._{0} = default({1});", key, ColumnType(column, false)); ;
                }
                throw new ApplicationException(string.Format("Cannot find association {0} key {1}", association.Name, key));
            });
        }

        /// <summary>
        /// Renders some of the attributes of a property derived from a relationship.
        /// </summary>
        private string RenderAssociationAsPropertyHelper3(Association association)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(association.ThisKey))
                result += string.Format(@", ThisKey=""{0}""", association.ThisKey);
            if (!string.IsNullOrEmpty(association.OtherKey))
                result += string.Format(@", OtherKey=""{0}""", association.OtherKey);
            return result;
        }

        /// <summary>
        /// Renders the attach detach methods associated with a relationship.
        /// </summary>
        private void RenderTableAssociationsAttachDetach(Table table)
        {
            foreach (object o in table.Type.Items)
            {
                Association association = o as Association;
                if (association == null || association.IsForeignKey)
                    continue; // if it is not an association or the table is not the child table, we are not interested
                // find the association as defined for the parent table
                Table otherTable = GetTable(association.Type); // the parent table
                Association parentAssociation = null;
                foreach (object o2 in otherTable.Type.Items)
                {
                    Association a = o2 as Association;
                    if (a != null && a.IsForeignKey &&
                        a.Name == association.Name)
                    {
                        parentAssociation = a;
                        break;
                    }
                }
                if (parentAssociation == null)
                { // we did not find the matching association in the parent table.
                    throw new ApplicationException(
                        string.Format("Cannot find the matching association {0}", association.Name));
                }
                RenderTableAssociationAttachDetach(table, association, parentAssociation);
            }
        }

        /// <summary>
        /// Tests whether the <c>CanBeNull</c> attribute should be added to the property derived from a column.
        /// </summary>
        private bool ShouldRenderCanBeNull(Dbml.Type t, Column column)
        {
            if (!column.CanBeNullSpecified)
                return false;
            if (column.CanBeNull && column.DbType != "Image")
                return false;

            if (column.DbType.StartsWith("Bit NOT NULL") ||
                column.DbType.StartsWith("Decimal") ||
                column.DbType.StartsWith("Image") ||
                column.DbType.StartsWith("Money NOT NULL") ||
                column.DbType.StartsWith("SmallInt NOT NULL") ||
                column.DbType.StartsWith("Int NOT NULL") ||
                column.DbType.StartsWith("Real NOT NULL"))
            {
                // seems like a bug in MS's implementation. But since the purpose is to mimic perfectly... Change this if necessary.
                return false;
            }

            System.Type type = System.Type.GetType(column.Type, false);
            foreach (object o in t.Items)
            {
                Association association = o as Association;
                if (association == null)
                    continue;
                if (!association.IsForeignKey)
                    continue;

                if (!string.IsNullOrEmpty(association.OtherKey))
                {
                    if ((new List<string>(association.OtherKey.Split(',')).Contains(column.Name)))
                        return type == null || !type.IsValueType;
                }
                if (!string.IsNullOrEmpty(association.ThisKey))
                {
                    if ((new List<string>(association.ThisKey.Split(',')).Contains(column.Name)))
                        return type == null || !type.IsValueType;
                }
            }
            if (!column.IsPrimaryKey)
                return true;
            return type == null || !type.IsValueType;
        }

        /// <summary>
        /// Gets all the attributes to be applied to a property derived from a table column.
        /// </summary>
        private string GetPropertyAttributes(Table table, Column column)
        {
            Column timeStampColumn = null;
            foreach (object o in table.Type.Items)
            {
                Column c = o as Column;
                if (c != null && c.IsVersionSpecified && c.IsVersion)
                {
                    timeStampColumn = c;
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            string storage = string.IsNullOrEmpty(column.Storage) ? column.Name : column.Storage;
            sb.AppendFormat(@"Storage=""_{0}""", storage);

            if (column.AutoSyncSpecified)
            {
                sb.AppendFormat(@", AutoSync=AutoSync.{0}", column.AutoSync.ToString());
            }
            else if (column.IsDbGeneratedSpecified && column.IsDbGenerated)
            {
                sb.AppendFormat(@", AutoSync=AutoSync.{0}",
                    GetPrimaryKey(table).Count == 0
                        ? AutoSync.Always.ToString()
                        : AutoSync.OnInsert.ToString());
            }
            else if (object.ReferenceEquals(column, timeStampColumn))
            {
                sb.Append(", AutoSync=AutoSync.Always");
            }

            sb.AppendFormat(@", DbType=""{0}""", column.DbType);

            if (ShouldRenderCanBeNull(table.Type, column))
            {
                sb.AppendFormat(@", CanBeNull={0}", column.CanBeNull.ToString().ToLower());
            }

            if (column.IsPrimaryKeySpecified)
            {
                sb.AppendFormat(@", IsPrimaryKey={0}", column.IsPrimaryKey.ToString().ToLower());
            }

            if (column.IsDbGeneratedSpecified)
            {
                sb.AppendFormat(@", IsDbGenerated={0}", column.IsDbGenerated.ToString().ToLower());
            }
            else if (object.ReferenceEquals(column, timeStampColumn))
            {
                sb.Append(", IsDbGenerated=true");
            }

            if (column.IsVersionSpecified)
            {
                sb.AppendFormat(@", IsVersion={0}", column.IsVersion.ToString().ToLower());
            }

            if (column.UpdateCheckSpecified)
            {
                sb.AppendFormat(@", UpdateCheck=UpdateCheck.{0}", column.UpdateCheck.ToString());
            }
            else if (timeStampColumn != null)
            {
                sb.Append(", UpdateCheck=UpdateCheck.Never");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Renders all the checks related to relationship that need to happen
        /// in the <c>set</c> section of a property derived from a table column.
        /// </summary>
        private void RenderForeignKeysChecks(Table table, Column column)
        {
            foreach (object o in table.Type.Items)
            {
                Association association = o as Association;
                if (association == null || !association.IsForeignKey)
                    continue;
                List<string> keys = new List<string>(association.ThisKey.Split(','));
                if (keys.Contains(column.Name))
                {
                    RenderForeignKeyCheck(column, association);
                }
            }
        }

        /// <summary>
        /// Renders all the functions and stored procedures defined in the database.
        /// </summary>
        private void RenderDatabaseFunctions()
        {
            if (this.database.Function == null)
                return;
            foreach (Function function in this.database.Function)
            {
                switch (GetFunctionType(function))
                {
                    case FunctionType.StoredProcReturningRecordset:
                        RenderDatabaseSPReturningRecordset(function);
                        break;

                    case FunctionType.StoredProcReturningSingleValue:
                        RenderDatabaseSPReturningSingleValue(function);
                        break;

                    case FunctionType.FunctionReturningSingleValue:
                        RenderDatabaseFnSingleValue(function);
                        break;

                    case FunctionType.FunctionReturningRecordset:
                        RenderDatabaseFnRecordset(function);
                        break;
                }
            }
        }

        /// <summary>
        /// Divides the functions (stored procedures) defined in the dbml file
        /// in four categories defining the necessary code render path.
        /// </summary>
        private enum FunctionType
        {
            StoredProcReturningRecordset,
            StoredProcReturningSingleValue,
            FunctionReturningRecordset,
            FunctionReturningSingleValue,
        }

        /// <summary>
        /// Determines a function type.
        /// </summary>
        private FunctionType GetFunctionType(Function function)
        {
            if (function.Items.Count > 0)
            {
                object ret = function.Items[0];
                if (function.IsComposable)
                {
                    if (ret is Dbml.Type)
                        return FunctionType.FunctionReturningRecordset;
                    if (ret is Return)
                        return FunctionType.FunctionReturningSingleValue;
                }
                else
                {
                    if (ret is Dbml.Type)
                        return FunctionType.StoredProcReturningRecordset;
                    if (ret is Return)
                        return FunctionType.StoredProcReturningSingleValue;
                }
            }
            throw new ApplicationException(string.Format("Unknown function type for {0}", function.Name));
        }

        /// <summary>
        /// Renders the parameters of a function when declaring it.
        /// </summary>
        private string GetFunctionParametersDeclare(Function function)
        {
            return Join(function.Parameter, ", ", delegate(Parameter p)
            {
                string type = LangType(p.Type);
                if (System.Type.GetType(p.Type, true).IsValueType)
                {
                    type = string.Format("System.Nullable<{0}>", type);
                }
                if (p.Direction == ParameterDirection.InOut ||
                    p.Direction == ParameterDirection.Out)
                {
                    type = "ref " + type;
                }

                if (string.IsNullOrEmpty(p.Parameter1))
                    return string.Format("[Parameter(DbType=\"{0}\")] {1} {2}", p.DbType, type, p.Name);
                return string.Format("[Parameter(Name=\"{3}\", DbType=\"{0}\")] {1} {2}", p.DbType, type, p.Parameter1, p.Name);
            });
        }

        /// <summary>
        /// Renders the parameters of a function when calling it.
        /// </summary>
        private string GetFunctionParametersCall(Function function)
        {
            return Join(function.Parameter, string.Empty, delegate(Parameter p)
            {
                return ", " + (string.IsNullOrEmpty(p.Parameter1) ? p.Name : p.Parameter1);
            });
        }

        /// <summary>
        /// Renders the all the functions or stored procedures as classes
        /// </summary>
        private void RenderFunctionsResults()
        {
            if (this.database.Function == null)
                return;
            foreach (Function function in this.database.Function)
            {
                switch (GetFunctionType(function))
                {
                    case FunctionType.StoredProcReturningRecordset:
                    case FunctionType.FunctionReturningRecordset:
                        RenderFunctionResult(function, (Dbml.Type)function.Items[0]);
                        break;
                }
            }
        }

        /// <summary>
        /// Renders all the fields returned by a stored procedure
        /// as class properties.
        /// </summary>
        private void RenderFunctionResultProperties(Function function)
        {
            Dbml.Type type = (Dbml.Type)function.Items[0];
            foreach (object o in type.Items)
            {
                if (o is Column)
                    RenderFunctionResultProperty(type, (Column)o);
            }
        }

        /// <summary>
        /// Renderes the atributes associated with a property generated
        /// from the field returned by a stored procedure.
        /// </summary>
        private string GetFunctionResultPropertyAttributes(Dbml.Type type, Column column)
        {
            StringBuilder sb = new StringBuilder();
            string storage = string.IsNullOrEmpty(column.Storage) ? column.Name : column.Storage;
            sb.AppendFormat(@"Storage=""_{0}""", storage);
            sb.AppendFormat(@", DbType=""{0}""", column.DbType);
            if (ShouldRenderCanBeNull(type, column))
            {
                sb.AppendFormat(@", CanBeNull={0}", column.CanBeNull.ToString().ToLower());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Renders the code that takes the out parameters as returned by a stored procedure and puts them into
        /// the private properties of the associated class.
        /// </summary>
        private string RenderFillOutParameter(Function function)
        {
            int pos = 0;
            return Join(function.Parameter, string.Empty, delegate(Parameter p)
            {
                pos++;
                if (p.Direction == ParameterDirection.In)
                    return string.Empty;

                string type = LangType(p.Type);
                if (System.Type.GetType(p.Type, true).IsValueType)
                {
                    type = string.Format("System.Nullable<{0}>", type);
                }
                string name = string.IsNullOrEmpty(p.Parameter1) ? p.Name : p.Parameter1;
                return string.Format("\r\n\t\t\t{0} = (({1})(result.GetParameterValue({2})));", name, type, pos - 1);
            });
        }
    }
}