using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Reflection;

namespace FortniteOptimal
{
    public partial class frmOptimal : Form
    {
        private string config = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";
        private Dictionary<string, int> configValues = new();
        private Dictionary<string, CheckBox> configValueCheckBoxes = new();

        public frmOptimal()
        {
            InitializeComponent();

            // Create config
            if (!File.Exists(config)) { using (FileStream fs = File.Create(config)) { } }
            else
            {
                // Read the dictionary from the INI file
                configValues = ReadDictionaryFromIni(config);
            }
            if (configValues.Count > 0)
            {
                CheckValues();
            }
           //    if (configValues["AutoLaunch"] == 1)
           //    {
           //        chkLaunch.Checked = true;
           //        EpicGamesLauncher.Launch();
           //    }
           //}
            /*if (chkLaunch.Checked == true)
            {
                EpicGamesLauncher.Launch();
            }
            if (chkClose.Checked == true)
            {
                this.Close();
            }*/
        }

        private void CheckValues()
        {
            foreach (string key in configValues.Keys)
            {
                if (configValues[key] == 1)
                {
                    ValueToCheckBox(key);
                    //configValueCheckBoxes[key].Checked = true;
                    //chkLaunch.Checked = true; // FIX, make a second dictionary that maps names to checkboxes
                    //EpicGamesLauncher.Launch();
                }
            }
        }
        private void ValueToCheckBox(string key)
        {

        }
        //private void SetValues(string valueName, bool chkBoxStatus)
        //{
        //    if (chkBoxStatus == true)
        //    {
        //        if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 1); }
        //        else { configValues[valueName] = 1; }
        //    }
        //    else
        //    {
        //        if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 0); }
        //        else { configValues[valueName] = 0; }
        //    }
        //    WriteDictionaryToIni(configValues, config);
        //}
        private void SetValues(string valueName, CheckBox chkBox)
        {
            // Add dictionary checkbox link
            if (!configValueCheckBoxes.ContainsKey(valueName)) { configValueCheckBoxes.Add(valueName, chkBox); }

            if (chkBox.Checked == true)
            {
                if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 1); }
                else { configValues[valueName] = 1; }
            }
            else
            {
                if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 0); }
                else { configValues[valueName] = 0; }
            }
            WriteDictionaryToIni(configValues, config);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            EpicGamesLauncher.Launch();
            if (chkClose.Checked == true)
            {
                this.Close();
            }
        }

        private void chkLaunch_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("AutoLaunch", chkLaunch);
        }
        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("AutoClose", chkClose);
        }
        private void WriteDictionaryToIni(Dictionary<string, int> dictionary, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var kvp in dictionary)
                {
                    // Format each key-value pair as a line in the INI file
                    string line = $"{kvp.Key}={kvp.Value}";
                    sw.WriteLine(line);
                }
            }
        }
        private Dictionary<string, int> ReadDictionaryFromIni(string filePath)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            // Read lines from the INI file
            string[] lines = File.ReadAllLines(filePath);

            // Parse each line and populate the dictionary
            foreach (string line in lines)
            {
                // Split the line into key and value
                string[] parts = line.Split('=');

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    if (int.TryParse(parts[1], out int value))
                    {
                        result[key] = value;
                    }
                    // If the value is not an integer, you might want to handle this case accordingly
                }
                // If the line doesn't follow the expected format, you might want to handle this case accordingly
            }

            return result;
        }

        private void chkCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("UseCustomSettings", chkCustomSettings);
            //if (chkCustomSettings.Checked) { configValues.Add("chkCustomSettings", 1); }
            try
            {
                string gameUsr = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\GameUserSettings\";
                if (!Directory.Exists(gameUsr))
                    Directory.CreateDirectory(gameUsr);


                // Get all .ini files in the specified directory
                string[] iniFiles = Directory.GetFiles(gameUsr, "*.ini");

                // Check if there are any .ini files
                if (iniFiles.Length > 0)
                {
                    // Populate the ListBox with the file names
                    foreach (string iniFile in iniFiles)
                    {
                        // Add each file name to the ListBox
                        lstConfig.Items.Add(Path.GetFileName(iniFile));
                    }
                }
                else
                {
                    // No .ini files found
                    MessageBox.Show("No .ini files found in the directory.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur (e.g., directory not found, access denied)
                MessageBox.Show($"An error occurred: {ex.Message}");

            }
            if (!chkCustomSettings.Checked)
                lstConfig.Items.Clear();
        }

    }
}