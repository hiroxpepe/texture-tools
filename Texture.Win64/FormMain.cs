// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Texture.Core;
using Texture.Draw;
using static Texture.Core.Cut;
using static Texture.Core.Face;
using static Texture.Core.Swing;
using static Texture.Draw.Palette;
using static Texture.Draw.Extensions;

namespace Texture.Win64 {
    /// <summary>
    /// main form.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public partial class FormMain : Form {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        const int LAYER_1 = 0;
        const int LAYER_2 = 1;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        Rectangle _rect;

        Param[] _param_array;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormMain() {
            InitializeComponent();
            initializeParam();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event handler

        async void _numericUpDown_width_ValueChanged(object sender, EventArgs e) {
            await Task.Run(action: () => {
                _rect.Width = (int)_numericUpDown_width.Value;
            });
        }

        async void _numericUpDown_height_ValueChanged(object sender, EventArgs e) {
            await Task.Run(action: () => {
                _rect.Height = (int)_numericUpDown_height.Value;
            });
        }

        async void _radioButton_layer1_Click(object sender, EventArgs e) {
            bool result = await saveLayer(index: LAYER_2);
            if (result) { await loadLayer(index: LAYER_1); }
        }

        async void _radioButton_layer2_Click(object sender, EventArgs e) {
            bool result = await saveLayer(index: LAYER_1);
            if (result) { await loadLayer(index: LAYER_2); }
        }

        /// <summary>
        /// event handler where write button are clicked
        /// </summary>
        async void _button_write_Click(object sender, EventArgs e) {
            bool result = await saveLayer(index: getLayerIndex());
            if (result) { await write(); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        void initializeParam() {
            _rect = new(x: 0, y: 0, width: 256, height: 256);
            _param_array = new Param[2];
            for (int i = 0; i < 2; i++) {
                _param_array[i] = new Param(
                    cut: NewCutDefault(),
                    face: NewFace(width: 256, height: 256),
                    palette: NewPalette(primary: Color.Red, secondary: Color.Orange),
                    swing: NewSwing(value: 5)
                );
            }
        }

        async Task<bool> saveLayer(int index) {
            try {
                Cut cut = NewCutByPiece(piece_count: (int)_numericUpDown_piece_count.Value);
                Face face = NewFace(rect: _rect, cut: cut, crop: (double)_numericUpDown_crop.Value);
                Palette palette = NewPalette(
                    primary: _comboBox_primary.Text,
                    secondary: _comboBox_secondary.Text,
                    accent: _comboBox_accent.Text,
                    alpha: (float)_numericUpDown_alpha.Value
                );
                Swing swing = NewSwing(value: (int)_numericUpDown_swing.Value);
                _param_array[index] = new Param(
                    cut: cut,
                    face: face,
                    palette: palette,
                    swing: swing
                );
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        async Task<bool> loadLayer(int index) {
            try {
                Cut cut = _param_array[index].Cut;
                Face face = _param_array[index].Face;
                Palette palette = _param_array[index].Palette;
                Swing swing = _param_array[index].Swing;
                _numericUpDown_piece_count.Value = cut.CountX; // FIXME:
                _numericUpDown_crop.Value = (decimal)face.Crop;
                _comboBox_primary.Text = palette.Primary.ToString();
                _comboBox_secondary.Text = palette.Secondary.ToString();
                _comboBox_accent.Text = palette.Accent.ToString();
                _numericUpDown_alpha.Value = (decimal)palette.Alpha;
                _numericUpDown_swing.Value = swing.MaxValueX; // FIXME:
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        async Task<bool> write() {
            try {
                bool result = await Context.Do(rect: _rect, param_array: _param_array);
                return result;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        int getLayerIndex() {
            if (_radioButton_layer1.Checked == true) {
                return 0;
            }
            else if (_radioButton_layer2.Checked == true) {
                return 1;
            }
            else {
                return -1;
            }
        }
    }
}