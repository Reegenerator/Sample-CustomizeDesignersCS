namespace CustomizeDesigners
{
    using Generators = Kodeo.Reegenerator.Generators;

    /// <summary>
    /// Example on how to call the default custom tool in order to get
    /// the results of the standard custom tool.
    /// </summary>
    public class InvokeDefaultCustomTool : Generators.CodeRenderer
    {
        /// <summary>
        /// Use the default LINQ to SQL code generator.
        /// </summary>
        /// <remarks>
        /// You can find out the name that you should use by pressing F4 when
        /// the project item is selected in Solution Explorer.
        /// The name is the value of the <c>Custom Tool</c> property.
        /// </remarks>
        public const string CustomToolName = "MSLinqToSQLGenerator";

        // public const string CustomToolName = "MSDataSetGenerator";
        // public const string CustomToolName = "ResXFileCodeGenerator";
        // public const string CustomToolName = "SettingsSingleFileGenerator";

        public override Generators.RenderResults Render()
        {
            byte[] ctResults = base.RunOtherCustomTool(CustomToolName);
            // string results = System.Text.Encoding.Default.GetString(ctResults);
            return new Generators.RenderResults(ctResults);
        }
    }
}