using Spectre.Console;
using System.Runtime.CompilerServices;
using System.Text;

namespace SampleConsoleApp.Demos;
internal abstract class Demo
{
    public abstract void Run();

    protected void PrintHeader(string headerText)
    {
        AnsiConsole.Write(new FigletText(headerText.ToUpper()));
    }

    protected void PrintSubHeader(string subHeaderText)
    {
        var pad = new Padder(
            new Text(subHeaderText, new Style(decoration: Decoration.Bold)))
            .Padding(2, 1, 0, 1);
        AnsiConsole.Write(pad);
    }

    protected void PrintCollection<T>(IEnumerable<T> items, bool newLine, [CallerArgumentExpression("items")] string expressionText = null!)
    {
        var stringified = newLine
            ? StrigifyCollection(items)
            : string.Join(", ", items);
        var pad = new Padder(
            new Markup($"[green]{expressionText}[/] => {stringified}"))
            .Padding(4, 0, 0, 0);
        AnsiConsole.Write(pad);
    }

    protected void Print(object? expression, [CallerArgumentExpression("expression")] string expressionText = null!)
    {
        var pad = new Padder(
            new Markup($"[green]{expressionText}[/] => {expression}"))
            .Padding(4, 0, 0, 0);
        AnsiConsole.Write(pad);
    }

    protected void Comment(string text)
    {
        var pad = new Padder(
            new Markup($"[italic dim]{text}[/]"))
            .Padding(4, 0, 0, 0);
        AnsiConsole.Write(pad);
    }

    private string StrigifyCollection<T>(IEnumerable<T> items)
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
