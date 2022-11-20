namespace Pasta_La_Vista
{
    partial class Ugyfel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.torles = new System.Windows.Forms.Button();
            this.modositas = new System.Windows.Forms.Button();
            this.felvezetes = new System.Windows.Forms.Button();
            this.tartalomtorles = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.kereses = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(289, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(566, 343);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ügyfél név:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 95);
            this.textBox1.MaxLength = 200;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 158);
            this.textBox2.MaxLength = 200;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(236, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(33, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ügyfél cím:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(33, 227);
            this.textBox3.MaxLength = 20;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(236, 23);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(33, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ügyfél telefon:";
            // 
            // torles
            // 
            this.torles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.torles.ForeColor = System.Drawing.Color.Red;
            this.torles.Location = new System.Drawing.Point(275, 502);
            this.torles.Name = "torles";
            this.torles.Size = new System.Drawing.Size(115, 35);
            this.torles.TabIndex = 16;
            this.torles.Text = "Törlés";
            this.torles.UseVisualStyleBackColor = true;
            this.torles.Click += new System.EventHandler(this.torles_Click);
            // 
            // modositas
            // 
            this.modositas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modositas.Location = new System.Drawing.Point(154, 502);
            this.modositas.Name = "modositas";
            this.modositas.Size = new System.Drawing.Size(115, 35);
            this.modositas.TabIndex = 15;
            this.modositas.Text = "Modosítás";
            this.modositas.UseVisualStyleBackColor = true;
            this.modositas.Click += new System.EventHandler(this.modositas_Click);
            // 
            // felvezetes
            // 
            this.felvezetes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.felvezetes.Location = new System.Drawing.Point(33, 502);
            this.felvezetes.Name = "felvezetes";
            this.felvezetes.Size = new System.Drawing.Size(115, 35);
            this.felvezetes.TabIndex = 14;
            this.felvezetes.Text = "Felvezetés";
            this.felvezetes.UseVisualStyleBackColor = true;
            this.felvezetes.Click += new System.EventHandler(this.felvezetes_Click);
            // 
            // tartalomtorles
            // 
            this.tartalomtorles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tartalomtorles.Location = new System.Drawing.Point(90, 278);
            this.tartalomtorles.Name = "tartalomtorles";
            this.tartalomtorles.Size = new System.Drawing.Size(115, 35);
            this.tartalomtorles.TabIndex = 18;
            this.tartalomtorles.Text = "Tartalom törlése";
            this.tartalomtorles.UseVisualStyleBackColor = true;
            this.tartalomtorles.Click += new System.EventHandler(this.tartalomtorles_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(668, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Keresés:";
            // 
            // kereses
            // 
            this.kereses.Location = new System.Drawing.Point(668, 42);
            this.kereses.Name = "kereses";
            this.kereses.Size = new System.Drawing.Size(187, 23);
            this.kereses.TabIndex = 19;
            this.kereses.TextChanged += new System.EventHandler(this.kereses_TextChanged);
            // 
            // Ugyfel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kereses);
            this.Controls.Add(this.tartalomtorles);
            this.Controls.Add(this.torles);
            this.Controls.Add(this.modositas);
            this.Controls.Add(this.felvezetes);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Ugyfel";
            this.Size = new System.Drawing.Size(885, 598);
            this.Load += new System.EventHandler(this.Ugyfel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Button torles;
        private Button modositas;
        private Button felvezetes;
        private Button tartalomtorles;
        private Label label6;
        private TextBox kereses;
    }
}
