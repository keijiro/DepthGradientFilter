using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[AddComponentMenu("VFX/Property Binders/Gradient Mask Binder")]
[VFXBinder("Gradient Mask")]
public sealed class VFXGradientMaskBinder : VFXBinderBase
{
    [VFXPropertyBinding("UnityEngine.Texture2D")]
    public ExposedProperty Property = "GradientMask";

    public DepthGradientFilter Target = null;

    public override bool IsValid(VisualEffect component)
      => Target != null && component.HasTexture(Property);

    public override void UpdateBinding(VisualEffect component)
      => component.SetTexture(Property, Target.MaskTexture);

    public override string ToString()
      => $"GradientMask : {Property}";
}
