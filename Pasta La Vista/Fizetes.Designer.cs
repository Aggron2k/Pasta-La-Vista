namespace Pasta_La_Vista
{
    partial class Fizetes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.torles = new System.Windows.Forms.Button();
            this.modositas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fizetendo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.poszt = new System.Windows.Forms.TextBox();
            this.tartalomtorles = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.fizetett = new System.Windows.Forms.ComboBox();
            this.tipus = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pFseged1 = new Pasta_La_Vista.PFseged();
            this.label6 = new System.Windows.Forms.Label();
            this.kereses = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // torles
            // 
            this.torles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.torles.ForeColor = System.Drawing.Color.Red;
            this.torles.Location = new System.Drawing.Point(148, 502);
            this.torles.Name = "torles";
            this.torles.Size = new System.Drawing.Size(115, 35);
            this.torles.TabIndex = 30;
            this.torles.Text = "Fizetés törlése";
            this.torles.UseVisualStyleBackColor = true;
            // 
            // modositas
            // 
            this.modositas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modositas.Location = new System.Drawing.Point(27, 502);
            this.modositas.Name = "modositas";
            this.modositas.Size = new System.Drawing.Size(115, 35);
            this.modositas.TabIndex = 29;
            this.modositas.Text = "Modosítás";
            this.modositas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fízetés típus:";
            // 
            // fizetendo
            // 
            this.fizetendo.Location = new System.Drawing.Point(27, 309);
            this.fizetendo.Name = "fizetendo";
            this.fizetendo.Size = new System.Drawing.Size(236, 23);
            this.fizetendo.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Fizetendő:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Rendelés adatai:";
            // 
            // poszt
            // 
            this.poszt.Location = new System.Drawing.Point(27, 52);
            this.poszt.Multiline = true;
            this.poszt.Name = "poszt";
            this.poszt.Size = new System.Drawing.Size(412, 231);
            this.poszt.TabIndex = 34;
            // 
            // tartalomtorles
            // 
            this.tartalomtorles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tartalomtorles.Location = new System.Drawing.Point(308, 360);
            this.tartalomtorles.Name = "tartalomtorles";
            this.tartalomtorles.Size = new System.Drawing.Size(115, 35);
            this.tartalomtorles.TabIndex = 35;
            this.tartalomtorles.Text = "Tartalom törlése";
            this.tartalomtorles.UseVisualStyleBackColor = true;
            this.tartalomtorles.Click += new System.EventHandler(this.tartalomtorles_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(473, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(393, 254);
            this.dataGridView1.TabIndex = 69;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Fizetett-e:";
            // 
            // fizetett
            // 
            this.fizetett.FormattingEnabled = true;
            this.fizetett.Location = new System.Drawing.Point(27, 432);
            this.fizetett.Name = "fizetett";
            this.fizetett.Size = new System.Drawing.Size(236, 23);
            this.fizetett.TabIndex = 71;
            // 
            // tipus
            // 
            this.tipus.FormattingEnabled = true;
            this.tipus.Location = new System.Drawing.Point(27, 372);
            this.tipus.Name = "tipus";
            this.tipus.Size = new System.Drawing.Size(236, 23);
            this.tipus.TabIndex = 72;
            // 
            // pFseged1
            // 
            this.pFseged1.Location = new System.Drawing.Point(897, 93);
            this.pFseged1.Name = "pFseged1";
            this.pFseged1.Size = new System.Drawing.Size(885, 598);
            this.pFseged1.TabIndex = 73;
            this.pFseged1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(679, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 75;
            this.label6.Text = "Rendelés keresés:";
            // 
            // kereses
            // 
            this.kereses.Location = new System.Drawing.Point(679, 25);
            this.kereses.Name = "kereses";
            this.kereses.Size = new System.Drawing.Size(187, 23);
            this.kereses.TabIndex = 74;
            this.kereses.TextChanged += new System.EventHandler(this.kereses_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(473, 322);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(393, 260);
            this.dataGridView2.TabIndex = 76;
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            // 
            // Fizetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kereses);
            this.Controls.Add(this.pFseged1);
            this.Controls.Add(this.tipus);
            this.Controls.Add(this.fizetett);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tartalomtorles);
            this.Controls.Add(this.poszt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.torles);
            this.Controls.Add(this.modositas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fizetendo);
            this.Controls.Add(this.label1);
            this.Name = "Fizetes";
            this.Size = new System.Drawing.Size(885, 598);
            this.Load += new System.EventHandler(this.Fizetes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button torles;
        private Button modositas;
        private Label label2;
        private TextBox fizetendo;
        private Label label1;
        private Label label4;
        private TextBox poszt;
        private Button tartalomtorles;
        private DataGridView dataGridView1;
        private Label label3;
        private ComboBox fizetett;
        private ComboBox tipus;
        private BindingSource bindingSource1;
        private PFseged pFseged1;
        private Label label6;
        private TextBox kereses;
        private DataGridView dataGridView2;
        private BindingSource bindingSource2;
    }
}
