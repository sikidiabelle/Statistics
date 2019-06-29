using Client_Leger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Client_Leger.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IEnumerable<Dotation> GetListeDotations()
        {
            IEnumerable<Dotation> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Dotations");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dotation>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Dotation>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Offre> GetListeOffres()
        {
            IEnumerable<Offre> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Offres");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Offre>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Offre>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Annee> GetListeAnnees()
        {
            IEnumerable<Annee> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Annees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Annee>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Annee>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Trajectoire> GetListeTrajectoires()
        {
            IEnumerable<Trajectoire> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Trajectoires");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Trajectoire>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Trajectoire>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Realise> GetListeRealises()
        {
            IEnumerable<Realise> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Realises");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Realise>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Realise>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Periode> GetListePeriodes()
        {
            IEnumerable<Periode> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Periodes");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Periode>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Periode>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Charge> GetListeCharges()
        {
            IEnumerable<Charge> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Charges");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Charge>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Charge>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Detail> GetListeDetails()
        {
            IEnumerable<Detail> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Details");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Detail>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Detail>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }
        private IEnumerable<Commentaire> GetListeCommentaires()
        {
            IEnumerable<Commentaire> liste = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50256/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Commentaires");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<IEnumerable<Commentaire>>();
                    readTask.Wait();

                    liste = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    liste = Enumerable.Empty<Commentaire>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return liste;
        }

        public ActionResult Index()
        {
            ViewData["Dotations"] = GetListeDotations();
            ViewData["Annees"] = GetListeAnnees();
            ViewData["Offres"] = GetListeOffres();
            ViewData["Realises"] = GetListeRealises();
            ViewData["Trajectoires"] = GetListeTrajectoires();
            return View();
        }
        public ActionResult realise()
        {
            ViewData["Dotations"] = GetListeDotations();
            ViewData["Annees"] = GetListeAnnees();
            ViewData["Offres"] = GetListeOffres();
            ViewData["Realises"] = GetListeRealises();
            ViewData["Trajectoires"] = GetListeTrajectoires();
            return View();
        }
        public ActionResult vision()
        {
            ViewData["Dotations"] = GetListeDotations();
            ViewData["Annees"] = GetListeAnnees();
            ViewData["Offres"] = GetListeOffres();
            ViewData["Realises"] = GetListeRealises();
            ViewData["Trajectoires"] = GetListeTrajectoires();
            return View();
        }
        public ActionResult dotation()
        {
            ViewData["Dotations"] = GetListeDotations();
            ViewData["Annees"] = GetListeAnnees();
            ViewData["Offres"] = GetListeOffres();
            ViewData["Realises"] = GetListeRealises();
            ViewData["Trajectoires"] = GetListeTrajectoires();
            return View();
        }
        public ActionResult avancement()
        {
            ViewData["Dotations"] = GetListeDotations();
            ViewData["Annees"] = GetListeAnnees();
            ViewData["Offres"] = GetListeOffres();
            ViewData["Realises"] = GetListeRealises();
            ViewData["Trajectoires"] = GetListeTrajectoires();
            return View();
        }
    }
}