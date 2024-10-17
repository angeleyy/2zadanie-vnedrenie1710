using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManager.Models;


namespace _1154545
{
    public class TaskController
    {
        private readonly List<Task> _tasks = new List<Task>();
        public IActionResult Index()
        {
            return View(_tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            task.CreatedAt = DateTime.Now;
            _tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var task = _tasks.Find(t => t.ID == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            var existingTask = _tasks.Find(t => t.ID == task.ID);
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _tasks.Find(t => t.ID == id);
            _tasks.Remove(task);
            return RedirectToAction("Index");
        }
    }
}