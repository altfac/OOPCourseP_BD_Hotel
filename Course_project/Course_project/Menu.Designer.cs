namespace Course_project
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btn_films = new System.Windows.Forms.Button();
            this.btn_partcp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_films
            // 
            this.btn_films.BackColor = System.Drawing.Color.Pink;
            this.btn_films.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_films.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_films.Location = new System.Drawing.Point(0, 187);
            this.btn_films.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_films.Name = "btn_films";
            this.btn_films.Size = new System.Drawing.Size(976, 185);
            this.btn_films.TabIndex = 0;
            this.btn_films.Text = "Номера";
            this.btn_films.UseVisualStyleBackColor = false;
            this.btn_films.Click += new System.EventHandler(this.btn_films_Click);
            // 
            // btn_partcp
            // 
            this.btn_partcp.BackColor = System.Drawing.Color.LightGreen;
            this.btn_partcp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_partcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_partcp.Location = new System.Drawing.Point(0, 2);
            this.btn_partcp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_partcp.Name = "btn_partcp";
            this.btn_partcp.Size = new System.Drawing.Size(976, 185);
            this.btn_partcp.TabIndex = 1;
            this.btn_partcp.Text = "Гости";
            this.btn_partcp.UseVisualStyleBackColor = false;
            this.btn_partcp.Click += new System.EventHandler(this.btn_partcp_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(976, 372);
            this.Controls.Add(this.btn_partcp);
            this.Controls.Add(this.btn_films);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(998, 428);
            this.MinimumSize = new System.Drawing.Size(998, 428);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гостиница";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_films;
        private System.Windows.Forms.Button btn_partcp;
    }
}

