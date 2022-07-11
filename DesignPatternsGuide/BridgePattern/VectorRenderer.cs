namespace BridgePattern;

public class VectorRenderer : IRenderer
{
    
    public override string ToString() => $"Drawing {{Name}} as {WhatToRender}";
    public string WhatToRender => "lines.";
}