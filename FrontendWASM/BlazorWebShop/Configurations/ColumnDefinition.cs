namespace MyFirstBlazorApp.Configurations;

public class ColumnDefinition
{
    public ColumnDefinition()
    {
        this.DataType = DataType.NotSet;
        this.Alignment = Alignment.Notset;
    }
    public string DataField { get; set; }
    public string Caption { get; set; }
    public DataType DataType { get; set; }
    public string Format { get; set; }
    public Alignment Alignment { get; set; }

}
