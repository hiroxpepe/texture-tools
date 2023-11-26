// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Texture.Win64.Properties;

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

        int _layer_index;

        Image _view_img;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormMain() {
            InitializeComponent();
            initialize_field();
            _label_layer1.ForeColor = System.Drawing.Color.Lime;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event handler

        void _numericUpDown_width_ValueChanged(object sender, EventArgs e) {
            _rect.Width = (int)_numericUpDown_width.Value;
        }

        void _numericUpDown_height_ValueChanged(object sender, EventArgs e) {
            _rect.Height = (int)_numericUpDown_height.Value;
        }

        void _button_layer1_Click(object sender, EventArgs e) {
            if (_layer_index is not LAYER_1) {
                bool result = save_layer(index: _layer_index);
                if (!result) { return; }
                switch_layer_index();
                load_layer(index: _layer_index);
            }
        }

        void _button_layer2_Click(object sender, EventArgs e) {
            if (_layer_index is not LAYER_2) {
                bool result = save_layer(index: _layer_index);
                if (!result) { return; }
                switch_layer_index();
                load_layer(index: _layer_index);
            }
        }

        /// <summary>
        /// event handler where write button are clicked
        /// </summary>
        void _button_write_Click(object sender, EventArgs e) {
            bool result = save_layer(index: _layer_index);
            if (!result) { return; }
            write();
        }

        void _comboBox_language_SelectedIndexChanged(object sender, EventArgs e) {
            switch (_comboBox_language.Text) {
                case "日本語":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
                    break;
                case "English":
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
                    break;
            }

            _label_language.Text = Resources._label_language_Text;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        void initialize_field() {
            _rect = new(x: 0, y: 0, width: 256, height: 256);
            _param_array = new Param[2];
            for (int i = 0; i < 2; i++) {
                _param_array[i] = new Param(
                    piece_count: 3, 
                    crop: 1.0d, 
                    primary: "White", 
                    secondary: "White", 
                    accent: "none", 
                    alpha: 1.0f,
                    swing: 0
                );
            }
            _layer_index = 0;
        }

        bool save_layer(int index) {
            try {
                _param_array[index] = new Param(
                    piece_count: (int) _numericUpDown_piece_count.Value, 
                    crop: (double) _numericUpDown_crop.Value, 
                    primary: _comboBox_primary.Text, 
                    secondary: _comboBox_secondary.Text, 
                    accent: _comboBox_accent.Text, 
                    alpha: (float) _numericUpDown_alpha.Value,
                    swing: (int) _numericUpDown_swing.Value
                );
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        bool load_layer(int index) {
            try {
                _numericUpDown_piece_count.Value = _param_array[index].PieceCount;
                _numericUpDown_crop.Value = (decimal) _param_array[index].Crop;
                _comboBox_primary.Text = _param_array[index].Primary;
                _comboBox_secondary.Text = _param_array[index].Secondary;
                _comboBox_accent.Text = _param_array[index].Accent;
                _numericUpDown_alpha.Value = (decimal) _param_array[index].Alpha;
                _numericUpDown_swing.Value = _param_array[index].Swing;
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        bool write() {
            try {
                Context.OnDo += (object param, EvtArgs e) => {
                    using FileStream fs = new(
                        path: (string) param, 
      　　　　　　　　　mode: FileMode.Open, 
                        access: FileAccess.Read
                    );
                    _view_img?.Dispose();
                    _view_img = Image.FromStream(stream: fs);
                    _pictureBox_view.Image = _view_img;
                };
                return Context.Do(rect: _rect, param_array: _param_array);;
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        void switch_layer_index() {
            if (_layer_index == LAYER_1) {
                _layer_index = LAYER_2;
                _label_layer1.ForeColor = System.Drawing.Color.Gray;
                _label_layer2.ForeColor = System.Drawing.Color.Lime;
            }
            else if (_layer_index == LAYER_2) {
                _layer_index = LAYER_1;
                _label_layer2.ForeColor = System.Drawing.Color.Gray;
                _label_layer1.ForeColor = System.Drawing.Color.Lime;
            }
        }
    }
}