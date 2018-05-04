﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VueDotnetSSR.Models;

namespace VueDotnetSSR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("initialMessages")]
        public JsonResult InitialMessages()
        {
            var initialMessages = FakeMessageStore.FakeMessages.OrderByDescending(m => m.Date).Take(2);

            var initialValues = new ClientState()
            {
                Messages = initialMessages,
                LastFetchedMessageDate = initialMessages.Last().Date
            };

            return Json(initialValues);
        }

        [Route("fetchMessages")]
        public JsonResult FetchMessages(DateTime lastFetchedMessageDate)
        {
            return Json(FakeMessageStore.FakeMessages.OrderByDescending(m => m.Date).SkipWhile(m => m.Date >= lastFetchedMessageDate).Take(1));
        }
    }
}
