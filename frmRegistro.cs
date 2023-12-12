using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using libzkfpcsharp;
using Sample;

namespace PryPlataformaEmpleados
{
    public partial class frmRegistro : Form
    {
        private IntPtr mDevHandle = IntPtr.Zero;
        private IntPtr FormHandle = IntPtr.Zero;
        private bool bIsTimeToDie = false;
        private byte[] FPBuffer;
        public byte[] huella;

        bool cerrar = false;

        string nombre = "";
        string email = "";
        string accion = "";

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        private const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        clsClase objC = new clsClase();

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }

        private void bnInit_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            email = txtMail.Text;

            if (objC.IniciarSesion(nombre, email))
            {
                int ret = zkfperrdef.ZKFP_ERR_OK;
                if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
                {
                    int nCount = zkfp2.GetDeviceCount();
                    if (nCount > 0)
                    {
                        lblId.Text = 0.ToString();
                        bnInit.Enabled = false;

                        byte[] paramValue = new byte[4];
                        int size = 4;
                        if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(Convert.ToInt32(lblId.Text))))
                        {
                            MessageBox.Show("OpenDevice fail");
                            zkfp2.Terminate();
                            bnInit.Enabled = true;
                            return;
                        }

                        bnInit.Enabled = false;

                        zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
                        zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                        size = 4;
                        zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
                        zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                        FPBuffer = new byte[mfpWidth * mfpHeight];

                        Thread captureThread = new Thread(new ThreadStart(DoCapture));
                        captureThread.IsBackground = true;
                        captureThread.Start();
                        bIsTimeToDie = false;

                        txtNombre.ReadOnly = true;
                        txtMail.ReadOnly = true;
                        optIngreso.Enabled = false;
                        optEgreso.Enabled=false;

                        MessageBox.Show("ATENCION: A continuacion, presione fuertemente con el pulgar sobre el lector hasta ver registrada su huella, luego realice el registro pulsando el boton.");
                    }
                    else
                    {
                        zkfp2.Terminate();
                        MessageBox.Show("No device connected!");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Verificar que el lector este conectado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o mail incorrectos.", "ERROR", MessageBoxButtons.OK);
                txtNombre.Text = "";
                txtMail.Text = "";
                txtMail.Enabled = false;
                optIngreso.Enabled = false;
                optIngreso.Checked = false;
                optEgreso.Checked = false;
                optEgreso.Enabled = false;
                bnInit.Enabled = false;
                
            }


            

            

        }


        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                int cbCapTmp = 2048;
                byte[] imgbuf = new byte[mfpWidth * mfpHeight];
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, imgbuf, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }


        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        pbHuella.Image = bmp;
                        btnRegistrar.Visible = true;


                        // Convierte el Bitmap a un arreglo de bytes (por ejemplo, en formato JPEG)
                        byte[] byteArray;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byteArray = stream.ToArray();
                        }

                        // Almacena el arreglo de bytes en tu variable "huella"
                        huella = byteArray;
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void frmRegistro_FormClosing(object sender, FormClosingEventArgs e)
        {
            bIsTimeToDie = true;
            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
            zkfp2.Terminate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtMail.Enabled = true;
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (txtMail.Text != "")
            {
                optEgreso.Enabled = true;
                optIngreso.Enabled = true;
            }
        }

        private void optIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (optIngreso.Checked == true || optEgreso.Checked == true)
            {
                bnInit.Enabled = true;
            }
        }

        private void optEgreso_CheckedChanged(object sender, EventArgs e)
        {
            if (optIngreso.Checked == true || optEgreso.Checked == true)
            {
                bnInit.Enabled = true;
            }
        }

        private void gpForm_Enter(object sender, EventArgs e)
        {

        }

        private void pbHuella_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            btnRegistrar.Visible = true;
        }

        private void pbHuella_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pbHuella_LocationChanged(object sender, EventArgs e)
        {
            btnRegistrar.Visible = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (optIngreso.Checked == true)
            {
                accion = "INGRESO";
            }
            else
            {
                if (optEgreso.Checked == true)
                {
                    accion = "EGRESO";
                }
            }
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Formatear la fecha en el formato deseado
            string fechaFormateada = fechaActual.ToString("d/MM/yyyy");
            TimeSpan tiempo = fechaActual.TimeOfDay;
            // Obtener el nombre del mes actual en formato de cadena
            string nombreMesActual = DateTime.Now.ToString("MMMM");
            // Obtener el año actual
            int anioActual = DateTime.Now.Year;
            string anio = anioActual.ToString();
            cerrar = objC.NuevoLogeo(nombre, email, fechaFormateada, accion, tiempo, anio, nombreMesActual, huella);


            if (accion == "EGRESO")
            {
                TimeSpan horaIngreso = objC.HoraIngreso(nombre, anio);
                TimeSpan horaEgreso = fechaActual.TimeOfDay;
                cerrar = objC.NuevoIngresoEgreso(nombre, fechaFormateada, horaIngreso, horaEgreso, nombreMesActual, anio);

            }

            if (cerrar == true)
            {
                this.Close();
            }
        }
    }
}
