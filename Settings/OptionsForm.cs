using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemUsageBar
{
    public partial class OptionsForm : Form
    {
        private static OptionsForm _instance = null;

        private readonly Settings.SettingsSection _generalSettings = Settings.Current.GetSection(Element.SettingsSectionName);
        private readonly Settings.SettingsSection _cpuSettings = Settings.Current.GetSection(CpuGraphElement.CpuSettingsSectionName);
        private readonly Settings.SettingsSection _ramSettings = Settings.Current.GetSection(RamGraphElement.RamSettingsSectionName);
        private readonly Settings.SettingsSection _mediaInfoSettings = Settings.Current.GetSection(MediaInfoElement.MediaInfoSettingsSectionName);


        private OptionsForm()
        {
            InitializeComponent();

            LoadSettings();
        }

        public static void ShowOptions()
        {
            if(_instance != null)
            {
                _instance.BringToFront();
                _instance.Focus();
                return;
            }

            _instance = new OptionsForm();
            _instance.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
             base.OnClosed(e);
            _instance = null;
        }

        private void LoadSettings()
        {
            // General
            btnTextColor.BackColor = _generalSettings.GetColor(Element.TextColorSettingName);
            btnBorderColour.BackColor = _generalSettings.GetColor(Element.BorderColorSettingName);
            btnBoxColour.BackColor = _generalSettings.GetColor(Element.BackgroundColorSettingName);
            checkFlatBorder.Checked = _generalSettings.GetBool(Element.ShowBorderSettingName);
            checkFlatBackground.Checked = _generalSettings.GetBool(Element.ShowBackgroundSettingName);
            cbButHoverColor.Checked = _generalSettings.GetBool(Element.FillOnHoverSettingName);
            btnButHoverColor.BackColor = _generalSettings.GetColor(Element.FillHoverColorSettingName);
            comboElementStyle.SelectedItem = _generalSettings.GetString(Element.StyleSettingName);

            //CPU
            cbCpuEnabled.Checked = _cpuSettings.GetBool(Element.ElementEnabledSettingName);
            btnCpuGraphColour.BackColor = _cpuSettings.GetColor(CpuGraphElement.GraphColorSettingName);
            cbAlwaysShowCpu.Checked = _cpuSettings.GetBool(CpuGraphElement.AlwaysShowTextSettingName);
            nudSize.Value = _cpuSettings.GetInt32(CpuGraphElement.SizeSettingName);

            //RAM
            cbRamEnabled.Checked = _ramSettings.GetBool(Element.ElementEnabledSettingName);
            btnRamGraphColor.BackColor = _ramSettings.GetColor(RamGraphElement.GraphColorSettingName);
            cbExpandOnHover.Checked = _ramSettings.GetBool(RamGraphElement.ExpandOnHoverSettingName);

            //MediaInfo
            cbMediaInfoEnabled.Checked = _mediaInfoSettings.GetBool(Element.ElementEnabledSettingName);
            btnProgressColor.BackColor = _mediaInfoSettings.GetColor(MediaInfoElement.ProgressColorSettingName);
            btnTrackingColor.BackColor = _mediaInfoSettings.GetColor(MediaInfoElement.TrackingColorSettingName);
            cbTrackSongLengths.Checked = _mediaInfoSettings.GetBool(MediaInfoElement.TrackUnknownSongLengthsSettingName);
        }

        private void ApplySettings()
        {
            Settings.Current.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ApplySettings();
            this.Close();
        }


        #region General Setting

        private void btnBorderColour_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnBorderColour.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnBorderColour.BackColor = cd.Color;
                _generalSettings.SetColor(Element.BorderColorSettingName, cd.Color);
            }
        }

        private void btnBoxColour_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnBoxColour.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnBoxColour.BackColor = cd.Color;
                _generalSettings.SetColor(Element.BackgroundColorSettingName, cd.Color);
            }
        }

        private void btnButHoverColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = (btnButHoverColor.BackColor == Color.Transparent) ? Color.White : cd.Color = btnButHoverColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnButHoverColor.BackColor = cd.Color;
                cbButHoverColor.Checked = true;
                _generalSettings.SetColor(Element.FillHoverColorSettingName, cd.Color);
            }
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = (btnTextColor.BackColor == Color.Transparent) ? Color.White : cd.Color = btnTextColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnTextColor.BackColor = cd.Color;
                _generalSettings.SetColor(Element.TextColorSettingName, cd.Color);
            }
        }

        private void comboElementStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _generalSettings.SetString(Element.StyleSettingName, comboElementStyle.SelectedItem.ToString());
            gbBoxStyle.Enabled = comboElementStyle.SelectedItem.ToString() == "Flat";
        }

        private void cbButHoverColor_CheckedChanged(object sender, EventArgs e)
        {
            _generalSettings.SetBool(Element.FillOnHoverSettingName, cbButHoverColor.Checked);
        }

        private void checkFlatBorder_CheckedChanged(object sender, EventArgs e)
        {
            _generalSettings.SetBool(Element.ShowBorderSettingName, checkFlatBorder.Checked);
        }

        private void checkFlatBackground_CheckedChanged(object sender, EventArgs e)
        {
            _generalSettings.SetBool(Element.ShowBackgroundSettingName, checkFlatBackground.Checked);
        }

        #endregion

        #region CPU Settings

        private void cbCpuEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _cpuSettings.SetBool(Element.ElementEnabledSettingName, cbCpuEnabled.Checked);
        }

        private void btnCpuGraphColour_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnCpuGraphColour.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnCpuGraphColour.BackColor = cd.Color;
                _cpuSettings.SetColor(CpuGraphElement.GraphColorSettingName, cd.Color);
            }
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            _cpuSettings.SetInt32(CpuGraphElement.SizeSettingName, (int)nudSize.Value);
        }

        private void cbAlwaysShowCpu_CheckedChanged(object sender, EventArgs e)
        {
            _cpuSettings.SetBool(CpuGraphElement.AlwaysShowTextSettingName, cbAlwaysShowCpu.Checked);
        }

        #endregion

        #region RAM Settings

        private void cbRamEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _ramSettings.SetBool(Element.ElementEnabledSettingName, cbRamEnabled.Checked);
        }

        private void btnRamGraphColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnRamGraphColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnRamGraphColor.BackColor = cd.Color;
                _ramSettings.SetColor(RamGraphElement.GraphColorSettingName, cd.Color);
            }
        }

        private void cbExpandOnHover_CheckedChanged(object sender, EventArgs e)
        {
            _ramSettings.SetBool(RamGraphElement.ExpandOnHoverSettingName, cbExpandOnHover.Checked);
        }

        #endregion

        #region MediaInfo Settings

        private void cbMediaInfoEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _mediaInfoSettings.SetBool(Element.ElementEnabledSettingName, cbMediaInfoEnabled.Checked);
        }

        private void btnProgressColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnProgressColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnProgressColor.BackColor = cd.Color;
                _mediaInfoSettings.SetColor(MediaInfoElement.ProgressColorSettingName, cd.Color);
            }
        }

        private void cbTrackSongLengths_CheckedChanged(object sender, EventArgs e)
        {
            _mediaInfoSettings.SetBool(MediaInfoElement.TrackUnknownSongLengthsSettingName, cbTrackSongLengths.Checked);
        }

        private void btnTrackingColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = btnTrackingColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnTrackingColor.BackColor = cd.Color;
                _mediaInfoSettings.SetColor(MediaInfoElement.TrackingColorSettingName, cd.Color);
            }
        }

        #endregion



    }
}