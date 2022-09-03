using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
[InitializeOnLoad]
class SpriteOrdering
{
    static SpriteOrdering()
    {
        Initialize();
    }
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 0.0f, 1.0f);
    }
}