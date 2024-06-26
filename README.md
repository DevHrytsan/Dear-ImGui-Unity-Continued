# Dear ImGui Continued for Unity
[The original repository](https://github.com/realgamessoftware/dear-imgui-unity) for Dear ImGui for Unity has been archived and is no longer maintained. So, I have decided to make new repo that includes various fixes and improvements of it to use in newer Unity version. 

### How to Install 
Install via Package Manager by clicking on [add package from git url](https://docs.unity3d.com/Manual/upm-ui-giturl.html):
```console
https://github.com/devhrytsan/dear-imgui-unity-continued.git
```
### How to use
- Add a `DearImGui` component to one of the objects in the scene.
> [!NOTE]
> - When using the Universal Render Pipeline (URP), add a `RenderImGuiFeature` render feature to the renderer asset. Then assign it to the `render feature` field of the DearImGui component.
> - When using the High Definition Render Pipeline (HDRP) , add a custom render pass and select `DearImGuiPass` injected after post processing.

- Subscribe to the `ImGuiUn.Layout` event and use ImGui functions.
- Simple example script:
  ```cs
  using UnityEngine;
  using ImGuiNET;

  public class DearImGuiDemo : MonoBehaviour
  {
      void OnEnable()
      {
          ImGuiUn.Layout += OnLayout;
      }

      void OnDisable()
      {
          ImGuiUn.Layout -= OnLayout;
      }

      void OnLayout()
      {
          ImGui.ShowDemoWindow();
      }
  }
  ```
Check [MrRobinOfficial repo](https://github.com/MrRobinOfficial/Guide-UnityDearImGui) for guide about package.

### Third Party

This package uses:
- Original Dear ImGui Unity by [realgamessoftware](https://github.com/realgamessoftware/dear-imgui-unity)
- Dear ImGui C bindings by [cimgui](https://github.com/cimgui/cimgui) 
- C# wrapper by [ImGui.NET](https://github.com/mellinoe/ImGui.NET).

### Contribution
Feel free to contribute to this project and suggest some improvements to it.
## License
Under the MIT license.
