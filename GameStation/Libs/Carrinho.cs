using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    public class Carrinho
    {
        private List<CarrinhoItem> cartItems = new List<CarrinhoItem>();
        private double total = 0.0;


        private CarrinhoItem itemInCart(CarrinhoItem item)
        {
            bool check = false;
            CarrinhoItem carrinhoItem = null;

            foreach(CarrinhoItem i in cartItems) {
                if(item.getCodigo() == i.getCodigo()) {
                    check = true;
                    carrinhoItem = i;
                }
            }

            if (check) {
                return carrinhoItem;
            } else {
                return null;
            }
        }

        public void addToCart(CarrinhoItem item)
        {
            CarrinhoItem checkItemInCart = itemInCart(item);
            if (checkItemInCart != null) {
                checkItemInCart.setQuantidade(checkItemInCart.getQuantidade() + item.getQuantidade());
            } else {
                cartItems.Add(item);
            }
        }

        
        public List<CarrinhoItem> getItems()
        {
            return cartItems;
        }
    }
}
