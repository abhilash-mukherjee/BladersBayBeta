using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Path = System.IO.Path;

namespace JMRSDK
{
    public class PreProcessSaveBundleVersion : IPreprocessBuildWithReport
    {
        public int callbackOrder => 2;

        public void OnPreprocessBuild(BuildReport report)
        {
            SaveBundleVersion(report);
        }

        public static async void SaveBundleVersion(BuildReport report)
        {
            string resourcePath = $"{Application.dataPath}/Resources";
            string fullFilePath = $"{resourcePath}/{AnalyticsUtils.bundleFileName}.txt";

            if (!Directory.Exists(resourcePath))
                Directory.CreateDirectory(resourcePath);


            string strData = PlayerSettings.iOS.buildNumber;
            byte[] array = System.Text.Encoding.UTF8.GetBytes(strData);

            using (FileStream stream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write))
            {
                await stream.WriteAsync(array, 0, array.Length);
                stream.Close();

                await Task.Delay(100);
                AssetDatabase.Refresh();
            }
        }
    }
}