using Microsoft.AspNetCore.Mvc;
using Insoft.Entities;
using Insoft.Models;
using Insoft.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Insoft.Controllers
{
    public class CitasController : Controller
    {
        private readonly ApplicationDBContext context;
  
        public CitasController(ApplicationDBContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {            
            return View("CitaInfo");
        }
        private Cita GetCita()
        {
            if (HttpContext.Session.GetObject<Cita>("DataObject") == null)
            {
                HttpContext.Session.SetObject("DataObject", new Cita());
            }
            return (Cita) 
            HttpContext.Session.GetObject<Cita>("DataObject");
        }
        private void RemoveCita()
        {
            HttpContext.Session.SetObject("DataObject", null);
        }
        [HttpPost]
        public ActionResult CitaInfo(CitaBuscarViewModel cita, string BtnPrevious, string BtnNext)
        {
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    Cita citas = GetCita();
                    citas.Placa = cita.Placa;
                    var data = context.Citas.Where(c => c.Placa == citas.Placa).ToList();
                    ViewBag.userdetails = data;
                    HttpContext.Session.SetObject("DataObject", citas);
                    return View("ListarInfo");
                }
            }
            return View();
        }

        public ActionResult ListarInfo(CitaBuscarViewModel cita, string BtnPrevious, string BtnNext)
        {
            Cita citas = GetCita();
            if (BtnPrevious != null)
            {
                CitaBuscarViewModel info = new CitaBuscarViewModel();
                info.Placa = citas.Placa;
                return View("CitaInfo", info);
            }
            if (BtnNext != null)
            {                                 
                    citas.Placa = citas.Placa;                  
                    HttpContext.Session.SetObject("DataObject", citas);
                    return View("GuardarInfo");                
            }
            return View();
        }

        [HttpPost]
        public ActionResult GuardarInfo(CitaGuardarViewModel Guardar, string BtnPrevious, string BtnNext, string BtnCancel)
        {           
            Cita citas = GetCita();

            if (BtnPrevious != null)
            {
                CitaBuscarViewModel info = new CitaBuscarViewModel();
                info.Placa = citas.Placa;
               
                return View("ListarInfo", info);
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    citas.Fecha = Guardar.Fecha;
                    citas.Estado = Guardar.Estado;
                    
                    context.Citas.Add(citas);
                    context.SaveChanges();
                    RemoveCita();

                    return View("Completado");
                }
            }
            if (BtnCancel != null)
                RemoveCita();
            return View();
        }

    }
}
