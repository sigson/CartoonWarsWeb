using Godot;
using System;

public partial class GroundScene : Node
{
    [Export] public NodePath PlayerTowerBinding;
    [Export] public NodePath EnemyTowerBinding;
    [Export] public NodePath PlayerSpawnBinding;
    [Export] public NodePath EnemySpawnBinding;
    [Export] public NodePath CameraStopLeft;
    [Export] public NodePath CameraStopRight;
    [Export] public NodePath CameraBindPosition;
}
