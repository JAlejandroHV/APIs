using AppPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPrueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MiPagina()
        {
            ViewBag.Message = "Esta es mi pagina";

            return View();
        }




        //Get all users
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            try { 
            using (Models.BDprueba db = new Models.BDprueba()) {



                var oUsuarios = (from d in db.Usuarios where d.IdUsuario > 0 select d).ToList();

                return Json(oUsuarios, JsonRequestBehavior.AllowGet);
            }
        }catch(Exception e){
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }






        //Get user by id
        [HttpGet]
        public JsonResult GetUserId(int IdUsuario)
        {
            try
            {
                using (Models.BDprueba db = new Models.BDprueba())
                {



                    var oUsuarios = (from d in db.Usuarios where d.IdUsuario == IdUsuario select d).ToList();

                    return Json(oUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        //Save User
        [HttpPost]
        public JsonResult SaveUser(Usuarios usuario)
        {
            try
            {
                using (Models.BDprueba db = new Models.BDprueba())
                {
                    var oUsuarios = new Usuarios {
                    ApellidoMaterno=usuario.ApellidoMaterno,
                    ApellidoPaterno=usuario.ApellidoPaterno,
                    Celular=usuario.Celular,
                    CURP=usuario.CURP,
                    Email=usuario.Email,
                    IdUsuario=usuario.IdUsuario,
                    Nombre=usuario.Nombre,
                    RFC=usuario.RFC
                    };

                    db.Usuarios.Add(oUsuarios);
                    db.SaveChanges();
                    return Json(oUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //Update User
        [HttpPost]
        public JsonResult UpdateUser(Usuarios usuario)
        {
            try
            {
                using (Models.BDprueba db = new Models.BDprueba())
                {
                    var oUser = db.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);

                    if (oUser != null)
                    {
                        oUser.ApellidoMaterno = usuario.ApellidoMaterno;
                        oUser.ApellidoPaterno = usuario.ApellidoPaterno;
                        oUser.Celular = usuario.Celular;
                        oUser.CURP = usuario.CURP;
                        oUser.Email = usuario.Email;
                        oUser.Nombre = usuario.Nombre;
                        oUser.RFC = usuario.RFC;



                        db.SaveChanges();
                        return Json(oUser, JsonRequestBehavior.AllowGet);
                    }
                    else {
                        return Json("Usuario no encontrado", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        //Delete User
        [HttpPost]
        public JsonResult DeleteUser(int IdUser)
        {
            try
            {
                using (Models.BDprueba db = new Models.BDprueba())
                {
                    var oUser = db.Usuarios.FirstOrDefault(x => x.IdUsuario == IdUser);

                    if (oUser != null)
                    {
                        db.Usuarios.Remove(oUser);
                        db.SaveChanges();
                        return Json(oUser, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Usuario no encontrado", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //linea de prueba








    }
}