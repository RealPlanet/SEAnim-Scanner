using SELib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// 
/// Copyright (C) 2020 by OfficialPLanet (RealPlanet @GitHub) refer to License.txt or ABOUT button at runtime
/// 

namespace SEAnimScanner
{
    public partial class AppWindow : Form
    {

        private String CurrentDirectory;
        private String ExportDirectory;
        private bool ScanInProgress = false;
        private bool LoadingAnims = false;
        private static List<String> file_paths; //This list contains the animation paths
        private static List<String> Joints; // This list contains all the joints the user might need the anims for.

        public AppWindow()
        {
            InitializeComponent();
            this.animList.DragDrop += new System.Windows.Forms.DragEventHandler(this.AnimInputBox_DragDrop);
            this.animList.DragEnter += new System.Windows.Forms.DragEventHandler(this.AnimInputBox_DragEnter);

            file_paths = new List<String>();
            Joints = new List<String>();
            CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            ExportDirectory = CurrentDirectory + "\\SEanimations\\"; //This will be the final directory

            //Add async functions to the background workers
            readAnimsBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(readAnimsBackground_doWork);
            getFilePathBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(getFilePathBackground_doWork);
        }

        /// <summary>
        /// Handles exit actions on button press
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reads all animations on a separate thread and looks for the specified joint
        /// </summary>
        private void startScan_ClickEvent(object sender, EventArgs e)
        {
            if (ScanInProgress) return;

            if (LoadingAnims) return;

            if (Joints == null || Joints.Count < 1) //If no joints where specified no use in starting the search
            {
                outputTextbox.AppendText("No joint name was specified, please type a valid joint name (ie. \" tag_weapon \") \n");
                return;
            }

            if (animList.Items.Count < 1)
            {
                outputTextbox.AppendText(" No Seanims where provided, please add atleast 1 \n");
                return;
            }

            ScanInProgress = true;
            progressBar.Value = 0;
            progressBar.Maximum = file_paths.Count;
            outputTextbox.Clear(); //Starting search, clear all previous messages
            outputTextbox.AppendText("Starting scan...\n");
            readAnimsBackground.RunWorkerAsync();
        }

        /// <summary>
        /// Opens GIT URL on defualt browser
        /// </summary>
        private void GitButton_Click(object sender, EventArgs e)
        {
            OpenURL("https://github.com/RealPlanet");
        }

        private void LicensBtt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Copyright(C) 2020 by OfficialPLanet(RealPlanet @GitHub)\n" +
                "Icon made by: \n https://www.flaticon.com/authors/freepik \n" +
                "If you like to support what I do you can find a donation link on my GitHub Page\n" +
                "Many thanks to Dtzxporter for his SEAnim Library");
        }

        /// <summary>
        /// Handles Cursor effects fro DND
        /// </summary>
        private void AnimInputBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Loads all files dropped by the user on a separate thread
        /// </summary>
        private void AnimInputBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            animList.Items.Clear();

            String[] stringAnimations = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            progressBar.Maximum = stringAnimations.Length; //Set the progress bar to fit all elements

            getFilePathBackground.RunWorkerAsync(stringAnimations);
        }

        /// <summary>
        /// When user inputs tokens separated by a comma(,) this method splits the string and adds it to the Joints List
        /// </summary>
        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            JointLabelInfo.Text = "";
            Joints.Clear();
            String TextIN = InputBox.Text;
            String[] ActualTextIn = TextIN.Split(',');
            foreach (String word in ActualTextIn) Joints.Add(word);
        }

        private void outputTextbox_TextChanged(object sender, EventArgs e)
        {
            outputTextbox.SelectionStart = outputTextbox.Text.Length;
            outputTextbox.ScrollToCaret();
        }

        /// <summary>
        /// Starts async scan of each seanim loaded
        /// </summary>
        private async void readAnimsBackground_doWork(object sender, DoWorkEventArgs e)
        {
            await Task.Run(() => DoAnimScan());
        }

        /// <summary>
        /// Starts async read of all files added by user
        /// </summary>
        private async void getFilePathBackground_doWork(object sender, DoWorkEventArgs e)
        {
            String[] PathsArray = (String[])e.Argument;
            await Task.Run(() => LoadAnimPaths(PathsArray));
        }

        /// <summary>
        /// Compares the given anim's joints with the joints provided by the user returns true if the anim contains atleast one
        /// </summary>
        private bool ReadSEanimForJoint(SEAnim anim)
        {
            if (anim.Bones.Count < 1) return false;
            else
            {
                if (Joints.Count < 2)
                {
                    for (int i = 0; i < anim.Bones.Count; i++)
                        if (anim.Bones.ElementAt(i).CompareTo(Joints.ElementAt(0)) == 0) return true;
                }
                else
                {
                    for (int j = 0; j < Joints.Count; j++)
                    {
                        for (int y = 0; y < anim.Bones.Count; y++)
                            if (anim.Bones.ElementAt(y).CompareTo(Joints.ElementAt(j)) == 0) return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Goes through each anim bone and compares it to the joints specified by user
        /// </summary>
        private void DoAnimScan()
        {
            for (int i = 0; i < file_paths.Count; i++)
            {
                outputTextbox.Invoke(new Action(() => outputTextbox.AppendText("Reading " + System.IO.Path.GetFileNameWithoutExtension(file_paths.ElementAt(i)) + " .... \n")));

                bool isCorrectAnim = ReadSEanimForJoint(SEAnim.Read(file_paths.ElementAt(i)));
                if (isCorrectAnim)
                {
                    if (!System.IO.Directory.Exists(ExportDirectory))
                        System.IO.Directory.CreateDirectory(ExportDirectory);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(ExportDirectory);
                    System.IO.File.Move(@file_paths.ElementAt(i), ExportDirectory + System.IO.Path.GetFileName(file_paths.ElementAt(i)));
                    file_paths.RemoveAt(i); //Remove the anim , then lower I to make sure to get the last element 
                    animList.Invoke(new Action(() => animList.Items.RemoveAt(i--))); //Add file name to the UI list
                }
                progressBar.Invoke(new Action(() => progressBar.Increment(1))); //Increments the progress bar to inform the user how long till it's done         
            }
            System.Windows.Forms.MessageBox.Show("Scan has been completed, anims can be found in \"SEanimations\" ");
            ScanInProgress = false;
        }

        /// <summary>
        /// Adds all animations to a list, if a directory was dropped all files inside it are checked
        /// </summary>
        private void LoadAnimPaths(String[] array)
        {
            LoadingAnims = true;
            for (int i = 0; i < array.Length; i++)
            {

                if (System.IO.Path.HasExtension(array[i]) && System.IO.Path.GetExtension(array[i]) == ".seanim")
                {                                            //If a file was dropped add it directly to te list
                    String file_name = System.IO.Path.GetFileNameWithoutExtension(array[i]);
                    file_paths.Add(array[i]); //Add the path for later use
                    animList.Invoke(new Action(() => animList.Items.Add(file_name))); //Add file name to the UI list
                    //Thread.Sleep(10);
                }
                else if (!System.IO.Path.HasExtension(array[i])) //If a folder was dropped then read it's contents
                {
                    System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(array[i]);
                    System.IO.FileInfo[] Files = d.GetFiles("*.seanim"); //Getting Text files
                    foreach (System.IO.FileInfo file in Files)
                    {
                        String file_name = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                        file_paths.Add(file.FullName); // Add the path for later use
                        animList.Invoke(new Action(() => animList.Items.Add(file_name))); //Add file name to the UI list
                        if (animList.Items.Count > 0)
                            DDlabel.Invoke(new Action(() => DDlabel.Text = "")); //Action that hides the "DRAG ANIMS HERE" label
                    }
                }
                if (animList.Items.Count > 0)
                    DDlabel.Invoke(new Action(() => DDlabel.Text = "")); //Action that hides the "DRAG ANIMS HERE" label
                progressBar.Invoke(new Action(() => progressBar.Increment(1))); //Increments the progress bar to inform the user how long till it's done
            }
            outputTextbox.Invoke(new Action(() => outputTextbox.AppendText("Loaded " + animList.Items.Count + " animation(s)... \n")));
            LoadingAnims = false;
        }

        private static void OpenURL(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                System.Windows.Forms.MessageBox.Show(noBrowser.Message);
            }
        }

        private void AppWindow_Load(object sender, EventArgs e)
        {

        }

        private void animList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}