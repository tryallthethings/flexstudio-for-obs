using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormSettings : Form
    {
        public string menuTitle = "Settings";
        private Dictionary<Control, EventHandler> _subscribedControls = new Dictionary<Control, EventHandler>();

        public FormSettings()
        {
            InitializeComponent();
            SubscribeComponents(this, false); // Unsubscribe Events
            List<char> driveAvail = getAvailableDriveLetters(FormMain.isMapped);
            cbbDriveLetter.DataSource = driveAvail;
            cbbDriveLetter.SelectedIndex = -1;
            LoadSettingsToControl(this);
            
            cbbDriveLetter.Enabled = !FormMain.isMapped;
            SubscribeComponents(this, true); // Subscribe Events
            AutoScaleDimensions = new SizeF(96F, 96F);
        }

        public static List<char> getAvailableDriveLetters(bool isMapped)
        {
            List<char> availableDriveLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            DriveInfo[] drives = DriveInfo.GetDrives();
            if (!isMapped)
            {
                for (int i = 0; i < drives.Length; i++)
                {
                    availableDriveLetters.Remove((drives[i].Name).ToUpper()[0]);
                }
            }

            return availableDriveLetters;
        }

        private void SettingValueChanged(object sender, EventArgs e)
        {
            var control = sender as Control;

            if (control != null)
            {
                string settingKey = control.Tag.ToString();

                if (control is TextBox)
                {
                    sett.ing[settingKey] = (control as TextBox).Text;
                }
                else if (control is ComboBox)
                {
                    sett.ing[settingKey] = (control as ComboBox).SelectedValue.ToString();
                }
                else if (control is CheckBox)
                {
                    sett.ing[settingKey] = (control as CheckBox).Checked.ToString();
                }
                // Add more control types if needed
            }
        }

        private void LoadSettingsToControl(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.HasChildren)
                {
                    LoadSettingsToControl(childControl);
                }

                if (childControl.Tag != null && !string.IsNullOrEmpty(childControl.Tag.ToString()))
                {
                    string settingKey = childControl.Tag.ToString();

                    if (!string.IsNullOrEmpty(sett.ing[settingKey]))
                    {
                        if (childControl is TextBox)
                        {
                            childControl.Text = sett.ing[settingKey];
                        }
                        else if (childControl is ComboBox)
                        {
                            (childControl as ComboBox).SelectedIndex = (childControl as ComboBox).FindStringExact(sett.ing[settingKey]);
                        }
                        else if (childControl is CheckBox)
                        {
                            (childControl as CheckBox).Checked = bool.Parse(sett.ing[settingKey]);
                        }
                        // Add more control types if needed
                    }
                }
            }
        }

        // Subscribe or unsubscribe all Form controls from SettingValueChanged
        private void SubscribeComponents(Control control, bool subscribe)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.HasChildren)
                {
                    SubscribeComponents(childControl, subscribe);
                }

                if (childControl.Tag != null && !string.IsNullOrEmpty(childControl.Tag.ToString()))
                {
                    EventHandler handler = SettingValueChanged;

                    if (subscribe)
                    {
                        if (_subscribedControls.ContainsKey(childControl))
                        {
                            if (childControl is TextBox)
                            {
                                (childControl as TextBox).TextChanged += _subscribedControls[childControl];
                            }
                            else if (childControl is ComboBox)
                            {
                                (childControl as ComboBox).SelectedValueChanged += _subscribedControls[childControl];
                            }
                            else if (childControl is CheckBox)
                            {
                                (childControl as CheckBox).CheckedChanged += _subscribedControls[childControl];
                            }
                            // Add more control types if needed
                        }
                    }
                    else
                    {
                        if (childControl is TextBox)
                        {
                            var textBox = childControl as TextBox;
                            textBox.TextChanged -= handler;
                            _subscribedControls[textBox] = handler;
                        }
                        else if (childControl is ComboBox)
                        {
                            var comboBox = childControl as ComboBox;
                            comboBox.SelectedValueChanged -= handler;
                            _subscribedControls[comboBox] = handler;
                        }
                        else if (childControl is CheckBox)
                        {
                            var checkBox = childControl as CheckBox;
                            checkBox.CheckedChanged -= handler;
                            _subscribedControls[checkBox] = handler;
                        }
                        // Add more control types if needed
                    }
                }
            }
        }
    }
}
