using Godot;
using System;

namespace Tempo.GSLSShaders
{
    public partial class BasicShader : Node2D
    {
        private ColorPickerButton _colorPickerButton;
        private Sprite2D _sprite2D;

        public override void _Ready()
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
            _colorPickerButton = GetNode<ColorPickerButton>("Controls/ColorPickerButton");
            _colorPickerButton.ColorChanged += ChangeColor;
        }

        public override void _ExitTree()
        {
            _colorPickerButton.ColorChanged -= ChangeColor;
        }


        public void ChangeColor(Color color)
        {
            ShaderMaterial shaderMaterial = _sprite2D.Material as ShaderMaterial;
            shaderMaterial.SetShaderParameter("custom_color", color);
            GD.Print($"Changed color to: {color}");
        }

    }
}

