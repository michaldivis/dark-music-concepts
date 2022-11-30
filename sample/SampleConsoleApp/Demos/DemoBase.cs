using Colorful;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Console = Colorful.Console;

namespace SampleConsoleApp.Demos;
internal abstract class Demo
{
    public abstract void Run();

    protected void PrintHeader(string headerText)
    {
        Console.WriteLine();
        Console.WriteLine($"*** {headerText.ToUpper()} ***", Color.Gray);
        Console.WriteLine();
    }

    protected void PrintSubHeader(string subHeaderText)
    {
        Console.WriteLine($"--- {subHeaderText}", Color.Gray);
    }

    protected void Print(object? expression, [CallerArgumentExpression("expression")] string expressionText = null!)
    {
        var parts = new Formatter[]
        {
        new Formatter(expressionText, Color.LightGreen),
        new Formatter(expression, Color.White)
        };

        Console.WriteLineFormatted("{0} => {1}", Color.LightGray, parts);
    }

    protected string StrigifyCollection<T>(IEnumerable<T> items)
    {
        var sb = new StringBuilder();

        sb.AppendLine();

        foreach (var item in items)
        {
            sb.AppendLine(item?.ToString());
        }

        return sb.ToString();
    }
}
