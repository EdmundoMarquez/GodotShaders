using Godot;
using System;

namespace Tempo.GSLSShaders
{
    public partial class CustomRing : Node2D
    {
        [Export] private GradientTexture1D colorGradient;
        private HSlider _radiusSlider;
        private HSlider _widthSlider;
        private HSlider _featherSlider;
        private Sprite2D _sprite2D;

        public override void _Ready()
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
            _radiusSlider = GetNode<HSlider>("Controls/RadiusSlider/HSlider");
            _widthSlider = GetNode<HSlider>("Controls/WidthSlider/HSlider");
            _featherSlider = GetNode<HSlider>("Controls/FeatherSlider/HSlider");

            _radiusSlider.ValueChanged += ModifyRadius;
            _widthSlider.ValueChanged += ModifyWidth;
            _featherSlider.ValueChanged += ModifyFeather;

            // Play loopable color animation
            Tween tween = CreateTween().SetLoops();
            foreach (var color in colorGradient.Gradient.Colors)
                tween.TweenProperty(_sprite2D, "material:shader_parameter/tint_color", color, 0.2f);
        }

        private void ModifyRadius(double value) => ChangeParameter("custom_radius", (float)value);
        private void ModifyWidth(double value) => ChangeParameter("custom_width", (float)value);
        private void ModifyFeather(double value) => ChangeParameter("custom_feather", (float)value);

        private void ChangeParameter(string parameter, float value)
        {
            ShaderMaterial shaderMaterial = _sprite2D.Material as ShaderMaterial;
            shaderMaterial.SetShaderParameter(parameter, value);
            GD.Print($"Changed {parameter} to: {value}");
        }

    }
}

