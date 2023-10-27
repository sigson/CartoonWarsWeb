using Godot;
using System;

public class ItemCard : Resource
{
    [Export] public Godot.Collections.Dictionary<string, Resource> Data = new Godot.Collections.Dictionary<string, Resource>();
    [Export] public Godot.Collections.Array<Resource> RawData = new Godot.Collections.Array<Resource>();
    [Export] public Godot.Collections.Dictionary<string, Color> Colors = new Godot.Collections.Dictionary<string, Color>();
}
