using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CrudLinq.Models;
using CrudLinq.Models.Models;

namespace CrudLinq.Controllers
{
    public class UsuarioController : Controller
    {
        List<UsuarioModel> lst;
        public ActionResult Index()
        {
            using (crudlinqEntities1 db = new crudlinqEntities1 { })
            {
                     lst = (from d in db.usuario
                           select new UsuarioModel
                           {
                               Id = d.IdUsuario,
                               Nombre = d.Nombre,
                               Apellido = d.Apellido,
                               Telefono = d.Telefono
                           }).ToList();
            }
                return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(UsuarioModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (crudlinqEntities1 db = new crudlinqEntities1 { })
                    {
                        var oTabla = new usuario();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Apellido = model.Apellido;
                        oTabla.Telefono = model.Telefono;

                        db.usuario.Add(oTabla);
                        db.SaveChanges();
                    }
                        return Redirect("~/Usuario/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            UsuarioModel model = new UsuarioModel();
            using (crudlinqEntities1 db = new crudlinqEntities1())
            {
                var otabla = db.usuario.Find(Id);
                model.Nombre = otabla.Nombre;
                model.Apellido = otabla.Apellido;
                model.Telefono = otabla.Telefono;
                model.Id = otabla.IdUsuario;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crudlinqEntities1 db = new crudlinqEntities1 { })
                    {
                        var otabla = db.usuario.Find(model.Id);
                        otabla.Nombre = model.Nombre;
                        otabla.Apellido = model.Apellido;
                        otabla.Telefono = model.Telefono;

                        db.Entry(otabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Usuario/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Eliminar(int Id)
        {
            UsuarioModel model = new UsuarioModel();
            using (crudlinqEntities1 db = new crudlinqEntities1())
            {
                var otabla = db.usuario.Find(Id);
                db.usuario.Remove(otabla);
                db.SaveChanges();
               
            }
            return Redirect("~/Usuario/Index");
        }
    }
}