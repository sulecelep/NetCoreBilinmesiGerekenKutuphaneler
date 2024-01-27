using System;
using System.Collections.Generic;

namespace UdemySwagger.Models
{
    /// <summary>
    /// Ürün nesnesi
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// ürün id'si
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ürün adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ürün fiyatı
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// ürün eklenme tarıhi
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// ürün kategorisi
        /// </summary>
        public string Category { get; set; }
    }
}
