using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftBodWA
{
    public partial class Prueba : System.Web.UI.Page
    {
        private AlmacenBO almacenBO;
        private IList<AlmacenesDTO> listaAlmacenes;

        public Prueba()
        {
            this.AlmacenBO = new AlmacenBO();
            this.listaAlmacenes = almacenBO.ListarTodos();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}