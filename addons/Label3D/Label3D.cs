using Godot;
using System;

[Tool]
public class Label3D : Spatial
{
	// 显示文本内容
	private String text = "Label2D to 3D";
	[Export]
	public String Text
	{
		get { return text; }
		set
		{
			text = value;
			SetText(value);
		}
	}
	public void SetText(string str)
	{
		Text = str;
		label2D.SetText(str);
	}
	public void SetText(int i)
	{
		Text = i.ToString();
		label2D.SetText(i.ToString());
	}
	public void SetText(float f)
	{
		Text = f.ToString();
		label2D.SetText(f.ToString());
	}

	// 文本颜色

	private Color font_color = new Color(1, 1, 1, 1);
	[Export]
	public Color FontColor
	{
		get { return font_color; }
		set
		{
			font_color = value;
			SetFontColor(value);
		}
	}
	private void SetFontColor(Color color)
	{
		label3D.SetMatColor(color);
	}

	// 文本显示大小

	private Vector2 size = new Vector2(140, 32);
	[Export]
	public Vector2 Size
	{
		get { return size; }
		set
		{
			size = value;
			this.SetRectSize(value);
		}
	}
	private void SetRectSize(Vector2 size_)
	{
		label3D.SetLabelSize(size_);
	}


	private Label3DScene label3D;
	private Label2D label2D;
	private Viewport view;
	public override void _EnterTree()
	{
		base._EnterTree();
		PackedScene scene3d = GD.Load<PackedScene>("res://addons/label3d/3d/Label3DScene.tscn");
		label3D = (Label3DScene)scene3d.Instance();
		AddChild(label3D);
	}

	public override void _Ready()
	{
		base._Ready();
		label2D = label3D.GetLabel();
		view = label3D.GetViewPort();
	}
	public override void _Process(float delta)
	{
	}
}
