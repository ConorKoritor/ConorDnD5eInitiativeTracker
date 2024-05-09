﻿namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usage
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int Times { get; set; }
        [StringLength(200)]
        public string? ActionMonsterName { get; set; }

        [StringLength(200)]
        public string? ActionName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionMonsterName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionName { get; set; }

        public virtual Action? Action { get; set; }

        public virtual LegendaryAction? LegendaryAction { get; set; }
    }
}
