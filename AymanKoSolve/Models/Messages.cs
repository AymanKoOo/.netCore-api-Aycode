﻿using System;

namespace AymanKoSolve.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get;set; }

        public int ChatId { get; set; }

        public Chatt Chat { get; set; }
    }
}