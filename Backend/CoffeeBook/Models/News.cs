﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBook.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        [Column(TypeName = "nvarchar(100)")]
        private string title;
        [Column(TypeName = "nvarchar(10000)")]
        private string content;
        [Column(TypeName = "nvarchar(100)")]
        private string thumbnail;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
    }
}
