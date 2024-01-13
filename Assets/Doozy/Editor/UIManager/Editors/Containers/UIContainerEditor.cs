﻿// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.EditorUI;
using Doozy.Editor.UIManager.Editors.Containers.Internal;
using Doozy.Runtime.UIManager.Containers;
using UnityEditor;

namespace Doozy.Editor.UIManager.Editors.Containers
{
    [CustomEditor(typeof(UIContainer), true)]
    [CanEditMultipleObjects]
    public class UIContainerEditor : BaseUIContainerEditor
    {
        protected override void InitializeEditor()
        {
            base.InitializeEditor();

            componentHeader
                .SetComponentNameText("UIContainer")
                .SetIcon(EditorSpriteSheets.UIManager.Icons.UIContainer)
                .AddManualButton()
                .AddApiButton("https://api.doozyui.com/api/Doozy.Runtime.UIManager.Containers.UIContainer.html")
                .AddYouTubeButton();
        }
    }
}
