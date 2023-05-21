using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WebJobMarcaNews.Data;
using WebJobMarcaNews.Models;

namespace WebJobMarcaNews.Repositories
{
    public class RepositoryNoticias
    {

        private NoticiasContext context;
        public RepositoryNoticias(NoticiasContext context)
        {
            this.context = context;
        }

        public async Task<List<Noticia>> GetNoticiasAsync()
        {
            string url = "https://e00-marca.uecdn.es/rss/portada.xml";
            XDocument doc = XDocument.Load(url);     
            var consultaNoticias = from datos in doc.Descendants("item")
                                   select datos;
            List<Noticia> news = new List<Noticia>();
            foreach (XElement tag in consultaNoticias)
            {
                Noticia noticia = new Noticia();
                    noticia.Titular = tag.Element("title").Value;
                noticia.Link = tag.Element("link").Value;
                news.Add(noticia);
            }
            return news;
        }
        public async Task InsertarNoticiasAsync(List<Noticia> news)
        {
            foreach(Noticia noticia in news)
            {
                if (!ExisteNoticia(noticia.Link))
                {
                    this.context.Noticias.Add(noticia);
                }            
            }
            await this.context.SaveChangesAsync();
        }
        public bool ExisteNoticia(string link)
        {
            var consulta = from datos in this.context.Noticias
                           where datos.Link == link
                           select datos;
            Noticia noticia =  consulta.FirstOrDefault();
            if(noticia==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
