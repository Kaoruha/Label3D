using Godot;
using System;

[Tool]
public class Label3DScene : Spatial
{
	[Export]
	public NodePath viewpath;
	private Viewport viewport = null;
	[Export]
	public NodePath labelpath;
	private Label2D label2D = null;

	[Export]
	public NodePath meshpath;
	private MeshInstance mesh = null;

	private SpatialMaterial mat = null;


	// Called when the node enters the scene tree for the first time.
	public override void _EnterTree()
	{
		GD.Print("Label3D EnterTree");
		GD.Print("Label3D EnterTree Complete");
	}
	public override void _Ready()
	{
		GD.Print("Label3D Get Ready");
		Initialization();
		GD.Print("Label3D Get Ready Complete");
	}

	public override void _Process(float delta)
	{

	}

	private void Initialization()
	{
		viewport = GetNode<Viewport>(viewpath);
		label2D = (Label2D)GetNode<Label2D>(labelpath);
		mesh = GetNode<MeshInstance>(meshpath);
		SetLabelSize(new Vector2(140, 32));
		mat = (SpatialMaterial)mesh.GetActiveMaterial(0);
	}
	public Label2D GetLabel()
	{
		if (label2D == null)
		{
			Initialization();
		}
		return label2D;
	}

	public Viewport GetViewPort()
	{
		if (viewport == null)
		{
			Initialization();
		}
		return viewport;
	}

	public void SetMatColor(Color color)
	{
		mat.AlbedoColor = color;
	}

	public void SetLabelSize(Vector2 size)
	{
		label2D.SetRectSize(size);
		viewport.Size = size;
		mesh.Scale = new Vector3(size.x / 100, size.y / 100, 1);
		mesh.Translation = new Vector3(size.x / 200, size.y / 200, 0);
	}
}
