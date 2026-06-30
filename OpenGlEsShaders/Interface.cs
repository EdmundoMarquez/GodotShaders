using Godot;
using System;

namespace Tempo.GSLSShaders
{
    public partial class Interface : Node
    {
        [Export] private ScreenWipe screenWipe;
        private Button _screenWipeButton;

        public override void _Ready()
        {
            _screenWipeButton = GetNode<Button>("Panel/ScreenWipeButton");
            _screenWipeButton.Pressed += OnScreenWipePressed;
        }

        public override void _ExitTree() => _screenWipeButton.Pressed -= OnScreenWipePressed;

        private void OnScreenWipePressed() => screenWipe.Play();

    }
}

