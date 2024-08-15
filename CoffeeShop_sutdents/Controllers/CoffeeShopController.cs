using Microsoft.AspNetCore.Mvc;
using CoffeeShop_sutdents.Models;

namespace CoffeeShop_sutdents.Controllers
{

    //   אנחנו בונים רק שרת   

    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeShopController : ControllerBase
    {
        // אני יוצר הזמנות משלי כדי לדמות דאטאבייס
        private static List<CoffeeOrder> _orders = new List<CoffeeOrder>();
        private static int _nextId = 1;

        // יוצר קונסטרקטור כדי לאתחל דאטא
        public CoffeeShopController() 
        {
            if(!_orders.Any())
            {
                _orders.Add(new CoffeeOrder { Id = _nextId++, CustomerName = "בני", CoffeeType = "שחור כמו החיים", Quantity = 1, OrderDate = DateTime.Now.AddHours(2) });
                _orders.Add(new CoffeeOrder { Id = _nextId++, CustomerName = "מאיר", CoffeeType = "קפה רגיל", Quantity = 1, OrderDate = DateTime.Now.AddHours(2) });
                _orders.Add(new CoffeeOrder { Id = _nextId++, CustomerName = "מתן", CoffeeType = "הפוך גדול חזק עם עבאדי", Quantity = 1, OrderDate = DateTime.Now.AddHours(2) });
            }
        }

        // להביא את כל ההזמנות שקיימות
        // GET: api/CoffeeShop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeOrder>>> GetAllOrder()
        {
            await Task.Delay(1000);
            return Ok(_orders);
        }

        // להביא הזמנה ספציפית
        // GET: api/CofeeShop/{id}

        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeOrder>> GetOrder(int id)
        {
            await Task.Delay(1000);
            var order = _orders.FirstOrDefault(order => order.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // יצירה של הזמנה חדשה

        // POST: api/CoffeeShop

        [HttpPost]
        public async Task<ActionResult<CoffeeOrder>> CreateOrder(CoffeeOrder order)
        {
            await Task.Delay(1000);
           order.Id = _nextId++;
            order.OrderDate = DateTime.Now;
            _orders.Add(order);

            return Ok(order);

        }


        // עריכה של פריט קיים
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateOrder(int id, CoffeeOrder order)
        {
            await Task.Delay(1000);
            var existOrder = _orders.FirstOrDefault(order => order.Id == id);
            if (existOrder == null)
            {
                return NotFound();
            }

            existOrder.CustomerName = order.CustomerName;
            existOrder.CoffeeType = order.CoffeeType;
            existOrder.Quantity = order.Quantity;

            return "Edit Successful";
        }

        // DELETE: api/CoffeeShop/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            await Task.Delay(1000);
            var order = _orders.FirstOrDefault(order => order.Id==id);
            if (order == null)
            {
                return NotFound();
            }
            _orders.Remove(order);

            return "מחקת בהצלחה!!!";
        }

    }
}
