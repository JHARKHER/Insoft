using Microsoft.AspNetCore.Mvc;
using Insoft.Entities;
using Insoft.Models;
using Insoft.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return (Cita)HttpContext.Session.GetObject<Cita>("DataObject");
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
                    Cita Cita = GetCita();
                    Cita.Placa = cita.Placa;
                    HttpContext.Session.SetObject("DataObject", Cita);
                    return View("GuardarInfo");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult GuardarInfo(CitaGuardarViewModel Guardar, string BtnPrevious, string BtnNext, string BtnCancel)
        {
            Cita Cita = GetCita();

            if (BtnPrevious != null)
            {
                CitaBuscarViewModel info = new CitaBuscarViewModel();
                info.Placa = Cita.Placa;
               
                return View("CitaInfo", info);
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    Cita.Fecha = Guardar.Fecha;                    
                    Cita.Estado = Guardar.Estado;
                    
                    context.Citas.Add(Cita);
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
