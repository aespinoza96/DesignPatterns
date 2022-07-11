namespace BridgePattern;

public class RasterRenderer : IRenderer
{
    public override string ToString() => $"Drawing {{Name}} as {WhatToRender}";
    public string WhatToRender => "pixels.";
}