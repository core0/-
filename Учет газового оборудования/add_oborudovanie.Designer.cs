namespace Учет_газового_оборудования
{
    partial class Form3_add_oborudovanie
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameEq = new System.Windows.Forms.TextBox();
            this.txtTypeEq = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateOfProduction = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfLastTO = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfNextTO = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Учет_газового_оборудования.Properties.Resources.dialog_block;
            this.btnCancel.Location = new System.Drawing.Point(597, 127);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::Учет_газового_оборудования.Properties.Resources.dialog_apply;
            this.btnOk.Location = new System.Drawing.Point(10, 127);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 41);
            this.btnOk.TabIndex = 6;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Название";
            // 
            // txtNameEq
            // 
            this.txtNameEq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameEq.Location = new System.Drawing.Point(83, 6);
            this.txtNameEq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameEq.Name = "txtNameEq";
            this.txtNameEq.Size = new System.Drawing.Size(385, 22);
            this.txtNameEq.TabIndex = 1;
            // 
            // txtTypeEq
            // 
            this.txtTypeEq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeEq.Location = new System.Drawing.Point(508, 6);
            this.txtTypeEq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTypeEq.Name = "txtTypeEq";
            this.txtTypeEq.Size = new System.Drawing.Size(176, 22);
            this.txtTypeEq.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Дата производства";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Дата последнего ТО";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Дата следующего ТО";
            // 
            // dtpDateOfProduction
            // 
            this.dtpDateOfProduction.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfProduction.Location = new System.Drawing.Point(140, 39);
            this.dtpDateOfProduction.Name = "dtpDateOfProduction";
            this.dtpDateOfProduction.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOfProduction.TabIndex = 3;
            // 
            // dtpDateOfLastTO
            // 
            this.dtpDateOfLastTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfLastTO.Location = new System.Drawing.Point(484, 39);
            this.dtpDateOfLastTO.Name = "dtpDateOfLastTO";
            this.dtpDateOfLastTO.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOfLastTO.TabIndex = 4;
            this.dtpDateOfLastTO.CloseUp += new System.EventHandler(this.dtpDateOfLastTO_CloseUp);
            // 
            // dtpDateOfNextTO
            // 
            this.dtpDateOfNextTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfNextTO.Location = new System.Drawing.Point(155, 71);
            this.dtpDateOfNextTO.Name = "dtpDateOfNextTO";
            this.dtpDateOfNextTO.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOfNextTO.TabIndex = 5;
            // 
            // Form3_add_oborudovanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 182);
            this.Controls.Add(this.dtpDateOfNextTO);
            this.Controls.Add(this.dtpDateOfLastTO);
            this.Controls.Add(this.dtpDateOfProduction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTypeEq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameEq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3_add_oborudovanie";
            this.Text = "Учет газового оборудования - Добавить оборудование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_add_oborudovanie_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Form3_add_oborudovanie_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameEq;
        private System.Windows.Forms.TextBox txtTypeEq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDateOfProduction;
        private System.Windows.Forms.DateTimePicker dtpDateOfLastTO;
        private System.Windows.Forms.DateTimePicker dtpDateOfNextTO;
    }
}