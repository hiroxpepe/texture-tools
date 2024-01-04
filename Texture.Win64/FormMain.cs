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

        readonly string? _exe_dir_path;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// default constructor.
        /// </summary>
        public FormMain() {
            InitializeComponent();
            initialize_field();
            _label_layer1.ForeColor = System.Drawing.Color.Lime;
            _comboBox_primary.DrawMode = DrawMode.OwnerDrawFixed;
            _comboBox_secondary.DrawMode = DrawMode.OwnerDrawFixed;
            _comboBox_accent.DrawMode = DrawMode.OwnerDrawFixed;
            _comboBox_language.DrawMode = DrawMode.OwnerDrawFixed;
            _exe_dir_path = Path.GetDirectoryName(Application.ExecutablePath);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event handler

        /// <summary>
        /// event handler _numericUpDown_width are changed.
        /// </summary>
        void _numericUpDown_width_ValueChanged(object sender, EventArgs e) {
            _rect.Width = (int)_numericUpDown_width.Value;
        }

        /// <summary>
        /// event handler _numericUpDown_height are changed.
        /// </summary>
        void _numericUpDown_height_ValueChanged(object sender, EventArgs e) {
            _rect.Height = (int)_numericUpDown_height.Value;
        }

        /// <summary>
        /// event handler _button_layer1 are clicked.
        /// </summary>
        void _button_layer1_Click(object sender, EventArgs e) {
            if (_layer_index is not LAYER_1) {
                bool result = save_layer(index: _layer_index);
                if (!result) { return; }
                switch_layer_index();
                load_layer(index: _layer_index);
                _comboBox_accent.Enabled = true;
            }
        }

        /// <summary>
        /// event handler _button_layer2 are clicked.
        /// </summary>
        void _button_layer2_Click(object sender, EventArgs e) {
            if (_layer_index is not LAYER_2) {
                bool result = save_layer(index: _layer_index);
                if (!result) { return; }
                switch_layer_index();
                load_layer(index: _layer_index);
                _comboBox_accent.Enabled = false;
            }
        }

        /// <summary>
        /// event handler _button_write are clicked.
        /// </summary>
        void _button_write_Click(object sender, EventArgs e) {
            bool result = save_layer(index: _layer_index);
            if (!result) { return; }
            write();
        }

        /// <summary>
        /// event handler _comboBox_primary are draw item.
        /// </summary>
        void _comboBox_primary_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == -1) { return; }
            // gets a color icon image.
            Image image = get_color_icon_image(event_args: e);
            // draw combobox items by owner-draw.
            draw_combobox_by_owner(combobox: _comboBox_primary, event_args: e, image: image);
        }

        /// <summary>
        /// event handler _comboBox_secondary are draw item.
        /// </summary>
        void _comboBox_secondary_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == -1) { return; }
            // gets a color icon image.
            Image image = get_color_icon_image(event_args: e);
            // draw combobox items by owner-draw.
            draw_combobox_by_owner(combobox: _comboBox_secondary, event_args: e, image: image);
        }

        /// <summary>
        /// event handler _comboBox_accent are draw item.
        /// </summary>
        void _comboBox_accent_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == -1) { return; }
            // gets a color icon image.
            Image image = get_color_icon_image(event_args: e);
            // draw combobox items by owner-draw.
            draw_combobox_by_owner(combobox: _comboBox_accent, event_args: e, image: image);
        }

        /// <summary>
        /// event handler _comboBox_language are draw item.
        /// </summary>
        void _comboBox_language_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == -1) { return; }
            // gets a language icon image.
            Image image = get_language_icon_image(event_args: e);
            // draw combobox items by owner-draw.
            draw_combobox_by_owner(combobox: _comboBox_language, event_args: e, image: image);
        }

        /// <summary>
        /// event handler _comboBox_language are changed.
        /// </summary>
        void _comboBox_language_SelectedIndexChanged(object sender, EventArgs e) {
            switch (_comboBox_language.Text) {
                case "日本語":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(name: "ja");
                    break;
                case "English":
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(name: string.Empty);
                    break;
            }
            // changes language.
            change_language();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>
        /// initializes fields.
        /// </summary>
        void initialize_field() {
            // default size.
            _rect = new(x: 0, y: 0, width: 256, height: 256);
            // layers are two.
            _param_array = new Param[2];
            // defines init params.
            string[] layer1 = {"7", "0.9", "Green", "Lime", "Yellow", "1.0", "10"};
            string[] layer2 = {"6", "0.9", "Lime", "Yellow", "none", "0.475", "20"};
            string[][] layers = {layer1, layer2};
            // sets init params.
            for (int i = 0; i < 2; i++) {
                _param_array[i] = new Param(
                    piece_count: int.Parse(layers[i][0]), 
                    crop: double.Parse(layers[i][1]), 
                    primary: layers[i][2], 
                    secondary: layers[i][3], 
                    accent: layers[i][4], 
                    alpha: float.Parse(layers[i][5]),
                    swing: int.Parse(layers[i][6])
                );
            }
            // sets layer index.
            _layer_index = 0;
            // sets init params to controls
            _numericUpDown_piece_count.Value = int.Parse(layers[0][0]);
            _numericUpDown_crop.Value = (decimal) double.Parse(layers[0][1]);
            _comboBox_primary.Text = layers[0][2];
            _comboBox_secondary.Text = layers[0][3];
            _comboBox_accent.Text = layers[0][4];
            _numericUpDown_alpha.Value = (decimal) float.Parse(layers[0][5]);
            _numericUpDown_swing.Value = int.Parse(layers[0][6]);
        }

        /// <summary>
        /// saves layer params of the index.
        /// </summary>
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

        /// <summary>
        /// loads layer params of the index.
        /// </summary>
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

        /// <summary>
        /// writes an image.
        /// </summary>
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
                return Context.Do(rect: _rect, param_array: _param_array, use_layer2: _checkBox_layer2.Checked);
            }
            catch (Exception ex) {
                MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// switches layer index.
        /// </summary>
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

        /// <summary>
        /// changes language.
        /// </summary>
        void change_language() {
            Text = Resources.FormMain_Text;
            _groupBox_layer.Text = Resources._groupBox_layer_Text;
            _groupBox_rect.Text = Resources._groupBox_rect_Text;
            _groupBox_view.Text = Resources._groupBox_view_Text;
            _label_width.Text = Resources._label_width_Text;
            _label_height.Text = Resources._label_height_Text;
            _label_piece_count.Text = Resources._label_piece_count_Text;
            _label_crop.Text = Resources._label_crop_Text;
            _label_primary.Text = Resources._label_primary_Text;
            _label_secondary.Text = Resources._label_secondary_Text;
            _label_accent.Text = Resources._label_accent_Text;
            _label_alpha.Text = Resources._label_alpha_Text;
            _label_swing.Text = Resources._label_swing_Text;
            _label_language.Text = Resources._label_language_Text;
            _button_write.Text = Resources._button_write_Text;
            _button_layer1.Text = Resources._button_layer1_Text;
            _button_layer2.Text = Resources._button_layer2_Text;
            _checkBox_layer2.Text = Resources._checkBox_layer2_Text;
        }

        /// <summary>
        /// gets a color icon image.
        /// </summary>
        Image get_color_icon_image(DrawItemEventArgs event_args) {
            Image image = event_args.Index switch {
                1 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\red_icon.png"),
                2 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\orange_icon.png"),
                3 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\amber_icon.png"),
                4 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\yellow_icon.png"),
                5 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\lime_icon.png"),
                6 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\green_icon.png"),
                7 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\turquoise_icon.png"),
                8 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\azure_icon.png"),
                9 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\blue_icon.png"),
                10 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\purple_icon.png"),
                11 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\magenta_icon.png"),
                12 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\rose_icon.png"),
                13 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\black_icon.png"),
                14 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\white_icon.png"),
                _ => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\none_icon.png"),
            };
            return image;
        }

        /// <summary>
        /// gets a language icon image.
        /// </summary>
        Image get_language_icon_image(DrawItemEventArgs event_args) {
            Image image = event_args.Index switch {
                1 => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\japanese_icon.png"),
                _ => Image.FromFile(filename: $"{_exe_dir_path}\\Resources\\english_icon.png"),
            };
            return image;
        }

        /// <summary>
        /// draw combobox items by owner-draw.
        /// </summary>
        void draw_combobox_by_owner(ComboBox combobox, DrawItemEventArgs event_args, Image image) {
            // draw background color.
            event_args.DrawBackground();
            // draw an icon image.
            event_args.Graphics.DrawImage(image: image, x: event_args.Bounds.X, y: event_args.Bounds.Y + 2);
            // draw a text.
            event_args.Graphics.DrawString(
                s: combobox.Items[event_args.Index].ToString(),
                font: new Font(familyName: combobox.Items[event_args.Index].ToString(), emSize: 10),
                brush: new SolidBrush(color: System.Drawing.Color.Black),
                x: event_args.Bounds.X + (image.Width / 2),
                y: event_args.Bounds.Y
            );
            // draw the focused rectangle.
            event_args.DrawFocusRectangle();
            // disposes the icon image.
            image.Dispose();
        }
    }
}