
namespace HomeWork_1
{
    partial class Records
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lRecordsInfo = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lRecordsInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lRecordsInfo
            // 
            this.lRecordsInfo.AutoSize = true;
            this.lRecordsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lRecordsInfo.Location = new System.Drawing.Point(3, 19);
            this.lRecordsInfo.Name = "lRecordsInfo";
            this.lRecordsInfo.Size = new System.Drawing.Size(202, 15);
            this.lRecordsInfo.TabIndex = 0;
            this.lRecordsInfo.Text = "Здесь будут отображаться рекорды";
            // 
            // bExit
            // 
            this.bExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.bExit.Location = new System.Drawing.Point(249, 19);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 30);
            this.bExit.TabIndex = 0;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bExit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Records";
            this.Text = "Records";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lRecordsInfo;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}