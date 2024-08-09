﻿namespace EcomGalaxy.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public EcomGalaxy.Models.ShoppingCart.ShoppingCart ShoppingCart { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public EcomGalaxy.Models.Product.Product Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}