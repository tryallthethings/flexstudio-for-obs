using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Flexstudio_for_OBS
{
    public static class trans
    {
        public static ResourceManager late { get; set; } = new ResourceManager("Flexstudio_for_OBS.Languages.Lang_en", typeof(trans).Assembly);

        public delegate void LanguageChangedEventHandler(object sender, EventArgs e);
        public static event LanguageChangedEventHandler LanguageChanged;

        public static void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void UpdateAllControlTexts(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Recursively update the text of nested controls
                if (control.HasChildren)
                {
                    UpdateAllControlTexts(control.Controls);
                }

                // Update the control's text using the control's name as the translation key
                UpdateControlText(control);

                // Update DataGridView headers if the control is a DataGridView
                if (control is DataGridView dgv)
                {
                    UpdateDataGridViewHeaders(dgv);
                }
            }
        }

        public static void UpdateControlText(Control control)
        {
            string translationKey = control.Name;
            string translatedText = GetStringWithFallback(translationKey);

            if (translatedText != null)
            {
                if (control is DataGridView dgv)
                {
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        string columnHeaderKey = column.Name;
                        string columnHeaderTranslatedText = GetStringWithFallback(columnHeaderKey);
                        if (columnHeaderTranslatedText != null)
                        {
                            column.HeaderText = columnHeaderTranslatedText;
                        }
                    }
                }
                else if (control is ComboBox cb)
                {
                    cb.BeginUpdate();
                    int selectedIndex = cb.SelectedIndex;
                    for (int i = 0; i < cb.Items.Count; i++)
                    {
                        string itemKey = cb.Items[i].ToString();
                        string itemTranslatedText = GetStringWithFallback(itemKey);
                        if (itemTranslatedText != null)
                        {
                            cb.Items[i] = itemTranslatedText;
                        }
                    }
                    cb.SelectedIndex = selectedIndex;
                    cb.EndUpdate();
                }
                else
                {
                    control.Text = translatedText;
                }
            }
        }

        public static void UpdateDataGridViewHeaders(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                string columnHeaderKey = column.Name;
                string columnHeaderTranslatedText = GetStringWithFallback(columnHeaderKey);
                if (columnHeaderTranslatedText != null)
                {
                    column.HeaderText = columnHeaderTranslatedText;
                }
            }
        }

        public static string GetStringWithFallback(string key)
        {
            string translatedText = trans.late.GetString(key, Thread.CurrentThread.CurrentUICulture);
            if (translatedText == null)
            {
                translatedText = trans.late.GetString(key, CultureInfo.GetCultureInfo("en"));
            }

            return translatedText;
        }

        public static string Me(string key)
        {
            return GetStringWithFallback(key);
        }
    }
}
