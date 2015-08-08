namespace Учет_газового_оборудования
{
    partial class find_form
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
            this.txtNameF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chN = new System.Windows.Forms.CheckBox();
            this.chF = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFamiliyaF = new System.Windows.Forms.TextBox();
            this.chO = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOtchestvoF = new System.Windows.Forms.TextBox();
            this.chNasele = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNaselenPunktF = new System.Windows.Forms.TextBox();
            this.chUlica = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUlicaF = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(621, 39);
            this.button1.TabIndex = 11;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNameF
            // 
            this.txtNameF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameF.Location = new System.Drawing.Point(51, 33);
            this.txtNameF.Name = "txtNameF";
            this.txtNameF.Size = new System.Drawing.Size(561, 22);
            this.txtNameF.TabIndex = 2;
            this.txtNameF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamiliyaF_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя";
            // 
            // chN
            // 
            this.chN.AutoSize = true;
            this.chN.Location = new System.Drawing.Point(618, 38);
            this.chN.Name = "chN";
            this.chN.Size = new System.Drawing.Size(15, 14);
            this.chN.TabIndex = 7;
            this.chN.UseVisualStyleBackColor = true;
            // 
            // chF
            // 
            this.chF.AutoSize = true;
            this.chF.Location = new System.Drawing.Point(618, 10);
            this.chF.Name = "chF";
            this.chF.Size = new System.Drawing.Size(15, 14);
            this.chF.TabIndex = 6;
            this.chF.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Фамилия";
            // 
            // txtFamiliyaF
            // 
            this.txtFamiliyaF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFamiliyaF.Location = new System.Drawing.Point(81, 5);
            this.txtFamiliyaF.Name = "txtFamiliyaF";
            this.txtFamiliyaF.Size = new System.Drawing.Size(531, 22);
            this.txtFamiliyaF.TabIndex = 1;
            this.txtFamiliyaF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamiliyaF_KeyPress);
            // 
            // chO
            // 
            this.chO.AutoSize = true;
            this.chO.Location = new System.Drawing.Point(618, 69);
            this.chO.Name = "chO";
            this.chO.Size = new System.Drawing.Size(15, 14);
            this.chO.TabIndex = 8;
            this.chO.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Отчество";
            // 
            // txtOtchestvoF
            // 
            this.txtOtchestvoF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtchestvoF.Location = new System.Drawing.Point(81, 64);
            this.txtOtchestvoF.Name = "txtOtchestvoF";
            this.txtOtchestvoF.Size = new System.Drawing.Size(531, 22);
            this.txtOtchestvoF.TabIndex = 3;
            this.txtOtchestvoF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamiliyaF_KeyPress);
            // 
            // chNasele
            // 
            this.chNasele.AutoSize = true;
            this.chNasele.Location = new System.Drawing.Point(618, 97);
            this.chNasele.Name = "chNasele";
            this.chNasele.Size = new System.Drawing.Size(15, 14);
            this.chNasele.TabIndex = 9;
            this.chNasele.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Населенный пункт";
            // 
            // txtNaselenPunktF
            // 
            this.txtNaselenPunktF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNaselenPunktF.Location = new System.Drawing.Point(136, 92);
            this.txtNaselenPunktF.Name = "txtNaselenPunktF";
            this.txtNaselenPunktF.Size = new System.Drawing.Size(476, 22);
            this.txtNaselenPunktF.TabIndex = 4;
            this.txtNaselenPunktF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamiliyaF_KeyPress);
            // 
            // chUlica
            // 
            this.chUlica.AutoSize = true;
            this.chUlica.Location = new System.Drawing.Point(618, 125);
            this.chUlica.Name = "chUlica";
            this.chUlica.Size = new System.Drawing.Size(15, 14);
            this.chUlica.TabIndex = 10;
            this.chUlica.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Улица";
            // 
            // txtUlicaF
            // 
            this.txtUlicaF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUlicaF.Location = new System.Drawing.Point(60, 120);
            this.txtUlicaF.Name = "txtUlicaF";
            this.txtUlicaF.Size = new System.Drawing.Size(552, 22);
            this.txtUlicaF.TabIndex = 5;
            this.txtUlicaF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamiliyaF_KeyPress);
            // 
            // find_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 224);
            this.Controls.Add(this.chUlica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUlicaF);
            this.Controls.Add(this.chNasele);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNaselenPunktF);
            this.Controls.Add(this.chO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOtchestvoF);
            this.Controls.Add(this.chF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFamiliyaF);
            this.Controls.Add(this.chN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameF);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "find_form";
            this.Text = "Учет газового оборудования - Поиск";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.find_form_FormClosing);
            this.Load += new System.EventHandler(this.find_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNameF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chN;
        private System.Windows.Forms.CheckBox chF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFamiliyaF;
        private System.Windows.Forms.CheckBox chO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOtchestvoF;
        private System.Windows.Forms.CheckBox chNasele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNaselenPunktF;
        private System.Windows.Forms.CheckBox chUlica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUlicaF;
    }
}