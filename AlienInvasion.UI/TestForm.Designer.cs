namespace AlienInvasion.UI
{
	partial class TestForm
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
			this.ClearButton = new System.Windows.Forms.Button();
			this.AlienSizeComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AddAlienButton = new System.Windows.Forms.Button();
			this.AddWeaponButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.WeaponComboBox = new System.Windows.Forms.ComboBox();
			this.WeaponsToFireText = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.RunWaveButton = new System.Windows.Forms.Button();
			this.AliensList = new System.Windows.Forms.ListBox();
			this.WeaponsList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(383, 313);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(99, 25);
			this.ClearButton.TabIndex = 1;
			this.ClearButton.Text = "Clear All";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// AlienSizeComboBox
			// 
			this.AlienSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AlienSizeComboBox.FormattingEnabled = true;
			this.AlienSizeComboBox.Items.AddRange(new object[] {
            "Small",
            "Large",
            "Huge"});
			this.AlienSizeComboBox.Location = new System.Drawing.Point(76, 14);
			this.AlienSizeComboBox.Name = "AlienSizeComboBox";
			this.AlienSizeComboBox.Size = new System.Drawing.Size(134, 21);
			this.AlienSizeComboBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Alien Size";
			// 
			// AddAlienButton
			// 
			this.AddAlienButton.Location = new System.Drawing.Point(231, 10);
			this.AddAlienButton.Name = "AddAlienButton";
			this.AddAlienButton.Size = new System.Drawing.Size(102, 28);
			this.AddAlienButton.TabIndex = 4;
			this.AddAlienButton.Text = "Add Alien";
			this.AddAlienButton.UseVisualStyleBackColor = true;
			this.AddAlienButton.Click += new System.EventHandler(this.AddAlienButton_Click);
			// 
			// AddWeaponButton
			// 
			this.AddWeaponButton.Location = new System.Drawing.Point(610, 11);
			this.AddWeaponButton.Name = "AddWeaponButton";
			this.AddWeaponButton.Size = new System.Drawing.Size(102, 28);
			this.AddWeaponButton.TabIndex = 8;
			this.AddWeaponButton.Text = "Add Weapon";
			this.AddWeaponButton.UseVisualStyleBackColor = true;
			this.AddWeaponButton.Click += new System.EventHandler(this.AddWeaponButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(402, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Weapons";
			// 
			// WeaponComboBox
			// 
			this.WeaponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.WeaponComboBox.FormattingEnabled = true;
			this.WeaponComboBox.Items.AddRange(new object[] {
            "ObliteratorCannon",
            "Peashooter500Blaster",
            "Peashooter1000Blaster"});
			this.WeaponComboBox.Location = new System.Drawing.Point(461, 15);
			this.WeaponComboBox.Name = "WeaponComboBox";
			this.WeaponComboBox.Size = new System.Drawing.Size(134, 21);
			this.WeaponComboBox.TabIndex = 6;
			// 
			// WeaponsToFireText
			// 
			this.WeaponsToFireText.AcceptsReturn = true;
			this.WeaponsToFireText.Location = new System.Drawing.Point(12, 344);
			this.WeaponsToFireText.Multiline = true;
			this.WeaponsToFireText.Name = "WeaponsToFireText";
			this.WeaponsToFireText.Size = new System.Drawing.Size(739, 210);
			this.WeaponsToFireText.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 320);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Weapons to be fired (in order):";
			// 
			// RunWaveButton
			// 
			this.RunWaveButton.Location = new System.Drawing.Point(259, 314);
			this.RunWaveButton.Name = "RunWaveButton";
			this.RunWaveButton.Size = new System.Drawing.Size(103, 25);
			this.RunWaveButton.TabIndex = 11;
			this.RunWaveButton.Text = "Run Wave";
			this.RunWaveButton.UseVisualStyleBackColor = true;
			this.RunWaveButton.Click += new System.EventHandler(this.RunWaveButton_Click);
			// 
			// AliensList
			// 
			this.AliensList.FormattingEnabled = true;
			this.AliensList.Location = new System.Drawing.Point(18, 49);
			this.AliensList.Name = "AliensList";
			this.AliensList.Size = new System.Drawing.Size(343, 251);
			this.AliensList.TabIndex = 12;
			// 
			// WeaponsList
			// 
			this.WeaponsList.FormattingEnabled = true;
			this.WeaponsList.Location = new System.Drawing.Point(383, 49);
			this.WeaponsList.Name = "WeaponsList";
			this.WeaponsList.Size = new System.Drawing.Size(343, 251);
			this.WeaponsList.TabIndex = 13;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 564);
			this.Controls.Add(this.WeaponsList);
			this.Controls.Add(this.AliensList);
			this.Controls.Add(this.RunWaveButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.WeaponsToFireText);
			this.Controls.Add(this.AddWeaponButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.WeaponComboBox);
			this.Controls.Add(this.AddAlienButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AlienSizeComboBox);
			this.Controls.Add(this.ClearButton);
			this.Name = "TestForm";
			this.Text = "Alien Invasion Test UI";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.ComboBox AlienSizeComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button AddAlienButton;
		private System.Windows.Forms.Button AddWeaponButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox WeaponComboBox;
		private System.Windows.Forms.TextBox WeaponsToFireText;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button RunWaveButton;
		private System.Windows.Forms.ListBox AliensList;
		private System.Windows.Forms.ListBox WeaponsList;
	}
}

