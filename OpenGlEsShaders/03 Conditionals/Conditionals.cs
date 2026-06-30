using Godot;
using System;

namespace Tempo.GSLSShaders
{

    public partial class Conditionals : Node2D
    {
        private HSlider _progressValueSlider;
        private Sprite2D _sprite2D;

        public override void _Ready()
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
            _progressValueSlider = GetNode<HSlider>("ProgressSlider/HSlider");

            _progressValueSlider.ValueChanged += ModifyStepProgress;
        }

        public override void _ExitTree()
        {
            _progressValueSlider.ValueChanged -= ModifyStepProgress;
        }


        private void ModifyStepProgress(double value) => ChangeParameter("progress", (float)value);

        private void ChangeParameter(string parameter, float value)
        {
            ShaderMaterial shaderMaterial = _sprite2D.Material as ShaderMaterial;
            shaderMaterial.SetShaderParameter(parameter, value);
            GD.Print($"Changed {parameter} to: {value}");
        }
    }
}
