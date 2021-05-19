using Godot;
using System;

[Tool]
public class addon : Node
{

	[Export]
	public string Text = "Label2D to 3D.";
	[Export]
	public Color FontColor;

	[Export]
	public int FontSize = 12;
	[Export]
	public Vector2 Size = new Vector2(140, 32);

	private Label3D label3D;

	private Label2D label2D;
	private Viewport view;
	public override void _EnterTree()
	{
		GD.Print("Addon EnterTree");
		PackedScene scene3d = GD.Load<PackedScene>("res://addons/label3d/3d/Label3D.tscn");
		label3D = (Label3D)scene3d.Instance();
		AddChild(label3D);
		GD.Print("Addon EnterTree Complete");
	}
	public override void _Ready()
	{
		GD.Print("Addon Get Ready");
		label2D = label3D.GetLabel();
		view = label3D.GetViewPort();
		GD.Print("Addon Get Ready Complete");
	}

	public void SetText(string str)
	{
		label2D.SetText(str);
	}
	public void SetText(int i)
	{
		label2D.SetText(i.ToString());
	}
	public void SetText(float f)
	{
		label2D.SetText(f.ToString());
	}

	public override void _Process(float delta)
	{
		if (Input.IsKeyPressed((int)KeyList.Space))
		{
			Random ran = new Random();
			int i = ran.Next(100, 999);
			SetText(i);
		}
		if (Engine.EditorHint)
		{
			GD.Print("Editor Mode");
			UpdateText();
			UpdateFontColor();
		}
	}


	private String text_cache = "";
	private void UpdateText()
	{
		if (Text == text_cache)
		{
			return;
		}
		else
		{
			label2D.SetText(Text);
			text_cache = Text;
		}
	}

	private Color color_cache = new Color(1, 1, 1, 1);
	private void UpdateFontColor()
	{
		if (FontColor == color_cache)
		{
			return;
		}
		else
		{
			label3D.SetMatColor(FontColor);
			color_cache = FontColor;
		}
	}

	private int font_size_cache = 12;
	private void UpdateFontSize()
	{
		if (FontSize == font_size_cache)
		{
			return;
		}
		else
		{
			// label2D.SetTextSize(FontSize);
			// TODO 修改Label的文字大小
			font_size_cache = FontSize;
		}
	}

}
