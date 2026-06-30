using Godot;
using System;


namespace Tempo.GSLSShaders
{
    public partial class UvTextures : Node2D
    {
        private HSlider _rValueSlider;
        private HSlider _gValueSlider;
        private HSlider _oValueSlider;
        private Sprite2D _sprite2D;

        public override void _Ready()
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
            _rValueSlider = GetNode<HSlider>("Controls/RedSlider/HSlider");
            _gValueSlider = GetNode<HSlider>("Controls/GreenSlider/HSlider");
            _oValueSlider = GetNode<HSlider>("Controls/OffsetSlider/HSlider");

            _rValueSlider.ValueChanged += ModifyRedValue;
            _gValueSlider.ValueChanged += ModifyGreenValue;
            _oValueSlider.ValueChanged += ModifyOffsetValue;
        }

        private void ModifyRedValue(double value) => ChangeParameter("red_value", (float)value);
        private void ModifyGreenValue(double value) => ChangeParameter("green_value", (float)value);
        private void ModifyOffsetValue(double value) => ChangeParameter("offset", (float)value);

        private void ChangeParameter(string parameter, float value)
        {
            ShaderMaterial shaderMaterial = _sprite2D.Material as ShaderMaterial;
            shaderMaterial.SetShaderParameter(parameter, value);
            GD.Print($"Changed {parameter} to: {value}");
        }

    }
}