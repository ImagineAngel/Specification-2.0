using Specification_2._0.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Specification_2._0
{
    public partial class Main_F : Form
    {
        public Main_F()
        {
            InitializeComponent();            
        }

        private Data.ApplicationContext context;
        private BindingList<Runner> Runners;         

        private void InitializeBindingListOfRunners()   
        {
            Runners = new BindingList<Runner>(context.Runners.ToList());
           
            Spisok_LB.DataSource = Runners;                      
        }

        private void Main_F_Load(object sender, EventArgs e)
        {
            try
            {
                context = new Data.ApplicationContext();

                InitializeBindingListOfRunners();

                if (Spisok_LB.Items.Count > 0)
                {
                    StateButton(true);
                }
                else
                {
                    StateButton(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            try
            {
                Modification_F modification = new Modification_F(true);

                if (modification.ShowDialog() == DialogResult.OK)
                {
                    Runner runnerDB = new Runner
                    {
                        Height = Convert.ToDouble(modification.Height_TB.Text.Trim()),                       
                        Weight = Convert.ToDouble(modification.Weight_TB.Text.Trim()),
                        Age = Convert.ToInt32(modification.Age_TB.Text.Trim()),
                        Name = modification.Name_TB.Text.Trim(),
                        Surname = modification.Surname_TB.Text.Trim(),
                        Ranked = Convert.ToInt32(modification.Ranked_TB.Text.Trim()),
                    };
                    context.Runners.Add(runnerDB);
                    context.SaveChanges();

                    Runners.Add(runnerDB);                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Update_B_Click(object sender, EventArgs e)
        {
            try
            {
                Modification_F modification = new Modification_F(false);

                Runner runnerDB = Spisok_LB.SelectedItem as Runner;

                if (runnerDB == null)
                {
                    throw new Exception("Необходимо выбрать объект");
                }

                modification.Height_TB.Text = runnerDB.Height.ToString();
                modification.Weight_TB.Text = runnerDB.Weight.ToString();
                modification.Age_TB.Text = runnerDB.Age.ToString();
                modification.Name_TB.Text = runnerDB.Name;
                modification.Surname_TB.Text = runnerDB.Surname;
                modification.Ranked_TB.Text = runnerDB.Ranked.ToString();

                if (modification.ShowDialog() == DialogResult.OK)
                {                 
                    Runner runnerContext = Spisok_LB.SelectedItem as Runner;

                    runnerContext.Height = Convert.ToDouble(modification.Height_TB.Text.Trim());
                    runnerContext.Weight = Convert.ToDouble(modification.Weight_TB.Text.Trim());
                    runnerContext.Age = Convert.ToInt32(modification.Age_TB.Text.Trim());
                    runnerContext.Name = modification.Name_TB.Text.Trim();
                    runnerContext.Surname = modification.Surname_TB.Text.Trim();
                    runnerContext.Ranked = Convert.ToInt32(modification.Ranked_TB.Text.Trim());

                    context.SaveChanges();

                    Runners.Remove(runnerDB);
                    Runners.Add(runnerContext);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Runner runnerDB = Spisok_LB.SelectedItem as Runner;

                    if (runnerDB == null)
                    {
                        throw new Exception("Необходимо выбрать объект");
                    } 

                    context.Runners.Remove(runnerDB);
                    context.SaveChanges();

                    Runners.Remove(runnerDB);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Exit_B_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Spisok_LB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Spisok_LB.SelectedItem != null) 
            {
                Runner runnerDB = Spisok_LB.SelectedItem as Runner;

                if (runnerDB != null)
                {
                    Height_TB.Text = runnerDB.Height.ToString();
                    Weight_TB.Text = runnerDB.Weight.ToString();
                    Age_TB.Text = runnerDB.Age.ToString();
                    Name_TB.Text = runnerDB.Name;
                    Surname_TB.Text = runnerDB.Surname;
                    Ranked_TB.Text = runnerDB.Ranked.ToString();
                }

                StateButton(true);
            }
            else
            {
                Height_TB.Clear();
                Weight_TB.Clear();
                Age_TB.Clear();
                Name_TB.Clear();
                Surname_TB.Clear();
                Ranked_TB.Clear();

                StateButton(false);
            }
        }

        private void Main_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    context.SaveChanges();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StateButton(bool state)
        {
            Update_B.Enabled = state;
            Delete_B.Enabled = state;
        }    
    }
}
