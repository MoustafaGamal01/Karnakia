﻿
using EcomGalaxy.Models;

namespace EcomGalaxy.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly MyContext _context;

        public ShoppingCartRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
            return await _context.ShoppingCarts
                .Include(c => c.ShoppingCartItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);
        }

        public async Task AddShoppingCartAsync(ShoppingCart cart)
        {
            await _context.ShoppingCarts.AddAsync(cart);
        }

        public async Task AddShoppingCartItemAsync(ShoppingCartItem item)
        {
            await _context.ShoppingCartItems.AddAsync(item);
        }

        public async Task<ShoppingCartItem> GetShoppingCartItemAsync(int cartId, int productId)
        {
            return await _context.ShoppingCartItems
                .FirstOrDefaultAsync(i => i.ShoppingCartId == cartId && i.ProductId == productId);
        }

        public async Task RemoveShoppingCartItemAsync(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Remove(item);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
