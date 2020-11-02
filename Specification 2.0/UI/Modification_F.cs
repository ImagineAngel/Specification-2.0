using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Specification_2._0
{
    public partial class Modification_F : Form
    {
        public Modification_F(bool isUpdate)
        {
            InitializeComponent();
            IsUpdate = isUpdate;
        }

        private bool IsUpdate;

        private void Modification_F_Load(object sender, EventArgs e)
        {
            if(IsUpdate)
            {
                this.Text = "Изменение данных";
                Header_L.Text = "Изменение данных";
            }
            else
            {
                this.Text = "Добавление данных";
                Header_L.Text = "Добавление данных";
            }
        }

        private void Modification_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if (Height_TB.Text.Trim() == "")
                    {
                        Height_TB.Focus();
                        throw new Exception("Вы не ввели рост бегуна");
                    }

                    if (Weight_TB.Text.Trim() == "")
                    {
                        Weight_TB.Focus();
                        throw new Exception("Вы не ввели вес бегуна");
                    }

                    if (Age_TB.Text.Trim() == "")
                    {
                        Age_TB.Focus();
                        throw new Exception("Вы не ввели возраст бегуна");
                    }

                    if (Name_TB.Text.Trim() == "")
                    {
                        Name_TB.Focus();
                        throw new Exception("Вы не ввели имя бегуна");
                    }

                    if (Surname_TB.Text.Trim() == "")
                    {
                        Surname_TB.Focus();
                        throw new Exception("Вы не ввели фамилию бегуна");
                    }

                    if (Ranked_TB.Text.Trim() == "")
                    {
                        Ranked_TB.Focus();
                        throw new Exception("Вы не ввели занятое место бегуном");
                    }

                    int R = Convert.ToInt32(Ranked_TB.Text);

                    if (R < 1 || R > 3)
                    {
                        Ranked_TB.Focus();
                        throw new Exception("Занятое место на олимпиаде должно находиться в диапазоне 1...3");
                    }
                }
                catch (FormatException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Введен неверный формат", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception Ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(Ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }       
    } 
}
