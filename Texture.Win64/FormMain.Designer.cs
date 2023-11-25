namespace Texture.Win64 {
    partial class FormMain {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this._button_write = new System.Windows.Forms.Button();
            this._numericUpDown_width = new System.Windows.Forms.NumericUpDown();
            this._numericUpDown_height = new System.Windows.Forms.NumericUpDown();
            this._label_width = new System.Windows.Forms.Label();
            this._label_height = new System.Windows.Forms.Label();
            this._numericUpDown_piece_count = new System.Windows.Forms.NumericUpDown();
            this._label_piece_count = new System.Windows.Forms.Label();
            this._numericUpDown_crop = new System.Windows.Forms.NumericUpDown();
            this._label_crop = new System.Windows.Forms.Label();
            this._comboBox_primary = new System.Windows.Forms.ComboBox();
            this._label_primary = new System.Windows.Forms.Label();
            this._comboBox_secondary = new System.Windows.Forms.ComboBox();
            this._label_secondary = new System.Windows.Forms.Label();
            this._comboBox_accent = new System.Windows.Forms.ComboBox();
            this._label_accent = new System.Windows.Forms.Label();
            this._numericUpDown_alpha = new System.Windows.Forms.NumericUpDown();
            this._label_alpha = new System.Windows.Forms.Label();
            this._numericUpDown_swing = new System.Windows.Forms.NumericUpDown();
            this._label_swing = new System.Windows.Forms.Label();
            this._groupBox_layer = new System.Windows.Forms.GroupBox();
            this._label_layer1 = new System.Windows.Forms.Label();
            this._label_layer2 = new System.Windows.Forms.Label();
            this._button_layer1 = new System.Windows.Forms.Button();
            this._button_layer2 = new System.Windows.Forms.Button();
            this._groupBox_rect = new System.Windows.Forms.GroupBox();
            this._groupBox_view = new System.Windows.Forms.GroupBox();
            this._pictureBox_view = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_piece_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_crop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_swing)).BeginInit();
            this._groupBox_layer.SuspendLayout();
            this._groupBox_rect.SuspendLayout();
            this._groupBox_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_view)).BeginInit();
            this.SuspendLayout();
            // 
            // _button_write
            // 
            this._button_write.AllowDrop = true;
            this._button_write.BackColor = System.Drawing.Color.Gray;
            this._button_write.ForeColor = System.Drawing.SystemColors.Control;
            this._button_write.Location = new System.Drawing.Point(17, 588);
            this._button_write.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._button_write.Name = "_button_write";
            this._button_write.Size = new System.Drawing.Size(279, 48);
            this._button_write.TabIndex = 0;
            this._button_write.Text = "write";
            this._button_write.UseVisualStyleBackColor = false;
            this._button_write.Click += new System.EventHandler(this._button_write_Click);
            // 
            // _numericUpDown_width
            // 
            this._numericUpDown_width.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this._numericUpDown_width.Location = new System.Drawing.Point(112, 26);
            this._numericUpDown_width.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this._numericUpDown_width.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this._numericUpDown_width.Name = "_numericUpDown_width";
            this._numericUpDown_width.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_width.TabIndex = 7;
            this._numericUpDown_width.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._numericUpDown_width.ValueChanged += new System.EventHandler(this._numericUpDown_width_ValueChanged);
            // 
            // _numericUpDown_height
            // 
            this._numericUpDown_height.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this._numericUpDown_height.Location = new System.Drawing.Point(112, 70);
            this._numericUpDown_height.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this._numericUpDown_height.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this._numericUpDown_height.Name = "_numericUpDown_height";
            this._numericUpDown_height.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_height.TabIndex = 8;
            this._numericUpDown_height.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._numericUpDown_height.ValueChanged += new System.EventHandler(this._numericUpDown_height_ValueChanged);
            // 
            // _label_width
            // 
            this._label_width.AutoSize = true;
            this._label_width.ForeColor = System.Drawing.SystemColors.Control;
            this._label_width.Location = new System.Drawing.Point(50, 28);
            this._label_width.Name = "_label_width";
            this._label_width.Size = new System.Drawing.Size(49, 20);
            this._label_width.TabIndex = 9;
            this._label_width.Text = "width:";
            // 
            // _label_height
            // 
            this._label_height.AutoSize = true;
            this._label_height.ForeColor = System.Drawing.SystemColors.Control;
            this._label_height.Location = new System.Drawing.Point(45, 72);
            this._label_height.Name = "_label_height";
            this._label_height.Size = new System.Drawing.Size(54, 20);
            this._label_height.TabIndex = 10;
            this._label_height.Text = "height:";
            // 
            // _numericUpDown_piece_count
            // 
            this._numericUpDown_piece_count.Location = new System.Drawing.Point(112, 119);
            this._numericUpDown_piece_count.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this._numericUpDown_piece_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDown_piece_count.Name = "_numericUpDown_piece_count";
            this._numericUpDown_piece_count.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_piece_count.TabIndex = 11;
            this._numericUpDown_piece_count.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // _label_piece_count
            // 
            this._label_piece_count.AutoSize = true;
            this._label_piece_count.ForeColor = System.Drawing.SystemColors.Control;
            this._label_piece_count.Location = new System.Drawing.Point(10, 121);
            this._label_piece_count.Name = "_label_piece_count";
            this._label_piece_count.Size = new System.Drawing.Size(89, 20);
            this._label_piece_count.TabIndex = 12;
            this._label_piece_count.Text = "piece count:";
            // 
            // _numericUpDown_crop
            // 
            this._numericUpDown_crop.DecimalPlaces = 2;
            this._numericUpDown_crop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this._numericUpDown_crop.Location = new System.Drawing.Point(112, 163);
            this._numericUpDown_crop.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDown_crop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numericUpDown_crop.Name = "_numericUpDown_crop";
            this._numericUpDown_crop.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_crop.TabIndex = 13;
            this._numericUpDown_crop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _label_crop
            // 
            this._label_crop.AutoSize = true;
            this._label_crop.ForeColor = System.Drawing.SystemColors.Control;
            this._label_crop.Location = new System.Drawing.Point(57, 165);
            this._label_crop.Name = "_label_crop";
            this._label_crop.Size = new System.Drawing.Size(42, 20);
            this._label_crop.TabIndex = 14;
            this._label_crop.Text = "crop:";
            // 
            // _comboBox_primary
            // 
            this._comboBox_primary.FormattingEnabled = true;
            this._comboBox_primary.Items.AddRange(new object[] {
            "none",
            "Red",
            "Orange",
            "Amber",
            "Yellow",
            "Lime",
            "Green",
            "Turquoise",
            "Azure",
            "Blue",
            "Purple",
            "Magenta",
            "Rose",
            "Black",
            "White"});
            this._comboBox_primary.Location = new System.Drawing.Point(112, 207);
            this._comboBox_primary.Name = "_comboBox_primary";
            this._comboBox_primary.Size = new System.Drawing.Size(150, 28);
            this._comboBox_primary.TabIndex = 15;
            this._comboBox_primary.Text = "White";
            // 
            // _label_primary
            // 
            this._label_primary.AutoSize = true;
            this._label_primary.ForeColor = System.Drawing.SystemColors.Control;
            this._label_primary.Location = new System.Drawing.Point(36, 210);
            this._label_primary.Name = "_label_primary";
            this._label_primary.Size = new System.Drawing.Size(63, 20);
            this._label_primary.TabIndex = 16;
            this._label_primary.Text = "primary:";
            // 
            // _comboBox_secondary
            // 
            this._comboBox_secondary.FormattingEnabled = true;
            this._comboBox_secondary.Items.AddRange(new object[] {
            "none",
            "Red",
            "Orange",
            "Amber",
            "Yellow",
            "Lime",
            "Green",
            "Turquoise",
            "Azure",
            "Blue",
            "Purple",
            "Magenta",
            "Rose",
            "Black",
            "White"});
            this._comboBox_secondary.Location = new System.Drawing.Point(112, 252);
            this._comboBox_secondary.Name = "_comboBox_secondary";
            this._comboBox_secondary.Size = new System.Drawing.Size(150, 28);
            this._comboBox_secondary.TabIndex = 17;
            this._comboBox_secondary.Text = "White";
            // 
            // _label_secondary
            // 
            this._label_secondary.AutoSize = true;
            this._label_secondary.ForeColor = System.Drawing.SystemColors.Control;
            this._label_secondary.Location = new System.Drawing.Point(20, 255);
            this._label_secondary.Name = "_label_secondary";
            this._label_secondary.Size = new System.Drawing.Size(79, 20);
            this._label_secondary.TabIndex = 18;
            this._label_secondary.Text = "secondary:";
            // 
            // _comboBox_accent
            // 
            this._comboBox_accent.FormattingEnabled = true;
            this._comboBox_accent.Items.AddRange(new object[] {
            "none",
            "Red",
            "Orange",
            "Amber",
            "Yellow",
            "Lime",
            "Green",
            "Turquoise",
            "Azure",
            "Blue",
            "Purple",
            "Magenta",
            "Rose",
            "Black",
            "White"});
            this._comboBox_accent.Location = new System.Drawing.Point(112, 297);
            this._comboBox_accent.Name = "_comboBox_accent";
            this._comboBox_accent.Size = new System.Drawing.Size(150, 28);
            this._comboBox_accent.TabIndex = 19;
            this._comboBox_accent.Text = "none";
            // 
            // _label_accent
            // 
            this._label_accent.AutoSize = true;
            this._label_accent.ForeColor = System.Drawing.SystemColors.Control;
            this._label_accent.Location = new System.Drawing.Point(44, 300);
            this._label_accent.Name = "_label_accent";
            this._label_accent.Size = new System.Drawing.Size(55, 20);
            this._label_accent.TabIndex = 20;
            this._label_accent.Text = "accent:";
            // 
            // _numericUpDown_alpha
            // 
            this._numericUpDown_alpha.DecimalPlaces = 2;
            this._numericUpDown_alpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this._numericUpDown_alpha.Location = new System.Drawing.Point(112, 342);
            this._numericUpDown_alpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDown_alpha.Name = "_numericUpDown_alpha";
            this._numericUpDown_alpha.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_alpha.TabIndex = 21;
            this._numericUpDown_alpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _label_alpha
            // 
            this._label_alpha.AutoSize = true;
            this._label_alpha.ForeColor = System.Drawing.SystemColors.Control;
            this._label_alpha.Location = new System.Drawing.Point(50, 344);
            this._label_alpha.Name = "_label_alpha";
            this._label_alpha.Size = new System.Drawing.Size(49, 20);
            this._label_alpha.TabIndex = 22;
            this._label_alpha.Text = "alpha:";
            // 
            // _numericUpDown_swing
            // 
            this._numericUpDown_swing.Location = new System.Drawing.Point(112, 386);
            this._numericUpDown_swing.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this._numericUpDown_swing.Name = "_numericUpDown_swing";
            this._numericUpDown_swing.Size = new System.Drawing.Size(150, 27);
            this._numericUpDown_swing.TabIndex = 23;
            // 
            // _label_swing
            // 
            this._label_swing.AutoSize = true;
            this._label_swing.ForeColor = System.Drawing.SystemColors.Control;
            this._label_swing.Location = new System.Drawing.Point(49, 386);
            this._label_swing.Name = "_label_swing";
            this._label_swing.Size = new System.Drawing.Size(50, 20);
            this._label_swing.TabIndex = 24;
            this._label_swing.Text = "swing:";
            // 
            // _groupBox_layer
            // 
            this._groupBox_layer.Controls.Add(this._label_layer1);
            this._groupBox_layer.Controls.Add(this._label_layer2);
            this._groupBox_layer.Controls.Add(this._button_layer1);
            this._groupBox_layer.Controls.Add(this._button_layer2);
            this._groupBox_layer.Controls.Add(this._label_swing);
            this._groupBox_layer.Controls.Add(this._numericUpDown_piece_count);
            this._groupBox_layer.Controls.Add(this._numericUpDown_swing);
            this._groupBox_layer.Controls.Add(this._label_piece_count);
            this._groupBox_layer.Controls.Add(this._label_alpha);
            this._groupBox_layer.Controls.Add(this._numericUpDown_crop);
            this._groupBox_layer.Controls.Add(this._numericUpDown_alpha);
            this._groupBox_layer.Controls.Add(this._label_crop);
            this._groupBox_layer.Controls.Add(this._label_accent);
            this._groupBox_layer.Controls.Add(this._comboBox_primary);
            this._groupBox_layer.Controls.Add(this._comboBox_accent);
            this._groupBox_layer.Controls.Add(this._label_primary);
            this._groupBox_layer.Controls.Add(this._label_secondary);
            this._groupBox_layer.Controls.Add(this._comboBox_secondary);
            this._groupBox_layer.ForeColor = System.Drawing.SystemColors.Control;
            this._groupBox_layer.Location = new System.Drawing.Point(17, 137);
            this._groupBox_layer.Name = "_groupBox_layer";
            this._groupBox_layer.Size = new System.Drawing.Size(279, 434);
            this._groupBox_layer.TabIndex = 25;
            this._groupBox_layer.TabStop = false;
            this._groupBox_layer.Text = "layer";
            // 
            // _label_layer1
            // 
            this._label_layer1.AutoSize = true;
            this._label_layer1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._label_layer1.Location = new System.Drawing.Point(75, 77);
            this._label_layer1.Name = "_label_layer1";
            this._label_layer1.Size = new System.Drawing.Size(24, 20);
            this._label_layer1.TabIndex = 28;
            this._label_layer1.Text = "●";
            // 
            // _label_layer2
            // 
            this._label_layer2.AutoSize = true;
            this._label_layer2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this._label_layer2.Location = new System.Drawing.Point(75, 30);
            this._label_layer2.Name = "_label_layer2";
            this._label_layer2.Size = new System.Drawing.Size(24, 20);
            this._label_layer2.TabIndex = 27;
            this._label_layer2.Text = "●";
            // 
            // _button_layer1
            // 
            this._button_layer1.BackColor = System.Drawing.Color.Gray;
            this._button_layer1.Location = new System.Drawing.Point(112, 73);
            this._button_layer1.Name = "_button_layer1";
            this._button_layer1.Size = new System.Drawing.Size(150, 29);
            this._button_layer1.TabIndex = 26;
            this._button_layer1.Text = "layer 1";
            this._button_layer1.UseVisualStyleBackColor = false;
            this._button_layer1.Click += new System.EventHandler(this._button_layer1_Click);
            // 
            // _button_layer2
            // 
            this._button_layer2.BackColor = System.Drawing.Color.Gray;
            this._button_layer2.Location = new System.Drawing.Point(112, 26);
            this._button_layer2.Name = "_button_layer2";
            this._button_layer2.Size = new System.Drawing.Size(150, 29);
            this._button_layer2.TabIndex = 25;
            this._button_layer2.Text = "layer 2";
            this._button_layer2.UseVisualStyleBackColor = false;
            this._button_layer2.Click += new System.EventHandler(this._button_layer2_Click);
            // 
            // _groupBox_rect
            // 
            this._groupBox_rect.Controls.Add(this._numericUpDown_width);
            this._groupBox_rect.Controls.Add(this._numericUpDown_height);
            this._groupBox_rect.Controls.Add(this._label_width);
            this._groupBox_rect.Controls.Add(this._label_height);
            this._groupBox_rect.ForeColor = System.Drawing.SystemColors.Control;
            this._groupBox_rect.Location = new System.Drawing.Point(17, 12);
            this._groupBox_rect.Name = "_groupBox_rect";
            this._groupBox_rect.Size = new System.Drawing.Size(279, 118);
            this._groupBox_rect.TabIndex = 26;
            this._groupBox_rect.TabStop = false;
            this._groupBox_rect.Text = "rect";
            // 
            // _groupBox_view
            // 
            this._groupBox_view.Controls.Add(this._pictureBox_view);
            this._groupBox_view.ForeColor = System.Drawing.SystemColors.Control;
            this._groupBox_view.Location = new System.Drawing.Point(314, 12);
            this._groupBox_view.Name = "_groupBox_view";
            this._groupBox_view.Size = new System.Drawing.Size(559, 559);
            this._groupBox_view.TabIndex = 27;
            this._groupBox_view.TabStop = false;
            this._groupBox_view.Text = "view";
            // 
            // _pictureBox_view
            // 
            this._pictureBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox_view.Location = new System.Drawing.Point(24, 26);
            this._pictureBox_view.Name = "_pictureBox_view";
            this._pictureBox_view.Size = new System.Drawing.Size(510, 510);
            this._pictureBox_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pictureBox_view.TabIndex = 0;
            this._pictureBox_view.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(901, 658);
            this.Controls.Add(this._groupBox_view);
            this.Controls.Add(this._groupBox_rect);
            this.Controls.Add(this._groupBox_layer);
            this.Controls.Add(this._button_write);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "テクスチャ生成";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_piece_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_crop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown_swing)).EndInit();
            this._groupBox_layer.ResumeLayout(false);
            this._groupBox_layer.PerformLayout();
            this._groupBox_rect.ResumeLayout(false);
            this._groupBox_rect.PerformLayout();
            this._groupBox_view.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _button_write;
        private System.Windows.Forms.NumericUpDown _numericUpDown_width;
        private System.Windows.Forms.NumericUpDown _numericUpDown_height;
        private System.Windows.Forms.Label _label_width;
        private System.Windows.Forms.Label _label_height;
        private System.Windows.Forms.NumericUpDown _numericUpDown_piece_count;
        private System.Windows.Forms.Label _label_piece_count;
        private System.Windows.Forms.NumericUpDown _numericUpDown_crop;
        private System.Windows.Forms.Label _label_crop;
        private System.Windows.Forms.ComboBox _comboBox_primary;
        private System.Windows.Forms.Label _label_primary;
        private System.Windows.Forms.ComboBox _comboBox_secondary;
        private System.Windows.Forms.Label _label_secondary;
        private System.Windows.Forms.ComboBox _comboBox_accent;
        private System.Windows.Forms.Label _label_accent;
        private System.Windows.Forms.NumericUpDown _numericUpDown_alpha;
        private System.Windows.Forms.Label _label_alpha;
        private System.Windows.Forms.NumericUpDown _numericUpDown_swing;
        private System.Windows.Forms.Label _label_swing;
        private System.Windows.Forms.GroupBox _groupBox_layer;
        private System.Windows.Forms.GroupBox _groupBox_rect;
        private System.Windows.Forms.Button _button_layer1;
        private System.Windows.Forms.Button _button_layer2;
        private System.Windows.Forms.Label _label_layer1;
        private System.Windows.Forms.Label _label_layer2;
        private System.Windows.Forms.GroupBox _groupBox_view;
        private System.Windows.Forms.PictureBox _pictureBox_view;
    }
}

