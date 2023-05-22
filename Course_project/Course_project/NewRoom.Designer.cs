namespace Course_project
{
    partial class NewRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRoom));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.CodeEditLabel = new System.Windows.Forms.Label();
            this.WindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.CodeRoomLabel = new System.Windows.Forms.Label();
            this.RoomCodeSelector = new System.Windows.Forms.NumericUpDown();
            this.PlacesRoomText = new System.Windows.Forms.Label();
            this.FloorRoomLabel = new System.Windows.Forms.Label();
            this.TypeRoomLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.typeRoomSelector = new System.Windows.Forms.ComboBox();
            this.FloorRoomSelector = new System.Windows.Forms.ComboBox();
            this.PlacesRoomSelector = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CostRoomSelector = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RoomCodeSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление нового номера";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Add.Location = new System.Drawing.Point(200, 307);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(65, 32);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Ок";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Back.Location = new System.Drawing.Point(14, 307);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(82, 32);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Отмена";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // CodeEditLabel
            // 
            this.CodeEditLabel.AutoSize = true;
            this.CodeEditLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CodeEditLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeEditLabel.Location = new System.Drawing.Point(166, 44);
            this.CodeEditLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CodeEditLabel.Name = "CodeEditLabel";
            this.CodeEditLabel.Size = new System.Drawing.Size(26, 17);
            this.CodeEditLabel.TabIndex = 72;
            this.CodeEditLabel.Text = "      ";
            // 
            // WindowsCheckBox
            // 
            this.WindowsCheckBox.AutoSize = true;
            this.WindowsCheckBox.Location = new System.Drawing.Point(14, 212);
            this.WindowsCheckBox.Name = "WindowsCheckBox";
            this.WindowsCheckBox.Size = new System.Drawing.Size(103, 17);
            this.WindowsCheckBox.TabIndex = 71;
            this.WindowsCheckBox.Text = "Добавить окно";
            this.WindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // CodeRoomLabel
            // 
            this.CodeRoomLabel.AutoSize = true;
            this.CodeRoomLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CodeRoomLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeRoomLabel.Location = new System.Drawing.Point(107, 67);
            this.CodeRoomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CodeRoomLabel.Name = "CodeRoomLabel";
            this.CodeRoomLabel.Size = new System.Drawing.Size(26, 17);
            this.CodeRoomLabel.TabIndex = 70;
            this.CodeRoomLabel.Text = "      ";
            // 
            // RoomCodeSelector
            // 
            this.RoomCodeSelector.Location = new System.Drawing.Point(110, 44);
            this.RoomCodeSelector.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.RoomCodeSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RoomCodeSelector.Name = "RoomCodeSelector";
            this.RoomCodeSelector.Size = new System.Drawing.Size(44, 20);
            this.RoomCodeSelector.TabIndex = 69;
            this.RoomCodeSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PlacesRoomText
            // 
            this.PlacesRoomText.AutoSize = true;
            this.PlacesRoomText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PlacesRoomText.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlacesRoomText.Location = new System.Drawing.Point(11, 192);
            this.PlacesRoomText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PlacesRoomText.Name = "PlacesRoomText";
            this.PlacesRoomText.Size = new System.Drawing.Size(26, 17);
            this.PlacesRoomText.TabIndex = 68;
            this.PlacesRoomText.Text = "      ";
            // 
            // FloorRoomLabel
            // 
            this.FloorRoomLabel.AutoSize = true;
            this.FloorRoomLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FloorRoomLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FloorRoomLabel.Location = new System.Drawing.Point(11, 148);
            this.FloorRoomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FloorRoomLabel.Name = "FloorRoomLabel";
            this.FloorRoomLabel.Size = new System.Drawing.Size(26, 17);
            this.FloorRoomLabel.TabIndex = 67;
            this.FloorRoomLabel.Text = "      ";
            // 
            // TypeRoomLabel
            // 
            this.TypeRoomLabel.AutoSize = true;
            this.TypeRoomLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TypeRoomLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeRoomLabel.Location = new System.Drawing.Point(139, 111);
            this.TypeRoomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TypeRoomLabel.Name = "TypeRoomLabel";
            this.TypeRoomLabel.Size = new System.Drawing.Size(26, 17);
            this.TypeRoomLabel.TabIndex = 66;
            this.TypeRoomLabel.Text = "      ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(135, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(197, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "₽";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(11, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 63;
            this.label6.Text = "Цена за ночь:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Количество мест";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "Этаж номера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Тип номера";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "Код номера";
            // 
            // typeRoomSelector
            // 
            this.typeRoomSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeRoomSelector.Items.AddRange(new object[] {
            "Бюджетный",
            "Стандартный",
            "Полулюкс",
            "Люкс"});
            this.typeRoomSelector.Location = new System.Drawing.Point(110, 85);
            this.typeRoomSelector.Name = "typeRoomSelector";
            this.typeRoomSelector.Size = new System.Drawing.Size(121, 21);
            this.typeRoomSelector.TabIndex = 73;
            // 
            // FloorRoomSelector
            // 
            this.FloorRoomSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FloorRoomSelector.FormattingEnabled = true;
            this.FloorRoomSelector.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.FloorRoomSelector.Location = new System.Drawing.Point(110, 127);
            this.FloorRoomSelector.Name = "FloorRoomSelector";
            this.FloorRoomSelector.Size = new System.Drawing.Size(45, 21);
            this.FloorRoomSelector.TabIndex = 74;
            // 
            // PlacesRoomSelector
            // 
            this.PlacesRoomSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlacesRoomSelector.FormattingEnabled = true;
            this.PlacesRoomSelector.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.PlacesRoomSelector.Location = new System.Drawing.Point(119, 171);
            this.PlacesRoomSelector.Name = "PlacesRoomSelector";
            this.PlacesRoomSelector.Size = new System.Drawing.Size(45, 21);
            this.PlacesRoomSelector.TabIndex = 75;
            // 
            // CostRoomSelector
            // 
            this.CostRoomSelector.Location = new System.Drawing.Point(101, 251);
            this.CostRoomSelector.Name = "CostRoomSelector";
            this.CostRoomSelector.Size = new System.Drawing.Size(91, 20);
            this.CostRoomSelector.TabIndex = 76;
            // 
            // NewRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(282, 355);
            this.ControlBox = false;
            this.Controls.Add(this.CostRoomSelector);
            this.Controls.Add(this.PlacesRoomSelector);
            this.Controls.Add(this.FloorRoomSelector);
            this.Controls.Add(this.typeRoomSelector);
            this.Controls.Add(this.CodeEditLabel);
            this.Controls.Add(this.WindowsCheckBox);
            this.Controls.Add(this.CodeRoomLabel);
            this.Controls.Add(this.RoomCodeSelector);
            this.Controls.Add(this.PlacesRoomText);
            this.Controls.Add(this.FloorRoomLabel);
            this.Controls.Add(this.TypeRoomLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(298, 394);
            this.MinimumSize = new System.Drawing.Size(298, 394);
            this.Name = "NewRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового номера";
            this.Load += new System.EventHandler(this.AddNewRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomCodeSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label CodeEditLabel;
        private System.Windows.Forms.CheckBox WindowsCheckBox;
        private System.Windows.Forms.Label CodeRoomLabel;
        private System.Windows.Forms.NumericUpDown RoomCodeSelector;
        private System.Windows.Forms.Label PlacesRoomText;
        private System.Windows.Forms.Label FloorRoomLabel;
        private System.Windows.Forms.Label TypeRoomLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox typeRoomSelector;
        private System.Windows.Forms.ComboBox FloorRoomSelector;
        private System.Windows.Forms.ComboBox PlacesRoomSelector;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox CostRoomSelector;
    }
}