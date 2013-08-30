using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcLocalization.Utils;
using MvcLocalization.Web.Models;

namespace MvcLocalization.Web.Controllers
{
    public class ItemsController : LocalizationController
    {
        public ActionResult Index()
        {
            List<Item> items;

            using (var context = new MvcLocalizationContext())
            {
                items = context.Items.ToList();
            }

            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MvcLocalizationContext())
                {
                    context.Items.Add(item);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(item);
        }

        public ActionResult Edit(int id)
        {
            Item item = null;

            using (var context = new MvcLocalizationContext())
            {
                item = context.Items.FirstOrDefault(i => i.Id == id);
            }

            if (item == null)
            {
                return new HttpNotFoundResult();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MvcLocalizationContext())
                {
                    var editedItem = context.Items.FirstOrDefault(i => i.Id == item.Id);
                    if (editedItem == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    editedItem.Name = item.Name;
                    editedItem.Price = item.Price;
                    editedItem.Weight = item.Weight;
                    editedItem.ProducedAt = item.ProducedAt;

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            Item item = null;

            using (var context = new MvcLocalizationContext())
            {
                item = context.Items.FirstOrDefault(i => i.Id == id);
            }

            if (item == null)
            {
                return new HttpNotFoundResult();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var context = new MvcLocalizationContext())
            {
                var deletedItem = context.Items.FirstOrDefault(i => i.Id == id);
                context.Items.Remove(deletedItem);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
