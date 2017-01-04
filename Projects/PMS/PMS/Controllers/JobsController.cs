using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using PagedList;


namespace PMS.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public async Task<ActionResult> Index(string sortOrder,string selectShip, string status)
        {
            var jobs = db.Jobs.Include(j => j.job);

            var ShipList = db.Ships.OrderBy(x => x.Name).Select(x => x.Name).Distinct().ToList();
            ViewBag.selectShip = new SelectList(ShipList);

            var statusList=new List<string>
            {
                "Scheduled",
                "Due",
                "Overdue"
            };
            ViewBag.selectStatus = new SelectList(statusList);

            
            ViewBag.CompNameSort= String.IsNullOrEmpty(sortOrder) ? "comp_desc" : "";
            ViewBag.DesignSort = sortOrder == "Design" ? "Design_desc" : "Design";
            ViewBag.ShipSort= sortOrder=="Ship" ? "Ship_desc" : "Ship";
            ViewBag.CategorySort= sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.StatusSort = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.TypeSort = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewBag.DateSort=sortOrder== "Date" ? "Date_desc" : "Date";

            ViewBag.CurrentShip = selectShip;
            ViewBag.CurrentStatus = status;

            if (!String.IsNullOrEmpty(selectShip))
            {
                jobs = jobs.Where(x => x.job.ship.Name == selectShip);
            }

            if (!String.IsNullOrEmpty(status))
            {
                if(status == "Scheduled")
                {
                    //jobs = jobs.Where(x => x.DueDate.Value.Subtract(DateTime.Now).Days > 30);
                    jobs = jobs.Where(x => DbFunctions.DiffDays(x.DueDate, DateTime.Now) < -30 || !x.DueDate.HasValue);
                }
                else if (status == "Due")
                {
                    //jobs = jobs.Where(x => x.DueDate.Value.Subtract(DateTime.Now).Days <= 30 && x.DueDate.Value.Subtract(DateTime.Now).Days >0);
                    jobs = jobs.Where(x => DbFunctions.DiffDays(x.DueDate, DateTime.Now) >= -30 && DbFunctions.DiffDays(x.DueDate, DateTime.Now)<0);
                }
                else if(status=="Overdue")
                {
                    //jobs = jobs.Where(x => x.DueDate.Value.Subtract(DateTime.Now).Days < 0);
                    jobs = jobs.Where(x => DbFunctions.DiffDays(x.DueDate, DateTime.Now) > 0);
                }
            }


                switch (sortOrder)
            {
                case "comp_desc":
                    jobs=jobs.OrderByDescending(x => x.job.activity.Component.Name);
                    break;
                case "Design_desc":
                    jobs = jobs.OrderByDescending(x => x.job.activity.Component.Designation);
                    break;
                case "Design":
                    jobs = jobs.OrderBy(x => x.job.activity.Component.Designation);
                    break;
                case "Ship_desc":
                    jobs = jobs.OrderByDescending(x => x.job.ship.Name);
                    break;
                case "Ship":
                    jobs = jobs.OrderBy(x => x.job.ship.Name);
                    break;
                case "Category_desc":
                    jobs = jobs.OrderByDescending(x => x.job.activity.Component.Category.Parent.Name);
                    break;
                case "Category":
                    jobs = jobs.OrderBy(x => x.job.activity.Component.Category.Parent.Name);
                    break;
                case "Status":
                    jobs = jobs.OrderBy(x => x.status);
                    break;
                case "Status_desc":
                    jobs = jobs.OrderByDescending(x => x.status);
                    break;
                case "Type":
                    jobs = jobs.OrderBy(x => x.job.activity.MaintenanceType);
                    break;
                case "Type_desc":
                    jobs = jobs.OrderByDescending(x => x.job.activity.MaintenanceType);
                    break;
                case "Date_desc":
                    jobs = jobs.OrderByDescending(x => x.DueDate);
                    break;
                case "Date":
                    jobs = jobs.OrderBy(x => x.DueDate);
                    break;
                default:
                    jobs = jobs.OrderBy(x => x.job.activity.Component.Name);
                    break;
            }
            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.ShipActivityId = new SelectList(db.ShipActivities, "Id", "Id");
            var activityNameList = db.Activities.OrderBy(x=>x.Name).Select(x => x.Name).Distinct().ToList();
            ViewBag.ActivityName = new SelectList(activityNameList);
            ViewBag.Ships = new SelectList(db.Ships, "Name", "Name");
            var designationList = db.Components.OrderBy(x => x.Designation).Select(x => x.Designation).Distinct().ToList();
            ViewBag.Designation=new SelectList(designationList);
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ShipActivityId,Name,MaintanceDuration,status,DueDate,LastDone,DueRunningHours,LastDoneRunningHours,Critical,Comments")] Job job)
        {
            
            if (ModelState.IsValid)
            {
                string comp = Request.Form["Designation"].ToString();
                Component compoment = db.Components.Where(x => x.Designation == comp).FirstOrDefault();

                string actname= Request.Form["ActivityName"].ToString();
                Activity activity = db.Activities.Where(x => x.ComponentId == compoment.Id && x.Name == actname).FirstOrDefault();

                string shipName = Request.Form["Ships"].ToString();
                Ship ship = db.Ships.Where(x => x.Name == shipName).FirstOrDefault();

                ShipActivity shipactivity = db.ShipActivities.Where(x => x.ActivityId == activity.Id && x.ShipId == ship.Id).FirstOrDefault();
                
                job.ShipActivityId = shipactivity.Id;

                job.DueRunningHours = job.DueRunningHours + job.LastDoneRunningHours;

                if (job.DueDate > DateTime.Now || !job.DueDate.HasValue)
                {
                    job.status = Status.Scheduled;
                }
                else
                {
                    job.status = Status.Due;
                }

                db.Jobs.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Ships = new SelectList(db.Ships, "Name", "Name");
            //ViewBag.Designation = new SelectList(db.Components, "Designation", "Designation");
            var activityNameList = db.Activities.OrderBy(x => x.Name).Select(x => x.Name).Distinct().ToList();
            ViewBag.ActivityName = new SelectList(activityNameList);
            ViewBag.Ships = new SelectList(db.Ships, "Name", "Name");
            var designationList = db.Components.OrderBy(x => x.Designation).Select(x => x.Designation).Distinct().ToList();
            ViewBag.Designation = new SelectList(designationList);
            return View(job);
        }

        public JsonResult DynamicDesignation(string ship)
        {
            var shipId = db.Ships.Select(x=>x).Where(x => x.Name == ship).FirstOrDefault().Id;
            var designList = db.ShipActivities.Where(x => x.ShipId == shipId).Select(x => x.activity.Component.Designation).Distinct().ToList();
            List<SelectListItem> DesignSelectList = designList.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            return Json(new SelectList(DesignSelectList, "Value", "Text"));
        }

        public JsonResult DynamicActName(string design)
        {
            var actnamelist = db.ShipActivities.Where(x => x.activity.Component.Designation == design).Select(x => x.activity.Name).Distinct().ToList();
            List<SelectListItem> ActNameSelectList= actnamelist.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            return Json(new SelectList(ActNameSelectList, "Value", "Text"));
        }

        
        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShipActivityId = new SelectList(db.ShipActivities, "Id", "Id", job.ShipActivityId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,ShipActivityId,Name,MaintanceDuration,status,DueDate,LastDone,DueRunningHours,LastDoneRunningHours,Critical,Comments")]*/ Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ShipActivityId = new SelectList(db.ShipActivities, "Id", "Id", job.ShipActivityId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
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
