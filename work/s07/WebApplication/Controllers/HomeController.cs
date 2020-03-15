using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication2.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(System.IO.File.ReadAllText(@"account.json"));



        public IActionResult Index()
        {
            return View(accounts);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (id == accounts[i].Number)
                {
                    return View(accounts[i]);
                }
            }

            return View(accounts);
        }


        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (id == accounts[i].Number)
                {
                    return View(accounts[i]);
                }
            }

            return View(accounts);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (id == accounts[i].Number)
                {
                    return View(accounts[i]);
                }
            }

            return View(accounts);
        }







        public IActionResult Create()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Get()
        {
            return Ok(accounts);
        }

        [HttpGet]
        public ActionResult Getid(int id)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (id == accounts[i].Number)
                {
                    return Ok(accounts[i]);
                }
            }

            return Ok(accounts);
        }


        public IActionResult Search()
        {
            return View(accounts);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Balance,Label,Owner")] Account account)
        {
            var initialJson = System.IO.File.ReadAllText(@"account.json");
            var array = JArray.Parse(initialJson);

            var itemToAdd = new JObject();
            itemToAdd["Number"] = account.Number;
            itemToAdd["Balance"] = account.Balance;
            itemToAdd["Label"] = account.Label;
            itemToAdd["Owner"] = account.Owner;
            array.Add(itemToAdd);

            var jsonToOutput = JsonConvert.SerializeObject(array, Formatting.Indented);
            System.IO.File.WriteAllText(@"account.json", jsonToOutput);




            return Ok("Customer Added Successfully");

        }




    }


    
}
