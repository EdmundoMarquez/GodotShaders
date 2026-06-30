using Godot;
using System;

namespace Tempo.GSLSShaders
{
    public partial class VertexShader : Node2D
    {
        private HSlider _offsetSlider;
        private HSlider _stretchSlider;
        private HSlider _centerSlider;
        private Sprite2D _sprite2D;

        public override void _Ready()
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
            _offsetSlider = GetNode<HSlider>("Controls/OffsetSlider/HSlider");
            _stretchSlider = GetNode<HSlider>("Controls/StretchSlider/HSlider");
            _centerSlider = GetNode<HSlider>("Controls/CenterSlider/HSlider");

            _offsetSlider.ValueChanged += ModifyOffset;
            _stretchSlider.ValueChanged += ModifyStretch;
            _centerSlider.ValueChanged += ModifyCenter;
        }

        private void ModifyOffset(double value) => ChangeParameter("offset_x", (float)value);
        private void ModifyStretch(double value) => ChangeParameter("stretch_y", (float)value);
        private void ModifyCenter(double value) => ChangeParameter("center_distance", (float)value);

        private void ChangeParameter(string parameter, float value)
        {
            ShaderMaterial shaderMaterial = _sprite2D.Material as ShaderMaterial;
            shaderMaterial.SetShaderParameter(parameter, value);
            GD.Print($"Changed {parameter} to: {value}");
        }

    }
}