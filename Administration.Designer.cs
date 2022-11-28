namespace TestApplicationShulte
{
    partial class Administration
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DB_update = new System.Windows.Forms.Button();
            this.test_bdDataSet = new TestApplicationShulte.test_bdDataSet();
            this.testbdDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Stat_all = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.npgsqlCommand1 = new Npgsql.NpgsqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_bdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testbdDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(813, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(38, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Получить данные пользователей";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(244, 349);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(607, 227);
            this.dataGridView2.TabIndex = 2;
            // 
            // DB_update
            // 
            this.DB_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DB_update.Location = new System.Drawing.Point(244, 262);
            this.DB_update.Name = "DB_update";
            this.DB_update.Size = new System.Drawing.Size(187, 35);
            this.DB_update.TabIndex = 3;
            this.DB_update.Text = "Обновить базу данных";
            this.DB_update.UseVisualStyleBackColor = true;
            this.DB_update.Click += new System.EventHandler(this.DB_update_Click);
            // 
            // test_bdDataSet
            // 
            this.test_bdDataSet.DataSetName = "test_bdDataSet";
            this.test_bdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testbdDataSetBindingSource
            // 
            this.testbdDataSetBindingSource.DataSource = this.test_bdDataSet;
            this.testbdDataSetBindingSource.Position = 0;
            // 
            // Stat_all
            // 
            this.Stat_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Stat_all.Location = new System.Drawing.Point(38, 531);
            this.Stat_all.Name = "Stat_all";
            this.Stat_all.Size = new System.Drawing.Size(162, 45);
            this.Stat_all.TabIndex = 5;
            this.Stat_all.Text = "Получить всю статистику";
            this.Stat_all.UseVisualStyleBackColor = true;
            this.Stat_all.Click += new System.EventHandler(this.Stat_all_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button3.Location = new System.Drawing.Point(38, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "Получить статистику по пользователю";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(38, 379);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 26);
            this.textBox2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(35, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Id пользователя";
            // 
            // npgsqlCommand1
            // 
            this.npgsqlCommand1.AllResultTypesAreUnknown = false;
            this.npgsqlCommand1.Transaction = null;
            this.npgsqlCommand1.UnknownResultTypeList = null;
            // 
            // Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 597);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Stat_all);
            this.Controls.Add(this.DB_update);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Administration";
            this.Text = "Administration";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_bdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testbdDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button DB_update;
        private test_bdDataSet test_bdDataSet;
        private System.Windows.Forms.BindingSource testbdDataSetBindingSource;
        private System.Windows.Forms.Button Stat_all;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private Npgsql.NpgsqlCommand npgsqlCommand1;
    }
}