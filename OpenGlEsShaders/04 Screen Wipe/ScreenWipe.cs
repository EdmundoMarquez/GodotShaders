using Godot;
using System;

namespace Tempo.GSLSShaders
{
    public partial class ScreenWipe : Node
    {
        private ColorRect _colorRect;

        public override void _Ready()
        {
            _colorRect = GetNode<ColorRect>("ColorRect");
            // float progress = 0.5f;
            // ShaderMaterial shaderMaterial = _colorRect.Material as ShaderMaterial;
            // shaderMaterial.SetShaderParameter("progress", progress);
            // GD.Print($"Screen Wipe Progress: {progress}");
        }

        public void Play()
        {
            Tween tween = CreateTween();
            tween.TweenProperty(_colorRect, "material:shader_parameter/progress", 1f, 1f).SetTrans(Tween.TransitionType.Expo);
            tween.TweenCallback(Callable.From(() => { _colorRect.MouseFilter = Control.MouseFilterEnum.Stop; }));
            tween.TweenProperty(_colorRect, "material:shader_parameter/progress", 0f, 1f).SetTrans(Tween.TransitionType.Expo);
            tween.TweenCallback(Callable.From(() => { _colorRect.MouseFilter = Control.MouseFilterEnum.Ignore; }));
        }
    }
}