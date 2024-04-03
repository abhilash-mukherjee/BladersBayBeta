using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using JMRSDK.EditorScript;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace JMRSDK.ManifestModifier
{
    public class SO_JMR_Manifest : ScriptableObject
    {
        [EnumFlags] public DeviceType deviceType;
        [EnumFlags] public InteractionType interactionType;
        public Categories category;
        public string licenseKey;

        public void SetToDefault()
        {
            ManifestConfig.ClearAll();

            SetDeviceType((DeviceType)~0);
            SetInteraction((InteractionType)~0);

            category = Categories.Gaming;
            SetCatogory(category);
        }

        public void LoadFromManifest()
        {
            //ReadDataLocally();

            //SetDeviceType(deviceType);
            //SetInteraction(interactionType);
            //SetCatogory(category);
            //SetLicenseKey();

            ManifestConfig.GetDataFromManifest();
        }

        public void SetDeviceType(DeviceType deviceType)
        {
            if ((int)deviceType == -1)
            {
                this.deviceType = (DeviceType)(2 << 1);
                ManifestConfig.SetDeviceTypeCARDBOARDCheckBoxBool();
                return;
            }

            switch (deviceType)
            {
                case DeviceType.PRO:
                    ManifestConfig.SetDeviceTypePROCheckBoxBool();
                    break;
                case DeviceType.JIO_DIVE:
                    ManifestConfig.SetDeviceTypeCARDBOARDCheckBoxBool();
                    break;
                case DeviceType.JIO_GLASS:
                    ManifestConfig.SetDeviceTypeLITECheckBoxBool();
                    break;
                case DeviceType.HOLOBOARD:
                    ManifestConfig.SetDeviceTypeHOLOBOARDCheckBoxBool();
                    break;
            }
        }

        public void SetInteraction(InteractionType interactionType)
        {
            if ((int)interactionType == -1)
            {
                this.interactionType = (InteractionType)(1 << 1);
                ManifestConfig.SetGazeAndClickCheckBoxBool();
                return;
            }

            switch (interactionType)
            {
                case InteractionType.GazeAndClick:
                    ManifestConfig.SetGazeAndClickCheckBoxBool();
                    break;
                case InteractionType.GazeAndDwell:
                    ManifestConfig.SetGazeAndDwellCheckBoxBool();
                    break;
                case InteractionType.Controller:
                    ManifestConfig.SetControllerCheckBoxBool();
                    break;
            }
        }

        public void SetLicenseKey()
        {
            ManifestConfig.ConfigureLisenceKey(licenseKey);
        }

        public void SetCatogory(Categories categories)
        {
            switch (categories)
            {
                case Categories.Entertainment:
                    ManifestConfig.ConfigCategory_Entertainment();
                    break;
                case Categories.Gaming:
                    ManifestConfig.ConfigCategory_Gaming();
                    break;
                case Categories.Learning:
                    ManifestConfig.ConfigCategory_Learning();
                    break;
                case Categories.Productivity:
                    ManifestConfig.ConfigCategory_Productivity();
                    break;
                case Categories.Utilities:
                    ManifestConfig.ConfigCategory_Utilities();
                    break;
                case Categories.Shopping:
                    ManifestConfig.ConfigCategory_Shopping();
                    break;
                case Categories.Health_And_Wellness:
                    ManifestConfig.ConfigCategory_HealthAndWellness();
                    break;
                case Categories.Miscellaneous:
                    ManifestConfig.ConfigCategory_Miscellaneous();
                    break;
            }
        }

        public void SetAllData()
        {
            List<int> deviceTypes = ReturnSelectedElements(deviceType, (int)deviceType);
            List<int> interactionTypes = ReturnSelectedElements(interactionType, (int)interactionType);

            if (deviceTypes.Count > 0)
            {
                for (int i = 0; i < deviceTypes.Count; i++)
                {
                    SetDeviceType((DeviceType)deviceTypes[i]);
                }
            }
            else
            {
                SetDeviceType((DeviceType)~0);
            }

            if (interactionTypes.Count > 0)
            {
                for (int i = 0; i < interactionTypes.Count; i++)
                {
                    SetInteraction((InteractionType)interactionTypes[i]);
                }
            }
            else
            {
                SetInteraction((InteractionType)~0);
            }

            SetCatogory(category);
            SetLicenseKey();
        }

        private List<int> ReturnSelectedElements<T>(T enumVariable, int value) where T : Enum
        {

            List<int> selectedElements = new List<int>();

            for (int i = 0; i < Enum.GetValues(typeof(T)).Length; i++)
            {
                int layer = 1 << i;
                if ((value & layer) != 0)
                {
                    selectedElements.Add(i);
                }
            }

            return selectedElements;
        }

        private void SaveDataLocally()
        {
            PlayerPrefs.SetInt("Manifest_DeviceType", (int)deviceType);
            PlayerPrefs.SetInt("Manifest_InteractionType", (int)interactionType);
            PlayerPrefs.SetInt("Manifest_Category", (int)category);
            PlayerPrefs.SetString("Manifest_License", licenseKey);
        }

        private void ReadDataLocally()
        {
            deviceType = (DeviceType)PlayerPrefs.GetInt("Manifest_DeviceType");
            interactionType = (InteractionType)PlayerPrefs.GetInt("Manifest_InteractionType");
            category = (Categories)PlayerPrefs.GetInt("Manifest_Category");
            licenseKey = PlayerPrefs.GetString("Manifest_License");
        }
    }


    public enum PlatformType
    {
        SM = 0,
        CU
    }

    public static class ManifestConfig
    {
        private static string manifestPath = Path.Combine(Environment.CurrentDirectory + "/Assets/Plugins/Android/AndroidManifest.xml");

        public static PlatformType currentPlatform = PlatformType.SM;

        #region Iteraction Type Editor Prefs
        private const string interactionTypeControllerPrefKey = "InteractionTypeController";
        private static bool interactionTypeController
        {
            get => EditorPrefs.GetBool(interactionTypeControllerPrefKey);
            set => EditorPrefs.SetBool(interactionTypeControllerPrefKey, value);
        }
        private const string interactionTypeGazeAndClickPrefKey = "InteractionTypeGazeAndClick";
        private static bool interactionTypeGazeAndClick
        {
            get => EditorPrefs.GetBool(interactionTypeGazeAndClickPrefKey);
            set => EditorPrefs.SetBool(interactionTypeGazeAndClickPrefKey, value);
        }
        private const string interactionTypeGazeAndDwellPrefKey = "InteractionTypeGazeAndDwell";
        private static bool interactionTypeGazeAndDwell
        {
            get => EditorPrefs.GetBool(interactionTypeGazeAndDwellPrefKey);
            set => EditorPrefs.SetBool(interactionTypeGazeAndDwellPrefKey, value);
        }
        private const string interactionConfigurationPrefKey = "InteractionType";
        private static string interactionConfiguration
        {
            get => EditorPrefs.GetString(interactionConfigurationPrefKey);
            set => EditorPrefs.SetString(interactionConfigurationPrefKey, value);
        }

        #endregion

        #region Device Type Editor Prefs
        private const string deviceTypePROPrefKey = "DeviceTypePRO";
        private static bool deviceTypePRO
        {
            get => EditorPrefs.GetBool(deviceTypePROPrefKey);
            set => EditorPrefs.SetBool(deviceTypePROPrefKey, value);
        }
        private const string deviceTypeLITEPrefKey = "DeviceTypeLITE";
        private static bool deviceTypeLITE
        {
            get => EditorPrefs.GetBool(deviceTypeLITEPrefKey);
            set => EditorPrefs.SetBool(deviceTypeLITEPrefKey, value);
        }
        private const string deviceTypeCARDBOARDPrefKey = "DeviceTypeCARDBOARD";
        private static bool deviceTypeCARDBOARD
        {
            get => EditorPrefs.GetBool(deviceTypeCARDBOARDPrefKey);
            set => EditorPrefs.SetBool(deviceTypeCARDBOARDPrefKey, value);
        }
        private const string deviceTypeHOLOBOARDPrefKey = "DeviceTypeHOLOBOARD";
        private static bool deviceTypeHOLOBOARD
        {
            get => EditorPrefs.GetBool(deviceTypeHOLOBOARDPrefKey);
            set => EditorPrefs.SetBool(deviceTypeHOLOBOARDPrefKey, value);
        }

        #endregion
        private static SO_JMR_Manifest soFile;

        private static string GetGUID()
        {
            var guids = AssetDatabase.FindAssets("t:" + nameof(SO_JMR_Manifest));

            if (guids.Length > 0)
                return guids[0];

            return null;
        }

        [MenuItem("JioMixedReality/Manifest/Show Asset", priority = 1)]
        private static void ShowAsset()
        {
            soFile = AssetDatabase.LoadAssetAtPath<SO_JMR_Manifest>(AssetDatabase.GUIDToAssetPath(GetGUID()));

            if(soFile == null)
            {
                CreateAsset();
            }
            else
            {
                EditorUtility.FocusProjectWindow();
                Selection.SetActiveObjectWithContext(soFile, Selection.activeContext);
                EditorGUIUtility.PingObject(Selection.activeObject);
            }
        }

        private static void CreateAsset()
        {
            soFile = ScriptableObject.CreateInstance<SO_JMR_Manifest>();
            string path = "Assets/Resources/ScriptableObjects/";
            string fileName = "SO_JMR_Manifest.asset";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            AssetDatabase.CreateAsset(soFile, path + fileName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.SetActiveObjectWithContext(soFile, Selection.activeContext);
            EditorGUIUtility.PingObject(Selection.activeObject);
        }

        public class BuildRunSO : IPreprocessBuildWithReport
        {
            public int callbackOrder => 0;

            public void OnPreprocessBuild(BuildReport report)
            {
                if(soFile == null)
                    soFile = AssetDatabase.LoadAssetAtPath<SO_JMR_Manifest>(AssetDatabase.GUIDToAssetPath(GetGUID()));

                if (soFile != null)
                {
                    ClearAll();
                    soFile.SetAllData();
                }
            }
        }

        public static void ResetAndroidManifest()
        {
            ResetPermissions();
            DisableRecentHistoryAttributes();

            Debug.Log("Status --> Android Manifest Reset");
        }

        /// <summary>
        /// Use to set the manifest to SM platform
        /// </summary>
        public static void SM_Setup()
        {
            currentPlatform = PlatformType.SM;
            ResetAndroidManifest();
            // DisableRecentHistoryAttributes();

            Debug.Log("Status --> SM Manifest Setup Completed");
        }

        /// <summary>
        /// Use to set the manifest to CU platform
        /// </summary>
        public static void CU_Setup()
        {
            currentPlatform = PlatformType.CU;
            ResetAndroidManifest();
            // EnableRecentHistoryAttributes();

            Debug.Log("Status --> CU Manifest Setup Completed");
        }

        #region PERMISSION EDITOR

        static string disabledCamera = $"<!--<uses-permission android:name=\"android.permission.CAMERA\"/>-->";
        static string enabledCamera = $"<uses-permission android:name=\"android.permission.CAMERA\"/>";

        static string disabledAudio = $"<!--<uses-permission android:name=\"android.permission.RECORD_AUDIO\"/>-->";
        static string enabledAudio = $"<uses-permission android:name=\"android.permission.RECORD_AUDIO\"/>";

        static string disableWriteExternalPermission = $"<uses-permission android:name=\"android.permission.WRITE_EXTERNAL_STORAGE\" tools:node=\"remove\" />";
        static string enableWriteExternalPermission = $"<uses-permission android:name=\"android.permission.WRITE_EXTERNAL_STORAGE\"/>";

        static string disableReadExternalPermission = $"<uses-permission android:name=\"android.permission.READ_EXTERNAL_STORAGE\" tools:node=\"remove\" />";
        static string enableReadExternalPermission = $"<uses-permission android:name=\"android.permission.READ_EXTERNAL_STORAGE\"/>";

        /// <summary>
        /// Toggles Audio and Camera permission at the same time [Recommended to use this method]
        /// By Default Permissions should be disabled
        /// </summary>
        public static void ToggleCameraAudioPrmission()
        {
            TogglePermissions(enabledCamera, disabledCamera);
            TogglePermissions(enabledAudio, disabledAudio);
        }

        /// <summary>
        /// Toggles Read and write external storage permission at the same time [Recommended to use this method]
        /// By Default Permissions should be disabled
        /// </summary>
        public static void ToggleStoragePermissions()
        {
            TogglePermissions(enableWriteExternalPermission, disableWriteExternalPermission);
            TogglePermissions(enableReadExternalPermission, disableReadExternalPermission);
        }

        /// <summary>
        /// Remove all mentioned permissions
        /// [Camera,Audio,Write external,Read External]
        /// </summary>
        public static void ResetPermissions()
        {
            TogglePermissions(enabledCamera, disabledCamera, true);
            TogglePermissions(enabledAudio, disabledAudio, true);

            TogglePermissions(enableWriteExternalPermission, disableWriteExternalPermission, true);
            TogglePermissions(enableReadExternalPermission, disableReadExternalPermission, true);
        }

        public static void TogglePermissions(string enableString, string disableString, bool isReset = false)
        {
            string manifest = ReadString(manifestPath);

            if (string.IsNullOrEmpty(manifest))
            {
                Debug.LogError("Manifest not found."); return;
            }

            if (isReset)
            {
                if (manifest.Contains(disableString))
                {
                    //Debug.LogWarning("Status -->  Permission already disabled");
                    return;
                }
                else if (manifest.Contains(enableString))
                {
                    manifest = manifest.Replace(enableString, disableString);
                    Debug.Log("Status -->  Permission RESET");
                }
            }
            else
            {
                //*** Dont reverse these conditions , otherwise this toggel wont work properly ***
                if (manifest.Contains(disableString))
                {
                    manifest = manifest.Replace(disableString, enableString);
                    Debug.Log("Status -->  Permission Enabled");
                }
                else if (manifest.Contains(enableString))
                {
                    manifest = manifest.Replace(enableString, disableString);
                    Debug.Log("Status -->  Permission Disabled");
                }
            }
            WriteString(manifest, manifestPath);
        }
        #endregion

        #region Utilities

        static string ReadString(string readPath = "")
        {
            StreamReader reader = new StreamReader(readPath);
            string textInFile = reader.ReadToEnd();
            reader.Close();
            return textInFile;
        }

        static void WriteString(string text, string writePath = "")
        {
            StreamWriter writer = new StreamWriter(writePath);
            writer.Write(text);
            writer.Close();
        }

        #endregion

        #region XML ATTRIBUTE UPDATE

        static string xmlString = string.Empty;
        private const string xmlPath = "Assets/Plugins/Android/AndroidManifest.xml";

        private const string xmlActivityNodePath = "manifest/application/activity";

        private const string NoHistory = "android:noHistory";
        private const string ExcludeFromRecents = "android:excludeFromRecents";

        private const string xmlMetaDataNotePath = "//manifest/application/meta-data";
        private const string attributeKey_PRO_LITE = "com.jiotesseract.platform";
        private const string attributeKey_CATEGORY = "com.jiotesseract.mr.category";
        private const string attributeKey_INTERACTIONTYPE = "com.jiotesseract.mr.interactiontype";
        private const string attributeKey_LICENSEKEY = "com.jiotesseract.licensekey";
        private const string AndroidValue = "android:value";
        private const string AndroidName = "android:name";
        private static string[] CATEGORIES = { "0", "1", "2", "3", "4", "5", "6", "7" };
        private static string[] INTERACTIONTYPE = { "Controller", "GazeAndClick", "GazeAndDwell" };
        private static string[] DEVICETYPE = { "PRO", "LITE", "CARDBOARD", "HOLOBOARD" };


        public static void DisableRecentHistoryAttributes()
        {
            UpdateXMLNonRecurringAttributes(xmlActivityNodePath, NoHistory, "false");
            UpdateXMLNonRecurringAttributes(xmlActivityNodePath, ExcludeFromRecents, "false");
        }

        public static void EnableRecentHistoryAttributes()
        {
            UpdateXMLNonRecurringAttributes(xmlActivityNodePath, NoHistory, "true");
            UpdateXMLNonRecurringAttributes(xmlActivityNodePath, ExcludeFromRecents, "true");
        }

        #region Configure Device Type
        public static void SetDeviceTypePROCheckBoxBool()
        {
            deviceTypePRO = !deviceTypePRO;
            ConfigureDeviceAttributeStringValue();
        }

        public static void SetDeviceTypeLITECheckBoxBool()
        {
            deviceTypeLITE = !deviceTypeLITE;
            ConfigureDeviceAttributeStringValue();
        }

        public static void SetDeviceTypeCARDBOARDCheckBoxBool()
        {
            deviceTypeCARDBOARD = !deviceTypeCARDBOARD;
            ConfigureDeviceAttributeStringValue();
        }

        public static void SetDeviceTypeHOLOBOARDCheckBoxBool()
        {
            deviceTypeHOLOBOARD = !deviceTypeHOLOBOARD;
            ConfigureDeviceAttributeStringValue();
        }

        public static void GetDataFromManifest()
        {
            if (soFile == null)
                soFile = AssetDatabase.LoadAssetAtPath<SO_JMR_Manifest>(AssetDatabase.GUIDToAssetPath(GetGUID()));

            string[] deviceTypes = GetAttributeStringFromManifest(ReadXMLAttributes(xmlMetaDataNotePath, AndroidValue, AndroidName, attributeKey_PRO_LITE));

            string[] interactionTypes = GetAttributeStringFromManifest(ReadXMLAttributes(xmlMetaDataNotePath, AndroidValue, AndroidName, attributeKey_INTERACTIONTYPE));

            string category = ReadXMLAttributes(xmlMetaDataNotePath, AndroidValue, AndroidName, attributeKey_CATEGORY);

            string license = ReadXMLAttributes(xmlMetaDataNotePath, AndroidValue, AndroidName, attributeKey_LICENSEKEY);

            if (deviceTypes.Length > 0) 
            {
                soFile.deviceType = 0;

                foreach (var st in deviceTypes)
                {
                    switch (st)
                    {
                        case "PRO":
                            soFile.deviceType |= (DeviceType)(1 << 0);
                            break; 
                        case "LITE":
                            soFile.deviceType |= (DeviceType)(1 << 1);
                            break; 
                        case "CARDBOARD":
                            soFile.deviceType |= (DeviceType)(1 << 2);
                            break;
                        case "HOLOBOARD":
                            soFile.deviceType |= (DeviceType)(1 << 3);
                            break;
                    }
                }
            }

            if (interactionTypes.Length > 0)
            {
                soFile.interactionType = 0;

                foreach (var st in interactionTypes)
                {
                    switch (st)
                    {
                        case "Controller":
                            soFile.interactionType |= (InteractionType)(1 << 0);
                            break;
                        case "GazeAndClick":
                            soFile.interactionType |= (InteractionType)(1 << 1);
                            break;
                        case "GazeAndDwell":
                            soFile.interactionType |= (InteractionType)(1 << 2);
                            break;
                    }
                }
            }

            soFile.category = (Categories)int.Parse(category);
            soFile.licenseKey = license;
        }

        #endregion

        #region Configure Category
        public static void ConfigCategory_Entertainment()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[0], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Gaming()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[1], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Learning()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[2], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Productivity()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[3], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Utilities()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[4], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_HealthAndWellness()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[5], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Shopping()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[6], AndroidName, attributeKey_CATEGORY);
        }

        public static void ConfigCategory_Miscellaneous()
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, CATEGORIES[7], AndroidName, attributeKey_CATEGORY);
        }
        #endregion

        #region Configure Interaction
        public static void SetControllerCheckBoxBool()
        {
            interactionTypeController = !interactionTypeController;
            ConfigureInteractionAttributeStringValue();
        }

        public static void SetGazeAndClickCheckBoxBool()
        {
            interactionTypeGazeAndClick = !interactionTypeGazeAndClick;
            ConfigureInteractionAttributeStringValue();
        }

        public static void SetGazeAndDwellCheckBoxBool()
        {
            interactionTypeGazeAndDwell = !interactionTypeGazeAndDwell;
            ConfigureInteractionAttributeStringValue();
        }
        #endregion

        #region Configure License
        public static void ConfigureLisenceKey(string key)
        {
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, key, AndroidName, attributeKey_LICENSEKEY);
        }
        #endregion

        private static void ConfigureInteractionAttributeStringValue()
        {

            string interactionTypeStringVal = "";
            if (interactionTypeController)
            {
                interactionTypeStringVal = INTERACTIONTYPE[0];
            }

            if (interactionTypeGazeAndClick)
            {
                if (string.IsNullOrEmpty(interactionTypeStringVal))
                {
                    interactionTypeStringVal = INTERACTIONTYPE[1];
                }
                else
                {
                    interactionTypeStringVal = string.Concat(interactionTypeStringVal, "|", INTERACTIONTYPE[1]);
                }
            }
            if (interactionTypeGazeAndDwell)
            {
                if (string.IsNullOrEmpty(interactionTypeStringVal))
                {
                    interactionTypeStringVal = INTERACTIONTYPE[2];
                }
                else
                {
                    interactionTypeStringVal = string.Concat(interactionTypeStringVal, "|", INTERACTIONTYPE[2]);
                }
            }
            Debug.Log("JMRSDK=> Interaction Attribute Key Set =>> " + interactionTypeStringVal);
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, interactionTypeStringVal, AndroidName, attributeKey_INTERACTIONTYPE);
        }
        private static void ConfigureDeviceAttributeStringValue()
        {

            string deviceTypeStringVal = "";
            if (deviceTypePRO)
            {
                deviceTypeStringVal = DEVICETYPE[0];
            }

            if (deviceTypeLITE)
            {
                if (string.IsNullOrEmpty(deviceTypeStringVal))
                {
                    deviceTypeStringVal = DEVICETYPE[1];
                }
                else
                {
                    deviceTypeStringVal = string.Concat(deviceTypeStringVal, "|", DEVICETYPE[1]);
                }
            }
            if (deviceTypeCARDBOARD)
            {
                if (string.IsNullOrEmpty(deviceTypeStringVal))
                {
                    deviceTypeStringVal = DEVICETYPE[2];
                }
                else
                {
                    deviceTypeStringVal = string.Concat(deviceTypeStringVal, "|", DEVICETYPE[2]);
                }

            }
            if (deviceTypeHOLOBOARD)
            {
                if (string.IsNullOrEmpty(deviceTypeStringVal))
                {
                    deviceTypeStringVal = DEVICETYPE[3];
                }
                else
                {
                    deviceTypeStringVal = string.Concat(deviceTypeStringVal, "|", DEVICETYPE[3]);
                }
            }
            Debug.Log("JMRSDK=> Device Type Attribute Key Set =>> " + deviceTypeStringVal);
            UpdateXMLRecurringAttributes(xmlMetaDataNotePath, AndroidValue, deviceTypeStringVal, AndroidName, attributeKey_PRO_LITE);
        }

        private static string[] GetAttributeStringFromManifest(string value)
        {
            string[] allValues;

            if (value.Contains('|'))
            {
                allValues = value.Split('|');
            }
            else
            {
                allValues = new string[1] { value };
            }

            return allValues;
        }

        /// <summary>
        /// For unique node attributes (which doesnt repeat in manifest)
        /// </summary>
        /// <param name="xmlNodePath"></param>
        /// <param name="xmlAttributeName"></param>
        /// <param name="value"></param>
        private static void UpdateXMLNonRecurringAttributes(string xmlNodePath, string xmlAttributeName, string value)
        {
            xmlString = File.ReadAllText(xmlPath);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            //var element = doc.SelectSingleNode(xmlNodePath) as XmlElement;
            var list = doc.SelectNodes(xmlNodePath);

            foreach (XmlElement element in list)
            {
                if (element != null && element.HasAttribute(xmlAttributeName))
                {
                    element.SetAttribute(xmlAttributeName, value.ToString());
                    doc.Save(xmlPath);
                }
                else
                {
                    Debug.LogError("XML Element " + xmlAttributeName + " not found. Please check the PATH");
                }
            }
        }

        /// <summary>
        /// For re-curring node attributes (which repeats in manifest)
        /// </summary>
        /// <param name="xmlNodePath"></param>
        /// <param name="xmlTargetAttributeName"></param>
        /// <param name="value"></param>
        /// <param name="xmlSearchAttribute"></param>
        /// <param name="xmlSearchAttributeKey"></param>
        private static void UpdateXMLRecurringAttributes(string xmlNodePath, string xmlTargetAttributeName, string value, string xmlSearchAttribute, string xmlSearchAttributeKey)
        {
            xmlString = File.ReadAllText(xmlPath);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            var list = doc.SelectNodes(xmlNodePath);

            foreach (XmlElement element in list)
            {
                if (element != null && element.HasAttribute(xmlSearchAttribute) && element.HasAttribute(xmlTargetAttributeName))
                {
                    if (element.Attributes[xmlSearchAttribute].Value == xmlSearchAttributeKey)
                    {
                        element.SetAttribute(xmlTargetAttributeName, value.ToString());
                        doc.Save(xmlPath);
                    }
                }
                else
                {
                    Debug.LogError("XML Element not found. Please check the PATH");
                }
            }
        }

        private static string ReadXMLAttributes(string xmlNodePath, string xmlTargetAttributeName, string xmlSearchAttribute, string xmlSearchAttributeKey)
        {
            xmlString = File.ReadAllText(xmlPath);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            var list = doc.SelectNodes(xmlNodePath);

            foreach (XmlElement element in list)
            {
                if (element != null && element.HasAttribute(xmlSearchAttribute) && element.HasAttribute(xmlTargetAttributeName))
                {

                    if (element.Attributes[xmlSearchAttribute].Value == xmlSearchAttributeKey)
                    {
                        return element.GetAttribute(xmlTargetAttributeName);
                    }
                }
            }
            return "XML Element not found. Please check the PATH";
        }

        public static void ClearAll()
        {
            deviceTypeCARDBOARD = deviceTypeHOLOBOARD = deviceTypeLITE = deviceTypePRO = false;
            interactionTypeController = interactionTypeGazeAndClick = interactionTypeGazeAndDwell = false;
        }

        #endregion

    }

    [CustomEditor(typeof(SO_JMR_Manifest))]

    public class Editor_SO_JMR_Manifest : Editor
    {
        private SO_JMR_Manifest script;

        public override void OnInspectorGUI()
        {
            GUILayout.Space(20);
            base.OnInspectorGUI();
            script = (SO_JMR_Manifest)target;
            GUILayout.Space(10);

            if (GUILayout.Button("UPDATE", GUILayout.Height(20)))
            {
                ManifestConfig.ClearAll();

                script.SetAllData();
            }

            GUILayout.Space(5);

            if (GUILayout.Button("LOAD DATA", GUILayout.Height(20)))
            {
                script.LoadFromManifest();
            }
        }
    }
}