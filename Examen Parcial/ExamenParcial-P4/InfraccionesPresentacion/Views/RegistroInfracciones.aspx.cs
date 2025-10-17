using InfraccionesDominio;
using InfraccionesNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace InfraccionesPresentacion
{
    public partial class RegistroInfracciones : System.Web.UI.Page
    {
        private ConductorBO conductorBO;
        private  VehiculoBO vehiculoDAO;
        private InfraccionBO infraccionBO;
        protected void Page_Init(object sender, EventArgs e)
        {
            conductorBO = new ConductorBO();
            vehiculoDAO = new VehiculoBO();
            infraccionBO = new InfraccionBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnBuscarConductor_Click(object sender, EventArgs e)
        {
            
                

                //string numeroLicencia = ((Button)sender).CommandArgument.ToString();
            Conductor conductor = new Conductor();
            conductor = conductorBO.ListarPorLicencia(TxtNumLicencia.Text);

                TxtConductor.Text = conductor.NombreApellidos.ToString();
                LblPuntosAcumulados.Text = conductor.PuntosAcumulados.ToString();
                
                
                DdlVehiculos.DataSource=vehiculoDAO.ListarPorConductor(conductor.ConductorId);
                DdlVehiculos.DataBind();
                /*string script = "window.onload = function() {showModalForm(); };";
                ClientScript.RegisterStartupScript(GetType(), "", script, true);*/
            

        }

        protected void BtnSeleccionarInfraccion_Click(object sender, EventArgs e)
        {

            

            string script = "window.onload = function() {modalInfracciones(); };";
                ClientScript.RegisterStartupScript(GetType(), "", script, true);

            LinkButton btn = (LinkButton)sender;
            string infraccion = (btn.CommandArgument).ToString();

            TxtInfraccion.Text = infraccion;

            //TxtMontoMulta.Text = infraccionBO.ObtenerInfraccion(id);

            
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
           
        }
    }
}