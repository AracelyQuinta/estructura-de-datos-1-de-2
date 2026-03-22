using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable

namespace BST_Visual
{
    public partial class Form1 : Form
    {
        // Árbol binario de búsqueda manejado por la interfaz.
        private ArbolBinarioBusqueda arbol;

        // Controles de la interfaz para entrada y comandos.
        private TextBox txtValor;
        private Button btnInsertar;
        private Button btnBuscar;
        private Button btnEliminar;
        private Button btnInOrden;
        private Button btnPreOrden;
        private Button btnPostOrden;
        private Button btnInfo;
        private Button btnLimpiar;
        private PictureBox pictureBox;
        private Label lblResultado;

        // Constructor del formulario.
        // Inicializa controles y carga un árbol de ejemplo.
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            arbol = new ArbolBinarioBusqueda();

            // Valores de ejemplo para evitar árbol vacío al inicio.
            arbol.Insertar(50);
            arbol.Insertar(30);
            arbol.Insertar(70);
            arbol.Insertar(20);
            arbol.Insertar(40);
            arbol.Insertar(60);
            arbol.Insertar(80);
        }

        // Configuración manual de los controles del formulario.
        private void InitializeComponent()
        {
            this.txtValor = new TextBox();
            this.btnInsertar = new Button();
            this.btnBuscar = new Button();
            this.btnEliminar = new Button();
            this.btnInOrden = new Button();
            this.btnPreOrden = new Button();
            this.btnPostOrden = new Button();
            this.btnInfo = new Button();
            this.btnLimpiar = new Button();
            this.pictureBox = new PictureBox();
            this.lblResultado = new Label();

            // txtValor
            this.txtValor.Location = new Point(20, 360);
            this.txtValor.Size = new Size(80, 23);

            // btnInsertar
            this.btnInsertar.Location = new Point(110, 360);
            this.btnInsertar.Size = new Size(70, 23);
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.Click += new EventHandler(this.btnInsertar_Click);

            // btnBuscar
            this.btnBuscar.Location = new Point(190, 360);
            this.btnBuscar.Size = new Size(70, 23);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

            // btnEliminar
            this.btnEliminar.Location = new Point(510, 360);
            this.btnEliminar.Size = new Size(70, 23);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

            // btnInOrden
            this.btnInOrden.Location = new Point(270, 360);
            this.btnInOrden.Size = new Size(70, 23);
            this.btnInOrden.Text = "InOrden";
            this.btnInOrden.Click += new EventHandler(this.btnInOrden_Click);

            // btnPreOrden
            this.btnPreOrden.Location = new Point(350, 360);
            this.btnPreOrden.Size = new Size(70, 23);
            this.btnPreOrden.Text = "PreOrden";
            this.btnPreOrden.Click += new EventHandler(this.btnPreOrden_Click);

            // btnPostOrden
            this.btnPostOrden.Location = new Point(430, 360);
            this.btnPostOrden.Size = new Size(70, 23);
            this.btnPostOrden.Text = "PostOrden";
            this.btnPostOrden.Click += new EventHandler(this.btnPostOrden_Click);

            // btnInfo
            this.btnInfo.Location = new Point(590, 360);
            this.btnInfo.Size = new Size(110, 23);
            this.btnInfo.Text = "Min/Max/Altura";
            this.btnInfo.Click += new EventHandler(this.btnInfo_Click);

            // btnLimpiar
            this.btnLimpiar.Location = new Point(710, 360);
            this.btnLimpiar.Size = new Size(70, 23);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

            // pictureBox
            this.pictureBox.Location = new Point(20, 20);
            this.pictureBox.Size = new Size(760, 320);
            this.pictureBox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox.BackColor = Color.White;
            this.pictureBox.Paint += new PaintEventHandler(this.pictureBox_Paint);

            // lblResultado
            this.lblResultado.Location = new Point(20, 400);
            this.lblResultado.Size = new Size(760, 50);
            this.lblResultado.BorderStyle = BorderStyle.FixedSingle;
            this.lblResultado.Text = "Resultado:";

            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnInOrden);
            this.Controls.Add(this.btnPreOrden);
            this.Controls.Add(this.btnPostOrden);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblResultado);

            this.ClientSize = new Size(820, 470);
            this.Text = "Árbol Binario de Búsqueda";
        }

        // Inserta el valor leído del cuadro de texto.
        // Actualiza la vista repintando el árbol.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                arbol.Insertar(valor);
                lblResultado.Text = $"Valor {valor} insertado.";
                pictureBox.Invalidate();
            }
            else
            {
                lblResultado.Text = "Ingrese un número válido.";
            }
        }

        // Busca el valor en el árbol y muestra mensaje de estado.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                bool encontrado = arbol.Buscar(valor);
                lblResultado.Text = encontrado ? $"Valor {valor} encontrado." : $"Valor {valor} no encontrado.";
            }
            else
            {
                lblResultado.Text = "Ingrese un número válido.";
            }
        }

        // Elimina el valor introducido y repinta el árbol.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValor.Text, out int valor))
            {
                arbol.Eliminar(valor);
                lblResultado.Text = $"Valor {valor} eliminado.";
                pictureBox.Invalidate();
            }
            else
            {
                lblResultado.Text = "Ingrese un número válido.";
            }
        }

        // Muestra recorrido inorden como texto.
        private void btnInOrden_Click(object sender, EventArgs e)
        {
            string ino = string.Join(" ", arbol.InOrden());
            lblResultado.Text = $"Inorden: {ino}";
        }

        // Muestra recorrido preorden como texto.
        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            string pre = string.Join(" ", arbol.PreOrden());
            lblResultado.Text = $"Preorden: {pre}";
        }

        // Muestra recorrido postorden como texto.
        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            string post = string.Join(" ", arbol.PostOrden());
            lblResultado.Text = $"Postorden: {post}";
        }

        // Muestra mínimo, máximo y altura del árbol.
        private void btnInfo_Click(object sender, EventArgs e)
        {
            int? min = arbol.Minimo();
            int? max = arbol.Maximo();
            int altura = arbol.Altura();
            lblResultado.Text = $"Mínimo: {min}, Máximo: {max}, Altura: {altura}";
        }

        // Limpia el árbol y actualiza la vista.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            arbol.Limpiar();
            lblResultado.Text = "Árbol limpiado.";
            pictureBox.Invalidate();
        }



        // Dibuja el árbol usando el algoritmo recursivo clásico con tamaño y separación adaptativa.
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (arbol.Raiz == null) return;

            int altura = arbol.Altura();
            int nodeRadius = Math.Clamp(26 - altura, 10, 24);
            int ySpacing = Math.Clamp(90 - altura * 4, 40, 80);

            int maxNodesAtLastLevel = (int)Math.Pow(2, Math.Max(0, altura - 1));
            int available = Math.Max(80, pictureBox.Width - 40);
            int initialOffset = Math.Clamp(available / (maxNodesAtLastLevel + 1), 30, 140);

            DibujarArbol(g, arbol.Raiz, pictureBox.Width / 2, 40, initialOffset, nodeRadius, ySpacing);
        }

        // Dibuja nodos y conexiones recursivamente.
        private void DibujarArbol(Graphics g, Nodo nodo, int x, int y, int offset, int nodeRadius, int ySpacing)
        {
            if (nodo == null) return;

            int diameter = nodeRadius * 2;
            int childOffset = Math.Max(20, (int)(offset * 0.65));
            int childY = y + ySpacing;

            if (nodo.Izquierdo != null)
            {
                int childX = x - offset;
                g.DrawLine(Pens.Black, x, y, childX, childY);
                DibujarArbol(g, nodo.Izquierdo, childX, childY, childOffset, nodeRadius, ySpacing);
            }

            if (nodo.Derecho != null)
            {
                int childX = x + offset;
                g.DrawLine(Pens.Black, x, y, childX, childY);
                DibujarArbol(g, nodo.Derecho, childX, childY, childOffset, nodeRadius, ySpacing);
            }

            Rectangle nodeRect = new Rectangle(x - nodeRadius, y - nodeRadius, diameter, diameter);
            g.FillEllipse(Brushes.LightBlue, nodeRect);
            g.DrawEllipse(Pens.Black, nodeRect);

            string text = nodo.Valor.ToString();
            SizeF textSize = g.MeasureString(text, this.Font);
            g.DrawString(text, this.Font, Brushes.Black,
                x - textSize.Width / 2,
                y - textSize.Height / 2);
        }
    }
}