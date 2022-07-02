//The Serializable attribute allows Unity to serialize this class and extend PostProcessEffectSettings.

using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable] 
// The [PostProcess()] attribute tells Unity that this class holds post-processing data. The first parameter links the settings to a renderer. The second parameter creates the injection point for the effect. The third parameter is the menu entry for the effect. You can use a forward slash (/) to create sub-menu categories. 
[PostProcess(typeof(GrayscaleRenderer), PostProcessEvent.AfterStack, "Custom/Grayscale")]
public sealed class Grayscale : PostProcessEffectSettings
{
    // You can create boxed fields to override or blend parameters. This example uses a FloatParameter with a fixed range from 0 to 1.
    [Range(0f, 1f), Tooltip("Grayscale effect intensity.")] 
    public FloatParameter blend = new FloatParameter { value = 0.5f };
    [Range(0f, 2f)] 
    public FloatParameter Red = new FloatParameter { value = 0.0f };
    [Range(0f, 2f)] 
    public FloatParameter Green = new FloatParameter { value = 0.0f };
    [Range(0f, 2f)] 
    public FloatParameter Blue = new FloatParameter { value = 0.0f };
}
public class GrayscaleRenderer : PostProcessEffectRenderer<Grayscale>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Grayscale"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}