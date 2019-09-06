namespace _101
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.Button_StartGame = new System.Windows.Forms.Button();
            this.Button_Rules = new System.Windows.Forms.Button();
            this.Button_Records = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(239, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 106);
            this.label1.TabIndex = 0;
            this.label1.Text = "101";
            // 
            // Button_StartGame
            // 
            this.Button_StartGame.Location = new System.Drawing.Point(238, 299);
            this.Button_StartGame.Name = "Button_StartGame";
            this.Button_StartGame.Size = new System.Drawing.Size(175, 33);
            this.Button_StartGame.TabIndex = 1;
            this.Button_StartGame.Text = "Начать игру";
            this.Button_StartGame.UseVisualStyleBackColor = true;
            this.Button_StartGame.Click += new System.EventHandler(this.Button_StartGame_Click);
            // 
            // Button_Rules
            // 
            this.Button_Rules.Location = new System.Drawing.Point(238, 337);
            this.Button_Rules.Name = "Button_Rules";
            this.Button_Rules.Size = new System.Drawing.Size(175, 33);
            this.Button_Rules.TabIndex = 2;
            this.Button_Rules.Text = "Правила";
            this.Button_Rules.UseVisualStyleBackColor = true;
            this.Button_Rules.Click += new System.EventHandler(this.Button_Rules_Click);
            // 
            // Button_Records
            // 
            this.Button_Records.Location = new System.Drawing.Point(238, 376);
            this.Button_Records.Name = "Button_Records";
            this.Button_Records.Size = new System.Drawing.Size(175, 36);
            this.Button_Records.TabIndex = 3;
            this.Button_Records.Text = "Рекорды";
            this.Button_Records.UseVisualStyleBackColor = true;
            this.Button_Records.Click += new System.EventHandler(this.Button_Records_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 853);
            this.Controls.Add(this.Button_Records);
            this.Controls.Add(this.Button_Rules);
            this.Controls.Add(this.Button_StartGame);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_StartGame;
        private System.Windows.Forms.Button Button_Rules;
        private System.Windows.Forms.Button Button_Records;
    }
}