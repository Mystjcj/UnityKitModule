//=======================================================
// 作者：liangddyy
// 描述：
//=======================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Liangddyy.UnityKitModule
{
    public class CommonUtil
    {
        public static bool IsOSXEditor
        {
            get { return Application.dataPath.StartsWith("/"); }
        }

        public static bool IsSelectSingleFloder()
        {
            if (Selection.assetGUIDs.Length != 1)
                return false;
            if (AssetDatabase.IsValidFolder(AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0])))
                return true;
            return false;
        }

        /// <summary>
        /// 遍历一个物体
        /// </summary>
        public static void ForEachChilds(Transform parent, Action<Transform> callback, bool isContainsParent = false)
        {
            if (isContainsParent)
                callback(parent);
            if (parent.childCount <= 0) return;
            for (int i = 0; i < parent.childCount; i++)
            {
                var item = parent.GetChild(i);
                ForEachChilds(item, callback, true);
            }
        }

        public static List<string> GetFiles(string path, Func<string, bool> filter = null)
        {
            if (!Directory.Exists(path))
                return null;

            IEnumerable<string> files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            if (filter != null)
                files = files.Where(filter).ToList();

            return files.ToList();
        }
    }
}