namespace BridgePattern;

public abstract class Shape
{
    private IRenderer renderer;
    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public IRenderer Renderer
    {
        get { return this.renderer; }
    }

    protected string Name { get; set; }

    public override string ToString()
    {
        return $"Drawing a {Name} as {renderer.WhatToRender}";
    }
}