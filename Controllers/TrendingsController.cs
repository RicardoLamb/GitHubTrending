using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GitHubTrendings.Models;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace GitHubTrendings.Controllers
{
    public class TrendingsController : Controller
    {
        private GitHubContext db = new GitHubContext();

        // GET: Trendings
        public ActionResult Index(String busca = null)
        {
            if (busca != null)
                return View(LerJsonGitHub(busca));
            return View(LerJsonGitHub());
        }

        // GET: Trendings/Details/5
        public ActionResult Details(String id = null )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(LerJsonGitHubDetalhe(id));
        }

        // GET: Trendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Trending trending = db.Trending.Find(id);
            //if (trending == null)
            //{
            //    return HttpNotFound();
            //}
            return View(LerJsonGitHubDetalhe(id.ToString()));
        }

        // POST: Trendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdOwner,NomeOwner,Repositorio,Stars,Descricao")] Trending trending)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(trending).State = EntityState.Modified;
                db.Trending.Add(trending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trending);
        }

        static IList<TrendingSets> LerJsonGitHub(String busca = null)
        {

            System.Web.HttpContext.Current.Server.MapPath("~/");
            String appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            String physicalPath = System.Web.HttpContext.Current.Request.MapPath(appPath + "\\Content\\JsonGitHubTrending.json");

            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Content\\JsonGitHubTrending.json";
            //String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            //String strFullPathToMyFile = Path.Combine(strAppDir, "JsonGitHubTrending.json");
            StreamReader stream = new StreamReader(physicalPath);
            
            JsonTextReader reader = new JsonTextReader(stream);
            JsonSerializer serializer = new JsonSerializer();

            dynamic trending = serializer.Deserialize<RootGitHub>(reader);
            IList<TrendingSets> lista = new List<TrendingSets>();
            IList<TrendingSets> listaBusca = new List<TrendingSets>();
            foreach (var git in trending.items)
            {
                TrendingSets viewItem = new TrendingSets();
                viewItem.Repositorio = git.html_url;
                viewItem.Descricao = git.description;
                viewItem.IdOwner = git.owner.id;
                viewItem.NomeOwner = git.owner.login;
                viewItem.Stars = git.stargazers_count;
                lista.Add(viewItem);
            }
            if (busca != null)
            {
                foreach (var buscar in lista)
                {
                    if (buscar.Descricao.ToUpper().Contains(busca.ToUpper()) || buscar.Repositorio.ToUpper().Contains(busca.ToUpper()) || buscar.NomeOwner.ToUpper().Contains(busca.ToUpper()) || buscar.IdOwner.ToString().ToUpper().Contains(busca.ToUpper()) || buscar.Stars.ToString().ToUpper().Contains(busca.ToUpper()))
                    {
                        TrendingSets viewItem = new TrendingSets();
                        viewItem.Repositorio = buscar.Repositorio;
                        viewItem.Descricao = buscar.Descricao;
                        viewItem.IdOwner = buscar.IdOwner;
                        viewItem.NomeOwner = buscar.NomeOwner;
                        viewItem.Stars = buscar.Stars;
                        listaBusca.Add(viewItem);
                    }
                }
                stream.Close();
                return listaBusca;
            }

            stream.Close();
            return lista;
        }

        static Trending LerJsonGitHubDetalhe(String busca = null)
        {
            //var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Content\\JsonGitHubTrending.json";
            //String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            //StreamReader stream = new StreamReader(strAppDir + "\\Content\\JsonGitHubTrending.json");
            System.Web.HttpContext.Current.Server.MapPath("~/");
            String appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            String physicalPath = System.Web.HttpContext.Current.Request.MapPath(appPath + "\\Content\\JsonGitHubTrending.json");
            StreamReader stream = new StreamReader(physicalPath);
            JsonTextReader reader = new JsonTextReader(stream);
            JsonSerializer serializer = new JsonSerializer();

            dynamic trending = serializer.Deserialize<RootGitHub>(reader);
            IList<TrendingSets> lista = new List<TrendingSets>();
            IList<TrendingSets> listaBusca = new List<TrendingSets>();
            Trending itemBuscar = new Trending();
            foreach (var git in trending.items)
            {
                TrendingSets viewItem = new TrendingSets();
                viewItem.Repositorio = git.html_url;
                viewItem.Descricao = git.description;
                viewItem.IdOwner = git.owner.id;
                viewItem.NomeOwner = git.owner.login;
                viewItem.Stars = git.stargazers_count;
                lista.Add(viewItem);
            }
            if (busca != null)
            {
                foreach (var buscar in lista)
                {
                    if (buscar.Descricao.ToUpper().Contains(busca.ToUpper()) || buscar.Repositorio.ToUpper().Contains(busca.ToUpper()) || buscar.NomeOwner.ToUpper().Contains(busca.ToUpper()) || buscar.IdOwner.ToString().ToUpper().Contains(busca.ToUpper()) || buscar.Stars.ToString().ToUpper().Contains(busca.ToUpper()))
                    {
                        TrendingSets viewItem = new TrendingSets();
                        itemBuscar.Repositorio = buscar.Repositorio;
                        itemBuscar.Descricao = buscar.Descricao;
                        itemBuscar.IdOwner = buscar.IdOwner;
                        itemBuscar.NomeOwner = buscar.NomeOwner;
                        itemBuscar.Stars = buscar.Stars;
                        listaBusca.Add(viewItem);
                    }
                }
                stream.Close();
                return itemBuscar;
            }

            stream.Close();
            return itemBuscar;
        }

        public ActionResult Buscar(string texto)
        {
            var repositorio = GitHubTrendings.Models.TrendingSets.Repositorios.Where(n => n.Descricao.Contains(texto) || n.Repositorio.Contains(texto) || n.NomeOwner.Contains(texto) || n.IdOwner.ToString().Contains(texto) || n.Stars.ToString().Contains(texto));
            return View(repositorio);
        }
    }
}
