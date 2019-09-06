namespace _101
{
    partial class GameField
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player_Button = new System.Windows.Forms.Button();
            this.button_clubs = new System.Windows.Forms.Button();
            this.button_diamonds = new System.Windows.Forms.Button();
            this.button_hearts = new System.Windows.Forms.Button();
            this.button_spades = new System.Windows.Forms.Button();
            this.CurrentSuit_PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentSuit_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Player_Button
            // 
            this.Player_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Player_Button.Location = new System.Drawing.Point(445, 522);
            this.Player_Button.Name = "Player_Button";
            this.Player_Button.Size = new System.Drawing.Size(96, 37);
            this.Player_Button.TabIndex = 0;
            this.Player_Button.Text = "Старт";
            this.Player_Button.UseVisualStyleBackColor = true;
            this.Player_Button.Click += new System.EventHandler(this.Player_Button_Click);
            // 
            // button_clubs
            // 
            this.button_clubs.BackgroundImage = global::_101.Properties.Resources.clubs;
            this.button_clubs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_clubs.Location = new System.Drawing.Point(172, 480);
            this.button_clubs.Name = "button_clubs";
            this.button_clubs.Size = new System.Drawing.Size(75, 79);
            this.button_clubs.TabIndex = 1;
            this.button_clubs.Tag = "0";
            this.button_clubs.UseVisualStyleBackColor = true;
            this.button_clubs.Visible = false;
            this.button_clubs.Click += new System.EventHandler(this.Button_Suits_Click);
            // 
            // button_diamonds
            // 
            this.button_diamonds.BackgroundImage = global::_101.Properties.Resources.diamonds;
            this.button_diamonds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_diamonds.Location = new System.Drawing.Point(253, 480);
            this.button_diamonds.Name = "button_diamonds";
            this.button_diamonds.Size = new System.Drawing.Size(75, 79);
            this.button_diamonds.TabIndex = 2;
            this.button_diamonds.Tag = "1";
            this.button_diamonds.UseVisualStyleBackColor = true;
            this.button_diamonds.Visible = false;
            this.button_diamonds.Click += new System.EventHandler(this.Button_Suits_Click);
            // 
            // button_hearts
            // 
            this.button_hearts.BackgroundImage = global::_101.Properties.Resources.hearts;
            this.button_hearts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_hearts.Location = new System.Drawing.Point(334, 480);
            this.button_hearts.Name = "button_hearts";
            this.button_hearts.Size = new System.Drawing.Size(75, 79);
            this.button_hearts.TabIndex = 3;
            this.button_hearts.Tag = "2";
            this.button_hearts.UseVisualStyleBackColor = true;
            this.button_hearts.Visible = false;
            this.button_hearts.Click += new System.EventHandler(this.Button_Suits_Click);
            // 
            // button_spades
            // 
            this.button_spades.BackgroundImage = global::_101.Properties.Resources.spades;
            this.button_spades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_spades.Location = new System.Drawing.Point(415, 480);
            this.button_spades.Name = "button_spades";
            this.button_spades.Size = new System.Drawing.Size(75, 79);
            this.button_spades.TabIndex = 4;
            this.button_spades.Tag = "3";
            this.button_spades.UseVisualStyleBackColor = true;
            this.button_spades.Visible = false;
            this.button_spades.Click += new System.EventHandler(this.Button_Suits_Click);
            // 
            // CurrentSuit_PB
            // 
            this.CurrentSuit_PB.BackColor = System.Drawing.Color.Transparent;
            this.CurrentSuit_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CurrentSuit_PB.Location = new System.Drawing.Point(490, 391);
            this.CurrentSuit_PB.Name = "CurrentSuit_PB";
            this.CurrentSuit_PB.Size = new System.Drawing.Size(51, 49);
            this.CurrentSuit_PB.TabIndex = 5;
            this.CurrentSuit_PB.TabStop = false;
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_101.Properties.Resources.GameTable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(662, 853);
            this.Controls.Add(this.CurrentSuit_PB);
            this.Controls.Add(this.button_spades);
            this.Controls.Add(this.button_hearts);
            this.Controls.Add(this.button_diamonds);
            this.Controls.Add(this.button_clubs);
            this.Controls.Add(this.Player_Button);
            this.Name = "GameField";
            this.Text = "101";
            ((System.ComponentModel.ISupportInitialize)(this.CurrentSuit_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Player_Button;
        private System.Windows.Forms.Button button_clubs;
        private System.Windows.Forms.Button button_diamonds;
        private System.Windows.Forms.Button button_hearts;
        private System.Windows.Forms.Button button_spades;
        private System.Windows.Forms.PictureBox CurrentSuit_PB;
    }
}

