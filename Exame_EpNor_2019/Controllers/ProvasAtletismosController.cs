using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exame_EpNor_2019.Models;

namespace Exame_EpNor_2019.Controllers
{
    public class ProvasAtletismosController : Controller
    {
        private ExameDbContext db = new ExameDbContext();



        //        //List<Atleta> atletas = Context.Db.Atletas;
        //        //List<ProvasAtletismos> provas_atletismo = Context.Db.ProvasAtletismos;

        //            <h2>Provas Atletismo</h2>

        //<p>
        //    @Html.ActionLink("Create New", "Create")
        //    |
        //    @Html.ActionLink("Todos", "Create")
        //    |
        //    @Html.ActionLink("Por Decorrer", "Create")
        //</p>

        //        // GET: ProvasAtletismos
        //        public ActionResult Index()
        //        {
        //            return View(db.ProvasAtletismos.ToList());
        //            //return View(contas.OrderBy(c => c.PrimeiroNome));
        //        }



        // GET: ProvasAtletismos
        public async Task<ActionResult> Index()
        {
            return View(await db.ProvasAtletismos.ToListAsync());
        }

        // GET: ProvasAtletismos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvasAtletismo provasAtletismo = await db.ProvasAtletismos.FindAsync(id);
            if (provasAtletismo == null)
            {
                return HttpNotFound();
            }
            return View(provasAtletismo);
        }

        // GET: ProvasAtletismos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvasAtletismos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProvasAtletismoId,Data,Designacao,Local,Distancia,Vencedor")] ProvasAtletismo provasAtletismo)
        {
            if (ModelState.IsValid)
            {
                db.ProvasAtletismos.Add(provasAtletismo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(provasAtletismo);
        }

        // GET: ProvasAtletismos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvasAtletismo provasAtletismo = await db.ProvasAtletismos.FindAsync(id);
            if (provasAtletismo == null)
            {
                return HttpNotFound();
            }
            return View(provasAtletismo);
        }

        // POST: ProvasAtletismos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProvasAtletismoId,Data,Designacao,Local,Distancia,Vencedor")] ProvasAtletismo provasAtletismo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provasAtletismo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(provasAtletismo);
        }

        // GET: ProvasAtletismos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvasAtletismo provasAtletismo = await db.ProvasAtletismos.FindAsync(id);
            if (provasAtletismo == null)
            {
                return HttpNotFound();
            }
            return View(provasAtletismo);
        }

        // POST: ProvasAtletismos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProvasAtletismo provasAtletismo = await db.ProvasAtletismos.FindAsync(id);
            db.ProvasAtletismos.Remove(provasAtletismo);
            await db.SaveChangesAsync();
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
