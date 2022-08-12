using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassEntidades;
using ClassLogicaNegocios;

namespace PresentacionWeb
{
    public partial class Conexion : System.Web.UI.Page
    {
        private LN LN = new LN();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Ver Tabla
                    DataTable ver = LN.VerConexion();
                    if (ver != null)
                    {
                        GridView1.DataSource = ver;
                        GridView1.DataBind();
                    }


                    //llenar drop down list
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add("Busca un cliente");
                    DataTable cliente = LN.VerCliente();

                    foreach (DataRow row in cliente.Rows)
                    {
                        DropDownList1.Items.Add(new ListItem()
                        {
                            Value = row[0].ToString(),
                            Text = row[1].ToString() + " - " + row[2].ToString()
                        });
                    }


                    DropDownList2.Items.Clear();
                    DropDownList2.Items.Add("Busca un auto");
                    DataTable auto = LN.VerAutomovil();

                    foreach (DataRow row in auto.Rows)
                    {
                        DropDownList2.Items.Add(new ListItem()
                        {
                            Value = row[0].ToString(),
                            Text = row[1].ToString() + " - " + row[2].ToString()
                        });
                    }


                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Add("Busca una marca");
                    DataTable marca = LN.VerMarcas();

                    foreach (DataRow row in marca.Rows)
                    {
                        DropDownList3.Items.Add(new ListItem()
                        {
                            Value = row[0].ToString(),
                            Text = row[1].ToString()
                        });
                    }


                    DropDownList4.Items.Clear();
                    DropDownList4.Items.Add("Busca un mecanico");
                    DataTable mecanico = LN.VerMecanico();

                    foreach (DataRow row in mecanico.Rows)
                    {
                        DropDownList4.Items.Add(new ListItem()
                        {
                            Value = row[0].ToString(),
                            Text = row[1].ToString() + " - " + row[2].ToString()
                        });
                    }
                }
            }
            catch (Exception exe)
            {
                Response.Write("<script>alert('" + exe.Message + "')</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.SelectedIndex != 0 || DropDownList2.SelectedIndex != 0 || DropDownList2.SelectedIndex != 0 || DropDownList4.SelectedIndex != 0)
                {

                    bool resultado = LN.CrearConexion(new ClassEntidades.Conexion()
                    {
                        Client = Int32.Parse(DropDownList1.SelectedValue),
                        Aut = Int32.Parse(DropDownList2.SelectedValue),
                        Marc = Int32.Parse(DropDownList3.SelectedValue),
                        Mecanic = Int32.Parse(DropDownList4.SelectedValue),
                        Fecha_Entra = TextBox1.Text,
                        DescripcionFalla = TextBox2.Text
                    });

                    if (resultado)
                    {
                        Response.Write("<script>alert('se creo correctamente')</script>");
                        Response.Redirect("Conexion.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al crear')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Seleccione una opción')</script>");

                }
            }
            catch (Exception exe)
            {
                Response.Write("<script>alert('" + exe.Message + "')</script>");
            }
        }
    }
}