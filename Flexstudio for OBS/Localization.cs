using System;
using System.Drawing;
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

                // Update ContextMenuStrip items if the control has a ContextMenuStrip
                if (control.ContextMenuStrip != null)
                {
                    UpdateContextMenuText(control.ContextMenuStrip);
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

            // Get the current font size and style
            float currentSize = control.Font.Size;
            FontStyle currentStyle = control.Font.Style;

            // Get the custom font with the original size and style
            Font customFont = FontHelper.GetCustomFont(currentSize, currentStyle);

            // Apply the custom font
            control.Font = customFont;
        }

        public static void UpdateContextMenuText(ContextMenuStrip contextMenu)
        {
            foreach (ToolStripItem item in contextMenu.Items)
            {
                string itemKey = item.Name;
                string itemTranslatedText = GetStringWithFallback(itemKey);
                if (itemTranslatedText != null)
                {
                    item.Text = itemTranslatedText;
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

                    // Update the DataGridViewButtonColumn's DefaultCellStyle.NullValue
                    if (column is DataGridViewButtonColumn buttonColumn)
                    {
                        buttonColumn.DefaultCellStyle.NullValue = columnHeaderTranslatedText;
                    }
                }
            }
        }

        public static string GetStringWithFallback(string key, params object[] args)
        {
            string translatedText = trans.late.GetString(key, Thread.CurrentThread.CurrentUICulture);
            if (translatedText == null)
            {
                ResourceManager englishResourceManager = new ResourceManager("Flexstudio_for_OBS.Languages.Lang_en", typeof(trans).Assembly);
                translatedText = englishResourceManager.GetString(key, CultureInfo.GetCultureInfo("en"));
            }

            if (translatedText != null)
            {
                translatedText = translatedText.Replace("{newline}", Environment.NewLine);
                translatedText = string.Format(translatedText, args);
            }

            return translatedText;
        }

        public static string Me(string key, params object[] args)
        {
            return GetStringWithFallback(key, args);
        }
    }
}
