using Godot;
using System;

[Tool]
public class Label2D : Node2D
{
    private Label _label;

    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {
        GD.Print("Label2D EnterTree");
        GD.Print("Label2D EnterTree Complete");
    }
    public override void _Ready()
    {
        GD.Print("Label2D Get Ready");
        _label = GetNode<Label>("Label");
        GD.Print("Label2D Get Ready Complete");
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public void SetText(string str)
    {
        _label.Text = str;
    }



    public void SetTextSize(Vector2 vec2)
    {
        _label.RectSize = vec2;
    }

    public void SetFontSize(int size)
    {
        _label.GetSize();

    }

    public void TestSetText()
    {
        int i = (int)GD.Randi();
        SetText(i.ToString());
    }
}
