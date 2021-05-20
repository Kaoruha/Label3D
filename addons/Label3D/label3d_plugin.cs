using Godot;
using System;

[Tool]
public class label3d_plugin : EditorPlugin
{
	public override void _EnterTree()
	{
		// Initialization of the plugin goes here
		// Add the new type with a name, a parent type, a script and an icon
		Script script = GD.Load<Script>("res://addons/Label3D/label3d_addon.cs");
		Texture icon = GD.Load<Texture>("res://addons/Label3D/icon.png");
		AddCustomType("Label3D", "Spatial", script, icon);
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here
		// Always remember to remove it from the engine when deactivated
		RemoveCustomType("Label3D");
	}
}
