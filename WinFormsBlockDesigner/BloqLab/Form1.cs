using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloqLab
{


    public partial class MainForm : Form
    {
        public Form2 newForm;
        public List<IBloq> list_of_blocks = new List<IBloq>();
        public List<RadioButton> list_of_radiobuttons = new List<RadioButton>();
        private bool containStart = false;
        private IBloq rightClickedBlock;
        Point mousePositionWhenClickedMiddleButton;
        Point rightClickedBlockPositionWhenClickedMiddleButton;
        bool middleButtonState;
        Point drawLinkStartPosition;
        bool leftButtonDrawingMode = false;
        bool ismoving = false;

        IBloq startBloqDrawingLine;



        public MainForm()
        {
            InitializeComponent();
        }

        private void NowySchematButton_Click(object sender, EventArgs e)
        {
            //to ze stacka
            newForm = new Form2();
            newForm.FormClosed += new FormClosedEventHandler(newForm_FormClosing);
            newForm.Show();
        }

        private void newForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            containStart = false;

            //https://stackoverflow.com/questions/2683679/how-to-know-user-has-clicked-x-or-the-close-button
            var form = sender as Form2;
            if (form.OkButtonState)
            {
                // Do something proper to CloseButton.
                MainPictureBox.Size = new Size(newForm.GetWidth, newForm.GetHeight);

                //https://stackoverflow.com/questions/5856196/clear-image-on-picturebox
                MainPictureBox.Image = null;
                list_of_blocks = new List<IBloq>();
                MainPictureBox.Invalidate();
                return;
            }
            else
            {
                // Then assume that X has been clicked and act accordingly.
                return;
            }

        }



        private void MainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            list_of_radiobuttons.Clear();
            list_of_radiobuttons.Add(StartRadioButton);
            list_of_radiobuttons.Add(StopRadioButton);
            list_of_radiobuttons.Add(RectRadioButton);
            list_of_radiobuttons.Add(RhombusRadioButton);
            list_of_radiobuttons.Add(LinkRadioButton);
            list_of_radiobuttons.Add(TrashRadioButton);


            //https://stackoverflow.com/questions/6996987/c-sharp-how-to-get-a-bitmap-from-a-picturebox
            if (MainPictureBox.Image == null)
                MainPictureBox.Image = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);

            RadioButton enableButton = null;
            foreach (RadioButton rb in list_of_radiobuttons)
                if (rb.Checked)
                {
                    enableButton = rb;
                    break;
                }

            // Create graphics
            Graphics g = Graphics.FromImage(MainPictureBox.Image);

            // Left button pressed
            if(!ismoving)
            if (e.Button == MouseButtons.Right)
            {
                for (int i = list_of_blocks.Count - 1; i >= 0; i--)
                {
                    list_of_blocks[i].ChangeBorderToSolidLine();
                }
                rightClickedBlock = null;

                bool coverageDetected = false;
                for (int i = list_of_blocks.Count - 1; i >= 0; i--)
                {
                    if (list_of_blocks[i].CheckCoverage(e.X, e.Y))
                    {

                        if (list_of_blocks[i].GetBorderStyle() == "dotted")
                        {
                            list_of_blocks[i].ChangeBorderToSolidLine();
                            rightClickedBlock = null;
                            ChosedBlockTextBox.Text = "";
                            ChosedBlockTextBox.Enabled = false;
                        }
                        else
                        {
                            list_of_blocks[i].ChangeBorderToDottedLine();
                            rightClickedBlock = list_of_blocks[i];
                            ChosedBlockTextBox.Text = list_of_blocks[i].Text;
                            ChosedBlockTextBox.Enabled = true;

                            if (list_of_blocks[i].Text == "START")
                                ChosedBlockTextBox.Enabled = false;
                            if (list_of_blocks[i].Text == "STOP")
                                ChosedBlockTextBox.Enabled = false;
                        }
                        coverageDetected = true;
                        break;
                    }
                }
                if (!coverageDetected && rightClickedBlock == null)
                {
                    ChosedBlockTextBox.Text = "";
                    ChosedBlockTextBox.Enabled = false;
                }


                redrawPictureBox(list_of_blocks, MainPictureBox);
            }



            // Left button pressed
            if(!ismoving)
            if (e.Button == MouseButtons.Left)
            {

                IBloq bloq;

                if (enableButton != null)
                    switch (enableButton.Name)
                    {
                        case "StartRadioButton":
                            if (containStart)
                            {
                                MessageBox.Show(GlobalStrings.MessageBoxAlreadyOneStopBlock);
                                break;
                            }
                            bloq = new StartBloq(e.X, e.Y);
                            list_of_blocks.Add(bloq);
                            bloq.DrawShape(g);
                            containStart = true;
                            break;
                        case "StopRadioButton":
                            bloq = new StopBloq(e.X, e.Y);
                            list_of_blocks.Add(bloq);
                            bloq.DrawShape(g);
                            break;
                        case "RhombusRadioButton":
                            bloq = new RhombusBloq(e.X, e.Y);
                            list_of_blocks.Add(bloq);
                            bloq.DrawShape(g);
                            break;
                        case "RectRadioButton":
                            bloq = new RectBloq(e.X, e.Y);
                            list_of_blocks.Add(bloq);
                            bloq.DrawShape(g);
                            break;
                        case "TrashRadioButton":
                            RemoveCoveredBloq(e.X, e.Y);
                            break;
                        default:
                            break;
                    }

            }



            MainPictureBox.Invalidate();
        }

        private void RemoveCoveredBloq(int xm, int ym)
        {
            for (int i = list_of_blocks.Count - 1; i >= 0; i--)
            {
                if (list_of_blocks[i].CheckCoverage(xm, ym))
                {
                    if (list_of_blocks[i] is StartBloq)
                        containStart = false;

                    if (rightClickedBlock == list_of_blocks[i])
                    {
                        rightClickedBlock = null;
                        ChosedBlockTextBox.Text = "";
                        ChosedBlockTextBox.Enabled = false;
                    }

                    list_of_blocks[i].CleanLines();
                    list_of_blocks.RemoveAt(i);
                    redrawPictureBox(list_of_blocks, MainPictureBox);

                    break;
                }
            }
        }

        private void PictureFlowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }



        private void ZapiszSchematButton_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Diagram file|*.diag";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();



            List<IBloq> data = list_of_blocks;
            // last element of list contains info about size of mainpicturebox
            data.Add(new SizeBloq(MainPictureBox.Width, MainPictureBox.Height));

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                //https://stackoverflow.com/questions/5005900/how-to-serialize-listt
                string strfilename = saveFileDialog1.InitialDirectory + saveFileDialog1.FileName;
                Serializator.Serialize(strfilename, list_of_blocks); // trying to serialise
                MessageBox.Show("Schemat zapisany pomyślnie.");
            }
            data.RemoveAt(data.Count - 1);

        }

        private void redrawPictureBox(List<IBloq> bloqs, PictureBox pb)
        {


            Graphics g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            foreach (IBloq b in list_of_blocks)
                b.DrawShape(g);

            pb.Invalidate();
        }

        private void redrawPictureBoxAndDrawLine(List<IBloq> bloqs, PictureBox pb, Point start, Point end)
        {

            Graphics g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            foreach (IBloq b in list_of_blocks)
                b.DrawShape(g);
            g.DrawLine(new Pen(Color.Black, 2), start, end);

            pb.Invalidate();
        }

        private void WczytajSchematButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Load an Image File";


            List<IBloq> data = null;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            if (openFileDialog1.FileName != "")
            {
                if (Path.GetExtension(openFileDialog1.FileName) != ".diag")
                {
                    MessageBox.Show(GlobalStrings.MessageBoxBadExtensionMessage);
                    return;
                }
                string strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                try
                {
                    data = Serializator.Deserialize<List<IBloq>>(strfilename);
                }
                catch(System.ArgumentException ex)
                {
                    MessageBox.Show(GlobalStrings.CannotLoadFile);
                    return;
                }
            }



            // get info about size of mainpicturebox
            // last element of list contains this staff
            MainPictureBox.Size = new Size(data[data.Count - 1].X, data[data.Count - 1].Y);
            
            // https://stackoverflow.com/questions/5856196/clear-image-on-picturebox
            // redraw image
            MainPictureBox.Image = new Bitmap(data[data.Count - 1].X, data[data.Count - 1].Y);

            data.RemoveAt(data.Count - 1);
            list_of_blocks = data;

            redrawPictureBox(list_of_blocks, MainPictureBox);

            return;

        }

        private void PolskiButton_Click(object sender, EventArgs e)
        {
            list_of_radiobuttons.Clear();
            list_of_radiobuttons.Add(StartRadioButton);
            list_of_radiobuttons.Add(StopRadioButton);
            list_of_radiobuttons.Add(RectRadioButton);
            list_of_radiobuttons.Add(RhombusRadioButton);
            list_of_radiobuttons.Add(LinkRadioButton);
            list_of_radiobuttons.Add(TrashRadioButton);

            int pw = MainPictureBox.Width;
            int ph = MainPictureBox.Height;

            int checkediterator = -1;
            foreach (RadioButton rb in list_of_radiobuttons)
            {
                if (rb.Checked)
                {
                    checkediterator++;
                    break;
                }
                checkediterator++;
            }



            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            Controls.Clear();
            InitializeComponent();

            MainPictureBox.Size = new Size(pw, ph);
            MainPictureBox.Image = new Bitmap(pw, ph);
            redrawPictureBox(list_of_blocks, MainPictureBox);

            list_of_radiobuttons.Clear();
            list_of_radiobuttons.Add(StartRadioButton);
            list_of_radiobuttons.Add(StopRadioButton);
            list_of_radiobuttons.Add(RectRadioButton);
            list_of_radiobuttons.Add(RhombusRadioButton);
            list_of_radiobuttons.Add(LinkRadioButton);
            list_of_radiobuttons.Add(TrashRadioButton);

            if (checkediterator > 0)
                list_of_radiobuttons[checkediterator].Checked = true;
        }

        private void AngielskiButton_Click(object sender, EventArgs e)
        {
            list_of_radiobuttons.Clear();
            list_of_radiobuttons.Add(StartRadioButton);
            list_of_radiobuttons.Add(StopRadioButton);
            list_of_radiobuttons.Add(RectRadioButton);
            list_of_radiobuttons.Add(RhombusRadioButton);
            list_of_radiobuttons.Add(LinkRadioButton);
            list_of_radiobuttons.Add(TrashRadioButton);

            int pw = MainPictureBox.Width;
            int ph = MainPictureBox.Height;

            int checkediterator = -1;
            foreach (RadioButton rb in list_of_radiobuttons)
            {
                if (rb.Checked)
                {
                    checkediterator++;
                    break;
                }
                checkediterator++;
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-EN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
            Controls.Clear();
            InitializeComponent();

            MainPictureBox.Size = new Size(pw, ph);
            MainPictureBox.Image = new Bitmap(pw, ph);
            redrawPictureBox(list_of_blocks, MainPictureBox);

            list_of_radiobuttons.Clear();
            list_of_radiobuttons.Add(StartRadioButton);
            list_of_radiobuttons.Add(StopRadioButton);
            list_of_radiobuttons.Add(RectRadioButton);
            list_of_radiobuttons.Add(RhombusRadioButton);
            list_of_radiobuttons.Add(LinkRadioButton);
            list_of_radiobuttons.Add(TrashRadioButton);

            if (checkediterator > 0)
                list_of_radiobuttons[checkediterator].Checked = true;
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (middleButtonState != false)
            {
                // moving clickedBlock
                ismoving = true;
                rightClickedBlock.X = rightClickedBlockPositionWhenClickedMiddleButton.X - mousePositionWhenClickedMiddleButton.X + e.X;
                rightClickedBlock.Y = rightClickedBlockPositionWhenClickedMiddleButton.Y - mousePositionWhenClickedMiddleButton.Y + e.Y;

                redrawPictureBox(list_of_blocks, MainPictureBox);
            }

            if (leftButtonDrawingMode)
            {

                redrawPictureBoxAndDrawLine(list_of_blocks, MainPictureBox, drawLinkStartPosition, new Point(e.X, e.Y));
            }

        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            if (leftButtonDrawingMode)
            {
                for (int i = list_of_blocks.Count - 1; i >= 0; i--)
                {
                    if (startBloqDrawingLine.TryDrawLine(list_of_blocks[i], e.X, e.Y))
                    {
                        break;
                    }

                }
                leftButtonDrawingMode = false;
            }





            redrawPictureBox(list_of_blocks, MainPictureBox);

            if (e.Button == MouseButtons.Middle)
            {
                ismoving = false;
                middleButtonState = false;
                if (e.X < 0)
                {
                    rightClickedBlock.X = 0;
                    redrawPictureBox(list_of_blocks, MainPictureBox);
                }
                    
                if (e.X > MainPictureBox.Width)
                {
                    rightClickedBlock.X = MainPictureBox.Width - 1;
                    redrawPictureBox(list_of_blocks, MainPictureBox);
                }
                    
                if (e.Y < 0)
                {
                    rightClickedBlock.Y = 0;
                    redrawPictureBox(list_of_blocks, MainPictureBox);
                }
                    
                if (e.Y > MainPictureBox.Height)
                {
                    rightClickedBlock.Y = MainPictureBox.Height - 1;
                    redrawPictureBox(list_of_blocks, MainPictureBox);
                }
                   
            }
                
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (rightClickedBlock != null)
                {
                    mousePositionWhenClickedMiddleButton = e.Location;
                    rightClickedBlockPositionWhenClickedMiddleButton.X = rightClickedBlock.X;
                    rightClickedBlockPositionWhenClickedMiddleButton.Y = rightClickedBlock.Y;
                    middleButtonState = true;
                }

            }

            if (LinkRadioButton.Checked == true)
            {

                for (int i = list_of_blocks.Count - 1; i >= 0; i--)
                {
                    if (list_of_blocks[i].CanStartDrawingLine(e.X, e.Y))
                    {
                        leftButtonDrawingMode = true;
                        drawLinkStartPosition = new Point(e.X, e.Y);
                        startBloqDrawingLine = list_of_blocks[i];
                        break;
                    }

                }

            }

        }

        private void ChosedBlockTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ChosedBlockTextBox.Enabled == true)
                if (rightClickedBlock != null)
                {
                    rightClickedBlock.Text = ChosedBlockTextBox.Text;
                    redrawPictureBox(list_of_blocks, MainPictureBox);
                }
        }
    }
}
