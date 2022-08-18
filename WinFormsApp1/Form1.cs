using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using WK.Libraries.SharpClipboardNS;
using System.Xml.Linq;
using UglyToad.PdfPig;
using UglyToad.PdfPig.AcroForms;
using UglyToad.PdfPig.AcroForms.Fields;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Outline;
using Diacritics.AccentMappings;
using Diacritics.Extensions;
using XmpCore;
using Serilog;
using Serilog.Sinks.SystemConsole;
namespace WinFormsApp1
{
    public partial class GenerateBatchCommand : Form
    {
        string caleAbsDataJsonFile { get; set; }
        string pathAPBgeneral { get; set; }
        string front1Plus { get; set; }
        string front2Plus { get; set; }
        string front3Plus { get; set; }
        string front4Plus { get; set; }
        string front5Plus { get; set; }
        string front6Plus { get; set; }
        string front7Plus { get; set; }
        string front1 { get; set; }
        string front2 { get; set; }
        string front3 { get; set; }
        string front4 { get; set; }
        string front5 { get; set; }
        string front6 { get; set; }
        string front7 { get; set; }
        string caleData { get; set; }
        string caleAbsData { get; set; }
        string caleAbsDataJson { get; set; }
        string caleAbsDataPDF { get; set; }
        string caleAbsDataPDF_M { get; set; }
        string caleAbsDataJson_M { get; set; }
        string[] pdflist { get; set; }
        string[] jsonList { get; set; }
        string varJsonName { get; set; }
        string varJsonName1 { get; set; }
        string varArtName { get; set; } 
        string varMapping { get; set; }
        string varArt { get; set; }
        string varDPI { get; set; }
        string varTexture { get; set; }
        string varWtempfolder { get; set; }
        string varDpivar { get; set; }
        string varTexturevar { get; set; }
        string varNocachevar { get; set; }
        string varNoLayerCache { get; set; }
        string varOverrideDPIvar { get; set; }
        string varnoCompositeCache { get; set; }
        string varoverrideTextureSize { get; set; }
        string varOutputTextvar { get; set; }
        string varOutputText { get; set; }
        string[] parteaNumePdf { get; set; }
        string[] parteaNumePdfPtScript { get; set; }
        string[] numeFatza { get; set; }
        string parteaNumeTOATEPdf { get; set; }
        int lungimelistapdf { get; set; }
        int day { get; set; }
        string Culoare1 { get; set; }
        string Culoare2 { get; set; }
        string Culoare3 { get; set; }
        string Culoare4 { get; set; }
        string Culoare1Lichid { get; set; }
        string Culoare2Lichid { get; set; }
        string Culoare3Lichid { get; set; }
        string Culoare4Lichid { get; set; }
        string Lichid1 { get; set; }
        string Lichid2 { get; set; }
        string Lichid3 { get; set; }
        string Lichid4 { get; set; }
        string ParteaLichid { get; set; }
        string ParteaBody { get; set; }
        string BodyHas1 { get; set; }
        string BodyHas2 { get; set; }
        string BodyHas3 { get; set; }
        string BodyHas4 { get; set; }
        string[] ArBodyNone { get; set; }
        string[] ArBody { get; set; }
        string[] ArCuloare { get; set; }
        string[] ArLichidNone { get; set; }
        string[] ArLichid { get; set; }
        string[] ArCuloareLichid { get; set; }
        string[] arrayIDdinJson { get; set; }
        string[] arrayIDColorsdinJson { get; set; }
        string[] stringNumefatzaDinJson { get; set; }
        int contorGeneral { get; set; }
        int contorFronturi { get; set; }
        int contorBody { get; set; }
        int contorLichid { get; set; }
        int contorBodyColor { get; set; }
        int contorLichidColor { get; set; }
        int varRulari { get; set; }
        string[] numesipathpdf { get; set; }
        string[] nameBodyNr { get; set; }
        string[] nameCuloriNr { get; set; }
        string vardisableTiledProcessing { get; set; }
        string vargeneratePsdMetadata { get; set; }
        string sSelectedFolder;
        string varCaleJson { get; set; }
        string varCalePdf { get; set; }
        string varCaleArtwork { get; set; }
        string varCaleArtworksOnly { get; set; }
        string caleAbsArt_M { get; set; }
        string caleAbsArt { get; set; }
        bool boolHistoryTemp;
        bool boolClip;
        bool boolAriseticket;
        string jobFolderName { get; set; }
        string jobFolderName_NoPause { get; set; }
        string varFileType { get; set; }
        string jobNumber { get; set; }
        string jobNrAspr { get; set; }
        string jobCaleAsprLink { get; set; }
        string stringPathJob { get; set; }
        string stringDataJob { get; set; }
        string asprVar { get; set; }
        int contorHistory { get; set; }
        int contorSearchListHistory { get; set; }
        string GripCommand { get; set; }
        string VarParamGrip { get; set; }
        string GripCommandParam { get; set; }
        string GripCale { get; set; }
        string GripCaleXlx { get; set; }
        string  stringxmp1  { get; set; }
        string newNameAw { get; set; }
        public List<string> listPdfsApbFound = new List<string>();
        public List<string> listPdfsApbNoFound = new List<string>();
        public List<string> InputsList = new List<string>();
        public List<string> InputListColorId = new List<string>();
        public List<string> InputListColors = new List<string>();
        public List<string> listPathPdfsApb = new List<string>();
        public List<string> listPdfsPaths = new List<string>();
        private const string schemans = "http://ns.adobe.com/xap/1.0/t/pg/";
        public List<string> listOfInfo = new List<string>();
        string stringokwrong { get; set; }
        public string jobNrfr2
        {
            get { return jobNumber; }
            set { jobNumber = value; }
        }
        public string calePathFr2
        {
            get { return caleAbsData; }
            set { caleAbsData = value; }
        }
        public string jobAspr
        {
            get { return jobNrAspr; }
            set { jobNrAspr = value; }
        }
        public string jobAsprlink
        {
            get { return jobCaleAsprLink; }
            set { jobCaleAsprLink = value; }
        }
        private static WK.Libraries.SharpClipboardNS.SharpClipboard clipboard =
            new WK.Libraries.SharpClipboardNS.SharpClipboard();
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        public const UInt32 FLASHW_ALL = 3;
        public const UInt32 FLASHW_TIMERNOFG = 12;
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public static bool FlashWindowEx(Form form)
        {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            return FlashWindowEx(ref fInfo);
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        BackgroundWorker Worker = new BackgroundWorker();
        public BindingList<HistoryListClasa> listOfHistory = new BindingList<HistoryListClasa>();
        List<HistoryListClasa> listaPathHistory = new List<HistoryListClasa>();
        List<HistoryListClasa> listaPathHistory2 = new List<HistoryListClasa>();
        List<HistoryTemp> listaPathHistoryTemp = new List<HistoryTemp>();
        public List<string> listaAsprHistoryTemp = new List<string>();
        private Form2 frm;
        public GenerateBatchCommand()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Debug()
                 .CreateLogger();
            Log.Information("--------------------------------------------------------Hello, world!");
            backgroundWorkerSearch.DoWork += BackgroundWorkerSearch_DoWork;
            backgroundWorkerSearch.RunWorkerCompleted += backgroundWorkerSearch_RunWorkerCompleted;
            clipboard.ClipboardChanged += ClipboardChanged;
            checkBox_beiersdorf.Click += CheckBox_beiersdorf_Click;
            checkBoxRenameAw.Click += CheckBoxRenameAw_Click;
            checkBox_overrideTextureSize.CheckedChanged += checkBox_overrideTextureSize_CheckedChanged;
            checkBox_noLayerCache.Click += checkBox_noLayerCache_Click;
            checkBox_NoCache.Click += checkBox_NoCache_Click;
            checkBox_NoComposite.Click += checkBox_NoComposite_Click;
            checkBox_vardisableTiledProcessing.CheckedChanged += checkBox_vardisableTiledProcessing_CheckedChanged;
            checkBox_generatePsdMetadata.CheckedChanged += checkBox_generatePsdMetadata_CheckedChanged;
            checkBox_OverrideDpi.CheckedChanged += checkBox_OverrideDpi_CheckedChanged;
            checkBox_OutputText.CheckedChanged += checkBox_OutputText_CheckedChanged;
            checkBoxBei.Click += CheckBoxBei_Click;
            checkBoxGar.Click += CheckBoxGar_Click;
            checkBoxOap.Click += CheckBoxOap_Click;
            comboBox1Id.TextChanged += ComboBox1Id_TextChanged;
            comboBox2Id.TextChanged += ComboBox2Id_TextChanged;
            comboBox3Id.TextChanged += ComboBox3Id_TextChanged;
            comboBox4Id.TextChanged += ComboBox4Id_TextChanged;
            comboBox5Id.TextChanged += ComboBox5Id_TextChanged;
            comboBox6Id.TextChanged += ComboBox6Id_TextChanged;
            comboBox7Id.TextChanged += ComboBox7Id_TextChanged;
            comboBoxBody1_Culoare.TextChanged += ComboBoxBody1_Culoare_TextChanged;
            comboBoxBody2_Culoare.TextChanged += ComboBoxBody2_Culoare_TextChanged;
            comboBoxBody3_Culoare.TextChanged += ComboBoxBody3_Culoare_TextChanged;
            comboBoxBody4_Culoare.TextChanged += ComboBoxBody4_Culoare_TextChanged;
            comboBoxLichid1_Culoare.TextChanged += ComboBoxLichid1_Culoare_TextChanged;
            comboBoxLichid2_Culoare.TextChanged += ComboBoxLichid2_Culoare_TextChanged;
            comboBoxLichid3_Culoare.TextChanged += ComboBoxLichid3_Culoare_TextChanged;
            comboBoxLichid4_Culoare.TextChanged += ComboBoxLichid4_Culoare_TextChanged;
            comboBox_Dpi.TextChanged += ComboBox_Dpi_TextChanged;
            comboBox_Texture.TextChanged += ComboBox_Texture_TextChanged;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            textBoxSearch.KeyDown += textBoxSearch_KeyDown;
            textBoxNoJobNas.TextChanged += TextBoxNoJobNas_TextChanged;
            textBox1_caleNas.Click += TextBoxOnClick;
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.DoWork += Worker_DoWork;
            jobCaleAsprLink = "";
            jobNrAspr = "";
        }
        private void CheckBoxOap_Click(object sender, EventArgs e)
        {
            checkBoxBei.Checked = false;
            checkBoxGar.Checked = false;
            checkBoxOap.Checked = true;
        }
        private void CheckBoxGar_Click(object sender, EventArgs e)
        {
            checkBoxBei.Checked = false;
            checkBoxGar.Checked = true;
            checkBoxOap.Checked = false;
        }
        private void CheckBoxBei_Click(object sender, EventArgs e)
        {
            checkBoxBei.Checked = true;
            checkBoxGar.Checked = false;
            checkBoxOap.Checked = false;
        }
        private void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
            {
                string textClip = e.Content.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(textClip))
                    {
                        if (textClip.StartsWith("https://jira.indg.net:8443/browse/ASPR-"))
                        {
                            jobCaleAsprLink = textClip.ToString();
                            jobNrAspr = Regex.Match(textClip, "ASPR-\\d+").Value;
                            try
                            {
                                textBoxAspr.Text = jobNrAspr.ToString();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                        }
                        if (textClip.StartsWith("localexplorer:\\\\") || textClip.StartsWith("file://nas") ||
                              textClip.StartsWith("d:\\AWtoolDATA\\") || textClip.StartsWith(" localexplorer:\\\\") ||
                              textClip.StartsWith(" file://nas") ||
                              textClip.StartsWith(" d:\\AWtoolDATA\\"))
                                    {
                                        if (!boolClip)
                                        {
                                            textBox1_caleNas.Text = textClip;
                                            textBox1.Text = "";
                                            Checkmyfiles();
                            }
                                    }
                        if (textClip.StartsWith("\\\\nas\\GRIP\\Artworks\\_ArtworkProcessing") || textClip.StartsWith("Z:\\Artworks\\_ArtworkProcessing"))
                        {
                            GripCaleXlx = textClip.ToString();
                            ComandaGrip();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public void ComandaGrip()
        {
            if (checkBox_beiersdorf.Checked)
            {
                GripCale = @"\\nas\grip\Artworks\Beiersdorf";
            }
            else
            {
                 GripCale = GripCaleXlx;
            }
            try
            {
                string[] files_xlsx = Directory.GetFiles(GripCaleXlx, "*.xlsx");
                List<string> listXlx = new List<string>();
                foreach (string file_xlsx in files_xlsx)
                {
                    listXlx.Add(Path.GetFileName(file_xlsx));
                }
                string VarTempCalexlx = files_xlsx[0].ToString();
                string Xlxfile = Path.GetFullPath(VarTempCalexlx).ToString();
                GripCommand = ".\\Grip.BatchArtworkUploader -e production -d \""
                   + GripCale + "\"" + " -f " + "\""
                   + Xlxfile + "\"" + " ";
                GripCommand = GripCommand.Replace("\\\"", "\"");
                GripCommandParam = GripCommand + VarParamGrip;
                richTextBox1_grip.Text = GripCommandParam.ToString();
            }
            catch (Exception)
            {
            }
        }
        private void CheckBox_beiersdorf_Click(object sender, EventArgs e)
        {
            ComandaGrip();
        }
        private void button_addparamgrip_Click(object sender, EventArgs e)
        {
            VarParamGrip = textBox_gripparam.Text.ToString();
            ComandaGrip();
        }
        private void button_grip_Click(object sender, EventArgs e)
        {
            RunComandaGrip();
        }
        public void RunComandaGrip()
        {
            var prcSh = Process.GetProcessesByName("powershell");
            if (prcSh.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = prcSh[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(prcSh[0].MainWindowHandle);
                Clipboard.SetText(richTextBox1_grip.Text);
                Thread.Sleep(500);
                SendKeys.Send("^+V");
                Thread.Sleep(200);
                SendKeys.Send("{ENTER}");
            }
        }
        public partial class NativeMethods
        {
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);
        }
        public static void BlockInput(int span)
        {
            try
            {
                NativeMethods.BlockInput(true);
                Thread.Sleep(span);
            }
            finally
            {
                NativeMethods.BlockInput(false);
            }
        }
        private void TextBoxNoJobNas_TextChanged(object sender, EventArgs e)
        {
            if (boolAriseticket)
            {
                ariseTicket();
            }
        }
        private void ComboBox_Texture_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        public void ParteaSiAduna()
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void ComboBox_Dpi_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxLichid4_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxLichid3_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxLichid2_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxLichid1_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox7Id_TextChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void ComboBox6Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox5Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox4Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox3Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox2Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBox1Id_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxBody1_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxBody2_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxBody3_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void ComboBoxBody4_Culoare_TextChanged(object sender, EventArgs e)
        {
            ParteaSiAduna();
        }
        private void GenerateBatchCommand_Load(object sender, EventArgs e)
        {
            setVarPathForFiles();
            textBoxSearchSpecial.Text = "INDGfix.pdf";
            boolClip = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        public void setVarPathForFiles()
        {
            varCaleJson = "\\artworks\\mapping\\";
            varCalePdf = "\\artworks\\pdf\\";
            varCaleArtwork = "\\artworks\\artwork\\";
            varCaleArtworksOnly = "\\artworks\\";
        }
        public void MasterMethodsReadJson()
        {
            LoadJson();
            Thread.Sleep(10);
            ParteaEgalNone();
            AdunaData();
            setMyPathToFr2();
        }
        public void Checkmyfiles()
        {
            ClearlistofInfoAndColor();
            PrelucreazaCalea();
            Log.Information("----check my files");
            bool okgo = false;
            string pathnas = textBox1_caleNas.Text;
            if (Directory.Exists(@pathnas))
            {
                Log.Information("-- directory exists");
                boolAriseticket = true;
                string info = "ok";
                int index = -2;
                ManageBoxAlert(info, index);
                string jsonnaspath = textBox1_caleNas.Text;
                caleAbsDataJson = jsonnaspath + varCaleJson;
                string[] files_jsones = Directory.GetFiles(caleAbsDataJson, "*.json");
                int countfiles = files_jsones.Count();
                if (countfiles==0)
                {
                    info = "json file is not there!";
                    StopApp(info);
                    Console.WriteLine($"Directory {pathnas} does not exist!");
                }
                else
                {
                    foreach (string fileName in files_jsones)
                    { ProcessFile(fileName); }
                    void ProcessFile(string fileName)
                    {
                        if (File.Exists(fileName))
                        {
                            Log.Information("-- json exists");
                            string info = "ok";
                            int index = -2;
                            ManageBoxAlert(info, index);
                            okgo = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Maybe vpn is not started or internet connection is lost");
                okgo = false;
                string info = "path is not ok"; 
                StopApp(info);
                Console.WriteLine($"Directory {pathnas} does not exist!");
            }
            if (okgo)
            {
                boolHistoryTemp = true;
                MasterMethods();
            }
        }
        public void StopApp(string info)
        {
            int index = -2;
            ManageBoxAlert(info, index);
            listJson.Items.Clear();
            listPdfs.Items.Clear();
        }
        #region master methodes
        public void MasterMethods()
        {
            listJson.Items.Clear();
            listPdfs.Items.Clear();
            ClearlistofInfoAndColor();
            PrelucreazaCalea();
            GetVarForMyFiles();
            PopuleazaListele();
            CheckColorNamesAutoPdfNames();
            Thread.Sleep(10);
            Thread.Sleep(10);
            LoadJson();
            Thread.Sleep(10);
            ParteaEgalNone();
            AdunaData();
            setMyPathToFr2();
        }
        #endregion master
        private void buttonGetPath_Click(object sender, EventArgs e)
        {
            GetPathForMyFiles();
            listJson.Items.Clear();
            listPdfs.Items.Clear();
            MasterMethods();
        }
        private void button_scan_Click(object sender, EventArgs e)
        {
            listJson.Items.Clear();
            listPdfs.Items.Clear();
            MasterMethods();
        }
        private void TextBoxOnClick(object sender, EventArgs eventArgs)
        {
            var textBox = (Button)sender;
            textBox.Focus();
            Thread.Sleep(10);
            textBox1_caleNas.Text = Clipboard.GetText();
            caleAbsData = textBox1_caleNas.Text;
            label6_exdepath.Text = caleAbsData;
            Checkmyfiles();
        }
        private void textBox1_caleNas_TextChanged(object sender, EventArgs e)
        {
        }
        private void buttonReadJson_Click(object sender, EventArgs e)
        {
            MasterMethodsReadJson();
        }
        public void btnGenerate_Click(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void button_CopyAw_Click(object sender, EventArgs e)
        {
            CopyAwToNas();
        }
        protected virtual bool IsFileLocked(string file)
        {
            try
            {
                using (Stream stream = new FileStream(file, FileMode.Open))
                {
                    stream.Close();
                }
            }
            catch
            {
                return true;
            }
            return false;
        }
        public void CheckifArtIsReady(){
           string pathtoartd = @"D:\AWtoolDATA\" + jobFolderName_NoPause + varCaleArtwork + varArtName;
           string ouptutextd = @"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\mapping\\output.txt";
            if (File.Exists(pathtoartd) && File.Exists(ouptutextd))
            {
                if (!IsFileLocked(pathtoartd) && !IsFileLocked(ouptutextd))
                {
                    CopyAwToNas();
                }
                else
                {
                    Thread.Sleep(2000);
                    CheckifArtIsReady();
                }
            }
            else
            {
                MessageBox.Show($"Errror " + Environment.NewLine + " something is lost..");
            }
        }
        public void CopyAwToNas()
        {
            if (checkBox_generatePsdMetadata.Checked)
            {
                CopyDirAll(@"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\mapping\\temp\\", caleAbsData + "\\artworks\\mapping\\temp\\", "*.*", true);
                Thread.Sleep(500);
            }
            try
            {
                File.Copy(@"D:\AWtoolDATA\" + jobFolderName_NoPause + varCaleArtwork + varArtName, caleAbsData + varCaleArtwork + varArtName, true);
                Thread.Sleep(500);
                CopyDirAll(@"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\mapping\\", caleAbsData + "\\artworks\\mapping\\", "*.txt", true);
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare " + Environment.NewLine + " {ex.Message}" + ex.Message + Environment.NewLine + "I'll try again");
                Thread.Sleep(1000);
                CheckifArtIsReady();
            }
        }
        public void VerificaPdf()
        {
            if (listPdfs.Items.Count > 0)
            {
                executaListaPdf();
            }
        }
        public void ParteaEgalNone()
        {
            parteaNumeTOATEPdf = "";
            ParteaBody = "";
            ParteaLichid = "";
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBoxCommanda.Text);
            CreateCommandLineText();
        }
        public void PrelucreazaCalea()
        {
            caleAbsData = textBox1_caleNas.Text;
            Log.Information("prelucreaza calea 1 - caleAbsData " + caleAbsData);
            if (caleAbsData.StartsWith(" "))
            {
                caleAbsData = caleAbsData.Replace(" ", "");
            }
            if (!caleAbsData.EndsWith("\\"))
            {
                caleAbsData = caleAbsData + "\\";
            }
            if (caleAbsData.Contains("artworks"))
            {
                MessageBox.Show("Calea nu trebuie sa contina folderul artworks!! \n Path will be fixed. ");
                caleAbsData = caleAbsData.Replace("artworks\\", "");
            }
            caleAbsData = caleAbsData.Replace("file://", "\\\\");
            caleAbsData = caleAbsData.Replace("localexplorer:", "");
            caleAbsData = caleAbsData.Replace("%20", " ");
            caleAbsData = caleAbsData.Replace("%E2%80%8B", " ");
            caleAbsData = caleAbsData.Replace("/", "\\");
            AdvertisingPath();
            textBox1_caleNas.Text = caleAbsData;
            Clipboard.SetText(textBox1_caleNas.Text);
            Log.Information("prelucreaza calea 2 - caleAbsData " + caleAbsData);
            if (boolHistoryTemp==true)
            {
                CreateStringHistoryTemp();
            }
            boolHistoryTemp = false;
        }
        public void CreateStringHistoryTemp()
        {
            Log.Information("-- create string history");
            textBox1_caleNas.Text = caleAbsData;
            listaPathHistoryTemp.Add(new HistoryTemp(caleAbsData));
            contorHistory = listaPathHistoryTemp.Count - 1;
            label20.Text = listaPathHistoryTemp.Count.ToString();
            string Asprnr = textBoxAspr.Text;
            listaAsprHistoryTemp.Add(Asprnr);
        }
        #region buton back and forward
        private void button2_Click(object sender, EventArgs e)
        {
            boolAriseticket = false;
            if (contorHistory > 0)
            {
                contorHistory -= 1;
                textBox1_caleNas.Text = listaPathHistoryTemp[contorHistory].ToString();
                if (contorHistory >= 0 && contorHistory <= listaAsprHistoryTemp.Count+1)
                {
                    string Asprnr = listaAsprHistoryTemp[contorHistory];
                    textBoxAspr.Text = Asprnr;
                }
                label23.Text = (contorHistory+1).ToString();
            }
            boolHistoryTemp = false;
            MasterMethods();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            boolAriseticket = false;
            if (contorHistory < listaPathHistoryTemp.Count - 1)
            {
                contorHistory += 1;
                textBox1_caleNas.Text = listaPathHistoryTemp[contorHistory].ToString();
                if (contorHistory >= 0 && contorHistory <= listaAsprHistoryTemp.Count+1)
                {
                    string Asprnr = listaAsprHistoryTemp[contorHistory];
                    textBoxAspr.Text = Asprnr;
                }
                label23.Text = (contorHistory+1).ToString();
            }
            boolHistoryTemp = false;
            MasterMethods();
        }
        #endregion back and forward end
        private void AdvertisingPath()
        {
            if (caleAbsData.Contains("nas"))
            {
                label7_infoFilesLocation.Text = "All files on \\\\nas";
            }
            if (caleAbsData.Contains("AWtoolDATA"))
            {
                label7_infoFilesLocation.Text = "All files on local D:AWtoolDATA";
            }
        }
        private void PopuleazaListele()
        {
            if (checkBox1_JobOnNas.Checked)
            {
                varCaleJson = "";
                varCalePdf = "";
                varCaleArtwork = "";
                varCaleArtworksOnly = "";
                caleAbsData = "D:\\AWtoolDATA\\";
                caleAbsDataJson = caleAbsData;
                caleAbsDataPDF = caleAbsData;
                caleData = "\"../AWtoolDATA/";
                caleAbsDataJson_M = caleData;
                caleAbsDataPDF_M = caleData;
                caleAbsArt_M = caleData;
                textBox1_caleNas.Text = caleAbsData;
                label6_exdepath.Text = caleAbsData;
                AdvertisingPath();
                
                GetdataToList();
                
            }
            else if (caleAbsDataJson != null)
            {
                setVarPathForFiles();
                GetdataToList();
            }
            else
            {
                MessageBox.Show($" get job path first");
            }
            void GetdataToList()
            {
                try
                {
                    string[] files_jsones = Directory.GetFiles(caleAbsDataJson, "*.json");
                    foreach (string files_jsone in files_jsones)
                    {
                        listJson.Items.Add(Path.GetFileName(files_jsone));
                    }
                    string[] files = Directory.GetFiles(caleAbsDataPDF, "*.pdf");
                    Log.Information("get data to list - caleAbsDataPDF " + caleAbsDataPDF);
                   
                    foreach (string file in files)
                    {
                        listPdfs.Items.Add(Path.GetFileName(file));
                        Log.Information("listPdfs " + listPdfs.Items[0]);
                        listPdfsPaths.Add(file);
                        Log.Information("listPdfsPaths " + listPdfsPaths[0]);
                   
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare citire json: " + Environment.NewLine + " {ex.Message}"+ ex.Message);
                    //Application.Exit();
                }
                foreach (string file in listPdfsPaths)
                {
                 
                }
            }
        }
        public void GetPathForMyFiles()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "Custom Description"; //not mandatory
            fbd.SelectedPath = @"D:\AWtoolDATA\";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedFolder = fbd.SelectedPath;
                caleAbsData = sSelectedFolder + "\\";
                GetVarForMyFiles();
                textBox1_caleNas.Text = caleAbsData;
                label6_exdepath.Text = caleAbsData;
                AdvertisingPath();
                //  MessageBox.Show($"caleAbsData = {caleAbsData}");
            }
            else
            { sSelectedFolder = string.Empty; }
            // MessageBox.Show($"sSelectedFolder = {sSelectedFolder}");
        }
        public void GetVarForMyFiles()
        {
            //string path = caleAbsData;
            jobFolderName = Path.GetFileName(Path.GetDirectoryName(caleAbsData));
            //string caleAbsData_M = jobFolderName;
            jobNumber = Regex.Match(jobFolderName, "\\d+").Value;
        
            textBoxNoJobNas.Text = jobNumber;
            jobFolderName_NoPause = jobFolderName.Replace(" ", "");
            jobFolderName_NoPause = jobFolderName_NoPause.Replace("%20", "");
            jobFolderName_NoPause = jobFolderName_NoPause.Replace("%E2%80%8B", "");
            string caleAbsDataPtComanda = "D:\\AWtoolDATA\\" + jobFolderName_NoPause;
            caleAbsDataJson = caleAbsData + varCaleJson;
            
            string caleAbsDataPDF1 = caleAbsData + varCalePdf;
            caleAbsDataPDF = caleAbsDataPDF1.Replace("\\\\artworks", "\\artworks");
            Log.Information("CU REPLACE GetVarForMyFiles caleAbsDataPDF " + caleAbsDataPDF);
            caleAbsArt = caleAbsData + varCaleArtwork;
            //caleAbsDataJson_M = "\"" + caleAbsDataJson;
            caleAbsDataJson_M = "\"" + caleAbsDataPtComanda + varCaleJson;
            caleAbsDataPDF_M = "\"" + caleAbsDataPtComanda + varCalePdf;
            caleAbsArt_M = "\"" + caleAbsDataPtComanda + varCaleArtwork;
            //  MessageBox.Show($"caleAbsData din get = {caleAbsData}  {jobFolderName}");
        }
        public void AdunaData()
        {
         
            try
            {
                front1 = comboBox1Id.GetItemText(comboBox1Id.SelectedItem); // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                front2 = comboBox2Id.GetItemText(comboBox2Id.SelectedItem);
                front3 = comboBox3Id.GetItemText(comboBox3Id.SelectedItem);
                front4 = comboBox4Id.GetItemText(comboBox4Id.SelectedItem);
                front5 = comboBox5Id.GetItemText(comboBox5Id.SelectedItem);
                front6 = comboBox6Id.GetItemText(comboBox6Id.SelectedItem);
                front7 = comboBox7Id.GetItemText(comboBox7Id.SelectedItem);
                //front1 = comboBox1Id.SelectedValue.ToString();
            }
            catch  
            {
                
            }
         
            numeFatza = new string[] { front1, front2, front3, front4, front5, front6, front7 };
            pdflist = listPdfs.Items.OfType<string>().ToArray();
            lungimelistapdf = pdflist.Count<string>();
            if (pdflist.Length > 7)
            {
                MessageBox.Show($"numarul de pdf e mai mare decat 7");
            }
            jsonList = listJson.Items.OfType<string>().ToArray();
            //string varPdf =  fatza1+ "=" + caleData + pdflist[0]+ "\"";
            varJsonName = jsonList[0];
            varJsonName1 = varJsonName.Replace("-mapping.json", "");
            varArtName = varJsonName1 + "-art"+newNameAw+".png";
            varMapping = "-m " + caleAbsDataJson_M + varJsonName + "\""; // de pus cale nas
            varArt = " -o " + caleAbsArt_M + varArtName + "\"";
            varDPI = comboBox_Dpi.SelectedItem.ToString();
            varTexture = comboBox_Texture.SelectedItem.ToString();
            varDpivar = " -d " + "\"" + varDPI + "\"";
            varTexturevar = " -t " + "\"" + varTexture + "\"";
            varWtempfolder = " -w " + caleAbsDataJson_M + "temp" + "\"";  // 
            varOutputText = " |& tee -a " + caleAbsDataJson_M + "output.txt" + "\"";
            VerificaPdf();
        }
        public void executaListaPdf()
        {
            for (int i = 0; i < pdflist.Length; i++)
            {
                if (i == 0)
                {
                    parteaNumePdf = new string[] { numeFatza[i] + "=" + caleAbsDataPDF_M + pdflist[i] + "\"" };
                }
                else
                {
                    parteaNumePdf = parteaNumePdf.Concat(new string[] { numeFatza[i] + "=" + caleAbsDataPDF_M + pdflist[i] + "\"" }).ToArray();
                }
            }
            ExecutaData();
        }
        private void checkBox_overrideTextureSize_CheckedChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_noLayerCache_Click(object sender, EventArgs e)
        {
            checkBox_noLayerCache.Checked = true;
            checkBox_NoCache.Checked = false; checkBox_NoComposite.Checked = false; 
            ParteaEgalNone();
            AdunaData();
        }
        private void CheckBoxRenameAw_Click(object sender, EventArgs e)
        {
            newNameAw = textBoxRenameAw.Text;
            switch (checkBoxRenameAw.Checked)
            {
                case false:
                    newNameAw = "";
                    ParteaEgalNone();
                    AdunaData();
                    break;
                case true:
                    ParteaEgalNone();
                    AdunaData();
                    break;
            }
        }
        private void checkBox_NoCache_Click(object sender, EventArgs e)
        {
            checkBox_NoCache.Checked = true;
            checkBox_NoComposite.Checked = false; checkBox_noLayerCache.Checked = false; 
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_NoComposite_Click(object sender, EventArgs e)
        {
            checkBox_NoComposite.Checked = true;
            checkBox_NoCache.Checked = false; checkBox_noLayerCache.Checked = false; 
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_vardisableTiledProcessing_CheckedChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_generatePsdMetadata_CheckedChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_OverrideDpi_CheckedChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        private void checkBox_OutputText_CheckedChanged(object sender, EventArgs e)
        {
            ParteaEgalNone();
            AdunaData();
        }
        public void ExecutaData()
        {
            for (int i = 0; i < pdflist.Length; i++)
            {
                parteaNumeTOATEPdf += parteaNumePdf[i] + " ";
            }
            if (checkBox_vardisableTiledProcessing.Checked)
            {
                vardisableTiledProcessing = " --disableTiledProcessing ";
            }
            else
            {
                vardisableTiledProcessing = "";
            }
            if (checkBox_generatePsdMetadata.Checked)
            {
                vargeneratePsdMetadata = " --generatePsdMetadata ";
            }
            else
            {
                vargeneratePsdMetadata = "";
            }
            if (checkBox_NoCache.Checked)
            {
                varNocachevar = " --noCache ";
            }
            else
            {
                varNocachevar = "";
            }
            if (checkBox_noLayerCache.Checked)
            {
                varNoLayerCache = " --noLayerCache ";
            }
            else
            {
                varNoLayerCache = "";
            }
            if (checkBox_NoComposite.Checked)
            {
                varnoCompositeCache = " --noCompositeCache ";
            }
            else
            {
                varnoCompositeCache = "";
            }
            if (checkBox_overrideTextureSize.Checked)
            {
                varoverrideTextureSize = " --overrideTextureSize ";
            }
            else
            {
                varoverrideTextureSize = "";
            }
            if (checkBox_OverrideDpi.Checked)
            {
                varOverrideDPIvar = " --overrideDPI ";
            }
            else
            {
                varOverrideDPIvar = "";
            }
            if (checkBox_OutputText.Checked)
            {
                varOutputTextvar = varOutputText;
            }
            else
            {
                varOutputTextvar = "";
            }
            if (checkBox_DuplicateFirst.Checked)
            {
                parteaNumeTOATEPdf += parteaNumePdf[0] + " ";
            }
            else
            {
            }
            if (checkBox_DuplicateSecond.Checked)
            {
                parteaNumeTOATEPdf += parteaNumePdf[1] + " ";
            }
            else
            {
            }
            if (label24.Text != "-")
            {
                Culoare1 = comboBoxBody1_Culoare.GetItemText(comboBoxBody1_Culoare.SelectedItem);
                Culoare2 = comboBoxBody2_Culoare.GetItemText(comboBoxBody2_Culoare.SelectedItem);
                Culoare3 = comboBoxBody3_Culoare.GetItemText(comboBoxBody3_Culoare.SelectedItem);
                Culoare4 = comboBoxBody4_Culoare.GetItemText(comboBoxBody4_Culoare.SelectedItem);
                BodyHas1 = label24.Text;
                BodyHas2 = label25.Text;
                BodyHas3 = label26.Text;
                BodyHas4 = label27.Text;
                ArBodyNone = new string[4] { BodyHas1, BodyHas2, BodyHas3, BodyHas4 };
                ArBody = new string[] { BodyHas1, BodyHas2, BodyHas3, BodyHas4 };
                ArCuloare = new string[4] { Culoare1, Culoare2, Culoare3, Culoare4 };
                for (int i = 0; i < 4; i++)
                {
                    if (ArBodyNone[i] == "-")
                    {
                        ArBody = ArBodyNone.Where(val => val != ArBodyNone[i]).ToArray();
                    }
                }
                for (int i = 0; i < ArBody.Length; i++)
                {
                    ParteaBody += ArBody[i] + "=" + "\"" + ArCuloare[i] + "\"" + " ";
                }
            }
            else
            {
            }
            if (label28.Text != "-")
            {
                Culoare1Lichid = comboBoxLichid1_Culoare.GetItemText(comboBoxLichid1_Culoare.SelectedItem);
                Culoare2Lichid = comboBoxLichid2_Culoare.GetItemText(comboBoxLichid2_Culoare.SelectedItem);
                Culoare3Lichid = comboBoxLichid3_Culoare.GetItemText(comboBoxLichid3_Culoare.SelectedItem);
                Culoare4Lichid = comboBoxLichid4_Culoare.GetItemText(comboBoxLichid4_Culoare.SelectedItem);
                Lichid1 = label28.Text;
                Lichid2 = label29.Text;
                Lichid3 = label30.Text;
                Lichid4 = label31.Text;
                ArLichidNone = new string[4] { Lichid1, Lichid2, Lichid3, Lichid4 };
                ArLichid = new string[] { Lichid1, Lichid2, Lichid3, Lichid4 };
                ArCuloareLichid = new string[4] { Culoare1Lichid, Culoare2Lichid, Culoare3Lichid, Culoare4Lichid };
                for (int i = 0; i < 4; i++)
                {
                    if (ArLichidNone[i] == "-")
                    {
                        ArLichid = ArLichidNone.Where(val => val != ArLichidNone[i]).ToArray();
                    }
                }
                for (int i = 0; i < ArLichid.Length; i++)
                {
                    ParteaLichid += ArLichid[i] + "=" + "\"" + ArCuloareLichid[i] + "\"" + " ";
                }
            }
            else
            {
            }
            string tempTextCommand = "./awtool.sh " + parteaNumeTOATEPdf + " " + ParteaBody + ParteaLichid + varMapping + 
                varArt + varWtempfolder + varDpivar + varTexturevar + varnoCompositeCache +
                varNocachevar + varNoLayerCache + vardisableTiledProcessing + vargeneratePsdMetadata + 
                varOverrideDPIvar+ varoverrideTextureSize + varOutputTextvar;
            tempTextCommand = tempTextCommand.Replace("\\", "/");
            tempTextCommand = tempTextCommand.Replace("D:/AWtoolDATA", "../AWtoolDATA");
            txtBoxCommanda.Text = tempTextCommand;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listPdfs);
            selectedItems = listPdfs.SelectedItems;
            if (listPdfs.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listPdfs.Items.Remove(selectedItems[i]);
            }
            ParteaSiAduna();
        }
        private void btnRemoveJson_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listJson);
            selectedItems = listJson.SelectedItems;
            if (listJson.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listJson.Items.Remove(selectedItems[i]);
            }
            MasterMethodsReadJson();
        }
        private void button1_Add_Click(object sender, EventArgs e)
        {
            front1Plus = textBox1_ID.Text;
            front2Plus = textBox1_ID.Text;
            front3Plus = textBox1_ID.Text;
            front4Plus = textBox1_ID.Text;
            front5Plus = textBox1_ID.Text;
            front6Plus = textBox1_ID.Text;
            front7Plus = textBox1_ID.Text;
            comboBox1Id.Items.Add(textBox1_ID.Text);
            comboBox2Id.Items.Add(textBox1_ID.Text);
            comboBox3Id.Items.Add(textBox1_ID.Text);
            comboBox4Id.Items.Add(textBox1_ID.Text);
            comboBox5Id.Items.Add(textBox1_ID.Text);
            comboBox6Id.Items.Add(textBox1_ID.Text);
            comboBox7Id.Items.Add(textBox1_ID.Text);
        }
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;
        public void btnDirect_Click(object sender, EventArgs e)
        {
            if (caleAbsData.Contains("\\nas"))
            {
                CopyDirAll(caleAbsData + varCaleArtworksOnly, @"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\", "*.json", true);
                CopyDirAll(caleAbsData + varCalePdf, @"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\PDF\\", "*.pdf", false);
            }
            else
            {
            }
            string path = @"d:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\artwork\\" + varArtName;
            if (File.Exists(path))
            {
                for (int i = 0; i < 9; i++)
                {
                    string pathPngtmp = path.Replace(".png", "_" + i + "_.png");
                    if (File.Exists(pathPngtmp))
                    {
                    }
                    else
                    {
                        pathPngtmp = path.Replace(".png", "_" + i + "_.png");
                        File.Copy(path, pathPngtmp);
                        i = 9;
                    }
                }
                File.Delete(path);
            }
            var prc = Process.GetProcessesByName("cmd");
            if (prc.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = prc[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(prc[0].MainWindowHandle);
                Clipboard.SetText(txtBoxCommanda.Text);
                CreateCommandLineText();
                Thread.Sleep(800);
                SendKeys.Send("^+V");
                Thread.Sleep(200);
                SendKeys.Send("{ENTER}");
            }
            if (watcher.EnableRaisingEvents == true)
            {
                watcher.Created -= OnCreated;
                watcher.EnableRaisingEvents = false;
                watchPng();
            }
            else
            {
                watchPng();
            }
        }
        private void Invoker()
        {
            CheckifArtIsReady ();
            Form currentForm = this;
            FlashWindowEx(currentForm);
            PlayaSong();
            varRulari = 0;
        }
        public void PlayaSong()
        {
            Thread.Sleep(20);
            SoundPlayer splayer = new SoundPlayer(@"c:\Windows\Media\Alarm07.wav");
            splayer.Play();
            MessageBox.Show(new Form() { TopMost = true },
                       "Artwork done. Aw is on nas /n temp folder is on nas in mapping!",
                     "Artwork message",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
        }
        private static FileSystemWatcher watcher = new FileSystemWatcher();
        private void watchPng()
        {
            varRulari = 1;
            string path = @"d:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\artwork\\";
            watcher.Path = path;
            watcher.Filter = "*.png";
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
        }
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            watcher.Created -= OnCreated;
            Invoke((MethodInvoker)Invoker);
        }
        private void CreateStringHistoryText()
        {
            string filedirectory = @"d:\AWtoolDATA\zHistory\";
            string fileName = @"d:\AWtoolDATA\zHistory\history_paths.txt";
            string dataPathCreated = DateTime.Now.ToString();
            string pathSidata = caleAbsData + "," + dataPathCreated;
            Directory.CreateDirectory(filedirectory);
            try
            {
                if (File.Exists(fileName))
                {
                    File.AppendAllText(fileName, pathSidata + Environment.NewLine);
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine(pathSidata);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"{Ex.ToString()}");
            }
        }
        private void CreateCommandLineText()
        {
            string fileName = @"" + caleAbsData + caleAbsDataJson + "\\command_line.txt";
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(txtBoxCommanda.Text);
                }
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        public bool SupportMultipleContent { get; set; }
        public void Lista1_Load2()
        {
            int iNrCombo = 0;
            foreach (Control x in panel1Fronturi.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "IdFrontName";
                    ((ComboBox)x).ValueMember = "IdFrontName";
                    ((ComboBox)x).SelectedIndex = iNrCombo;
                    iNrCombo++;
                }
            }
            int CountBody = 0;
            foreach (Control x in panel_body.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "IdBodyName";
                    ((ComboBox)x).ValueMember = "IdBodyName";
                    string foundString = ((ComboBox)x).FindStringExact("none").ToString();
                    int foundIndex = ((ComboBox)x).FindStringExact(nameBodyNr[CountBody]);
                    if (foundIndex == -1)
                    {
                        ((ComboBox)x).SelectedIndex = ((ComboBox)x).FindStringExact("none");
                    }
                    else
                    {
                        ((ComboBox)x).SelectedIndex = foundIndex;
                    }
                    CountBody++;
                }
            }
            int CountColorBody = 0;
            foreach (Control x in panelColorBody.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "IdBodyColor";
                    ((ComboBox)x).ValueMember = "IdBodyColor";
                    CountColorBody++;
                }
            }
            int CountLichid = 0;
            foreach (Control x in panelLichid.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "IdLichidName";
                    ((ComboBox)x).ValueMember = "IdLichidName";
                    string foundString = ((ComboBox)x).FindStringExact("none").ToString();
                    int foundIndex = ((ComboBox)x).FindString(nameCuloriNr[CountLichid]);
                    if (foundIndex == -1)
                    {
                        ((ComboBox)x).SelectedIndex = ((ComboBox)x).FindStringExact("none");
                    }
                    else
                    {
                        ((ComboBox)x).SelectedIndex = foundIndex;
                    }
                    CountLichid++;
                }
            }
            int CountCuloareLichid = 0;
            foreach (Control x in panelColorLichid.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DisplayMember = "IdLichidColor";
                    ((ComboBox)x).ValueMember = "IdLichidColor";
                    CountCuloareLichid++;
                }
            }
        }
        public void ClearDisplays()
        {
            textBoxInfoId.Text = "";
            comboBox1Id.Items.Clear();
            comboBox2Id.Items.Clear();
            comboBox3Id.Items.Clear();
            comboBox4Id.Items.Clear();
            comboBox5Id.Items.Clear();
            comboBox6Id.Items.Clear();
            comboBox7Id.Items.Clear();
            comboBox1Id.ResetText();
            comboBox2Id.ResetText();
            comboBox3Id.ResetText();
            comboBox4Id.ResetText();
            comboBox5Id.ResetText();
            comboBox6Id.ResetText();
            comboBox7Id.ResetText();
            comboBoxBody1_Culoare.Items.Clear();
            comboBoxBody2_Culoare.Items.Clear();
            comboBoxBody3_Culoare.Items.Clear();
            comboBoxBody4_Culoare.Items.Clear();
            comboBoxLichid1_Culoare.Items.Clear();
            comboBoxLichid2_Culoare.Items.Clear();
            comboBoxLichid3_Culoare.Items.Clear();
            comboBoxLichid4_Culoare.Items.Clear();
            comboBoxBody1_Culoare.ResetText();
            comboBoxBody2_Culoare.ResetText();
            comboBoxBody3_Culoare.ResetText();
            comboBoxBody4_Culoare.ResetText();
            comboBoxLichid1_Culoare.ResetText();
            comboBoxLichid2_Culoare.ResetText();
            comboBoxLichid3_Culoare.ResetText();
            comboBoxLichid4_Culoare.ResetText();
            label24.Text = "-";
            label25.Text = "-";
            label26.Text = "-";
            label27.Text = "-";
            label28.Text = "-";
            label29.Text = "-";
            label30.Text = "-";
            label31.Text = "-";
            checkBox_Liquid.CheckState = CheckState.Unchecked;
            checkBox_Body.CheckState = CheckState.Unchecked;
        }
        public void LoadJson()
        {
            ClearDisplays();
            string varTempCaleJson = listJson.Items[0].ToString();
            string filepath = caleAbsData + varCaleJson + varTempCaleJson;
            try
            {
                if (listJson.Items.Count > 0)
                {
                    List<string> fronturi = new List<string>(contorFronturi);
                    using (StreamReader r = new StreamReader(filepath))
                    {
                        string idsiculoriSearchText = r.ReadToEnd();
                        dynamic results = JsonConvert.DeserializeObject<dynamic>(idsiculoriSearchText);
                        var id = results.id;
                        var name = results.name;
                        var inputLenght = results.inputs.Count;
                        int contorFronturi = inputLenght;
                        int iNrCombo = 0;
                        string noColor = "null";
                        InputsList.Clear();
                        InputListColorId.Clear();
                        InputListColors.Clear();
                        textBoxCollectionId.Text = "";
                        textBoxArtworkName.Text = "=LEFT(M2,9)" +  "=CONCATENATE(LEFT(M2,5),MID(M2,9,5),\"_hero\")";
                        textBoxAdditionalCollectionIDs.Text = "";
                        textBoxAdditionalGroupIds.Text = "";
                        textBoxMappingJsonFile.Text = "";
                        textBoxArtworkId.Text = "";
                        textBoxArtworkRemove.Text = "";
                        textBoxArtworkReprocess.Text = "";
                        textBoxSearchingPath.Text = "=LEFT(M2,5)";
                        textBoxInputsExcel.Text = "";
                        textBoxColorsExcel.Text = "";
                        textBoxInputsPdfNames.Text = "";
                        for (int i = 0; i < inputLenght; i++)
                        {
                            try
                            {
                                if (!string.IsNullOrWhiteSpace(Convert.ToString(results.inputs[i].colors[0].name)))
                                {
                                    noColor = "its";
                                }
                            }
                            catch 
                            {
                                noColor = "null";
                            }
                            try
                            {
                                    string inputBody = results.inputs[i].id.ToString();
                                try
                                {
                                    if (string.IsNullOrEmpty(Convert.ToString(results.inputs[i].data)))
                                    {
                                        if (string.IsNullOrEmpty(Convert.ToString(results.inputs[i].colors)))
                                        {
                                            Log.Information("are data alpha " + i);
                                            InputsList.Add(results.inputs[i].id.ToString());
                                            foreach (var item in InputsList)
                                            {
                                                Log.Information("InputsList " + item);
                                            }
                                        }
                                        else
                                        {
                                            InputListColorId.Add(results.inputs[i].id.ToString());
                                            for (int l = 0; l < results.inputs[i].colors.Count; l++)
                                            {
                                                InputListColors.Add(results.inputs[i].colors[l].name.ToString());
                                            }
                                        }
                                    }
                                }
                                catch (Exception Ex)
                                {
                                    Log.Information("err alpha " +i+"// "+Ex);
                                }
                                try
                                    {
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    if (noColor != "null")
                                    {
                                        int inputLenghtColors = results.inputs[i].colors.Count;
                                        string inputBodyColors = results.inputs[i].colors[0].name.ToString();
                                        contorFronturi--;
                                        textBoxInfoId.Text += ("name color: " + inputBody + Environment.NewLine);
                                        textBoxInfoId.Text += ("    color:  " + results.inputs[i].colors[0].name.ToString() + Environment.NewLine);
                                        textBoxInfoId.Text += ("    colors no: : " + inputLenghtColors);
                                        textBoxInfoId.Text += (Environment.NewLine);
                                        switch (iNrCombo)
                                        {
                                            case 0:
                                                label24.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxBody1_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxBody1_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 1:
                                                label25.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxBody2_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxBody2_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 2:
                                                label26.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxBody3_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxBody3_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 3:
                                                label27.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxBody4_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxBody4_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 4:
                                                label28.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxLichid1_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxLichid1_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 5:
                                                label29.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxLichid2_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxLichid2_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 6:
                                                label30.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxLichid3_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxLichid3_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                            case 7:
                                                label31.Text = inputBody;
                                                for (int j = 0; j < inputLenghtColors; j++)
                                                {
                                                    comboBoxLichid4_Culoare.Items.Add(results.inputs[i].colors[j].name.ToString());
                                                    comboBoxLichid4_Culoare.SelectedIndex = 0;
                                                }
                                                iNrCombo++;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (Regex.IsMatch(inputBody, "alpha"))
                                        {
                                            textBoxInfoId.Text += ("alpha: " + inputBody + Environment.NewLine);
                                            contorFronturi--;
                                        }
                                        else
                                        {
                                            textBoxInfoId.Text += ("inputs: " + inputBody + Environment.NewLine);
                                            fronturi.Add(inputBody);
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {
                                    Log.Information("err json  " + exx.ToString());
                                }
                        }
                        for (int l = 0; l < 7 - contorFronturi; l++)
                        {
                            fronturi.Add("none");
                        }
                        int contorFr = 0;
                        foreach (string fr in fronturi)
                        {
                            foreach (Control x in panel1Fronturi.Controls)
                            {
                                if (x is ComboBox)
                                {
                                    ((ComboBox)x).Items.Add(fr);
                                    ((ComboBox)x).DisplayMember = fr;
                                    ((ComboBox)x).ValueMember = fr;
                                    ((ComboBox)x).SelectedIndex = 0;
                                    contorFr++;
                                }
                            }
                        }
                    }
                    try
                    {
                        int iFrNrCombo = 0;
                        foreach (Control x in panel1Fronturi.Controls)
                        {
                            if (x is ComboBox)
                            {
                                ((ComboBox)x).SelectedIndex = iFrNrCombo;
                                iFrNrCombo++;
                            }
                        }
                    }
                    catch 
                    {
                    };
                    try
                    {
                        foreach (Control x in panel1Fronturi.Controls)
                        {
                            if (x is ComboBox)
                            {
                                string foundString = ((ComboBox)x).FindStringExact("none").ToString();
                                var foundIndex = ((ComboBox)x).FindStringExact("none");
                                if (((ComboBox)x).Text == "none")
                                {
                                    ((ComboBox)x).Items.Clear();
                                    ((ComboBox)x).ResetText();
                                    ((ComboBox)x).Hide();
                                }
                                else
                                {
                                    ((ComboBox)x).Show();
                                }
                            }
                        }
                        foreach (Control x in panelColorBody.Controls)
                        {
                            if (x is ComboBox)
                            {
                                if (((ComboBox)x).Text == "")
                                {
                                    ((ComboBox)x).Items.Clear();
                                    ((ComboBox)x).ResetText();
                                    ((ComboBox)x).Hide();
                                }
                                else
                                {
                                    ((ComboBox)x).Show();
                                }
                            }
                        }
                        foreach (Control x in panelColorLichid.Controls)
                        {
                            if (x is ComboBox)
                            {
                                if (((ComboBox)x).Text == "")
                                {
                                    ((ComboBox)x).Items.Clear();
                                    ((ComboBox)x).ResetText();
                                    ((ComboBox)x).Hide();
                                }
                                else
                                {
                                    ((ComboBox)x).Show();
                                }
                            }
                        }
                    }
                    catch 
                    {
                    };
                }
                else
                {
                    MessageBox.Show("No json file found");
                }
            }
            catch (Exception Ex)
            {
                Log.Information("ceva la json load" + Ex.ToString());
            }
        }
        #region history temp
        public class HistoryTemp
        {
            private string caleHistoryTemp { get; set; }
            public HistoryTemp(string pathForHistoryTemp)
            {
                PathInHistoryTemp = pathForHistoryTemp;
            }
            public string PathInHistoryTemp
            {
                get { return caleHistoryTemp; }
                set { caleHistoryTemp = value; }
            }
            public override string ToString()
            {
                return caleHistoryTemp;
            }
        }
        #endregion
        public class IdFront
        {
            public string IdFrontName
            {
                get;
                set;
            }
            public IdFront(string n)
            {
                IdFrontName = n;
            }
        }
        public class IdBody
        {
            public string IdBodyName
            {
                get;
                set;
            }
            public IdBody(string n)
            {
                IdBodyName = n;
            }
        }
        public class IdBodySiColor
        {
            private string namebody;
            private string namebodyColor;
            public IdBodySiColor() { }
            public IdBodySiColor(string nameForBody, string nameForColor)
            {
                IdBodyName = nameForBody;
                IdBodyColor = nameForColor;
            }
            public string IdBodyName
            {
                get { return namebody; }
                set { namebody = value; }
            }
            public string IdBodyColor
            {
                get { return namebodyColor; }
                set { namebodyColor = value; }
            }
        }
        public class IdLichidSiColor
        {
            private string nameLichid;
            private string nameLichidColor;
            public IdLichidSiColor() { }
            public IdLichidSiColor(string nameForLichid, string nameForLichidColor)
            {
                IdLichidName = nameForLichid;
                IdLichidColor = nameForLichidColor;
            }
            public string IdLichidName
            {
                get { return nameLichid; }
                set { nameLichid = value; }
            }
            public string IdLichidColor
            {
                get { return nameLichidColor; }
                set { nameLichidColor = value; }
            }
        }
        public class IdLichid
        {
            public string IdLichidName
            {
                get;
                set;
            }
            public IdLichid(string n)
            {
                IdLichidName = n;
            }
        }
        public class ColorsBody
        {
            public string ColorsBodyName
            {
                get;
                set;
            }
            public ColorsBody(string n)
            {
                ColorsBodyName = n;
            }
        }
        public class ColorsLiquid
        {
            public string ColorsLiquidName
            {
                get;
                set;
            }
            public ColorsLiquid(string n)
            {
                ColorsLiquidName = n;
            }
        }
        private void button1_OpenCale_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)
            {
                string destinat = "/R=\"" + caleAbsData + "tab 1 add.tab" + "\"" + " /T";
                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);
                }
            }
            else
            {
                Process.Start("explorer.exe", @caleAbsData);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Process photoViewer = new Process();
            string fullpath = GetProcessPath("Photoshop");
            if (!string.IsNullOrEmpty(fullpath))
            {
                photoViewer.StartInfo.FileName = fullpath;
                string pngPath = @caleAbsData + varCaleArtwork + varArtName;
                pngPath = pngPath.Replace("\\\\", "\\");
                pngPath = pngPath.Replace("nas", "\\nas");
                photoViewer.StartInfo.Arguments = pngPath;
                photoViewer.Start();
            }
            else
            {
                string pngPath = @caleAbsData + varCaleArtwork + varArtName;
                pngPath = pngPath.Replace("\\\\", "\\");
                pngPath = pngPath.Replace("nas", "\\nas");
                new Process
                {
                    StartInfo = new ProcessStartInfo(@pngPath)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
        }
        private void buttonOpenMax_Click_1(object sender, EventArgs e)
        {
            string maxPath = @caleAbsData;
            string[] files_maxes = Directory.GetFiles(caleAbsData, "*.max");
            string[] files_maxeswithNr = { "" };
            var fileNames = Directory.GetFiles(caleAbsData, "*.max");
            string pattern = "*.max";
            var dirInfo = new DirectoryInfo(caleAbsData);
            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).First();
            string MsCommand = "resetMaxFile #noPrompt \nloadMaxFile \"" + file + "\"";
            string docPath = @"d:\AWtoolDATA\_script\max";
            string MsCommandNew = MsCommand.Replace(@"\", @"\\");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ResetAndOpen.ms")))
            {
                outputFile.WriteLine(MsCommandNew);
            }
            var prc = Process.GetProcessesByName("3dsmax");
            if (prc.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = prc[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
        }
        private void buttonOpenJson_Click(object sender, EventArgs e)
        {
            string jsonPath = @caleAbsData + varCaleJson + varJsonName;
            jsonPath = jsonPath.Replace("\\\\", "\\");
            jsonPath = jsonPath.Replace("nas", "\\nas");
            new Process
            {
                StartInfo = new ProcessStartInfo(@jsonPath)
                {
                    UseShellExecute = true
                }
            }.Start();
        }
        public string GetProcessPath(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            if (processes.Length > 0)
            {
                return processes[0].MainModule.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
        public void CopyFilesJob(string source, string target)
        {
            byte[] buffer = new byte[1024 * 1024];
            using (FileStream fsin = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                long fileLength = new System.IO.FileInfo(source).Length;
                using (FileStream fsout = new FileStream(target, FileMode.Create, FileAccess.Write))
                {
                    long totalBytes = 0;
                    int currentBlockSize = 0;
                    while ((currentBlockSize = fsin.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytes += currentBlockSize;
                        double persentage = (totalBytes * 100) / fileLength;
                        fsout.Write(buffer, 0, currentBlockSize);
                        metProgressChanged((int)(persentage));
                    }
                }
            }
        }
        public void metProgressChanged(int e)
        {
            this.Invoke(new Action(() => this.progressBar1.Value = e));
            Thread.Sleep(5);
            int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) /
                (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + " %",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + " %",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + " %",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
            if (progressBar1.Value == 100)
            {
                this.Invoke(new Action(() => this.progressBar1.Value = 0));
            }
            else
            {
            }
        }
        public void CopyDirAll(string sourceDirectory, string targetDirectory, string filetype, bool folderele)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget, filetype, folderele);
        }
        public void CopyAll(DirectoryInfo source, DirectoryInfo target, string varFileType, bool folderele)
        {
            Directory.CreateDirectory(target.FullName);
            foreach (FileInfo fi in source.GetFiles(varFileType))
            {
                string srs = Path.Combine(source.FullName, fi.Name);
                string trgt = Path.Combine(target.FullName, fi.Name);
                CopyFilesJob(srs, trgt);
            }
            if (folderele)
            {
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir, varFileType, folderele);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1_caleNas.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CopyDirAll(caleAbsData + varCaleArtworksOnly, @"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\", "*.*", true);
            MessageBox.Show("Copy from nas done");
        }
        private void buttonUpdateToNas_Click(object sender, EventArgs e)
        {
            CopyDirAll(@"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\", caleAbsData + varCaleArtworksOnly, "*.*", true);
            MessageBox.Show("Copy To nas done");
        }
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            contorSearchListHistory = 0;
            ReadHistory();
            buttonSearch.Text = "Search";
        }
        public void ReadHistory()
        {
            listOfHistory.Clear();
            listaPathHistory.Clear();
            listBox_History.Text = String.Empty;
            string fileName = @"d:\AWtoolDATA\zHistory\history_paths.txt";
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] linevalues = line.Split(",");
                    stringPathJob = linevalues[0];
                    stringDataJob = linevalues[1];
                    listaPathHistory.Add(new HistoryListClasa(stringPathJob, stringDataJob));
                }
                reader.Close();
            }
            List<HistoryListClasa> listaDistincta = new List<HistoryListClasa>();
            listaDistincta = listaPathHistory.Distinct().ToList();
            listaDistincta.Sort();
            foreach (var product in listaDistincta)
            {
                listBox_History.Items.Add(new HistoryListClasa(product.PathInHistory, product.DataInHistory));
            }
        }
        protected void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (contorSearchListHistory == 0)
                {
                    SearchThread();
                }
                else
                {
                    SearchNew();
                }
            }
        }
        public void SearchThread()
        {
            listBox_History.SelectedItems.Clear();
            int topIndex = listBox_History.TopIndex;
            for (int i = listBox_History.Items.Count - 1; i >= 0; i--)
            {
                if (listBox_History.Items[i].ToString().ToLower().Contains(textBoxSearch.Text.ToLower()))
                {
                    listBox_History.SetSelected(i, true);
                    topIndex = listBox_History.SelectedIndex;
                }
                else
                    listBox_History.Items.RemoveAt(i);
            }
        }
        public void SearchNew()
        {
            buttonSearch.Text = "New Search";
            contorSearchListHistory = 1;
            ReadHistory();
            Thread.Sleep(1000);
            SearchThread();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (contorSearchListHistory == 0)
            {
                SearchThread();
                buttonSearch.Text = "New Search";
            }
            else
            {
                SearchNew();
            }
        }
        public void SearchtextChanged()
        {
            int topIndex = listBox_History.TopIndex;
            listBox_History.SelectionMode = SelectionMode.One;
            if (textBoxSearch.Text != string.Empty)
            {
                int index = listBox_History.FindString(textBoxSearch.Text);
                if (index != -1 && listBox_History.SelectedIndex != index)
                {
                    listBox_History.ClearSelected();
                    listBox_History.SetSelected(index, true);
                    topIndex = listBox_History.SelectedIndex;
                }
            }
            else
            {
                listBox_History.ClearSelected();
            }
            listBox_History.SelectionMode = SelectionMode.MultiExtended;
            listBox_History.TopIndex = topIndex;
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox_History);
            selectedItems = listBox_History.SelectedItems;
            if (listBox_History.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    caleAbsData = listBox_History.GetItemText(listBox_History.SelectedItem);
                string pattern = "data: \\d+/\\d+/\\d+ \\d+:\\d+:\\d+ \\w+   Path: ";
                string input = caleAbsData;
                caleAbsData = Regex.Replace(input, pattern, "");
                textBox1_caleNas.Text = caleAbsData;
                MasterMethods();
            }
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Mapping done. Artwork generated.");
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(800);
            e.Result = "copy done!";
        }
        private void buttonCopyJsonFromNas_Click(object sender, EventArgs e)
        {
            if (caleAbsData.Contains("\\nas"))
            {
                CopyDirAll(caleAbsData + varCaleArtworksOnly, @"D:\AWtoolDATA\" + jobFolderName_NoPause + "\\artworks\\", "*.json", true);
            }
        }
        public void buttonOnTop_Click(object sender, EventArgs e)
        {
            ariseTicket();
        }
        public void ariseTicket()
        {
            Form2 frm = new Form2(this);
            frm.UpdateValues(jobNrfr2, calePathFr2, jobAspr, jobAsprlink);
            frm.TopMost = true;
            Screen[] sc;
            sc = Screen.AllScreens;
            frm.StartPosition = FormStartPosition.Manual;
            try
            {
                frm.Left = sc[0].Bounds.Width - frm.Width + 1080;
                frm.Top = sc[0].Bounds.Height - frm.Height - 600;
            }
            catch (Exception)
            {
                throw;
            }
            if (frm != null)
            {
                frm.Show();
            }
            else
            {
                Form2 frm2 = new Form2(this);
                frm2.UpdateValues(jobNrfr2, calePathFr2, jobAspr, jobAsprlink);
                frm2.TopMost = true;
                frm2.Show();
            }
        }
        public void setMyPathToFr2()
        {
            if (frm != null)
            {
                frm.UpdateValues(jobNrfr2, calePathFr2, jobAspr, jobAsprlink);
            }
        }
        private void buttonOpenPdf1_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[0].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf2_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[1].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf3_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[2].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf4_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[3].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf5_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[4].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf6_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[5].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonOpenPdf7_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfPathfromlist = listPdfs.Items[6].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        public static string RemoveStringReader(string input)
        {
            var s = new StringBuilder(input.Length);
            using (var reader = new StringReader(input))
            {
                int i = 0;
                char c;
                for (; i < input.Length; i++)
                {
                    c = (char)reader.Read();
                    if (!char.IsWhiteSpace(c))
                    {
                        s.Append(c);
                    }
                }
            }
            return s.ToString();
        }
        private void buttonPdfPath_Click(object sender, EventArgs e)
        {
            string pdfPath = caleAbsData + @"\artworks\PDF\";
            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)
            {
                string destinat = "/R=\"" + pdfPath + "tab 1 add.tab" + "\"";
                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);
                }
            }
            else
            {
                Process.Start("explorer.exe", @pdfPath);
            }
        }
        private void buttonArtPath_Click(object sender, EventArgs e)
        {
            string artPath = caleAbsData + @"artworks\artwork\";
            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)
            {
                string destinat = "/R=\"" + artPath + "tab 1 add.tab" + "\"";
                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);
                }
            }
            else
            {
                Process.Start("explorer.exe", @artPath);
            }
        }
        private void buttonMapPath_Click(object sender, EventArgs e)
        {
            string mapPath = caleAbsData + @"artworks\mapping\";
            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)
            {
                string destinat = "/R=\"" + mapPath + "tab 1 add.tab" + "\"";
                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);
                }
            }
            else
            {
                Process.Start("explorer.exe", @mapPath);
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void buttonClearAlert_Click(object sender, EventArgs e)
        {
            textBoxALERT.Text = "";
            label36.ForeColor = Color.Green;
            label36.ForeColor = Color.Green;
        }
        public void GetMycolorOLD(int checkboxpdf)
        {
            textBox1.Text = "";
            try
            {
                string pdfPathfromlist = listPdfs.Items[checkboxpdf].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        string text = File.ReadAllText(pdfPath);
                        string factMessage = text;
                        int first = factMessage.IndexOf("<xmpTPg:PlateNames>") + "<xmpTPg:PlateNames>".Length;
                        int last = factMessage.LastIndexOf("</xmpTPg:PlateNames>");
                        string str = factMessage.Substring(first, last - first);
                        int first2 = str.IndexOf("<rdf:Seq>") + "<rdf:Seq>".Length;
                        int last2 = str.LastIndexOf("</rdf:Seq>");
                        string str2 = str.Substring(first2, last2 - first2);
                        int nrmatches = Regex.Matches(str2, "<rdf:li>").Count;
                        string str3 = str2.Trim();
                        string str4 = str3.Replace("<rdf:li>", "");
                        List<string> listOfNames = new List<string>(str4.Split("</rdf:li>"));
                        List<string> listOfNames2 = new List<string>();
                        List<string> listOfNames3 = new List<string>();
                        foreach (var input in listOfNames)
                        {
                            string input2 = input.TrimStart();
                            listOfNames2.Add(input2);
                        }
                        foreach (var input in listOfNames2)
                        {
                            string input2 = input.TrimEnd();
                            listOfNames3.Add(input2);
                        }
                        foreach (var input in listOfNames3)
                        {
                            textBox1.AppendText(input);
                            textBox1.AppendText(Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void CheckColorNamesAndPathNames(string colorString, string nameofpdf, int index)
        {
            string l = colorString;
                if (l == "black")
                {
                    string info = "A color is named black in doc \"" + nameofpdf + "\"!!";
                    ManageBoxAlert(info, index);
                }
                 if (l == "cyan")
                {
                    string info = "A color is named cyan in doc \"" + nameofpdf + "\"!!";
                    ManageBoxAlert(info, index);
                }
                 if (l == "magenta")
                {
                    string info = "A color is named magenta in doc \"" + nameofpdf + "\"!!";
                    ManageBoxAlert(info, index);
                }
                 if (l == "yellow")
                {
                    string info = "A color is named yellow in doc \"" + nameofpdf + "\"!!";
                    ManageBoxAlert(info, index);
                }
            string InputString = colorString;
            bool hasDiacritics = InputString.HasDiacritics();
            if (hasDiacritics)
            {
                string info = "A color named \""+l+"\" in \""+ nameofpdf + "\" has diacritic!!";
                ManageBoxAlert(info, index);
            }
            else
            {
                string info = "ok";
                ManageBoxAlert(info, index);
            }
        }
        private void ClearlistofInfoAndColor()
        {
            stringokwrong = "";
            listOfInfo.Clear();
            listPdfsPaths.Clear();
            textBoxALERT.ForeColor = Color.Green;
            label36.ForeColor = Color.Green;
            textBoxALERT.Text = "";
        }
        public void ManageBoxAlert(string info, int index)
        {
            stringokwrong = info + "," + stringokwrong;
            if (info != "ok" && info != null && info != Environment.NewLine && info != "")
            {
                listOfInfo.Add(info);
            }
                if (index == listPdfsPaths.Count || index < 0)
                 {
                Log.Information("-- ManageBoxAlert index = cu pdf count sau index < 0 ");
                listOfInfo.RemoveAll(s => string.IsNullOrEmpty(s));
                listOfInfo.RemoveAll(s => s=="ok");
                listOfInfo.RemoveAll(s => s == "");
                    if (listOfInfo.Count() > 0)
                    {
                        foreach (var item in listOfInfo)
                        {
                        Log.Information("-- manage box item list something wrong");
                        textBoxALERT.ForeColor = Color.Red;
                            label36.ForeColor = Color.Red;
                            textBoxALERT.AppendText(item);
                            textBoxALERT.AppendText(Environment.NewLine);
                        }
                    }
                    else
                    {
                        textBoxALERT.ForeColor = Color.Green;
                        label36.ForeColor = Color.Green;
                        textBoxALERT.Text = "ok";
                }
            }
        }
        public void CheckColorNamesAutoPdfNames()
        {
            try
            {
                for (int i = 0; i < listPdfsPaths.Count; i++)
                {
                    int pdfIndex = i;
                    string pdfPath = @listPdfsPaths[i].ToString();
                    string NameofPdfforcheck = Path.GetFileName(pdfPath);
                            bool hasDiacritics = NameofPdfforcheck.HasDiacritics();
                            if (hasDiacritics)
                            {
                                string info = "A pdf file named \"" + NameofPdfforcheck + "\" has diacritic!!";
                                ManageBoxAlert(info, pdfIndex);
                            }
                            else
                            {
                                string info = "ok";
                                ManageBoxAlert(info, pdfIndex);
                            }
                    using (PdfDocument document = PdfDocument.Open(@pdfPath))
                        {
                            if (document.TryGetXmpMetadata(out XmpMetadata metadata))
                            {
                                XDocument xmp1 = metadata.GetXDocument();
                                stringxmp1 = xmp1.ToString();
                            }
                        }
                        byte[] byteArray = Encoding.UTF8.GetBytes(stringxmp1);
                        MemoryStream stream = new MemoryStream(byteArray);
                        IXmpMeta xmp;
                        xmp = XmpMetaFactory.Parse(stream);
                        foreach (var property in xmp.Properties)
                        {
                            string resultpath = property.Path;
                            if (resultpath != null)
                            {
                                if (resultpath.Contains("PlateNames"))
                                {
                                    string result = property.Value;
                                    if (result != null)
                                    {
                                    CheckColorNamesAndPathNames(result, NameofPdfforcheck, pdfIndex);
                                    }
                                }
                            }
                        }
                    if (pdfIndex == listPdfsPaths.Count-1)
                    {
                        pdfIndex = listPdfsPaths.Count;
                       string info = null;
                        ManageBoxAlert(info, pdfIndex);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void GetMycolorVer2(int checkboxpdf)
        {
            textBox1.Text = "";
            try
            {
                string pdfPathfromlist = listPdfs.Items[checkboxpdf].ToString();
                for (int i = listPdfsPaths.Count - 1; i >= 0; i--)
                {
                    if (listPdfsPaths[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPdfsPaths[i].ToString();
                        using (PdfDocument document = PdfDocument.Open(@pdfPath))
                        {
                            if (document.TryGetXmpMetadata(out XmpMetadata metadata))
                            {
                                XDocument xmp1 = metadata.GetXDocument();
                                stringxmp1 = xmp1.ToString();
                            }
                        }
                        byte[] byteArray = Encoding.UTF8.GetBytes(stringxmp1);
                        MemoryStream stream = new MemoryStream(byteArray);
                        IXmpMeta xmp;
                        xmp = XmpMetaFactory.Parse(stream);
                        foreach (var property in xmp.Properties)
                        {
                            string resultpath = property.Path;
                            if (resultpath != null)
                            {
                                if (resultpath.Contains("PlateNames"))
                                {
                                    string result = property.Value;
                                    if (result != null)
                                    {
                                        textBox1.AppendText(result);
                                        textBox1.AppendText(Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void buttonGetNumeCulori_Click(object sender, EventArgs e)
        {
            if (checkBoxPDF1.Checked)
            {
                int checkboxpdf = 0;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF2.Checked)
            {
                int checkboxpdf = 1;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF3.Checked)
            {
                int checkboxpdf = 2;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF4.Checked)
            {
                int checkboxpdf = 3;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF5.Checked)
            {
                int checkboxpdf = 4;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF6.Checked)
            {
                int checkboxpdf = 5;
                GetMycolorVer2(checkboxpdf);
            }
            if (checkBoxPDF7.Checked)
            {
                int checkboxpdf = 6;
                GetMycolorVer2(checkboxpdf);
            }
        }
        private void textBoxRenameAw_TextChanged(object sender, EventArgs e)
        {
            switch (checkBoxRenameAw.Checked)
            {
                case false:
                    newNameAw = "";
                    ParteaEgalNone();
                    AdunaData();
                    break;
                case true:
                    newNameAw = textBoxRenameAw.Text;
                    ParteaEgalNone();
                    AdunaData();
                    break;
            }
        }
        private void button7Copypathjson_Click(object sender, EventArgs e)
        {
            string jsonPath = @caleAbsData + varCaleJson + varJsonName;
            jsonPath = jsonPath.Replace("\\\\", "\\");
            jsonPath = jsonPath.Replace("nas", "\\nas");
            Clipboard.SetText(jsonPath);
        }
        private void buttonOpenBei_Click(object sender, EventArgs e)
        {
            string varpathbPlus = textBoxBei.Text;
            string  varpathbMinus = varpathbPlus.Remove(5);
            string varpathb = varpathbMinus+@"\"+varpathbPlus;
            string pathbei = @"\\nas\grip\Artworks\Beiersdorf\"+ varpathb + @"\";
            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
            if (pname.Length > 0)
            {
                string destinat = "/L=\"" + pathbei + "tab 1 add.tab" + "\"" + " /T";
                var process = Process.GetProcessesByName("TOTALCMD64").First();
                string fullPath = process.GetMainModuleFileName();
                if (fullPath.Length > 0)
                {
                    Process.Start(fullPath, destinat);
                }
            }
            else
            {
                Process.Start("explorer.exe", @pathbei);
            }
        }
        private void buttonSearchpdfFiles_Click(object sender, EventArgs e)
        {
            richTextBoxListacupdfs.Text = "";
            richTextBoxNotFound.Text = "";
            listBoxPdfsApb.Items.Clear();
            listPathPdfsApb.Clear();
            listPdfsApbFound.Clear();
            listPdfsApbNoFound.Clear();
            buttonSearchpdfFiles.Text = "searching..";
            backgroundWorkerSearch.RunWorkerAsync();
        }
        private void BackgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            workwithnamesofpdf();
        }
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            buttonSearchpdfFiles.Text = "Search pdf files";
            foreach (var item in listPdfsApbFound)
            {
                richTextBoxListacupdfs.AppendText(item + Environment.NewLine);
                listBoxPdfsApb.Items.Add(item);
            }
            foreach (var item in listPdfsApbNoFound)
            {
                richTextBoxNotFound.AppendText(item + Environment.NewLine);
            }
        }
        private void workwithnamesofpdf()
        {
            string numePdfsJira1 = textBoxSearchFiles.Text;
            string numePdfsJira2 = numePdfsJira1.Replace(".pdf", "").Replace("\r", "|").Replace("\n", "|").Replace("\t", "|").Replace(Environment.NewLine, "|").Replace(" ", "|").Replace("||", "|");
            string[] partialnamepdflist = numePdfsJira2.Split("|");
            Log.Information("***** items for search:");
            foreach (var item in partialnamepdflist)
            {
            Log.Information(item);
            }
            Log.Information("*****");
            foreach (var item in partialnamepdflist)
            {
                string sPattern = "^\\d{5}\\.\\d{3}\\.";
                string sPattern2 = "^\\d{5}\\.[A-Z][A-Z]\\.";
                string sPattern3 = "^[A-Za-z]";
                string sPattern4 = "^\\d{5}.[A-Z][A-Z][A-Z]";
                try
                {
                    if (Regex.IsMatch(item, sPattern))
                    {
                        Log.Information("item cu 5 + 3 cifre  " + item);
                        string varpathbMinus = item.Remove(5);
                        string itempath = item.Remove(9);
                        string varpathb = varpathbMinus + @"\" + itempath;
                        string pathbei = @"\\nas\grip\Artworks\Beiersdorf\" + varpathbMinus + @"\";
                        Log.Information("item   " + item);
                        Log.Information("varpathbMinus   " + varpathbMinus);
                        Log.Information("itempath   " + itempath);
                        Log.Information("pathbei   " + pathbei);
                        SearchPdfFiles(pathbei, item);
                    }
                     if (Regex.IsMatch(item, sPattern2))
                    {
                        Log.Information("+++++ 12345.aa +++++ " );
                        Log.Information("      item " + item);
                        string varpathbMinus = item.Remove(5);
                        string pathbei = @"\\nas\grip\Artworks\Beiersdorf\" + varpathbMinus + @"\";
                        Log.Information("      path " + pathbei);
                        SearchPdfFiles(pathbei, item);
                    }
                     if (Regex.IsMatch(item, sPattern3))
                    {
                        Log.Information("item cu LITERE doar " + item);
                        string varpathbMinus = item.Remove(5);
                        string varpathb = varpathbMinus + @"\";
                        string pathbei = @"\\nas\grip\Artworks\Beiersdorf\_NIVEA\zzz-Deformed Logo\";
                        Log.Information("item logo doar ---pathbei---- " + pathbei);
                        SearchPdfFiles(pathbei, item);
                    }
                    if (Regex.IsMatch(item, sPattern4))
                    {
                        Log.Information("item cu 5 cifre si 3 LITERE doar " + item);
                        string varpathbMinus = item;
                        string itemtosearch = item.Remove(5);
                        string pathbei = @"\\nas\grip\Artworks\Beiersdorf\" + varpathbMinus + @"\";
                        Log.Information(" ---pathbei---- " + pathbei + " itemtosearch " + itemtosearch);
                        SearchPdfFiles(pathbei, itemtosearch);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare " + Environment.NewLine + " {ex.Message}" + ex.Message );
                    Log.Information("eroare cautare " +  ex.Message);
                }
            }
        }
        private void SearchPdfFiles(string pathbei, string item)
        {
            string partialName = item;
            string capstikcerpath = @"\\nas\grip\Artworks\Beiersdorf\_Capsticker\";
            string deformedlogopath = @"\\nas\grip\Artworks\Beiersdorf\_NIVEA\zzz-Deformed Logo\";
            string forsearch = "";
            if (checkBoxSearchAny.Checked)
            {
                forsearch = "*.pdf";
            }
            else
            {
                forsearch = "*"+textBoxSearchSpecial.Text;
            }
            Log.Information("----- search ------  ");
            Log.Information("     " + item);
            Log.Information("     " + pathbei);
            Log.Information("     " + forsearch);
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(pathbei);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + forsearch, SearchOption.AllDirectories);
            DirectoryInfo hdDirectoryInWhichToSearch2 = new DirectoryInfo(capstikcerpath);
            FileInfo[] filesInDir2 = hdDirectoryInWhichToSearch2.GetFiles("*" + partialName + forsearch, SearchOption.AllDirectories);
            DirectoryInfo hdDirectoryInWhichToSearch3 = new DirectoryInfo(deformedlogopath);
            FileInfo[] filesInDir3 = hdDirectoryInWhichToSearch3.GetFiles("*" + partialName , SearchOption.AllDirectories);
            if (filesInDir.Length > 0 || filesInDir2.Length > 0 || filesInDir3.Length > 0)
            {
                foreach (FileInfo foundFile in filesInDir)
                {
                    string fullName = foundFile.Name;
                    string fullNamePath = foundFile.FullName;
                    listPdfsApbFound.Add(fullName);
                    listPathPdfsApb.Add(fullNamePath);
                }
                foreach (FileInfo foundFile in filesInDir2)
                {
                    string fullName = foundFile.Name;
                    string fullNamePath = foundFile.FullName;
                    listPdfsApbFound.Add(fullName);
                    listPathPdfsApb.Add(fullNamePath);
                }
                foreach (FileInfo foundFile in filesInDir3)
                {
                    string fullName = foundFile.Name;
                    string fullNamePath = foundFile.FullName;
                    listPdfsApbFound.Add(fullName);
                    listPathPdfsApb.Add(fullNamePath);
                }
            }
            else {
                listPdfsApbNoFound.Add(partialName+" ");
            }
        }
        private void buttonOpenApbPdf_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxPdfsApb); 
            selectedItems = listBoxPdfsApb.SelectedItems;
            if (listBoxPdfsApb.SelectedIndex != -1)
            {
                Log.Information("selectedpdf  " + selectedItems[0].ToString());
                string pdfPathfromlist = selectedItems[0].ToString();
                try
                {
                    for (int i = listPathPdfsApb.Count - 1; i >= 0; i--)
                {
                    if (listPathPdfsApb[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                    {
                        string pdfPath = @listPathPdfsApb[i].ToString();
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(@pdfPath)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else { }
                }
            }
            catch (Exception)
            {
            }
        }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBoxListacupdfs.Text="";
            listBoxPdfsApb.Items.Clear();
            listPathPdfsApb.Clear();
            richTextBoxNotFound.Text = "";
        }
        private void buttonOpenApbPdfPath_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxPdfsApb);
            selectedItems = listBoxPdfsApb.SelectedItems;
            if (listBoxPdfsApb.SelectedIndex != -1)
            {
                Log.Information("selectedpdf  " + selectedItems[0].ToString());
                string pdfPathfromlist = selectedItems[0].ToString();
                try
                {
                    for (int i = listPathPdfsApb.Count - 1; i >= 0; i--)
                    {
                        if (listPathPdfsApb[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                        {
                            string pdfPath = @listPathPdfsApb[i].ToString();
                            string pathbei1 = Path.GetDirectoryName(pdfPath);
                            string pathbei = pathbei1+@"\";
                            Log.Information("pdfPath  " + pdfPath.ToString());
                            Log.Information("pathbei  " + pathbei.ToString());
                            Process[] pname = Process.GetProcessesByName("TOTALCMD64");
                            if (pname.Length > 0)
                            {
                                string destinat = "/L=\"" + pathbei + "tab 1 add.tab" + "\"" + " /T";
                                var process = Process.GetProcessesByName("TOTALCMD64").First();
                                string fullPath = process.GetMainModuleFileName();
                                if (fullPath.Length > 0)
                                {
                                    Process.Start(fullPath, destinat);
                                }
                            }
                            else
                            {
                                Process.Start("explorer.exe", @pathbei);
                            }
                        }
                        else { }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void buttonCopyNamesSelectePdfApb_Click(object sender, EventArgs e)
        {
            string listaPdfApbinClip = "";
            if (checkBoxColumn.Checked)
            {
                listaPdfApbinClip = string.Join("\n", listBoxPdfsApb.Items.OfType<object>());
            }
            else
            {
                listaPdfApbinClip = string.Join("\t", listBoxPdfsApb.Items.OfType<object>());
            }
            Clipboard.SetText(listaPdfApbinClip);
            Log.Information("listaPdfApbinClip  " + listaPdfApbinClip);
        }
        private void buttonCopypdftojob_Click(object sender, EventArgs e)
        {
            string dir = @caleAbsData+ @"artworks\PDF\"+@"newApbPdf_1";
            checkmydir(dir);
            void checkmydir(string dir)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    foreach (var item in listPathPdfsApb)
                    {
                        Log.Information("item in lista pt copiat  " + item);
                        string filename = Path.GetFileName(@item);
                        File.Copy(@item, @dir + @"\" + filename, true);
                    }
                }
                else
                {
                    var dirName = new DirectoryInfo(dir).Name;
                    string[] numar = dirName.Split('_');
                    string a = numar[1];
                    string b = string.Empty;
                    int val;
                    int newval;
                    try
                    {
                        if (Int32.TryParse(a, out val))
                        {
                            val = int.Parse(a);
                            newval = val + 1;
                            string newno = newval.ToString();
                            string newdir = @caleAbsData + @"artworks\PDF\" + @"newApbPdf_" + newno;
                            checkmydir(newdir);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        private void buttonCopySelectedPath_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxPdfsApb);
            selectedItems = listBoxPdfsApb.SelectedItems;
            if (listBoxPdfsApb.SelectedIndex != -1)
            {
                Log.Information("selectedpdf for copy path " + selectedItems[0].ToString());
                string pdfPathfromlist = selectedItems[0].ToString();
                try
                {
                    for (int i = listPathPdfsApb.Count - 1; i >= 0; i--)
                    {
                        if (listPathPdfsApb[i].ToString().ToLower().Contains(pdfPathfromlist.ToLower()))
                        {
                            string pdfPath = @listPathPdfsApb[i].ToString();
                            Log.Information("pdfPath for copy path  " + pdfPath.ToString());
                            Clipboard.SetText(pdfPath.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void button_ai_unu_Click(object sender, EventArgs e)
        {
            string pdfPath = caleAbsData + @"artworks\PDF\";
            CreateEntry(pdfPath);
            Process[] pname = Process.GetProcessesByName("Illustrator.exe");
                string destinat = @"d:\AWtoolDATA\_script\appwork\00_export for uv psd_v5 - test.jsx";
            string fullPath = @"C:\Program Files\Adobe\Adobe Illustrator 2022\Support Files\Contents\Windows\Illustrator.exe";
                   Process.Start(fullPath, destinat);
        }
        public void CreateEntry(string pdfPath)
        {
            for (int i = 0; i < pdflist.Length; i++)
            {
                string sourceFile = @listPdfsPaths[i];
                string destinationFile = @caleAbsDataPDF + "\\work\\" + "_" + numeFatza[i].ToString() +"_"+ listPdfs.Items[i].ToString();
                string directoryPath = Path.GetDirectoryName(destinationFile);
                if (!Directory.Exists(directoryPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                }
                try
                {
                    File.Copy(sourceFile, destinationFile);
                }
                catch (IOException iox)
                {
                    Log.Information("eroare copiere "+iox.Message);
                }
            }
            var fileName = @"d:\AWtoolDATA\_script\appwork\00_export for uv psd_v5 - test.jsx";
            var lineToProcess = "var pathglobal =" + "\"" + @caleAbsDataPDF + "work\\" + "\"" + ";";
            Log.Information("lineToProcess "+lineToProcess);
            var lineToAdd = lineToProcess.Replace("\\","\\\\");
            var txtLines = File.ReadAllLines(fileName).ToList();
            txtLines.RemoveAt(27);
            txtLines.Insert(27, lineToAdd);
            File.WriteAllLines(fileName, txtLines);
        }
        private void buttonOpenApb_Click(object sender, EventArgs e)
        {
            string varapb = textBoxOpenApb.Text;
            string sPattern = "^APB-\\d{}"; 
            if (Regex.IsMatch(varapb, sPattern))
            {
                Log.Information("match find apb");
            }
            else
            {
                varapb = "APB-" + varapb;
            }
            if (checkBoxBei.Checked)
            {
                 pathAPBgeneral = @"\\nas\GRIP\Artworks\_ArtworkProcessing\Beiersdorf\";
            }
            if (checkBoxGar.Checked)
            {
                 pathAPBgeneral = @"\\nas\GRIP\Artworks\_ArtworkProcessing\Garnier\";
            }
            if (checkBoxOap.Checked)
            {
                 pathAPBgeneral = @"\\nas\GRIP\Artworks\_ArtworkProcessing\OAP\";
            }
            string[] foldersAPB = Directory.GetDirectories(pathAPBgeneral, varapb+"*", SearchOption.TopDirectoryOnly);
            Log.Information(foldersAPB[0].ToString());
            if (foldersAPB.Length>0)
            {
                string varPathApb = foldersAPB[0]+@"\";
                Process[] pname = Process.GetProcessesByName("TOTALCMD64");
                if (pname.Length > 0)
                {
                    string destinat = "/L=\"" + varPathApb + "tab 1 add.tab" + "\"" + " /T";
                    var process = Process.GetProcessesByName("TOTALCMD64").First();
                    string fullPath = process.GetMainModuleFileName();
                    if (fullPath.Length > 0)
                    {
                        Process.Start(fullPath, destinat);
                    }
                }
                else
                {
                    Process.Start("explorer.exe", @varPathApb);
                }
            }
            else
            {
            }
        }
        private void buttonAddInputsExcel_Click_1(object sender, EventArgs e)
        {
            foreach (var item in InputsList)
            {
                textBoxInputsExcel.Text = textBoxInputsExcel.Text+ Environment.NewLine + item.ToString();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            foreach (var item in listPdfs.Items)
            {
                textBoxInputsPdfNames.Text = textBoxInputsPdfNames.Text + Environment.NewLine + item.ToString();
            }
        }
        private void buttonAddNameOfpdfAWname_Click(object sender, EventArgs e)
        {
            string pdfNameforexcel = listPdfs.Items[0].ToString();
            textBoxArtworkName.Text = pdfNameforexcel.Replace("_INDGfixed.pdf", "").Replace("_INDGfix.pdf", "").Replace(".pdf", "");
        }
        private void buttonColorsExcel_Click_1(object sender, EventArgs e)
        {
            foreach (var item in InputListColorId)
            {
                textBoxColorsExcel.Text = textBoxColorsExcel.Text + Environment.NewLine + item.ToString();
            }
            foreach (var item in InputListColors)
            {
                textBoxColorsExcel.Text = textBoxColorsExcel.Text + Environment.NewLine + item.ToString();
            }
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            string jsonPath = @caleAbsData + varCaleJson + varJsonName;
            jsonPath = jsonPath.Replace("\\\\", "\\");
            jsonPath = jsonPath.Replace("nas", "\\nas");
            textBoxMappingJsonFile.Text = jsonPath;
        }
        private void buttonCreateExcelline_Click_1(object sender, EventArgs e)
        {
            string whatclip = "all";
            createExcelLine(whatclip);
        }
        private void buttonCreateExcellineInputsNames_Click(object sender, EventArgs e)
        {
            string whatclip = "InputsAndName";
            createExcelLine(whatclip);
        }
        private void createExcelLine(string whatclip)
        {
            string InputsExcel = "";
            if (InputsList.Count==1)
            {
                InputsExcel = InputsList[0].ToString() + ":file" ;
            }
            else { 
                for (int i = 0; i < InputsList.Count; i++)
                {
                        InputsExcel = InputsExcel + InputsList[i].ToString() + ":file" + "\t";
                }
            }
            string InputsExcelColors = "";
            if (InputListColorId.Count == 1)
            {
                InputsExcelColors = InputListColorId[0].ToString() + ":fill";
            }
            else
            {
                for (int i = 0; i < InputListColorId.Count; i++)
                {
                    InputsExcelColors = InputsExcelColors + InputListColorId[i].ToString() + ":fill" + "\t";
                }
            }
            int nrinputs = InputsList.Count;
            string tabs = new string('\t', nrinputs);
            string taabs = new string('\t', 9) + tabs;
            string InputsExcelColorsName = "";
            for (int i = 0; i < InputListColors.Count; i++)
            {
                InputsExcelColorsName = InputsExcelColorsName + taabs + InputListColors[i].ToString() + "\n";
            }
            string CollectionId = textBoxCollectionId.Text;
            CollectionId = Regex.Replace(CollectionId, @"\t|\n|\r| |Environment.NewLine", "");
            string pdfNames = textBoxInputsPdfNames.Text;
            pdfNames = Regex.Replace(pdfNames, @"\n|\r|Environment.NewLine", "\t");
            pdfNames = Regex.Replace(pdfNames, @"\t\t", "\t");
            pdfNames = Regex.Replace(pdfNames, @"^\t", "");
            string LineExcel3 = InputsExcel + InputsExcelColors;
            string InputsExcelColorsName2 = InputsExcelColorsName.Replace("\t", "");
            string InputsExcelColorsName3 = new string('\t', nrinputs) + InputsExcelColorsName2;
            string LineExcel4 = pdfNames + "\t" + InputsExcelColorsName3;
            string LineExcel1 = "CollectionId" + "\t" + "ArtworkName" + "\t" + "AdditionalCollectionIDs" + "\t" + 
                "AdditionalGroupIds" + "\t" + "MappingJsonFile" + "\t" + "ArtworkId" + "\t" + "ArtworkRemove" + "\t" + 
                "ArtworkReprocess" + "\t" +"SearchingPath" + "\t" + InputsExcel  + InputsExcelColors;
            string LineExcel2 = CollectionId + "\t" + textBoxArtworkName.Text + "\t" + textBoxAdditionalCollectionIDs.Text + "\t" +
              textBoxAdditionalGroupIds.Text + "\t" + textBoxMappingJsonFile.Text + "\t" + textBoxArtworkId.Text + "\t" +
              textBoxArtworkRemove.Text + "\t" +
              textBoxArtworkReprocess.Text + "\t" +
              textBoxSearchingPath.Text+ "\t" + pdfNames + "\n" + InputsExcelColorsName;
            if (whatclip == "all")
            {
                string LineExcel = LineExcel1 + "\n" + LineExcel2;
                Log.Information("lineexcel " + LineExcel);
                Clipboard.SetText(LineExcel.ToString());
            }
            else if (whatclip == "InputsAndName")
            {
                string LineExcel = LineExcel3 + "\n" + LineExcel4;
                Log.Information("lineexcel " + LineExcel);
                Clipboard.SetText(LineExcel.ToString());
            }
        }
    }
    }
    internal static class Extensions
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);
        public static string GetMainModuleFileName(this Process process, int buffer = 1024)
        {
            var fileNameBuilder = new StringBuilder(buffer);
            uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
            return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) ?
                fileNameBuilder.ToString() :
                null;
        }
    }
