using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GitHubTrendings.Models
{
    public class TrendingSets 
    {
        private static List<TrendingSets> repositorios;

        public static List<TrendingSets> Repositorios
        {
            get
            {
                return repositorios;
            }
            set { }
        }

        [Display(Name = "Repositório")]
        public string Repositorio { get; set; }

        [Display(Name = "Descrição Repositório")]
        public string Descricao { get; set; }

        [Display(Name = "Código Proprietário")]
        public int IdOwner { get; set; }

        [Display(Name = "Proprietário")]
        public string NomeOwner { get; set; }

        [Display(Name = "Estrelas")]
        public int Stars { get; set; }

    }
}