using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form

    {



        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);





        //public Form2(string job, string cale)
        //{
        //    InitializeComponent();
        //    // labelFrm2.Text = job;
        //    calePathFr2 = cale;
        //    button1Fr2Copy.Text = job;
        //}
        //public string calePathFr2 { get; set; }
        //public string jobNrfr2 { get; set; }
        public string calejob { get; set; }
        
        public string jobAsprlinkhere { get; set; }


        private GenerateBatchCommand mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as GenerateBatchCommand;
            InitializeComponent();

        }
        // public delegate void MyHandler();
        //public event MyHandler MyEventHandler;
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MyEventHandler?.Invoke();
        //}

        //{
        // get { return labelFrm2.Text; }
        //  }
        //public Form2(GenerateBatchCommand caleabsdata)
        //{
        //    calePathFr2 = GenerateBatchCommand.caleabsdata;
        //}
        //public string YourText { get; set; }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            button1Fr2Copy.Text = this.mainForm.jobNrfr2;

            //const int margin = 40;
            ////int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - margin;
            ////int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - margin;
            //int x = Screen.PrimaryScreen.WorkingArea.Right - margin;
            //int y = Screen.PrimaryScreen.WorkingArea.Bottom - margin;

            //this.Location = new Point(0, 0);


            //Rectangle workingArea = Screen.GetWorkingArea(this);
            //this.Location = new Point(workingArea.Right - Size.Width,
            //                          workingArea.Bottom - Size.Height);


            //this.mainForm.jobNrfr2 = labelFrm2.Text;
            //MessageBox.Show(this.calejob);
            //textBoxFdoi.Text = calejob;

        }
        void button1Fr2Copy_Click(object sender, EventArgs e)
        {
            // this.mainForm.jobNrfr2 = labelFrm2.Text;
            // button1Fr2Copy.Text = this.mainForm.jobNrfr2;

            // Clipboard.SetText(this.mainForm.calePathFr2); //calejob
            Clipboard.SetText(calejob);
        }

        public void UpdateValues(string jobnr, string calePath, string jobAspr, string jobAsprlink)
        {
            // button1Fr2Copy.Text = this.mainForm.jobNrfr2; // _yourText
            button1Fr2Copy.Text = jobnr; // _yourText
                                         // labelAspr.Text = jobAspr;
            // aici da eroarea!!!!
            jobAsprlinkhere = jobAsprlink;
            
            buttonAspr.Text = jobAspr.ToString();
            calejob = calePath;
        }
        private void buttonAspr_Click(object sender, EventArgs e)
        {


            new Process
            {
                StartInfo = new ProcessStartInfo(@jobAsprlinkhere)
                {
                    UseShellExecute = true
                }
            }.Start();
            //Process[] pname = Process.GetProcessesByName("chrome.exe");
            //if (pname.Length > 0)

            //{

            //    // string file = @"c:\totalcmd\TOTALCMD64.EXE";
            //    //Process.Start("chrome.exe", "http://www.YourUrl.com");

            //    string destinat = jobAsprlinkhere; //

            //    var process = Process.GetProcessesByName("chrome.exe").First();
            //    string fullPath = process.GetMainModuleFileName();
            //    if (fullPath.Length > 0)
            //    {
            //        Process.Start(fullPath, destinat);

            //    }
            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {

            //  Process.Start(@"c:\test"); //caleAbsData
            // Process.Start(@"\\nas\GRIP\shapes\_FailedOrders\012345 temp proba\");

            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)

            {

                // string file = @"c:\totalcmd\TOTALCMD64.EXE";

                //string destinat = @"/R=""" + @calejob + "tab 1 add.tab" + ""; //
                string destinat = "/R=\"" + calejob + "tab 1 add.tab" + "\"" + " /T";

                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);

                }
            }
            else
            {
                Process.Start("explorer.exe", @calejob);
            }


        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }



}
