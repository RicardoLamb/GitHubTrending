using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GitHubTrendings.Models
{
    [Table("Trending")]
    public class Trending
    {
        public int Id { get; set; }

        [Display(Name = "Repositório")]
        public string Repositorio { get; set; }

        [Display(Name = "Descrição Repositório")]
        public string Descricao { get; set; }

        [Display(Name = "Códgo Proprietário")]
        public int IdOwner { get; set; }

        [Display(Name = "Proprietário")]
        public string NomeOwner { get; set; }

        [Display(Name = "Estrelas")]
        public int Stars { get; set; }

    }
}