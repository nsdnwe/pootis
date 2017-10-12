using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pootis.Controllers {
    public class HomeController : Controller {
        Random rnd = new Random();
        public ActionResult Index() {
            return View();
        }
        public ActionResult Kysymykset() {
            string filePath = Server.MapPath("~/kysymykset.csv");

            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream) {
                string[] Line = sr.ReadLine().Split(';');
                if(Row != 0) lines.Add(Line);
                Row++;
            }

            var data = lines.ToArray();
            var q = new Models.QuestionsVm() { Questions = lines.ToArray()};

            var o = new int[q.Questions.Length, 4];
            for (int i = 0; i < q.Questions.Length; i++) {
                var r = makeOrder();
                o[i, 0] = r[0];
                o[i, 1] = r[1];
                o[i, 2] = r[2];
                o[i, 3] = r[3];
            }
            q.Order = o;

            return View(q);
        }

        private int[] makeOrder() {
            int[] res = new int[4];
            for (int i = 0; i < 4; i++) res[i] = -1;
            for (int i = 0; i < 4; i++) {
                while (true) {
                    res[i] = rnd.Next(1, 5);
                    if (i == 0) break;
                    bool found = false;
                    for (int j = 0; j < i; j++) {
                        if (res[j] == res[i]) found = true;
                    }
                    if (!found) break;
                }
            }
            return res;
        }
    }
}