using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class EditorAutoRefresh {
    private static Object lastSelection = null;
    private static int lastSelectionID = 0;

    static EditorAutoRefresh() {
        EditorApplication.update += Update;
    }

    static void Update() {
        Object currentSelection = Selection.activeObject;

        // Detecta quando a seleção é deletada para consertar a Hierarchy
        if (lastSelectionID != 0 && EditorUtility.InstanceIDToObject(lastSelectionID) == null) {
            EditorApplication.DirtyHierarchyWindowSorting();
            lastSelectionID = 0;
            lastSelection = null;
        }

        // Salva silenciosamente a cena para forçar o Inspector a atualizar
        if (currentSelection != lastSelection) {
            if (!Application.isPlaying) {
                AssetDatabase.SaveAssets();
                EditorSceneManager.SaveOpenScenes();
            }
            lastSelection = currentSelection;
            lastSelectionID = currentSelection ? currentSelection.GetInstanceID() : 0;
        }
    }
}
