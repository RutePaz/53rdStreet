using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _53rdStreet.Models;

namespace _53rdStreet.Controllers
{
    public class MusicalsController : Controller
    {
        //cria uma variavel que representa a Base de Daos
        private MusicalDB db = new MusicalDB();

        // GET: Musicals
        public ActionResult Index()
        {
            //db.Musicals.ToList()->em sql: Select * from Agentes
            //enviar para a View uma lista com todos os Agentes
            
            return View(db.Musical.ToList());
            //return View();
        }

        // GET: Musicals/Details/5
        public ActionResult Details(int? id)
        {
            //se se escrever 'int?' é possível 
            //não fornecer o valor para o ID e não há erro

            //para caso nao ter sido fornecido o ID
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //procura na BD, o Musical cujo ID foi fornecido 
            Musical musical = db.Musical.Find(id);

            //proteção para o caso de não ter sido encontrado qq Musical que tenha o ID fornecido
            if (musical == null)
            {
                return HttpNotFound();
            }
            //entrega á View os dados do Agente encontrado
            return View(musical);
        }

        // GET: Musicals/Create
        public ActionResult Create()
        {
            //apresneta a View para se inserir um novo Agente 
            return View();
        }

        // POST: Musicals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //anotador para proteção por roubo de indentidade 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Musical,Title,Synopsis,Director,Duration,OpeningNight,Ticket,Poster")] Musical musical)
        {
            //escrever os dados de um novo musical na BD
            
            //ModelState.IsValid : confronta os dados fornecidos d View com as exigências do Modelo
                       if (ModelState.IsValid)
 {
               //adiciona um novo musical
                db.Musical.Add(musical);
                 //faz commit ás alterações
                db.SaveChanges();
                //Redirecionamento para a página de Index
                return RedirectToAction("Index");
            }
            //se houver um erro, reapresenta os dados do Agente na View
            return View(musical);
        }

        // GET: Musicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musical musical = db.Musical.Find(id);
            if (musical == null)
            {
                return HttpNotFound();
            }
            return View(musical);
        }

        // POST: Musicals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Musical,Title,Synopsis,Director,Duration,OpeningNight,Ticket,Poster")] Musical musical)
        {
            if (ModelState.IsValid)
            {
                //neste cado já existe um Agente 
                //apenas quero EDITAR os seus dados
                db.Entry(musical).State = EntityState.Modified;
                //efetuar 'Commit'
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musical);
        }

        // GET: Musicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musical musical = db.Musical.Find(id);
            if (musical == null)
            {
                return HttpNotFound();
            }
            return View(musical);
        }

        // POST: Musicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musical musical = db.Musical.Find(id);
            //remove o Agente da BD
            db.Musical.Remove(musical);
            //Commit
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
