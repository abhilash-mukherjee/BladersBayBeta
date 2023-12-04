using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Path = System.IO.Path;
namespace JMRSDK
{
    public class SplashScreenChecker : IPreprocessBuildWithReport
    {
        public int callbackOrder => 1;
        public void OnPreprocessBuild(BuildReport report)
        {
            CheckForSplashScreen();
        }
        public static async void CheckForSplashScreen()
        {
            bool status = PlayerSettings.SplashScreen.show;
            string resourcePath = $"{Application.dataPath}/Resources";
            string fullFilePath = $"{resourcePath}/{SplashScreenData.resourceFileName}.txt";
            if (!Directory.Exists(resourcePath))
                Directory.CreateDirectory(resourcePath);
            SplashScreenData data = new SplashScreenData();
            data.isSplashScreenActive = status;
            string strData = JsonUtility.ToJson(data);
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