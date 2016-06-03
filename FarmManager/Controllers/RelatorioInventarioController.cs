using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using FarmManager.DAL;
using System.ComponentModel;

namespace FarmManager.Controllers
{
    public class RelatorioInventarioController : Controller
    {

        #region campos 

        private FarmContext db = new FarmContext();
        private DataTable dataTablePasto;
        private DataTable dataTablePiquete;
        private DataTable dataTableTerraNua;
        private DataTable dataTableTerraPlantio;
        private DataTable dataTableTerra;
        private DataTable dataTableGado;
        private DataTable dataTableGrao;

        #endregion

        #region propriedades

        //Pasto
        public DataTable DataTablePasto
        {
            get
            {
                var dt = ConvertToDatatable(db.Pastos.ToList());

                System.Data.DataColumn colunaTipoTerra = new System.Data.DataColumn("TPTerra", typeof(System.String));
                colunaTipoTerra.DefaultValue = "Pasto";
                dt.Columns.Add(colunaTipoTerra);

                return dt;
            }
        }

        //Piquete
        public DataTable DataTablePiquete
        {
            get
            {
                var dt = ConvertToDatatable(db.Piquetes.ToList());

                System.Data.DataColumn colunaTipoTerra = new System.Data.DataColumn("TPTerra", typeof(System.String));
                colunaTipoTerra.DefaultValue = "Piquete";
                dt.Columns.Add(colunaTipoTerra);

                return dt;
            }
        }

        //TerraNua
        public DataTable DataTableTerraNua
        {
            get
            {
                var dt = ConvertToDatatable(db.TerrasNuas.ToList());

                System.Data.DataColumn colunaTipoTerra = new System.Data.DataColumn("TPTerra", typeof(System.String));
                colunaTipoTerra.DefaultValue = "Nua";
                dt.Columns.Add(colunaTipoTerra);

                return dt;
            }
        }

        //TerraDePlantio
        public DataTable DataTableTerraPlantio
        {
            get
            {
                var dt = ConvertToDatatable(db.TerrasPlantios.ToList());

                System.Data.DataColumn colunaTipoTerra = new System.Data.DataColumn("TPTerra", typeof(System.String));
                colunaTipoTerra.DefaultValue = "Plantio";
                dt.Columns.Add(colunaTipoTerra);

                return dt;
            }
        }

        //TerraDePlantio
        public DataTable DataTableTerra
        {
            get
            {
                DataTable DataTableTerra = new DataTable();
                DataTableTerra.Merge(DataTablePasto);
                DataTableTerra.Merge(DataTableTerraPlantio);
                DataTableTerra.Merge(DataTablePiquete);
                DataTableTerra.Merge(DataTableTerraNua);
                return DataTableTerra;
            }
        }

        //Gado
        public DataTable DataTableGado
        {
            get
            {
                return ConvertToDatatable(db.Gados.ToList());
            }
        }

        //Equipamento Rural
        public DataTable DataTableEquipamentoRural
        {
            get
            {
                return ConvertToDatatable(db.EquipamentosRurais.ToList());
            }
        }

        //Grao
        public DataTable DataTableGrao
        {
            get
            {
                var dtMilho = ConvertToDatatable(db.Milhos.ToList());
                System.Data.DataColumn colunaDEGraoMilho = new System.Data.DataColumn("DEGrao", typeof(System.String));
                colunaDEGraoMilho.DefaultValue = "Milho";
                dtMilho.Columns.Add(colunaDEGraoMilho);
                var dtSoja = ConvertToDatatable(db.Sojas.ToList());
                System.Data.DataColumn colunaDEGraoSoja = new System.Data.DataColumn("DEGrao", typeof(System.String));
                colunaDEGraoSoja.DefaultValue = "Soja";
                dtSoja.Columns.Add(colunaDEGraoSoja);
                DataTable DataTableGrao = new DataTable();
                DataTableGrao.Merge(dtMilho);
                DataTableGrao.Merge(dtSoja);
                return DataTableGrao;
            }
        }

        #endregion

        #region metodos

        public ActionResult Index()
        {
            var viewer = new Microsoft.Reporting.WebForms.ReportViewer();
            viewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Relatorios\Inventario.rdlc";
            viewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DSTerra", DataTableTerra));
            viewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DSGado", DataTableGado));
            viewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DSEquipamentoRural", DataTableEquipamentoRural));
            viewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DSGrao", DataTableGrao));

            viewer.SizeToReportContent = true;
            viewer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            viewer.Height = System.Web.UI.WebControls.Unit.Percentage(100);

            ViewBag.ReportViewer = viewer;

            return View();
        }


        private DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion
    }
}