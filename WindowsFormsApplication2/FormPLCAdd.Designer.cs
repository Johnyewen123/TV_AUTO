namespace WindowsFormsApplication2
{
    partial class FormPLCAdd
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btn_SaveXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(554, 534);
            this.propertyGrid1.TabIndex = 0;
            // 
            // btn_SaveXML
            // 
            this.btn_SaveXML.Location = new System.Drawing.Point(409, 12);
            this.btn_SaveXML.Name = "btn_SaveXML";
            this.btn_SaveXML.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveXML.TabIndex = 1;
            this.btn_SaveXML.Text = "savexmL";
            this.btn_SaveXML.UseVisualStyleBackColor = true;
            this.btn_SaveXML.Click += new System.EventHandler(this.btn_SaveXML_Click);
            // 
            // FormPLCAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 558);
            this.Controls.Add(this.btn_SaveXML);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "FormPLCAdd";
            this.Text = "PLC地址配置";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btn_SaveXML;

    }
}