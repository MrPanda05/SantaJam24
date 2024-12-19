using Godot;
using Platformer.Triggers;
using System;

public partial class MovePlatformButton : Node2D
{
    [Export]
    private ButtonTri _myButton;

    private void Penis()
    {
        GD.Print("Do some shti");
    }

    public override void _Ready()
    {
        _myButton.OnButtonPressed += Penis;
    }
}
