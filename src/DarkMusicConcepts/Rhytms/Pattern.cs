using Throw;

namespace DarkMusicConcepts.Rhytms;
/// <summary>
/// Representation of a rhytmical pattern. Each node either is a beat or is empty (true or false)
/// </summary>
public class Pattern
{
    public bool[] Nodes { get; }
    public Time NodeDuration { get; }
    public Time Length { get; }

    private Pattern(bool[] nodes, Time nodeDuration)
    {
        Nodes = nodes;
        NodeDuration = nodeDuration;
        Length = nodeDuration * nodes.Length;
    }

    /// <summary>
    /// Creates a pattern
    /// </summary>
    /// <param name="nodes">The nodes</param>
    /// <param name="nodeDuration">Duration of a node</param>
    /// <returns>Created pattern</returns>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentException" />
    public static Pattern Create(bool[] nodes, Time nodeDuration)
    {
        nodes
            .ThrowIfNull()
            .IfEmpty();

        return new Pattern(nodes, nodeDuration);
    }

    /// <summary>
    /// Check if a given node index is on a specific pulse.
    /// <para>
    /// Example: check if the node with index 7 is on a <see cref="Time.QuarterNoteDotted"/> pulse
    /// </para>
    /// </summary>
    /// <param name="node">Index of the node</param>
    /// <param name="pulse">Pulse length</param>
    /// <returns><see langword="true"/> if the node is on the pulse</returns>
    public bool IsNodeOnPulse(int node, Time pulse)
    {
        var nodeTotalLength = NodeDuration * node;
        var isOnPulse = nodeTotalLength.Ticks % pulse.Ticks == 0;
        return isOnPulse;
    }
}
