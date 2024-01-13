﻿// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.EditorUI.ScriptableObjects.SpriteSheets;
using Doozy.Editor.EditorUI.Windows.Internal;
using UnityEditor;
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Editor.EditorUI.Windows
{
    public class EditorSpriteSheetsWindow : EditorUIDatabaseWindow<EditorSpriteSheetsWindow>
    {
        public const string k_WindowTitle = "SpriteSheets";
        public const string k_MenuPath = EditorUIWindow.k_WindowMenuPath + "/" + EditorUIWindow.k_WindowTitle + "/" + k_WindowTitle;
        public const int k_MenuItemPriority = -497;
        
        public static void Open() => InternalOpenWindow(k_WindowTitle);
        
        [MenuItem(k_MenuPath, false, k_MenuItemPriority)]
        private static void RefreshDatabase()
        {
            if (EditorUtility.DisplayDialog
                (
                    $"Refresh the {k_WindowTitle} database?",
                    "This will regenerate the database with the latest registered sprite sheets, from the source files." +
                    "\n\n" +
                    "Takes around 1 to 30 seconds, depending on the number of source files and your computer's performance." +
                    "\n\n" +
                    "This operation cannot be undone!",
                    "Yes",
                    "No"
                )
               )
            EditorDataSpriteSheetDatabase.instance.RefreshDatabase();
        }
    }
}