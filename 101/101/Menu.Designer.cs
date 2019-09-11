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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.Button_StartGame = new System.Windows.Forms.Button();
            this.Button_Rules = new System.Windows.Forms.Button();
            this.Button_Statistics = new System.Windows.Forms.Button();
            this.Label_Text_Of_Rules = new System.Windows.Forms.Label();
            this.Label_Rules_Head = new System.Windows.Forms.Label();
            this.Button_Close_Rules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(211, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 145);
            this.label1.TabIndex = 0;
            this.label1.Text = "101";
            // 
            // Button_StartGame
            // 
            this.Button_StartGame.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_StartGame.Location = new System.Drawing.Point(212, 423);
            this.Button_StartGame.Name = "Button_StartGame";
            this.Button_StartGame.Size = new System.Drawing.Size(259, 50);
            this.Button_StartGame.TabIndex = 1;
            this.Button_StartGame.Text = "Начать игру";
            this.Button_StartGame.UseVisualStyleBackColor = true;
            this.Button_StartGame.Click += new System.EventHandler(this.Button_StartGame_Click);
            // 
            // Button_Rules
            // 
            this.Button_Rules.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_Rules.Location = new System.Drawing.Point(212, 479);
            this.Button_Rules.Name = "Button_Rules";
            this.Button_Rules.Size = new System.Drawing.Size(259, 50);
            this.Button_Rules.TabIndex = 2;
            this.Button_Rules.Text = "Правила";
            this.Button_Rules.UseVisualStyleBackColor = true;
            this.Button_Rules.Click += new System.EventHandler(this.Button_Rules_Click);
            // 
            // Button_Statistics
            // 
            this.Button_Statistics.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_Statistics.Location = new System.Drawing.Point(212, 535);
            this.Button_Statistics.Name = "Button_Statistics";
            this.Button_Statistics.Size = new System.Drawing.Size(259, 50);
            this.Button_Statistics.TabIndex = 3;
            this.Button_Statistics.Text = "Статистика";
            this.Button_Statistics.UseVisualStyleBackColor = true;
            this.Button_Statistics.Click += new System.EventHandler(this.Button_Statistics_Click);
            // 
            // Label_Text_Of_Rules
            // 
            this.Label_Text_Of_Rules.BackColor = System.Drawing.Color.Transparent;
            this.Label_Text_Of_Rules.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Text_Of_Rules.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Text_Of_Rules.Location = new System.Drawing.Point(23, 73);
            this.Label_Text_Of_Rules.Name = "Label_Text_Of_Rules";
            this.Label_Text_Of_Rules.Size = new System.Drawing.Size(617, 716);
            this.Label_Text_Of_Rules.TabIndex = 4;
            this.Label_Text_Of_Rules.Text = resources.GetString("Label_Text_Of_Rules.Text");
            this.Label_Text_Of_Rules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Text_Of_Rules.Visible = false;
            // 
            // Label_Rules_Head
            // 
            this.Label_Rules_Head.AutoSize = true;
            this.Label_Rules_Head.BackColor = System.Drawing.Color.Transparent;
            this.Label_Rules_Head.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Rules_Head.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_Rules_Head.Location = new System.Drawing.Point(245, 25);
            this.Label_Rules_Head.Name = "Label_Rules_Head";
            this.Label_Rules_Head.Size = new System.Drawing.Size(177, 48);
            this.Label_Rules_Head.TabIndex = 5;
            this.Label_Rules_Head.Text = "Правила";
            this.Label_Rules_Head.Visible = false;
            // 
            // Button_Close_Rules
            // 
            this.Button_Close_Rules.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_Close_Rules.Location = new System.Drawing.Point(212, 783);
            this.Button_Close_Rules.Name = "Button_Close_Rules";
            this.Button_Close_Rules.Size = new System.Drawing.Size(248, 49);
            this.Button_Close_Rules.TabIndex = 6;
            this.Button_Close_Rules.Text = "В главное меню";
            this.Button_Close_Rules.UseVisualStyleBackColor = true;
            this.Button_Close_Rules.Visible = false;
            this.Button_Close_Rules.Click += new System.EventHandler(this.Button_Close_Rules_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_101.Properties.Resources.green;
            this.ClientSize = new System.Drawing.Size(662, 853);
            this.Controls.Add(this.Button_Close_Rules);
            this.Controls.Add(this.Label_Rules_Head);
            this.Controls.Add(this.Label_Text_Of_Rules);
            this.Controls.Add(this.Button_Statistics);
            this.Controls.Add(this.Button_Rules);
            this.Controls.Add(this.Button_StartGame);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_StartGame;
        private System.Windows.Forms.Button Button_Rules;
        private System.Windows.Forms.Button Button_Statistics;
        private System.Windows.Forms.Label Label_Text_Of_Rules;
        private System.Windows.Forms.Label Label_Rules_Head;
        private System.Windows.Forms.Button Button_Close_Rules;
    }
}