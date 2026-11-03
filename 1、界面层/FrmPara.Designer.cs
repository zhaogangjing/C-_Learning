namespace S7_Database
{
    partial class FrmPara
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.cmb_CpuType = new System.Windows.Forms.ComboBox();
            this.txt_Rack = new System.Windows.Forms.TextBox();
            this.txt_Slot = new System.Windows.Forms.TextBox();
            this.btn_SetOk = new System.Windows.Forms.Button();
            this.btn_SetCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_FrmClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 1);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(82, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPU类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(83, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "机架号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(83, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "插槽号：";
            // 
            // txt_IP
            // 
            this.txt_IP.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_IP.Location = new System.Drawing.Point(202, 87);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(142, 30);
            this.txt_IP.TabIndex = 5;
            this.txt_IP.Text = "192.168.1.110";
            this.txt_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_CpuType
            // 
            this.cmb_CpuType.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_CpuType.FormattingEnabled = true;
            this.cmb_CpuType.Location = new System.Drawing.Point(202, 129);
            this.cmb_CpuType.Name = "cmb_CpuType";
            this.cmb_CpuType.Size = new System.Drawing.Size(142, 30);
            this.cmb_CpuType.TabIndex = 6;
            // 
            // txt_Rack
            // 
            this.txt_Rack.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Rack.Location = new System.Drawing.Point(202, 170);
            this.txt_Rack.Name = "txt_Rack";
            this.txt_Rack.Size = new System.Drawing.Size(142, 30);
            this.txt_Rack.TabIndex = 7;
            // 
            // txt_Slot
            // 
            this.txt_Slot.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Slot.Location = new System.Drawing.Point(202, 211);
            this.txt_Slot.Name = "txt_Slot";
            this.txt_Slot.Size = new System.Drawing.Size(142, 30);
            this.txt_Slot.TabIndex = 8;
            // 
            // btn_SetOk
            // 
            this.btn_SetOk.BackgroundImage = global::S7_Database.Properties.Resources.Green;
            this.btn_SetOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SetOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(85)))));
            this.btn_SetOk.FlatAppearance.BorderSize = 0;
            this.btn_SetOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SetOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_SetOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetOk.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SetOk.ForeColor = System.Drawing.Color.White;
            this.btn_SetOk.Location = new System.Drawing.Point(87, 268);
            this.btn_SetOk.Name = "btn_SetOk";
            this.btn_SetOk.Size = new System.Drawing.Size(111, 43);
            this.btn_SetOk.TabIndex = 9;
            this.btn_SetOk.Text = "设置完成";
            this.btn_SetOk.UseVisualStyleBackColor = true;
            this.btn_SetOk.Click += new System.EventHandler(this.btn_SetOk_Click);
            // 
            // btn_SetCancel
            // 
            this.btn_SetCancel.BackgroundImage = global::S7_Database.Properties.Resources.Yellow;
            this.btn_SetCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SetCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(85)))));
            this.btn_SetCancel.FlatAppearance.BorderSize = 0;
            this.btn_SetCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SetCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_SetCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetCancel.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SetCancel.ForeColor = System.Drawing.Color.White;
            this.btn_SetCancel.Location = new System.Drawing.Point(233, 268);
            this.btn_SetCancel.Name = "btn_SetCancel";
            this.btn_SetCancel.Size = new System.Drawing.Size(111, 43);
            this.btn_SetCancel.TabIndex = 10;
            this.btn_SetCancel.Text = "取消设置";
            this.btn_SetCancel.UseVisualStyleBackColor = true;
            this.btn_SetCancel.Click += new System.EventHandler(this.btn_SetCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::S7_Database.Properties.Resources.Param;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(41, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "参数设置";
            // 
            // btn_FrmClose
            // 
            this.btn_FrmClose.BackColor = System.Drawing.Color.Navy;
            this.btn_FrmClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(85)))));
            this.btn_FrmClose.FlatAppearance.BorderSize = 0;
            this.btn_FrmClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(85)))));
            this.btn_FrmClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(85)))));
            this.btn_FrmClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FrmClose.Font = new System.Drawing.Font("阿里巴巴普惠体 3.0 55 Regular", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FrmClose.ForeColor = System.Drawing.Color.White;
            this.btn_FrmClose.Location = new System.Drawing.Point(370, 0);
            this.btn_FrmClose.Name = "btn_FrmClose";
            this.btn_FrmClose.Size = new System.Drawing.Size(51, 54);
            this.btn_FrmClose.TabIndex = 13;
            this.btn_FrmClose.Text = "X";
            this.btn_FrmClose.UseVisualStyleBackColor = false;
            this.btn_FrmClose.Click += new System.EventHandler(this.btn_FrmClose_Click);
            // 
            // FrmPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(421, 346);
            this.Controls.Add(this.btn_FrmClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_SetCancel);
            this.Controls.Add(this.btn_SetOk);
            this.Controls.Add(this.txt_Slot);
            this.Controls.Add(this.txt_Rack);
            this.Controls.Add(this.cmb_CpuType);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsers";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.ComboBox cmb_CpuType;
        private System.Windows.Forms.TextBox txt_Rack;
        private System.Windows.Forms.TextBox txt_Slot;
        private System.Windows.Forms.Button btn_SetOk;
        private System.Windows.Forms.Button btn_SetCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_FrmClose;
    }
}