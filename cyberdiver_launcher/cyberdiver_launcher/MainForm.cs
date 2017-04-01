/*
 * Created by SharpDevelop.
 * User: Michael
 * Date: 10/31/2013
 * Time: 4:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace cyberdiver_launcher
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string cyberdiver_version = "missingno";
			
			if (System.Diagnostics.Debugger.IsAttached)
			{
				cyberdiver_version = "Test Version";
			}
			else
			{
				cyberdiver_version = "1.2";
			}
			
			string cyberdiver_buildnumber = Application.ProductVersion;
			
			if (System.Diagnostics.Debugger.IsAttached)
			{
				if (File.Exists("cyberdiver_version_debug.txt"))
				{
        			string line1;
					using(StreamReader reader = new StreamReader("cyberdiver_version_debug.txt")) 
					{
    					line1 = reader.ReadLine();
					}
					cyberdiver_version = line1;
				}
				else
				{
					string[] lines = { cyberdiver_version };
        			File.WriteAllLines("cyberdiver_version_debug.txt", lines);
        			string line1;
					using(StreamReader reader = new StreamReader("cyberdiver_version_debug.txt")) 
					{
    					line1 = reader.ReadLine();
					}
					cyberdiver_version = line1;
				}
			}
			else
			{
				if (File.Exists("cyberdiver_version.txt"))
				{
					string line1;
					using(StreamReader reader = new StreamReader("cyberdiver_version.txt")) 
					{
    					line1 = reader.ReadLine();
					}
					cyberdiver_version = line1;
				}
				else
				{
					string[] lines = { cyberdiver_version };
        			File.WriteAllLines("cyberdiver_version.txt", lines);
        			string line1;
					using(StreamReader reader = new StreamReader("cyberdiver_version.txt")) 
					{
    					line1 = reader.ReadLine();
					}
					cyberdiver_version = line1;
				}
			}
			
			label7.Text = "Launcher Version: " + cyberdiver_version;
			label8.Text = "Build Number: " + cyberdiver_buildnumber;
			this.Text = "CyberDiver Launcher - Version: " + cyberdiver_version;
			
			if (File.Exists("cyberdiver_config.txt"))
			{
				string config_line1, config_line2, config_line3, config_line4, config_line5, config_line6, config_line7, config_line8;

				using(StreamReader reader = new StreamReader("cyberdiver_config.txt")) 
				{
    				config_line1 = reader.ReadLine();
    				config_line2 = reader.ReadLine();
    				config_line3 = reader.ReadLine();
    				config_line4 = reader.ReadLine();
    				config_line5 = reader.ReadLine();
    				config_line6 = reader.ReadLine();
    				config_line7 = reader.ReadLine();
    				config_line8 = reader.ReadLine();
				}
					
				Boolean bline5 = bool.Parse(config_line5);
				Boolean bline6 = bool.Parse(config_line6);
				Boolean bline7 = bool.Parse(config_line7);
				Boolean bline8 = bool.Parse(config_line8);
			
				textBox1.Text = config_line1;
				textBox2.Text = config_line2;
				textBox3.Text = config_line3;
				textBox4.Text = config_line4;
				checkBox1.Checked = bline5;
				checkBox2.Checked = bline6;
				checkBox3.Checked = bline7;
				checkBox5.Checked = bline8;
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			string[] lines = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked.ToString(), checkBox2.Checked.ToString(), checkBox3.Checked.ToString(), checkBox5.Checked.ToString() };
        	File.WriteAllLines("cyberdiver_config.txt", lines);
			
			if (checkBox1.Checked == false)
			{
				System.Diagnostics.Process.Start("hl2.exe", "-sw -game bs09 -width " + textBox2.Text + " -height " + textBox3.Text + " -ac -english -dxlevel 90 -nesys 0");
			}
			else if (checkBox2.Checked == false)
			{
				System.Diagnostics.Process.Start("hl2.exe", "-sw -game bs09 -heapsize " + textBox1.Text + " -width " + textBox2.Text + " -height " + textBox3.Text + " -english -dxlevel 90 -nesys 0");
			}
			else if (checkBox3.Checked == false)
			{
				System.Diagnostics.Process.Start("hl2.exe", "-sw -game bs09 -heapsize " + textBox1.Text + " -width " + textBox2.Text + " -height " + textBox3.Text + " -ac -english -dxlevel 90 -nesys 0");
			}
			else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked == false)
			{
				System.Diagnostics.Process.Start("hl2.exe", "-sw -game bs09 -width " + textBox2.Text + " -height " + textBox3.Text + " -english -dxlevel 90 -nesys 0");
			}
			else
			{
				System.Diagnostics.Process.Start("hl2.exe", "-sw -game bs09 -heapsize " + textBox1.Text + " -width " + textBox2.Text + " -height " + textBox3.Text + " -ac -english -nesys 0 " + textBox4.Text);
			}
			
			if (checkBox5.Checked == true)
			{
				this.Close();
			}
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == false)
			{
				textBox1.Enabled = false;
			}
			else
			{
				textBox1.Enabled = true;
			}
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == false)
			{
				textBox4.Enabled = false;
			}
			else
			{
				textBox4.Enabled = true;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
        	InstructionsForm btnFm1 = new InstructionsForm();
			btnFm1.Show();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			InstructionsGameForm btnFm2 = new InstructionsGameForm();
			btnFm2.Show();
		}
	}
}
