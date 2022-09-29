
namespace USBmodify
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.UserMode = new System.Windows.Forms.TabPage();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.Information = new System.Windows.Forms.TabPage();
            this.lbl_error = new System.Windows.Forms.Label();
            this.txt_error = new System.Windows.Forms.TextBox();
            this.lbl_FilePath = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tab_Main.SuspendLayout();
            this.UserMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Main
            // 
            this.tab_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_Main.Controls.Add(this.UserMode);
            this.tab_Main.Controls.Add(this.Information);
            this.tab_Main.Location = new System.Drawing.Point(12, 12);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(656, 426);
            this.tab_Main.TabIndex = 2;
            // 
            // UserMode
            // 
            this.UserMode.Controls.Add(this.dgv_Data);
            this.UserMode.Location = new System.Drawing.Point(4, 28);
            this.UserMode.Name = "UserMode";
            this.UserMode.Padding = new System.Windows.Forms.Padding(3);
            this.UserMode.Size = new System.Drawing.Size(648, 394);
            this.UserMode.TabIndex = 0;
            this.UserMode.Text = "UserMode";
            this.UserMode.UseVisualStyleBackColor = true;
            // 
            // dgv_Data
            // 
            this.dgv_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Location = new System.Drawing.Point(6, 6);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersWidth = 62;
            this.dgv_Data.RowTemplate.Height = 31;
            this.dgv_Data.Size = new System.Drawing.Size(636, 375);
            this.dgv_Data.TabIndex = 0;
            this.dgv_Data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellValueChanged);
            // 
            // Information
            // 
            this.Information.Controls.Add(this.lbl_error);
            this.Information.Controls.Add(this.txt_error);
            this.Information.Controls.Add(this.lbl_FilePath);
            this.Information.Controls.Add(this.txt_FilePath);
            this.Information.Location = new System.Drawing.Point(4, 28);
            this.Information.Name = "Information";
            this.Information.Padding = new System.Windows.Forms.Padding(3);
            this.Information.Size = new System.Drawing.Size(648, 394);
            this.Information.TabIndex = 1;
            this.Information.Text = "Information";
            this.Information.UseVisualStyleBackColor = true;
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.Location = new System.Drawing.Point(6, 88);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(49, 18);
            this.lbl_error.TabIndex = 9;
            this.lbl_error.Text = "Error:";
            // 
            // txt_error
            // 
            this.txt_error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_error.Location = new System.Drawing.Point(9, 109);
            this.txt_error.Multiline = true;
            this.txt_error.Name = "txt_error";
            this.txt_error.Size = new System.Drawing.Size(633, 266);
            this.txt_error.TabIndex = 8;
            // 
            // lbl_FilePath
            // 
            this.lbl_FilePath.AutoSize = true;
            this.lbl_FilePath.Location = new System.Drawing.Point(6, 3);
            this.lbl_FilePath.Name = "lbl_FilePath";
            this.lbl_FilePath.Size = new System.Drawing.Size(75, 18);
            this.lbl_FilePath.TabIndex = 7;
            this.lbl_FilePath.Text = "File Path:";
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FilePath.Location = new System.Drawing.Point(9, 24);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(633, 29);
            this.txt_FilePath.TabIndex = 6;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Exit.Font = new System.Drawing.Font("新細明體", 12F);
            this.btn_Exit.Location = new System.Drawing.Point(688, 352);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 76);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Save.Font = new System.Drawing.Font("新細明體", 12F);
            this.btn_Save.Location = new System.Drawing.Point(688, 252);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 76);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.tab_Main);
            this.Name = "Form1";
            this.Text = "USBModify";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tab_Main.ResumeLayout(false);
            this.UserMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.Information.ResumeLayout(false);
            this.Information.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage UserMode;
        private System.Windows.Forms.TabPage Information;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label lbl_FilePath;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.TextBox txt_error;
    }
}

