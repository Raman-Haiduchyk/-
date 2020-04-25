using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Edit
{
    public partial class EditorForm : Form
    {

        private Model Data;
               
        bool isRendering = false;

        public EditorForm()
        {
            InitializeComponent();
            Data = new Model();
            Control.penColor = penColorDialog.Color;
            Control.brushColor = brushColorDialog.Color;
            penColorBtn.BackColor = Control.penColor;
            brushColorBtn.BackColor = Control.brushColor;
            Control.ListInitialization(Data);
            // получение списка всех классов для рисования
            Data.Types = new List<Type>(Assembling.ReflectiveEnumerator.GetEnumerableOfType<Figure>(Assembly.GetExecutingAssembly()));
            Data.SortTypesWithName();
            foreach (Type T in Data.Types)
            {
                instrumentBox.Items.Add(T.Name);
            }
            instrumentBox.SelectedIndex = 0;
            foreach (Figure F in Data.Figures)
                figureList.Items.Add(F.Name);

            pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);

            void pictureBox_MouseWheel(object sender, MouseEventArgs e)
            {
                if (isRendering)
                    if (e.Delta > 0)
                    {
                        if (Control.Sides < 15)
                        {
                            Control.Sides++;
                            pictureBox.Invalidate();
                        }
                    }
                    else
                    {
                        if (Control.Sides > 3)
                        Control.Sides--;
                        pictureBox.Invalidate();
                    }
            }
        }

        // Обработка предварительной отрисовки

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Control.DrawFigureList(Data, e.Graphics);
            isRendering = Control.PreviewFigure(e.Graphics, instrumentBox.SelectedIndex, Data);
            if (!isRendering) 
            { 
                Control.DrawFigureList(Data, e.Graphics);
                if (figureList.Items.Count != Data.Figures.Count)
                {
                    figureList.Items.Clear();
                    foreach (Figure fig in Data.Figures)
                        figureList.Items.Add(fig.Name);
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control.OnMouseLeftClickEvent(isRendering, e.Location);
                pictureBox.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Control.OnMouseRightClickEvent(isRendering);
                pictureBox.Invalidate();
            }            
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Control.OnMouseDoubleClickEvent(isRendering, e.Location, instrumentBox.SelectedIndex, Data);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Control.OnMouseMoveEvent(isRendering, e.Location);
            pictureBox.Invalidate();
        }

        // настройка цветов
        private void penColorBtn_Click(object sender, EventArgs e)
        {
            if (penColorDialog.ShowDialog() == DialogResult.OK)
            Control.penColor = penColorDialog.Color;
            penColorBtn.BackColor = Control.penColor;
        }

        private void brushColorBtn_Click(object sender, EventArgs e)
        {
            if (brushColorDialog.ShowDialog() == DialogResult.OK)
            Control.brushColor = brushColorDialog.Color;
            brushColorBtn.BackColor = Control.brushColor;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (figureList.SelectedIndex != -1)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                string filename = saveFileDialog.FileName;
                if (!Serialization.SaveFigure(filename, figureList.SelectedIndex, Data))
                    MessageBox.Show("Ошибка");
            }
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog.FileName;
            if (!Serialization.LoadFigure(Data, filename))
                MessageBox.Show("Ошибка");
        }

        //выбор инструмента рисования
        private void instrumentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control.OnBoxChangeEvent(instrumentBox.SelectedIndex, Data);
        }

        private void saveListBtn_Click(object sender, EventArgs e)
        {
                
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel) return;
           
            
            for(int i = 0; i < Data.Figures.Count; i++)
            {
                Figure fig = Data.Figures[i];
                string filename = folderBrowserDialog.SelectedPath + "\\" + fig.Name + ".dat";
                MessageBox.Show(filename);
                if (!Serialization.SaveFigure(filename, i, Data))
                    MessageBox.Show($"Ошибка : не удалось сохранить {fig.Name}");
            }
        }
    }
}
