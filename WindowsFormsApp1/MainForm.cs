using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;


namespace PRTHandler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbox_function.Text = "dwg";
            cbox_maxPaperSize.Text = "3";

            try
            {
                string ugiiBaseDir = Environment.GetEnvironmentVariable("UGII_BASE_DIR");
                tb_nxPath.Text = ugiiBaseDir;
            }
            catch (System.IO.DirectoryNotFoundException) { }
        }


        private void cbox_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_Path.Items.Clear();
            if (cbox_function.Text == "dwg")
            {
                this.Text = "Hard drive waster";
                cbox_Path.DropDownStyle = ComboBoxStyle.DropDown;
                btn_browserPath.Enabled = true;
                lb_path.Text = "Output path";
                groupBox1.Enabled = false;
            }
            if (cbox_function.Text == "print")
            {
                this.Text = "Paper waster";
                cbox_Path.DropDownStyle = ComboBoxStyle.DropDownList;
                btn_browserPath.Enabled = false;
                lb_path.Text = "Printer";
                groupBox1.Enabled = true;
                //get printer list
                string defaultPrinterName = new PrintDocument().PrinterSettings.PrinterName;
                foreach (string eachPrinterName in PrinterSettings.InstalledPrinters)
                {
                    cbox_Path.Items.Add(eachPrinterName);
                    if (eachPrinterName == defaultPrinterName)
                    {
                        cbox_Path.SelectedIndex = cbox_Path.Items.IndexOf(eachPrinterName);
                    }
                }
            }
        }

        private void btn_addPrt_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "Select prt";
            dialog.Filter = "Part file (*.prt)|*.prt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string prtName in dialog.FileNames)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = prtName;
                }
            }
        }

        private void btn_removePrt_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                DataGridViewSelectedCellCollection cells = dataGridView1.SelectedCells;
                foreach (DataGridViewCell c in cells)
                {
                    dataGridView1.Rows.RemoveAt(c.RowIndex);
                }
            }
            catch { }
        }

        /// <summary>
        /// execute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_execute_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(tb_nxPath.Text + "\\ugii\\libpart.dll"))
                {
                    System.IO.Directory.SetCurrentDirectory(tb_nxPath.Text + "\\ugii");
                }
                else if (System.IO.File.Exists(tb_nxPath.Text + "\\nxbin\\libpart.dll"))
                {
                    System.IO.Directory.SetCurrentDirectory(tb_nxPath.Text + "\\nxbin");
                }
                else
                {
                    MessageBox.Show("Unknow NX version");
                    Close();
                }

            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("UGII_BASE_DIR incorrect");
                return;
            }

            if (cbox_function.Text == "print")
                printDrawing();
            else if (cbox_function.Text == "dwg")
                converDrawing();
        }

        private void btn_clearPath_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }


        /// <summary>
        /// print function
        /// </summary>
        private void printDrawing()
        {
            dataGridView1.ClearSelection();

            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = true;

                progressBar1.PerformStep();
                lb_progress.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();

                dataGridView1.Rows[i].Cells[1].Value = "Open part";

                NXDrawingPart part = new NXDrawingPart();

                if (!part.initSuccess)
                {
                    Close();
                    return;
                }

                part.openPart((string)dataGridView1.Rows[i].Cells[0].Value);

                double[] drawingSize = part.GetDrawingSize();
                if (drawingSize == null)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "No drawing in the file";
                    continue;
                }

                // paper size
                // h*w
                // 210*297  a4 v
                // 297*420  a3 h
                // 420*594  a2 h
                // 594*841  a1 h
                // 841*1189 a0 h
                bool landscape = true;
                if (drawingSize[0] > drawingSize[1])
                    landscape = false;

                int paperSize;
                double drawingHeight = Math.Max(drawingSize[0], drawingSize[1]);
                if (drawingHeight >= 1189) paperSize = 0;
                else if (drawingHeight >= 841) paperSize = 1;
                else if (drawingHeight >= 594) paperSize = 2;
                else if (drawingHeight >= 420) paperSize = 3;
                else paperSize = 4;

                if (landscape)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "A" + paperSize.ToString() + " horizontal";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[1].Value = "A" + paperSize.ToString() + " portrait";
                }

                paperSize = Math.Max(paperSize, int.Parse(cbox_maxPaperSize.Text));

                // line weight, thin, normal, thick

                part.Print(
                    cbox_Path.Text,
                    paperSize,
                    landscape
                );

                part.closePart();
                part.Dispose();
            }
        }

        /// <summary>
        /// convert to cad
        /// </summary>
        private void converDrawing()
        {
            if (!System.IO.Directory.Exists(cbox_Path.Text))
            {
                MessageBox.Show("Path does not exist");
                return;
            }
            //
            //convert to cgm
            //
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                progressBar1.PerformStep();
                lb_progress.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();

                dataGridView1.Rows[i].Selected = true;

                dataGridView1.Rows[i].Cells[1].Value = "Open Part";

                NXDrawingPart part = new NXDrawingPart();
                if (!part.initSuccess)
                {
                    Close();
                    return;
                }

                part.openPart((string)dataGridView1.Rows[i].Cells[0].Value);

                double[] drawingSize = part.GetDrawingSize();
                if (drawingSize == null)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "No drawing in the file";
                    continue;
                }

                part.ExportCgm(cbox_Path.Text);

                dataGridView1.Rows[i].Cells[1].Value = "Convert to CGM";

                part.closePart();
                part.Dispose();
            }

            dataGridView1.ClearSelection();

            // convert to dwg
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = true;

                progressBar1.PerformStep();
                lb_progress.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();

                if ((string)(dataGridView1.Rows[i].Cells[1].Value) != "No drawing in the file")
                {
                    string fileName = (string)dataGridView1.Rows[i].Cells[0].Value;
                    string cgmName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    //MessageBox.Show(cgmName);
                    NXDrawingPart part = new NXDrawingPart();
                    if (!part.initSuccess)
                    {
                        Close();
                        return;
                    }

                    if (File.Exists(cbox_Path.Text + "\\temp.prt"))
                    {
                        System.IO.File.Delete(cbox_Path.Text + "\\temp.prt");
                    }
                    part.ExportDwg(tb_nxPath.Text, cbox_Path.Text, cgmName);

                    dataGridView1.Rows[i].Cells[1].Value = "Done";

                    while (!System.IO.File.Exists(cbox_Path.Text + "\\" + cgmName + ".dwg")) ;
                    System.IO.File.Delete(cbox_Path.Text + "\\temp.prt");
                }
                else
                {
                    continue;
                }
            }
        }

        private void btn_browseNX_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select UGII_BASE_DIR";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    tb_nxPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btn_browserPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select dwg save path";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    cbox_Path.Text = dialog.SelectedPath;
                }
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All; //drag in
                foreach (string str in s) //only alow file drag in
                {
                    if (File.Exists(str) == false)
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string eachFile in files)
            {
                string extName = Path.GetExtension(eachFile).ToLower();
                if (extName.Contains(".prt"))
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = eachFile;
                }
            }
        }
    }
}
