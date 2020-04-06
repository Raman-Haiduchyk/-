﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            Data.Types = new List<Type>(Assembling.ReflectiveEnumerator.GetEnumerableOfType<Figure>());
            Data.SortTypesWithName();
            foreach (Type T in Data.Types)
            {
                instrumentBox.Items.Add(T.Name);
            }
            instrumentBox.SelectedIndex = 0;

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
            if (!isRendering) { Control.DrawFigureList(Data, e.Graphics); }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control.OnMouseLeftClickEvent(isRendering, e.Location, instrumentBox.SelectedIndex, Data);
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
    }
}
